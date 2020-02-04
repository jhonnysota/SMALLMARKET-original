using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

using Entidades.Contabilidad;
using AccesoDatos.Util;

namespace AccesoDatos.Contabilidad
{
    public class BancosConciliarAD : DbConection
    {

        public BancosConciliarE LlenarEntidad(IDataReader oReader)
        {
            BancosConciliarE bancosconciliar = new BancosConciliarE();
           			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idPersona'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				bancosconciliar.idPersona = oReader["idPersona"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idPersona"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idEmpresa'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				bancosconciliar.idEmpresa = oReader["idEmpresa"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idEmpresa"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='item'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				bancosconciliar.item = oReader["item"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["item"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Fecha'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				bancosconciliar.Fecha = oReader["Fecha"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["Fecha"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Glosa'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				bancosconciliar.Glosa = oReader["Glosa"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["Glosa"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Monto'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				bancosconciliar.Monto = oReader["Monto"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["Monto"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Operacion'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				bancosconciliar.Operacion = oReader["Operacion"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["Operacion"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idLocal'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                bancosconciliar.idLocal = oReader["idLocal"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idLocal"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='AnioPeriodo'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                bancosconciliar.AnioPeriodo = oReader["AnioPeriodo"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["AnioPeriodo"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='MesPeriodo'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                bancosconciliar.MesPeriodo = oReader["MesPeriodo"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["MesPeriodo"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='numVoucher'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                bancosconciliar.numVoucher = oReader["numVoucher"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["numVoucher"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idComprobante'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                bancosconciliar.idComprobante = oReader["idComprobante"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["idComprobante"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='numFile'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                bancosconciliar.numFile = oReader["numFile"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["numFile"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='numItem'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                bancosconciliar.numItem = oReader["numItem"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["numItem"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='CodCuenta'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                bancosconciliar.CodCuenta = oReader["CodCuenta"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["CodCuenta"]);

            //Extensiones
            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='RazonSocial'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                bancosconciliar.RazonSocial = oReader["RazonSocial"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["RazonSocial"]);

            return  bancosconciliar;        
        }

        public BancosConciliarE InsertarBancosConciliar(BancosConciliarE bancosconciliar)
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_InsertarBancosConciliar", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
					oComando.Parameters.Add("@idPersona", SqlDbType.Int).Value = bancosconciliar.idPersona;
					oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = bancosconciliar.idEmpresa;
					oComando.Parameters.Add("@Fecha", SqlDbType.DateTime).Value = bancosconciliar.Fecha;
					oComando.Parameters.Add("@Glosa", SqlDbType.VarChar, 100).Value = bancosconciliar.Glosa;
					oComando.Parameters.Add("@Monto", SqlDbType.Decimal).Value = bancosconciliar.Monto;
					oComando.Parameters.Add("@Operacion", SqlDbType.VarChar, 20).Value = bancosconciliar.Operacion;
                    oComando.Parameters.Add("@CodCuenta", SqlDbType.VarChar, 10).Value = bancosconciliar.CodCuenta;

                    oConexion.Open();
                    bancosconciliar.item = Int32.Parse(oComando.ExecuteScalar().ToString());
                }
            }

            return bancosconciliar;
        }

        public BancosConciliarE ActualizarBancosConciliar(BancosConciliarE bancosconciliar)
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ActualizarBancosConciliar", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idPersona", SqlDbType.Int).Value = bancosconciliar.idPersona;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = bancosconciliar.idEmpresa;
                    oComando.Parameters.Add("@item", SqlDbType.Int).Value = bancosconciliar.item;
                    oComando.Parameters.Add("@Fecha", SqlDbType.SmallDateTime).Value = bancosconciliar.Fecha.Date;
                    oComando.Parameters.Add("@Glosa", SqlDbType.VarChar, 100).Value = bancosconciliar.Glosa;
                    oComando.Parameters.Add("@Monto", SqlDbType.Decimal).Value = bancosconciliar.Monto;
                    oComando.Parameters.Add("@Operacion", SqlDbType.VarChar, 20).Value = bancosconciliar.Operacion;
                    oComando.Parameters.Add("@idLocal", SqlDbType.Int).Value = bancosconciliar.idLocal;
                    oComando.Parameters.Add("@AnioPeriodo", SqlDbType.VarChar, 4).Value = bancosconciliar.AnioPeriodo;
                    oComando.Parameters.Add("@MesPeriodo", SqlDbType.VarChar, 2).Value = bancosconciliar.MesPeriodo;
                    oComando.Parameters.Add("@numVoucher", SqlDbType.VarChar, 9).Value = bancosconciliar.numVoucher;
                    oComando.Parameters.Add("@idComprobante", SqlDbType.VarChar, 2).Value = bancosconciliar.idComprobante;
                    oComando.Parameters.Add("@numFile", SqlDbType.VarChar, 2).Value = bancosconciliar.numFile;
                    oComando.Parameters.Add("@numItem", SqlDbType.VarChar, 5).Value = bancosconciliar.numItem;
                    oComando.Parameters.Add("@CodCuenta", SqlDbType.VarChar, 10).Value = bancosconciliar.CodCuenta;

                    oConexion.Open();
                    oComando.ExecuteNonQuery();
                }
            }

            return bancosconciliar;
        }

        public int EliminarBancosConciliar(Int32 idPersona, Int32 idEmpresa, DateTime FechaIni, DateTime FechaFin, String CodCuenta)
        {
            int resp = 0;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_EliminarBancosConciliar", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idPersona", SqlDbType.Int).Value = idPersona;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@FechaIni", SqlDbType.DateTime).Value = FechaIni;
                    oComando.Parameters.Add("@FechaFin", SqlDbType.DateTime).Value = FechaFin;
                    oComando.Parameters.Add("@CodCuenta", SqlDbType.VarChar, 10).Value = CodCuenta;

                    oConexion.Open();
                    resp = oComando.ExecuteNonQuery();
                }
            }

            return resp;
        }

        public List<BancosConciliarE> ListarBancosConciliar(Int32 idPersona, Int32 idEmpresa, Int32 AnioPeriodo, Int32 MesPeriodo, String CodCuenta)
        {
            List<BancosConciliarE> listaEntidad = new List<BancosConciliarE>();

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ListarBancosConciliar", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idPersona", SqlDbType.Int).Value = idPersona;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@AnioPeriodo", SqlDbType.Int).Value = AnioPeriodo;
                    oComando.Parameters.Add("@MesPeriodo", SqlDbType.Int).Value = MesPeriodo;
                    oComando.Parameters.Add("@CodCuenta", SqlDbType.VarChar, 10).Value = CodCuenta;

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