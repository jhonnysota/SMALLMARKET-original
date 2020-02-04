using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

using Entidades.Tesoreria;
using AccesoDatos.Util;

namespace AccesoDatos.Tesoreria
{
    public class TipoLineaCreditoAD : DbConection
    {

        public TipoLineaCreditoE LlenarEntidad(IDataReader oReader)
        {
            TipoLineaCreditoE tipolineacredito = new TipoLineaCreditoE();
            
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idLinea'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				tipolineacredito.idLinea = oReader["idLinea"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idLinea"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Descripcion'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				tipolineacredito.Descripcion = oReader["Descripcion"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["Descripcion"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='desCorta'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                tipolineacredito.desCorta = oReader["desCorta"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["desCorta"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idDocumento'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                tipolineacredito.idDocumento = oReader["idDocumento"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["idDocumento"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='numVerPlanCuentas'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				tipolineacredito.numVerPlanCuentas = oReader["numVerPlanCuentas"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["numVerPlanCuentas"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='codCuenta'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				tipolineacredito.codCuenta = oReader["codCuenta"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["codCuenta"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idComprobante'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				tipolineacredito.idComprobante = oReader["idComprobante"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["idComprobante"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='numFile'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				tipolineacredito.numFile = oReader["numFile"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["numFile"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='fecBaja'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				tipolineacredito.fecBaja = oReader["fecBaja"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(oReader["fecBaja"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='indEstado'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				tipolineacredito.indEstado = oReader["indEstado"] == DBNull.Value ? true : Convert.ToBoolean(oReader["indEstado"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='UsuarioRegistro'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				tipolineacredito.UsuarioRegistro = oReader["UsuarioRegistro"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["UsuarioRegistro"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='FechaRegistro'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				tipolineacredito.FechaRegistro = oReader["FechaRegistro"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["FechaRegistro"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='UsuarioModificacion'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				tipolineacredito.UsuarioModificacion = oReader["UsuarioModificacion"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["UsuarioModificacion"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='FechaModificacion'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				tipolineacredito.FechaModificacion = oReader["FechaModificacion"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["FechaModificacion"]);

            //Extensiones
            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='desCuenta'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                tipolineacredito.desCuenta = oReader["desCuenta"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["desCuenta"]);

            return  tipolineacredito;        
        }

        public TipoLineaCreditoE InsertarTipoLineaCredito(TipoLineaCreditoE tipolineacredito)
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_InsertarTipoLineaCredito", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@Descripcion", SqlDbType.VarChar, 100).Value = tipolineacredito.Descripcion;
                    oComando.Parameters.Add("@desCorta", SqlDbType.VarChar, 5).Value = tipolineacredito.desCorta;
                    oComando.Parameters.Add("@idDocumento", SqlDbType.VarChar, 2).Value = tipolineacredito.idDocumento;
                    oComando.Parameters.Add("@numVerPlanCuentas", SqlDbType.VarChar, 3).Value = tipolineacredito.numVerPlanCuentas;
					oComando.Parameters.Add("@codCuenta", SqlDbType.VarChar, 20).Value = tipolineacredito.codCuenta;
					oComando.Parameters.Add("@idComprobante", SqlDbType.VarChar, 2).Value = tipolineacredito.idComprobante;
					oComando.Parameters.Add("@numFile", SqlDbType.VarChar, 2).Value = tipolineacredito.numFile;
					oComando.Parameters.Add("@UsuarioRegistro", SqlDbType.VarChar, 20).Value = tipolineacredito.UsuarioRegistro;

                    oConexion.Open();
                    tipolineacredito.idLinea = Int32.Parse(oComando.ExecuteScalar().ToString());
                }
            }

            return tipolineacredito;
        }
        
        public TipoLineaCreditoE ActualizarTipoLineaCredito(TipoLineaCreditoE tipolineacredito)
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ActualizarTipoLineaCredito", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idLinea", SqlDbType.Int).Value = tipolineacredito.idLinea;
					oComando.Parameters.Add("@Descripcion", SqlDbType.VarChar, 100).Value = tipolineacredito.Descripcion;
                    oComando.Parameters.Add("@desCorta", SqlDbType.VarChar, 5).Value = tipolineacredito.desCorta;
                    oComando.Parameters.Add("@idDocumento", SqlDbType.VarChar, 2).Value = tipolineacredito.idDocumento;
                    oComando.Parameters.Add("@numVerPlanCuentas", SqlDbType.VarChar, 3).Value = tipolineacredito.numVerPlanCuentas;
					oComando.Parameters.Add("@codCuenta", SqlDbType.VarChar, 20).Value = tipolineacredito.codCuenta;
					oComando.Parameters.Add("@idComprobante", SqlDbType.VarChar, 2).Value = tipolineacredito.idComprobante;
					oComando.Parameters.Add("@numFile", SqlDbType.VarChar, 2).Value = tipolineacredito.numFile;
					oComando.Parameters.Add("@UsuarioModificacion", SqlDbType.VarChar, 20).Value = tipolineacredito.UsuarioModificacion;

                    oConexion.Open();
                    oComando.ExecuteNonQuery();
                }
            }

            return tipolineacredito;
        }        

        public int AnularTipoLineaCredito(Int32 idLinea)
        {
            int resp = 0;
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_AnularTipoLineaCredito", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idLinea", SqlDbType.Int).Value = idLinea;

                    oConexion.Open();
                    resp = oComando.ExecuteNonQuery();
                }
            }

            return resp;
        }

        public List<TipoLineaCreditoE> ListarTipoLineaCredito(Boolean indEstado)
        {
           List<TipoLineaCreditoE> listaEntidad = new List<TipoLineaCreditoE>();
           TipoLineaCreditoE entidad = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ListarTipoLineaCredito", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@indEstado", SqlDbType.Bit).Value = indEstado;

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
        
        public TipoLineaCreditoE ObtenerTipoLineaCredito(Int32 idLinea, Int32 idEmpresa)
        {        
            TipoLineaCreditoE tipolineacredito = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ObtenerTipoLineaCredito", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idLinea", SqlDbType.Int).Value = idLinea;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;

                    oConexion.Open();
                    
                    using (SqlDataReader oReader = oComando.ExecuteReader())
                    {
                        while (oReader.Read())
                        {
                            tipolineacredito = LlenarEntidad(oReader);
                        }
                    }
                }
            }

            return tipolineacredito;
        }

    }
}