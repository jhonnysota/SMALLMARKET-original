using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

using Entidades.Maestros;
using AccesoDatos.Util;

namespace AccesoDatos.Maestros
{
    public class EmisionDocumentoCCostosAD : DbConection
    {
        
        public EmisionDocumentoCCostosE LlenarEntidad(IDataReader oReader)
        {
            EmisionDocumentoCCostosE emisiondocumentoccostos = new EmisionDocumentoCCostosE();
            
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idEmpresa'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				emisiondocumentoccostos.idEmpresa = oReader["idEmpresa"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idEmpresa"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idLocal'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				emisiondocumentoccostos.idLocal = oReader["idLocal"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idLocal"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idDocumento'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				emisiondocumentoccostos.idDocumento = oReader["idDocumento"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["idDocumento"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='numSerie'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				emisiondocumentoccostos.numSerie = oReader["numSerie"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["numSerie"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='numDocumento'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				emisiondocumentoccostos.numDocumento = oReader["numDocumento"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["numDocumento"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idCCostos'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				emisiondocumentoccostos.idCCostos = oReader["idCCostos"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["idCCostos"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='ImporteOriginal'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				emisiondocumentoccostos.ImporteOriginal = oReader["ImporteOriginal"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["ImporteOriginal"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Porcentaje'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				emisiondocumentoccostos.Porcentaje = oReader["Porcentaje"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["Porcentaje"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='ImportePorcentaje'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				emisiondocumentoccostos.ImportePorcentaje = oReader["ImportePorcentaje"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["ImportePorcentaje"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='UsuarioRegistro'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				emisiondocumentoccostos.UsuarioRegistro = oReader["UsuarioRegistro"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["UsuarioRegistro"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='FechaRegistro'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				emisiondocumentoccostos.FechaRegistro = oReader["FechaRegistro"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["FechaRegistro"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='UsuarioModificacion'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				emisiondocumentoccostos.UsuarioModificacion = oReader["UsuarioModificacion"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["UsuarioModificacion"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='FechaModificacion'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				emisiondocumentoccostos.FechaModificacion = oReader["FechaModificacion"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["FechaModificacion"]);
			

            return  emisiondocumentoccostos;        
        }

        public EmisionDocumentoCCostosE InsertarEmisionDocumentoCCostos(EmisionDocumentoCCostosE emisiondocumentoccostos)
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_InsertarEmisionDocumentoCCostos", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = emisiondocumentoccostos.idEmpresa;
					oComando.Parameters.Add("@idLocal", SqlDbType.Int).Value = emisiondocumentoccostos.idLocal;
					oComando.Parameters.Add("@idDocumento", SqlDbType.VarChar, 2).Value = emisiondocumentoccostos.idDocumento;
					oComando.Parameters.Add("@numSerie", SqlDbType.VarChar, 20).Value = emisiondocumentoccostos.numSerie;
					oComando.Parameters.Add("@numDocumento", SqlDbType.VarChar, 20).Value = emisiondocumentoccostos.numDocumento;
					oComando.Parameters.Add("@idCCostos", SqlDbType.VarChar, 10).Value = emisiondocumentoccostos.idCCostos;
					oComando.Parameters.Add("@ImporteOriginal", SqlDbType.Decimal).Value = emisiondocumentoccostos.ImporteOriginal;
					oComando.Parameters.Add("@Porcentaje", SqlDbType.Decimal).Value = emisiondocumentoccostos.Porcentaje;
					oComando.Parameters.Add("@ImportePorcentaje", SqlDbType.Decimal).Value = emisiondocumentoccostos.ImportePorcentaje;
					oComando.Parameters.Add("@UsuarioRegistro", SqlDbType.VarChar, 20).Value = emisiondocumentoccostos.UsuarioRegistro;

                    oConexion.Open();
                    oComando.ExecuteNonQuery();
                }
            }

