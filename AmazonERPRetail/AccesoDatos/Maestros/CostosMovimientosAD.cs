using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

using Entidades.Maestros;
using AccesoDatos.Util;

namespace AccesoDatos.Maestros
{
    public class CostosMovimientosAD : DbConection
    {
        
        public CostosMovimientosE LlenarEntidad(IDataReader oReader)
        {
            CostosMovimientosE costosmovimientos = new CostosMovimientosE();
            
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idEmpresa'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				costosmovimientos.idEmpresa = oReader["idEmpresa"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idEmpresa"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idElemento'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				costosmovimientos.idElemento = oReader["idElemento"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idElemento"]);


            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='CodClasificacion'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                costosmovimientos.CodClasificacion = oReader["CodClasificacion"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["CodClasificacion"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Nombre'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				costosmovimientos.Nombre = oReader["Nombre"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["Nombre"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Anio'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				costosmovimientos.Anio = oReader["Anio"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["Anio"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='UsuarioRegistro'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				costosmovimientos.UsuarioRegistro = oReader["UsuarioRegistro"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["UsuarioRegistro"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='FechaRegistro'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				costosmovimientos.FechaRegistro = oReader["FechaRegistro"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["FechaRegistro"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='UsuarioModificacion'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				costosmovimientos.UsuarioModificacion = oReader["UsuarioModificacion"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["UsuarioModificacion"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='FechaModificacion'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				costosmovimientos.FechaModificacion = oReader["FechaModificacion"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["FechaModificacion"]);
			

            return  costosmovimientos;        
        }

        public CostosMovimientosE InsertarCostosMovimientos(CostosMovimientosE costosmovimientos)
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_InsertarCostosMovimientos", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;

                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = costosmovimientos.idEmpresa;
                    oComando.Parameters.Add("@CodClasificacion", SqlDbType.VarChar, 20).Value = costosmovimientos.CodClasificacion;
                    oComando.Parameters.Add("@Nombre", SqlDbType.VarChar, 100).Value = costosmovimientos.Nombre;
                    oComando.Parameters.Add("@idElemento", SqlDbType.Int).Value = costosmovimientos.idElemento;
                    oComando.Parameters.Add("@Anio", SqlDbType.VarChar, 4).Value = costosmovimientos.Anio;
					oComando.Parameters.Add("@UsuarioRegistro", SqlDbType.VarChar, 30).Value = costosmovimientos.UsuarioRegistro;
					oComando.Parameters.Add("@FechaRegistro", SqlDbType.SmallDateTime).Value = costosmovimientos.FechaRegistro;
					oComando.Parameters.Add("@UsuarioModificacion", SqlDbType.VarChar, 30).Value = costosmovimientos.UsuarioModificacion;
					oComando.Parameters.Add("@FechaModificacion", SqlDbType.SmallDateTime).Value = costosmovimientos.FechaModificacion;

                    oConexion.Open();
                    oComando.ExecuteNonQuery();
                    oConexion.Close();
                }
            }

            return costosmovimientos;
        }
        
        public CostosMovimientosE ActualizarCostosMovimientos(CostosMovimientosE costosmovimientos)
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ActualizarCostosMovimientos", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;

                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = costosmovimientos.idEmpresa;
                    oComando.Parameters.Add("@CodClasificacion", SqlDbType.VarChar, 20).Value = costosmovimientos.CodClasificacion;
                    oComando.Parameters.Add("@Nombre", SqlDbType.VarChar,100).Value = costosmovimientos.Nombre;
                    oComando.Parameters.Add("@idElemento", SqlDbType.Int).Value = costosmovimientos.idElemento;
					oComando.Parameters.Add("@Anio", SqlDbType.VarChar, 4).Value = costosmovimientos.Anio;
					oComando.Parameters.Add("@UsuarioRegistro", SqlDbType.VarChar, 30).Value = costosmovimientos.UsuarioRegistro;
					oComando.Parameters.Add("@FechaRegistro", SqlDbType.SmallDateTime).Value = costosmovimientos.FechaRegistro;
					oComando.Parameters.Add("@UsuarioModificacion", SqlDbType.VarChar, 30).Value = costosmovimientos.UsuarioModificacion;
					oComando.Parameters.Add("@FechaModificacion", SqlDbType.SmallDateTime).Value = costosmovimientos.FechaModificacion;

                    oConexion.Open();
                    oComando.ExecuteNonQuery();
                    oConexion.Close();
                }
            }

            return costosmovimientos;
        }        

        public int EliminarCostosMovimientos(Int32 idEmpresa,String CodClasificacion, Int32 idElemento , String Anio)
        {
            int resp = 0;
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_EliminarCostosMovimientos", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;

                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@CodClasificacion", SqlDbType.VarChar, 20).Value = CodClasificacion;
                    oComando.Parameters.Add("@idElemento", SqlDbType.Int).Value = idElemento;
                    oComando.Parameters.Add("@Anio", SqlDbType.VarChar, 4).Value = Anio;
                    oConexion.Open();
                    resp = oComando.ExecuteNonQuery();
                    oConexion.Close();
                }
            }

            return resp;
        }

        public List<CostosMovimientosE> ListarCostosMovimientos(Int32 idEmpresa, Int32 idElemento, String Anio)
        {
           List<CostosMovimientosE> listaEntidad = new List<CostosMovimientosE>();
           CostosMovimientosE entidad = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ListarCostosMovimientos", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@idElemento", SqlDbType.Int).Value = idElemento;
                    oComando.Parameters.Add("@Anio", SqlDbType.VarChar,4).Value = Anio;


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
        
        public CostosMovimientosE ObtenerCostosMovimientos(Int32 idEmpresa, String CodClasificacion, Int32 idElemento, String Anio)
        {        
            CostosMovimientosE costosmovimientos = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ObtenerCostosMovimientos", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;

                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@CodClasificacion", SqlDbType.VarChar, 20).Value = CodClasificacion;
                    oComando.Parameters.Add("@idElemento", SqlDbType.Int).Value = idElemento;
                    oComando.Parameters.Add("@Anio", SqlDbType.VarChar, 4).Value = Anio;
                    oConexion.Open();
                    
                    using (SqlDataReader oReader = oComando.ExecuteReader())
                    {
                        while (oReader.Read())
                        {
                            costosmovimientos = LlenarEntidad(oReader);
                        }
                    }
                }

                oConexion.Close();
            }

            return costosmovimientos;
        }
    }
}