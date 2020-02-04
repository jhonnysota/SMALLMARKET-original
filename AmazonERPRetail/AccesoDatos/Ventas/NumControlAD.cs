using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

using Entidades.Ventas;
using AccesoDatos.Util;

namespace AccesoDatos.Ventas
{
    public class NumControlAD : DbConection
    {

        public NumControlE LlenarEntidad(IDataReader oReader)
        {
            NumControlE numcontrol = new NumControlE();
            
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idEmpresa'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				numcontrol.idEmpresa = oReader["idEmpresa"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idEmpresa"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idLocal'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				numcontrol.idLocal = oReader["idLocal"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idLocal"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idControl'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				numcontrol.idControl = oReader["idControl"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idControl"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Descripcion'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				numcontrol.Descripcion = oReader["Descripcion"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["Descripcion"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='swNotaCredito'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				numcontrol.swNotaCredito = oReader["swNotaCredito"] == DBNull.Value ? false : Convert.ToBoolean(oReader["swNotaCredito"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idTipCondicion'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				numcontrol.idTipCondicion = oReader["idTipCondicion"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idTipCondicion"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='regVenta'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				numcontrol.regVenta = oReader["regVenta"] == DBNull.Value ? false : Convert.ToBoolean(oReader["regVenta"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='indCodigoBarras'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				numcontrol.indCodigoBarras = oReader["indCodigoBarras"] == DBNull.Value ? false : Convert.ToBoolean(oReader["indCodigoBarras"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='indVisible'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				numcontrol.indVisible = oReader["indVisible"] == DBNull.Value ? false : Convert.ToBoolean(oReader["indVisible"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='UsuarioRegistro'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				numcontrol.UsuarioRegistro = oReader["UsuarioRegistro"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["UsuarioRegistro"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='FechaRegistro'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				numcontrol.FechaRegistro = oReader["FechaRegistro"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["FechaRegistro"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='UsuarioModificacion'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				numcontrol.UsuarioModificacion = oReader["UsuarioModificacion"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["UsuarioModificacion"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='FechaModificacion'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				numcontrol.FechaModificacion = oReader["FechaModificacion"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["FechaModificacion"]);

            return  numcontrol;        
        }

        public NumControlE InsertarNumControl(NumControlE numcontrol)
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_InsertarNumControl", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = numcontrol.idEmpresa;
					oComando.Parameters.Add("@idLocal", SqlDbType.Int).Value = numcontrol.idLocal;
                    oComando.Parameters.Add("@idControl", SqlDbType.Int).Value = numcontrol.idControl;
                    oComando.Parameters.Add("@Descripcion", SqlDbType.VarChar, 50).Value = numcontrol.Descripcion;
					oComando.Parameters.Add("@swNotaCredito", SqlDbType.Bit).Value = numcontrol.swNotaCredito;
					oComando.Parameters.Add("@idTipCondicion", SqlDbType.Int).Value = numcontrol.idTipCondicion;
					oComando.Parameters.Add("@regVenta", SqlDbType.Bit).Value = numcontrol.regVenta;
					oComando.Parameters.Add("@indCodigoBarras", SqlDbType.Bit).Value = numcontrol.indCodigoBarras;
					oComando.Parameters.Add("@indVisible", SqlDbType.Bit).Value = numcontrol.indVisible;
					oComando.Parameters.Add("@UsuarioRegistro", SqlDbType.VarChar, 20).Value = numcontrol.UsuarioRegistro;

                    oConexion.Open();
                    oComando.ExecuteNonQuery();
                }
            }

            return numcontrol;
        }
        
        public NumControlE ActualizarNumControl(NumControlE numcontrol)
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ActualizarNumControl", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = numcontrol.idEmpresa;
					oComando.Parameters.Add("@idLocal", SqlDbType.Int).Value = numcontrol.idLocal;
					oComando.Parameters.Add("@idControl", SqlDbType.Int).Value = numcontrol.idControl;
					oComando.Parameters.Add("@Descripcion", SqlDbType.VarChar, 50).Value = numcontrol.Descripcion;
					oComando.Parameters.Add("@swNotaCredito", SqlDbType.Bit).Value = numcontrol.swNotaCredito;
					oComando.Parameters.Add("@idTipCondicion", SqlDbType.Int).Value = numcontrol.idTipCondicion;
					oComando.Parameters.Add("@regVenta", SqlDbType.Bit).Value = numcontrol.regVenta;
					oComando.Parameters.Add("@indCodigoBarras", SqlDbType.Bit).Value = numcontrol.indCodigoBarras;
					oComando.Parameters.Add("@indVisible", SqlDbType.Bit).Value = numcontrol.indVisible;
					oComando.Parameters.Add("@UsuarioModificacion", SqlDbType.VarChar, 20).Value = numcontrol.UsuarioModificacion;

                    oConexion.Open();
                    oComando.ExecuteNonQuery();
                }
            }

            return numcontrol;
        }

        public List<NumControlE> ListarNumControl(Int32 idEmpresa, Int32 idLocal)
        {
           List<NumControlE> listaEntidad = new List<NumControlE>();
           NumControlE entidad = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ListarNumControl", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@idLocal", SqlDbType.Int).Value = idLocal;

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
        
        public NumControlE ObtenerNumControl(Int32 idEmpresa, Int32 idLocal, Int32 idControl)
        {        
            NumControlE numcontrol = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ObtenerNumControl", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
					oComando.Parameters.Add("@idLocal", SqlDbType.Int).Value = idLocal;
					oComando.Parameters.Add("@idControl", SqlDbType.Int).Value = idControl;

                    oConexion.Open();
                    
                    using (SqlDataReader oReader = oComando.ExecuteReader())
                    {
                        while (oReader.Read())
                        {
                            numcontrol = LlenarEntidad(oReader);
                        }
                    }
                }
            }

            return numcontrol;
        }

        public Int32 MaxNumControl(Int32 idEmpresa, Int32 idLocal)
        {
            int resp = 0;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_MaxNumControl", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@idLocal", SqlDbType.Int).Value = idLocal;

                    oConexion.Open();
                    resp = Convert.ToInt32(oComando.ExecuteScalar().ToString());
                }
            }

            return resp;
        }

    }
}