            return emisiondocumentoccostos;
        }
        
        public EmisionDocumentoCCostosE ActualizarEmisionDocumentoCCostos(EmisionDocumentoCCostosE emisiondocumentoccostos)
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ActualizarEmisionDocumentoCCostos", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = emisiondocumentoccostos.idEmpresa;
					oComando.Parameters.Add("@idLocal", SqlDbType.Int).Value = emisiondocumentoccostos.idLocal;
					oComando.Parameters.Add("@idDocumento", SqlDbType.VarChar, 2).Value = emisiondocumentoccostos.idDocumento;
					oComando.Parameters.Add("@numSerie", SqlDbType.VarChar, 20).Value = emisiondocumentoccostos.numSerie;
					oComando.Parameters.Add("@numDocumento", SqlDbType.VarChar, 20).Value = emisiondocumentoccostos.numDocumento;
					oComando.Parameters.Add("@idCCostos", SqlDbType.VarChar, 10).Value = emisiondocumentoccostos.idCCostos;
					oComando.Parameters.Add("@ImporteOriginal", SqlDbType.Decimal).Value = emisiondocumentoccostos.ImporteOriginal;
					oComando.Parameters.Add("@Porcentaje", SqlDbType.Decimal).Value = emisiondocumentoccostos.Porcentaje;
					oComando.Parameters.Add("@ImportePorcentaje", SqlDbType.Decimal).Value = emisiondocumentoccostos.ImportePorcentaje;
					oComando.Parameters.Add("@UsuarioModificacion", SqlDbType.VarChar, 20).Value = emisiondocumentoccostos.UsuarioModificacion;

                    oConexion.Open();
                    oComando.ExecuteNonQuery();
                }
            }

            return emisiondocumentoccostos;
        }        

        public int EliminarEmisionDocumentoCCostos(Int32 idEmpresa, Int32 idLocal, String idDocumento, String numSerie, String numDocumento)
        {
            int resp = 0;
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_EliminarEmisionDocumentoCCostos", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
					oComando.Parameters.Add("@idLocal", SqlDbType.Int).Value = idLocal;
					oComando.Parameters.Add("@idDocumento", SqlDbType.VarChar, 2).Value = idDocumento;
					oComando.Parameters.Add("@numSerie", SqlDbType.VarChar, 20).Value = numSerie;
					oComando.Parameters.Add("@numDocumento", SqlDbType.VarChar, 20).Value = numDocumento;

                    oConexion.Open();
                    resp = oComando.ExecuteNonQuery();
                }
            }

            return resp;
        }

        public List<EmisionDocumentoCCostosE> ListarEmisionDocumentoCCostos(Int32 idEmpresa, Int32 idLocal, String idDocumento, String numSerie, String numDocumento)
        {
            List<EmisionDocumentoCCostosE> listaEntidad = new List<EmisionDocumentoCCostosE>();

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ListarEmisionDocumentoCCostos", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@idLocal", SqlDbType.Int).Value = idLocal;
                    oComando.Parameters.Add("@idDocumento", SqlDbType.VarChar, 2).Value = idDocumento;
                    oComando.Parameters.Add("@numSerie", SqlDbType.VarChar, 20).Value = numSerie;
                    oComando.Parameters.Add("@numDocumento", SqlDbType.VarChar, 20).Value = numDocumento;

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
        
        public EmisionDocumentoCCostosE ObtenerEmisionDocumentoCCostos(Int32 idEmpresa, Int32 idLocal, String idDocumento, String numSerie, String numDocumento, String idCCostos)
        {        
            EmisionDocumentoCCostosE emisiondocumentoccostos = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ObtenerEmisionDocumentoCCostos", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
					oComando.Parameters.Add("@idLocal", SqlDbType.Int).Value = idLocal;
					oComando.Parameters.Add("@idDocumento", SqlDbType.VarChar, 2).Value = idDocumento;
					oComando.Parameters.Add("@numSerie", SqlDbType.VarChar, 20).Value = numSerie;
					oComando.Parameters.Add("@numDocumento", SqlDbType.VarChar, 20).Value = numDocumento;
					oComando.Parameters.Add("@idCCostos", SqlDbType.VarChar, 10).Value = idCCostos;

                    oConexion.Open();
                    
                    using (SqlDataReader oReader = oComando.ExecuteReader())
                    {
                        while (oReader.Read())
                        {
                            emisiondocumentoccostos = LlenarEntidad(oReader);
                        }
                    }
                }
            }

            return emisiondocumentoccostos;
        }

    }
}