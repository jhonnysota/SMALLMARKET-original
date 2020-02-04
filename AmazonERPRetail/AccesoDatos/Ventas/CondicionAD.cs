using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

using Entidades.Ventas;
using AccesoDatos.Util;

namespace AccesoDatos.Ventas
{
    public class CondicionAD : DbConection
    {

        public CondicionE LlenarEntidad(IDataReader oReader)
        {
            CondicionE condicion = new CondicionE();
            
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idTipCondicion'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				condicion.idTipCondicion = oReader["idTipCondicion"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idTipCondicion"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idCondicion'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				condicion.idCondicion = oReader["idCondicion"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idCondicion"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='desCondicion'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				condicion.desCondicion = oReader["desCondicion"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["desCondicion"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='GeneraLetra'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				condicion.GeneraLetra = oReader["GeneraLetra"] == DBNull.Value ? false : Convert.ToBoolean(oReader["GeneraLetra"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Credito'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				condicion.Credito = oReader["Credito"] == DBNull.Value ? false : Convert.ToBoolean(oReader["Credito"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='SeCobra'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				condicion.SeCobra = oReader["SeCobra"] == DBNull.Value ? false : Convert.ToBoolean(oReader["SeCobra"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='ManejaUnidad'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				condicion.ManejaUnidad = oReader["ManejaUnidad"] == DBNull.Value ? false : Convert.ToBoolean(oReader["ManejaUnidad"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='tGratuita'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				condicion.tGratuita = oReader["tGratuita"] == DBNull.Value ? false : Convert.ToBoolean(oReader["tGratuita"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='ConImpuesto'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				condicion.ConImpuesto = oReader["ConImpuesto"] == DBNull.Value ? false : Convert.ToBoolean(oReader["ConImpuesto"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='ncDescuentos'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				condicion.ncDescuentos = oReader["ncDescuentos"] == DBNull.Value ? false : Convert.ToBoolean(oReader["ncDescuentos"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='tFilial'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				condicion.tFilial = oReader["tFilial"] == DBNull.Value ? true : Convert.ToBoolean(oReader["tFilial"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='indCreditoCobranza'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                condicion.indCreditoCobranza = oReader["indCreditoCobranza"] == DBNull.Value ? false : Convert.ToBoolean(oReader["indCreditoCobranza"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='indDias'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                condicion.indDias = oReader["indDias"] == DBNull.Value ? false : Convert.ToBoolean(oReader["indDias"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='UsuarioRegistro'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				condicion.UsuarioRegistro = oReader["UsuarioRegistro"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["UsuarioRegistro"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='FechaRegistro'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				condicion.FechaRegistro = oReader["FechaRegistro"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["FechaRegistro"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='UsuarioModificacion'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				condicion.UsuarioModificacion = oReader["UsuarioModificacion"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["UsuarioModificacion"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='FechaModificacion'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				condicion.FechaModificacion = oReader["FechaModificacion"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["FechaModificacion"]);

            return  condicion;        
        }

        public CondicionE InsertarCondicion(CondicionE condicion)
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_InsertarCondicion", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idTipCondicion", SqlDbType.Int).Value = condicion.idTipCondicion;
					oComando.Parameters.Add("@idCondicion", SqlDbType.TinyInt).Value = condicion.idCondicion;
					oComando.Parameters.Add("@desCondicion", SqlDbType.VarChar, 50).Value = condicion.desCondicion;
					oComando.Parameters.Add("@GeneraLetra", SqlDbType.Bit).Value = condicion.GeneraLetra;
					oComando.Parameters.Add("@Credito", SqlDbType.Bit).Value = condicion.Credito;
					oComando.Parameters.Add("@SeCobra", SqlDbType.Bit).Value = condicion.SeCobra;
					oComando.Parameters.Add("@ManejaUnidad", SqlDbType.Bit).Value = condicion.ManejaUnidad;
					oComando.Parameters.Add("@tGratuita", SqlDbType.Bit).Value = condicion.tGratuita;
					oComando.Parameters.Add("@ConImpuesto", SqlDbType.Bit).Value = condicion.ConImpuesto;
					oComando.Parameters.Add("@ncDescuentos", SqlDbType.Bit).Value = condicion.ncDescuentos;
					oComando.Parameters.Add("@tFilial", SqlDbType.Bit).Value = condicion.tFilial;
                    oComando.Parameters.Add("@indCreditoCobranza", SqlDbType.Bit).Value = condicion.indCreditoCobranza;
                    oComando.Parameters.Add("@indDias", SqlDbType.Bit).Value = condicion.indDias;
                    oComando.Parameters.Add("@UsuarioRegistro", SqlDbType.VarChar, 20).Value = condicion.UsuarioRegistro;

