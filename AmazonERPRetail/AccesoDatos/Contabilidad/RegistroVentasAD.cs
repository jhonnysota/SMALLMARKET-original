using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

using Entidades.Contabilidad;
using AccesoDatos.Util;

namespace AccesoDatos.Contabilidad
{
    public class RegistroVentasAD : DbConection
    {

        public RegistroVentasE LlenarEntidad(IDataReader oReader)
        {
            RegistroVentasE registroventas = new RegistroVentasE();
            
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idRegistro'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				registroventas.idRegistro = oReader["idRegistro"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idRegistro"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idEmpresa'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				registroventas.idEmpresa = oReader["idEmpresa"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idEmpresa"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idLocal'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				registroventas.idLocal = oReader["idLocal"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idLocal"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Anio'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				registroventas.Anio = oReader["Anio"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["Anio"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Mes'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				registroventas.Mes = oReader["Mes"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["Mes"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='fecDocumento'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				registroventas.fecDocumento = oReader["fecDocumento"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["fecDocumento"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='tipDocVenta'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				registroventas.tipDocVenta = oReader["tipDocVenta"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["tipDocVenta"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Serie'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				registroventas.Serie = oReader["Serie"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["Serie"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Numero'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				registroventas.Numero = oReader["Numero"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["Numero"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idPersona'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				registroventas.idPersona = oReader["idPersona"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idPersona"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='tipDocPersona'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				registroventas.tipDocPersona = oReader["tipDocPersona"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["tipDocPersona"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='numDocPersona'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				registroventas.numDocPersona = oReader["numDocPersona"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["numDocPersona"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='RazonSocial'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				registroventas.RazonSocial = oReader["RazonSocial"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["RazonSocial"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idMoneda'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                registroventas.idMoneda = oReader["idMoneda"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["idMoneda"]);

			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='BaseExportacion'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				registroventas.BaseExportacion = oReader["BaseExportacion"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["BaseExportacion"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='BaseInafecta'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				registroventas.BaseInafecta = oReader["BaseInafecta"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["BaseInafecta"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='BaseImponible'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				registroventas.BaseImponible = oReader["BaseImponible"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["BaseImponible"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Igv'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				registroventas.Igv = oReader["Igv"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["Igv"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Total'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				registroventas.Total = oReader["Total"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["Total"]);            

			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Tica'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				registroventas.Tica = oReader["Tica"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["Tica"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='tipDocVentaRef'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				registroventas.tipDocVentaRef = oReader["tipDocVentaRef"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["tipDocVentaRef"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='SerieRef'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				registroventas.SerieRef = oReader["SerieRef"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["SerieRef"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='NumeroRef'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				registroventas.NumeroRef = oReader["NumeroRef"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["NumeroRef"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='FechaRef'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				registroventas.FechaRef = oReader["FechaRef"] == DBNull.Value ? (Nullable<DateTime>)null : Convert.ToDateTime(oReader["FechaRef"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Percepcion'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				registroventas.Percepcion = oReader["Percepcion"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["Percepcion"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='csIgv'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				registroventas.csIgv = oReader["csIgv"] == DBNull.Value ? true : Convert.ToBoolean(oReader["csIgv"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Correlativo'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				registroventas.Correlativo = oReader["Correlativo"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["Correlativo"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='UsuarioRegistro'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				registroventas.UsuarioRegistro = oReader["UsuarioRegistro"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["UsuarioRegistro"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='FechaRegistro'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				registroventas.FechaRegistro = oReader["FechaRegistro"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["FechaRegistro"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='UsuarioModificacion'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				registroventas.UsuarioModificacion = oReader["UsuarioModificacion"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["UsuarioModificacion"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='FechaModificacion'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				registroventas.FechaModificacion = oReader["FechaModificacion"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["FechaModificacion"]);
			
            //Extensiones
            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Periodo'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                registroventas.Periodo = oReader["Periodo"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["Periodo"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='PrimerDigito'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                registroventas.PrimerDigito = oReader["PrimerDigito"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["PrimerDigito"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='dctoBaseImponible'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                registroventas.dctoBaseImponible = oReader["dctoBaseImponible"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["dctoBaseImponible"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='dsctoIgv'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                registroventas.dsctoIgv = oReader["dsctoIgv"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["dsctoIgv"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='BaseExonerada'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                registroventas.BaseExonerada = oReader["BaseExonerada"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["BaseExonerada"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Isc'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                registroventas.Isc = oReader["Isc"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["Isc"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='BaseImponibleIvap'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                registroventas.BaseImponibleIvap = oReader["BaseImponibleIvap"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["BaseImponibleIvap"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Ivap'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                registroventas.Ivap = oReader["Ivap"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["Ivap"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='OtrosTributos'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                registroventas.OtrosTributos = oReader["OtrosTributos"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["OtrosTributos"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Inconsistencia'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                registroventas.Inconsistencia = oReader["Inconsistencia"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["Inconsistencia"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Identificacion'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                registroventas.Identificacion = oReader["Identificacion"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["Identificacion"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idMedioPago'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                registroventas.idMedioPago = oReader["idMedioPago"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["idMedioPago"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Estado'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                registroventas.Estado = oReader["Estado"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["Estado"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='fecVencimiento'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                registroventas.fecVencimiento = oReader["fecVencimiento"] == DBNull.Value ? (Nullable<DateTime>)null : Convert.ToDateTime(oReader["fecVencimiento"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Diario'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                registroventas.Diario = oReader["Diario"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["Diario"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='NumFile'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                registroventas.NumFile = oReader["NumFile"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["NumFile"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='FecOperacion'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                registroventas.FecOperacion = oReader["FecOperacion"] == DBNull.Value ? (Nullable<DateTime>)null : Convert.ToDateTime(oReader["FecOperacion"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Voucher'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                registroventas.Voucher = oReader["Voucher"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["Voucher"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Moneda'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                registroventas.Moneda = oReader["Moneda"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["Moneda"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='VTA'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                registroventas.VTA = oReader["VTA"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["VTA"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='tipoPersoneriaDaot'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                registroventas.tipoPersoneriaDaot = oReader["tipoPersoneriaDaot"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["tipoPersoneriaDaot"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Nombres'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                registroventas.Nombres = oReader["Nombres"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["Nombres"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='ApePat'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                registroventas.ApePat = oReader["ApePat"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["ApePat"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='ApeMat'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                registroventas.ApeMat = oReader["ApeMat"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["ApeMat"]);

            return  registroventas;        
        }

        public Int32 InsertarRegistroVentas(DataTable oDt)
        {
            Int32 resp;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_InsertarRegistroVentas", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.CommandTimeout = 0;
                    SqlParameter oParametro = new SqlParameter("@TablaRegVenta", SqlDbType.Structured)
                    {
                        TypeName = "TipoTablaRegistroVentas",
                        Value = oDt
                    };

                    oComando.Parameters.Add(oParametro);

                    oConexion.Open();
                    resp = oComando.ExecuteNonQuery();
                }
            }

            return resp;
        }
        
        public RegistroVentasE ActualizarRegistroVentas(RegistroVentasE registroventas)
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ActualizarRegistroVentas", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = registroventas.idEmpresa;
					oComando.Parameters.Add("@idLocal", SqlDbType.Int).Value = registroventas.idLocal;
					oComando.Parameters.Add("@Anio", SqlDbType.Char, 4).Value = registroventas.Anio;
					oComando.Parameters.Add("@Mes", SqlDbType.Char, 2).Value = registroventas.Mes;
					oComando.Parameters.Add("@fecDocumento", SqlDbType.SmallDateTime).Value = registroventas.fecDocumento;
					oComando.Parameters.Add("@tipDocVenta", SqlDbType.VarChar, 2).Value = registroventas.tipDocVenta;
					oComando.Parameters.Add("@Serie", SqlDbType.VarChar, 20).Value = registroventas.Serie;
					oComando.Parameters.Add("@Numero", SqlDbType.VarChar, 20).Value = registroventas.Numero;
					oComando.Parameters.Add("@idPersona", SqlDbType.Int).Value = registroventas.idPersona;
					oComando.Parameters.Add("@tipDocPersona", SqlDbType.VarChar, 2).Value = registroventas.tipDocPersona;
					oComando.Parameters.Add("@numDocPersona", SqlDbType.VarChar, 15).Value = registroventas.numDocPersona;
					oComando.Parameters.Add("@RazonSocial", SqlDbType.VarChar, 100).Value = registroventas.RazonSocial;
                    oComando.Parameters.Add("@idMoneda", SqlDbType.Char, 2).Value = registroventas.idMoneda;
					oComando.Parameters.Add("@BaseExportacion", SqlDbType.Decimal).Value = registroventas.BaseExportacion;
					oComando.Parameters.Add("@BaseInafecta", SqlDbType.Decimal).Value = registroventas.BaseInafecta;
					oComando.Parameters.Add("@BaseImponible", SqlDbType.Decimal).Value = registroventas.BaseImponible;
					oComando.Parameters.Add("@Igv", SqlDbType.Decimal).Value = registroventas.Igv;
					oComando.Parameters.Add("@Total", SqlDbType.Decimal).Value = registroventas.Total;
					oComando.Parameters.Add("@Tica", SqlDbType.Decimal).Value = registroventas.Tica;
					oComando.Parameters.Add("@tipDocVentaRef", SqlDbType.VarChar, 2).Value = registroventas.tipDocVentaRef;
					oComando.Parameters.Add("@SerieRef", SqlDbType.VarChar, 4).Value = registroventas.SerieRef;
					oComando.Parameters.Add("@NumeroRef", SqlDbType.VarChar, 20).Value = registroventas.NumeroRef;
					oComando.Parameters.Add("@FechaRef", SqlDbType.SmallDateTime).Value = registroventas.FechaRef;
					oComando.Parameters.Add("@Percepcion", SqlDbType.Decimal).Value = registroventas.Percepcion;
					oComando.Parameters.Add("@csIgv", SqlDbType.Bit).Value = registroventas.csIgv;
					oComando.Parameters.Add("@Correlativo", SqlDbType.VarChar, 10).Value = registroventas.Correlativo;
					oComando.Parameters.Add("@UsuarioModificacion", SqlDbType.VarChar, 20).Value = registroventas.UsuarioModificacion;
					oComando.Parameters.Add("@FechaModificacion", SqlDbType.SmallDateTime).Value = registroventas.FechaModificacion;

                    oConexion.Open();
                    oComando.ExecuteNonQuery();
                }
            }

            return registroventas;
        }

        public Int32 EliminarRegistroVentas(Int32 idRegistro)
        {
            Int32 resp = 0;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_EliminarRegistroVentas", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idRegistro", SqlDbType.Int).Value = idRegistro;
                    oConexion.Open();

                    resp = oComando.ExecuteNonQuery();
                }
            }

            return resp;
        }

        public Int32 EliminarRegistroVentasPorFechas(Int32 idEmpresa, Int32 idLocal, DateTime fecInicial, DateTime fecFinal)
        {
            Int32 resp = 0;
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_EliminarRegistroVentasPorFechas", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.CommandTimeout = 0;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@idLocal", SqlDbType.Int).Value = idLocal;
                    oComando.Parameters.Add("@fecInicial", SqlDbType.SmallDateTime).Value = fecInicial;
                    oComando.Parameters.Add("@fecFinal", SqlDbType.SmallDateTime).Value = fecFinal;

                    oConexion.Open();
                    resp = oComando.ExecuteNonQuery();
                }
            }

            return resp;
        }

        public List<RegistroVentasE> ListarRegistroVentas()
        {
            List<RegistroVentasE> listaEntidad = new List<RegistroVentasE>();

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ListarRegistroVentas", oConexion))
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

        public RegistroVentasE ObtenerRegistroVentas(Int32 idRegistro)
        {        
            RegistroVentasE registroventas = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ObtenerRegistroVentas", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idRegistro", SqlDbType.Int).Value = idRegistro;

                    oConexion.Open();
                    
                    using (SqlDataReader oReader = oComando.ExecuteReader())
                    {
                        while (oReader.Read())
                        {
                            registroventas = LlenarEntidad(oReader);
                        }
                    }
                }
            }

            return registroventas;
        }

        public List<RegistroVentasE> RegistroDeVentasLe(Int32 idEmpresa, Int32 idLocal, DateTime fecIni, DateTime fecFin, String idMoneda)
        {
            List<RegistroVentasE> ListaVentas = new List<RegistroVentasE>();

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_RegistroDeVentasLe", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.CommandTimeout = 0;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@idLocal", SqlDbType.Int).Value = idLocal;
                    oComando.Parameters.Add("@fecIni", SqlDbType.SmallDateTime).Value = fecIni;
                    oComando.Parameters.Add("@fecFin", SqlDbType.SmallDateTime).Value = fecFin;
                    oComando.Parameters.Add("@idMoneda", SqlDbType.VarChar, 2).Value = idMoneda;

                    oConexion.Open();

                    using (SqlDataReader oReader = oComando.ExecuteReader())
                    {
                        while (oReader.Read())
                        {
                            ListaVentas.Add(LlenarEntidad(oReader));
                        }
                    }
                }
            }

            return ListaVentas;
        }

        public List<RegistroVentasE> RegistroDeVentasDaot(Int32 idEmpresa, Int32 idLocal, DateTime fecIni, DateTime fecFin, String idMoneda)
        {
            List<RegistroVentasE> ListaVentas = new List<RegistroVentasE>();

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_RegistroDeVentasDaot", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.CommandTimeout = 0;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@idLocal", SqlDbType.Int).Value = idLocal;
                    oComando.Parameters.Add("@fecIni", SqlDbType.SmallDateTime).Value = fecIni;
                    oComando.Parameters.Add("@fecFin", SqlDbType.SmallDateTime).Value = fecFin;
                    oComando.Parameters.Add("@idMoneda", SqlDbType.VarChar, 2).Value = idMoneda;

                    oConexion.Open();

                    using (SqlDataReader oReader = oComando.ExecuteReader())
                    {
                        while (oReader.Read())
                        {
                            ListaVentas.Add(LlenarEntidad(oReader));
                        }
                    }
                }
            }

            return ListaVentas;
        }

    }
}