using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

using Entidades.Tesoreria;
using AccesoDatos.Util;

namespace AccesoDatos.Tesoreria
{
    public class TipoPagoDetAD : DbConection
    {

        public TipoPagoDetE LlenarEntidad(IDataReader oReader)
        {
            TipoPagoDetE tipopagodet = new TipoPagoDetE();
            
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idEmpresa'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				tipopagodet.idEmpresa = oReader["idEmpresa"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idEmpresa"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='codTipoPago'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				tipopagodet.codTipoPago = oReader["codTipoPago"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["codTipoPago"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idConcepto'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				tipopagodet.idConcepto = oReader["idConcepto"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idConcepto"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='UsuarioRegistro'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				tipopagodet.UsuarioRegistro = oReader["UsuarioRegistro"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["UsuarioRegistro"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='FechaRegistro'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				tipopagodet.FechaRegistro = oReader["FechaRegistro"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["FechaRegistro"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='UsuarioModificacion'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				tipopagodet.UsuarioModificacion = oReader["UsuarioModificacion"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["UsuarioModificacion"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='FechaModificacion'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				tipopagodet.FechaModificacion = oReader["FechaModificacion"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["FechaModificacion"]);

            //Extensiones
            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='codConcepto'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                tipopagodet.codConcepto = oReader["codConcepto"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["codConcepto"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='desConcepto'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                tipopagodet.desConcepto = oReader["desConcepto"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["desConcepto"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='numVerPlanCuentas'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                tipopagodet.numVerPlanCuentas = oReader["numVerPlanCuentas"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["numVerPlanCuentas"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='codCuenta'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                tipopagodet.codCuenta = oReader["codCuenta"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["codCuenta"]);

            return  tipopagodet;        
        }

        public TipoPagoDetE InsertarTipoPagoDet(TipoPagoDetE tipopagodet)
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_InsertarTipoPagoDet", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = tipopagodet.idEmpresa;
					oComando.Parameters.Add("@codTipoPago", SqlDbType.VarChar, 3).Value = tipopagodet.codTipoPago;
					oComando.Parameters.Add("@idConcepto", SqlDbType.Int).Value = tipopagodet.idConcepto;
					oComando.Parameters.Add("@UsuarioRegistro", SqlDbType.VarChar, 20).Value = tipopagodet.UsuarioRegistro;

                    oConexion.Open();
                    oComando.ExecuteNonQuery();
                }
            }

            return tipopagodet;
        }
        
        public TipoPagoDetE ActualizarTipoPagoDet(TipoPagoDetE tipopagodet)
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ActualizarTipoPagoDet", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = tipopagodet.idEmpresa;
					oComando.Parameters.Add("@codTipoPago", SqlDbType.VarChar, 3).Value = tipopagodet.codTipoPago;
					oComando.Parameters.Add("@idConcepto", SqlDbType.Int).Value = tipopagodet.idConcepto;
					oComando.Parameters.Add("@UsuarioModificacion", SqlDbType.VarChar, 20).Value = tipopagodet.UsuarioModificacion;

                    oConexion.Open();
                    oComando.ExecuteNonQuery();
                }
            }

            return tipopagodet;
        }        

        public int EliminarTipoPagoDet(Int32 idEmpresa, String codTipoPago)
        {
            int resp = 0;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_EliminarTipoPagoDet", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
					oComando.Parameters.Add("@codTipoPago", SqlDbType.VarChar, 3).Value = codTipoPago;

                    oConexion.Open();
                    resp = oComando.ExecuteNonQuery();
                }
            }

            return resp;
        }

        public List<TipoPagoDetE> ListarTipoPagoDet(Int32 idEmpresa, String codTipoPago)
        {
            List<TipoPagoDetE> listaEntidad = new List<TipoPagoDetE>();

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ListarTipoPagoDet", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@codTipoPago", SqlDbType.VarChar, 3).Value = codTipoPago;

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
        
        public TipoPagoDetE ObtenerTipoPagoDet(Int32 idEmpresa, String codTipoPago, Int32 idConcepto)
        {        
            TipoPagoDetE tipopagodet = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ObtenerTipoPagoDet", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
					oComando.Parameters.Add("@codTipoPago", SqlDbType.VarChar, 3).Value = codTipoPago;
					oComando.Parameters.Add("@idConcepto", SqlDbType.Int).Value = idConcepto;

                    oConexion.Open();
                    
                    using (SqlDataReader oReader = oComando.ExecuteReader())
                    {
                        while (oReader.Read())
                        {
                            tipopagodet = LlenarEntidad(oReader);
                        }
                    }
                }
            }

            return tipopagodet;
        }

        public List<TipoPagoDetE> ListarTipoPagoDetIndSolProv(Int32 idEmpresa)
        {
            List<TipoPagoDetE> listaEntidad = new List<TipoPagoDetE>();

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ListarTipoPagoDetIndSolProv", oConexion))
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

        public TipoPagoDetE TipoPagoDetPorConcepto(Int32 idEmpresa, Int32 idConcepto)
        {
            TipoPagoDetE tipopagodet = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_TipoPagoDetPorConcepto", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@idConcepto", SqlDbType.Int).Value = idConcepto;

                    oConexion.Open();

                    using (SqlDataReader oReader = oComando.ExecuteReader())
                    {
                        while (oReader.Read())
                        {
                            tipopagodet = LlenarEntidad(oReader);
                        }
                    }
                }
            }

            return tipopagodet;
        }

    }
}