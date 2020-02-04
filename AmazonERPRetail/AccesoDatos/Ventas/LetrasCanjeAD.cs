using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

using Entidades.Ventas;
using AccesoDatos.Util;

namespace AccesoDatos.Ventas
{
    public class LetrasCanjeAD : DbConection
    {

        public LetrasCanjeE LlenarEntidad(IDataReader oReader)
        {
            LetrasCanjeE letrascanje = new LetrasCanjeE();
            
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idEmpresa'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				letrascanje.idEmpresa = oReader["idEmpresa"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idEmpresa"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idLocal'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				letrascanje.idLocal = oReader["idLocal"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idLocal"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='tipCanje'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				letrascanje.tipCanje = oReader["tipCanje"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["tipCanje"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='codCanje'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				letrascanje.codCanje = oReader["codCanje"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["codCanje"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idDocumento'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				letrascanje.idDocumento = oReader["idDocumento"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["idDocumento"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='numSerie'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				letrascanje.numSerie = oReader["numSerie"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["numSerie"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='numDocumento'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				letrascanje.numDocumento = oReader["numDocumento"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["numDocumento"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idPersona'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				letrascanje.idPersona = oReader["idPersona"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idPersona"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='fecDocumento'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				letrascanje.fecDocumento = oReader["fecDocumento"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["fecDocumento"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idMoneda'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				letrascanje.idMoneda = oReader["idMoneda"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["idMoneda"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='tipCambioDoc'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                letrascanje.tipCambioDoc = oReader["tipCambioDoc"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["tipCambioDoc"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='SaldoDoc'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				letrascanje.SaldoDoc = oReader["SaldoDoc"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["SaldoDoc"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idComprobante'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				letrascanje.idComprobante = oReader["idComprobante"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["idComprobante"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='numFile'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				letrascanje.numFile = oReader["numFile"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["numFile"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='AnioPeriodo'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				letrascanje.AnioPeriodo = oReader["AnioPeriodo"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["AnioPeriodo"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='MesPeriodo'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				letrascanje.MesPeriodo = oReader["MesPeriodo"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["MesPeriodo"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='numVoucher'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				letrascanje.numVoucher = oReader["numVoucher"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["numVoucher"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='fecProceso'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				letrascanje.fecProceso = oReader["fecProceso"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["fecProceso"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Glosa'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				letrascanje.Glosa = oReader["Glosa"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["Glosa"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='numVerPlanCuentas'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                letrascanje.numVerPlanCuentas = oReader["numVerPlanCuentas"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["numVerPlanCuentas"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='codCuenta'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                letrascanje.codCuenta = oReader["codCuenta"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["codCuenta"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idCtaCte'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                letrascanje.idCtaCte = oReader["idCtaCte"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idCtaCte"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idCtaCteItem'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                letrascanje.idCtaCteItem = oReader["idCtaCteItem"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idCtaCteItem"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='fecAprobacion'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                letrascanje.fecAprobacion = oReader["fecAprobacion"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(oReader["fecAprobacion"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='UsuarioRegistro'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				letrascanje.UsuarioRegistro = oReader["UsuarioRegistro"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["UsuarioRegistro"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='FechaRegistro'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				letrascanje.FechaRegistro = oReader["FechaRegistro"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["FechaRegistro"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='UsuarioModificacion'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				letrascanje.UsuarioModificacion = oReader["UsuarioModificacion"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["UsuarioModificacion"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='FechaModificacion'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				letrascanje.FechaModificacion = oReader["FechaModificacion"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["FechaModificacion"]);

            //Extensiones
            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='desMoneda'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                letrascanje.desMoneda = oReader["desMoneda"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["desMoneda"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='RazonSocial'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                letrascanje.RazonSocial = oReader["RazonSocial"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["RazonSocial"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Ruc'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                letrascanje.Ruc = oReader["Ruc"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["Ruc"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='desDocumento'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                letrascanje.desDocumento = oReader["desDocumento"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["desDocumento"]);

            return  letrascanje;
        }

        public LetrasCanjeE InsertarLetrasCanje(LetrasCanjeE letrascanje)
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_InsertarLetrasCanje", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = letrascanje.idEmpresa;
					oComando.Parameters.Add("@idLocal", SqlDbType.Int).Value = letrascanje.idLocal;
					oComando.Parameters.Add("@tipCanje", SqlDbType.Char, 2).Value = letrascanje.tipCanje;
					oComando.Parameters.Add("@codCanje", SqlDbType.Char, 10).Value = letrascanje.codCanje;
					oComando.Parameters.Add("@idDocumento", SqlDbType.Char, 2).Value = letrascanje.idDocumento;
					oComando.Parameters.Add("@numSerie", SqlDbType.VarChar, 20).Value = letrascanje.numSerie;
					oComando.Parameters.Add("@numDocumento", SqlDbType.VarChar, 20).Value = letrascanje.numDocumento;
					oComando.Parameters.Add("@idPersona", SqlDbType.Int).Value = letrascanje.idPersona;
					oComando.Parameters.Add("@fecDocumento", SqlDbType.SmallDateTime).Value = letrascanje.fecDocumento;
					oComando.Parameters.Add("@idMoneda", SqlDbType.VarChar, 2).Value = letrascanje.idMoneda;
                    oComando.Parameters.Add("@tipCambioDoc", SqlDbType.Decimal).Value = letrascanje.tipCambioDoc;
                    oComando.Parameters.Add("@SaldoDoc", SqlDbType.Decimal).Value = letrascanje.SaldoDoc;
					oComando.Parameters.Add("@fecProceso", SqlDbType.DateTime).Value = letrascanje.fecProceso;
					oComando.Parameters.Add("@Glosa", SqlDbType.VarChar, 200).Value = letrascanje.Glosa;
                    oComando.Parameters.Add("@numVerPlanCuentas", SqlDbType.VarChar, 3).Value = letrascanje.numVerPlanCuentas;
                    oComando.Parameters.Add("@codCuenta", SqlDbType.VarChar, 20).Value = letrascanje.codCuenta;
                    oComando.Parameters.Add("@idCtaCte", SqlDbType.Int).Value = letrascanje.idCtaCte;
                    oComando.Parameters.Add("@UsuarioRegistro", SqlDbType.VarChar, 20).Value = letrascanje.UsuarioRegistro;

                    oConexion.Open();
                    oComando.ExecuteNonQuery();
                }
            }

            return letrascanje;
        }
        
        public LetrasCanjeE ActualizarLetrasCanje(LetrasCanjeE letrascanje)
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ActualizarLetrasCanje", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = letrascanje.idEmpresa;
					oComando.Parameters.Add("@idLocal", SqlDbType.Int).Value = letrascanje.idLocal;
					oComando.Parameters.Add("@tipCanje", SqlDbType.Char, 2).Value = letrascanje.tipCanje;
					oComando.Parameters.Add("@codCanje", SqlDbType.Char, 10).Value = letrascanje.codCanje;
					oComando.Parameters.Add("@idDocumento", SqlDbType.Char, 2).Value = letrascanje.idDocumento;
					oComando.Parameters.Add("@numSerie", SqlDbType.VarChar, 20).Value = letrascanje.numSerie;
					oComando.Parameters.Add("@numDocumento", SqlDbType.VarChar, 20).Value = letrascanje.numDocumento;
					oComando.Parameters.Add("@idPersona", SqlDbType.Int).Value = letrascanje.idPersona;
					oComando.Parameters.Add("@fecDocumento", SqlDbType.SmallDateTime).Value = letrascanje.fecDocumento;
					oComando.Parameters.Add("@idMoneda", SqlDbType.VarChar, 2).Value = letrascanje.idMoneda;
                    oComando.Parameters.Add("@tipCambioDoc", SqlDbType.Decimal).Value = letrascanje.tipCambioDoc;
                    oComando.Parameters.Add("@SaldoDoc", SqlDbType.Decimal).Value = letrascanje.SaldoDoc;
					oComando.Parameters.Add("@fecProceso", SqlDbType.DateTime).Value = letrascanje.fecProceso;
					oComando.Parameters.Add("@Glosa", SqlDbType.VarChar, 200).Value = letrascanje.Glosa;
                    oComando.Parameters.Add("@numVerPlanCuentas", SqlDbType.VarChar, 3).Value = letrascanje.numVerPlanCuentas;
                    oComando.Parameters.Add("@codCuenta", SqlDbType.VarChar, 20).Value = letrascanje.codCuenta;
                    oComando.Parameters.Add("@idCtaCte", SqlDbType.Int).Value = letrascanje.idCtaCte;
                    oComando.Parameters.Add("@UsuarioModificacion", SqlDbType.VarChar, 20).Value = letrascanje.UsuarioModificacion;

                    oConexion.Open();
                    oComando.ExecuteNonQuery();
                }
            }

            return letrascanje;
        }

        public Int32 EliminarLetrasCanje(Int32 idEmpresa, Int32 idLocal, String tipCanje, String codCanje)
        {
            Int32 resp = 0;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_EliminarLetrasCanje", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@idLocal", SqlDbType.Int).Value = idLocal;
                    oComando.Parameters.Add("@tipCanje", SqlDbType.Char, 2).Value = tipCanje;
                    oComando.Parameters.Add("@codCanje", SqlDbType.Char, 10).Value = codCanje;

                    oConexion.Open();
                    resp = oComando.ExecuteNonQuery();
                }
            }

            return resp;
        }

        public List<LetrasCanjeE> ListarLetrasCanje(Int32 idEmpresa, Int32 idLocal, String tipCanje, String codCanje)
        {
            List<LetrasCanjeE> listaEntidad = new List<LetrasCanjeE>();

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ListarLetrasCanje", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@idLocal", SqlDbType.Int).Value = idLocal;
                    oComando.Parameters.Add("@tipCanje", SqlDbType.Char, 2).Value = tipCanje;
                    oComando.Parameters.Add("@codCanje", SqlDbType.Char, 10).Value = codCanje;

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
        
        public LetrasCanjeE ObtenerLetrasCanje(Int32 idEmpresa, Int32 idLocal, String tipCanje, String codCanje)
        {        
            LetrasCanjeE letrascanje = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ObtenerLetrasCanje", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
					oComando.Parameters.Add("@idLocal", SqlDbType.Int).Value = idLocal;
					oComando.Parameters.Add("@tipCanje", SqlDbType.Char, 2).Value = tipCanje;
					oComando.Parameters.Add("@codCanje", SqlDbType.Char, 10).Value = codCanje;

                    oConexion.Open();
                    
                    using (SqlDataReader oReader = oComando.ExecuteReader())
                    {
                        while (oReader.Read())
                        {
                            letrascanje = LlenarEntidad(oReader);
                        }
                    }
                }
            }

            return letrascanje;
        }

        public Int32 GenerarCodCanje(Int32 idEmpresa, Int32 idLocal, String tipCanje)
        {
            Int32 CodigoRetorno = 0;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_GenerarCodCanje", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@idLocal", SqlDbType.Int).Value = idLocal;
                    oComando.Parameters.Add("@tipCanje", SqlDbType.Char, 2).Value = tipCanje;

                    oConexion.Open();
                    CodigoRetorno = Convert.ToInt32(oComando.ExecuteScalar().ToString());
                }
            }

            return CodigoRetorno;
        }

        public LetrasCanjeE LetrasCanjePorDocumento(Int32 idEmpresa, Int32 idLocal, String idDocumento, String numSerie, String numDocumento)
        {
            LetrasCanjeE letrascanje = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_LetrasCanjePorDocumento", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@idLocal", SqlDbType.Int).Value = idLocal;
                    oComando.Parameters.Add("@idDocumento", SqlDbType.Char, 2).Value = idDocumento;
                    oComando.Parameters.Add("@numSerie", SqlDbType.VarChar, 20).Value = numSerie;
                    oComando.Parameters.Add("@numDocumento", SqlDbType.VarChar, 20).Value = numDocumento;

                    oConexion.Open();

                    using (SqlDataReader oReader = oComando.ExecuteReader())
                    {
                        while (oReader.Read())
                        {
                            letrascanje = LlenarEntidad(oReader);
                        }
                    }
                }
            }

            return letrascanje;
        }

        public List<LetrasCanjeE> ListarLetrasCanjeCtaCte(Int32 idEmpresa, Int32 idLocal, String tipCanje, String codCanje)
        {
            List<LetrasCanjeE> listaEntidad = new List<LetrasCanjeE>();

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ListarLetrasCanjeCtaCte", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@idLocal", SqlDbType.Int).Value = idLocal;
                    oComando.Parameters.Add("@tipCanje", SqlDbType.Char, 2).Value = tipCanje;
                    oComando.Parameters.Add("@codCanje", SqlDbType.Char, 10).Value = codCanje;

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

        public Int32 ActualizarLetrasCanjeConta(Int32 idEmpresa, Int32 idLocal, String tipCanje, String codCanje, String idComprobante, String numFile, String Anio, String Mes, String Voucher, String Usuario)
        {
            Int32 resp = 0;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ActualizarLetrasCanjeConta", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@idLocal", SqlDbType.Int).Value = idLocal;
                    oComando.Parameters.Add("@tipCanje", SqlDbType.Char, 2).Value = tipCanje;
                    oComando.Parameters.Add("@codCanje", SqlDbType.Char, 10).Value = codCanje;
                    oComando.Parameters.Add("@idComprobante", SqlDbType.VarChar, 2).Value = idComprobante;
                    oComando.Parameters.Add("@numFile", SqlDbType.VarChar, 2).Value = numFile;
                    oComando.Parameters.Add("@AnioPeriodo", SqlDbType.VarChar, 4).Value = Anio;
                    oComando.Parameters.Add("@MesPeriodo", SqlDbType.VarChar, 2).Value = Mes;
                    oComando.Parameters.Add("@numVoucher", SqlDbType.VarChar, 9).Value = Voucher;
                    oComando.Parameters.Add("@UsuarioModificacion", SqlDbType.VarChar, 20).Value = Usuario;

                    oConexion.Open();
                    resp = oComando.ExecuteNonQuery();
                }
            }

            return resp;
        }

        public Int32 ActualizarLetrasCanjeIdCtaCteItem(LetrasCanjeE letrascanje)
        {
            Int32 resp = 0;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ActualizarLetrasCanjeIdCtaCteItem", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = letrascanje.idEmpresa;
                    oComando.Parameters.Add("@idLocal", SqlDbType.Int).Value = letrascanje.idLocal;
                    oComando.Parameters.Add("@tipCanje", SqlDbType.Char, 2).Value = letrascanje.tipCanje;
                    oComando.Parameters.Add("@codCanje", SqlDbType.Char, 10).Value = letrascanje.codCanje;
                    oComando.Parameters.Add("@idDocumento", SqlDbType.Char, 2).Value = letrascanje.idDocumento;
                    oComando.Parameters.Add("@numSerie", SqlDbType.VarChar, 20).Value = letrascanje.numSerie;
                    oComando.Parameters.Add("@numDocumento", SqlDbType.VarChar, 20).Value = letrascanje.numDocumento;
                    oComando.Parameters.Add("@idPersona", SqlDbType.Int).Value = letrascanje.idPersona;
                    oComando.Parameters.Add("@idCtaCteItem", SqlDbType.Int).Value = letrascanje.idCtaCteItem;
                    oComando.Parameters.Add("@UsuarioModificacion", SqlDbType.VarChar, 20).Value = letrascanje.UsuarioModificacion;

                    oConexion.Open();
                    oComando.ExecuteNonQuery();
                }
            }

            return resp;
        }

        public Int32 ActualizarLetrasCanjeIdCtaCte(Int32 idEmpresa, Int32 idLocal, String tipCanje, String codCanje, String idDocumento, String numSerie, String numDocumento, Decimal tipCambioDoc, String numVerPlanCuentas, String codCuenta, Int32 idCtaCte)
        {
            Int32 resp = 0;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ActualizarLetrasCanjeIdCtaCte", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@idLocal", SqlDbType.Int).Value = idLocal;
                    oComando.Parameters.Add("@tipCanje", SqlDbType.Char, 2).Value = tipCanje;
                    oComando.Parameters.Add("@codCanje", SqlDbType.Char, 10).Value = codCanje;
                    oComando.Parameters.Add("@idDocumento", SqlDbType.Char, 2).Value = idDocumento;
                    oComando.Parameters.Add("@numSerie", SqlDbType.VarChar, 20).Value = numSerie;
                    oComando.Parameters.Add("@numDocumento", SqlDbType.VarChar, 20).Value = numDocumento;
                    oComando.Parameters.Add("@tipCambioDoc", SqlDbType.Decimal).Value = tipCambioDoc;
                    oComando.Parameters.Add("@numVerPlanCuentas", SqlDbType.VarChar, 3).Value = numVerPlanCuentas;
                    oComando.Parameters.Add("@codCuenta", SqlDbType.VarChar, 20).Value = codCuenta;
                    oComando.Parameters.Add("@idCtaCte", SqlDbType.Int).Value = idCtaCte;

                    oConexion.Open();

                    resp = oComando.ExecuteNonQuery();
                }
            }

            return resp;
        }

        public Int32 ActualizarFecAprobacionLetrasCanje(Int32 idEmpresa, Int32 idLocal, String tipCanje, String codCanje, DateTime? fecAprobacion, String Usuario)
        {
            Int32 resp = 0;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ActualizarFecAprobacionLetrasCanje", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@idLocal", SqlDbType.Int).Value = idLocal;
                    oComando.Parameters.Add("@tipCanje", SqlDbType.Char, 2).Value = tipCanje;
                    oComando.Parameters.Add("@codCanje", SqlDbType.Char, 10).Value = codCanje;
                    oComando.Parameters.Add("@fecAprobacion", SqlDbType.SmallDateTime).Value = fecAprobacion;
                    oComando.Parameters.Add("@Usuario", SqlDbType.VarChar, 20).Value = Usuario;

                    oConexion.Open();
                    oComando.ExecuteNonQuery();
                }
            }

            return resp;
        }

    }
}