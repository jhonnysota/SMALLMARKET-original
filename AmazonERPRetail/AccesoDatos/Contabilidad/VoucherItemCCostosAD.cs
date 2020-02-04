using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

using Entidades.Contabilidad;
using AccesoDatos.Util;

namespace AccesoDatos.Contabilidad
{
    public class VoucherItemCCostosAD : DbConection
    {
        
        public VoucherItemCCostosE LlenarEntidad(IDataReader oReader)
        {
            VoucherItemCCostosE voucheritemccostos = new VoucherItemCCostosE();
            
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idEmpresa'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				voucheritemccostos.idEmpresa = oReader["idEmpresa"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idEmpresa"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idLocal'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				voucheritemccostos.idLocal = oReader["idLocal"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idLocal"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='AnioPeriodo'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				voucheritemccostos.AnioPeriodo = oReader["AnioPeriodo"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["AnioPeriodo"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='MesPeriodo'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				voucheritemccostos.MesPeriodo = oReader["MesPeriodo"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["MesPeriodo"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='numVoucher'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				voucheritemccostos.numVoucher = oReader["numVoucher"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["numVoucher"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idComprobante'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				voucheritemccostos.idComprobante = oReader["idComprobante"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["idComprobante"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='numFile'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				voucheritemccostos.numFile = oReader["numFile"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["numFile"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='numItem'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				voucheritemccostos.numItem = oReader["numItem"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["numItem"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idCCostos'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				voucheritemccostos.idCCostos = oReader["idCCostos"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["idCCostos"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='ImporteOriginal'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				voucheritemccostos.ImporteOriginal = oReader["ImporteOriginal"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["ImporteOriginal"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Pocentaje'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				voucheritemccostos.Porcentaje = oReader["Pocentaje"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["Pocentaje"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='ImportePorcentaje'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				voucheritemccostos.ImportePorcentaje = oReader["ImportePorcentaje"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["ImportePorcentaje"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='UsuarioRegistro'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				voucheritemccostos.UsuarioRegistro = oReader["UsuarioRegistro"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["UsuarioRegistro"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='FechaRegistro'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				voucheritemccostos.FechaRegistro = oReader["FechaRegistro"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["FechaRegistro"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='UsuarioModificacion'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				voucheritemccostos.UsuarioModificacion = oReader["UsuarioModificacion"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["UsuarioModificacion"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='FechaModificacion'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				voucheritemccostos.FechaModificacion = oReader["FechaModificacion"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["FechaModificacion"]);


            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='desCCostos'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                voucheritemccostos.desCCostos = oReader["desCCostos"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["desCCostos"]);

            return  voucheritemccostos;        
        }

        public VoucherItemCCostosE InsertarVoucherItemCCostos(VoucherItemCCostosE voucheritemccostos)
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_InsertarVoucherItemCCostos", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;

                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = voucheritemccostos.idEmpresa;
					oComando.Parameters.Add("@idLocal", SqlDbType.Int).Value = voucheritemccostos.idLocal;
					oComando.Parameters.Add("@AnioPeriodo", SqlDbType.VarChar, 4).Value = voucheritemccostos.AnioPeriodo;
					oComando.Parameters.Add("@MesPeriodo", SqlDbType.Char, 4).Value = voucheritemccostos.MesPeriodo;
					oComando.Parameters.Add("@numVoucher", SqlDbType.VarChar, 9).Value = voucheritemccostos.numVoucher;
					oComando.Parameters.Add("@idComprobante", SqlDbType.Char, 2).Value = voucheritemccostos.idComprobante;
					oComando.Parameters.Add("@numFile", SqlDbType.Char, 4).Value = voucheritemccostos.numFile;
					oComando.Parameters.Add("@numItem", SqlDbType.VarChar, 5).Value = voucheritemccostos.numItem;
					oComando.Parameters.Add("@idCCostos", SqlDbType.VarChar, 10).Value = voucheritemccostos.idCCostos;
					oComando.Parameters.Add("@ImporteOriginal", SqlDbType.Decimal).Value = voucheritemccostos.ImporteOriginal;
					oComando.Parameters.Add("@Pocentaje", SqlDbType.Decimal).Value = voucheritemccostos.Porcentaje;
					oComando.Parameters.Add("@ImportePorcentaje", SqlDbType.Decimal).Value = voucheritemccostos.ImportePorcentaje;
					oComando.Parameters.Add("@UsuarioRegistro", SqlDbType.VarChar, 20).Value = voucheritemccostos.UsuarioRegistro;
                    //oComando.Parameters.Add("@FechaRegistro", SqlDbType.SmallDateTime).Value = voucheritemccostos.FechaRegistro;
                    //oComando.Parameters.Add("@UsuarioModificacion", SqlDbType.VarChar, 20).Value = voucheritemccostos.UsuarioModificacion;
					//oComando.Parameters.Add("@FechaModificacion", SqlDbType.SmallDateTime).Value = voucheritemccostos.FechaModificacion;

                    oConexion.Open();
                    oComando.ExecuteNonQuery();
                    oConexion.Close();
                }
            }

