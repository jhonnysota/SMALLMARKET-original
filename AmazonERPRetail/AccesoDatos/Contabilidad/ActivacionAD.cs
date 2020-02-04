using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

using Entidades.Contabilidad;
using AccesoDatos.Util;

namespace AccesoDatos.Contabilidad
{
    public class ActivacionAD : DbConection
    {
        
        public ActivacionE LlenarEntidad(IDataReader oReader)
        {
            ActivacionE activacion = new ActivacionE();
            
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idActivacion'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				activacion.idActivacion = oReader["idActivacion"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idActivacion"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idEmpresa'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                activacion.idEmpresa = oReader["idEmpresa"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idEmpresa"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='codActivacion'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				activacion.codActivacion = oReader["codActivacion"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["codActivacion"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='fecOperacion'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                activacion.fecOperacion = oReader["fecOperacion"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["fecOperacion"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='fecDocumento'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                activacion.fecDocumento = oReader["fecDocumento"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["fecDocumento"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idCCostos'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                activacion.idCCostos = oReader["idCCostos"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["idCCostos"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='indTicaAuto'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                activacion.indTicaAuto = oReader["indTicaAuto"] == DBNull.Value ? false : Convert.ToBoolean(oReader["indTicaAuto"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='tipCambio'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                activacion.tipCambio = oReader["tipCambio"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["tipCambio"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='MesIni'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				activacion.MesIni = oReader["MesIni"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["MesIni"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='MesFinal'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				activacion.MesFinal = oReader["MesFinal"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["MesFinal"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='numVerPlanCuentas'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				activacion.numVerPlanCuentas = oReader["numVerPlanCuentas"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["numVerPlanCuentas"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='codCuenta'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				activacion.codCuenta = oReader["codCuenta"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["codCuenta"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idComprobante'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                activacion.idComprobante = oReader["idComprobante"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["idComprobante"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='numFile'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                activacion.numFile = oReader["numFile"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["numFile"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='AnioPeriodo'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                activacion.AnioPeriodo = oReader["AnioPeriodo"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["AnioPeriodo"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='MesPeriodo'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                activacion.MesPeriodo = oReader["MesPeriodo"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["MesPeriodo"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='numVoucher'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                activacion.numVoucher = oReader["numVoucher"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["numVoucher"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='UsuarioRegistro'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				activacion.UsuarioRegistro = oReader["UsuarioRegistro"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["UsuarioRegistro"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='FechaRegistro'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				activacion.FechaRegistro = oReader["FechaRegistro"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["FechaRegistro"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='UsuarioModificacion'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				activacion.UsuarioModificacion = oReader["UsuarioModificacion"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["UsuarioModificacion"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='FechaModificacion'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				activacion.FechaModificacion = oReader["FechaModificacion"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["FechaModificacion"]);

            //Extensiones
            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='desCCostos'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                activacion.desCCostos = oReader["desCCostos"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["desCCostos"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='desCuenta'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                activacion.desCuenta = oReader["desCuenta"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["desCuenta"]);

            return  activacion;        
        }

        public ActivacionE InsertarActivacion(ActivacionE activacion)
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_InsertarActivacion", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = activacion.idEmpresa;
                    oComando.Parameters.Add("@codActivacion", SqlDbType.VarChar, 10).Value = activacion.codActivacion;
                    oComando.Parameters.Add("@fecOperacion", SqlDbType.SmallDateTime).Value = activacion.fecOperacion.Date;
                    oComando.Parameters.Add("@fecDocumento", SqlDbType.SmallDateTime).Value = activacion.fecDocumento.Date;
                    oComando.Parameters.Add("@idCCostos", SqlDbType.VarChar, 10).Value = activacion.idCCostos;
                    oComando.Parameters.Add("@indTicaAuto", SqlDbType.Bit).Value = activacion.indTicaAuto;
                    oComando.Parameters.Add("@tipCambio", SqlDbType.Decimal).Value = activacion.tipCambio;
					oComando.Parameters.Add("@MesIni", SqlDbType.Char, 2).Value = activacion.MesIni;
					oComando.Parameters.Add("@MesFinal", SqlDbType.Char, 2).Value = activacion.MesFinal;
					oComando.Parameters.Add("@numVerPlanCuentas", SqlDbType.VarChar, 3).Value = activacion.numVerPlanCuentas;
					oComando.Parameters.Add("@codCuenta", SqlDbType.VarChar, 20).Value = activacion.codCuenta;
                    oComando.Parameters.Add("@idComprobante", SqlDbType.VarChar, 2).Value = activacion.idComprobante;
                    oComando.Parameters.Add("@numFile", SqlDbType.VarChar, 2).Value = activacion.numFile;
                    oComando.Parameters.Add("@UsuarioRegistro", SqlDbType.VarChar, 20).Value = activacion.UsuarioRegistro;

                    oConexion.Open();
                    activacion.idActivacion = Int32.Parse(oComando.ExecuteScalar().ToString());
                }
            }

            return activacion;
        }
        
