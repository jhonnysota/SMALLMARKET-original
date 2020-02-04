using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

using Entidades.Almacen;
using AccesoDatos.Util;

namespace AccesoDatos.Almacen
{
    public class GastosImportacionAD : DbConection
    {

        public GastosImportacionE LlenarEntidad(IDataReader oReader)
        {
            GastosImportacionE gastosimportacion = new GastosImportacionE();
            
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idEmpresa'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				gastosimportacion.idEmpresa = oReader["idEmpresa"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idEmpresa"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idLocal'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				gastosimportacion.idLocal = oReader["idLocal"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idLocal"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idHojaCosto'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				gastosimportacion.idHojaCosto = oReader["idHojaCosto"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idHojaCosto"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='item'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				gastosimportacion.item = oReader["item"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["item"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Descripcion'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				gastosimportacion.Descripcion = oReader["Descripcion"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["Descripcion"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idPersona'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                gastosimportacion.idPersona = oReader["idPersona"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idPersona"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Fecha'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				gastosimportacion.Fecha = oReader["Fecha"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["Fecha"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idDocumento'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                gastosimportacion.idDocumento = oReader["idDocumento"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["idDocumento"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='serDocumento'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                gastosimportacion.serDocumento = oReader["serDocumento"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["serDocumento"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='numDocumento'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                gastosimportacion.numDocumento = oReader["numDocumento"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["numDocumento"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idDocumento'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                gastosimportacion.idDocumento = oReader["idDocumento"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["idDocumento"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='TipoCambio'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				gastosimportacion.TipoCambio = oReader["TipoCambio"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["TipoCambio"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idMoneda'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				gastosimportacion.idMoneda = oReader["idMoneda"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["idMoneda"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Monto'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				gastosimportacion.Monto = oReader["Monto"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["Monto"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='MontoDolares'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				gastosimportacion.MontoDolares = oReader["MontoDolares"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["MontoDolares"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='MontoSoles'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                gastosimportacion.MontoSoles = oReader["MontoSoles"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["MontoSoles"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='DistribuirItem'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                gastosimportacion.DistribuirItem = oReader["DistribuirItem"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["DistribuirItem"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='ItemADistribuir'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                gastosimportacion.ItemADistribuir = oReader["ItemADistribuir"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["ItemADistribuir"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='UsuarioRegistro'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				gastosimportacion.UsuarioRegistro = oReader["UsuarioRegistro"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["UsuarioRegistro"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='FechaRegistro'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				gastosimportacion.FechaRegistro = oReader["FechaRegistro"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["FechaRegistro"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='UsuarioModificacion'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				gastosimportacion.UsuarioModificacion = oReader["UsuarioModificacion"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["UsuarioModificacion"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='FechaModificacion'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				gastosimportacion.FechaModificacion = oReader["FechaModificacion"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["FechaModificacion"]);

            //Extensiones
            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='DesMoneda'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                gastosimportacion.DesMoneda = oReader["DesMoneda"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["DesMoneda"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='desDocumento'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                gastosimportacion.desDocumento = oReader["desDocumento"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["desDocumento"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='RazonSocial'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                gastosimportacion.RazonSocial = oReader["RazonSocial"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["RazonSocial"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='RUC'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                gastosimportacion.Ruc = oReader["RUC"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["RUC"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='codArticulo'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                gastosimportacion.codArticulo = oReader["codArticulo"] == DBNull.Value ? "0" : Convert.ToString(oReader["codArticulo"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='codConcepto'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                gastosimportacion.codConcepto = oReader["codConcepto"] == DBNull.Value ? "0" : Convert.ToString(oReader["codConcepto"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='desArticulo'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                gastosimportacion.desArticulo = oReader["desArticulo"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["desArticulo"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Cantidad'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                gastosimportacion.Cantidad = oReader["Cantidad"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["Cantidad"]);

            return gastosimportacion;        
        }

        public GastosImportacionE InsertarGastosImportacion(GastosImportacionE gastosimportacion)
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_InsertarGastosImportacion", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = gastosimportacion.idEmpresa;
					oComando.Parameters.Add("@idLocal", SqlDbType.Int).Value = gastosimportacion.idLocal;
					oComando.Parameters.Add("@idHojaCosto", SqlDbType.Int).Value = gastosimportacion.idHojaCosto;
					oComando.Parameters.Add("@Descripcion", SqlDbType.VarChar, 150).Value = gastosimportacion.Descripcion;
                    oComando.Parameters.Add("@idPersona", SqlDbType.Int).Value = gastosimportacion.idPersona;
                    oComando.Parameters.Add("@Fecha", SqlDbType.SmallDateTime).Value = gastosimportacion.Fecha;
                    oComando.Parameters.Add("@idDocumento", SqlDbType.VarChar, 2).Value = gastosimportacion.idDocumento;
                    oComando.Parameters.Add("@serDocumento", SqlDbType.VarChar, 20).Value = gastosimportacion.serDocumento;
                    oComando.Parameters.Add("@numDocumento", SqlDbType.VarChar, 20).Value = gastosimportacion.numDocumento;
                    oComando.Parameters.Add("@TipoCambio", SqlDbType.Decimal).Value = gastosimportacion.TipoCambio;
					oComando.Parameters.Add("@idMoneda", SqlDbType.VarChar, 2).Value = gastosimportacion.idMoneda;
					oComando.Parameters.Add("@Monto", SqlDbType.Decimal).Value = gastosimportacion.Monto;
					oComando.Parameters.Add("@MontoDolares", SqlDbType.Decimal).Value = gastosimportacion.MontoDolares;
                    oComando.Parameters.Add("@ItemADistribuir", SqlDbType.VarChar, 100).Value = gastosimportacion.ItemADistribuir;
                    oComando.Parameters.Add("@DistribuirItem", SqlDbType.Int).Value = gastosimportacion.DistribuirItem;
                    oComando.Parameters.Add("@UsuarioRegistro", SqlDbType.VarChar, 20).Value = gastosimportacion.UsuarioRegistro;

                    oConexion.Open();
                    gastosimportacion.item = Int32.Parse(oComando.ExecuteScalar().ToString());
                }
            }

            return gastosimportacion;
        }
        
        public GastosImportacionE ActualizarGastosImportacion(GastosImportacionE gastosimportacion)
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ActualizarGastosImportacion", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = gastosimportacion.idEmpresa;
					oComando.Parameters.Add("@idLocal", SqlDbType.Int).Value = gastosimportacion.idLocal;
					oComando.Parameters.Add("@idHojaCosto", SqlDbType.Int).Value = gastosimportacion.idHojaCosto;
					oComando.Parameters.Add("@item", SqlDbType.Int).Value = gastosimportacion.item;
					oComando.Parameters.Add("@Descripcion", SqlDbType.VarChar, 150).Value = gastosimportacion.Descripcion;
                    oComando.Parameters.Add("@idPersona", SqlDbType.Int).Value = gastosimportacion.idPersona;
                    oComando.Parameters.Add("@Fecha", SqlDbType.SmallDateTime).Value = gastosimportacion.Fecha;
                    oComando.Parameters.Add("@idDocumento", SqlDbType.VarChar, 2).Value = gastosimportacion.idDocumento;
                    oComando.Parameters.Add("@serDocumento", SqlDbType.VarChar, 20).Value = gastosimportacion.serDocumento;
                    oComando.Parameters.Add("@numDocumento", SqlDbType.VarChar, 20).Value = gastosimportacion.numDocumento;
                    oComando.Parameters.Add("@TipoCambio", SqlDbType.Decimal).Value = gastosimportacion.TipoCambio;
					oComando.Parameters.Add("@idMoneda", SqlDbType.VarChar, 2).Value = gastosimportacion.idMoneda;
					oComando.Parameters.Add("@Monto", SqlDbType.Decimal).Value = gastosimportacion.Monto;
					oComando.Parameters.Add("@MontoDolares", SqlDbType.Decimal).Value = gastosimportacion.MontoDolares;
                    oComando.Parameters.Add("@ItemADistribuir", SqlDbType.VarChar, 100).Value = gastosimportacion.ItemADistribuir;
                    oComando.Parameters.Add("@DistribuirItem", SqlDbType.Int).Value = gastosimportacion.DistribuirItem;
                    oComando.Parameters.Add("@UsuarioModificacion", SqlDbType.VarChar, 20).Value = gastosimportacion.UsuarioModificacion;

                    oConexion.Open();
                    oComando.ExecuteNonQuery();
                }
            }

            return gastosimportacion;
        }        

        public int EliminarGastosImportacion(Int32 idEmpresa, Int32 idLocal, Int32 idHojaCosto, Int32 item)
        {
            int resp = 0;
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_EliminarGastosImportacion", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
					oComando.Parameters.Add("@idLocal", SqlDbType.Int).Value = idLocal;
					oComando.Parameters.Add("@idHojaCosto", SqlDbType.Int).Value = idHojaCosto;
					oComando.Parameters.Add("@item", SqlDbType.Int).Value = item;

                    oConexion.Open();
                    resp = oComando.ExecuteNonQuery();
                }
            }

            return resp;
        }

        public List<GastosImportacionE> ListarGastosImportacionPorHojaCosto(Int32 idEmpresa, Int32 idLocal, Int32 idHojaCosto)
        {
            List<GastosImportacionE> listaEntidad = new List<GastosImportacionE>();

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ListarGastosImportacionPorHojaCosto", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@idLocal", SqlDbType.Int).Value = idLocal;
                    oComando.Parameters.Add("@idHojaCosto", SqlDbType.Int).Value = idHojaCosto;

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

        public List<GastosImportacionE> ListarGastosImportacion(Int32 idEmpresa, Int32 idLocal, Int32 idHojaCosto)
        {
            List<GastosImportacionE> listaEntidad = new List<GastosImportacionE>();

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ListarGastosImportacion", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@idLocal", SqlDbType.Int).Value = idLocal;
                    oComando.Parameters.Add("@idHojaCosto", SqlDbType.Int).Value = idHojaCosto;

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
        
        public GastosImportacionE ObtenerGastosImportacion(Int32 idEmpresa, Int32 idLocal, Int32 idHojaCosto, Int32 item)
        {        
            GastosImportacionE gastosimportacion = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ObtenerGastosImportacion", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
					oComando.Parameters.Add("@idLocal", SqlDbType.Int).Value = idLocal;
					oComando.Parameters.Add("@idHojaCosto", SqlDbType.Int).Value = idHojaCosto;
					oComando.Parameters.Add("@item", SqlDbType.Int).Value = item;

                    oConexion.Open();
                    
                    using (SqlDataReader oReader = oComando.ExecuteReader())
                    {
                        while (oReader.Read())
                        {
                            gastosimportacion = LlenarEntidad(oReader);
                        }
                    }
                }
            }

            return gastosimportacion;
        }

    }
}