using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

using Entidades.Tesoreria;
using AccesoDatos.Util;

namespace AccesoDatos.Tesoreria
{
    public class FondoFijoAD : DbConection
    {

        public FondoFijoE LlenarEntidad(IDataReader oReader)
        {
            FondoFijoE fondofijo = new FondoFijoE();
            
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idEmpresa'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				fondofijo.idEmpresa = oReader["idEmpresa"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idEmpresa"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idLocal'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				fondofijo.idLocal = oReader["idLocal"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idLocal"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idPersona'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                fondofijo.idPersona = oReader["idPersona"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idPersona"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='numFondo'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                fondofijo.numFondo = oReader["numFondo"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["numFondo"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='desFondo'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				fondofijo.desFondo = oReader["desFondo"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["desFondo"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='TipoFondo'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                fondofijo.TipoFondo = oReader["TipoFondo"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["TipoFondo"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='numVerPlanCuentas'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				fondofijo.numVerPlanCuentas = oReader["numVerPlanCuentas"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["numVerPlanCuentas"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='codCuenta'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				fondofijo.codCuenta = oReader["codCuenta"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["codCuenta"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idComprobante'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				fondofijo.idComprobante = oReader["idComprobante"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["idComprobante"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='numFile'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				fondofijo.numFile = oReader["numFile"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["numFile"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idMoneda'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				fondofijo.idMoneda = oReader["idMoneda"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["idMoneda"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='MontoAutorizado'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                fondofijo.MontoAutorizado = oReader["MontoAutorizado"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["MontoAutorizado"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idPersonaResponsable'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				fondofijo.idPersonaResponsable = oReader["idPersonaResponsable"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idPersonaResponsable"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Tipo'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                fondofijo.Tipo = oReader["Tipo"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["Tipo"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idPersonaBanco'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                fondofijo.idPersonaBanco = oReader["idPersonaBanco"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idPersonaBanco"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='tipCuenta'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                fondofijo.tipCuenta = oReader["tipCuenta"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["tipCuenta"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idMonedaCuenta'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                fondofijo.idMonedaCuenta = oReader["idMonedaCuenta"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["idMonedaCuenta"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='numCuenta'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                fondofijo.numCuenta = oReader["numCuenta"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["numCuenta"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='numInterbancaria'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                fondofijo.numInterbancaria = oReader["numInterbancaria"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["numInterbancaria"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='TipoCuentaLiq'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                fondofijo.TipoCuentaLiq = oReader["TipoCuentaLiq"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["TipoCuentaLiq"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='UsuarioRegistro'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                fondofijo.UsuarioRegistro = oReader["UsuarioRegistro"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["UsuarioRegistro"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='FechaRegistro'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				fondofijo.FechaRegistro = oReader["FechaRegistro"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["FechaRegistro"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='UsuarioModificacion'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                fondofijo.UsuarioModificacion = oReader["UsuarioModificacion"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["UsuarioModificacion"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='FechaModificacion'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				fondofijo.FechaModificacion = oReader["FechaModificacion"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["FechaModificacion"]);

            //Extensiones 
            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='desResponsable'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                fondofijo.desResponsable = oReader["desResponsable"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["desResponsable"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='desCuenta'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                fondofijo.desCuenta = oReader["desCuenta"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["desCuenta"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='desPersona'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                fondofijo.desPersona = oReader["desPersona"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["desPersona"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='desMoneda'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                fondofijo.desMoneda = oReader["desMoneda"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["desMoneda"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='RUC'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                fondofijo.RUC = oReader["RUC"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["RUC"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='desBanco'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                fondofijo.desBanco = oReader["desBanco"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["desBanco"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='nroResponsable'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                fondofijo.nroResponsable = oReader["nroResponsable"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["nroResponsable"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='desTipoFondo'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                fondofijo.desTipoFondo = oReader["desTipoFondo"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["desTipoFondo"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='desTipoCuentaLiq'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                fondofijo.desTipoCuentaLiq = oReader["desTipoCuentaLiq"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["desTipoCuentaLiq"]);

            return  fondofijo;        
        }

        public FondoFijoE InsertarFondoFijo(FondoFijoE fondofijo)
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_InsertarFondoFijo", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = fondofijo.idEmpresa;
					oComando.Parameters.Add("@idLocal", SqlDbType.Int).Value = fondofijo.idLocal;
					oComando.Parameters.Add("@idPersona", SqlDbType.Int).Value = fondofijo.idPersona;
                    oComando.Parameters.Add("@numFondo", SqlDbType.VarChar, 20).Value = fondofijo.numFondo;
                    oComando.Parameters.Add("@desFondo", SqlDbType.VarChar, 50).Value = fondofijo.desFondo;
                    oComando.Parameters.Add("@TipoFondo", SqlDbType.VarChar, 3).Value = fondofijo.TipoFondo;
                    oComando.Parameters.Add("@numVerPlanCuentas", SqlDbType.VarChar, 3).Value = fondofijo.numVerPlanCuentas;
					oComando.Parameters.Add("@codCuenta", SqlDbType.VarChar, 20).Value = fondofijo.codCuenta;
					oComando.Parameters.Add("@idComprobante", SqlDbType.Char, 2).Value = fondofijo.idComprobante;
					oComando.Parameters.Add("@numFile", SqlDbType.Char, 2).Value = fondofijo.numFile;
					oComando.Parameters.Add("@idMoneda", SqlDbType.VarChar, 2).Value = fondofijo.idMoneda;
                    oComando.Parameters.Add("@MontoAutorizado", SqlDbType.Decimal).Value = fondofijo.MontoAutorizado;
                    oComando.Parameters.Add("@idPersonaResponsable", SqlDbType.Int).Value = fondofijo.idPersonaResponsable;
                    oComando.Parameters.Add("@Tipo", SqlDbType.VarChar, 1).Value = fondofijo.Tipo;
                    oComando.Parameters.Add("@idPersonaBanco", SqlDbType.Int).Value = fondofijo.idPersonaBanco;
                    oComando.Parameters.Add("@tipCuenta", SqlDbType.Int).Value = fondofijo.tipCuenta;
                    oComando.Parameters.Add("@idMonedaCuenta", SqlDbType.VarChar, 2).Value = fondofijo.idMonedaCuenta;
                    oComando.Parameters.Add("@numCuenta", SqlDbType.VarChar, 20).Value = fondofijo.numCuenta;
                    oComando.Parameters.Add("@numInterbancaria", SqlDbType.VarChar, 20).Value = fondofijo.numInterbancaria;
                    oComando.Parameters.Add("@TipoCuentaLiq", SqlDbType.Int).Value = fondofijo.TipoCuentaLiq;
                    oComando.Parameters.Add("@UsuarioRegistro", SqlDbType.VarChar, 20).Value = fondofijo.UsuarioRegistro;

                    oConexion.Open();
                    oComando.ExecuteNonQuery();
                }
            }

            return fondofijo;
        }
        
        public FondoFijoE ActualizarFondoFijo(FondoFijoE fondofijo)
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ActualizarFondoFijo", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = fondofijo.idEmpresa;
                    oComando.Parameters.Add("@idLocal", SqlDbType.Int).Value = fondofijo.idLocal;
                    oComando.Parameters.Add("@idPersona", SqlDbType.Int).Value = fondofijo.idPersona;
                    oComando.Parameters.Add("@numFondo", SqlDbType.VarChar, 20).Value = fondofijo.numFondo;
                    oComando.Parameters.Add("@desFondo", SqlDbType.VarChar, 50).Value = fondofijo.desFondo;
                    oComando.Parameters.Add("@TipoFondo", SqlDbType.VarChar, 3).Value = fondofijo.TipoFondo;
                    oComando.Parameters.Add("@numVerPlanCuentas", SqlDbType.VarChar, 3).Value = fondofijo.numVerPlanCuentas;
                    oComando.Parameters.Add("@codCuenta", SqlDbType.VarChar, 20).Value = fondofijo.codCuenta;
                    oComando.Parameters.Add("@idComprobante", SqlDbType.Char, 2).Value = fondofijo.idComprobante;
                    oComando.Parameters.Add("@numFile", SqlDbType.Char, 2).Value = fondofijo.numFile;
                    oComando.Parameters.Add("@idMoneda", SqlDbType.VarChar, 2).Value = fondofijo.idMoneda;
                    oComando.Parameters.Add("@MontoAutorizado", SqlDbType.Decimal).Value = fondofijo.MontoAutorizado;
                    oComando.Parameters.Add("@idPersonaResponsable", SqlDbType.Int).Value = fondofijo.idPersonaResponsable;
                    oComando.Parameters.Add("@Tipo", SqlDbType.VarChar, 1).Value = fondofijo.Tipo;
                    oComando.Parameters.Add("@idPersonaBanco", SqlDbType.Int).Value = fondofijo.idPersonaBanco;
                    oComando.Parameters.Add("@tipCuenta", SqlDbType.Int).Value = fondofijo.tipCuenta;
                    oComando.Parameters.Add("@idMonedaCuenta", SqlDbType.VarChar, 2).Value = fondofijo.idMonedaCuenta;
                    oComando.Parameters.Add("@numCuenta", SqlDbType.VarChar, 20).Value = fondofijo.numCuenta;
                    oComando.Parameters.Add("@numInterbancaria", SqlDbType.VarChar, 20).Value = fondofijo.numInterbancaria;
                    oComando.Parameters.Add("@TipoCuentaLiq", SqlDbType.Int).Value = fondofijo.TipoCuentaLiq;
                    oComando.Parameters.Add("@UsuarioModificacion", SqlDbType.VarChar, 20).Value = fondofijo.UsuarioModificacion;

                    oConexion.Open();
                    oComando.ExecuteNonQuery();
                }
            }

            return fondofijo;
        }        

        public int EliminarFondoFijo(Int32 idEmpresa, Int32 idLocal, Int32 idPersona)
        {
            int resp = 0;
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_EliminarFondoFijo", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
					oComando.Parameters.Add("@idLocal", SqlDbType.Int).Value = idLocal;
					oComando.Parameters.Add("@idPersona", SqlDbType.Int).Value = idPersona;

                    oConexion.Open();
                    resp = oComando.ExecuteNonQuery();
                }
            }

            return resp;
        }

        public List<FondoFijoE> ListarFondoFijo(Int32 idEmpresa, Int32 idLocal, String TipoFondo)
        {
            List<FondoFijoE> listaEntidad = new List<FondoFijoE>();

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ListarFondoFijo", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@idLocal", SqlDbType.Int).Value = idLocal;
                    oComando.Parameters.Add("@TipoFondo", SqlDbType.VarChar, 3).Value = TipoFondo;

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
        
        public FondoFijoE ObtenerFondoFijo(Int32 idEmpresa, Int32 idLocal, Int32 idPersona)
        {        
            FondoFijoE fondofijo = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ObtenerFondoFijo", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
					oComando.Parameters.Add("@idLocal", SqlDbType.Int).Value = idLocal;
					oComando.Parameters.Add("@idPersona", SqlDbType.Int).Value = idPersona;

                    oConexion.Open();
                    
                    using (SqlDataReader oReader = oComando.ExecuteReader())
                    {
                        while (oReader.Read())
                        {
                            fondofijo = LlenarEntidad(oReader);
                        }
                    }
                }
            }

            return fondofijo;
        }

        public String NroFondoFijo(Int32 idEmpresa, Int32 idLocal)
        {
            String Numero = String.Empty;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_NroFondoFijo", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@idLocal", SqlDbType.Int).Value = idLocal;

                    oConexion.Open();

                    using (SqlDataReader oReader = oComando.ExecuteReader())
                    {
                        if (oReader.Read())
                        {
                            Numero = Convert.ToString(oReader["numFondo"]);
                        }
                    }
                }
            }

            return Numero;
        }

        public List<FondoFijoE> FondoFijoCuentas(Int32 idEmpresa, Int32 idLocal, Int32 idPersona)
        {
            List<FondoFijoE> fondofijo = new List<FondoFijoE>();

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_FondoFijoCuentas", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@idLocal", SqlDbType.Int).Value = idLocal;
                    oComando.Parameters.Add("@idPersona", SqlDbType.Int).Value = idPersona;

                    oConexion.Open();

                    using (SqlDataReader oReader = oComando.ExecuteReader())
                    {
                        while (oReader.Read())
                        {
                            fondofijo.Add(LlenarEntidad(oReader));
                        }
                    }
                }
            }

            return fondofijo;
        }

        public int FondoFijoPorTipoFondoResp(Int32 idEmpresa, Int32 idLocal, String TipoFondo, Int32 idPersonaResponsable)
        {
            int resp = 0;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_FondoFijoPorTipoFondoResp", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@idLocal", SqlDbType.Int).Value = idLocal;
                    oComando.Parameters.Add("@TipoFondo", SqlDbType.VarChar, 3).Value = TipoFondo;
                    oComando.Parameters.Add("@idPersonaResponsable", SqlDbType.Int).Value = idPersonaResponsable;

                    oConexion.Open();
                    resp = Convert.ToInt32(oComando.ExecuteScalar());
                }
            }

            return resp;
        }

        public List<FondoFijoE> ListarFondoFijoPorResponsable(Int32 idEmpresa, Int32 idLocal, Int32 idPersonaResponsable)
        {
            List<FondoFijoE> oListaFondos = new List<FondoFijoE>();

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ListarFondoFijoPorResponsable", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@idLocal", SqlDbType.Int).Value = idLocal;
                    oComando.Parameters.Add("@idPersonaResponsable", SqlDbType.Int).Value = idPersonaResponsable;

                    oConexion.Open();

                    using (SqlDataReader oReader = oComando.ExecuteReader())
                    {
                        while (oReader.Read())
                        {
                            oListaFondos.Add(LlenarEntidad(oReader));
                        }
                    }
                }
            }

            return oListaFondos;
        }


    }
}