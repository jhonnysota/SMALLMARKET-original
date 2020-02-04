using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

using Entidades.Maestros;
using AccesoDatos.Util;

namespace AccesoDatos.Maestros
{
    public class AfectacionIgvAD : DbConection
    {

        public AfectacionIgvE LlenarEntidad(IDataReader oReader)
        {
            AfectacionIgvE afectacionigv = new AfectacionIgvE();
            
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idEmpresa'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				afectacionigv.idEmpresa = oReader["idEmpresa"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idEmpresa"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idAfectacion'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				afectacionigv.idAfectacion = oReader["idAfectacion"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idAfectacion"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='DesAfectacion'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				afectacionigv.DesAfectacion = oReader["DesAfectacion"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["DesAfectacion"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='EquivalenciaSunat'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                afectacionigv.EquivalenciaSunat = oReader["EquivalenciaSunat"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["EquivalenciaSunat"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='indIgv'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				afectacionigv.indIgv = oReader["indIgv"] == DBNull.Value ? false : Convert.ToBoolean(oReader["indIgv"]);
            
            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='indEstado'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                afectacionigv.indEstado = oReader["indEstado"] == DBNull.Value ? false : Convert.ToBoolean(oReader["indEstado"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='UsuarioRegistro'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				afectacionigv.UsuarioRegistro = oReader["UsuarioRegistro"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["UsuarioRegistro"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='FechaRegistro'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				afectacionigv.FechaRegistro = oReader["FechaRegistro"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["FechaRegistro"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='UsuarioModificacion'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				afectacionigv.UsuarioModificacion = oReader["UsuarioModificacion"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["UsuarioModificacion"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='FechaModificacion'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				afectacionigv.FechaModificacion = oReader["FechaModificacion"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["FechaModificacion"]);

            //Extensiones
            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='DesAfectacion'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                afectacionigv.desTemporal = oReader["DesAfectacion"] == DBNull.Value ? String.Empty : afectacionigv.EquivalenciaSunat + " - " + Convert.ToString(oReader["DesAfectacion"]);

            return  afectacionigv;        
        }

        public AfectacionIgvE InsertarAfectacionIgv(AfectacionIgvE afectacionigv)
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_InsertarAfectacionIgv", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = afectacionigv.idEmpresa;
					oComando.Parameters.Add("@DesAfectacion", SqlDbType.VarChar, 100).Value = afectacionigv.DesAfectacion;
                    oComando.Parameters.Add("@EquivalenciaSunat", SqlDbType.VarChar, 2).Value = afectacionigv.EquivalenciaSunat;
                    oComando.Parameters.Add("@indIgv", SqlDbType.Bit).Value = afectacionigv.indIgv;
                    oComando.Parameters.Add("@UsuarioRegistro", SqlDbType.VarChar, 20).Value = afectacionigv.UsuarioRegistro;

                    oConexion.Open();
                    oComando.ExecuteNonQuery();
                }
            }

            return afectacionigv;
        }
        
        public AfectacionIgvE ActualizarAfectacionIgv(AfectacionIgvE afectacionigv)
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ActualizarAfectacionIgv", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = afectacionigv.idEmpresa;
                    oComando.Parameters.Add("@idAfectacion", SqlDbType.Int).Value = afectacionigv.idAfectacion;
                    oComando.Parameters.Add("@DesAfectacion", SqlDbType.VarChar, 100).Value = afectacionigv.DesAfectacion;
                    oComando.Parameters.Add("@EquivalenciaSunat", SqlDbType.VarChar, 2).Value = afectacionigv.EquivalenciaSunat;
                    oComando.Parameters.Add("@indIgv", SqlDbType.Bit).Value = afectacionigv.indIgv;
                    oComando.Parameters.Add("@UsuarioModificacion", SqlDbType.VarChar, 20).Value = afectacionigv.UsuarioModificacion;

                    oConexion.Open();
                    oComando.ExecuteNonQuery();
                }
            }

            return afectacionigv;
        }        

        public int EliminarAfectacionIgv(Int32 idEmpresa, Int32 idAfectacion, Boolean indEstado, String UsuarioAnula)
        {
            int resp = 0;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_EliminarAfectacionIgv", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
					oComando.Parameters.Add("@idAfectacion", SqlDbType.Int).Value = idAfectacion;
                    oComando.Parameters.Add("@indEstado", SqlDbType.Bit).Value = indEstado;
                    oComando.Parameters.Add("@UsuarioAnula", SqlDbType.VarChar, 20).Value = UsuarioAnula;

                    oConexion.Open();
                    resp = oComando.ExecuteNonQuery();
                }
            }

            return resp;
        }

        public List<AfectacionIgvE> ListarAfectacionIgv(Int32 idEmpresa)
        {
            List<AfectacionIgvE> listaEntidad = new List<AfectacionIgvE>();

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ListarAfectacionIgv", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;

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
        
        public AfectacionIgvE ObtenerAfectacionIgv(Int32 idEmpresa, Int32 idAfectacion)
        {        
            AfectacionIgvE afectacionigv = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ObtenerAfectacionIgv", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
					oComando.Parameters.Add("@idAfectacion", SqlDbType.Int).Value = idAfectacion;

                    oConexion.Open();
                    
                    using (SqlDataReader oReader = oComando.ExecuteReader())
                    {
                        while (oReader.Read())
                        {
                            afectacionigv = LlenarEntidad(oReader);
                        }
                    }
                }
            }

            return afectacionigv;
        }

        public List<AfectacionIgvE> ListarAfectacionIgvActivos(Int32 idEmpresa)
        {
            List<AfectacionIgvE> listaEntidad = new List<AfectacionIgvE>();

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ListarAfectacionIgvActivos", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;

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