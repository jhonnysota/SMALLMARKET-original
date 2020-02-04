using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

using Entidades.Contabilidad;
using AccesoDatos.Util;

namespace AccesoDatos.Contabilidad
{
    public class VoucherEnlaceAD : DbConection
    {

        public VoucherEnlaceE LlenarEntidad(IDataReader oReader)
        {
            VoucherEnlaceE voucherenlace = new VoucherEnlaceE();
            
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idEmpresa'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				voucherenlace.idEmpresa = oReader["idEmpresa"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idEmpresa"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idLocal'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				voucherenlace.idLocal = oReader["idLocal"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idLocal"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='AnioPeriodo'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				voucherenlace.AnioPeriodo = oReader["AnioPeriodo"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["AnioPeriodo"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='MesPeriodo'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				voucherenlace.MesPeriodo = oReader["MesPeriodo"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["MesPeriodo"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='numVoucher'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				voucherenlace.numVoucher = oReader["numVoucher"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["numVoucher"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idComprobante'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				voucherenlace.idComprobante = oReader["idComprobante"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["idComprobante"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='numFile'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				voucherenlace.numFile = oReader["numFile"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["numFile"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='numItem'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				voucherenlace.numItem = oReader["numItem"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["numItem"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idEmpresaD'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				voucherenlace.idEmpresaD = oReader["idEmpresaD"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idEmpresaD"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idLocalD'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				voucherenlace.idLocalD = oReader["idLocalD"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idLocalD"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='AnioPeriodoD'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				voucherenlace.AnioPeriodoD = oReader["AnioPeriodoD"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["AnioPeriodoD"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='MesPeriodoD'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				voucherenlace.MesPeriodoD = oReader["MesPeriodoD"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["MesPeriodoD"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='numVoucherD'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				voucherenlace.numVoucherD = oReader["numVoucherD"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["numVoucherD"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idComprobanteD'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				voucherenlace.idComprobanteD = oReader["idComprobanteD"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["idComprobanteD"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='numFileD'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				voucherenlace.numFileD = oReader["numFileD"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["numFileD"]);
			

            return  voucherenlace;        
        }

        public VoucherEnlaceE InsertarVoucherEnlace(VoucherEnlaceE voucherenlace)
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_InsertarVoucherEnlace", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = voucherenlace.idEmpresa;
					oComando.Parameters.Add("@idLocal", SqlDbType.Int).Value = voucherenlace.idLocal;
					oComando.Parameters.Add("@AnioPeriodo", SqlDbType.Char, 4).Value = voucherenlace.AnioPeriodo;
					oComando.Parameters.Add("@MesPeriodo", SqlDbType.Char, 2).Value = voucherenlace.MesPeriodo;
					oComando.Parameters.Add("@numVoucher", SqlDbType.Char, 9).Value = voucherenlace.numVoucher;
					oComando.Parameters.Add("@idComprobante", SqlDbType.Char, 2).Value = voucherenlace.idComprobante;
					oComando.Parameters.Add("@numFile", SqlDbType.Char, 2).Value = voucherenlace.numFile;
					oComando.Parameters.Add("@numItem", SqlDbType.VarChar, 5).Value = voucherenlace.numItem;
					oComando.Parameters.Add("@idEmpresaD", SqlDbType.Int).Value = voucherenlace.idEmpresaD;
					oComando.Parameters.Add("@idLocalD", SqlDbType.Int).Value = voucherenlace.idLocalD;
					oComando.Parameters.Add("@AnioPeriodoD", SqlDbType.Char, 4).Value = voucherenlace.AnioPeriodoD;
					oComando.Parameters.Add("@MesPeriodoD", SqlDbType.Char, 2).Value = voucherenlace.MesPeriodoD;
					oComando.Parameters.Add("@numVoucherD", SqlDbType.Char, 9).Value = voucherenlace.numVoucherD;
					oComando.Parameters.Add("@idComprobanteD", SqlDbType.Char, 2).Value = voucherenlace.idComprobanteD;
					oComando.Parameters.Add("@numFileD", SqlDbType.Char, 2).Value = voucherenlace.numFileD;

                    oConexion.Open();
                    oComando.ExecuteNonQuery();
                }
            }

            return voucherenlace;
        }
        
     //   public VoucherEnlaceE ActualizarVoucherEnlace(VoucherEnlaceE voucherenlace)
     //   {
     //       using (SqlConnection oConexion = ConexionSql())
     //       {
     //           using (SqlCommand oComando = new SqlCommand("retail.usp_ActualizarVoucherEnlace", oConexion))
     //           {
     //               oComando.CommandType = CommandType.StoredProcedure;

     //               oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = voucherenlace.idEmpresa;
					//oComando.Parameters.Add("@idLocal", SqlDbType.Int).Value = voucherenlace.idLocal;
					//oComando.Parameters.Add("@AnioPeriodo", SqlDbType.Char, 4).Value = voucherenlace.AnioPeriodo;
					//oComando.Parameters.Add("@MesPeriodo", SqlDbType.Char, 2).Value = voucherenlace.MesPeriodo;
					//oComando.Parameters.Add("@numVoucher", SqlDbType.Char, 9).Value = voucherenlace.numVoucher;
					//oComando.Parameters.Add("@idComprobante", SqlDbType.Char, 2).Value = voucherenlace.idComprobante;
					//oComando.Parameters.Add("@numFile", SqlDbType.Char, 2).Value = voucherenlace.numFile;
					//oComando.Parameters.Add("@numItem", SqlDbType.VarChar, 5).Value = voucherenlace.numItem;
					//oComando.Parameters.Add("@idEmpresaD", SqlDbType.Int).Value = voucherenlace.idEmpresaD;
					//oComando.Parameters.Add("@idLocalD", SqlDbType.Int).Value = voucherenlace.idLocalD;
					//oComando.Parameters.Add("@AnioPeriodoD", SqlDbType.Char, 4).Value = voucherenlace.AnioPeriodoD;
					//oComando.Parameters.Add("@MesPeriodoD", SqlDbType.Char, 2).Value = voucherenlace.MesPeriodoD;
					//oComando.Parameters.Add("@numVoucherD", SqlDbType.Char, 9).Value = voucherenlace.numVoucherD;
					//oComando.Parameters.Add("@idComprobanteD", SqlDbType.Char, 2).Value = voucherenlace.idComprobanteD;
					//oComando.Parameters.Add("@numFileD", SqlDbType.Char, 2).Value = voucherenlace.numFileD;

