using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

using Entidades.Almacen;
using AccesoDatos.Util;

namespace AccesoDatos.Almacen
{
    public class CorrelativoAD : DbConection
    {

        public CorrelativoE LlenarEntidad(IDataReader oReader)
        {
            CorrelativoE correlativo = new CorrelativoE();
            
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idEmpresa'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				correlativo.idEmpresa = oReader["idEmpresa"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idEmpresa"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idCorrelativo'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				correlativo.idCorrelativo = oReader["idCorrelativo"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idCorrelativo"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idTipo'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                correlativo.idTipo = oReader["idTipo"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idTipo"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Descripción'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				correlativo.Descripción = oReader["Descripción"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["Descripción"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='numSerie'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				correlativo.numSerie = oReader["numSerie"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["numSerie"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='numCorrelativo'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				correlativo.numCorrelativo = oReader["numCorrelativo"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["numCorrelativo"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='UsuarioRegistro'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				correlativo.UsuarioRegistro = oReader["UsuarioRegistro"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["UsuarioRegistro"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='FechaRegistro'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				correlativo.FechaRegistro = oReader["FechaRegistro"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["FechaRegistro"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='UsuarioModificacion'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				correlativo.UsuarioModificacion = oReader["UsuarioModificacion"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["UsuarioModificacion"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='FechaModificacion'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				correlativo.FechaModificacion = oReader["FechaModificacion"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["FechaModificacion"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='desTipo'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                correlativo.desTipo = oReader["desTipo"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["desTipo"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='formato'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                correlativo.formato = oReader["formato"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["formato"]);
           

            return  correlativo;        
        }

        public CorrelativoE InsertarCorrelativo(CorrelativoE correlativo)
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_InsertarCorrelativo", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = correlativo.idEmpresa;
					oComando.Parameters.Add("@Descripción", SqlDbType.VarChar, 50).Value = correlativo.Descripción;
                    oComando.Parameters.Add("@idTipo", SqlDbType.Int).Value = correlativo.idTipo;
					oComando.Parameters.Add("@numSerie", SqlDbType.VarChar, 20).Value = correlativo.numSerie;
					oComando.Parameters.Add("@numCorrelativo", SqlDbType.VarChar, 20).Value = correlativo.numCorrelativo;
					oComando.Parameters.Add("@UsuarioRegistro", SqlDbType.VarChar, 20).Value = correlativo.UsuarioRegistro;
					oComando.Parameters.Add("@FechaRegistro", SqlDbType.SmallDateTime).Value = correlativo.FechaRegistro;
					oComando.Parameters.Add("@UsuarioModificacion", SqlDbType.VarChar, 20).Value = correlativo.UsuarioModificacion;
					oComando.Parameters.Add("@FechaModificacion", SqlDbType.SmallDateTime).Value = correlativo.FechaModificacion;
                    oComando.Parameters.Add("@formato", SqlDbType.VarChar, 10).Value = correlativo.formato;

                    oConexion.Open();
                    correlativo.idCorrelativo = Int32.Parse(oComando.ExecuteScalar().ToString());
                }
            }

            return correlativo;
        }
        
        public CorrelativoE ActualizarCorrelativo(CorrelativoE correlativo)
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ActualizarCorrelativo", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = correlativo.idEmpresa;
					oComando.Parameters.Add("@idCorrelativo", SqlDbType.Int).Value = correlativo.idCorrelativo;
                    oComando.Parameters.Add("@idTipo", SqlDbType.Int).Value = correlativo.idTipo;
					oComando.Parameters.Add("@Descripción", SqlDbType.VarChar, 50).Value = correlativo.Descripción;
					oComando.Parameters.Add("@numSerie", SqlDbType.VarChar, 20).Value = correlativo.numSerie;
					oComando.Parameters.Add("@numCorrelativo", SqlDbType.VarChar, 20).Value = correlativo.numCorrelativo;
					oComando.Parameters.Add("@UsuarioRegistro", SqlDbType.VarChar, 20).Value = correlativo.UsuarioRegistro;
					oComando.Parameters.Add("@FechaRegistro", SqlDbType.SmallDateTime).Value = correlativo.FechaRegistro;
					oComando.Parameters.Add("@UsuarioModificacion", SqlDbType.VarChar, 20).Value = correlativo.UsuarioModificacion;
					oComando.Parameters.Add("@FechaModificacion", SqlDbType.SmallDateTime).Value = correlativo.FechaModificacion;
                    oComando.Parameters.Add("@formato", SqlDbType.VarChar, 10).Value = correlativo.formato;

                    oConexion.Open();
                    oComando.ExecuteNonQuery();
                }
            }

            return correlativo;
        }        

        public int EliminarCorrelativo(Int32 idEmpresa, Int32 idCorrelativo)
        {
            int resp = 0;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_EliminarCorrelativo", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
					oComando.Parameters.Add("@idCorrelativo", SqlDbType.Int).Value = idCorrelativo;

                    oConexion.Open();
                    resp = oComando.ExecuteNonQuery();
                }
            }

            return resp;
        }

        public List<CorrelativoE> ListarCorrelativo()
        {
            List<CorrelativoE> listaEntidad = new List<CorrelativoE>();

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ListarCorrelativo", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
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
        
        public CorrelativoE ObtenerCorrelativo(Int32 idEmpresa, Int32 idCorrelativo)
        {        
            CorrelativoE correlativo = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ObtenerCorrelativo", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
					oComando.Parameters.Add("@idCorrelativo", SqlDbType.Int).Value = idCorrelativo;

                    oConexion.Open();
                    
                    using (SqlDataReader oReader = oComando.ExecuteReader())
                    {
                        while (oReader.Read())
                        {
                            correlativo = LlenarEntidad(oReader);
                        }
                    }
                }
            }

            return correlativo;
        }

    }
}