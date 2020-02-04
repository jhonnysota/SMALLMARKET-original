using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

using Entidades.CtasPorCobrar;
using AccesoDatos.Util;

namespace AccesoDatos.CtasPorCobrar
{
    public class TipoIngresosDetAD : DbConection
    {

        public TipoIngresosDetE LlenarEntidad(IDataReader oReader)
        {
            TipoIngresosDetE tipoingresosdet = new TipoIngresosDetE();
            
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idEmpresa'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				tipoingresosdet.idEmpresa = oReader["idEmpresa"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idEmpresa"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='TipoCobro'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				tipoingresosdet.TipoCobro = oReader["TipoCobro"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["TipoCobro"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='TipoPlanilla'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				tipoingresosdet.TipoPlanilla = oReader["TipoPlanilla"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["TipoPlanilla"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idComprobante'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				tipoingresosdet.idComprobante = oReader["idComprobante"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["idComprobante"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='numFile'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				tipoingresosdet.numFile = oReader["numFile"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["numFile"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='UsuarioRegistro'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				tipoingresosdet.UsuarioRegistro = oReader["UsuarioRegistro"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["UsuarioRegistro"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='FechaRegistro'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				tipoingresosdet.FechaRegistro = oReader["FechaRegistro"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["FechaRegistro"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='UsuarioModificacion'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				tipoingresosdet.UsuarioModificacion = oReader["UsuarioModificacion"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["UsuarioModificacion"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='FechaModificacion'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				tipoingresosdet.FechaModificacion = oReader["FechaModificacion"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["FechaModificacion"]);

            //Extensiones
            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='desTipoCobro'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                tipoingresosdet.desTipoCobro = oReader["desTipoCobro"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["desTipoCobro"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='desComprobante'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                tipoingresosdet.desComprobante = oReader["desComprobante"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["desComprobante"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='desTipoPlanilla'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                tipoingresosdet.desTipoPlanilla = oReader["desTipoPlanilla"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["desTipoPlanilla"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='desFile'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                tipoingresosdet.desFile = oReader["desFile"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["desFile"]);

            return  tipoingresosdet;
        }

        public TipoIngresosDetE InsertarTipoIngresosDet(TipoIngresosDetE tipoingresosdet)
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_InsertarTipoIngresosDet", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = tipoingresosdet.idEmpresa;
					oComando.Parameters.Add("@TipoCobro", SqlDbType.VarChar, 5).Value = tipoingresosdet.TipoCobro;
					oComando.Parameters.Add("@TipoPlanilla", SqlDbType.Int).Value = tipoingresosdet.TipoPlanilla;
					oComando.Parameters.Add("@idComprobante", SqlDbType.Char, 2).Value = tipoingresosdet.idComprobante;
					oComando.Parameters.Add("@numFile", SqlDbType.Char, 2).Value = tipoingresosdet.numFile;
					oComando.Parameters.Add("@UsuarioRegistro", SqlDbType.VarChar, 20).Value = tipoingresosdet.UsuarioRegistro;

                    oConexion.Open();
                    oComando.ExecuteNonQuery();
                }
            }

            return tipoingresosdet;
        }
        
        public TipoIngresosDetE ActualizarTipoIngresosDet(TipoIngresosDetE tipoingresosdet)
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ActualizarTipoIngresosDet", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = tipoingresosdet.idEmpresa;
					oComando.Parameters.Add("@TipoCobro", SqlDbType.VarChar, 5).Value = tipoingresosdet.TipoCobro;
					oComando.Parameters.Add("@TipoPlanilla", SqlDbType.Int).Value = tipoingresosdet.TipoPlanilla;
					oComando.Parameters.Add("@idComprobante", SqlDbType.Char, 2).Value = tipoingresosdet.idComprobante;
					oComando.Parameters.Add("@numFile", SqlDbType.Char, 2).Value = tipoingresosdet.numFile;
					oComando.Parameters.Add("@UsuarioModificacion", SqlDbType.VarChar, 20).Value = tipoingresosdet.UsuarioModificacion;

                    oConexion.Open();
                    oComando.ExecuteNonQuery();
                }
            }

            return tipoingresosdet;
        }        

        public int EliminarTipoIngresosDet(Int32 idEmpresa, String TipoCobro, Int32 TipoPlanilla)
        {
            int resp = 0;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_EliminarTipoIngresosDet", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
					oComando.Parameters.Add("@TipoCobro", SqlDbType.VarChar, 5).Value = TipoCobro;
					oComando.Parameters.Add("@TipoPlanilla", SqlDbType.Int).Value = TipoPlanilla;

                    oConexion.Open();
                    resp = oComando.ExecuteNonQuery();
                }
            }

            return resp;
        }

        public List<TipoIngresosDetE> ListarTipoIngresosDet(Int32 idEmpresa, String TipoCobro)
        {
            List<TipoIngresosDetE> listaEntidad = new List<TipoIngresosDetE>();

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ListarTipoIngresosDet", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@TipoCobro", SqlDbType.VarChar, 5).Value = TipoCobro;

                    oConexion.Open();
                    
                    using (SqlDataReader oReader = oComando.ExecuteReader())
                    {
                        while (oReader.Read())
                        {
                            listaEntidad.Add(LlenarEntidad(oReader));
                        }
                    }
                }

                oConexion.Close();
            }

            return listaEntidad;
        }
        
        public TipoIngresosDetE ObtenerTipoIngresosDet(Int32 idEmpresa, String TipoCobro, Int32 TipoPlanilla)
        {        
            TipoIngresosDetE tipoingresosdet = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ObtenerTipoIngresosDet", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
					oComando.Parameters.Add("@TipoCobro", SqlDbType.VarChar, 5).Value = TipoCobro;
					oComando.Parameters.Add("@TipoPlanilla", SqlDbType.Int).Value = TipoPlanilla;

                    oConexion.Open();
                    
                    using (SqlDataReader oReader = oComando.ExecuteReader())
                    {
                        while (oReader.Read())
                        {
                            tipoingresosdet = LlenarEntidad(oReader);
                        }
                    }
                }
            }

            return tipoingresosdet;
        }

        public TipoIngresosDetE ObtenerTipoIngresosDetPorPlanilla(Int32 idEmpresa, Int32 TipoPlanilla)
        {
            TipoIngresosDetE tipoingresosdet = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ObtenerTipoIngresosDetPorPlanilla", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@TipoPlanilla", SqlDbType.Int).Value = TipoPlanilla;

                    oConexion.Open();

                    using (SqlDataReader oReader = oComando.ExecuteReader())
                    {
                        while (oReader.Read())
                        {
                            tipoingresosdet = LlenarEntidad(oReader);
                        }
                    }
                }
            }

            return tipoingresosdet;
        }

    }
}