     //               oConexion.Open();
     //               oComando.ExecuteNonQuery();
     //               oConexion.Close();
     //           }
     //       }

     //       return voucherenlace;
     //   }        

        public int EliminarVoucherEnlace(Int32 idEmpresa, Int32 idLocal, String AnioPeriodo, String MesPeriodo, String numVoucher, String idComprobante, String numFile, String numItem)//, Int32 idEmpresaD, Int32 idLocalD, String AnioPeriodoD, String MesPeriodoD, String numVoucherD, String idComprobanteD, String numFileD)
        {
            int resp = 0;
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_EliminarVoucherEnlace", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
					oComando.Parameters.Add("@idLocal", SqlDbType.Int).Value = idLocal;
					oComando.Parameters.Add("@AnioPeriodo", SqlDbType.Char, 4).Value = AnioPeriodo;
					oComando.Parameters.Add("@MesPeriodo", SqlDbType.Char, 2).Value = MesPeriodo;
					oComando.Parameters.Add("@numVoucher", SqlDbType.Char, 9).Value = numVoucher;
					oComando.Parameters.Add("@idComprobante", SqlDbType.Char, 2).Value = idComprobante;
					oComando.Parameters.Add("@numFile", SqlDbType.Char, 2).Value = numFile;
					oComando.Parameters.Add("@numItem", SqlDbType.VarChar, 5).Value = numItem;
					//oComando.Parameters.Add("@idEmpresaD", SqlDbType.Int).Value = idEmpresaD;
					//oComando.Parameters.Add("@idLocalD", SqlDbType.Int).Value = idLocalD;
					//oComando.Parameters.Add("@AnioPeriodoD", SqlDbType.Char, 4).Value = AnioPeriodoD;
					//oComando.Parameters.Add("@MesPeriodoD", SqlDbType.Char, 2).Value = MesPeriodoD;
					//oComando.Parameters.Add("@numVoucherD", SqlDbType.Char, 9).Value = numVoucherD;
					//oComando.Parameters.Add("@idComprobanteD", SqlDbType.Char, 2).Value = idComprobanteD;
					//oComando.Parameters.Add("@numFileD", SqlDbType.Char, 2).Value = numFileD;

                    oConexion.Open();
                    resp = oComando.ExecuteNonQuery();
                }
            }

            return resp;
        }

        public List<VoucherEnlaceE> ListarVoucherEnlace()
        {
           List<VoucherEnlaceE> listaEntidad = new List<VoucherEnlaceE>();
           VoucherEnlaceE entidad = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ListarVoucherEnlace", oConexion))
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
        
        public VoucherEnlaceE ObtenerVoucherEnlace(Int32 idEmpresa, Int32 idLocal, String AnioPeriodo, String MesPeriodo, String numVoucher, String idComprobante, String numFile)//, String numItem, Int32 idEmpresaD, Int32 idLocalD, String AnioPeriodoD, String MesPeriodoD, String numVoucherD, String idComprobanteD, String numFileD)
        {        
            VoucherEnlaceE voucherenlace = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ObtenerVoucherEnlace", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
					oComando.Parameters.Add("@idLocal", SqlDbType.Int).Value = idLocal;
					oComando.Parameters.Add("@AnioPeriodo", SqlDbType.Char, 4).Value = AnioPeriodo;
					oComando.Parameters.Add("@MesPeriodo", SqlDbType.Char, 2).Value = MesPeriodo;
					oComando.Parameters.Add("@numVoucher", SqlDbType.Char, 9).Value = numVoucher;
					oComando.Parameters.Add("@idComprobante", SqlDbType.Char, 2).Value = idComprobante;
					oComando.Parameters.Add("@numFile", SqlDbType.Char, 2).Value = numFile;
					//oComando.Parameters.Add("@numItem", SqlDbType.VarChar, 5).Value = numItem;
					//oComando.Parameters.Add("@idEmpresaD", SqlDbType.Int).Value = idEmpresaD;
					//oComando.Parameters.Add("@idLocalD", SqlDbType.Int).Value = idLocalD;
					//oComando.Parameters.Add("@AnioPeriodoD", SqlDbType.Char, 4).Value = AnioPeriodoD;
					//oComando.Parameters.Add("@MesPeriodoD", SqlDbType.Char, 2).Value = MesPeriodoD;
					//oComando.Parameters.Add("@numVoucherD", SqlDbType.Char, 9).Value = numVoucherD;
					//oComando.Parameters.Add("@idComprobanteD", SqlDbType.Char, 2).Value = idComprobanteD;
					//oComando.Parameters.Add("@numFileD", SqlDbType.Char, 2).Value = numFileD;

                    oConexion.Open();
                    
                    using (SqlDataReader oReader = oComando.ExecuteReader())
                    {
                        while (oReader.Read())
                        {
                            voucherenlace = LlenarEntidad(oReader);
                        }
                    }
                }
            }

            return voucherenlace;
        }

    }
}