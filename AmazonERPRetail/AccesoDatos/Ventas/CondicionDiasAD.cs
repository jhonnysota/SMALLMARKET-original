using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

using Entidades.Ventas;
using AccesoDatos.Util;

namespace AccesoDatos.Ventas
{
    public class CondicionDiasAD : DbConection
    {

        public CondicionDiasE LlenarEntidad(IDataReader oReader)
        {
            CondicionDiasE condiciondias = new CondicionDiasE();
            
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idTipCondicion'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				condiciondias.idTipCondicion = oReader["idTipCondicion"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idTipCondicion"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idCondicion'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				condiciondias.idCondicion = oReader["idCondicion"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idCondicion"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Dias'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				condiciondias.Dias = oReader["Dias"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["Dias"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Dias'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                condiciondias.DiasAnte = oReader["Dias"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["Dias"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='UsuarioRegistro'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				condiciondias.UsuarioRegistro = oReader["UsuarioRegistro"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["UsuarioRegistro"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='FechaRegistro'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				condiciondias.FechaRegistro = oReader["FechaRegistro"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["FechaRegistro"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='UsuarioModificacion'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				condiciondias.UsuarioModificacion = oReader["UsuarioModificacion"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["UsuarioModificacion"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='FechaModificacion'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				condiciondias.FechaModificacion = oReader["FechaModificacion"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["FechaModificacion"]);
			

            return  condiciondias;        
        }

        public CondicionDiasE InsertarCondicionDias(CondicionDiasE condiciondias)
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_InsertarCondicionDias", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idTipCondicion", SqlDbType.Int).Value = condiciondias.idTipCondicion;
					oComando.Parameters.Add("@idCondicion", SqlDbType.TinyInt).Value = condiciondias.idCondicion;
					oComando.Parameters.Add("@Dias", SqlDbType.TinyInt).Value = condiciondias.Dias;
					oComando.Parameters.Add("@UsuarioRegistro", SqlDbType.VarChar, 20).Value = condiciondias.UsuarioRegistro;

                    oConexion.Open();
                    oComando.ExecuteNonQuery();
                }
            }

            return condiciondias;
        }
        
        public CondicionDiasE ActualizarCondicionDias(CondicionDiasE condiciondias)
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ActualizarCondicionDias", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idTipCondicion", SqlDbType.Int).Value = condiciondias.idTipCondicion;
					oComando.Parameters.Add("@idCondicion", SqlDbType.TinyInt).Value = condiciondias.idCondicion;
					oComando.Parameters.Add("@Dias", SqlDbType.TinyInt).Value = condiciondias.Dias;
                    oComando.Parameters.Add("@DiasAnte", SqlDbType.TinyInt).Value = condiciondias.DiasAnte;
                    oComando.Parameters.Add("@UsuarioModificacion", SqlDbType.VarChar, 20).Value = condiciondias.UsuarioModificacion;

                    oConexion.Open();
                    oComando.ExecuteNonQuery();
                 }
            }

            return condiciondias;
        }

        public Int32 ObtenerDiasVencimiento(Int32 idTipCondicion, Int32 idCondicion)
        {
            Int32 Dias = 0;
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ObtenerDiasVencimiento", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idTipCondicion", SqlDbType.Int).Value = idTipCondicion;
                    oComando.Parameters.Add("@idCondicion", SqlDbType.TinyInt).Value = idCondicion;

                    oConexion.Open();
                    Dias = Convert.ToInt32(oComando.ExecuteScalar());
                }
            }

            return Dias;
        }
         
        public List<CondicionDiasE> ListarCondicionDias(Int32 idTipCondicion, Int32 idCondicion)
        {
           List<CondicionDiasE> listaEntidad = new List<CondicionDiasE>();
           CondicionDiasE entidad = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ListarCondicionDias", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idTipCondicion", SqlDbType.Int).Value = idTipCondicion;
                    oComando.Parameters.Add("@idCondicion", SqlDbType.Int).Value = idCondicion;

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
            }

            return listaEntidad;
        }

        public Int32 EliminarCondicionDias(Int32 idTipCondicion, Int32 idCondicion)
        {
            Int32 resp = 0;
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_EliminarCondicionDias", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idTipCondicion", SqlDbType.Int).Value = idTipCondicion;
                    oComando.Parameters.Add("@idCondicion", SqlDbType.TinyInt).Value = idCondicion;

                    oConexion.Open();
                    resp = oComando.ExecuteNonQuery();
                }
            }

            return resp;
        }

    }
}