            return voucheritemccostos;
        }
        
        public VoucherItemCCostosE ActualizarVoucherItemCCostos(VoucherItemCCostosE voucheritemccostos)
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ActualizarVoucherItemCCostos", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;

                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = voucheritemccostos.idEmpresa;
					oComando.Parameters.Add("@idLocal", SqlDbType.Int).Value = voucheritemccostos.idLocal;
					oComando.Parameters.Add("@AnioPeriodo", SqlDbType.VarChar, 4).Value = voucheritemccostos.AnioPeriodo;
					oComando.Parameters.Add("@MesPeriodo", SqlDbType.Char, 4).Value = voucheritemccostos.MesPeriodo;
					oComando.Parameters.Add("@numVoucher", SqlDbType.VarChar, 9).Value = voucheritemccostos.numVoucher;
					oComando.Parameters.Add("@idComprobante", SqlDbType.Char, 2).Value = voucheritemccostos.idComprobante;
					oComando.Parameters.Add("@numFile", SqlDbType.Char, 4).Value = voucheritemccostos.numFile;
					oComando.Parameters.Add("@numItem", SqlDbType.VarChar, 5).Value = voucheritemccostos.numItem;
					oComando.Parameters.Add("@idCCostos", SqlDbType.VarChar, 10).Value = voucheritemccostos.idCCostos;
					oComando.Parameters.Add("@ImporteOriginal", SqlDbType.Decimal).Value = voucheritemccostos.ImporteOriginal;
					oComando.Parameters.Add("@Pocentaje", SqlDbType.Decimal).Value = voucheritemccostos.Porcentaje;
					oComando.Parameters.Add("@ImportePorcentaje", SqlDbType.Decimal).Value = voucheritemccostos.ImportePorcentaje;
                    //oComando.Parameters.Add("@UsuarioRegistro", SqlDbType.VarChar, 20).Value = voucheritemccostos.UsuarioRegistro;
                    //oComando.Parameters.Add("@FechaRegistro", SqlDbType.SmallDateTime).Value = voucheritemccostos.FechaRegistro;
                    oComando.Parameters.Add("@UsuarioModificacion", SqlDbType.VarChar, 20).Value = voucheritemccostos.UsuarioModificacion;
                    //oComando.Parameters.Add("@FechaModificacion", SqlDbType.SmallDateTime).Value = voucheritemccostos.FechaModificacion;

                    oConexion.Open();
                    oComando.ExecuteNonQuery();
                    oConexion.Close();
                }
            }

            return voucheritemccostos;
        }        

        public int EliminarVoucherItemCCostos(Int32 idEmpresa, Int32 idLocal, String AnioPeriodo, String MesPeriodo, String numVoucher, String idComprobante, String numFile, String numItem, String idCCostos)
        {
            int resp = 0;
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_EliminarVoucherItemCCostos", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;

                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
					oComando.Parameters.Add("@idLocal", SqlDbType.Int).Value = idLocal;
					oComando.Parameters.Add("@AnioPeriodo", SqlDbType.VarChar, 4).Value = AnioPeriodo;
					oComando.Parameters.Add("@MesPeriodo", SqlDbType.Char, 4).Value = MesPeriodo;
					oComando.Parameters.Add("@numVoucher", SqlDbType.VarChar, 9).Value = numVoucher;
					oComando.Parameters.Add("@idComprobante", SqlDbType.Char, 2).Value = idComprobante;
					oComando.Parameters.Add("@numFile", SqlDbType.Char, 4).Value = numFile;
					oComando.Parameters.Add("@numItem", SqlDbType.VarChar, 5).Value = numItem;
					oComando.Parameters.Add("@idCCostos", SqlDbType.VarChar, 10).Value = idCCostos;

                    oConexion.Open();
                    resp = oComando.ExecuteNonQuery();
                    oConexion.Close();
                }
            }

            return resp;
        }

        public List<VoucherItemCCostosE> ListarVoucherItemCCostos(Int32 idEmpresa, Int32 idLocal, String AnioPeriodo, String MesPeriodo, String numVoucher, String idComprobante, String numFile, String numItem)
        {
            List<VoucherItemCCostosE> listaEntidad = new List<VoucherItemCCostosE>();
            VoucherItemCCostosE entidad = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ListarVoucherItemCCostos", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@idLocal", SqlDbType.Int).Value = idLocal;
                    oComando.Parameters.Add("@AnioPeriodo", SqlDbType.VarChar, 4).Value = AnioPeriodo;
                    oComando.Parameters.Add("@MesPeriodo", SqlDbType.Char, 4).Value = MesPeriodo;
                    oComando.Parameters.Add("@numVoucher", SqlDbType.VarChar, 9).Value = numVoucher;
                    oComando.Parameters.Add("@idComprobante", SqlDbType.Char, 2).Value = idComprobante;
                    oComando.Parameters.Add("@numFile", SqlDbType.Char, 4).Value = numFile;
                    oComando.Parameters.Add("@numItem", SqlDbType.VarChar, 5).Value = numItem;
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

                oConexion.Close();
            }

            return listaEntidad;
        }
        
        public VoucherItemCCostosE ObtenerVoucherItemCCostos(Int32 idEmpresa, Int32 idLocal, String AnioPeriodo, String MesPeriodo, String numVoucher, String idComprobante, String numFile, String numItem, String idCCostos)
        {        
            VoucherItemCCostosE voucheritemccostos = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ObtenerVoucherItemCCostos", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;

                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
					oComando.Parameters.Add("@idLocal", SqlDbType.Int).Value = idLocal;
					oComando.Parameters.Add("@AnioPeriodo", SqlDbType.VarChar, 4).Value = AnioPeriodo;
					oComando.Parameters.Add("@MesPeriodo", SqlDbType.Char, 4).Value = MesPeriodo;
					oComando.Parameters.Add("@numVoucher", SqlDbType.VarChar, 9).Value = numVoucher;
					oComando.Parameters.Add("@idComprobante", SqlDbType.Char, 2).Value = idComprobante;
					oComando.Parameters.Add("@numFile", SqlDbType.Char, 4).Value = numFile;
					oComando.Parameters.Add("@numItem", SqlDbType.VarChar, 5).Value = numItem;
					oComando.Parameters.Add("@idCCostos", SqlDbType.VarChar, 10).Value = idCCostos;
                    oConexion.Open();
                    
                    using (SqlDataReader oReader = oComando.ExecuteReader())
                    {
                        while (oReader.Read())
                        {
                            voucheritemccostos = LlenarEntidad(oReader);
                        }
                    }
                }

                oConexion.Close();
            }

            return voucheritemccostos;
        }
    }
}