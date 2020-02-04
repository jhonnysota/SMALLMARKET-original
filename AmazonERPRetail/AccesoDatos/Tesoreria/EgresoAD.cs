using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

using Entidades.Tesoreria;
using AccesoDatos.Util;

namespace AccesoDatos.Tesoreria
{
    public class EgresoAD : DbConection
    {

        public EgresoE LlenarEntidad(IDataReader oReader)
        {
            EgresoE egreso = new EgresoE();
            
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idEmpresa'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				egreso.idEmpresa = oReader["idEmpresa"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idEmpresa"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idLocal'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				egreso.idLocal = oReader["idLocal"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idLocal"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idNumEgreso'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				egreso.idNumEgreso = oReader["idNumEgreso"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idNumEgreso"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='NumEgreso'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				egreso.NumEgreso = oReader["NumEgreso"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["NumEgreso"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idMoneda'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				egreso.idMoneda = oReader["idMoneda"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["idMoneda"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='codTipoPago'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                egreso.codTipoPago = oReader["codTipoPago"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["codTipoPago"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idConcepto'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                egreso.idConcepto = oReader["idConcepto"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idConcepto"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='codFormaPago'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				egreso.codFormaPago = oReader["codFormaPago"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["codFormaPago"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='fechaProceso'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				egreso.fechaProceso = oReader["fechaProceso"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["fechaProceso"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='tipCambio'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				egreso.tipCambio = oReader["tipCambio"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["tipCambio"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='impEgresoBase'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				egreso.impEgresoBase = oReader["impEgresoBase"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["impEgresoBase"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idPersona'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				egreso.idPersona = oReader["idPersona"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idPersona"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='impEgresoSecun'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				egreso.impEgresoSecun = oReader["impEgresoSecun"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["impEgresoSecun"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='tipEstado'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				egreso.tipEstado = oReader["tipEstado"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["tipEstado"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='glosaPago'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				egreso.glosaPago = oReader["glosaPago"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["glosaPago"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='AnioPeriodo'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				egreso.AnioPeriodo = oReader["AnioPeriodo"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["AnioPeriodo"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='MesPeriodo'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				egreso.MesPeriodo = oReader["MesPeriodo"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["MesPeriodo"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='numVoucher'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				egreso.numVoucher = oReader["numVoucher"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["numVoucher"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idComprobante'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				egreso.idComprobante = oReader["idComprobante"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["idComprobante"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='numFile'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				egreso.numFile = oReader["numFile"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["numFile"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='FechaRegistro'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				egreso.FechaRegistro = oReader["FechaRegistro"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["FechaRegistro"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='UsuarioRegistro'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				egreso.UsuarioRegistro = oReader["UsuarioRegistro"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["UsuarioRegistro"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='FechaModificacion'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				egreso.FechaModificacion = oReader["FechaModificacion"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["FechaModificacion"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='UsuarioModificacion'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				egreso.UsuarioModificacion = oReader["UsuarioModificacion"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["UsuarioModificacion"]);

            //Extensiones
            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='RazonSocial'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                egreso.RazonSocial = oReader["RazonSocial"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["RazonSocial"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idDocumentoBanco'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                egreso.idDocumentoBanco = oReader["idDocumentoBanco"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["idDocumentoBanco"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='SerieBanco'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                egreso.SerieBanco = oReader["SerieBanco"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["SerieBanco"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='NumeroBanco'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                egreso.NumeroBanco = oReader["NumeroBanco"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["NumeroBanco"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='desMoneda'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                egreso.desMoneda = oReader["desMoneda"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["desMoneda"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Monto'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                egreso.Monto = oReader["Monto"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["Monto"]);

            return egreso;
        }

        public EgresoE InsertarEgreso(EgresoE egreso)
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_InsertarEgreso", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = egreso.idEmpresa;
					oComando.Parameters.Add("@idLocal", SqlDbType.Int).Value = egreso.idLocal;
					oComando.Parameters.Add("@NumEgreso", SqlDbType.VarChar, 10).Value = egreso.NumEgreso;
					oComando.Parameters.Add("@idMoneda", SqlDbType.VarChar, 2).Value = egreso.idMoneda;
                    oComando.Parameters.Add("@codTipoPago", SqlDbType.VarChar, 3).Value = egreso.codTipoPago;
                    oComando.Parameters.Add("@idConcepto", SqlDbType.Int).Value = egreso.idConcepto;
                    oComando.Parameters.Add("@codFormaPago", SqlDbType.VarChar, 3).Value = egreso.codFormaPago;
					oComando.Parameters.Add("@fechaProceso", SqlDbType.SmallDateTime).Value = egreso.fechaProceso;
					oComando.Parameters.Add("@tipCambio", SqlDbType.Decimal).Value = egreso.tipCambio;
					oComando.Parameters.Add("@impEgresoBase", SqlDbType.Decimal).Value = egreso.impEgresoBase;
					oComando.Parameters.Add("@idPersona", SqlDbType.Int).Value = egreso.idPersona;
					oComando.Parameters.Add("@impEgresoSecun", SqlDbType.Decimal).Value = egreso.impEgresoSecun;
					oComando.Parameters.Add("@tipEstado", SqlDbType.VarChar, 2).Value = egreso.tipEstado;
					oComando.Parameters.Add("@glosaPago", SqlDbType.VarChar, 100).Value = egreso.glosaPago;
					oComando.Parameters.Add("@AnioPeriodo", SqlDbType.Char, 4).Value = egreso.AnioPeriodo;
					oComando.Parameters.Add("@MesPeriodo", SqlDbType.Char, 2).Value = egreso.MesPeriodo;
					oComando.Parameters.Add("@numVoucher", SqlDbType.VarChar, 9).Value = egreso.numVoucher;
					oComando.Parameters.Add("@idComprobante", SqlDbType.Char, 2).Value = egreso.idComprobante;
					oComando.Parameters.Add("@numFile", SqlDbType.Char, 2).Value = egreso.numFile;
					oComando.Parameters.Add("@UsuarioRegistro", SqlDbType.VarChar, 20).Value = egreso.UsuarioRegistro;

                    oConexion.Open();
                    egreso.idNumEgreso = Int32.Parse(oComando.ExecuteScalar().ToString());
                }
            }

            return egreso;
        }
        
        public EgresoE ActualizarEgreso(EgresoE egreso)
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ActualizarEgreso", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = egreso.idEmpresa;
					oComando.Parameters.Add("@idLocal", SqlDbType.Int).Value = egreso.idLocal;
					oComando.Parameters.Add("@idNumEgreso", SqlDbType.Int).Value = egreso.idNumEgreso;
					oComando.Parameters.Add("@NumEgreso", SqlDbType.VarChar, 10).Value = egreso.NumEgreso;
					oComando.Parameters.Add("@idMoneda", SqlDbType.VarChar, 2).Value = egreso.idMoneda;
                    oComando.Parameters.Add("@codTipoPago", SqlDbType.VarChar, 3).Value = egreso.codTipoPago;
                    oComando.Parameters.Add("@idConcepto", SqlDbType.Int).Value = egreso.idConcepto;
                    oComando.Parameters.Add("@codFormaPago", SqlDbType.VarChar, 3).Value = egreso.codFormaPago;
                    oComando.Parameters.Add("@fechaProceso", SqlDbType.SmallDateTime).Value = egreso.fechaProceso;
					oComando.Parameters.Add("@tipCambio", SqlDbType.Decimal).Value = egreso.tipCambio;
					oComando.Parameters.Add("@impEgresoBase", SqlDbType.Decimal).Value = egreso.impEgresoBase;
					oComando.Parameters.Add("@idPersona", SqlDbType.Int).Value = egreso.idPersona;
					oComando.Parameters.Add("@impEgresoSecun", SqlDbType.Decimal).Value = egreso.impEgresoSecun;
					oComando.Parameters.Add("@tipEstado", SqlDbType.VarChar, 2).Value = egreso.tipEstado;
					oComando.Parameters.Add("@glosaPago", SqlDbType.VarChar, 100).Value = egreso.glosaPago;
					oComando.Parameters.Add("@AnioPeriodo", SqlDbType.Char, 4).Value = egreso.AnioPeriodo;
					oComando.Parameters.Add("@MesPeriodo", SqlDbType.Char, 2).Value = egreso.MesPeriodo;
					oComando.Parameters.Add("@numVoucher", SqlDbType.VarChar, 9).Value = egreso.numVoucher;
					oComando.Parameters.Add("@idComprobante", SqlDbType.Char, 2).Value = egreso.idComprobante;
					oComando.Parameters.Add("@numFile", SqlDbType.Char, 2).Value = egreso.numFile;
					oComando.Parameters.Add("@UsuarioModificacion", SqlDbType.VarChar, 20).Value = egreso.UsuarioModificacion;

                    oConexion.Open();
                    oComando.ExecuteNonQuery();
                }
            }

            return egreso;
        }        

        public Int32 EliminarEgreso(Int32 idEmpresa, Int32 idLocal, Int32 idNumEgreso)
        {
            Int32 resp = 0;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_EliminarEgreso", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
					oComando.Parameters.Add("@idLocal", SqlDbType.Int).Value = idLocal;
					oComando.Parameters.Add("@idNumEgreso", SqlDbType.Int).Value = idNumEgreso;

                    oConexion.Open();
                    resp = oComando.ExecuteNonQuery();
                }
            }

            return resp;
        }

        public List<EgresoE> ListarEgreso()
        {
            List<EgresoE> listaEntidad = new List<EgresoE>();

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ListarEgreso", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
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
        
        public EgresoE ObtenerEgreso(Int32 idEmpresa, Int32 idLocal, Int32 idNumEgreso)
        {        
            EgresoE egreso = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ObtenerEgreso", oConexion))
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
                            egreso = LlenarEntidad(oReader);
                        }
                    }
                }
            }

            return egreso;
        }

        public List<EgresoE> ListarEgresosProgramaPago(Int32 idEmpresa, Int32 Banco, DateTime Desde, DateTime Hasta)
        {
            List<EgresoE> listaEntidad = new List<EgresoE>();

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ListarEgresosProgramaPago", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@Banco", SqlDbType.Int).Value = Banco;
                    oComando.Parameters.Add("@Desde", SqlDbType.SmallDateTime).Value = Desde;
                    oComando.Parameters.Add("@Hasta", SqlDbType.SmallDateTime).Value = Hasta;

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