                    oConexion.Open();
                    oComando.ExecuteNonQuery();
                }
            }

            return condicion;
        }
        
        public CondicionE ActualizarCondicion(CondicionE condicion)
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ActualizarCondicion", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idTipCondicion", SqlDbType.Int).Value = condicion.idTipCondicion;
					oComando.Parameters.Add("@idCondicion", SqlDbType.TinyInt).Value = condicion.idCondicion;
					oComando.Parameters.Add("@desCondicion", SqlDbType.VarChar, 50).Value = condicion.desCondicion;
					oComando.Parameters.Add("@GeneraLetra", SqlDbType.Bit).Value = condicion.GeneraLetra;
					oComando.Parameters.Add("@Credito", SqlDbType.Bit).Value = condicion.Credito;
					oComando.Parameters.Add("@SeCobra", SqlDbType.Bit).Value = condicion.SeCobra;
					oComando.Parameters.Add("@ManejaUnidad", SqlDbType.Bit).Value = condicion.ManejaUnidad;
					oComando.Parameters.Add("@tGratuita", SqlDbType.Bit).Value = condicion.tGratuita;
					oComando.Parameters.Add("@ConImpuesto", SqlDbType.Bit).Value = condicion.ConImpuesto;
					oComando.Parameters.Add("@ncDescuentos", SqlDbType.Bit).Value = condicion.ncDescuentos;
					oComando.Parameters.Add("@tFilial", SqlDbType.Bit).Value = condicion.tFilial;
                    oComando.Parameters.Add("@indCreditoCobranza", SqlDbType.Bit).Value = condicion.indCreditoCobranza;
                    oComando.Parameters.Add("@indDias", SqlDbType.Bit).Value = condicion.indDias;
                    oComando.Parameters.Add("@UsuarioModificacion", SqlDbType.VarChar, 20).Value = condicion.UsuarioModificacion;

                    oConexion.Open();
                    oComando.ExecuteNonQuery();
                }
            }

            return condicion;
        }

        public List<CondicionE> ListarCondicionPorTipo(Int32 idTipCondicion)
        {
            List<CondicionE> listaEntidad = new List<CondicionE>();
            CondicionE entidad = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ListarCondicionPorTipo", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idTipCondicion", SqlDbType.Int).Value = idTipCondicion;

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

        public CondicionE ObtenerCondicion(Int32 idTipCondicion, Int32 idCondicion)
        {
            CondicionE condicion = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ObtenerCondicion", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idTipCondicion", SqlDbType.Int).Value = idTipCondicion;
                    oComando.Parameters.Add("@idCondicion", SqlDbType.TinyInt).Value = idCondicion;

                    oConexion.Open();

                    using (SqlDataReader oReader = oComando.ExecuteReader())
                    {
                        while (oReader.Read())
                        {
                            condicion = LlenarEntidad(oReader);
                        }
                    }
                }
            }

            return condicion;
        }

        public int EliminarCondicion(Int32 idTipCondicion)
        {
            int resp = 0;
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_EliminarCondicion", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idTipCondicion", SqlDbType.Int).Value = idTipCondicion;

                    oConexion.Open();
                    resp = oComando.ExecuteNonQuery();
                }
            }

            return resp;
        }

        public Int32 MaxCondicion(Int32 idTipCondicion)
        {
            int resp = 0;
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_MaxCondicion", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idTipCondicion", SqlDbType.Int).Value = idTipCondicion;

                    oConexion.Open();
                    resp = Convert.ToInt32(oComando.ExecuteScalar());
                }
            }

            return resp;
        }

    }
}