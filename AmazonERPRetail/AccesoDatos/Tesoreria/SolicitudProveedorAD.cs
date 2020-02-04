using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

using Entidades.Tesoreria;
using AccesoDatos.Util;

namespace AccesoDatos.Tesoreria
{
    public class SolicitudProveedorAD : DbConection
    {

        public SolicitudProveedorE LlenarEntidad(IDataReader oReader)
        {
            SolicitudProveedorE solicitudproveedor = new SolicitudProveedorE();
            
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idSolicitud'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				solicitudproveedor.idSolicitud = oReader["idSolicitud"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idSolicitud"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idEmpresa'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				solicitudproveedor.idEmpresa = oReader["idEmpresa"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idEmpresa"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idLocal'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				solicitudproveedor.idLocal = oReader["idLocal"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idLocal"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='codSolicitud'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				solicitudproveedor.codSolicitud = oReader["codSolicitud"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["codSolicitud"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Fecha'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				solicitudproveedor.Fecha = oReader["Fecha"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["Fecha"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idProveedor'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                solicitudproveedor.idProveedor = oReader["idProveedor"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idProveedor"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idMoneda'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				solicitudproveedor.idMoneda = oReader["idMoneda"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["idMoneda"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='impTotal'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				solicitudproveedor.impTotal = oReader["impTotal"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["impTotal"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Descripcion'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				solicitudproveedor.Descripcion = oReader["Descripcion"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["Descripcion"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Pedido'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				solicitudproveedor.Pedido = oReader["Pedido"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["Pedido"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idOrdenPago'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				solicitudproveedor.idOrdenPago = oReader["idOrdenPago"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idOrdenPago"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idConcepto'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                solicitudproveedor.idConcepto = oReader["idConcepto"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idConcepto"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Saldo'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                solicitudproveedor.Saldo = oReader["Saldo"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["Saldo"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='indEstado'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                solicitudproveedor.indEstado = oReader["indEstado"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["indEstado"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='UsuarioRegistro'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				solicitudproveedor.UsuarioRegistro = oReader["UsuarioRegistro"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["UsuarioRegistro"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='FechaRegistro'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				solicitudproveedor.FechaRegistro = oReader["FechaRegistro"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["FechaRegistro"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='UsuarioModificacion'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				solicitudproveedor.UsuarioModificacion = oReader["UsuarioModificacion"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["UsuarioModificacion"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='FechaModificacion'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				solicitudproveedor.FechaModificacion = oReader["FechaModificacion"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["FechaModificacion"]);

            //Extensiones
            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='RUC'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                solicitudproveedor.RUC = oReader["RUC"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["RUC"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='RazonSocial'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                solicitudproveedor.RazonSocial = oReader["RazonSocial"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["RazonSocial"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='desMoneda'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                solicitudproveedor.desMoneda = oReader["desMoneda"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["desMoneda"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='codOrdenPago'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                solicitudproveedor.codOrdenPago = oReader["codOrdenPago"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["codOrdenPago"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='ctaBancaria'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                solicitudproveedor.ctaBancaria = oReader["ctaBancaria"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["ctaBancaria"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='desLocal'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                solicitudproveedor.desLocal = oReader["desLocal"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["desLocal"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='TipoSolicitud'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                solicitudproveedor.TipoSolicitud = oReader["TipoSolicitud"] == DBNull.Value ? "R" : Convert.ToString(oReader["TipoSolicitud"]);

            return  solicitudproveedor;        
        }

        public SolicitudProveedorE InsertarSolicitudProveedor(SolicitudProveedorE solicitudproveedor)
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_InsertarSolicitudProveedor", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = solicitudproveedor.idEmpresa;
					oComando.Parameters.Add("@idLocal", SqlDbType.Int).Value = solicitudproveedor.idLocal;
					oComando.Parameters.Add("@codSolicitud", SqlDbType.VarChar, 20).Value = solicitudproveedor.codSolicitud;
					oComando.Parameters.Add("@Fecha", SqlDbType.SmallDateTime).Value = solicitudproveedor.Fecha;
                    oComando.Parameters.Add("@idProveedor", SqlDbType.Int).Value = solicitudproveedor.idProveedor;
                    oComando.Parameters.Add("@idMoneda", SqlDbType.VarChar, 2).Value = solicitudproveedor.idMoneda;
					oComando.Parameters.Add("@impTotal", SqlDbType.Decimal).Value = solicitudproveedor.impTotal;
					oComando.Parameters.Add("@Descripcion", SqlDbType.VarChar, 500).Value = solicitudproveedor.Descripcion;
					oComando.Parameters.Add("@Pedido", SqlDbType.VarChar, 20).Value = solicitudproveedor.Pedido;
					oComando.Parameters.Add("@idOrdenPago", SqlDbType.Int).Value = solicitudproveedor.idOrdenPago;
                    oComando.Parameters.Add("@idConcepto", SqlDbType.Int).Value = solicitudproveedor.idConcepto;
                    oComando.Parameters.Add("@UsuarioRegistro", SqlDbType.VarChar, 20).Value = solicitudproveedor.UsuarioRegistro;

                    oConexion.Open();
                    solicitudproveedor.idSolicitud = Int32.Parse(oComando.ExecuteScalar().ToString());
                }
            }

            return solicitudproveedor;
        }
        
        public SolicitudProveedorE ActualizarSolicitudProveedor(SolicitudProveedorE solicitudproveedor)
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ActualizarSolicitudProveedor", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idSolicitud", SqlDbType.Int).Value = solicitudproveedor.idSolicitud;
					oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = solicitudproveedor.idEmpresa;
					oComando.Parameters.Add("@idLocal", SqlDbType.Int).Value = solicitudproveedor.idLocal;
					oComando.Parameters.Add("@codSolicitud", SqlDbType.VarChar, 20).Value = solicitudproveedor.codSolicitud;
					oComando.Parameters.Add("@Fecha", SqlDbType.SmallDateTime).Value = solicitudproveedor.Fecha;
                    oComando.Parameters.Add("@idProveedor", SqlDbType.Int).Value = solicitudproveedor.idProveedor;
                    oComando.Parameters.Add("@idMoneda", SqlDbType.VarChar, 2).Value = solicitudproveedor.idMoneda;
					oComando.Parameters.Add("@impTotal", SqlDbType.Decimal).Value = solicitudproveedor.impTotal;
					oComando.Parameters.Add("@Descripcion", SqlDbType.VarChar, 500).Value = solicitudproveedor.Descripcion;
					oComando.Parameters.Add("@Pedido", SqlDbType.VarChar, 20).Value = solicitudproveedor.Pedido;
					oComando.Parameters.Add("@idOrdenPago", SqlDbType.Int).Value = solicitudproveedor.idOrdenPago;
                    oComando.Parameters.Add("@idConcepto", SqlDbType.Int).Value = solicitudproveedor.idConcepto;
                    oComando.Parameters.Add("@UsuarioModificacion", SqlDbType.VarChar, 20).Value = solicitudproveedor.UsuarioModificacion;

                    oConexion.Open();
                    oComando.ExecuteNonQuery();
                }
            }

            return solicitudproveedor;
        }        

        public int EliminarSolicitudProveedor(Int32 idSolicitud)
        {
            Int32 resp = 0;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_EliminarSolicitudProveedor", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idSolicitud", SqlDbType.Int).Value = idSolicitud;

                    oConexion.Open();
                    resp = oComando.ExecuteNonQuery();
                }
            }

            return resp;
        }

        public List<SolicitudProveedorE> ListarSolicitudProveedor(Int32 idEmpresa, Int32 idLocal, Int32 idProveedor, DateTime fecIni, DateTime fecFin, String indEstado)
        {
            List<SolicitudProveedorE> listaEntidad = new List<SolicitudProveedorE>();

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ListarSolicitudProveedor", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@idLocal", SqlDbType.Int).Value = idLocal;
                    oComando.Parameters.Add("@idProveedor", SqlDbType.Int).Value = idProveedor;
                    oComando.Parameters.Add("@fecIni", SqlDbType.SmallDateTime).Value = fecIni.Date;
                    oComando.Parameters.Add("@fecFin", SqlDbType.SmallDateTime).Value = fecFin.Date;
                    oComando.Parameters.Add("@indEstado", SqlDbType.Char, 1).Value = indEstado;

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
        
        public SolicitudProveedorE ObtenerSolicitudProveedor(Int32 idSolicitud)
        {        
            SolicitudProveedorE solicitudproveedor = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ObtenerSolicitudProveedor", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idSolicitud", SqlDbType.Int).Value = idSolicitud;

                    oConexion.Open();
                    
                    using (SqlDataReader oReader = oComando.ExecuteReader())
                    {
                        while (oReader.Read())
                        {
                            solicitudproveedor = LlenarEntidad(oReader);
                        }
                    }
                }
            }

            return solicitudproveedor;
        }

        public String GenerarNumSolicitudProveedor(Int32 idEmpresa, Int32 idLocal)
        {
            String Codigo = String.Empty;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_GenerarNumSolicitudProveedor", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@idLocal", SqlDbType.Int).Value = idLocal;

                    oConexion.Open();

                    using (SqlDataReader oReader = oComando.ExecuteReader())
                    {
                        if (oReader.Read())
                        {
                            Codigo = Convert.ToString(oReader["codSolicitud"]);
                        }
                    }
                }
            }

            return Codigo;
        }

        public SolicitudProveedorE SolicitudProvImpresion(Int32 idSolicitud)
        {
            SolicitudProveedorE solicitudproveedor = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_SolicitudProvImpresion", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idSolicitud", SqlDbType.Int).Value = idSolicitud;

                    oConexion.Open();

                    using (SqlDataReader oReader = oComando.ExecuteReader())
                    {
                        while (oReader.Read())
                        {
                            solicitudproveedor = LlenarEntidad(oReader);
                        }
                    }
                }
            }

            return solicitudproveedor;
        }

        public int ActualizarEstadoSolProveedor(Int32 idSolicitud, String indEstado, String UsuarioModificacion)
        {
            Int32 resp = 0;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ActualizarEstadoSolProveedor", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idSolicitud", SqlDbType.Int).Value = idSolicitud;
                    oComando.Parameters.Add("@indEstado", SqlDbType.Char, 1).Value = indEstado;
                    oComando.Parameters.Add("@UsuarioModificacion", SqlDbType.VarChar, 20).Value = UsuarioModificacion;

                    oConexion.Open();
                    resp = oComando.ExecuteNonQuery();
                }
            }

            return resp;
        }

        public Int32 ActualizarSaldoSolProveedor(Int32 idSolicitud, Decimal Saldo)
        {
            Int32 resp = 0;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ActualizarSaldoSolProveedor", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idSolicitud", SqlDbType.Int).Value = idSolicitud;
                    oComando.Parameters.Add("@Saldo", SqlDbType.Decimal).Value = Saldo;

                    oConexion.Open();
                    resp = oComando.ExecuteNonQuery();
                }
            }

            return resp;
        }

        public List<SolicitudProveedorE> SolicitudProveedorPendientes(Int32 idEmpresa, Int32 idLocal, String RazonSocial)
        {
            List<SolicitudProveedorE> listaEntidad = new List<SolicitudProveedorE>();

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_SolicitudProveedorPendientes", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@idLocal", SqlDbType.Int).Value = idLocal;
                    oComando.Parameters.Add("@RazonSocial", SqlDbType.VarChar, 50).Value = RazonSocial;

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