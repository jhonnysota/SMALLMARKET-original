using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

using Entidades.Ventas;
using AccesoDatos.Util;

namespace AccesoDatos.Ventas
{
    public class ComisionesConfiguracionAD : DbConection
    {
        
        public ComisionesConfiguracionE LlenarEntidad(IDataReader oReader)
        {
            ComisionesConfiguracionE comisionesconfiguracion = new ComisionesConfiguracionE();
            
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idEmpresa'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				comisionesconfiguracion.idEmpresa = oReader["idEmpresa"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idEmpresa"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idComision'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				comisionesconfiguracion.idComision = oReader["idComision"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idComision"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idPeriodo'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                comisionesconfiguracion.idPeriodo = oReader["idPeriodo"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idPeriodo"]);

			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='NombreZona'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				comisionesconfiguracion.NombreZona = oReader["NombreZona"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["NombreZona"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Estado'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				comisionesconfiguracion.Estado = oReader["Estado"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["Estado"]);





            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idComisionCategoria'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                comisionesconfiguracion.idComisionCategoria = oReader["idComisionCategoria"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idComisionCategoria"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idCategoria'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                comisionesconfiguracion.idCategoria = oReader["idCategoria"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idCategoria"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idComisionTarifario'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                comisionesconfiguracion.idComisionTarifario = oReader["idComisionTarifario"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idComisionTarifario"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idComisionCriterio'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                comisionesconfiguracion.idComisionCriterio = oReader["idComisionCriterio"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idComisionCriterio"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idParTabla'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                comisionesconfiguracion.idParTabla = oReader["idParTabla"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idParTabla"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idComisionVendedor'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                comisionesconfiguracion.idComisionVendedor = oReader["idComisionVendedor"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idComisionVendedor"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idVendedor'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                comisionesconfiguracion.idVendedor = oReader["idVendedor"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idVendedor"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idComisionLinea'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                comisionesconfiguracion.idComisionLinea = oReader["idEmpresa"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idComisionLinea"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idLinea'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                comisionesconfiguracion.idLinea = oReader["idLinea"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idLinea"]);







            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Meta'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                comisionesconfiguracion.Meta = oReader["Meta"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["Meta"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Resultado'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                comisionesconfiguracion.Resultado = oReader["Resultado"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["Resultado"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Porcentaje'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                comisionesconfiguracion.Porcentaje = oReader["Porcentaje"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["Porcentaje"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Pago'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                comisionesconfiguracion.Pago = oReader["Pago"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["Pago"]);


            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='RangoIni'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                comisionesconfiguracion.RangoIni = oReader["RangoIni"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["RangoIni"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='RangoFin'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                comisionesconfiguracion.RangoFin = oReader["RangoFin"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["RangoFin"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Factor'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                comisionesconfiguracion.Factor = oReader["Factor"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["Factor"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Comision'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                comisionesconfiguracion.Comision = oReader["Comision"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["Comision"]);






            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='desCategoria'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                comisionesconfiguracion.desCategoria = oReader["desCategoria"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["desCategoria"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='desLinea'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                comisionesconfiguracion.desLinea = oReader["desLinea"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["desLinea"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='desParTabla'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                comisionesconfiguracion.desParTabla = oReader["desParTabla"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["desParTabla"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='desPersona'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                comisionesconfiguracion.desPersona = oReader["desPersona"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["desPersona"]);






			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='UsuarioRegistra'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				comisionesconfiguracion.UsuarioRegistra = oReader["UsuarioRegistra"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["UsuarioRegistra"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='FechaRegistra'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				comisionesconfiguracion.FechaRegistra = oReader["FechaRegistra"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["FechaRegistra"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='UsuarioModifica'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				comisionesconfiguracion.UsuarioModifica = oReader["UsuarioModifica"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["UsuarioModifica"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='FechaModifica'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				comisionesconfiguracion.FechaModifica = oReader["FechaModifica"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["FechaModifica"]);
			

            return  comisionesconfiguracion;        
        }

        public ComisionesConfiguracionE InsertarComisionesConfiguracion(ComisionesConfiguracionE comisionesconfiguracion)
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_InsertarComisionesConfiguracion", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;

                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = comisionesconfiguracion.idEmpresa;
                    oComando.Parameters.Add("@idComision", SqlDbType.Int).Value = comisionesconfiguracion.idComision;
                    oComando.Parameters.Add("@idPeriodo", SqlDbType.Int).Value = comisionesconfiguracion.idPeriodo;
                    oComando.Parameters.Add("@idCategoria", SqlDbType.Int).Value = comisionesconfiguracion.idCategoria;
                    oComando.Parameters.Add("@idLinea", SqlDbType.Int).Value = comisionesconfiguracion.idLinea;
                    oComando.Parameters.Add("@idParTabla", SqlDbType.Int).Value = comisionesconfiguracion.idParTabla;
                    oComando.Parameters.Add("@idVendedor", SqlDbType.Int).Value = comisionesconfiguracion.idVendedor;

                    oComando.Parameters.Add("@NombreZona", SqlDbType.VarChar, 80).Value = comisionesconfiguracion.NombreZona;

                    oComando.Parameters.Add("@RangoIni", SqlDbType.Decimal).Value = comisionesconfiguracion.RangoIni;
                    oComando.Parameters.Add("@RangoFin", SqlDbType.Decimal).Value = comisionesconfiguracion.RangoFin;
                    oComando.Parameters.Add("@Factor", SqlDbType.Decimal).Value = comisionesconfiguracion.Factor;
                    oComando.Parameters.Add("@Comision", SqlDbType.Decimal).Value = comisionesconfiguracion.Comision;
                    oComando.Parameters.Add("@Meta", SqlDbType.Decimal).Value = comisionesconfiguracion.Meta;
                    oComando.Parameters.Add("@Pago", SqlDbType.Decimal).Value = comisionesconfiguracion.Pago;

                    oComando.Parameters.Add("@Estado", SqlDbType.VarChar, 20).Value = comisionesconfiguracion.Estado;

                    oComando.Parameters.Add("@UsuarioRegistra", SqlDbType.VarChar, 20).Value = comisionesconfiguracion.UsuarioRegistra;
                    oComando.Parameters.Add("@FechaRegistra", SqlDbType.SmallDateTime).Value = comisionesconfiguracion.FechaRegistra;
                    oComando.Parameters.Add("@UsuarioModifica", SqlDbType.VarChar, 20).Value = comisionesconfiguracion.UsuarioModifica;
                    oComando.Parameters.Add("@FechaModifica", SqlDbType.SmallDateTime).Value = comisionesconfiguracion.FechaModifica;

                    oComando.Parameters.Add("@TipoTabla", SqlDbType.VarChar, 20).Value = comisionesconfiguracion.TipoTabla;

                    oConexion.Open();
                    comisionesconfiguracion.idComision = Int32.Parse(oComando.ExecuteScalar().ToString());
                    oConexion.Close();
                }
            }

            return comisionesconfiguracion;
        }
        
        public ComisionesConfiguracionE ActualizarComisionesConfiguracion(ComisionesConfiguracionE comisionesconfiguracion)
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ActualizarComisionesConfiguracion", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;

                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = comisionesconfiguracion.idEmpresa;
					oComando.Parameters.Add("@idComision", SqlDbType.Int).Value = comisionesconfiguracion.idComision;
                    oComando.Parameters.Add("@idPeriodo", SqlDbType.Int).Value = comisionesconfiguracion.idPeriodo;
					oComando.Parameters.Add("@NombreZona", SqlDbType.VarChar, 80).Value = comisionesconfiguracion.NombreZona;
					oComando.Parameters.Add("@Estado", SqlDbType.VarChar, 20).Value = comisionesconfiguracion.Estado;
					oComando.Parameters.Add("@UsuarioModifica", SqlDbType.VarChar, 20).Value = comisionesconfiguracion.UsuarioModifica;
					//oComando.Parameters.Add("@FechaModifica", SqlDbType.SmallDateTime).Value = comisionesconfiguracion.FechaModifica;

                    oConexion.Open();
                    oComando.ExecuteNonQuery();
                    oConexion.Close();
                }
            }

            return comisionesconfiguracion;
        }        

        public int EliminarComisionesConfiguracion(Int32 idEmpresa, Int32 idComision)
        {
            int resp = 0;
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_EliminarComisionesConfiguracion", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;

                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
					oComando.Parameters.Add("@idComision", SqlDbType.Int).Value = idComision;

                    oConexion.Open();
                    resp = oComando.ExecuteNonQuery();
                    oConexion.Close();
                }
            }

            return resp;
        }

        public int EliminarComisionesConfiguracionDetalle(Int32 idEmpresa, Int32 idComision)
        {
            int resp = 0;
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_EliminarComisionesConfiguracionDetalle", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;

                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@idComision", SqlDbType.Int).Value = idComision;

                    oConexion.Open();
                    resp = oComando.ExecuteNonQuery();
                    oConexion.Close();
                }
            }

            return resp;
        }

        public List<ComisionesConfiguracionE> ListarComisionesConfiguracion(Int32 idEmpresa, Int32 idComision, String TipoReporte)
        {
           List<ComisionesConfiguracionE> listaEntidad = new List<ComisionesConfiguracionE>();
           ComisionesConfiguracionE entidad = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ListarComisionesConfiguracion", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@idComision", SqlDbType.Int).Value = idComision;
                    oComando.Parameters.Add("@TipoReporte", SqlDbType.VarChar, 20).Value = TipoReporte;
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

        public List<ComisionesConfiguracionE> ListarComisionesConfiguracionPeriodo(Int32 idEmpresa, Int32 idPeriodo, String Busqueda)
        {
            List<ComisionesConfiguracionE> listaEntidad = new List<ComisionesConfiguracionE>();
            ComisionesConfiguracionE entidad = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ListarComisionesConfiguracionPeriodo", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@idPeriodo", SqlDbType.Int).Value = idPeriodo;
                    oComando.Parameters.Add("@Busqueda", SqlDbType.VarChar, 20).Value = Busqueda;
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
        
        public ComisionesConfiguracionE ObtenerComisionesConfiguracion(Int32 idEmpresa, Int32 idComision)
        {        
            ComisionesConfiguracionE comisionesconfiguracion = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ObtenerComisionesConfiguracion", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;

                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
					oComando.Parameters.Add("@idComision", SqlDbType.Int).Value = idComision;
                    oConexion.Open();
                    
                    using (SqlDataReader oReader = oComando.ExecuteReader())
                    {
                        while (oReader.Read())
                        {
                            comisionesconfiguracion = LlenarEntidad(oReader);
                        }
                    }
                }

                oConexion.Close();
            }

            return comisionesconfiguracion;
        }
    }
}