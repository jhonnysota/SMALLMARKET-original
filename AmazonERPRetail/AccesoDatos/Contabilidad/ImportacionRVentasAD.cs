using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

using Entidades.Contabilidad;
using AccesoDatos.Util;

namespace AccesoDatos.Contabilidad
{
    public class ImportacionRVentasAD : DbConection
    {

        public ImportacionRVentasE LlenarEntidad(IDataReader oReader)
        {
            ImportacionRVentasE rventas = new ImportacionRVentasE();
            
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idEmpresa'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				rventas.idEmpresa = oReader["idEmpresa"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idEmpresa"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idLocal'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				rventas.idLocal = oReader["idLocal"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idLocal"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idEstablecimiento'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				rventas.idEstablecimiento = oReader["idEstablecimiento"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idEstablecimiento"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='AnioPeriodo'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                rventas.AnioPeriodo = oReader["AnioPeriodo"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["AnioPeriodo"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='MesPeriodo'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                rventas.MesPeriodo = oReader["MesPeriodo"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["MesPeriodo"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Libro'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                rventas.Libro = oReader["Libro"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["Libro"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='numFile'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                rventas.numFile = oReader["numFile"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["numFile"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Item'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                rventas.Item = oReader["Item"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["Item"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='T'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				rventas.T = oReader["T"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["T"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='VOU'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				rventas.VOU = oReader["VOU"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["VOU"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='DebeHaber'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                rventas.DebeHaber = oReader["DebeHaber"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["DebeHaber"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Fecha'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				rventas.Fecha = oReader["Fecha"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["Fecha"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='CUENTA'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				rventas.Cuenta = oReader["CUENTA"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["CUENTA"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Debe'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				rventas.Debe = oReader["Debe"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["Debe"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Haber'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				rventas.Haber = oReader["Haber"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["Haber"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Moneda'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				rventas.Moneda = oReader["Moneda"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["Moneda"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='TC'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				rventas.TC = oReader["TC"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["TC"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Doc'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				rventas.Doc = oReader["Doc"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["Doc"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Numero'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				rventas.Numero = oReader["Numero"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["Numero"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='FechaD'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				rventas.FechaD = oReader["FechaD"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["FechaD"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='FechaV'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				rventas.FechaV = oReader["FechaV"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(oReader["FechaV"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Codigo'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				rventas.Codigo = oReader["Codigo"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["Codigo"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='CC'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				rventas.CC = oReader["CC"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["CC"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='FE'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				rventas.FE = oReader["FE"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["FE"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='PRE'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				rventas.PRE = oReader["PRE"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["PRE"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='MPago'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				rventas.MPago = oReader["MPago"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["MPago"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Glosa'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				rventas.Glosa = oReader["Glosa"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["Glosa"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='RNumero'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				rventas.RNumero = oReader["RNumero"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["RNumero"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='RTdoc'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				rventas.RTdoc = oReader["RTdoc"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["RTdoc"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='RFecha'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				rventas.RFecha = oReader["RFecha"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(oReader["RFecha"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='SNumero'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				rventas.SNumero = oReader["SNumero"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["SNumero"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='SFecha'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				rventas.SFecha = oReader["SFecha"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(oReader["SFecha"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='TL'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				rventas.TL = oReader["TL"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["TL"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='BaseImponible'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				rventas.BaseImponible = oReader["BaseImponible"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["BaseImponible"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='BaseNoImponible'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				rventas.BaseNoImponible = oReader["BaseNoImponible"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["BaseNoImponible"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='IgvB'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				rventas.IgvB = oReader["IgvB"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["IgvB"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='BaseImponibleExportacion'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				rventas.BaseImponibleExportacion = oReader["BaseImponibleExportacion"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["BaseImponibleExportacion"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='IGV'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				rventas.IGV = oReader["IGV"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["IGV"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='IgvOtros'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				rventas.IgvOtros = oReader["IgvOtros"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["IgvOtros"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='BaseImponilbleC'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				rventas.BaseImponilbleC = oReader["BaseImponilbleC"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["BaseImponilbleC"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='IgvC'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				rventas.IgvC = oReader["IgvC"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["IgvC"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='ISC'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				rventas.ISC = oReader["ISC"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["ISC"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='RUC'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				rventas.RUC = oReader["RUC"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["RUC"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Tipo'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				rventas.Tipo = oReader["Tipo"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["Tipo"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Rs'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				rventas.Rs = oReader["Rs"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["Rs"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Ape1'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				rventas.Ape1 = oReader["Ape1"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["Ape1"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Ape2'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				rventas.Ape2 = oReader["Ape2"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["Ape2"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Nombre'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				rventas.Nombre = oReader["Nombre"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["Nombre"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='TDoci'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				rventas.TDoci = oReader["TDoci"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["TDoci"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='RNumdes'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				rventas.RNumdes = oReader["RNumdes"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["RNumdes"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='RCodTasa'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				rventas.RCodTasa = oReader["RCodTasa"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["RCodTasa"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='RIndRet'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				rventas.RIndRet = oReader["RIndRet"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["RIndRet"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='RMonto'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				rventas.RMonto = oReader["RMonto"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["RMonto"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='RIgv'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				rventas.RIgv = oReader["RIgv"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["RIgv"]);
			

            return  rventas;        
        }

        public ImportacionRVentasE InsertarRVENTAS(ImportacionRVentasE rventas)
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_InsertarRVENTAS", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = rventas.idEmpresa;
					oComando.Parameters.Add("@idLocal", SqlDbType.Int).Value = rventas.idLocal;
					oComando.Parameters.Add("@idEstablecimiento", SqlDbType.Int).Value = rventas.idEstablecimiento;
                    oComando.Parameters.Add("@AnioPeriodo", SqlDbType.VarChar, 4).Value = rventas.AnioPeriodo;
                    oComando.Parameters.Add("@MesPeriodo", SqlDbType.VarChar, 2).Value = rventas.MesPeriodo;
                    oComando.Parameters.Add("@Libro", SqlDbType.VarChar, 2).Value = rventas.Libro;
                    oComando.Parameters.Add("@numFile", SqlDbType.VarChar, 2).Value = rventas.numFile;
                    oComando.Parameters.Add("@Item", SqlDbType.Int).Value = rventas.Item;
                    oComando.Parameters.Add("@T", SqlDbType.VarChar, 2).Value = rventas.T;
                    oComando.Parameters.Add("@VOU", SqlDbType.VarChar, 5).Value = rventas.VOU;
                    oComando.Parameters.Add("@DebeHaber", SqlDbType.Char, 1).Value = rventas.DebeHaber;
                    oComando.Parameters.Add("@Fecha", SqlDbType.SmallDateTime).Value = rventas.Fecha;
					oComando.Parameters.Add("@Cuenta", SqlDbType.VarChar, 10).Value = rventas.Cuenta;
					oComando.Parameters.Add("@Debe", SqlDbType.Decimal).Value = rventas.Debe;
					oComando.Parameters.Add("@Haber", SqlDbType.Decimal).Value = rventas.Haber;
					oComando.Parameters.Add("@Moneda", SqlDbType.VarChar, 1).Value = rventas.Moneda;
					oComando.Parameters.Add("@TC", SqlDbType.VarChar, 20).Value = rventas.TC;
					oComando.Parameters.Add("@Doc", SqlDbType.VarChar, 2).Value = rventas.Doc;
					oComando.Parameters.Add("@Numero", SqlDbType.VarChar, 40).Value = rventas.Numero;
					oComando.Parameters.Add("@FechaD", SqlDbType.SmallDateTime).Value = rventas.FechaD;
					oComando.Parameters.Add("@FechaV", SqlDbType.SmallDateTime).Value = rventas.FechaV;
					oComando.Parameters.Add("@Codigo", SqlDbType.VarChar, 15).Value = rventas.Codigo;
					oComando.Parameters.Add("@CC", SqlDbType.VarChar, 10).Value = rventas.CC;
					oComando.Parameters.Add("@FE", SqlDbType.VarChar, 4).Value = rventas.FE;
					oComando.Parameters.Add("@PRE", SqlDbType.VarChar, 10).Value = rventas.PRE;
					oComando.Parameters.Add("@MPago", SqlDbType.VarChar, 3).Value = rventas.MPago;
					oComando.Parameters.Add("@Glosa", SqlDbType.VarChar, 60).Value = rventas.Glosa;
					oComando.Parameters.Add("@RNumero", SqlDbType.VarChar, 40).Value = rventas.RNumero;
					oComando.Parameters.Add("@RTdoc", SqlDbType.VarChar, 2).Value = rventas.RTdoc;
					oComando.Parameters.Add("@RFecha", SqlDbType.SmallDateTime).Value = rventas.RFecha;
					oComando.Parameters.Add("@SNumero", SqlDbType.VarChar, 40).Value = rventas.SNumero;
					oComando.Parameters.Add("@SFecha", SqlDbType.SmallDateTime).Value = rventas.SFecha;
					oComando.Parameters.Add("@TL", SqlDbType.VarChar, 1).Value = rventas.TL;
					oComando.Parameters.Add("@BaseImponible", SqlDbType.Decimal).Value = rventas.BaseImponible;
					oComando.Parameters.Add("@BaseNoImponible", SqlDbType.Decimal).Value = rventas.BaseNoImponible;
					oComando.Parameters.Add("@IgvB", SqlDbType.Decimal).Value = rventas.IgvB;
					oComando.Parameters.Add("@BaseImponibleExportacion", SqlDbType.Decimal).Value = rventas.BaseImponibleExportacion;
					oComando.Parameters.Add("@IGV", SqlDbType.Decimal).Value = rventas.IGV;
					oComando.Parameters.Add("@IgvOtros", SqlDbType.Decimal).Value = rventas.IgvOtros;
					oComando.Parameters.Add("@BaseImponilbleC", SqlDbType.Decimal).Value = rventas.BaseImponilbleC;
					oComando.Parameters.Add("@IgvC", SqlDbType.Decimal).Value = rventas.IgvC;
					oComando.Parameters.Add("@ISC", SqlDbType.Decimal).Value = rventas.ISC;
					oComando.Parameters.Add("@RUC", SqlDbType.VarChar, 15).Value = rventas.RUC;
					oComando.Parameters.Add("@Tipo", SqlDbType.VarChar, 1).Value = rventas.Tipo;
					oComando.Parameters.Add("@Rs", SqlDbType.VarChar, 60).Value = rventas.Rs;
					oComando.Parameters.Add("@Ape1", SqlDbType.VarChar, 20).Value = rventas.Ape1;
					oComando.Parameters.Add("@Ape2", SqlDbType.VarChar, 20).Value = rventas.Ape2;
					oComando.Parameters.Add("@Nombre", SqlDbType.VarChar, 20).Value = rventas.Nombre;
					oComando.Parameters.Add("@TDoci", SqlDbType.VarChar, 1).Value = rventas.TDoci;
					oComando.Parameters.Add("@RNumdes", SqlDbType.VarChar, 1).Value = rventas.RNumdes;
					oComando.Parameters.Add("@RCodTasa", SqlDbType.VarChar, 5).Value = rventas.RCodTasa;
					oComando.Parameters.Add("@RIndRet", SqlDbType.VarChar, 1).Value = rventas.RIndRet;
					oComando.Parameters.Add("@RMonto", SqlDbType.Decimal).Value = rventas.RMonto;
					oComando.Parameters.Add("@RIgv", SqlDbType.Decimal).Value = rventas.RIgv;
                    oComando.Parameters.Add("@NombreArchivo", SqlDbType.VarChar, 80).Value = rventas.NombreArchivo;
                    
                    oConexion.Open();
                    oComando.ExecuteNonQuery();
                }
            }

            return rventas;
        }
        
        public ImportacionRVentasE ActualizarRVENTAS(ImportacionRVentasE rventas)
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ActualizarRVENTAS", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = rventas.idEmpresa;
                    oComando.Parameters.Add("@idLocal", SqlDbType.Int).Value = rventas.idLocal;
                    oComando.Parameters.Add("@idEstablecimiento", SqlDbType.Int).Value = rventas.idEstablecimiento;
                    oComando.Parameters.Add("@AnioPeriodo", SqlDbType.VarChar, 4).Value = rventas.AnioPeriodo;
                    oComando.Parameters.Add("@MesPeriodo", SqlDbType.VarChar, 2).Value = rventas.MesPeriodo;
                    oComando.Parameters.Add("@Libro", SqlDbType.VarChar, 2).Value = rventas.Libro;
                    oComando.Parameters.Add("@numFile", SqlDbType.VarChar, 2).Value = rventas.numFile;
                    oComando.Parameters.Add("@Item", SqlDbType.Int).Value = rventas.Item;
                    oComando.Parameters.Add("@T", SqlDbType.VarChar, 2).Value = rventas.T;
                    oComando.Parameters.Add("@VOU", SqlDbType.VarChar, 5).Value = rventas.VOU;
                    oComando.Parameters.Add("@DebeHaber", SqlDbType.Char, 1).Value = rventas.DebeHaber;
                    oComando.Parameters.Add("@Fecha", SqlDbType.SmallDateTime).Value = rventas.Fecha;
                    oComando.Parameters.Add("@Cuenta", SqlDbType.VarChar, 10).Value = rventas.Cuenta;
                    oComando.Parameters.Add("@Debe", SqlDbType.Decimal).Value = rventas.Debe;
                    oComando.Parameters.Add("@Haber", SqlDbType.Decimal).Value = rventas.Haber;
                    oComando.Parameters.Add("@Moneda", SqlDbType.VarChar, 1).Value = rventas.Moneda;
                    oComando.Parameters.Add("@TC", SqlDbType.VarChar, 20).Value = rventas.TC;
                    oComando.Parameters.Add("@Doc", SqlDbType.VarChar, 2).Value = rventas.Doc;
                    oComando.Parameters.Add("@Numero", SqlDbType.VarChar, 40).Value = rventas.Numero;
                    oComando.Parameters.Add("@FechaD", SqlDbType.SmallDateTime).Value = rventas.FechaD;
                    oComando.Parameters.Add("@FechaV", SqlDbType.SmallDateTime).Value = rventas.FechaV;
                    oComando.Parameters.Add("@Codigo", SqlDbType.VarChar, 15).Value = rventas.Codigo;
                    oComando.Parameters.Add("@CC", SqlDbType.VarChar, 10).Value = rventas.CC;
                    oComando.Parameters.Add("@FE", SqlDbType.VarChar, 4).Value = rventas.FE;
                    oComando.Parameters.Add("@PRE", SqlDbType.VarChar, 10).Value = rventas.PRE;
                    oComando.Parameters.Add("@MPago", SqlDbType.VarChar, 3).Value = rventas.MPago;
                    oComando.Parameters.Add("@Glosa", SqlDbType.VarChar, 60).Value = rventas.Glosa;
                    oComando.Parameters.Add("@RNumero", SqlDbType.VarChar, 40).Value = rventas.RNumero;
                    oComando.Parameters.Add("@RTdoc", SqlDbType.VarChar, 2).Value = rventas.RTdoc;
                    oComando.Parameters.Add("@RFecha", SqlDbType.SmallDateTime).Value = rventas.RFecha;
                    oComando.Parameters.Add("@SNumero", SqlDbType.VarChar, 40).Value = rventas.SNumero;
                    oComando.Parameters.Add("@SFecha", SqlDbType.SmallDateTime).Value = rventas.SFecha;
                    oComando.Parameters.Add("@TL", SqlDbType.VarChar, 1).Value = rventas.TL;
                    oComando.Parameters.Add("@BaseImponible", SqlDbType.Decimal).Value = rventas.BaseImponible;
                    oComando.Parameters.Add("@BaseNoImponible", SqlDbType.Decimal).Value = rventas.BaseNoImponible;
                    oComando.Parameters.Add("@IgvB", SqlDbType.Decimal).Value = rventas.IgvB;
                    oComando.Parameters.Add("@BaseImponibleExportacion", SqlDbType.Decimal).Value = rventas.BaseImponibleExportacion;
                    oComando.Parameters.Add("@IGV", SqlDbType.Decimal).Value = rventas.IGV;
                    oComando.Parameters.Add("@IgvOtros", SqlDbType.Decimal).Value = rventas.IgvOtros;
                    oComando.Parameters.Add("@BaseImponilbleC", SqlDbType.Decimal).Value = rventas.BaseImponilbleC;
                    oComando.Parameters.Add("@IgvC", SqlDbType.Decimal).Value = rventas.IgvC;
                    oComando.Parameters.Add("@ISC", SqlDbType.Decimal).Value = rventas.ISC;
                    oComando.Parameters.Add("@RUC", SqlDbType.VarChar, 15).Value = rventas.RUC;
                    oComando.Parameters.Add("@Tipo", SqlDbType.VarChar, 1).Value = rventas.Tipo;
                    oComando.Parameters.Add("@Rs", SqlDbType.VarChar, 60).Value = rventas.Rs;
                    oComando.Parameters.Add("@Ape1", SqlDbType.VarChar, 20).Value = rventas.Ape1;
                    oComando.Parameters.Add("@Ape2", SqlDbType.VarChar, 20).Value = rventas.Ape2;
                    oComando.Parameters.Add("@Nombre", SqlDbType.VarChar, 20).Value = rventas.Nombre;
                    oComando.Parameters.Add("@TDoci", SqlDbType.VarChar, 1).Value = rventas.TDoci;
                    oComando.Parameters.Add("@RNumdes", SqlDbType.VarChar, 1).Value = rventas.RNumdes;
                    oComando.Parameters.Add("@RCodTasa", SqlDbType.VarChar, 5).Value = rventas.RCodTasa;
                    oComando.Parameters.Add("@RIndRet", SqlDbType.VarChar, 1).Value = rventas.RIndRet;
                    oComando.Parameters.Add("@RMonto", SqlDbType.Decimal).Value = rventas.RMonto;
                    oComando.Parameters.Add("@RIgv", SqlDbType.Decimal).Value = rventas.RIgv;
                    oComando.Parameters.Add("@NombreArchivo", SqlDbType.VarChar, 80).Value = rventas.NombreArchivo;

                    oConexion.Open();
                    oComando.ExecuteNonQuery();
                }
            }

            return rventas;
        }        

        public int EliminarRVENTAS(Int32 idEmpresa, String Libro, DateTime fecIni, DateTime fecFin)
        {
            Int32 resp = 0;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_EliminarRVENTAS", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.CommandTimeout = 0;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@Libro", SqlDbType.VarChar, 2).Value = Libro;
                    oComando.Parameters.Add("@fecIni", SqlDbType.SmallDateTime).Value = fecIni.Date;
                    oComando.Parameters.Add("@fecFin", SqlDbType.SmallDateTime).Value = fecFin.Date;

                    oConexion.Open();
                    resp = oComando.ExecuteNonQuery();
                }
            }

            return resp;
        }

        public List<ImportacionRVentasE> ListarRVENTAS()
        {
            List<ImportacionRVentasE> listaEntidad = new List<ImportacionRVentasE>();

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ListarRVENTAS", oConexion))
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
        
        public ImportacionRVentasE ObtenerRVENTAS()
        {        
            ImportacionRVentasE rventas = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ObtenerRVENTAS", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oConexion.Open();
                    
                    using (SqlDataReader oReader = oComando.ExecuteReader())
                    {
                        while (oReader.Read())
                        {
                            rventas = LlenarEntidad(oReader);
                        }
                    }
                }
            }

            return rventas;
        }

    }
}