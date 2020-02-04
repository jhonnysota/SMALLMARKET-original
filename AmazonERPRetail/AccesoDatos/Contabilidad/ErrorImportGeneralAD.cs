using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

using Entidades.Contabilidad;
using AccesoDatos.Util;

namespace AccesoDatos.Contabilidad
{
    public class ErrorImportGeneralAD : DbConection
    {

        public ErrorImportGeneralE LlenarEntidad(IDataReader oReader)
        {
            ErrorImportGeneralE errorimportgeneral = new ErrorImportGeneralE();
            
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idEmpresa'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				errorimportgeneral.idEmpresa = oReader["idEmpresa"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idEmpresa"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idLocal'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				errorimportgeneral.idLocal = oReader["idLocal"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idLocal"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idUsuario'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				errorimportgeneral.idUsuario = oReader["idUsuario"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idUsuario"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Archivo'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				errorimportgeneral.Archivo = oReader["Archivo"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["Archivo"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Linea'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				errorimportgeneral.Linea = oReader["Linea"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["Linea"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='NombreCampo'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				errorimportgeneral.NombreCampo = oReader["NombreCampo"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["NombreCampo"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='ValorCampo'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				errorimportgeneral.ValorCampo = oReader["ValorCampo"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["ValorCampo"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Mensaje'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				errorimportgeneral.Mensaje = oReader["Mensaje"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["Mensaje"]);
			

            return  errorimportgeneral;        
        }

        public ErrorImportGeneralE InsertarErrorImportGeneral(ErrorImportGeneralE errorimportgeneral)
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_InsertarErrorImportGeneral", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = errorimportgeneral.idEmpresa;
					oComando.Parameters.Add("@idLocal", SqlDbType.Int).Value = errorimportgeneral.idLocal;
					oComando.Parameters.Add("@idUsuario", SqlDbType.Int).Value = errorimportgeneral.idUsuario;
					oComando.Parameters.Add("@Archivo", SqlDbType.VarChar, 20).Value = errorimportgeneral.Archivo;
					oComando.Parameters.Add("@Linea", SqlDbType.Int).Value = errorimportgeneral.Linea;
					oComando.Parameters.Add("@NombreCampo", SqlDbType.VarChar, 100).Value = errorimportgeneral.NombreCampo;
					oComando.Parameters.Add("@ValorCampo", SqlDbType.VarChar, 100).Value = errorimportgeneral.ValorCampo;
					oComando.Parameters.Add("@Mensaje", SqlDbType.VarChar, 250).Value = errorimportgeneral.Mensaje;

                    oConexion.Open();
                    oComando.ExecuteNonQuery();
                }
            }

            return errorimportgeneral;
        }       

        public int EliminarErrorImportGeneral(Int32 idEmpresa, Int32 idLocal, Int32 idUsuario, String Archivo)
        {
            int resp = 0;
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_EliminarErrorImportGeneral", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
					oComando.Parameters.Add("@idLocal", SqlDbType.Int).Value = idLocal;
					oComando.Parameters.Add("@idUsuario", SqlDbType.Int).Value = idUsuario;
					oComando.Parameters.Add("@Archivo", SqlDbType.VarChar, 20).Value = Archivo;

                    oConexion.Open();
                    resp = oComando.ExecuteNonQuery();
                }
            }

            return resp;
        }

        public List<ErrorImportGeneralE> ListarErrorImportGeneral(Int32 idEmpresa, Int32 idLocal, Int32 idUsuario, String Archivo)
        {
           List<ErrorImportGeneralE> listaEntidad = new List<ErrorImportGeneralE>();
           ErrorImportGeneralE entidad = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ListarErrorImportGeneral", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@idLocal", SqlDbType.Int).Value = idLocal;
                    oComando.Parameters.Add("@idUsuario", SqlDbType.Int).Value = idUsuario;
                    oComando.Parameters.Add("@Archivo", SqlDbType.VarChar, 20).Value = Archivo;

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

    }
}