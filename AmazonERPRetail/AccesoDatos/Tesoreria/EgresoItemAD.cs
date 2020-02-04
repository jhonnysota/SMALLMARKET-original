using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

using Entidades.Tesoreria;
using AccesoDatos.Util;

namespace AccesoDatos.Tesoreria
{
    public class EgresoItemAD : DbConection
    {

        public EgresoItemE LlenarEntidad(IDataReader oReader)
        {
            EgresoItemE egresoitem = new EgresoItemE();
            
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idEmpresa'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				egresoitem.idEmpresa = oReader["idEmpresa"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idEmpresa"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idLocal'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				egresoitem.idLocal = oReader["idLocal"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idLocal"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idNumEgreso'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				egresoitem.idNumEgreso = oReader["idNumEgreso"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idNumEgreso"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='NumItem'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				egresoitem.NumItem = oReader["NumItem"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["NumItem"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idPersona'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				egresoitem.idPersona = oReader["idPersona"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idPersona"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idDocumento'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				egresoitem.idDocumento = oReader["idDocumento"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["idDocumento"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idMoneda'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				egresoitem.idMoneda = oReader["idMoneda"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["idMoneda"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='serDocumento'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				egresoitem.serDocumento = oReader["serDocumento"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["serDocumento"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='numDocumento'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				egresoitem.numDocumento = oReader["numDocumento"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["numDocumento"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='indDebeHaber'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				egresoitem.indDebeHaber = oReader["indDebeHaber"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["indDebeHaber"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='impMontoPago'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				egresoitem.impMontoPago = oReader["impMontoPago"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["impMontoPago"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='numVerPlanCuentas'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				egresoitem.numVerPlanCuentas = oReader["numVerPlanCuentas"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["numVerPlanCuentas"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='impPagoBase'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				egresoitem.impPagoBase = oReader["impPagoBase"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["impPagoBase"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='impPagoSecun'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				egresoitem.impPagoSecun = oReader["impPagoSecun"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["impPagoSecun"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='codCuenta'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				egresoitem.codCuenta = oReader["codCuenta"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["codCuenta"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='tipEstado'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				egresoitem.tipEstado = oReader["tipEstado"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["tipEstado"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='tipCambio'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				egresoitem.tipCambio = oReader["tipCambio"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["tipCambio"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idSistema'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				egresoitem.idSistema = oReader["idSistema"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["idSistema"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='fecDocumento'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				egresoitem.fecDocumento = oReader["fecDocumento"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["fecDocumento"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='fecVencimiento'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				egresoitem.fecVencimiento = oReader["fecVencimiento"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["fecVencimiento"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='desGlosa'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				egresoitem.desGlosa = oReader["desGlosa"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["desGlosa"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idCtaCte'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                egresoitem.idCtaCte = oReader["idCtaCte"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idCtaCte"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idCtaCteItem'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                egresoitem.idCtaCteItem = oReader["idCtaCteItem"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idCtaCteItem"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='UsuarioRegistro'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				egresoitem.UsuarioRegistro = oReader["UsuarioRegistro"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["UsuarioRegistro"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='FechaRegistro'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				egresoitem.FechaRegistro = oReader["FechaRegistro"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["FechaRegistro"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='UsuarioModificacion'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				egresoitem.UsuarioModificacion = oReader["UsuarioModificacion"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["UsuarioModificacion"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='FechaModificacion'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				egresoitem.FechaModificacion = oReader["FechaModificacion"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["FechaModificacion"]);

            return  egresoitem;        
        }

        public EgresoItemE InsertarEgresoItem(EgresoItemE egresoitem)
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_InsertarEgresoItem", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = egresoitem.idEmpresa;
					oComando.Parameters.Add("@idLocal", SqlDbType.Int).Value = egresoitem.idLocal;
					oComando.Parameters.Add("@idNumEgreso", SqlDbType.Int).Value = egresoitem.idNumEgreso;
					oComando.Parameters.Add("@NumItem", SqlDbType.Int).Value = egresoitem.NumItem;
					oComando.Parameters.Add("@idPersona", SqlDbType.Int).Value = egresoitem.idPersona;
					oComando.Parameters.Add("@idDocumento", SqlDbType.VarChar, 2).Value = egresoitem.idDocumento;
					oComando.Parameters.Add("@idMoneda", SqlDbType.Char, 2).Value = egresoitem.idMoneda;
					oComando.Parameters.Add("@serDocumento", SqlDbType.VarChar, 20).Value = egresoitem.serDocumento;
					oComando.Parameters.Add("@numDocumento", SqlDbType.VarChar, 20).Value = egresoitem.numDocumento;
					oComando.Parameters.Add("@indDebeHaber", SqlDbType.Char, 1).Value = egresoitem.indDebeHaber;
					oComando.Parameters.Add("@impMontoPago", SqlDbType.Decimal).Value = egresoitem.impMontoPago;
					oComando.Parameters.Add("@numVerPlanCuentas", SqlDbType.VarChar, 3).Value = egresoitem.numVerPlanCuentas;
					oComando.Parameters.Add("@impPagoBase", SqlDbType.Decimal).Value = egresoitem.impPagoBase;
					oComando.Parameters.Add("@impPagoSecun", SqlDbType.Decimal).Value = egresoitem.impPagoSecun;
					oComando.Parameters.Add("@codCuenta", SqlDbType.VarChar, 20).Value = egresoitem.codCuenta;
					oComando.Parameters.Add("@tipEstado", SqlDbType.VarChar, 2).Value = egresoitem.tipEstado;
					oComando.Parameters.Add("@tipCambio", SqlDbType.Decimal).Value = egresoitem.tipCambio;
					oComando.Parameters.Add("@idSistema", SqlDbType.VarChar, 5).Value = egresoitem.idSistema;
					oComando.Parameters.Add("@fecDocumento", SqlDbType.SmallDateTime).Value = egresoitem.fecDocumento;
					oComando.Parameters.Add("@fecVencimiento", SqlDbType.DateTime).Value = egresoitem.fecVencimiento;
					oComando.Parameters.Add("@desGlosa", SqlDbType.VarChar, 200).Value = egresoitem.desGlosa;
					oComando.Parameters.Add("@UsuarioRegistro", SqlDbType.VarChar, 20).Value = egresoitem.UsuarioRegistro;

                    oConexion.Open();
                    oComando.ExecuteNonQuery();
                }
            }

            return egresoitem;
        }
        
        public EgresoItemE ActualizarEgresoItem(EgresoItemE egresoitem)
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ActualizarEgresoItem", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = egresoitem.idEmpresa;
					oComando.Parameters.Add("@idLocal", SqlDbType.Int).Value = egresoitem.idLocal;
					oComando.Parameters.Add("@idNumEgreso", SqlDbType.Int).Value = egresoitem.idNumEgreso;
					oComando.Parameters.Add("@NumItem", SqlDbType.Int).Value = egresoitem.NumItem;
					oComando.Parameters.Add("@idPersona", SqlDbType.Int).Value = egresoitem.idPersona;
					oComando.Parameters.Add("@idDocumento", SqlDbType.VarChar, 2).Value = egresoitem.idDocumento;
					oComando.Parameters.Add("@idMoneda", SqlDbType.Char, 2).Value = egresoitem.idMoneda;
					oComando.Parameters.Add("@serDocumento", SqlDbType.VarChar, 20).Value = egresoitem.serDocumento;
					oComando.Parameters.Add("@numDocumento", SqlDbType.VarChar, 20).Value = egresoitem.numDocumento;
					oComando.Parameters.Add("@indDebeHaber", SqlDbType.Char, 1).Value = egresoitem.indDebeHaber;
					oComando.Parameters.Add("@impMontoPago", SqlDbType.Decimal).Value = egresoitem.impMontoPago;
					oComando.Parameters.Add("@numVerPlanCuentas", SqlDbType.VarChar, 3).Value = egresoitem.numVerPlanCuentas;
					oComando.Parameters.Add("@impPagoBase", SqlDbType.Decimal).Value = egresoitem.impPagoBase;
					oComando.Parameters.Add("@impPagoSecun", SqlDbType.Decimal).Value = egresoitem.impPagoSecun;
					oComando.Parameters.Add("@codCuenta", SqlDbType.VarChar, 20).Value = egresoitem.codCuenta;
					oComando.Parameters.Add("@tipEstado", SqlDbType.VarChar, 2).Value = egresoitem.tipEstado;
					oComando.Parameters.Add("@tipCambio", SqlDbType.Decimal).Value = egresoitem.tipCambio;
					oComando.Parameters.Add("@idSistema", SqlDbType.VarChar, 5).Value = egresoitem.idSistema;
					oComando.Parameters.Add("@fecDocumento", SqlDbType.SmallDateTime).Value = egresoitem.fecDocumento;
					oComando.Parameters.Add("@fecVencimiento", SqlDbType.DateTime).Value = egresoitem.fecVencimiento;
					oComando.Parameters.Add("@desGlosa", SqlDbType.VarChar, 200).Value = egresoitem.desGlosa;
					oComando.Parameters.Add("@UsuarioModificacion", SqlDbType.VarChar, 20).Value = egresoitem.UsuarioModificacion;

                    oConexion.Open();
                    oComando.ExecuteNonQuery();
                }
            }

            return egresoitem;
        }        

        public Int32 EliminarEgresoItem(Int32 idEmpresa, Int32 idLocal, Int32 idNumEgreso, Int32 NumItem)
        {
            Int32 resp = 0;
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_EliminarEgresoItem", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
					oComando.Parameters.Add("@idLocal", SqlDbType.Int).Value = idLocal;
					oComando.Parameters.Add("@idNumEgreso", SqlDbType.Int).Value = idNumEgreso;
					oComando.Parameters.Add("@NumItem", SqlDbType.Int).Value = NumItem;

                    oConexion.Open();
                    resp = oComando.ExecuteNonQuery();
                }
            }

            return resp;
        }

        public List<EgresoItemE> ListarEgresoItem()
        {
            List<EgresoItemE> listaEntidad = new List<EgresoItemE>();
            EgresoItemE entidad = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ListarEgresoItem", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
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
        
        public EgresoItemE ObtenerEgresoItem(Int32 idEmpresa, Int32 idLocal, Int32 idNumEgreso, Int32 NumItem)
        {        
            EgresoItemE egresoitem = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ObtenerEgresoItem", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
					oComando.Parameters.Add("@idLocal", SqlDbType.Int).Value = idLocal;
					oComando.Parameters.Add("@idNumEgreso", SqlDbType.Int).Value = idNumEgreso;
					oComando.Parameters.Add("@NumItem", SqlDbType.Int).Value = NumItem;

                    oConexion.Open();
                    
                    using (SqlDataReader oReader = oComando.ExecuteReader())
                    {
                        while (oReader.Read())
                        {
                            egresoitem = LlenarEntidad(oReader);
                        }
                    }
                }
            }

            return egresoitem;
        }

        public List<EgresoItemE> ListarEgresoItemPorIdNumEgreso(Int32 idEmpresa, Int32 idLocal, Int32 idNumEgreso)
        {
            List<EgresoItemE> listaEntidad = new List<EgresoItemE>();
            EgresoItemE entidad = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ListarEgresoItemPorIdNumEgreso", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@idLocal", SqlDbType.Int).Value = idLocal;
                    oComando.Parameters.Add("@idNumEgreso", SqlDbType.Int).Value = idNumEgreso;

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

    }
}