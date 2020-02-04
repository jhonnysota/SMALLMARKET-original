using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

using Entidades.CtasPorPagar;
using AccesoDatos.Util;

namespace AccesoDatos.CtasPorPagar
{
    public class CanjeDctoItemAD : DbConection
    {

        public CanjeDctoItemE LlenarEntidad(IDataReader oReader)
        {
            CanjeDctoItemE canjedctoitem = new CanjeDctoItemE();
            
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idEmpresa'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				canjedctoitem.idEmpresa = oReader["idEmpresa"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idEmpresa"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idLocal'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				canjedctoitem.idLocal = oReader["idLocal"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idLocal"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idCanje'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				canjedctoitem.idCanje = oReader["idCanje"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idCanje"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idItemDcmto'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				canjedctoitem.idItemDcmto = oReader["idItemDcmto"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idItemDcmto"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idPersona'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				canjedctoitem.idPersona = oReader["idPersona"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idPersona"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='numVerPlanCuentas'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				canjedctoitem.numVerPlanCuentas = oReader["numVerPlanCuentas"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["numVerPlanCuentas"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='codCuenta'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				canjedctoitem.codCuenta = oReader["codCuenta"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["codCuenta"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idDocumento'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				canjedctoitem.idDocumento = oReader["idDocumento"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["idDocumento"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='serDocumento'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				canjedctoitem.serDocumento = oReader["serDocumento"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["serDocumento"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='numDocumento'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				canjedctoitem.numDocumento = oReader["numDocumento"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["numDocumento"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='FechaDocumento'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				canjedctoitem.FechaDocumento = oReader["FechaDocumento"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["FechaDocumento"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='FechaVencimiento'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				canjedctoitem.FechaVencimiento = oReader["FechaVencimiento"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(oReader["FechaVencimiento"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idMonedaOrigen'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				canjedctoitem.idMonedaOrigen = oReader["idMonedaOrigen"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["idMonedaOrigen"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='MontoOrigen'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				canjedctoitem.MontoOrigen = oReader["MontoOrigen"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["MontoOrigen"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='TipoCambio'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				canjedctoitem.TipoCambio = oReader["TipoCambio"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["TipoCambio"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='indDebeHaber'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				canjedctoitem.indDebeHaber = oReader["indDebeHaber"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["indDebeHaber"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='PorRetencion'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				canjedctoitem.PorRetencion = oReader["PorRetencion"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["PorRetencion"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='MontoReteSoles'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				canjedctoitem.MontoReteSoles = oReader["MontoReteSoles"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["MontoReteSoles"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='MontoReteDolares'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				canjedctoitem.MontoReteDolares = oReader["MontoReteDolares"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["MontoReteDolares"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='MontoSoles'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                canjedctoitem.MontoSoles = oReader["MontoSoles"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["MontoSoles"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='MontoDolares'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                canjedctoitem.MontoDolares = oReader["MontoDolares"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["MontoDolares"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idCtaCte'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                canjedctoitem.idCtaCte = oReader["idCtaCte"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idCtaCte"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idCtaCteItem'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                canjedctoitem.idCtaCteItem = oReader["idCtaCteItem"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idCtaCteItem"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='UsuarioRegistro'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				canjedctoitem.UsuarioRegistro = oReader["UsuarioRegistro"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["UsuarioRegistro"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='FechaRegistro'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				canjedctoitem.FechaRegistro = oReader["FechaRegistro"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["FechaRegistro"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='UsuarioModificacion'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				canjedctoitem.UsuarioModificacion = oReader["UsuarioModificacion"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["UsuarioModificacion"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='FechaModificacion'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				canjedctoitem.FechaModificacion = oReader["FechaModificacion"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["FechaModificacion"]);

            //Extensiones
            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Documento'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                canjedctoitem.Documento = oReader["Documento"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["Documento"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='desMoneda'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                canjedctoitem.desMoneda = oReader["desMoneda"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["desMoneda"]);

            return  canjedctoitem;        
        }

        public CanjeDctoItemE InsertarCanjeDctoItem(CanjeDctoItemE canjedctoitem)
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_InsertarCanjeDctoItem", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = canjedctoitem.idEmpresa;
					oComando.Parameters.Add("@idLocal", SqlDbType.Int).Value = canjedctoitem.idLocal;
					oComando.Parameters.Add("@idCanje", SqlDbType.Int).Value = canjedctoitem.idCanje;
					oComando.Parameters.Add("@idPersona", SqlDbType.Int).Value = canjedctoitem.idPersona;
					oComando.Parameters.Add("@numVerPlanCuentas", SqlDbType.VarChar, 3).Value = canjedctoitem.numVerPlanCuentas;
					oComando.Parameters.Add("@codCuenta", SqlDbType.VarChar, 20).Value = canjedctoitem.codCuenta;
					oComando.Parameters.Add("@idDocumento", SqlDbType.VarChar, 2).Value = canjedctoitem.idDocumento;
					oComando.Parameters.Add("@serDocumento", SqlDbType.VarChar, 20).Value = canjedctoitem.serDocumento;
					oComando.Parameters.Add("@numDocumento", SqlDbType.VarChar, 20).Value = canjedctoitem.numDocumento;
					oComando.Parameters.Add("@FechaDocumento", SqlDbType.SmallDateTime).Value = canjedctoitem.FechaDocumento;
					oComando.Parameters.Add("@FechaVencimiento", SqlDbType.SmallDateTime).Value = canjedctoitem.FechaVencimiento;
					oComando.Parameters.Add("@idMonedaOrigen", SqlDbType.VarChar, 2).Value = canjedctoitem.idMonedaOrigen;
					oComando.Parameters.Add("@MontoOrigen", SqlDbType.Decimal).Value = canjedctoitem.MontoOrigen;
					oComando.Parameters.Add("@TipoCambio", SqlDbType.Decimal).Value = canjedctoitem.TipoCambio;
                    oComando.Parameters.Add("@MontoSoles", SqlDbType.Decimal).Value = canjedctoitem.MontoSoles;
                    oComando.Parameters.Add("@MontoDolares", SqlDbType.Decimal).Value = canjedctoitem.MontoDolares;
                    oComando.Parameters.Add("@indDebeHaber", SqlDbType.VarChar, 2).Value = canjedctoitem.indDebeHaber;
                    oComando.Parameters.Add("@PorRetencion", SqlDbType.Decimal).Value = canjedctoitem.PorRetencion;
					oComando.Parameters.Add("@MontoReteSoles", SqlDbType.Decimal).Value = canjedctoitem.MontoReteSoles;
					oComando.Parameters.Add("@MontoReteDolares", SqlDbType.Decimal).Value = canjedctoitem.MontoReteDolares;
                    oComando.Parameters.Add("@UsuarioRegistro", SqlDbType.VarChar, 20).Value = canjedctoitem.UsuarioRegistro;

                    oConexion.Open();
                    canjedctoitem.idItemDcmto = Int32.Parse(oComando.ExecuteScalar().ToString());
                }
            }

