using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

using Entidades.Maestros;
using AccesoDatos.Util;

namespace AccesoDatos.Maestros
{
    public class BancosCuentasAD : DbConection
    {

        public BancosCuentasE LlenarEntidad(IDataReader oReader)
        {
            BancosCuentasE bancoscuentas = new BancosCuentasE();
            
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idPersona'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				bancoscuentas.idPersona = oReader["idPersona"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idPersona"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idEmpresa'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				bancoscuentas.idEmpresa = oReader["idEmpresa"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idEmpresa"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idBancosCuentas'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                bancoscuentas.idBancosCuentas = oReader["idBancosCuentas"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idBancosCuentas"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='numCuenta'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				bancoscuentas.numCuenta = oReader["numCuenta"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["numCuenta"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='numCuentaInter'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                bancoscuentas.numCuentaInter = oReader["numCuentaInter"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["numCuentaInter"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idLocal'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				bancoscuentas.idLocal = oReader["idLocal"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idLocal"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='tipCuenta'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				bancoscuentas.tipCuenta = oReader["tipCuenta"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["tipCuenta"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idMoneda'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				bancoscuentas.idMoneda = oReader["idMoneda"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["idMoneda"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='numVerPlanCuentas'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				bancoscuentas.numVerPlanCuentas = oReader["numVerPlanCuentas"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["numVerPlanCuentas"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='codCuenta'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				bancoscuentas.codCuenta = oReader["codCuenta"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["codCuenta"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='numCheque'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				bancoscuentas.numCheque = oReader["numCheque"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["numCheque"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='numChequeIni'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				bancoscuentas.numChequeIni = oReader["numChequeIni"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["numChequeIni"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='numChequeFin'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				bancoscuentas.numChequeFin = oReader["numChequeFin"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["numChequeFin"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='FormatoCheque'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				bancoscuentas.FormatoCheque = oReader["FormatoCheque"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["FormatoCheque"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='indDocumentos'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                bancoscuentas.indDocumentos = oReader["indDocumentos"] == DBNull.Value ? false : Convert.ToBoolean(oReader["indDocumentos"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='indBaja'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				bancoscuentas.indBaja = oReader["indBaja"] == DBNull.Value ? false : Convert.ToBoolean(oReader["indBaja"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='fecBaja'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				bancoscuentas.fecBaja = oReader["fecBaja"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["fecBaja"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='UsuarioRegistro'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				bancoscuentas.UsuarioRegistro = oReader["UsuarioRegistro"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["UsuarioRegistro"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='FechaRegistro'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				bancoscuentas.FechaRegistro = oReader["FechaRegistro"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["FechaRegistro"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='UsuarioModificacion'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				bancoscuentas.UsuarioModificacion = oReader["UsuarioModificacion"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["UsuarioModificacion"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='FechaModificacion'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				bancoscuentas.FechaModificacion = oReader["FechaModificacion"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["FechaModificacion"]);

            //Extensiones
            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='desCuenta'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                bancoscuentas.desCuenta = oReader["desCuenta"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["desCuenta"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='desMoneda'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                bancoscuentas.desMoneda = oReader["desMoneda"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["desMoneda"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='desTipCuenta'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                bancoscuentas.desTipCuenta = oReader["desTipCuenta"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["desTipCuenta"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='RazonSocial'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                bancoscuentas.RazonSocial = oReader["RazonSocial"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["RazonSocial"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='desCuentaBanco'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                bancoscuentas.desCuentaBanco = oReader["desCuentaBanco"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["desCuentaBanco"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='SolicitaDoc'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                bancoscuentas.SolicitaDoc = oReader["SolicitaDoc"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["SolicitaDoc"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='DescripcionCuenta'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                bancoscuentas.DescripcionCuenta = oReader["DescripcionCuenta"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["DescripcionCuenta"]);            

            return  bancoscuentas;        
        }

        public BancosCuentasE InsertarBancosCuentas(BancosCuentasE bancoscuentas)
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_InsertarBancosCuentas", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idPersona", SqlDbType.Int).Value = bancoscuentas.idPersona;
					oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = bancoscuentas.idEmpresa;
					oComando.Parameters.Add("@numCuenta", SqlDbType.VarChar, 20).Value = bancoscuentas.numCuenta;
                    oComando.Parameters.Add("@numCuentaInter", SqlDbType.VarChar, 50).Value = bancoscuentas.numCuentaInter;
                    oComando.Parameters.Add("@idLocal", SqlDbType.Int).Value = bancoscuentas.idLocal;
					oComando.Parameters.Add("@tipCuenta", SqlDbType.VarChar, 20).Value = bancoscuentas.tipCuenta;
					oComando.Parameters.Add("@idMoneda", SqlDbType.VarChar, 20).Value = bancoscuentas.idMoneda;
					oComando.Parameters.Add("@numVerPlanCuentas", SqlDbType.VarChar, 3).Value = bancoscuentas.numVerPlanCuentas;
					oComando.Parameters.Add("@codCuenta", SqlDbType.VarChar, 20).Value = bancoscuentas.codCuenta;
					oComando.Parameters.Add("@numCheque", SqlDbType.VarChar, 50).Value = bancoscuentas.numCheque;
					oComando.Parameters.Add("@numChequeIni", SqlDbType.VarChar, 50).Value = bancoscuentas.numChequeIni;
					oComando.Parameters.Add("@numChequeFin", SqlDbType.VarChar, 50).Value = bancoscuentas.numChequeFin;
					oComando.Parameters.Add("@FormatoCheque", SqlDbType.VarChar, 100).Value = bancoscuentas.FormatoCheque;
                    oComando.Parameters.Add("@indDocumentos", SqlDbType.Bit).Value = bancoscuentas.indDocumentos;
                    oComando.Parameters.Add("@indBaja", SqlDbType.Bit).Value = bancoscuentas.indBaja;
					oComando.Parameters.Add("@UsuarioRegistro", SqlDbType.VarChar, 20).Value = bancoscuentas.UsuarioRegistro;

                    oConexion.Open();
                    oComando.ExecuteNonQuery();
                }
            }

            return bancoscuentas;
        }
            
        public BancosCuentasE ActualizarBancosCuentas(BancosCuentasE bancoscuentas)
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ActualizarBancosCuentas", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idPersona", SqlDbType.Int).Value = bancoscuentas.idPersona;
					oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = bancoscuentas.idEmpresa;
                    oComando.Parameters.Add("@idBancosCuentas", SqlDbType.Int).Value = bancoscuentas.idBancosCuentas;
                    oComando.Parameters.Add("@numCuenta", SqlDbType.VarChar, 20).Value = bancoscuentas.numCuenta;
                    oComando.Parameters.Add("@numCuentaInter", SqlDbType.VarChar, 50).Value = bancoscuentas.numCuentaInter;
                    oComando.Parameters.Add("@idLocal", SqlDbType.Int).Value = bancoscuentas.idLocal;
					oComando.Parameters.Add("@tipCuenta", SqlDbType.VarChar, 20).Value = bancoscuentas.tipCuenta;
					oComando.Parameters.Add("@idMoneda", SqlDbType.VarChar, 20).Value = bancoscuentas.idMoneda;
					oComando.Parameters.Add("@numVerPlanCuentas", SqlDbType.VarChar, 3).Value = bancoscuentas.numVerPlanCuentas;
					oComando.Parameters.Add("@codCuenta", SqlDbType.VarChar, 20).Value = bancoscuentas.codCuenta;
					oComando.Parameters.Add("@numCheque", SqlDbType.VarChar, 50).Value = bancoscuentas.numCheque;
					oComando.Parameters.Add("@numChequeIni", SqlDbType.VarChar, 50).Value = bancoscuentas.numChequeIni;
					oComando.Parameters.Add("@numChequeFin", SqlDbType.VarChar, 50).Value = bancoscuentas.numChequeFin;
					oComando.Parameters.Add("@FormatoCheque", SqlDbType.VarChar, 100).Value = bancoscuentas.FormatoCheque;
                    oComando.Parameters.Add("@indDocumentos", SqlDbType.Bit).Value = bancoscuentas.indDocumentos;
                    oComando.Parameters.Add("@indBaja", SqlDbType.Bit).Value = bancoscuentas.indBaja;
					oComando.Parameters.Add("@UsuarioModificacion", SqlDbType.VarChar, 20).Value = bancoscuentas.UsuarioModificacion;

                    oConexion.Open();
                    oComando.ExecuteNonQuery();
                }
            }

            return bancoscuentas;
        }

        public Int32 EliminarBancosCuentas(Int32 idPersona, Int32 idEmpresa, Int32 IdBancosCuentas)
        {
            int resp = 0;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_EliminarBancosCuentas", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idPersona", SqlDbType.Int).Value = idPersona;
					oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@idBancosCuentas", SqlDbType.Int).Value = IdBancosCuentas;

                    oConexion.Open();
                    resp = oComando.ExecuteNonQuery();
                }
            }

            return resp;
        }

        public Int32 EliminarTodoBancosCuentas(Int32 idPersona, Int32 idEmpresa)
        {
            int resp = 0;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_EliminarTodoBancosCuentas", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idPersona", SqlDbType.Int).Value = idPersona;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;

                    oConexion.Open();
                    resp = oComando.ExecuteNonQuery();
                }
            }

            return resp;
        }

        public List<BancosCuentasE> ListarBancosCuentas(Int32 idEmpresa, Int32 idPersona)
        {
            List<BancosCuentasE> listaEntidad = new List<BancosCuentasE>();

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ListarBancosCuentas", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idPersona", SqlDbType.Int).Value = idPersona;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;

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
        
        public BancosCuentasE ObtenerBancosCuentas(Int32 idPersona, Int32 idEmpresa, String numCuenta)
        {        
            BancosCuentasE bancoscuentas = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ObtenerBancosCuentas", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idPersona", SqlDbType.Int).Value = idPersona;
					oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
					oComando.Parameters.Add("@numCuenta", SqlDbType.VarChar, 20).Value = numCuenta;

                    oConexion.Open();
                    
                    using (SqlDataReader oReader = oComando.ExecuteReader())
                    {
                        while (oReader.Read())
                        {
                            bancoscuentas = LlenarEntidad(oReader);
                        }
                    }
                }
            }

            return bancoscuentas;
        }

        public List<BancosCuentasE> ListarCuentasPorBancos(Int32 idEmpresa, Int32 idLocal, Int32 idPersona, String idMoneda)
        {
            List<BancosCuentasE> listaEntidad = new List<BancosCuentasE>();

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ListarCuentasPorBancos", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@idLocal", SqlDbType.Int).Value = idLocal;
                    oComando.Parameters.Add("@idPersona", SqlDbType.Int).Value = idPersona;
                    oComando.Parameters.Add("@idMoneda", SqlDbType.Text).Value = idMoneda;

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

        public List<BancosCuentasE> ListarCuentasParaDoc(Int32 idEmpresa)
        {
            List<BancosCuentasE> listaEntidad = new List<BancosCuentasE>();

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ListarCuentasParaDoc", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;

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

        public List<BancosCuentasE> BancosCuentasPorMoneda(Int32 idPersona, Int32 idEmpresa, String idMoneda)
        {
            List<BancosCuentasE> listaEntidad = new List<BancosCuentasE>();

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_BancosCuentasPorMoneda", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idPersona", SqlDbType.Int).Value = idPersona;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@idMoneda", SqlDbType.Text).Value = idMoneda;

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

        public BancosCuentasE ObtenerBancosPorNroCuenta(Int32 idEmpresa, String numCuenta)
        {
            BancosCuentasE bancoscuentas = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ObtenerBancosPorNroCuenta", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@numCuenta", SqlDbType.VarChar, 20).Value = numCuenta;

                    oConexion.Open();

                    using (SqlDataReader oReader = oComando.ExecuteReader())
                    {
                        while (oReader.Read())
                        {
                            bancoscuentas = LlenarEntidad(oReader);
                        }
                    }
                }
            }

            return bancoscuentas;
        }

        public BancosCuentasE ObtenerBancosPorCodCuenta(Int32 idEmpresa, String codCuenta)
        {
            BancosCuentasE bancoscuentas = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ObtenerBancosPorCodCuenta", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@codCuenta", SqlDbType.VarChar, 20).Value = codCuenta;

                    oConexion.Open();

                    using (SqlDataReader oReader = oComando.ExecuteReader())
                    {
                        while (oReader.Read())
                        {
                            bancoscuentas = LlenarEntidad(oReader);
                        }
                    }
                }
            }

            return bancoscuentas;
        }

        public List<BancosCuentasE> BancosCuentasPorEmpresa(Int32 idPersona, Int32 idEmpresa)
        {
            List<BancosCuentasE> listaEntidad = new List<BancosCuentasE>();

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_BancosCuentasPorEmpresa", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idPersona", SqlDbType.Int).Value = idPersona;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;

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