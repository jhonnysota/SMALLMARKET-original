using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

using Entidades.Ventas;
using AccesoDatos.Util;

namespace AccesoDatos.Ventas
{
    public class TipoTrasladoAD : DbConection
    {

        public TipoTrasladoE LlenarEntidad(IDataReader oReader)
        {
            TipoTrasladoE tipotraslado = new TipoTrasladoE();
            
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idTraslado'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				tipotraslado.idTraslado = oReader["idTraslado"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idTraslado"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='desTraslado'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				tipotraslado.desTraslado = oReader["desTraslado"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["desTraslado"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='codSunat'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				tipotraslado.codSunat = oReader["codSunat"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["codSunat"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='flagFact'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				tipotraslado.flagFact = oReader["flagFact"] == DBNull.Value ? false : Convert.ToBoolean(oReader["flagFact"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='flagCtaCte'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				tipotraslado.flagCtaCte = oReader["flagCtaCte"] == DBNull.Value ? false : Convert.ToBoolean(oReader["flagCtaCte"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='codFmtp'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				tipotraslado.codFmtp = oReader["codFmtp"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["codFmtp"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='PonerCeroVenta'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				tipotraslado.PonerCeroVenta = oReader["PonerCeroVenta"] == DBNull.Value ? false : Convert.ToBoolean(oReader["PonerCeroVenta"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='indAlmacen'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				tipotraslado.indAlmacen = oReader["indAlmacen"] == DBNull.Value ? false : Convert.ToBoolean(oReader["indAlmacen"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='codSunatOpe'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                tipotraslado.codSunatOpe = oReader["codSunatOpe"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["codSunatOpe"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='indEstado'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				tipotraslado.indEstado = oReader["indEstado"] == DBNull.Value ? false : Convert.ToBoolean(oReader["indEstado"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='UsuarioRegistro'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				tipotraslado.UsuarioRegistro = oReader["UsuarioRegistro"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["UsuarioRegistro"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='FechaRegistro'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				tipotraslado.FechaRegistro = oReader["FechaRegistro"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["FechaRegistro"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='UsuarioModificacion'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				tipotraslado.UsuarioModificacion = oReader["UsuarioModificacion"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["UsuarioModificacion"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='FechaModificacion'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				tipotraslado.FechaModificacion = oReader["FechaModificacion"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["FechaModificacion"]);

            //Extensiones
            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='desCodSunatOpe'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                tipotraslado.desCodSunatOpe = oReader["desCodSunatOpe"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["desCodSunatOpe"]);

            return  tipotraslado;
        }

        public TipoTrasladoE InsertarTipoTraslado(TipoTrasladoE tipotraslado)
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_InsertarTipoTraslado", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@desTraslado", SqlDbType.VarChar, 100).Value = tipotraslado.desTraslado;
                    oComando.Parameters.Add("@codSunat", SqlDbType.VarChar, 3).Value = tipotraslado.codSunat;
                    oComando.Parameters.Add("@flagFact", SqlDbType.Bit).Value = tipotraslado.flagFact;
                    oComando.Parameters.Add("@flagCtaCte", SqlDbType.Bit).Value = tipotraslado.flagCtaCte;
                    oComando.Parameters.Add("@codFmtp", SqlDbType.Int).Value = tipotraslado.codFmtp;
                    oComando.Parameters.Add("@PonerCeroVenta", SqlDbType.Bit).Value = tipotraslado.PonerCeroVenta;
                    oComando.Parameters.Add("@indAlmacen", SqlDbType.Bit).Value = tipotraslado.indAlmacen;
                    oComando.Parameters.Add("@codSunatOpe", SqlDbType.VarChar, 3).Value = tipotraslado.codSunatOpe;
                    oComando.Parameters.Add("@UsuarioRegistro", SqlDbType.VarChar, 20).Value = tipotraslado.UsuarioRegistro;

                    oConexion.Open();
                    tipotraslado.idTraslado = Convert.ToInt32(oComando.ExecuteScalar());
                }
            }

            return tipotraslado;        
        }
        
        public TipoTrasladoE ActualizarTipoTraslado(TipoTrasladoE tipotraslado)
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ActualizarTipoTraslado", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idTraslado", SqlDbType.Int).Value = tipotraslado.idTraslado;
                    oComando.Parameters.Add("@desTraslado", SqlDbType.VarChar, 100).Value = tipotraslado.desTraslado;
                    oComando.Parameters.Add("@codSunat", SqlDbType.VarChar, 3).Value = tipotraslado.codSunat;
                    oComando.Parameters.Add("@flagFact", SqlDbType.Bit).Value = tipotraslado.flagFact;
                    oComando.Parameters.Add("@flagCtaCte", SqlDbType.Bit).Value = tipotraslado.flagCtaCte;
                    oComando.Parameters.Add("@codFmtp", SqlDbType.Int).Value = tipotraslado.codFmtp;
                    oComando.Parameters.Add("@PonerCeroVenta", SqlDbType.Bit).Value = tipotraslado.PonerCeroVenta;
                    oComando.Parameters.Add("@indAlmacen", SqlDbType.Bit).Value = tipotraslado.indAlmacen;
                    oComando.Parameters.Add("@codSunatOpe", SqlDbType.VarChar, 3).Value = tipotraslado.codSunatOpe;
                    oComando.Parameters.Add("@UsuarioModificacion", SqlDbType.VarChar, 20).Value = tipotraslado.UsuarioModificacion;

                    oConexion.Open();
                    oComando.ExecuteNonQuery();
                }
            }

            return tipotraslado;
        }

        public int AnularTipoTraslado(int idTraslado)
        {
            int resp = 0;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_AnularTipoTraslado", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idTraslado", SqlDbType.Int).Value = idTraslado;

                    oConexion.Open();
                    resp = oComando.ExecuteNonQuery();
                }
            }

            return resp;
        }

        public List<TipoTrasladoE> ListarTipoTraslado()
        {
            List<TipoTrasladoE> listaEntidad = new List<TipoTrasladoE>();

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ListarTipoTraslado", oConexion))
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
        
        public TipoTrasladoE ObtenerTipoTraslado(int idTraslado)
        {
            TipoTrasladoE tipotraslado = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ObtenerTipoTraslado", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idTraslado", SqlDbType.Int).Value = idTraslado;

                    oConexion.Open();
                    
                    using (SqlDataReader oReader = oComando.ExecuteReader())
                    {
                        while (oReader.Read())
                        {
                            tipotraslado = LlenarEntidad(oReader);
                        }
                    }
                }
            }

            return tipotraslado;        
        }

    }
}