            return canjedctoitem;
        }
        
        public CanjeDctoItemE ActualizarCanjeDctoItem(CanjeDctoItemE canjedctoitem)
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ActualizarCanjeDctoItem", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = canjedctoitem.idEmpresa;
					oComando.Parameters.Add("@idLocal", SqlDbType.Int).Value = canjedctoitem.idLocal;
					oComando.Parameters.Add("@idCanje", SqlDbType.Int).Value = canjedctoitem.idCanje;
					oComando.Parameters.Add("@idItemDcmto", SqlDbType.Int).Value = canjedctoitem.idItemDcmto;
					oComando.Parameters.Add("@idPersona", SqlDbType.Int).Value = canjedctoitem.idPersona;
					oComando.Parameters.Add("@numVerPlanCuentas", SqlDbType.VarChar, 3).Value = canjedctoitem.numVerPlanCuentas;
					oComando.Parameters.Add("@codCuenta", SqlDbType.VarChar, 20).Value = canjedctoitem.codCuenta;
					oComando.Parameters.Add("@idDocumento", SqlDbType.VarChar, 2).Value = canjedctoitem.idDocumento;
					oComando.Parameters.Add("@serDocumento", SqlDbType.VarChar, 20).Value = canjedctoitem.serDocumento;
					oComando.Parameters.Add("@numDocumento", SqlDbType.VarChar, 20).Value = canjedctoitem.numDocumento;
					oComando.Parameters.Add("@FechaDocumento", SqlDbType.SmallDateTime).Value = canjedctoitem.FechaDocumento;
					oComando.Parameters.Add("@FechaVencimiento", SqlDbType.SmallDateTime).Value = canjedctoitem.FechaVencimiento;
					oComando.Parameters.Add("@idMonedaOrigen", SqlDbType.VarChar, 2).Value = canjedctoitem.idMonedaOrigen;
					oComando.Parameters.Add("@MontoOrigen", SqlDbType.Decimal).Value = canjedctoitem.MontoOrigen;
					oComando.Parameters.Add("@TipoCambio", SqlDbType.Decimal).Value = canjedctoitem.TipoCambio;
                    oComando.Parameters.Add("@MontoSoles", SqlDbType.Decimal).Value = canjedctoitem.MontoSoles;
                    oComando.Parameters.Add("@MontoDolares", SqlDbType.Decimal).Value = canjedctoitem.MontoDolares;
                    oComando.Parameters.Add("@indDebeHaber", SqlDbType.VarChar, 2).Value = canjedctoitem.indDebeHaber;
                    oComando.Parameters.Add("@PorRetencion", SqlDbType.Decimal).Value = canjedctoitem.PorRetencion;
					oComando.Parameters.Add("@MontoReteSoles", SqlDbType.Decimal).Value = canjedctoitem.MontoReteSoles;
					oComando.Parameters.Add("@MontoReteDolares", SqlDbType.Decimal).Value = canjedctoitem.MontoReteDolares;
                    oComando.Parameters.Add("@UsuarioModificacion", SqlDbType.VarChar, 20).Value = canjedctoitem.UsuarioModificacion;

