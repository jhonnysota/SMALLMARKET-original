using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

using Entidades.Maestros;
using AccesoDatos.Util;

namespace AccesoDatos.Maestros
{
    public class CostosEstrucAD : DbConection
    {
        
        public CostosEstrucE LlenarEntidad(IDataReader oReader)
        {
            CostosEstrucE estruc = new CostosEstrucE();
            
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idEmpresa'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				estruc.idEmpresa = oReader["idEmpresa"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idEmpresa"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='numNivel'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				estruc.numNivel = oReader["numNivel"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["numNivel"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='desNivel'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				estruc.desNivel = oReader["desNivel"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["desNivel"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='numLongitud'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				estruc.numLongitud = oReader["numLongitud"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["numLongitud"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='indUltimoNivel'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				estruc.indUltimoNivel = oReader["indUltimoNivel"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["indUltimoNivel"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='UsuarioRegistro'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				estruc.UsuarioRegistro = oReader["UsuarioRegistro"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["UsuarioRegistro"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='FechaRegistro'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				estruc.FechaRegistro = oReader["FechaRegistro"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["FechaRegistro"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='UsuarioModificacion'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				estruc.UsuarioModificacion = oReader["UsuarioModificacion"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["UsuarioModificacion"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='FechaModificacion'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				estruc.FechaModificacion = oReader["FechaModificacion"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["FechaModificacion"]);
			

            return  estruc;        
        }

        public CostosEstrucE InsertarEstruc(CostosEstrucE estruc)
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_InsertarCostosEstruc", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;

                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = estruc.idEmpresa;
					oComando.Parameters.Add("@numNivel", SqlDbType.Int).Value = estruc.numNivel;
					oComando.Parameters.Add("@desNivel", SqlDbType.VarChar, 50).Value = estruc.desNivel;
					oComando.Parameters.Add("@numLongitud", SqlDbType.Int).Value = estruc.numLongitud;
					oComando.Parameters.Add("@indUltimoNivel", SqlDbType.Char, 1).Value = estruc.indUltimoNivel;
					oComando.Parameters.Add("@UsuarioRegistro", SqlDbType.VarChar, 30).Value = estruc.UsuarioRegistro;
					oComando.Parameters.Add("@FechaRegistro", SqlDbType.SmallDateTime).Value = estruc.FechaRegistro;
					oComando.Parameters.Add("@UsuarioModificacion", SqlDbType.VarChar, 30).Value = estruc.UsuarioModificacion;
					oComando.Parameters.Add("@FechaModificacion", SqlDbType.SmallDateTime).Value = estruc.FechaModificacion;

                    oConexion.Open();
                    oComando.ExecuteNonQuery();
                    oConexion.Close();
                }
            }

            return estruc;
        }
        
        public CostosEstrucE ActualizarEstruc(CostosEstrucE estruc)
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ActualizarCostosEstruc", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;

                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = estruc.idEmpresa;
					oComando.Parameters.Add("@numNivel", SqlDbType.Int).Value = estruc.numNivel;
					oComando.Parameters.Add("@desNivel", SqlDbType.VarChar, 50).Value = estruc.desNivel;
					oComando.Parameters.Add("@numLongitud", SqlDbType.Int).Value = estruc.numLongitud;
					oComando.Parameters.Add("@indUltimoNivel", SqlDbType.Char, 1).Value = estruc.indUltimoNivel;
					oComando.Parameters.Add("@UsuarioRegistro", SqlDbType.VarChar, 30).Value = estruc.UsuarioRegistro;
					oComando.Parameters.Add("@FechaRegistro", SqlDbType.SmallDateTime).Value = estruc.FechaRegistro;
					oComando.Parameters.Add("@UsuarioModificacion", SqlDbType.VarChar, 30).Value = estruc.UsuarioModificacion;
					oComando.Parameters.Add("@FechaModificacion", SqlDbType.SmallDateTime).Value = estruc.FechaModificacion;

                    oConexion.Open();
                    oComando.ExecuteNonQuery();
                    oConexion.Close();
                }
            }

            return estruc;
        }        

        public int EliminarEstruc(Int32 idEmpresa, Int32 numNivel)
        {
            int resp = 0;
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_EliminarCostosEstruc", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;

                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
					oComando.Parameters.Add("@numNivel", SqlDbType.Int).Value = numNivel;

                    oConexion.Open();
                    resp = oComando.ExecuteNonQuery();
                    oConexion.Close();
                }
            }

            return resp;
        }

        public List<CostosEstrucE> ListarEstruc()
        {
           List<CostosEstrucE> listaEntidad = new List<CostosEstrucE>();
           CostosEstrucE entidad = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ListarCostosEstruc", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
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
        
        public CostosEstrucE ObtenerEstruc(Int32 idEmpresa, Int32 numNivel)
        {        
            CostosEstrucE estruc = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ObtenerCostosEstruc", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;

                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
					oComando.Parameters.Add("@numNivel", SqlDbType.Int).Value = numNivel;
                    oConexion.Open();
                    
                    using (SqlDataReader oReader = oComando.ExecuteReader())
                    {
                        while (oReader.Read())
                        {
                            estruc = LlenarEntidad(oReader);
                        }
                    }
                }

                oConexion.Close();
            }

            return estruc;
        }
    }
}