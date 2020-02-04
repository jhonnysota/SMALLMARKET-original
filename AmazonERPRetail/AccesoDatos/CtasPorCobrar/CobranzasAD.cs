using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

using Entidades.CtasPorCobrar;
using AccesoDatos.Util;

namespace AccesoDatos.CtasPorCobrar
{
    public class CobranzasAD : DbConection
    {

        public CobranzasE LlenarEntidad(IDataReader oReader)
        {
            CobranzasE cobranzas = new CobranzasE();

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idPlanilla'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                cobranzas.idPlanilla = oReader["idPlanilla"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idPlanilla"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='TipoPlanilla'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                cobranzas.TipoPlanilla = oReader["TipoPlanilla"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["TipoPlanilla"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idEmpresa'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				cobranzas.idEmpresa = oReader["idEmpresa"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idEmpresa"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idLocal'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				cobranzas.idLocal = oReader["idLocal"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idLocal"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='codPlanilla'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				cobranzas.codPlanilla = oReader["codPlanilla"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["codPlanilla"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Fecha'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				cobranzas.Fecha = oReader["Fecha"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["Fecha"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='MontoSoles'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				cobranzas.MontoSoles = oReader["MontoSoles"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["MontoSoles"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='MontoDolares'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				cobranzas.MontoDolares = oReader["MontoDolares"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["MontoDolares"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Observaciones'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				cobranzas.Observaciones = oReader["Observaciones"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["Observaciones"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='EstadoDoc'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				cobranzas.EstadoDoc = oReader["EstadoDoc"] == DBNull.Value ? false : Convert.ToBoolean(oReader["EstadoDoc"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idComprobante'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				cobranzas.idComprobante = oReader["idComprobante"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["idComprobante"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='numFile'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				cobranzas.numFile = oReader["numFile"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["numFile"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='AnioPeriodo'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				cobranzas.AnioPeriodo = oReader["AnioPeriodo"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["AnioPeriodo"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='MesPeriodo'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				cobranzas.MesPeriodo = oReader["MesPeriodo"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["MesPeriodo"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='numVoucher'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				cobranzas.numVoucher = oReader["numVoucher"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["numVoucher"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='VieneFact'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                cobranzas.VieneFact = oReader["VieneFact"] == DBNull.Value ? false : Convert.ToBoolean(oReader["VieneFact"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idBanco'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                cobranzas.idBanco = oReader["idBanco"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idBanco"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='UsuarioRegistro'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				cobranzas.UsuarioRegistro = oReader["UsuarioRegistro"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["UsuarioRegistro"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='FechaRegistro'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				cobranzas.FechaRegistro = oReader["FechaRegistro"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["FechaRegistro"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='UsuarioModificacion'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				cobranzas.UsuarioModificacion = oReader["UsuarioModificacion"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["UsuarioModificacion"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='FechaModificacion'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				cobranzas.FechaModificacion = oReader["FechaModificacion"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["FechaModificacion"]);

            //Extensiones
            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='desEstado'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                cobranzas.desEstado = oReader["desEstado"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["desEstado"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idDocumento'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                cobranzas.idDocumento = oReader["idDocumento"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["idDocumento"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='numCheque'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                cobranzas.numCheque = oReader["numCheque"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["numCheque"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='TipCambio'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                cobranzas.TipCambio = oReader["TipCambio"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["TipCambio"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='desCtaDetino'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                cobranzas.desCtaDetino = oReader["desCtaDetino"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["desCtaDetino"]);


            return  cobranzas;        
        }

        public CobranzasE InsertarCobranzas(CobranzasE cobranzas)
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_InsertarCobranzas", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@TipoPlanilla", SqlDbType.Int).Value = cobranzas.TipoPlanilla;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = cobranzas.idEmpresa;
					oComando.Parameters.Add("@idLocal", SqlDbType.Int).Value = cobranzas.idLocal;
					oComando.Parameters.Add("@codPlanilla", SqlDbType.VarChar, 10).Value = cobranzas.codPlanilla;
					oComando.Parameters.Add("@Fecha", SqlDbType.SmallDateTime).Value = cobranzas.Fecha;
					oComando.Parameters.Add("@MontoSoles", SqlDbType.Decimal).Value = cobranzas.MontoSoles;
					oComando.Parameters.Add("@MontoDolares", SqlDbType.Decimal).Value = cobranzas.MontoDolares;
					oComando.Parameters.Add("@Observaciones", SqlDbType.VarChar, 150).Value = cobranzas.Observaciones;
					oComando.Parameters.Add("@idComprobante", SqlDbType.VarChar, 2).Value = cobranzas.idComprobante;
					oComando.Parameters.Add("@numFile", SqlDbType.Char, 2).Value = cobranzas.numFile;
					oComando.Parameters.Add("@AnioPeriodo", SqlDbType.Char, 4).Value = cobranzas.AnioPeriodo;
					oComando.Parameters.Add("@MesPeriodo", SqlDbType.VarChar, 2).Value = cobranzas.MesPeriodo;
                    oComando.Parameters.Add("@idBanco", SqlDbType.Int).Value = cobranzas.idBanco;
                    oComando.Parameters.Add("@UsuarioRegistro", SqlDbType.VarChar, 20).Value = cobranzas.UsuarioRegistro;

                    oConexion.Open();
                    cobranzas.idPlanilla = Int32.Parse(oComando.ExecuteScalar().ToString());
                }
            }

            return cobranzas;
        }
        
        public CobranzasE ActualizarCobranzas(CobranzasE cobranzas)
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ActualizarCobranzas", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idPlanilla", SqlDbType.Int).Value = cobranzas.idPlanilla;
                    oComando.Parameters.Add("@TipoPlanilla", SqlDbType.Int).Value = cobranzas.TipoPlanilla;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = cobranzas.idEmpresa;
					oComando.Parameters.Add("@idLocal", SqlDbType.Int).Value = cobranzas.idLocal;
					oComando.Parameters.Add("@codPlanilla", SqlDbType.VarChar, 4).Value = cobranzas.codPlanilla;
					oComando.Parameters.Add("@Fecha", SqlDbType.SmallDateTime).Value = cobranzas.Fecha;
					oComando.Parameters.Add("@MontoSoles", SqlDbType.Decimal).Value = cobranzas.MontoSoles;
					oComando.Parameters.Add("@MontoDolares", SqlDbType.Decimal).Value = cobranzas.MontoDolares;
					oComando.Parameters.Add("@Observaciones", SqlDbType.VarChar, 150).Value = cobranzas.Observaciones;
					oComando.Parameters.Add("@idComprobante", SqlDbType.VarChar, 2).Value = cobranzas.idComprobante;
					oComando.Parameters.Add("@numFile", SqlDbType.VarChar, 2).Value = cobranzas.numFile;
					oComando.Parameters.Add("@AnioPeriodo", SqlDbType.VarChar, 4).Value = cobranzas.AnioPeriodo;
					oComando.Parameters.Add("@MesPeriodo", SqlDbType.VarChar, 2).Value = cobranzas.MesPeriodo;
                    oComando.Parameters.Add("@idBanco", SqlDbType.Int).Value = cobranzas.idBanco;
                    oComando.Parameters.Add("@UsuarioModificacion", SqlDbType.VarChar, 20).Value = cobranzas.UsuarioModificacion;

                    oConexion.Open();
                    oComando.ExecuteNonQuery();
                }
            }

            return cobranzas;
        }        

        public int EliminarCobranzas(Int32 idPlanilla)
        {
            int resp = 0;
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_EliminarCobranzas", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
					oComando.Parameters.Add("@idPlanilla", SqlDbType.Int).Value = idPlanilla;

                    oConexion.Open();
                    resp = oComando.ExecuteNonQuery();
                }
            }

            return resp;
        }

