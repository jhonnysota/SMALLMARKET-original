using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

using Entidades.Almacen;
using AccesoDatos.Util;

namespace AccesoDatos.Almacen
{
    public class OperacionAD : DbConection
    {

        public OperacionE LlenarEntidad(IDataReader oReader)
        {
            OperacionE operacion = new OperacionE();
            
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idEmpresa'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				operacion.idEmpresa = oReader["idEmpresa"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idEmpresa"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idOperacion'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				operacion.idOperacion = oReader["idOperacion"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idOperacion"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='tipAlmacen'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				operacion.tipAlmacen = oReader["tipAlmacen"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["tipAlmacen"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='desAlmacen'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                operacion.desAlmacen = oReader["desAlmacen"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["desAlmacen"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='tipMovimiento'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                operacion.tipMovimiento = oReader["tipMovimiento"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["tipMovimiento"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='desOperacion'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				operacion.desOperacion = oReader["desOperacion"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["desOperacion"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='desDetalle'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				operacion.desDetalle = oReader["desDetalle"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["desDetalle"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='indValorizar'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				operacion.indValorizar = oReader["indValorizar"] == DBNull.Value ? false : Convert.ToBoolean(oReader["indValorizar"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='indServicio'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				operacion.indServicio = oReader["indServicio"] == DBNull.Value ? false : Convert.ToBoolean(oReader["indServicio"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='automatico'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				operacion.automatico = oReader["automatico"] == DBNull.Value ? false : Convert.ToBoolean(oReader["automatico"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='codSunat'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				operacion.codSunat = oReader["codSunat"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["codSunat"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='indOrdentrabajo'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				operacion.indOrdentrabajo = oReader["indOrdentrabajo"] == DBNull.Value ? false : Convert.ToBoolean(oReader["indOrdentrabajo"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='indTransferencia'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				operacion.indTransferencia = oReader["indTransferencia"] == DBNull.Value ? false : Convert.ToBoolean(oReader["indTransferencia"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='indConsumo'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				operacion.indConsumo = oReader["indConsumo"] == DBNull.Value ? false : Convert.ToBoolean(oReader["indConsumo"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='indDocumentoAutomatico'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				operacion.indDocumentoAutomatico = oReader["indDocumentoAutomatico"] == DBNull.Value ? false : Convert.ToBoolean(oReader["indDocumentoAutomatico"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='indProveedor'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				operacion.indProveedor = oReader["indProveedor"] == DBNull.Value ? false : Convert.ToBoolean(oReader["indProveedor"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='indCliente'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				operacion.indCliente = oReader["indCliente"] == DBNull.Value ? false : Convert.ToBoolean(oReader["indCliente"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='indEstadistico'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				operacion.indEstadistico = oReader["indEstadistico"] == DBNull.Value ? false : Convert.ToBoolean(oReader["indEstadistico"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='indOrdenCompra'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				operacion.indOrdenCompra = oReader["indOrdenCompra"] == DBNull.Value ? false : Convert.ToBoolean(oReader["indOrdenCompra"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='indConversion'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                operacion.indConversion = oReader["indConversion"] == DBNull.Value ? false : Convert.ToBoolean(oReader["indConversion"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='indDocumento'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                operacion.indDocumento = oReader["indDocumento"] == DBNull.Value ? false : Convert.ToBoolean(oReader["indDocumento"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='indReferencia'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                operacion.indReferencia = oReader["indReferencia"] == DBNull.Value ? false : Convert.ToBoolean(oReader["indReferencia"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='indDevolucion'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                operacion.indDevolucion = oReader["indDevolucion"] == DBNull.Value ? false : Convert.ToBoolean(oReader["indDevolucion"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='indCostoVenta'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                operacion.indCostoVenta = oReader["indCostoVenta"] == DBNull.Value ? false : Convert.ToBoolean(oReader["indCostoVenta"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='orden'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				operacion.orden = oReader["orden"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["orden"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='desMovimiento'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                operacion.desMovimiento = oReader["desMovimiento"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["desMovimiento"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='UsuarioRegistro'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                operacion.UsuarioRegistro = oReader["UsuarioRegistro"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["UsuarioRegistro"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='FechaRegistro'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                operacion.FechaRegistro = oReader["FechaRegistro"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["FechaRegistro"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='UsuarioModificacion'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                operacion.UsuarioModificacion = oReader["UsuarioModificacion"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["UsuarioModificacion"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='FechaModificacion'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                operacion.FechaModificacion = oReader["FechaModificacion"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["FechaModificacion"]);

            //Extensiones
            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='TipoAlmacen'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                operacion.TipoAlmacen = oReader["TipoAlmacen"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["TipoAlmacen"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='nomSunat'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                operacion.nomSunat = oReader["nomSunat"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["nomSunat"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='ContaReg'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                operacion.ContaReg = oReader["ContaReg"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["ContaReg"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='NombreEmpresa'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                operacion.NombreEmpresa = oReader["NombreEmpresa"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["NombreEmpresa"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='desTipMovimiento'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                operacion.desTipMovimiento = oReader["desTipMovimiento"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["desTipMovimiento"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='desTipAlmacen'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                operacion.desTipAlmacen = oReader["desTipAlmacen"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["desTipAlmacen"]);

            return  operacion;        
        }

        public OperacionE InsertarOperacion(OperacionE operacion)
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_InsertarOperacion", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = operacion.idEmpresa;
					oComando.Parameters.Add("@tipAlmacen", SqlDbType.Int).Value = operacion.tipAlmacen;
                    oComando.Parameters.Add("@tipMovimiento", SqlDbType.Int).Value = operacion.tipMovimiento;
					oComando.Parameters.Add("@desOperacion", SqlDbType.VarChar, 50).Value = operacion.desOperacion;
					oComando.Parameters.Add("@desDetalle", SqlDbType.VarChar, 25).Value = operacion.desDetalle;
					oComando.Parameters.Add("@indValorizar", SqlDbType.Bit).Value = operacion.indValorizar;
					oComando.Parameters.Add("@indServicio", SqlDbType.Bit).Value = operacion.indServicio;
					oComando.Parameters.Add("@automatico", SqlDbType.Bit).Value = operacion.automatico;
					oComando.Parameters.Add("@codSunat", SqlDbType.VarChar, 2).Value = operacion.codSunat;
					oComando.Parameters.Add("@indOrdentrabajo", SqlDbType.Bit).Value = operacion.indOrdentrabajo;
					oComando.Parameters.Add("@indTransferencia", SqlDbType.Bit).Value = operacion.indTransferencia;
					oComando.Parameters.Add("@indConsumo", SqlDbType.Bit).Value = operacion.indConsumo;
					oComando.Parameters.Add("@indDocumentoAutomatico", SqlDbType.Bit).Value = operacion.indDocumentoAutomatico;
					oComando.Parameters.Add("@indProveedor", SqlDbType.Bit).Value = operacion.indProveedor;
					oComando.Parameters.Add("@indCliente", SqlDbType.Bit).Value = operacion.indCliente;
					oComando.Parameters.Add("@indEstadistico", SqlDbType.Bit).Value = operacion.indEstadistico;
					oComando.Parameters.Add("@indOrdenCompra", SqlDbType.Bit).Value = operacion.indOrdenCompra;
                    oComando.Parameters.Add("@indConversion", SqlDbType.Bit).Value = operacion.indConversion;
                    oComando.Parameters.Add("@indDevolucion", SqlDbType.Bit).Value = operacion.indDevolucion;
                    oComando.Parameters.Add("@indDocumento", SqlDbType.Bit).Value = operacion.indDocumento;
                    oComando.Parameters.Add("@indReferencia", SqlDbType.Bit).Value = operacion.indReferencia;
                    oComando.Parameters.Add("@indCostoVenta", SqlDbType.Bit).Value = operacion.indCostoVenta;
                    oComando.Parameters.Add("@orden", SqlDbType.VarChar, 2).Value = operacion.orden;
                    oComando.Parameters.Add("@UsuarioRegistro", SqlDbType.VarChar, 20).Value = operacion.UsuarioRegistro;

                    oConexion.Open();
                    operacion.idOperacion = Convert.ToInt32(oComando.ExecuteScalar());
                }
            }

            return operacion;
        }
        
        public OperacionE ActualizarOperacion(OperacionE operacion)
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ActualizarOperacion", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = operacion.idEmpresa;
					oComando.Parameters.Add("@idOperacion", SqlDbType.Int).Value = operacion.idOperacion;
                    oComando.Parameters.Add("@tipAlmacen", SqlDbType.Int).Value = operacion.tipAlmacen;
                    oComando.Parameters.Add("@tipMovimiento", SqlDbType.Int).Value = operacion.tipMovimiento;
					oComando.Parameters.Add("@desOperacion", SqlDbType.VarChar, 50).Value = operacion.desOperacion;
					oComando.Parameters.Add("@desDetalle", SqlDbType.VarChar, 25).Value = operacion.desDetalle;
					oComando.Parameters.Add("@indValorizar", SqlDbType.Bit).Value = operacion.indValorizar;
					oComando.Parameters.Add("@indServicio", SqlDbType.Bit).Value = operacion.indServicio;
					oComando.Parameters.Add("@automatico", SqlDbType.Bit).Value = operacion.automatico;
					oComando.Parameters.Add("@codSunat", SqlDbType.VarChar, 2).Value = operacion.codSunat;
					oComando.Parameters.Add("@indOrdentrabajo", SqlDbType.Bit).Value = operacion.indOrdentrabajo;
					oComando.Parameters.Add("@indTransferencia", SqlDbType.Bit).Value = operacion.indTransferencia;
					oComando.Parameters.Add("@indConsumo", SqlDbType.Bit).Value = operacion.indConsumo;
					oComando.Parameters.Add("@indDocumentoAutomatico", SqlDbType.Bit).Value = operacion.indDocumentoAutomatico;
					oComando.Parameters.Add("@indProveedor", SqlDbType.Bit).Value = operacion.indProveedor;
					oComando.Parameters.Add("@indCliente", SqlDbType.Bit).Value = operacion.indCliente;
					oComando.Parameters.Add("@indEstadistico", SqlDbType.Bit).Value = operacion.indEstadistico;
					oComando.Parameters.Add("@indOrdenCompra", SqlDbType.Bit).Value = operacion.indOrdenCompra;
                    oComando.Parameters.Add("@indConversion", SqlDbType.Bit).Value = operacion.indConversion;
                    oComando.Parameters.Add("@indDevolucion", SqlDbType.Bit).Value = operacion.indDevolucion;
                    oComando.Parameters.Add("@indDocumento", SqlDbType.Bit).Value = operacion.indDocumento;
                    oComando.Parameters.Add("@indReferencia", SqlDbType.Bit).Value = operacion.indReferencia;
                    oComando.Parameters.Add("@indCostoVenta", SqlDbType.Bit).Value = operacion.indCostoVenta;
                    oComando.Parameters.Add("@orden", SqlDbType.VarChar, 2).Value = operacion.orden;
                    oComando.Parameters.Add("@UsuarioModificacion", SqlDbType.VarChar, 20).Value = operacion.UsuarioModificacion;

                    oConexion.Open();
                    oComando.ExecuteNonQuery();
                }
            }

            return operacion;
        }

        public int EliminarOperacion(Int32 idEmpresa, Int32 idOperacion, Int32 tipAlmacen, Int32 idTipoDocumento)
        {
            int resp = 0;
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_EliminarOperacion", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@idOperacion", SqlDbType.Int).Value = idOperacion;
                    oComando.Parameters.Add("@tipAlmacen", SqlDbType.Int).Value = tipAlmacen;
                    oComando.Parameters.Add("@tipMovimiento", SqlDbType.Int).Value = idTipoDocumento;

                    oConexion.Open();
                    resp = oComando.ExecuteNonQuery();
                }
            }

            return resp;
        }

        public List<OperacionE> ListarOperacion(Int32 idEmpresa)
        {
            List<OperacionE> listaEntidad = new List<OperacionE>();

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ListarOperacion", oConexion))
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

        public List<OperacionE> ListarEmpresaOperacion(Int32 idEmpresa, Int32 TipAlmacen)
        {
            List<OperacionE> listaEntidad = new List<OperacionE>();
            OperacionE entidad = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ListarEmpresaOperacion", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@TipAlmacen", SqlDbType.Int).Value = TipAlmacen;
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

        public List<OperacionE> ListarOperacionPorTipoArticulo(Int32 tipAlmacen, Int32 idEmpresa, Int32 tipMovimiento)
        {
            List<OperacionE> listaEntidad = new List<OperacionE>();
            OperacionE entidad = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ListarOperacionPorTipoArticulo", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@tipAlmacen", SqlDbType.Int).Value = tipAlmacen;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@tipMovimiento", SqlDbType.Int).Value = tipMovimiento;

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

        public List<OperacionE> ListarOperacionporTipoMovimiento(String pStr_filtro, Int32 idEmpresa, Int32 tipMovimiento)
        {
            List<OperacionE> listaEntidad = new List<OperacionE>();
            OperacionE entidad = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ListarOperacionporTipoMovimiento", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@pc_filtro", SqlDbType.VarChar).Value = pStr_filtro;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@tipMovimiento", SqlDbType.Int).Value = tipMovimiento;

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

        public OperacionE ObtenerOperacion(Int32 pi_idEmpresa, Int32 pi_idOperacion)
        {        
            OperacionE operacion = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ObtenerOperacion", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@pn_idEmpresa", SqlDbType.Int).Value = pi_idEmpresa;
                    oComando.Parameters.Add("@pn_idOperacion", SqlDbType.Int).Value = pi_idOperacion;
                    
                    oConexion.Open();
                    
                    using (SqlDataReader oReader = oComando.ExecuteReader())
                    {
                        while (oReader.Read())
                        {
                            operacion = LlenarEntidad(oReader);
                        }
                    }
                }
            }

            return operacion;
        }

    }
}