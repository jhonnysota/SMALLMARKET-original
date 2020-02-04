using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

using Entidades.Ventas;
using AccesoDatos.Util;

namespace AccesoDatos.Ventas
{
    public class PresupuestoVentaDetAD : DbConection
    {

        public PresupuestoVentaDetE LlenarEntidad(IDataReader oReader)
        {
            PresupuestoVentaDetE presupuestoventadet = new PresupuestoVentaDetE();
            
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idEmpresa'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				presupuestoventadet.idEmpresa = oReader["idEmpresa"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idEmpresa"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='AnioPresupuesto'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				presupuestoventadet.AnioPresupuesto = oReader["AnioPresupuesto"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["AnioPresupuesto"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idVendedor'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				presupuestoventadet.idVendedor = oReader["idVendedor"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idVendedor"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idEstablecimiento'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				presupuestoventadet.idEstablecimiento = oReader["idEstablecimiento"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idEstablecimiento"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idArticulo'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                presupuestoventadet.idArticulo = oReader["idArticulo"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idArticulo"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idTipoArticulo'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                presupuestoventadet.idTipoArticulo = oReader["idTipoArticulo"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idTipoArticulo"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Mes'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				presupuestoventadet.Mes = oReader["Mes"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["Mes"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='NombreMes'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                presupuestoventadet.NombreMes = oReader["NombreMes"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["NombreMes"]);          

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Cantidad'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				presupuestoventadet.Cantidad = oReader["Cantidad"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["Cantidad"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='PrecioUnit'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				presupuestoventadet.PrecioUnit = oReader["PrecioUnit"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["PrecioUnit"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Total'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				presupuestoventadet.Total = oReader["Total"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["Total"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='UsuarioRegistro'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				presupuestoventadet.UsuarioRegistro = oReader["UsuarioRegistro"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["UsuarioRegistro"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='FechaRegistro'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				presupuestoventadet.FechaRegistro = oReader["FechaRegistro"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["FechaRegistro"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='UsuarioModificacion'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				presupuestoventadet.UsuarioModificacion = oReader["UsuarioModificacion"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["UsuarioModificacion"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='FechaModificacion'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				presupuestoventadet.FechaModificacion = oReader["FechaModificacion"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["FechaModificacion"]);

            //Extensiones
            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Vendedor'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                presupuestoventadet.Vendedor = oReader["Vendedor"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["Vendedor"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='DesTipoArticulo'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                presupuestoventadet.DesTipoArticulo = oReader["DesTipoArticulo"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["DesTipoArticulo"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='DesEstablecimiento'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                presupuestoventadet.DesEstablecimiento = oReader["DesEstablecimiento"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["DesEstablecimiento"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='codArticulo'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                presupuestoventadet.codArticulo = oReader["codArticulo"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["codArticulo"]);

            return  presupuestoventadet;        
        }

        public PresupuestoVentaDetE InsertarPresupuestoVentaDet(PresupuestoVentaDetE presupuestoventadet)
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_InsertarPresupuestoVentaDet", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = presupuestoventadet.idEmpresa;
					oComando.Parameters.Add("@AnioPresupuesto", SqlDbType.VarChar, 4).Value = presupuestoventadet.AnioPresupuesto;
					oComando.Parameters.Add("@idVendedor", SqlDbType.Int).Value = presupuestoventadet.idVendedor;
					oComando.Parameters.Add("@idEstablecimiento", SqlDbType.Int).Value = presupuestoventadet.idEstablecimiento;
					oComando.Parameters.Add("@idArticulo", SqlDbType.Int).Value = presupuestoventadet.idArticulo;
                    oComando.Parameters.Add("@idTipoArticulo", SqlDbType.Int).Value = presupuestoventadet.idTipoArticulo;
                    oComando.Parameters.Add("@Mes", SqlDbType.VarChar, 2).Value = presupuestoventadet.Mes;
                    oComando.Parameters.Add("@NombreMes", SqlDbType.VarChar, 20).Value = presupuestoventadet.NombreMes;
                    oComando.Parameters.Add("@Cantidad", SqlDbType.Decimal).Value = presupuestoventadet.Cantidad;
					oComando.Parameters.Add("@PrecioUnit", SqlDbType.Decimal).Value = presupuestoventadet.PrecioUnit;
					oComando.Parameters.Add("@Total", SqlDbType.Decimal).Value = presupuestoventadet.Total;
					oComando.Parameters.Add("@UsuarioRegistro", SqlDbType.VarChar, 20).Value = presupuestoventadet.UsuarioRegistro;

                    oConexion.Open();
                    oComando.ExecuteNonQuery();
                }
            }

            return presupuestoventadet;
        }
        
        public PresupuestoVentaDetE ActualizarPresupuestoVentaDet(PresupuestoVentaDetE presupuestoventadet)
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ActualizarPresupuestoVentaDet", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = presupuestoventadet.idEmpresa;
					oComando.Parameters.Add("@AnioPresupuesto", SqlDbType.VarChar, 4).Value = presupuestoventadet.AnioPresupuesto;
					oComando.Parameters.Add("@idVendedor", SqlDbType.Int).Value = presupuestoventadet.idVendedor;
					oComando.Parameters.Add("@idEstablecimiento", SqlDbType.Int).Value = presupuestoventadet.idEstablecimiento;
					oComando.Parameters.Add("@idArticulo", SqlDbType.Int).Value = presupuestoventadet.idArticulo;
                    oComando.Parameters.Add("@idTipoArticulo", SqlDbType.Int).Value = presupuestoventadet.idTipoArticulo;
                    oComando.Parameters.Add("@Mes", SqlDbType.VarChar, 2).Value = presupuestoventadet.Mes;
                    oComando.Parameters.Add("@NombreMes", SqlDbType.VarChar, 20).Value = presupuestoventadet.NombreMes;
                    oComando.Parameters.Add("@Cantidad", SqlDbType.Decimal).Value = presupuestoventadet.Cantidad;
					oComando.Parameters.Add("@PrecioUnit", SqlDbType.Decimal).Value = presupuestoventadet.PrecioUnit;
					oComando.Parameters.Add("@Total", SqlDbType.Decimal).Value = presupuestoventadet.Total;
					oComando.Parameters.Add("@UsuarioModificacion", SqlDbType.VarChar, 20).Value = presupuestoventadet.UsuarioModificacion;

                    oConexion.Open();
                    oComando.ExecuteNonQuery();
                }
            }

            return presupuestoventadet;
        }        

        public int EliminarPresupuestoVentaDet(Int32 idEmpresa, String AnioPresupuesto, Int32 idVendedor, Int32 idEstablecimiento, Int32 idArticulo, String Mes)
        {
            int resp = 0;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_EliminarPresupuestoVentaDet", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
					oComando.Parameters.Add("@AnioPresupuesto", SqlDbType.VarChar, 4).Value = AnioPresupuesto;
					oComando.Parameters.Add("@idVendedor", SqlDbType.Int).Value = idVendedor;
					oComando.Parameters.Add("@idEstablecimiento", SqlDbType.Int).Value = idEstablecimiento;
					oComando.Parameters.Add("@idArticulo", SqlDbType.Int).Value = idArticulo;
					oComando.Parameters.Add("@Mes", SqlDbType.VarChar, 2).Value = Mes;

                    oConexion.Open();
                    resp = oComando.ExecuteNonQuery();
                }
            }

            return resp;
        }

        public List<PresupuestoVentaDetE> ListarPresupuestoVentaDet(Int32 idEmpresa, String AnioPresupuesto, Int32 idVendedor)
        {
            List<PresupuestoVentaDetE> listaEntidad = new List<PresupuestoVentaDetE>();

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ListarPresupuestoVentaDet", oConexion))
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
                            listaEntidad.Add(LlenarEntidad(oReader));
                        }
                    }
                }
            }

            return listaEntidad;
        }
        
        public PresupuestoVentaDetE ObtenerPresupuestoVentaDet(Int32 idEmpresa, String AnioPresupuesto, Int32 idVendedor, Int32 idEstablecimiento, Int32 idArticulo, String Mes)
        {        
            PresupuestoVentaDetE presupuestoventadet = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ObtenerPresupuestoVentaDet", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
					oComando.Parameters.Add("@AnioPresupuesto", SqlDbType.VarChar, 4).Value = AnioPresupuesto;
					oComando.Parameters.Add("@idVendedor", SqlDbType.Int).Value = idVendedor;
					oComando.Parameters.Add("@idEstablecimiento", SqlDbType.Int).Value = idEstablecimiento;
					oComando.Parameters.Add("@idArticulo", SqlDbType.Int).Value = idArticulo;
					oComando.Parameters.Add("@Mes", SqlDbType.VarChar, 2).Value = Mes;

                    oConexion.Open();
                    
                    using (SqlDataReader oReader = oComando.ExecuteReader())
                    {
                        while (oReader.Read())
                        {
                            presupuestoventadet = LlenarEntidad(oReader);
                        }
                    }
                }
            }

            return presupuestoventadet;
        }

    }
}