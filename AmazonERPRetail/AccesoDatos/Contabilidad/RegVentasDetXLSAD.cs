using System;
using System.Data;
using System.Data.SqlClient;

using Entidades.Contabilidad;
using AccesoDatos.Util;

namespace AccesoDatos.Contabilidad
{
    public class RegVentasDetXLSAD : DbConection
    {

        public RegVentasDetXLSE LlenarEntidad(IDataReader oReader)
        {
            RegVentasDetXLSE regventasdetxls = new RegVentasDetXLSE();
            
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idEmpresa'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				regventasdetxls.idEmpresa = oReader["idEmpresa"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idEmpresa"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idLocal'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				regventasdetxls.idLocal = oReader["idLocal"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idLocal"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idUsuario'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				regventasdetxls.idUsuario = oReader["idUsuario"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idUsuario"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Linea'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				regventasdetxls.Linea = oReader["Linea"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["Linea"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idCCostos'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				regventasdetxls.idCCostos = oReader["idCCostos"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["idCCostos"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idDocumento'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				regventasdetxls.idDocumento = oReader["idDocumento"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["idDocumento"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='numSerie'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				regventasdetxls.numSerie = oReader["numSerie"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["numSerie"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='numDocumentoIni'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				regventasdetxls.numDocumentoIni = oReader["numDocumentoIni"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["numDocumentoIni"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='numDocumentoFin'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				regventasdetxls.numDocumentoFin = oReader["numDocumentoFin"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["numDocumentoFin"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='SerieMaquina'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				regventasdetxls.SerieMaquina = oReader["SerieMaquina"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["SerieMaquina"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='FechaReal'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				regventasdetxls.FechaReal = oReader["FechaReal"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["FechaReal"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='FechaTurno'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				regventasdetxls.FechaTurno = oReader["FechaTurno"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["FechaTurno"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Producto'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                regventasdetxls.Producto = oReader["Producto"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["Producto"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Ruc'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				regventasdetxls.Ruc = oReader["Ruc"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["Ruc"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='RazonSocial'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				regventasdetxls.RazonSocial = oReader["RazonSocial"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["RazonSocial"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Placa'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				regventasdetxls.Placa = oReader["Placa"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["Placa"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='OpeInafecta'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				regventasdetxls.OpeInafecta = oReader["OpeInafecta"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["OpeInafecta"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='BaseImponible'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				regventasdetxls.BaseImponible = oReader["BaseImponible"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["BaseImponible"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Igv'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				regventasdetxls.Igv = oReader["Igv"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["Igv"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Total'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				regventasdetxls.Total = oReader["Total"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["Total"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Recaudo'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				regventasdetxls.Recaudo = oReader["Recaudo"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["Recaudo"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Cantidad'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				regventasdetxls.Cantidad = oReader["Cantidad"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["Cantidad"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idUmedida'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                regventasdetxls.idUmedida = oReader["idUmedida"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idUmedida"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='desUmed'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				regventasdetxls.desUmed = oReader["desUmed"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["desUmed"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idDocumentoRef'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				regventasdetxls.idDocumentoRef = oReader["idDocumentoRef"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["idDocumentoRef"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='numSerieRef'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				regventasdetxls.numSerieRef = oReader["numSerieRef"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["numSerieRef"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='numDocumentoRef'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				regventasdetxls.numDocumentoRef = oReader["numDocumentoRef"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["numDocumentoRef"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='FechaRef'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                regventasdetxls.FechaRef = oReader["FechaRef"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["FechaRef"]);

            return  regventasdetxls;        
        }

        public Int32 InsertarRegVentasDetXLS(DataTable oDt)
        {
            Int32 resp = 0;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_InsertarRegVentasDetXLS", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.CommandTimeout = 0;

                    SqlParameter param = new SqlParameter("@Tabla", SqlDbType.Structured);
                    param.TypeName = "RegVentasDet_XLS";
                    param.Value = oDt;
                    oComando.Parameters.Add(param);

                    oConexion.Open();
                    resp = oComando.ExecuteNonQuery();
                }
            }

            return resp;
        }

        public Int32 ProcesarRegVentasDetXLS(Int32 idEmpresa, Int32 idLocal, Int32 idUsuario)
        {
            Int32 resp = 0;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ProcesarRegVentasDetXLS", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.CommandTimeout = 0;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@idLocal", SqlDbType.Int).Value = idLocal;
                    oComando.Parameters.Add("@idUsuario", SqlDbType.Int).Value = idUsuario;

                    oConexion.Open();
                    resp = oComando.ExecuteNonQuery();
                }
            }

            return resp;
        }

        public Int32 EliminarRegVentasDetXLS(Int32 idEmpresa, Int32 idLocal, Int32 idUsuario)
        {
            Int32 resp = 0;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_EliminarRegVentasDetXLS", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.CommandTimeout = 0;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@idLocal", SqlDbType.Int).Value = idLocal;
                    oComando.Parameters.Add("@idUsuario", SqlDbType.Int).Value = idUsuario;

                    oConexion.Open();
                    resp = oComando.ExecuteNonQuery();
                }
            }

            return resp;
        }

        public Int32 IntegrarRegVentasXLSDet(Int32 idEmpresa, Int32 idLocal, Int32 idUsuario, String Sistema, String Usuario)
        {
            Int32 resp = 0;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_IntegrarRegVentasXLSDet", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.CommandTimeout = 0;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@idLocal", SqlDbType.Int).Value = idLocal;
                    oComando.Parameters.Add("@idUsuario", SqlDbType.Int).Value = idUsuario;
                    oComando.Parameters.Add("@Sistema", SqlDbType.VarChar, 3).Value = Sistema;
                    oComando.Parameters.Add("@Usuario", SqlDbType.VarChar, 20).Value = Usuario;

                    oConexion.Open();
                    resp = oComando.ExecuteNonQuery();
                }
            }

            return resp;
        }

    }
}