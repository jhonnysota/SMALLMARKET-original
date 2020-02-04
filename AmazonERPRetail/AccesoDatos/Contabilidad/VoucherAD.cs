using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

using Entidades.Contabilidad;
using AccesoDatos.Util;

namespace AccesoDatos.Contabilidad
{
    public class VoucherAD : DbConection
    {

        public VoucherE LlenarEntidad(IDataReader oReader)
        {
            VoucherE voucher = new VoucherE();

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idEmpresa'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                voucher.idEmpresa = oReader["idEmpresa"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idEmpresa"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idLocal'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                voucher.idLocal = oReader["idLocal"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idLocal"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='AnioPeriodo'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                voucher.AnioPeriodo = oReader["AnioPeriodo"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["AnioPeriodo"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='MesPeriodo'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                voucher.MesPeriodo = oReader["MesPeriodo"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["MesPeriodo"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='numVoucher'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                voucher.numVoucher = oReader["numVoucher"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["numVoucher"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idComprobante'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                voucher.idComprobante = oReader["idComprobante"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["idComprobante"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='numFile'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                voucher.numFile = oReader["numFile"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["numFile"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='fecTransferencia'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				voucher.fecTransferencia = oReader["fecTransferencia"] == DBNull.Value ? (Nullable<DateTime>)null : Convert.ToDateTime(oReader["fecTransferencia"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='numItems'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				voucher.numItems = oReader["numItems"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["numItems"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idMoneda'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				voucher.idMoneda = oReader["idMoneda"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["idMoneda"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='fecOperacion'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				voucher.fecOperacion = oReader["fecOperacion"] == DBNull.Value ? (Nullable<DateTime>)null : Convert.ToDateTime(oReader["fecOperacion"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='fecDocumento'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                voucher.fecDocumento = oReader["fecDocumento"] == DBNull.Value ? (Nullable<DateTime>)null : Convert.ToDateTime(oReader["fecDocumento"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='impDebeSoles'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				voucher.impDebeSoles = oReader["impDebeSoles"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["impDebeSoles"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='impHaberSoles'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				voucher.impHaberSoles = oReader["impHaberSoles"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["impHaberSoles"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='impDebeDolares'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				voucher.impDebeDolares = oReader["impDebeDolares"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["impDebeDolares"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='impHaberDolares'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				voucher.impHaberDolares = oReader["impHaberDolares"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["impHaberDolares"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='impMonOrigDeb'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				voucher.impMonOrigDeb = oReader["impMonOrigDeb"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["impMonOrigDeb"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='impMonOrigHab'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				voucher.impMonOrigHab = oReader["impMonOrigHab"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["impMonOrigHab"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='GlosaGeneral'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				voucher.GlosaGeneral = oReader["GlosaGeneral"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["GlosaGeneral"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='indEstado'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				voucher.indEstado = oReader["indEstado"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["indEstado"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='tipCambio'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				voucher.tipCambio = oReader["tipCambio"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["tipCambio"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='RazonSocial'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				voucher.RazonSocial = oReader["RazonSocial"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["RazonSocial"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='numDocumentoPresu'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				voucher.numDocumentoPresu = oReader["numDocumentoPresu"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["numDocumentoPresu"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='indHojaCosto'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				voucher.indHojaCosto = oReader["indHojaCosto"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["indHojaCosto"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='numHojaCosto'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				voucher.numHojaCosto = oReader["numHojaCosto"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["numHojaCosto"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='numOrdenCompra'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				voucher.numOrdenCompra = oReader["numOrdenCompra"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["numOrdenCompra"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='sistema'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				voucher.sistema = oReader["sistema"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["sistema"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='EsAutomatico'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                voucher.EsAutomatico = oReader["EsAutomatico"] == DBNull.Value ? false : Convert.ToBoolean(oReader["EsAutomatico"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='UsuarioRegistro'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				voucher.UsuarioRegistro = oReader["UsuarioRegistro"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["UsuarioRegistro"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='FechaRegistro'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				voucher.FechaRegistro = oReader["FechaRegistro"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["FechaRegistro"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='UsuarioModificacion'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				voucher.UsuarioModificacion = oReader["UsuarioModificacion"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["UsuarioModificacion"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='FechaModificacion'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				voucher.FechaModificacion = oReader["FechaModificacion"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["FechaModificacion"]);
			
            // Extensiones
            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='desFile'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                voucher.desFile = oReader["desFile"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["desFile"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='desMoneda'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                voucher.desMoneda = oReader["desMoneda"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["desMoneda"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='descomprobante'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                voucher.descomprobante = oReader["descomprobante"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["descomprobante"]);

            

            return  voucher;        
        }

        public VoucherE InsertarVoucher(VoucherE voucher)
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_InsertarVoucher", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = voucher.idEmpresa;
                    oComando.Parameters.Add("@idLocal", SqlDbType.Int).Value = voucher.idLocal;
                    oComando.Parameters.Add("@AnioPeriodo", SqlDbType.Char, 4).Value = voucher.AnioPeriodo;
                    oComando.Parameters.Add("@MesPeriodo", SqlDbType.Char, 2).Value = voucher.MesPeriodo;
                    oComando.Parameters.Add("@numVoucher", SqlDbType.VarChar, 9).Value = voucher.numVoucher;
                    oComando.Parameters.Add("@idComprobante", SqlDbType.Char, 2).Value = voucher.idComprobante;
                    oComando.Parameters.Add("@numFile", SqlDbType.Char, 2).Value = voucher.numFile;
                    oComando.Parameters.Add("@fecTransferencia", SqlDbType.SmallDateTime).Value = voucher.fecTransferencia;
                    oComando.Parameters.Add("@numItems", SqlDbType.Int).Value = voucher.numItems;
                    oComando.Parameters.Add("@idMoneda", SqlDbType.Char, 2).Value = voucher.idMoneda;
                    oComando.Parameters.Add("@fecOperacion", SqlDbType.SmallDateTime).Value = voucher.fecOperacion;
                    oComando.Parameters.Add("@fecDocumento", SqlDbType.SmallDateTime).Value = voucher.fecDocumento;
                    oComando.Parameters.Add("@impDebeSoles", SqlDbType.Decimal).Value = voucher.impDebeSoles;
                    oComando.Parameters.Add("@impHaberSoles", SqlDbType.Decimal).Value = voucher.impHaberSoles;
                    oComando.Parameters.Add("@impDebeDolares", SqlDbType.Decimal).Value = voucher.impDebeDolares;
                    oComando.Parameters.Add("@impHaberDolares", SqlDbType.Decimal).Value = voucher.impHaberDolares;
                    oComando.Parameters.Add("@GlosaGeneral", SqlDbType.VarChar, 500).Value = voucher.GlosaGeneral;
                    oComando.Parameters.Add("@indEstado", SqlDbType.Char, 1).Value = voucher.indEstado;
                    oComando.Parameters.Add("@tipCambio", SqlDbType.Decimal).Value = voucher.tipCambio;
                    oComando.Parameters.Add("@RazonSocial", SqlDbType.VarChar, 50).Value = voucher.RazonSocial;
                    oComando.Parameters.Add("@numDocumentoPresu", SqlDbType.VarChar, 40).Value = voucher.numDocumentoPresu;
                    oComando.Parameters.Add("@indHojaCosto", SqlDbType.Char, 1).Value = voucher.indHojaCosto;
                    oComando.Parameters.Add("@numHojaCosto", SqlDbType.VarChar, 10).Value = voucher.numHojaCosto;
                    oComando.Parameters.Add("@numOrdenCompra", SqlDbType.VarChar, 7).Value = voucher.numOrdenCompra;
                    oComando.Parameters.Add("@sistema", SqlDbType.VarChar, 5).Value = voucher.sistema;
                    oComando.Parameters.Add("@EsAutomatico", SqlDbType.Bit).Value = voucher.EsAutomatico;
                    oComando.Parameters.Add("@impMonOrigDeb", SqlDbType.Decimal).Value = voucher.impMonOrigHab;
                    oComando.Parameters.Add("@impMonOrigHab", SqlDbType.Decimal).Value = voucher.impMonOrigHab;
                    oComando.Parameters.Add("@UsuarioRegistro", SqlDbType.VarChar, 20).Value = voucher.UsuarioRegistro;

                    oConexion.Open();
                    oComando.ExecuteNonQuery();
                }
            }

            return voucher;        
        }
        
        public VoucherE ActualizarVoucher(VoucherE voucher)
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ActualizarVoucher", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = voucher.idEmpresa;
                    oComando.Parameters.Add("@idLocal", SqlDbType.Int).Value = voucher.idLocal;
                    oComando.Parameters.Add("@AnioPeriodo", SqlDbType.Char, 4).Value = voucher.AnioPeriodo;
                    oComando.Parameters.Add("@MesPeriodo", SqlDbType.Char, 2).Value = voucher.MesPeriodo;
                    oComando.Parameters.Add("@numVoucher", SqlDbType.VarChar, 9).Value = voucher.numVoucher;
                    oComando.Parameters.Add("@idComprobante", SqlDbType.Char, 2).Value = voucher.idComprobante;
                    oComando.Parameters.Add("@numFile", SqlDbType.Char, 2).Value = voucher.numFile;
                    oComando.Parameters.Add("@fecTransferencia", SqlDbType.SmallDateTime).Value = voucher.fecTransferencia;
                    oComando.Parameters.Add("@numItems", SqlDbType.Int).Value = voucher.numItems;
                    oComando.Parameters.Add("@idMoneda", SqlDbType.Char, 2).Value = voucher.idMoneda;
                    oComando.Parameters.Add("@fecOperacion", SqlDbType.SmallDateTime).Value = voucher.fecOperacion;
                    oComando.Parameters.Add("@fecDocumento", SqlDbType.SmallDateTime).Value = voucher.fecDocumento;
                    oComando.Parameters.Add("@impDebeSoles", SqlDbType.Decimal).Value = voucher.impDebeSoles;
                    oComando.Parameters.Add("@impHaberSoles", SqlDbType.Decimal).Value = voucher.impHaberSoles;
                    oComando.Parameters.Add("@impDebeDolares", SqlDbType.Decimal).Value = voucher.impDebeDolares;
                    oComando.Parameters.Add("@impHaberDolares", SqlDbType.Decimal).Value = voucher.impHaberDolares;
                    oComando.Parameters.Add("@GlosaGeneral", SqlDbType.VarChar, 500).Value = voucher.GlosaGeneral;
                    oComando.Parameters.Add("@indEstado", SqlDbType.Char, 1).Value = voucher.indEstado;
                    oComando.Parameters.Add("@tipCambio", SqlDbType.Decimal).Value = voucher.tipCambio;
                    oComando.Parameters.Add("@RazonSocial", SqlDbType.VarChar, 50).Value = voucher.RazonSocial;
                    oComando.Parameters.Add("@numDocumentoPresu", SqlDbType.VarChar, 40).Value = voucher.numDocumentoPresu;
                    oComando.Parameters.Add("@indHojaCosto", SqlDbType.Char, 1).Value = voucher.indHojaCosto;
                    oComando.Parameters.Add("@numHojaCosto", SqlDbType.VarChar, 10).Value = voucher.numHojaCosto;
                    oComando.Parameters.Add("@numOrdenCompra", SqlDbType.VarChar, 7).Value = voucher.numOrdenCompra;
                    oComando.Parameters.Add("@sistema", SqlDbType.VarChar, 5).Value = voucher.sistema;
                    oComando.Parameters.Add("@impMonOrigDeb", SqlDbType.Decimal).Value = voucher.impMonOrigHab;
                    oComando.Parameters.Add("@impMonOrigHab", SqlDbType.Decimal).Value = voucher.impMonOrigHab;
                    //oComando.Parameters.Add("@EsAutomatico", SqlDbType.Bit).Value = voucher.EsAutomatico;
                    oComando.Parameters.Add("@UsuarioModificacion", SqlDbType.VarChar, 20).Value = voucher.UsuarioModificacion;

                    oConexion.Open();
                    oComando.ExecuteNonQuery();
                }
            }

