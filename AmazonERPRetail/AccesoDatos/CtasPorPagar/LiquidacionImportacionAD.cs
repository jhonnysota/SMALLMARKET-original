using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

using Entidades.CtasPorPagar;
using AccesoDatos.Util;

namespace AccesoDatos.CtasPorPagar
{
    public class LiquidacionImportacionAD : DbConection
    {

        public LiquidacionImportacionE LlenarEntidad(IDataReader oReader)
        {
            LiquidacionImportacionE liquidacionimportacion = new LiquidacionImportacionE();
            
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idLiquidacion'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				liquidacionimportacion.idLiquidacion = oReader["idLiquidacion"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idLiquidacion"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='codLiquidacion'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                liquidacionimportacion.codLiquidacion = oReader["codLiquidacion"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["codLiquidacion"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idEmpresa'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				liquidacionimportacion.idEmpresa = oReader["idEmpresa"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idEmpresa"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idLocal'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				liquidacionimportacion.idLocal = oReader["idLocal"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idLocal"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idPersona'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				liquidacionimportacion.idPersona = oReader["idPersona"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idPersona"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Fecha'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				liquidacionimportacion.Fecha = oReader["Fecha"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["Fecha"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idDocumento'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                liquidacionimportacion.idDocumento = oReader["idDocumento"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["idDocumento"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='numSerie'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                liquidacionimportacion.numSerie = oReader["numSerie"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["numSerie"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='numDocumento'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                liquidacionimportacion.numDocumento = oReader["numDocumento"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["numDocumento"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idMoneda'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				liquidacionimportacion.idMoneda = oReader["idMoneda"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["idMoneda"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Importe'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				liquidacionimportacion.Importe = oReader["Importe"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["Importe"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='TiCa'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				liquidacionimportacion.TiCa = oReader["TiCa"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["TiCa"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='numVerPlanCuentas'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				liquidacionimportacion.numVerPlanCuentas = oReader["numVerPlanCuentas"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["numVerPlanCuentas"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='codCuenta'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				liquidacionimportacion.codCuenta = oReader["codCuenta"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["codCuenta"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='AnioPeriodo'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				liquidacionimportacion.AnioPeriodo = oReader["AnioPeriodo"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["AnioPeriodo"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='MesPeriodo'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				liquidacionimportacion.MesPeriodo = oReader["MesPeriodo"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["MesPeriodo"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idComprobante'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				liquidacionimportacion.idComprobante = oReader["idComprobante"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["idComprobante"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='numFile'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				liquidacionimportacion.numFile = oReader["numFile"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["numFile"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='numVoucher'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				liquidacionimportacion.numVoucher = oReader["numVoucher"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["numVoucher"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Glosa'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				liquidacionimportacion.Glosa = oReader["Glosa"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["Glosa"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idCtaCte'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				liquidacionimportacion.idCtaCte = oReader["idCtaCte"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idCtaCte"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idCtaCteItem'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				liquidacionimportacion.idCtaCteItem = oReader["idCtaCteItem"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idCtaCteItem"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Estado'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				liquidacionimportacion.Estado = oReader["Estado"] == DBNull.Value ? false : Convert.ToBoolean(oReader["Estado"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='UsuarioRegistro'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				liquidacionimportacion.UsuarioRegistro = oReader["UsuarioRegistro"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["UsuarioRegistro"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='FechaRegistro'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				liquidacionimportacion.FechaRegistro = oReader["FechaRegistro"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["FechaRegistro"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='UsuarioModificacion'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				liquidacionimportacion.UsuarioModificacion = oReader["UsuarioModificacion"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["UsuarioModificacion"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='FechaModificacion'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				liquidacionimportacion.FechaModificacion = oReader["FechaModificacion"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["FechaModificacion"]);

            //Extensiones
            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='desCuenta'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                liquidacionimportacion.desCuenta = oReader["desCuenta"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["desCuenta"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='desComprobante'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                liquidacionimportacion.desComprobante = oReader["desComprobante"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["desComprobante"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='desFile'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                liquidacionimportacion.desFile = oReader["desFile"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["desFile"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='desEstado'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                liquidacionimportacion.desEstado = oReader["desEstado"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["desEstado"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='RUC'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                liquidacionimportacion.RUC = oReader["RUC"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["RUC"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='RazonSocial'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                liquidacionimportacion.RazonSocial = oReader["RazonSocial"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["RazonSocial"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Fecha'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                liquidacionimportacion.FechaTmp = oReader["Fecha"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["Fecha"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='desMoneda'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                liquidacionimportacion.desMoneda = oReader["desMoneda"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["desMoneda"]);

            return  liquidacionimportacion;
        }

        public LiquidacionImportacionE InsertarLiquidacionImportacion(LiquidacionImportacionE liquidacionimportacion)
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_InsertarLiquidacionImportacion", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@codLiquidacion", SqlDbType.VarChar, 14).Value = liquidacionimportacion.codLiquidacion;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = liquidacionimportacion.idEmpresa;
					oComando.Parameters.Add("@idLocal", SqlDbType.Int).Value = liquidacionimportacion.idLocal;
					oComando.Parameters.Add("@idPersona", SqlDbType.Int).Value = liquidacionimportacion.idPersona;
					oComando.Parameters.Add("@Fecha", SqlDbType.SmallDateTime).Value = liquidacionimportacion.Fecha;
                    oComando.Parameters.Add("@idDocumento", SqlDbType.VarChar, 20).Value = liquidacionimportacion.idDocumento;
                    oComando.Parameters.Add("@numSerie", SqlDbType.VarChar, 20).Value = liquidacionimportacion.numSerie;
                    oComando.Parameters.Add("@numDocumento", SqlDbType.VarChar, 20).Value = liquidacionimportacion.numDocumento;
                    oComando.Parameters.Add("@idMoneda", SqlDbType.VarChar, 2).Value = liquidacionimportacion.idMoneda;
					oComando.Parameters.Add("@Importe", SqlDbType.Decimal).Value = liquidacionimportacion.Importe;
					oComando.Parameters.Add("@TiCa", SqlDbType.Decimal).Value = liquidacionimportacion.TiCa;
					oComando.Parameters.Add("@numVerPlanCuentas", SqlDbType.VarChar, 3).Value = liquidacionimportacion.numVerPlanCuentas;
					oComando.Parameters.Add("@codCuenta", SqlDbType.VarChar, 20).Value = liquidacionimportacion.codCuenta;
					oComando.Parameters.Add("@AnioPeriodo", SqlDbType.VarChar, 4).Value = liquidacionimportacion.AnioPeriodo;
					oComando.Parameters.Add("@MesPeriodo", SqlDbType.VarChar, 2).Value = liquidacionimportacion.MesPeriodo;
					oComando.Parameters.Add("@idComprobante", SqlDbType.VarChar, 2).Value = liquidacionimportacion.idComprobante;
					oComando.Parameters.Add("@numFile", SqlDbType.VarChar, 2).Value = liquidacionimportacion.numFile;
					oComando.Parameters.Add("@Glosa", SqlDbType.VarChar, 300).Value = liquidacionimportacion.Glosa;
					oComando.Parameters.Add("@UsuarioRegistro", SqlDbType.VarChar, 20).Value = liquidacionimportacion.UsuarioRegistro;

                    oConexion.Open();
                    liquidacionimportacion.idLiquidacion = Int32.Parse(oComando.ExecuteScalar().ToString());
                }
            }

            return liquidacionimportacion;
        }
        
        public LiquidacionImportacionE ActualizarLiquidacionImportacion(LiquidacionImportacionE liquidacionimportacion)
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ActualizarLiquidacionImportacion", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idLiquidacion", SqlDbType.Int).Value = liquidacionimportacion.idLiquidacion;
                    oComando.Parameters.Add("@codLiquidacion", SqlDbType.VarChar, 14).Value = liquidacionimportacion.codLiquidacion;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = liquidacionimportacion.idEmpresa;
					oComando.Parameters.Add("@idLocal", SqlDbType.Int).Value = liquidacionimportacion.idLocal;
					oComando.Parameters.Add("@idPersona", SqlDbType.Int).Value = liquidacionimportacion.idPersona;
					oComando.Parameters.Add("@Fecha", SqlDbType.SmallDateTime).Value = liquidacionimportacion.Fecha;
                    oComando.Parameters.Add("@idDocumento", SqlDbType.VarChar, 20).Value = liquidacionimportacion.idDocumento;
                    oComando.Parameters.Add("@numSerie", SqlDbType.VarChar, 20).Value = liquidacionimportacion.numSerie;
                    oComando.Parameters.Add("@numDocumento", SqlDbType.VarChar, 20).Value = liquidacionimportacion.numDocumento;
                    oComando.Parameters.Add("@idMoneda", SqlDbType.VarChar, 2).Value = liquidacionimportacion.idMoneda;
					oComando.Parameters.Add("@Importe", SqlDbType.Decimal).Value = liquidacionimportacion.Importe;
					oComando.Parameters.Add("@TiCa", SqlDbType.Decimal).Value = liquidacionimportacion.TiCa;
					oComando.Parameters.Add("@numVerPlanCuentas", SqlDbType.VarChar, 3).Value = liquidacionimportacion.numVerPlanCuentas;
					oComando.Parameters.Add("@codCuenta", SqlDbType.VarChar, 20).Value = liquidacionimportacion.codCuenta;
					oComando.Parameters.Add("@AnioPeriodo", SqlDbType.VarChar, 4).Value = liquidacionimportacion.AnioPeriodo;
					oComando.Parameters.Add("@MesPeriodo", SqlDbType.VarChar, 2).Value = liquidacionimportacion.MesPeriodo;
					oComando.Parameters.Add("@idComprobante", SqlDbType.VarChar, 2).Value = liquidacionimportacion.idComprobante;
					oComando.Parameters.Add("@numFile", SqlDbType.VarChar, 2).Value = liquidacionimportacion.numFile;
					oComando.Parameters.Add("@Glosa", SqlDbType.VarChar, 300).Value = liquidacionimportacion.Glosa;
					oComando.Parameters.Add("@UsuarioModificacion", SqlDbType.VarChar, 20).Value = liquidacionimportacion.UsuarioModificacion;

                    oConexion.Open();
                    oComando.ExecuteNonQuery();
                }
            }

            return liquidacionimportacion;
        }        

        public int EliminarLiquidacionImportacion(Int32 idLiquidacion)
        {
            int resp = 0;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_EliminarLiquidacionImportacion", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idLiquidacion", SqlDbType.Int).Value = idLiquidacion;

                    oConexion.Open();
                    resp = oComando.ExecuteNonQuery();
                }
            }

            return resp;
        }

        public List<LiquidacionImportacionE> ListarLiquidacionImportacion(Int32 idEmpresa, Int32 idLocal, DateTime fecIni, DateTime fecFin, Boolean Estado1, Boolean Estado2, Boolean Detallado)
        {
            List<LiquidacionImportacionE> listaEntidad = new List<LiquidacionImportacionE>();

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ListarLiquidacionImportacion", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@idLocal", SqlDbType.Int).Value = idLocal;
                    oComando.Parameters.Add("@fecIni", SqlDbType.SmallDateTime).Value = fecIni.Date;
                    oComando.Parameters.Add("@fecFin", SqlDbType.SmallDateTime).Value = fecFin.Date;
                    oComando.Parameters.Add("@Estado1", SqlDbType.Bit).Value = Estado1;
                    oComando.Parameters.Add("@Estado2", SqlDbType.Bit).Value = Estado2;
                    oComando.Parameters.Add("@Detallado", SqlDbType.Bit).Value = Detallado;

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
        
        public LiquidacionImportacionE ObtenerLiquidacionImportacion(Int32 idLiquidacion)
        {        
            LiquidacionImportacionE liquidacionimportacion = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ObtenerLiquidacionImportacion", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;

                    oComando.Parameters.Add("@idLiquidacion", SqlDbType.Int).Value = idLiquidacion;
                    oConexion.Open();
                    
                    using (SqlDataReader oReader = oComando.ExecuteReader())
                    {
                        while (oReader.Read())
                        {
                            liquidacionimportacion = LlenarEntidad(oReader);
                        }
                    }
                }

                oConexion.Close();
            }

            return liquidacionimportacion;
        }

        public String GenerarCodLiquidacionImportacion(Int32 idEmpresa, DateTime Fecha)
        {
            String Codigo = String.Empty;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_GenerarCodLiquidacionImportacion", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@Fecha", SqlDbType.SmallDateTime).Value = Fecha;

                    oConexion.Open();

                    using (SqlDataReader oReader = oComando.ExecuteReader())
                    {
                        if (oReader.Read())
                        {
                            Codigo = Convert.ToString(oReader["codLiquidacion"]);
                        }
                    }
                }
            }

            return Codigo;
        }

        public Int32 GenerarVoucherLiquidacionImportacion(Int32 idEmpresa, Int32 idLocal, Int32 idLiquidacion, String Usuario)
        {
            Int32 resp = 0;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_GenerarVoucherLiquidacionImportacion", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@idLocal", SqlDbType.Int).Value = idLocal;
                    oComando.Parameters.Add("@idLiquidacion", SqlDbType.Int).Value = idLiquidacion;
                    oComando.Parameters.Add("@Usuario", SqlDbType.VarChar, 20).Value = Usuario;

                    oConexion.Open();
                    resp = oComando.ExecuteNonQuery();
                }
            }

            return resp;
        }

        public Int32 ActualizarEstadoLiquiImportacion(Int32 idLiquidacion, Boolean Estado, String UsuarioModificacion)
        {
            Int32 resp = 0;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ActualizarEstadoLiquiImportacion", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idLiquidacion", SqlDbType.Int).Value = idLiquidacion;
                    oComando.Parameters.Add("@Estado", SqlDbType.Bit).Value = Estado;
                    oComando.Parameters.Add("@UsuarioModificacion", SqlDbType.VarChar, 20).Value = UsuarioModificacion;

                    oConexion.Open();
                    resp = oComando.ExecuteNonQuery();
                }
            }

            return resp;
        }

        public Int32 LimpiarVoucherLiquiImportacion(Int32 idLiquidacion, String UsuarioModificacion)
        {
            Int32 resp = 0;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_LimpiarVoucherLiquiImportacion", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idLiquidacion", SqlDbType.Int).Value = idLiquidacion;
                    oComando.Parameters.Add("@UsuarioModificacion", SqlDbType.VarChar, 20).Value = UsuarioModificacion;

                    oConexion.Open();
                    resp = oComando.ExecuteNonQuery();
                }
            }

            return resp;
        }

        public Int32 ActualizarCtaCteLiquiImport(LiquidacionImportacionE liquidacionimportacion)
        {
            Int32 resp = 0;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ActualizarCtaCteLiquiImport", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idLiquidacion", SqlDbType.Int).Value = liquidacionimportacion.idLiquidacion;
                    oComando.Parameters.Add("@idCtaCte", SqlDbType.Int).Value = liquidacionimportacion.idCtaCte;
                    oComando.Parameters.Add("@idCtaCteItem", SqlDbType.Int).Value = liquidacionimportacion.idCtaCteItem;

                    oConexion.Open();
                    resp = oComando.ExecuteNonQuery();
                }
            }

            return resp;
        }

    }
}