        public ActivacionE ActualizarActivacion(ActivacionE activacion)
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ActualizarActivacion", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idActivacion", SqlDbType.Int).Value = activacion.idActivacion;
					oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = activacion.idEmpresa;
                    oComando.Parameters.Add("@codActivacion", SqlDbType.VarChar, 10).Value = activacion.codActivacion;
                    oComando.Parameters.Add("@fecOperacion", SqlDbType.SmallDateTime).Value = activacion.fecOperacion.Date;
                    oComando.Parameters.Add("@fecDocumento", SqlDbType.SmallDateTime).Value = activacion.fecDocumento.Date;
                    oComando.Parameters.Add("@idCCostos", SqlDbType.VarChar, 10).Value = activacion.idCCostos;
                    oComando.Parameters.Add("@indTicaAuto", SqlDbType.Bit).Value = activacion.indTicaAuto;
                    oComando.Parameters.Add("@tipCambio", SqlDbType.Decimal).Value = activacion.tipCambio;
                    oComando.Parameters.Add("@MesIni", SqlDbType.Char, 2).Value = activacion.MesIni;
					oComando.Parameters.Add("@MesFinal", SqlDbType.Char, 2).Value = activacion.MesFinal;
					oComando.Parameters.Add("@numVerPlanCuentas", SqlDbType.VarChar, 3).Value = activacion.numVerPlanCuentas;
					oComando.Parameters.Add("@codCuenta", SqlDbType.VarChar, 20).Value = activacion.codCuenta;
                    oComando.Parameters.Add("@idComprobante", SqlDbType.VarChar, 2).Value = activacion.idComprobante;
                    oComando.Parameters.Add("@numFile", SqlDbType.VarChar, 2).Value = activacion.numFile;
                    oComando.Parameters.Add("@UsuarioModificacion", SqlDbType.VarChar, 20).Value = activacion.UsuarioModificacion;

                    oConexion.Open();
                    oComando.ExecuteNonQuery();
                }
            }

            return activacion;
        }        

        public int EliminarActivacion(Int32 idActivacion)
        {
            int resp = 0;
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_EliminarActivacion", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idActivacion", SqlDbType.Int).Value = idActivacion;

                    oConexion.Open();
                    resp = oComando.ExecuteNonQuery();
                }
            }

            return resp;
        }

        public List<ActivacionE> ListarActivacion(Int32 idEmpresa)
        {
           List<ActivacionE> listaEntidad = new List<ActivacionE>();
           ActivacionE entidad = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ListarActivacion", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;

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
        
        public ActivacionE ObtenerActivacion(Int32 idActivacion)
        {        
            ActivacionE activacion = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ObtenerActivacion", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;

                    oComando.Parameters.Add("@idActivacion", SqlDbType.Int).Value = idActivacion;
                    oConexion.Open();
                    
                    using (SqlDataReader oReader = oComando.ExecuteReader())
                    {
                        while (oReader.Read())
                        {
                            activacion = LlenarEntidad(oReader);
                        }
                    }
                }
            }

            return activacion;
        }

        public ActivacionE ActualizarVoucherActivacion(ActivacionE activacion)
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ActualizarVoucherActivacion", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idActivacion", SqlDbType.Int).Value = activacion.idActivacion;
                    oComando.Parameters.Add("@AnioPeriodo", SqlDbType.VarChar, 4).Value = activacion.AnioPeriodo;
                    oComando.Parameters.Add("@MesPeriodo", SqlDbType.VarChar, 2).Value = activacion.MesPeriodo;
                    oComando.Parameters.Add("@numVoucher", SqlDbType.VarChar, 9).Value = activacion.numVoucher;
                    oComando.Parameters.Add("@UsuarioModificacion", SqlDbType.VarChar, 20).Value = activacion.UsuarioModificacion;

                    oConexion.Open();
                    oComando.ExecuteNonQuery();
                }
            }

            return activacion;
        }

        public String GenerarNumActivacion(Int32 idEmpresa)
        {
            String Codigo = String.Empty;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_GenerarNumActivacion", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;

                    oConexion.Open();

                    using (SqlDataReader oReader = oComando.ExecuteReader())
                    {
                        if (oReader.Read())
                        {
                            Codigo = Convert.ToString(oReader["codActivacion"]);
                        }
                    }
                }
            }

            return Codigo;
        }

        public ActivacionE GenerarVoucherCapitalizacion(Int32 idActivacion, Int32 idEmpresa, Int32 idLocal, String Usuario)
        {
            ActivacionE activacion = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_GenerarVoucherCapitalizacion", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idActivacion", SqlDbType.Int).Value = idActivacion;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@idLocal", SqlDbType.Int).Value = idLocal;
                    oComando.Parameters.Add("@Usuario", SqlDbType.VarChar, 20).Value = Usuario;

                    oConexion.Open();

                    using (SqlDataReader oReader = oComando.ExecuteReader())
                    {
                        if (oReader.Read())
                        {
                            activacion = LlenarEntidad(oReader);
                        }
                    }
                }
            }

            return activacion;
        }

    }
}