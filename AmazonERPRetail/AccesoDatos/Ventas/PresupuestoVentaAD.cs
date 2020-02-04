using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

using Entidades.Ventas;
using AccesoDatos.Util;

namespace AccesoDatos.Ventas
{
    public class PresupuestoVentaAD : DbConection
    {
        
        public PresupuestoVentaE LlenarEntidad(IDataReader oReader)
        {
            PresupuestoVentaE presupuestoventa = new PresupuestoVentaE();
            
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idEmpresa'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				presupuestoventa.idEmpresa = oReader["idEmpresa"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idEmpresa"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='AnioPresupuesto'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				presupuestoventa.AnioPresupuesto = oReader["AnioPresupuesto"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["AnioPresupuesto"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idVendedor'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				presupuestoventa.idVendedor = oReader["idVendedor"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idVendedor"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idTipoArticulo'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				presupuestoventa.idTipoArticulo = oReader["idTipoArticulo"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idTipoArticulo"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idMoneda'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				presupuestoventa.idMoneda = oReader["idMoneda"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["idMoneda"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='UsuarioRegistro'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				presupuestoventa.UsuarioRegistro = oReader["UsuarioRegistro"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["UsuarioRegistro"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='FechaRegistro'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				presupuestoventa.FechaRegistro = oReader["FechaRegistro"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["FechaRegistro"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='UsuarioModificacion'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				presupuestoventa.UsuarioModificacion = oReader["UsuarioModificacion"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["UsuarioModificacion"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='FechaModificacion'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				presupuestoventa.FechaModificacion = oReader["FechaModificacion"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["FechaModificacion"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Vendedor'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                presupuestoventa.Vendedor = oReader["Vendedor"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["Vendedor"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='DesTipoArticulo'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                presupuestoventa.DesTipoArticulo = oReader["DesTipoArticulo"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["DesTipoArticulo"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='DesMoneda'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                presupuestoventa.DesMoneda = oReader["DesMoneda"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["DesMoneda"]);


            return  presupuestoventa;        
        }

        public PresupuestoVentaE InsertarPresupuestoVenta(PresupuestoVentaE presupuestoventa)
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_InsertarPresupuestoVenta", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;

                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = presupuestoventa.idEmpresa;
					oComando.Parameters.Add("@AnioPresupuesto", SqlDbType.VarChar, 4).Value = presupuestoventa.AnioPresupuesto;
					oComando.Parameters.Add("@idVendedor", SqlDbType.Int).Value = presupuestoventa.idVendedor;
					oComando.Parameters.Add("@idTipoArticulo", SqlDbType.Int).Value = presupuestoventa.idTipoArticulo;
					oComando.Parameters.Add("@idMoneda", SqlDbType.VarChar, 2).Value = presupuestoventa.idMoneda;
					oComando.Parameters.Add("@UsuarioRegistro", SqlDbType.VarChar, 20).Value = presupuestoventa.UsuarioRegistro;

                    oConexion.Open();
                    oComando.ExecuteNonQuery();
                    oConexion.Close();
                }
            }

            return presupuestoventa;
        }
        
        public PresupuestoVentaE ActualizarPresupuestoVenta(PresupuestoVentaE presupuestoventa)
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ActualizarPresupuestoVenta", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;

                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = presupuestoventa.idEmpresa;
					oComando.Parameters.Add("@AnioPresupuesto", SqlDbType.VarChar, 4).Value = presupuestoventa.AnioPresupuesto;
					oComando.Parameters.Add("@idVendedor", SqlDbType.Int).Value = presupuestoventa.idVendedor;
					oComando.Parameters.Add("@idTipoArticulo", SqlDbType.Int).Value = presupuestoventa.idTipoArticulo;
					oComando.Parameters.Add("@idMoneda", SqlDbType.VarChar, 2).Value = presupuestoventa.idMoneda;
					oComando.Parameters.Add("@UsuarioModificacion", SqlDbType.VarChar, 20).Value = presupuestoventa.UsuarioModificacion;

                    oConexion.Open();
                    oComando.ExecuteNonQuery();
                    oConexion.Close();
                }
            }

            return presupuestoventa;
        }        

        public int EliminarPresupuestoVenta(Int32 idEmpresa, String AnioPresupuesto, Int32 idVendedor)
        {
            int resp = 0;
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_EliminarPresupuestoVenta", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;

                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
					oComando.Parameters.Add("@AnioPresupuesto", SqlDbType.VarChar, 4).Value = AnioPresupuesto;
					oComando.Parameters.Add("@idVendedor", SqlDbType.Int).Value = idVendedor;

                    oConexion.Open();
                    resp = oComando.ExecuteNonQuery();
                    oConexion.Close();
                }
            }

            return resp;
        }

        public List<PresupuestoVentaE> ListarPresupuestoVenta(Int32 idEmpresa, String AnioPresupuesto)
        {
           List<PresupuestoVentaE> listaEntidad = new List<PresupuestoVentaE>();
           PresupuestoVentaE entidad = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ListarPresupuestoVenta", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;

                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@AnioPresupuesto", SqlDbType.VarChar,4).Value = AnioPresupuesto;

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

                oConexion.Close();
            }

            return listaEntidad;
        }
        
        public PresupuestoVentaE ObtenerPresupuestoVenta(Int32 idEmpresa, String AnioPresupuesto, Int32 idVendedor)
        {        
            PresupuestoVentaE presupuestoventa = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ObtenerPresupuestoVenta", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;

                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
					oComando.Parameters.Add("@AnioPresupuesto", SqlDbType.VarChar, 4).Value = AnioPresupuesto;
					oComando.Parameters.Add("@idVendedor", SqlDbType.Int).Value = idVendedor;
                    oConexion.Open();
                    
                    using (SqlDataReader oReader = oComando.ExecuteReader())
                    {
                        while (oReader.Read())
                        {
                            presupuestoventa = LlenarEntidad(oReader);
                        }
                    }
                }

                oConexion.Close();
            }

            return presupuestoventa;
        }
    }
}