                    oConexion.Open();
                    oComando.ExecuteNonQuery();
                }
            }

            return canjedctoitem;
        }        

        public int EliminarCanjeDctoItem(Int32 idCanje, Int32 idItemDcmto)
        {
            int resp = 0;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_EliminarCanjeDctoItem", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
					oComando.Parameters.Add("@idCanje", SqlDbType.Int).Value = idCanje;
                    oComando.Parameters.Add("@idItemDcmto", SqlDbType.Int).Value = idItemDcmto;

                    oConexion.Open();
                    resp = oComando.ExecuteNonQuery();
                }
            }

            return resp;
        }

        public List<CanjeDctoItemE> ListarCanjeDctoItem(Int32 idCanje)
        {
            List<CanjeDctoItemE> listaEntidad = new List<CanjeDctoItemE>();

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ListarCanjeDctoItem", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idCanje", SqlDbType.Int).Value = idCanje;

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
        
        public CanjeDctoItemE ObtenerCanjeDctoItem(Int32 idEmpresa, Int32 idLocal, Int32 idCanje, Int32 idItemDcmto)
        {        
            CanjeDctoItemE canjedctoitem = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ObtenerCanjeDctoItem", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
					oComando.Parameters.Add("@idLocal", SqlDbType.Int).Value = idLocal;
					oComando.Parameters.Add("@idCanje", SqlDbType.Int).Value = idCanje;
					oComando.Parameters.Add("@idItemDcmto", SqlDbType.Int).Value = idItemDcmto;

                    oConexion.Open();
                    
                    using (SqlDataReader oReader = oComando.ExecuteReader())
                    {
                        while (oReader.Read())
                        {
                            canjedctoitem = LlenarEntidad(oReader);
                        }
                    }
                }
            }

            return canjedctoitem;
        }

        public CanjeDctoItemE ActualizarCanjeDctoItemCtaCte(CanjeDctoItemE canjedctoitem)
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ActualizarCanjeDctoItemCtaCte", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idCanje", SqlDbType.Int).Value = canjedctoitem.idCanje;
                    oComando.Parameters.Add("@idItemDcmto", SqlDbType.Int).Value = canjedctoitem.idItemDcmto;
                    oComando.Parameters.Add("@idCtaCte", SqlDbType.Int).Value = canjedctoitem.idCtaCte;
                    oComando.Parameters.Add("@idCtaCteItem", SqlDbType.Int).Value = canjedctoitem.idCtaCteItem;
                    oComando.Parameters.Add("@UsuarioModificacion", SqlDbType.VarChar, 20).Value = canjedctoitem.UsuarioModificacion;

                    oConexion.Open();
                    oComando.ExecuteNonQuery();
                }
            }

            return canjedctoitem;
        }

    }
}