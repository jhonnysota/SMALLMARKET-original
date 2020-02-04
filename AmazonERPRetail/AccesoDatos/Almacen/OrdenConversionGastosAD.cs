using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

using Entidades.Almacen;
using AccesoDatos.Util;

namespace AccesoDatos.Almacen
{
    public class OrdenConversionGastosAD : DbConection
    {

        public OrdenConversionGastosE LlenarEntidad(IDataReader oReader)
        {
            OrdenConversionGastosE ordenconversiongastos = new OrdenConversionGastosE();
            
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idEmpresa'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				ordenconversiongastos.idEmpresa = oReader["idEmpresa"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idEmpresa"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idOrdenConversion'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				ordenconversiongastos.idOrdenConversion = oReader["idOrdenConversion"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idOrdenConversion"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='item'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				ordenconversiongastos.item = oReader["item"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["item"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Descripcion'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				ordenconversiongastos.Descripcion = oReader["Descripcion"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["Descripcion"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idPersona'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				ordenconversiongastos.idPersona = oReader["idPersona"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idPersona"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Fecha'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				ordenconversiongastos.Fecha = oReader["Fecha"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["Fecha"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idDocumento'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				ordenconversiongastos.idDocumento = oReader["idDocumento"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["idDocumento"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='serDocumento'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				ordenconversiongastos.serDocumento = oReader["serDocumento"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["serDocumento"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='numDocumento'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				ordenconversiongastos.numDocumento = oReader["numDocumento"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["numDocumento"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='TipoCambio'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				ordenconversiongastos.TipoCambio = oReader["TipoCambio"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["TipoCambio"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idMoneda'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				ordenconversiongastos.idMoneda = oReader["idMoneda"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["idMoneda"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Monto'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				ordenconversiongastos.Monto = oReader["Monto"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["Monto"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='MontoDolares'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				ordenconversiongastos.MontoDolares = oReader["MontoDolares"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["MontoDolares"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='DistribuirItem'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				ordenconversiongastos.DistribuirItem = oReader["DistribuirItem"] == DBNull.Value ? false : Convert.ToBoolean(oReader["DistribuirItem"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='ItemADistribuir'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				ordenconversiongastos.ItemADistribuir = oReader["ItemADistribuir"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["ItemADistribuir"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='UsuarioRegistro'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				ordenconversiongastos.UsuarioRegistro = oReader["UsuarioRegistro"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["UsuarioRegistro"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='FechaRegistro'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				ordenconversiongastos.FechaRegistro = oReader["FechaRegistro"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["FechaRegistro"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='UsuarioModificacion'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				ordenconversiongastos.UsuarioModificacion = oReader["UsuarioModificacion"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["UsuarioModificacion"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='FechaModificacion'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				ordenconversiongastos.FechaModificacion = oReader["FechaModificacion"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["FechaModificacion"]);

            //Extensiones
            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='DesMoneda'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                ordenconversiongastos.DesMoneda = oReader["DesMoneda"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["DesMoneda"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='desDocumento'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                ordenconversiongastos.desDocumento = oReader["desDocumento"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["desDocumento"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='RazonSocial'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                ordenconversiongastos.RazonSocial = oReader["RazonSocial"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["RazonSocial"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Ruc'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                ordenconversiongastos.Ruc = oReader["Ruc"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["Ruc"]);

            return  ordenconversiongastos;        
        }

        public OrdenConversionGastosE InsertarOrdenConversionGastos(OrdenConversionGastosE ordenconversiongastos)
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_InsertarOrdenConversionGastos", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = ordenconversiongastos.idEmpresa;
					oComando.Parameters.Add("@idOrdenConversion", SqlDbType.Int).Value = ordenconversiongastos.idOrdenConversion;
					oComando.Parameters.Add("@Descripcion", SqlDbType.VarChar, 150).Value = ordenconversiongastos.Descripcion;
					oComando.Parameters.Add("@idPersona", SqlDbType.Int).Value = ordenconversiongastos.idPersona;
					oComando.Parameters.Add("@Fecha", SqlDbType.SmallDateTime).Value = ordenconversiongastos.Fecha;
					oComando.Parameters.Add("@idDocumento", SqlDbType.VarChar, 2).Value = ordenconversiongastos.idDocumento;
					oComando.Parameters.Add("@serDocumento", SqlDbType.VarChar, 20).Value = ordenconversiongastos.serDocumento;
					oComando.Parameters.Add("@numDocumento", SqlDbType.VarChar, 20).Value = ordenconversiongastos.numDocumento;
					oComando.Parameters.Add("@TipoCambio", SqlDbType.Decimal).Value = ordenconversiongastos.TipoCambio;
					oComando.Parameters.Add("@idMoneda", SqlDbType.VarChar, 2).Value = ordenconversiongastos.idMoneda;
					oComando.Parameters.Add("@Monto", SqlDbType.Decimal).Value = ordenconversiongastos.Monto;
					oComando.Parameters.Add("@MontoDolares", SqlDbType.Decimal).Value = ordenconversiongastos.MontoDolares;
					oComando.Parameters.Add("@DistribuirItem", SqlDbType.Bit).Value = ordenconversiongastos.DistribuirItem;
					oComando.Parameters.Add("@ItemADistribuir", SqlDbType.VarChar, 100).Value = ordenconversiongastos.ItemADistribuir;
					oComando.Parameters.Add("@UsuarioRegistro", SqlDbType.VarChar, 20).Value = ordenconversiongastos.UsuarioRegistro;

                    oConexion.Open();
                    ordenconversiongastos.item = Int32.Parse(oComando.ExecuteScalar().ToString());
                }
            }

            return ordenconversiongastos;
        }
        
        public OrdenConversionGastosE ActualizarOrdenConversionGastos(OrdenConversionGastosE ordenconversiongastos)
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ActualizarOrdenConversionGastos", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = ordenconversiongastos.idEmpresa;
					oComando.Parameters.Add("@idOrdenConversion", SqlDbType.Int).Value = ordenconversiongastos.idOrdenConversion;
					oComando.Parameters.Add("@item", SqlDbType.Int).Value = ordenconversiongastos.item;
					oComando.Parameters.Add("@Descripcion", SqlDbType.VarChar, 150).Value = ordenconversiongastos.Descripcion;
					oComando.Parameters.Add("@idPersona", SqlDbType.Int).Value = ordenconversiongastos.idPersona;
					oComando.Parameters.Add("@Fecha", SqlDbType.SmallDateTime).Value = ordenconversiongastos.Fecha;
					oComando.Parameters.Add("@idDocumento", SqlDbType.VarChar, 2).Value = ordenconversiongastos.idDocumento;
					oComando.Parameters.Add("@serDocumento", SqlDbType.VarChar, 20).Value = ordenconversiongastos.serDocumento;
					oComando.Parameters.Add("@numDocumento", SqlDbType.VarChar, 20).Value = ordenconversiongastos.numDocumento;
					oComando.Parameters.Add("@TipoCambio", SqlDbType.Decimal).Value = ordenconversiongastos.TipoCambio;
					oComando.Parameters.Add("@idMoneda", SqlDbType.VarChar, 2).Value = ordenconversiongastos.idMoneda;
					oComando.Parameters.Add("@Monto", SqlDbType.Decimal).Value = ordenconversiongastos.Monto;
					oComando.Parameters.Add("@MontoDolares", SqlDbType.Decimal).Value = ordenconversiongastos.MontoDolares;
					oComando.Parameters.Add("@DistribuirItem", SqlDbType.Bit).Value = ordenconversiongastos.DistribuirItem;
					oComando.Parameters.Add("@ItemADistribuir", SqlDbType.VarChar, 100).Value = ordenconversiongastos.ItemADistribuir;
					oComando.Parameters.Add("@UsuarioModificacion", SqlDbType.VarChar, 20).Value = ordenconversiongastos.UsuarioModificacion;

                    oConexion.Open();
                    oComando.ExecuteNonQuery();
                }
            }

            return ordenconversiongastos;
        }        

        public int EliminarOrdenConversionGastos(Int32 idEmpresa, Int32 idOrdenConversion, Int32 item)
        {
            int resp = 0;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_EliminarOrdenConversionGastos", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
					oComando.Parameters.Add("@idOrdenConversion", SqlDbType.Int).Value = idOrdenConversion;
					oComando.Parameters.Add("@item", SqlDbType.Int).Value = item;

                    oConexion.Open();
                    resp = oComando.ExecuteNonQuery();
                }
            }

            return resp;
        }

        public List<OrdenConversionGastosE> ListarOrdenConversionGastos(Int32 idOrdenConversion)
        {
            List<OrdenConversionGastosE> listaEntidad = new List<OrdenConversionGastosE>();

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ListarOrdenConversionGastos", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idOrdenConversion", SqlDbType.Int).Value = idOrdenConversion;

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
        
        public OrdenConversionGastosE ObtenerOrdenConversionGastos(Int32 idEmpresa, Int32 idOrdenConversion, Int32 item)
        {        
            OrdenConversionGastosE ordenconversiongastos = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ObtenerOrdenConversionGastos", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
					oComando.Parameters.Add("@idOrdenConversion", SqlDbType.Int).Value = idOrdenConversion;
					oComando.Parameters.Add("@item", SqlDbType.Int).Value = item;

                    oConexion.Open();
                    
                    using (SqlDataReader oReader = oComando.ExecuteReader())
                    {
                        while (oReader.Read())
                        {
                            ordenconversiongastos = LlenarEntidad(oReader);
                        }
                    }
                }
            }

            return ordenconversiongastos;
        }

        public List<OrdenConversionGastosE> ListarGastosConversion(Int32 idEmpresa, Int32 idOrdenConversion)
        {
            List<OrdenConversionGastosE> listaEntidad = new List<OrdenConversionGastosE>();

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ListarGastosConversion", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@idOrdenConversion", SqlDbType.Int).Value = idOrdenConversion;

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