using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

using Entidades.Maestros;
using AccesoDatos.Util;

namespace AccesoDatos.Maestros
{
    public class CostosClasificacionAD : DbConection
    {
        
        public CostosClasificacionE LlenarEntidad(IDataReader oReader)
        {
            CostosClasificacionE clasificacion = new CostosClasificacionE();
            
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idEmpresa'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				clasificacion.idEmpresa = oReader["idEmpresa"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idEmpresa"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='CodClasificacion'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				clasificacion.CodClasificacion = oReader["CodClasificacion"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["CodClasificacion"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='nombreClasificacion'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				clasificacion.nombreClasificacion = oReader["nombreClasificacion"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["nombreClasificacion"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='numNivel'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				clasificacion.numNivel = oReader["numNivel"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["numNivel"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='indUltimoNivel'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				clasificacion.indUltimoNivel = oReader["indUltimoNivel"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["indUltimoNivel"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='CodCategoriaSup'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				clasificacion.CodCategoriaSup = oReader["CodCategoriaSup"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["CodCategoriaSup"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='UsuarioRegistro'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				clasificacion.UsuarioRegistro = oReader["UsuarioRegistro"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["UsuarioRegistro"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='FechaRegistro'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				clasificacion.FechaRegistro = oReader["FechaRegistro"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["FechaRegistro"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='UsuarioModificacion'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				clasificacion.UsuarioModificacion = oReader["UsuarioModificacion"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["UsuarioModificacion"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='FechaModificacion'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				clasificacion.FechaModificacion = oReader["FechaModificacion"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["FechaModificacion"]);
			

            return  clasificacion;        
        }

        public CostosClasificacionE InsertarClasificacion(CostosClasificacionE clasificacion)
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_InsertarCostosClasificacion", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;

                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = clasificacion.idEmpresa;
					oComando.Parameters.Add("@CodClasificacion", SqlDbType.VarChar, 20).Value = clasificacion.CodClasificacion;
					oComando.Parameters.Add("@nombreClasificacion", SqlDbType.VarChar, 100).Value = clasificacion.nombreClasificacion;
					oComando.Parameters.Add("@numNivel", SqlDbType.Int).Value = clasificacion.numNivel;
					oComando.Parameters.Add("@indUltimoNivel", SqlDbType.Char, 1).Value = clasificacion.indUltimoNivel;
					oComando.Parameters.Add("@CodCategoriaSup", SqlDbType.VarChar, 20).Value = clasificacion.CodCategoriaSup;
					oComando.Parameters.Add("@UsuarioRegistro", SqlDbType.VarChar, 30).Value = clasificacion.UsuarioRegistro;
					oComando.Parameters.Add("@FechaRegistro", SqlDbType.SmallDateTime).Value = clasificacion.FechaRegistro;
					oComando.Parameters.Add("@UsuarioModificacion", SqlDbType.VarChar, 30).Value = clasificacion.UsuarioModificacion;
					oComando.Parameters.Add("@FechaModificacion", SqlDbType.SmallDateTime).Value = clasificacion.FechaModificacion;

                    oConexion.Open();
                    oComando.ExecuteNonQuery();
                    oConexion.Close();
                }
            }

            return clasificacion;
        }
        
        public CostosClasificacionE ActualizarClasificacion(CostosClasificacionE clasificacion)
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ActualizarCostosClasificacion", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;

                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = clasificacion.idEmpresa;
					oComando.Parameters.Add("@CodClasificacion", SqlDbType.VarChar, 20).Value = clasificacion.CodClasificacion;
					oComando.Parameters.Add("@nombreClasificacion", SqlDbType.VarChar, 100).Value = clasificacion.nombreClasificacion;
					oComando.Parameters.Add("@numNivel", SqlDbType.Int).Value = clasificacion.numNivel;
					oComando.Parameters.Add("@indUltimoNivel", SqlDbType.Char, 1).Value = clasificacion.indUltimoNivel;
					oComando.Parameters.Add("@CodCategoriaSup", SqlDbType.VarChar, 20).Value = clasificacion.CodCategoriaSup;
					oComando.Parameters.Add("@UsuarioRegistro", SqlDbType.VarChar, 30).Value = clasificacion.UsuarioRegistro;
					oComando.Parameters.Add("@FechaRegistro", SqlDbType.SmallDateTime).Value = clasificacion.FechaRegistro;
					oComando.Parameters.Add("@UsuarioModificacion", SqlDbType.VarChar, 30).Value = clasificacion.UsuarioModificacion;
					oComando.Parameters.Add("@FechaModificacion", SqlDbType.SmallDateTime).Value = clasificacion.FechaModificacion;

                    oConexion.Open();
                    oComando.ExecuteNonQuery();
                    oConexion.Close();
                }
            }

            return clasificacion;
        }        

        public int EliminarClasificacion(Int32 idEmpresa, String CodClasificacion)
        {
            int resp = 0;
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_EliminarCostosClasificacion", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;

                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
					oComando.Parameters.Add("@CodClasificacion", SqlDbType.VarChar, 20).Value = CodClasificacion;

                    oConexion.Open();
                    resp = oComando.ExecuteNonQuery();
                    oConexion.Close();
                }
            }

            return resp;
        }

        public List<CostosClasificacionE> ListarClasificacion(Int32 idEmpresa)
        {
           List<CostosClasificacionE> listaEntidad = new List<CostosClasificacionE>();
           CostosClasificacionE entidad = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ListarCostosClasificacion", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;

                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;


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

        public List<CostosClasificacionE> ListarClasificacionCat(Int32 idEmpresa, Int32 numNivel)
        {
            List<CostosClasificacionE> listaEntidad = new List<CostosClasificacionE>();
            CostosClasificacionE entidad = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ListarCostosClasificacionCatArbol", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@numNivel", SqlDbType.Int).Value = numNivel;

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

        public CostosClasificacionE ObtenerClasificacion(Int32 idEmpresa, String CodClasificacion)
        {        
            CostosClasificacionE clasificacion = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ObtenerCostosClasificacion", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;

                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
					oComando.Parameters.Add("@CodClasificacion", SqlDbType.VarChar, 20).Value = CodClasificacion;
                    oConexion.Open();
                    
                    using (SqlDataReader oReader = oComando.ExecuteReader())
                    {
                        while (oReader.Read())
                        {
                            clasificacion = LlenarEntidad(oReader);
                        }
                    }
                }

                oConexion.Close();
            }

            return clasificacion;
        }
    }
}