            return voucher;
        }        

        public Int32 EliminarVoucher(Int32 idEmpresa, Int32 idLocal, String AnioPeriodo, String MesPeriodo, String numVoucher, String idComprobantes, String numFile)
        {
            Int32 resp = 0;
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_EliminarVoucher", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.CommandTimeout = 0;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@idLocal", SqlDbType.Int).Value = idLocal;
                    oComando.Parameters.Add("@AnioPeriodo", SqlDbType.Char, 4).Value = AnioPeriodo;
                    oComando.Parameters.Add("@MesPeriodo", SqlDbType.Char, 2).Value = MesPeriodo;
                    oComando.Parameters.Add("@numVoucher", SqlDbType.VarChar, 9).Value = numVoucher;
                    oComando.Parameters.Add("@idComprobante", SqlDbType.Char, 2).Value = idComprobantes;
                    oComando.Parameters.Add("@numFile", SqlDbType.Char, 2).Value = numFile;

                    oConexion.Open();
                    resp = oComando.ExecuteNonQuery();
                }
            }

            return resp;
        }

        public Int32 EliminarVoucherPorPeriodos(Int32 idEmpresa, Int32 idLocal, String idComprobante, String numFile, String Periodo)
        {
            Int32 resp = 0;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_EliminarVoucherPorPeriodos", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@idLocal", SqlDbType.Int).Value = idLocal;
                    oComando.Parameters.Add("@idComprobante", SqlDbType.VarChar, 2).Value = idComprobante;
                    oComando.Parameters.Add("@numFile", SqlDbType.VarChar, 2).Value = numFile;
                    oComando.Parameters.Add("@Periodo", SqlDbType.Char, 6).Value = Periodo;

                    oConexion.Open();
                    resp = oComando.ExecuteNonQuery();
                }
            }

            return resp;
        }

        public Int32 EliminarVoucherPorPeriodoyFechas(Int32 idEmpresa, Int32 idLocal, String AnioPeriodo, String MesPeriodo, String idComprobante, String numFile, DateTime fecIni, DateTime fecFin)
        {
            Int32 resp = 0;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_EliminarVoucherPorPeriodoyFechas", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@idLocal", SqlDbType.Int).Value = idLocal;
                    oComando.Parameters.Add("@AnioPeriodo", SqlDbType.Char, 4).Value = AnioPeriodo;
                    oComando.Parameters.Add("@MesPeriodo", SqlDbType.Char, 2).Value = MesPeriodo;
                    oComando.Parameters.Add("@idComprobante", SqlDbType.VarChar, 2).Value = idComprobante;
                    oComando.Parameters.Add("@numFile", SqlDbType.VarChar, 2).Value = numFile;
                    oComando.Parameters.Add("@fecIni", SqlDbType.DateTime).Value = fecIni;
                    oComando.Parameters.Add("@fecFin", SqlDbType.DateTime).Value = fecFin;

                    oConexion.Open();
                    resp = oComando.ExecuteNonQuery();
                }
            }

            return resp;
        }

        public Int32 AnularVoucher(Int32 idEmpresa, Int32 idLocal, String AnioPeriodo, String MesPeriodo, String numVoucher, String idComprobantes, String numFile, String UsuarioAnula, String Tipo)
        {
            Int32 resp = 0;
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_AnularVoucher", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@idLocal", SqlDbType.Int).Value = idLocal;
                    oComando.Parameters.Add("@AnioPeriodo", SqlDbType.Char, 4).Value = AnioPeriodo;
                    oComando.Parameters.Add("@MesPeriodo", SqlDbType.Char, 2).Value = MesPeriodo;
                    oComando.Parameters.Add("@numVoucher", SqlDbType.VarChar, 9).Value = numVoucher;
                    oComando.Parameters.Add("@idComprobante", SqlDbType.Char, 2).Value = idComprobantes;
                    oComando.Parameters.Add("@numFile", SqlDbType.Char, 2).Value = numFile;
                    oComando.Parameters.Add("@UsuarioAnula", SqlDbType.VarChar, 20).Value = UsuarioAnula;
                    oComando.Parameters.Add("@Tipo", SqlDbType.Char, 1).Value = Tipo;

                    oConexion.Open();
                    resp = oComando.ExecuteNonQuery();
                }
            }

            return resp;
        }

        public List<VoucherE> ListarVoucher(Int32 idEmpresa, Int32 idLocal, String AnioPeriodo, String MesPeriodo, String idComprobante, String numFile)
        {
            List<VoucherE> ListarVoucher = new List<VoucherE>();
            VoucherE voucher = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ListarVoucher", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@idLocal", SqlDbType.Int).Value = idLocal;
                    oComando.Parameters.Add("@AnioPeriodo", SqlDbType.Char, 4).Value = AnioPeriodo;
                    oComando.Parameters.Add("@MesPeriodo", SqlDbType.Char, 2).Value = MesPeriodo;
                    oComando.Parameters.Add("@idComprobante", SqlDbType.Char, 2).Value = idComprobante;
                    oComando.Parameters.Add("@numFile", SqlDbType.Char, 2).Value = numFile;

                    oConexion.Open();
                    
                    using (SqlDataReader oReader = oComando.ExecuteReader())
                    {
                        while (oReader.Read())
                        {
                            voucher = LlenarEntidad(oReader);
                            ListarVoucher.Add(voucher);
                        }
                    }
                }
            }

            return ListarVoucher;
        }

        public List<VoucherE> ListarVoucherNumVoucher(Int32 idEmpresa, Int32 idLocal, String AnioPeriodo, String MesPeriodo, String idComprobante, String numFile, String numVoucher)
        {
            List<VoucherE> ListarVoucher = new List<VoucherE>();
            VoucherE voucher = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ListarVoucherNumVoucher", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@idLocal", SqlDbType.Int).Value = idLocal;
                    oComando.Parameters.Add("@AnioPeriodo", SqlDbType.Char, 4).Value = AnioPeriodo;
                    oComando.Parameters.Add("@MesPeriodo", SqlDbType.Char, 2).Value = MesPeriodo;
                    oComando.Parameters.Add("@idComprobante", SqlDbType.Char, 2).Value = idComprobante;
                    oComando.Parameters.Add("@numFile", SqlDbType.Char, 2).Value = numFile;
                    oComando.Parameters.Add("@numVoucher", SqlDbType.VarChar, 9).Value = numVoucher;

                    oConexion.Open();

                    using (SqlDataReader oReader = oComando.ExecuteReader())
                    {
                        while (oReader.Read())
                        {
                            voucher = LlenarEntidad(oReader);
                            ListarVoucher.Add(voucher);
                        }
                    }
                }
            }

            return ListarVoucher;
        }

        public VoucherE ObtenerVoucherPorCodigo(Int32 idEmpresa, Int32 idLocal, String AnioPeriodo, String MesPeriodo, String numVoucher, String idComprobantes, String numFile)
        {        
            VoucherE voucher = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ObtenerVoucher", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@idLocal", SqlDbType.Int).Value = idLocal;
                    oComando.Parameters.Add("@AnioPeriodo", SqlDbType.Char, 4).Value = AnioPeriodo;
                    oComando.Parameters.Add("@MesPeriodo", SqlDbType.Char, 2).Value = MesPeriodo;
					oComando.Parameters.Add("@numVoucher", SqlDbType.VarChar, 9).Value = numVoucher;
                    oComando.Parameters.Add("@idComprobante", SqlDbType.Char, 2).Value = idComprobantes;
                    oComando.Parameters.Add("@numFile", SqlDbType.Char, 2).Value = numFile;

                    oConexion.Open();
                    
                    using (SqlDataReader oReader = oComando.ExecuteReader())
                    {
                        while (oReader.Read())
                        {
                            voucher = LlenarEntidad(oReader);
                        }
                    }
                }
            }

            return voucher;
        }

        public Int32 GenerarNumVoucher(Int32 idEmpresa, Int32 idLocal, String AnioPeriodo, String MesPeriodo, String idComprobantes, String numFile)
        {
            Int32 Correlativo = 0;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_GenerarNumVoucher", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@idLocal", SqlDbType.Int).Value = idLocal;
                    oComando.Parameters.Add("@AnioPeriodo", SqlDbType.Char, 4).Value = AnioPeriodo;
                    oComando.Parameters.Add("@MesPeriodo", SqlDbType.Char, 2).Value = MesPeriodo;
                    oComando.Parameters.Add("@idComprobante", SqlDbType.Char, 2).Value = idComprobantes;
                    oComando.Parameters.Add("@numFile", SqlDbType.Char, 2).Value = numFile;
                    SqlParameter numVoucher = new SqlParameter("@numVoucher", SqlDbType.Int);
                    numVoucher.Direction = ParameterDirection.ReturnValue;
                    oComando.Parameters.Add(numVoucher);

                    oConexion.Open();
                    oComando.ExecuteNonQuery();
                    Correlativo = Int32.Parse(oComando.Parameters["@numVoucher"].Value.ToString());
                }
            }

            return Correlativo;
        }

        public VoucherE ValidaDocContableExistente(Int32 idEmpresa, Int32 idLocal, String AnioPeriodo, String MesPeriodo, String numVoucher, String idComprobantes, String numFile, String serDocumento, String numDocumento, Int32 idPersona, String idDocumento)
        {
            VoucherE voucher = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ValidaDocContableExistente", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@idLocal", SqlDbType.Int).Value = idLocal;
                    oComando.Parameters.Add("@AnioPeriodo", SqlDbType.Char, 4).Value = AnioPeriodo;
                    oComando.Parameters.Add("@MesPeriodo", SqlDbType.Char, 2).Value = MesPeriodo;
                    oComando.Parameters.Add("@numVoucher", SqlDbType.VarChar, 9).Value = numVoucher;
                    oComando.Parameters.Add("@idComprobante", SqlDbType.Char, 2).Value = idComprobantes;
                    oComando.Parameters.Add("@numFile", SqlDbType.Char, 2).Value = numFile;
                    oComando.Parameters.Add("@serDocumento", SqlDbType.VarChar, 10).Value = serDocumento;
                    oComando.Parameters.Add("@numDocumento", SqlDbType.VarChar, 20).Value = numDocumento;
                    oComando.Parameters.Add("@idPersona", SqlDbType.Int).Value = idPersona;
                    oComando.Parameters.Add("@idDocumento", SqlDbType.VarChar, 2).Value = idDocumento;

                    oConexion.Open();

                    using (SqlDataReader oReader = oComando.ExecuteReader())
                    {
                        while (oReader.Read())
                        {
                            voucher = LlenarEntidad(oReader);
                        }
                    }
                }
            }

            return voucher;
        }

        public Int32 TransferirVentasVoucher(Int32 idEmpresa, Int32 idLocal, DateTime fecIni, DateTime fecFin, String Usuario)
        {
            Int32 Resp = 0;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_TransferirVentasVoucher", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.CommandTimeout = 0;

                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@idLocal", SqlDbType.Int).Value = idLocal;
                    oComando.Parameters.Add("@fecIni", SqlDbType.SmallDateTime).Value = fecIni;
                    oComando.Parameters.Add("@fecFin", SqlDbType.SmallDateTime).Value = fecFin;
                    oComando.Parameters.Add("@Usuario", SqlDbType.VarChar, 20).Value = Usuario;

                    oConexion.Open();
                    Resp = oComando.ExecuteNonQuery();
                }
            }

            return Resp;
        }

        public Int32 GeneraAsientoVenta(Int32 idEmpresa, Int32 idLocal, String TipoDocu, String Serie, String Numero, String Usuario)
        {
            Int32 Resp = 0;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_GeneraAsientoVenta", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@idLocal", SqlDbType.Int).Value = idLocal;
                    oComando.Parameters.Add("@TipoDocu", SqlDbType.VarChar, 2).Value = TipoDocu;
                    oComando.Parameters.Add("@Serie", SqlDbType.VarChar, 20).Value = Serie;
                    oComando.Parameters.Add("@Numero", SqlDbType.VarChar, 20).Value = Numero;
                    oComando.Parameters.Add("@Usuario", SqlDbType.VarChar, 20).Value = Usuario;

                    oConexion.Open();
                    Resp = oComando.ExecuteNonQuery();
                }
            }

            return Resp;
        }

        public void TriggerVouchers(Boolean Habilita)
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_TriggerVouchers", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@Habilita", SqlDbType.Bit).Value = Habilita;

                    oConexion.Open();
                    oComando.ExecuteNonQuery();
                }
            }
        }

    }
}