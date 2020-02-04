using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

using Entidades.Contabilidad;
using AccesoDatos.Util;

namespace AccesoDatos.Contabilidad
{
    public class ConsistenciaVoucherAD : DbConection
    {
        
        public ConsistenciaVoucherE LlenarEntidad(IDataReader oReader)
        {
            ConsistenciaVoucherE Diferencia = new ConsistenciaVoucherE();

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idEmpresa'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                Diferencia.idEmpresa = oReader["idEmpresa"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idEmpresa"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='numVoucher'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                Diferencia.numVoucher = oReader["numVoucher"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["numVoucher"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='numItem'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                Diferencia.numItem = oReader["numItem"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["numItem"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='MesPeriodo'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                Diferencia.MesPeriodo = oReader["MesPeriodo"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["MesPeriodo"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='AnioPeriodo'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                Diferencia.AnioPeriodo = oReader["AnioPeriodo"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["AnioPeriodo"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idComprobante'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                Diferencia.idComprobante = oReader["idComprobante"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["idComprobante"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='numFile'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                Diferencia.numFile = oReader["numFile"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["numFile"]);


            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='D_imp_Soles'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                Diferencia.D_imp_Soles = oReader["D_imp_Soles"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["D_imp_Soles"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='H_imp_Soles'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                Diferencia.H_imp_Soles = oReader["H_imp_Soles"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["H_imp_Soles"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='D_imp_Dolares'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                Diferencia.D_imp_Dolares = oReader["D_imp_Dolares"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["D_imp_Dolares"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='H_imp_Dolares'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                Diferencia.H_imp_Dolares = oReader["H_imp_Dolares"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["H_imp_Dolares"]);




            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idMoneda'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                Diferencia.idMoneda = oReader["idMoneda"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["idMoneda"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='fecOperacion'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                Diferencia.fecOperacion = oReader["fecOperacion"] == DBNull.Value ? Diferencia.fecOperacion : Convert.ToDateTime(oReader["fecOperacion"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='fecDocumento'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                Diferencia.fecDocumento = oReader["fecDocumento"] == DBNull.Value ? Diferencia.fecDocumento : Convert.ToDateTime(oReader["fecDocumento"]);
            
            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Glosita'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                Diferencia.Glosita = oReader["Glosita"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["Glosita"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='GlosaGeneral'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                Diferencia.GlosaGeneral = oReader["GlosaGeneral"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["GlosaGeneral"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='codCuentaDestino'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                Diferencia.codCuentaDestino = oReader["codCuentaDestino"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["codCuentaDestino"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='desCuenta'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                Diferencia.desCuenta = oReader["desCuenta"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["desCuenta"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Diferencia'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                Diferencia.Diferencia = oReader["Diferencia"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["Diferencia"]);

            return Diferencia;
        }

        public List<ConsistenciaVoucherE> ConsistenciaVoucher(Int32 idEmpresa, String ano_ini, String ano_fin, String mes_ini, String mes_fin)
        {
            List<ConsistenciaVoucherE> oLista = new List<ConsistenciaVoucherE>();
            ConsistenciaVoucherE Item = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ConsistenciaVoucher", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.CommandTimeout = 0;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@ano_ini", SqlDbType.VarChar, 4).Value = ano_ini;
                    oComando.Parameters.Add("@ano_fin", SqlDbType.VarChar, 4).Value = ano_fin;
                    oComando.Parameters.Add("@mes_ini", SqlDbType.VarChar, 2).Value = mes_ini;
                    oComando.Parameters.Add("@mes_fin", SqlDbType.VarChar, 2).Value = mes_fin;

                    oConexion.Open();

                    using (SqlDataReader oReader = oComando.ExecuteReader())
                    {
                        while (oReader.Read())
                        {
                            Item = LlenarEntidad(oReader);
                            oLista.Add(Item);
                        }
                    }
                }

                oConexion.Close();
            }

            return oLista;
        }

        public List<ConsistenciaVoucherE> ConsistenciaVoucherDiferencia(Int32 idEmpresa, String ano, String mes)
        {
            List<ConsistenciaVoucherE> oLista = new List<ConsistenciaVoucherE>();
            ConsistenciaVoucherE Item = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ConsistenciaVoucherDiferencia", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.CommandTimeout = 0;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@ano", SqlDbType.VarChar, 4).Value = ano;
                    oComando.Parameters.Add("@mes", SqlDbType.VarChar, 2).Value = mes;

                    oConexion.Open();

                    using (SqlDataReader oReader = oComando.ExecuteReader())
                    {
                        while (oReader.Read())
                        {
                            Item = LlenarEntidad(oReader);
                            oLista.Add(Item);
                        }
                    }
                }

                oConexion.Close();
            }

            return oLista;
        }



    }
}
