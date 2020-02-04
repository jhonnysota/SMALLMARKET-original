using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

using Entidades.CtasPorPagar;
using AccesoDatos.Util;

namespace AccesoDatos.CtasPorPagar
{
    public class LiquidacionAD : DbConection
    {

        public LiquidacionE LlenarEntidad(IDataReader oReader)
        {
            LiquidacionE liquidacion = new LiquidacionE();
            
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idEmpresa'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				liquidacion.idEmpresa = oReader["idEmpresa"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idEmpresa"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idLocal'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				liquidacion.idLocal = oReader["idLocal"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idLocal"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idLiquidacion'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				liquidacion.idLiquidacion = oReader["idLiquidacion"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idLiquidacion"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idPersona'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				liquidacion.idPersona = oReader["idPersona"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idPersona"]);
			
            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Fecha'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                liquidacion.Fecha = oReader["Fecha"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["Fecha"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='numVerPlanCuentas'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                liquidacion.numVerPlanCuentas = oReader["numVerPlanCuentas"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["numVerPlanCuentas"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='codCuenta'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                liquidacion.codCuenta = oReader["codCuenta"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["codCuenta"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='AnioPeriodo'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                liquidacion.AnioPeriodo = oReader["AnioPeriodo"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["AnioPeriodo"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='MesPeriodo'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                liquidacion.MesPeriodo = oReader["MesPeriodo"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["MesPeriodo"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idComprobante'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                liquidacion.idComprobante = oReader["idComprobante"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["idComprobante"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='numFile'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                liquidacion.numFile = oReader["numFile"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["numFile"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='numVoucher'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                liquidacion.numVoucher = oReader["numVoucher"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["numVoucher"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='PeriodoIni'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                liquidacion.PeriodoIni = oReader["PeriodoIni"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["PeriodoIni"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='PeriodoFin'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                liquidacion.PeriodoFin = oReader["PeriodoFin"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["PeriodoFin"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idOrdenPago'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                liquidacion.idOrdenPago = oReader["idOrdenPago"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idOrdenPago"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Estado'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                liquidacion.Estado = oReader["Estado"] == DBNull.Value ? false : Convert.ToBoolean(oReader["Estado"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='UsuarioRegistro'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                liquidacion.UsuarioRegistro = oReader["UsuarioRegistro"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["UsuarioRegistro"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='FechaRegistro'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				liquidacion.FechaRegistro = oReader["FechaRegistro"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["FechaRegistro"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='UsuarioModificacion'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                liquidacion.UsuarioModificacion = oReader["UsuarioModificacion"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["UsuarioModificacion"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='FechaModificacion'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				liquidacion.FechaModificacion = oReader["FechaModificacion"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["FechaModificacion"]);

            //Extensiones
            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='desEstado'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                liquidacion.desEstado = oReader["desEstado"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["desEstado"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='RazonSocial'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                liquidacion.RazonSocial = oReader["RazonSocial"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["RazonSocial"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='RUC'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                liquidacion.RUC = oReader["RUC"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["RUC"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='desCuenta'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                liquidacion.desCuenta = oReader["desCuenta"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["desCuenta"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='desTipoCuentaLiq'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                liquidacion.desTipoCuentaLiq = oReader["desTipoCuentaLiq"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["desTipoCuentaLiq"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='TipoFondo'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                liquidacion.TipoFondo = oReader["TipoFondo"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["TipoFondo"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Tipo168'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                liquidacion.Tipo168 = oReader["Tipo168"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["Tipo168"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='TotalLiqui'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                liquidacion.TotalLiqui = oReader["TotalLiqui"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["TotalLiqui"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='codOrdenPago'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                liquidacion.codOrdenPago = oReader["codOrdenPago"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["codOrdenPago"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='desEmpresa'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                liquidacion.desEmpresa = oReader["desEmpresa"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["desEmpresa"]);
            

            return  liquidacion;        
        }

        public LiquidacionE InsertarLiquidacion(LiquidacionE liquidacion)
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_InsertarLiquidacion", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = liquidacion.idEmpresa;
					oComando.Parameters.Add("@idLocal", SqlDbType.Int).Value = liquidacion.idLocal;
					oComando.Parameters.Add("@idPersona", SqlDbType.Int).Value = liquidacion.idPersona;
					oComando.Parameters.Add("@Fecha", SqlDbType.DateTime).Value = liquidacion.Fecha.Date;
                    oComando.Parameters.Add("@numVerPlanCuentas", SqlDbType.VarChar, 3).Value = liquidacion.numVerPlanCuentas;
                    oComando.Parameters.Add("@codCuenta", SqlDbType.VarChar, 20).Value = liquidacion.codCuenta;
                    oComando.Parameters.Add("@idComprobante", SqlDbType.VarChar, 2).Value = liquidacion.idComprobante;
                    oComando.Parameters.Add("@numFile", SqlDbType.VarChar, 2).Value = liquidacion.numFile;
                    oComando.Parameters.Add("@PeriodoIni", SqlDbType.SmallDateTime).Value = liquidacion.PeriodoIni.Date;
                    oComando.Parameters.Add("@PeriodoFin", SqlDbType.SmallDateTime).Value = liquidacion.PeriodoFin.Date;
                    oComando.Parameters.Add("@UsuarioRegistro", SqlDbType.VarChar, 20).Value = liquidacion.UsuarioRegistro;

                    oConexion.Open();
                    liquidacion.idLiquidacion = Convert.ToInt32(oComando.ExecuteScalar());
                }
            }

            return liquidacion;
        }
        
        public LiquidacionE ActualizarLiquidacion(LiquidacionE liquidacion)
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ActualizarLiquidacion", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = liquidacion.idEmpresa;
					oComando.Parameters.Add("@idLocal", SqlDbType.Int).Value = liquidacion.idLocal;
					oComando.Parameters.Add("@idLiquidacion", SqlDbType.Int).Value = liquidacion.idLiquidacion;
					oComando.Parameters.Add("@idPersona", SqlDbType.Int).Value = liquidacion.idPersona;
					oComando.Parameters.Add("@Fecha", SqlDbType.DateTime).Value = liquidacion.Fecha;
                    oComando.Parameters.Add("@numVerPlanCuentas", SqlDbType.VarChar, 3).Value = liquidacion.numVerPlanCuentas;
                    oComando.Parameters.Add("@codCuenta", SqlDbType.VarChar, 20).Value = liquidacion.codCuenta;
                    oComando.Parameters.Add("@idComprobante", SqlDbType.VarChar, 2).Value = liquidacion.idComprobante;
                    oComando.Parameters.Add("@numFile", SqlDbType.VarChar, 2).Value = liquidacion.numFile;
                    oComando.Parameters.Add("@PeriodoIni", SqlDbType.SmallDateTime).Value = liquidacion.PeriodoIni.Date;
                    oComando.Parameters.Add("@PeriodoFin", SqlDbType.SmallDateTime).Value = liquidacion.PeriodoFin.Date;
                    oComando.Parameters.Add("@UsuarioModificacion", SqlDbType.VarChar, 20).Value = liquidacion.UsuarioModificacion;

                    oConexion.Open();
                    oComando.ExecuteNonQuery();
                }
            }

            return liquidacion;
        }        

        public Int32 EliminarLiquidacion(Int32 idEmpresa, Int32 idLocal, Int32 idLiquidacion)
        {
            Int32 resp = 0;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_EliminarLiquidacion", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
					oComando.Parameters.Add("@idLocal", SqlDbType.Int).Value = idLocal;
					oComando.Parameters.Add("@idLiquidacion", SqlDbType.Int).Value = idLiquidacion;

                    oConexion.Open();
                    resp = oComando.ExecuteNonQuery();
                }
            }

            return resp;
        }

        public List<LiquidacionE> ListarLiquidacion(Int32 idEmpresa, Int32 idLocal, Int32 idPersona, DateTime fecIni, DateTime fecFin, Boolean Estado1, Boolean Estado2, String TipoFondo, Boolean BuscarDcmto, String idDocumento, String NumSerie, String NumDocumento)
        {
            List<LiquidacionE> listaEntidad = new List<LiquidacionE>();

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ListarLiquidacion", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@idLocal", SqlDbType.Int).Value = idLocal;
                    oComando.Parameters.Add("@idPersona", SqlDbType.Int).Value = idPersona;
                    oComando.Parameters.Add("@fecIni", SqlDbType.SmallDateTime).Value = fecIni;
                    oComando.Parameters.Add("@fecFin", SqlDbType.SmallDateTime).Value = fecFin;
                    oComando.Parameters.Add("@Estado1", SqlDbType.Bit).Value = Estado1;
                    oComando.Parameters.Add("@Estado2", SqlDbType.Bit).Value = Estado2;
                    oComando.Parameters.Add("@TipoFondo", SqlDbType.VarChar, 3).Value = TipoFondo;
                    oComando.Parameters.Add("@BuscarDcmto", SqlDbType.Bit).Value = BuscarDcmto;
                    oComando.Parameters.Add("@idDocumento", SqlDbType.VarChar, 2).Value = idDocumento;
                    oComando.Parameters.Add("@NumSerie", SqlDbType.VarChar, 20).Value = NumSerie;
                    oComando.Parameters.Add("@NumDocumento", SqlDbType.VarChar, 20).Value = NumDocumento;

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
        
        public LiquidacionE ObtenerLiquidacion(Int32 idEmpresa, Int32 idLocal, Int32 idLiquidacion)
        {        
            LiquidacionE liquidacion = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ObtenerLiquidacion", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
					oComando.Parameters.Add("@idLocal", SqlDbType.Int).Value = idLocal;
					oComando.Parameters.Add("@idLiquidacion", SqlDbType.Int).Value = idLiquidacion;

                    oConexion.Open();
                    
                    using (SqlDataReader oReader = oComando.ExecuteReader())
                    {
                        while (oReader.Read())
                        {
                            liquidacion = LlenarEntidad(oReader);
                        }
                    }
                }
            }

            return liquidacion;
        }

        public Int32 ActualizarEstadoLiquidacion(Int32 idLiquidacion, Boolean Estado, String UsuarioModificacion)
        {
            Int32 resp = 0;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ActualizarEstadoLiquidacion", oConexion))
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

        public Int32 GenerarVoucherCxpLiquidacion(Int32 idEmpresa, Int32 idLocal, Int32 idLiquidacion, DateTime Fecha, String Usuario)
        {
            Int32 resp = 0;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_GenerarVoucherCxpLiquidacion", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@idLocal", SqlDbType.Int).Value = idLocal;
                    oComando.Parameters.Add("@idLiquidacion", SqlDbType.Int).Value = idLiquidacion;
                    oComando.Parameters.Add("@Fecha", SqlDbType.SmallDateTime).Value = Fecha;
                    oComando.Parameters.Add("@Usuario", SqlDbType.VarChar, 20).Value = Usuario;

                    oConexion.Open();
                    resp = oComando.ExecuteNonQuery();
                }
            }

            return resp;
        }

        public Int32 LimpiarVoucherLiquidacion(Int32 idLiquidacion, String UsuarioModificacion)
        {
            Int32 resp = 0;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_LimpiarVoucherLiquidacion", oConexion))
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

        public Int32 ActualizarLiquidacionIdOp(Int32 idLiquidacion, Int32 idOrdenPago)
        {
            Int32 resp = 0;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ActualizarLiquidacionIdOp", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idLiquidacion", SqlDbType.Int).Value = idLiquidacion;
                    oComando.Parameters.Add("@idOrdenPago", SqlDbType.Int).Value = idOrdenPago;

                    oConexion.Open();
                    resp = oComando.ExecuteNonQuery();
                }
            }

            return resp;
        }

    }
}