        public List<CobranzasE> ListarCobranzas(Int32 idEmpresa, Int32 idLocal, Int32 TipoPlanilla, DateTime fecIni, DateTime fecFin)
        {
            List<CobranzasE> listaEntidad = new List<CobranzasE>();

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ListarCobranzas", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@idLocal", SqlDbType.Int).Value = idLocal;
                    oComando.Parameters.Add("@TipoPlanilla", SqlDbType.Int).Value = TipoPlanilla;
                    oComando.Parameters.Add("@fecIni", SqlDbType.SmallDateTime).Value = fecIni.Date;
                    oComando.Parameters.Add("@fecFin", SqlDbType.SmallDateTime).Value = fecFin.Date;

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
        
        public CobranzasE ObtenerCobranzas(Int32 idPlanilla)
        {        
            CobranzasE cobranzas = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ObtenerCobranzas", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
					oComando.Parameters.Add("@idPlanilla", SqlDbType.Int).Value = idPlanilla;

                    oConexion.Open();
                    
                    using (SqlDataReader oReader = oComando.ExecuteReader())
                    {
                        while (oReader.Read())
                        {
                            cobranzas = LlenarEntidad(oReader);
                        }
                    }
                }
            }

            return cobranzas;
        }

        public String GenerarCodPlanilla(Int32 idEmpresa, Int32 idLocal, Int32 TipoPlanilla, String Anio)
        {
            CobranzasE cobranzas = new CobranzasE();

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_GenerarCodPlanilla", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@idLocal", SqlDbType.Int).Value = idLocal;
                    oComando.Parameters.Add("@TipoPlanilla", SqlDbType.Int).Value = TipoPlanilla;
                    oComando.Parameters.Add("@Anio", SqlDbType.VarChar, 4).Value = Anio;

                    oConexion.Open();

                    using (SqlDataReader oReader = oComando.ExecuteReader())
                    {
                        if (oReader.Read())
                        {
                            cobranzas.codPlanilla = Convert.ToString(oReader["codPlanilla"]);
                        }
                    }
                }
            }

            return cobranzas.codPlanilla;
        }

        public String GenerarVenAsientoPlanillas(Int32 idPlanilla, Int32 idEmpresa, Int32 idLocal, String numVerPlanCuentas, String Usuario)
        {
            String Codigo = String.Empty;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_GenerarVenAsientoPlanillas", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idPlanilla", SqlDbType.Int).Value = idPlanilla;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@idLocal", SqlDbType.Int).Value = idLocal;
                    oComando.Parameters.Add("@numVerPlanCuentas", SqlDbType.VarChar, 3).Value = numVerPlanCuentas;
                    oComando.Parameters.Add("@Usuario", SqlDbType.VarChar, 20).Value = Usuario;

                    oConexion.Open();

                    using (SqlDataReader oReader = oComando.ExecuteReader())
                    {
                        if (oReader.Read())
                        {
                            Codigo = (oReader["idComprobante"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["idComprobante"])) + " " +
                                    (oReader["numFile"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["numFile"])) + " " +
                                    (oReader["numVoucher"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["numVoucher"]));
                        }
                    }
                }
            }

            return Codigo;
        }

        public int ActualizarEstadoCobranzas(Int32 idPlanilla, String numVoucher, Boolean EstadoDoc, String UsuarioModificacion)
        {
            int resp = 0;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ActualizarEstadoCobranzas", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idPlanilla", SqlDbType.Int).Value = idPlanilla;
                    oComando.Parameters.Add("@numVoucher", SqlDbType.VarChar, 9).Value = numVoucher;
                    oComando.Parameters.Add("@EstadoDoc", SqlDbType.Bit).Value = EstadoDoc;
                    oComando.Parameters.Add("@UsuarioModificacion", SqlDbType.VarChar, 20).Value = UsuarioModificacion;

                    oConexion.Open();
                    resp = oComando.ExecuteNonQuery();
                }
            }

            return resp;
        }

        public int ActualizarVieneFact(Int32 idPlanilla)
        {
            int resp = 0;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ActualizarVieneFact", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idPlanilla", SqlDbType.Int).Value = idPlanilla;
                    oConexion.Open();

                    resp = oComando.ExecuteNonQuery();
                }
            }

            return resp;
        }

        public int LimpiarCobranzasVoucher(Int32 idPlanilla, String UsuarioModificacion)
        {
            int resp = 0;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_LimpiarCobranzasVoucher", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idPlanilla", SqlDbType.Int).Value = idPlanilla;
                    oComando.Parameters.Add("@UsuarioModificacion", SqlDbType.VarChar, 20).Value = UsuarioModificacion;

                    oConexion.Open();
                    resp = oComando.ExecuteNonQuery();
                }
            }

            return resp;
        }

        public String GenerarAsientoPlanillaCompensacion(Int32 idPlanilla, Int32 idEmpresa, Int32 idLocal, String numVerPlanCuentas, String Usuario)
        {
            String Codigo = String.Empty;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_GenerarAsientoPlanillaCompensacion", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idPlanilla", SqlDbType.Int).Value = idPlanilla;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@idLocal", SqlDbType.Int).Value = idLocal;
                    oComando.Parameters.Add("@numVerPlanCuentas", SqlDbType.VarChar, 3).Value = numVerPlanCuentas;
                    oComando.Parameters.Add("@Usuario", SqlDbType.VarChar, 20).Value = Usuario;

                    oConexion.Open();

                    using (SqlDataReader oReader = oComando.ExecuteReader())
                    {
                        if (oReader.Read())
                        {
                            Codigo = (oReader["idComprobante"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["idComprobante"])) + " " +
                                    (oReader["numFile"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["numFile"])) + " " +
                                    (oReader["numVoucher"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["numVoucher"]));
                        }
                    }
                }
            }

            return Codigo;
        }

        public List<CobranzasE> ListarCobranzasPorLetraTipPla(Int32 idEmpresa, Int32 idLocal, Int32 TipoPlanilla, String Letra)
        {
            List<CobranzasE> listaEntidad = new List<CobranzasE>();

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ListarCobranzasPorLetraTipPla", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@idLocal", SqlDbType.Int).Value = idLocal;
                    oComando.Parameters.Add("@TipoPlanilla", SqlDbType.Int).Value = TipoPlanilla;
                    oComando.Parameters.Add("@Letra", SqlDbType.VarChar, 10).Value = Letra;

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

    }
}