using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

using Entidades.CtasPorPagar;
using AccesoDatos.Util;

namespace AccesoDatos.CtasPorPagar
{
    public class CanjeAD : DbConection
    {

        public CanjeE LlenarEntidad(IDataReader oReader)
        {
            CanjeE canje = new CanjeE();
            
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idEmpresa'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				canje.idEmpresa = oReader["idEmpresa"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idEmpresa"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idLocal'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				canje.idLocal = oReader["idLocal"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idLocal"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idCanje'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				canje.idCanje = oReader["idCanje"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idCanje"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='numCanje'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				canje.numCanje = oReader["numCanje"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["numCanje"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idPersona'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				canje.idPersona = oReader["idPersona"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idPersona"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='TipoCambio'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				canje.TipoCambio = oReader["TipoCambio"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["TipoCambio"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idMonedaCanje'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				canje.idMonedaCanje = oReader["idMonedaCanje"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["idMonedaCanje"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='MontoCanje'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				canje.MontoCanje = oReader["MontoCanje"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["MontoCanje"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='FechaCanje'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				canje.FechaCanje = oReader["FechaCanje"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["FechaCanje"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='numLetras'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				canje.numLetras = oReader["numLetras"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["numLetras"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='tipCanje'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				canje.tipCanje = oReader["tipCanje"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["tipCanje"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Estado'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				canje.Estado = oReader["Estado"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["Estado"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='AnioPeriodo'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				canje.AnioPeriodo = oReader["AnioPeriodo"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["AnioPeriodo"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='MesPeriodo'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				canje.MesPeriodo = oReader["MesPeriodo"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["MesPeriodo"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='numVoucher'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				canje.numVoucher = oReader["numVoucher"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["numVoucher"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idComprobante'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				canje.idComprobante = oReader["idComprobante"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["idComprobante"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='numFile'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				canje.numFile = oReader["numFile"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["numFile"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='indRetencion'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				canje.indRetencion = oReader["indRetencion"] == DBNull.Value ? false : Convert.ToBoolean(oReader["indRetencion"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='UsuarioRegistro'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				canje.UsuarioRegistro = oReader["UsuarioRegistro"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["UsuarioRegistro"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='FechaRegistro'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				canje.FechaRegistro = oReader["FechaRegistro"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["FechaRegistro"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='UsuarioModificacion'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				canje.UsuarioModificacion = oReader["UsuarioModificacion"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["UsuarioModificacion"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='FechaModificacion'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				canje.FechaModificacion = oReader["FechaModificacion"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["FechaModificacion"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='RazonSocial'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                canje.RazonSocial = oReader["RazonSocial"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["RazonSocial"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='RUC'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                canje.RUC = oReader["RUC"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["RUC"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='desMoneda'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                canje.desMoneda = oReader["desMoneda"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["desMoneda"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='desEstado'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                canje.desEstado = oReader["desEstado"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["desEstado"]);

            return  canje;        
        }

        public CanjeE InsertarCanje(CanjeE canje)
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_InsertarCanje", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = canje.idEmpresa;
					oComando.Parameters.Add("@idLocal", SqlDbType.Int).Value = canje.idLocal;
					oComando.Parameters.Add("@numCanje", SqlDbType.VarChar, 10).Value = canje.numCanje;
					oComando.Parameters.Add("@idPersona", SqlDbType.Int).Value = canje.idPersona;
					oComando.Parameters.Add("@TipoCambio", SqlDbType.Decimal).Value = canje.TipoCambio;
					oComando.Parameters.Add("@idMonedaCanje", SqlDbType.VarChar, 2).Value = canje.idMonedaCanje;
					oComando.Parameters.Add("@MontoCanje", SqlDbType.Decimal).Value = canje.MontoCanje;
					oComando.Parameters.Add("@FechaCanje", SqlDbType.SmallDateTime).Value = canje.FechaCanje.Date;
					oComando.Parameters.Add("@numLetras", SqlDbType.Int).Value = canje.numLetras;
					oComando.Parameters.Add("@tipCanje", SqlDbType.VarChar, 2).Value = "CJ";
					oComando.Parameters.Add("@indRetencion", SqlDbType.Bit).Value = canje.indRetencion;
                    oComando.Parameters.Add("@UsuarioRegistro", SqlDbType.VarChar, 20).Value = canje.UsuarioRegistro;

                    oConexion.Open();
                    canje.idCanje = Int32.Parse(oComando.ExecuteScalar().ToString());
                }
            }

            return canje;
        }
        
        public CanjeE ActualizarCanje(CanjeE canje)
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ActualizarCanje", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = canje.idEmpresa;
					oComando.Parameters.Add("@idLocal", SqlDbType.Int).Value = canje.idLocal;
					oComando.Parameters.Add("@idCanje", SqlDbType.Int).Value = canje.idCanje;
					oComando.Parameters.Add("@numCanje", SqlDbType.VarChar, 10).Value = canje.numCanje;
					oComando.Parameters.Add("@idPersona", SqlDbType.Int).Value = canje.idPersona;
					oComando.Parameters.Add("@TipoCambio", SqlDbType.Decimal).Value = canje.TipoCambio;
					oComando.Parameters.Add("@idMonedaCanje", SqlDbType.VarChar, 2).Value = canje.idMonedaCanje;
					oComando.Parameters.Add("@MontoCanje", SqlDbType.Decimal).Value = canje.MontoCanje;
					oComando.Parameters.Add("@FechaCanje", SqlDbType.SmallDateTime).Value = canje.FechaCanje.Date;
					oComando.Parameters.Add("@numLetras", SqlDbType.Int).Value = canje.numLetras;
					oComando.Parameters.Add("@tipCanje", SqlDbType.VarChar, 2).Value = "CJ";
					oComando.Parameters.Add("@indRetencion", SqlDbType.Bit).Value = canje.indRetencion;
                    oComando.Parameters.Add("@UsuarioModificacion", SqlDbType.VarChar, 20).Value = canje.UsuarioModificacion;

                    oConexion.Open();
                    oComando.ExecuteNonQuery();
                }
            }

            return canje;
        }        

        public int EliminarCanje(Int32 idEmpresa, Int32 idLocal, Int32 idCanje)
        {
            int resp = 0;
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_EliminarCanje", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
					oComando.Parameters.Add("@idLocal", SqlDbType.Int).Value = idLocal;
					oComando.Parameters.Add("@idCanje", SqlDbType.Int).Value = idCanje;

                    oConexion.Open();
                    resp = oComando.ExecuteNonQuery();
                }
            }

            return resp;
        }

        public List<CanjeE> ListarCanje(Int32 idEmpresa, Int32 idLocal, Int32 idPersona, DateTime fecIni, DateTime fecFin)
        {
           List<CanjeE> listaEntidad = new List<CanjeE>();
           CanjeE entidad = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ListarCanje", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@idLocal", SqlDbType.Int).Value = idLocal;
                    oComando.Parameters.Add("@idPersona", SqlDbType.Int).Value = idPersona;
                    oComando.Parameters.Add("@fecIni", SqlDbType.SmallDateTime).Value = fecIni.Date;
                    oComando.Parameters.Add("@fecFin", SqlDbType.SmallDateTime).Value = fecFin.Date;

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
        
        public CanjeE ObtenerCanje(Int32 idCanje)
        {        
            CanjeE canje = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ObtenerCanje", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
					oComando.Parameters.Add("@idCanje", SqlDbType.Int).Value = idCanje;

                    oConexion.Open();
                    
                    using (SqlDataReader oReader = oComando.ExecuteReader())
                    {
                        while (oReader.Read())
                        {
                            canje = LlenarEntidad(oReader);
                        }
                    }
                }
            }

            return canje;
        }

        public String GenerarNumCanjeLetra(Int32 idEmpresa, String Mes, String Anio)
        {
            String Codigo = String.Empty;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_GenerarNumCanjeLetra", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@Mes", SqlDbType.Char, 2).Value = Mes;
                    oComando.Parameters.Add("@Anio", SqlDbType.Char, 4).Value = Anio;

                    oConexion.Open();

                    using (SqlDataReader oReader = oComando.ExecuteReader())
                    {
                        if (oReader.Read())
                        {
                            Codigo = oReader["numCanje"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["numCanje"]);
                        }
                    }
                }
            }

            return Codigo;
        }

        public int CambiarEstadoCanje(Int32 idCanje, String Estado, String Usuario)
        {
            int resp = 0;
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_CambiarEstadoCanje", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idCanje", SqlDbType.Int).Value = idCanje;
                    oComando.Parameters.Add("@Estado", SqlDbType.Char, 2).Value = Estado;
                    oComando.Parameters.Add("@Usuario", SqlDbType.VarChar, 20).Value = Usuario;
                    

                    oConexion.Open();
                    resp = oComando.ExecuteNonQuery();
                }
            }

            return resp;
        }

        public Int32 ActualizarCanjeConta(CanjeE canje)
        {
            Int32 resp = 0;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ActualizarCanjeConta", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idCanje", SqlDbType.Int).Value = canje.idCanje;
                    oComando.Parameters.Add("@AnioPeriodo", SqlDbType.VarChar, 4).Value = canje.AnioPeriodo;
                    oComando.Parameters.Add("@MesPeriodo", SqlDbType.VarChar, 2).Value = canje.MesPeriodo;
                    oComando.Parameters.Add("@numVoucher", SqlDbType.VarChar, 9).Value = canje.numVoucher;
                    oComando.Parameters.Add("@idComprobante", SqlDbType.VarChar, 2).Value = canje.idComprobante;
                    oComando.Parameters.Add("@numFile", SqlDbType.VarChar, 2).Value = canje.numFile;
                    oComando.Parameters.Add("@UsuarioModificacion", SqlDbType.VarChar, 20).Value = canje.UsuarioModificacion;

                    oConexion.Open();
                    resp = oComando.ExecuteNonQuery();
                }
            }

            return resp;
        }

    }
}