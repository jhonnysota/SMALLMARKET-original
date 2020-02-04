using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

using Entidades.CtasPorCobrar;
using AccesoDatos.Util;

namespace AccesoDatos.CtasPorCobrar
{
    public class TipoIngresosAD : DbConection
    {

        public TipoIngresosE LlenarEntidad(IDataReader oReader)
        {
            TipoIngresosE tipoingresos = new TipoIngresosE();
            
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idEmpresa'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				tipoingresos.idEmpresa = oReader["idEmpresa"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idEmpresa"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='TipoCobro'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				tipoingresos.TipoCobro = oReader["TipoCobro"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["TipoCobro"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Tipo'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				tipoingresos.Tipo = oReader["Tipo"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["Tipo"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='TipoOperacion'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				tipoingresos.TipoOperacion = oReader["TipoOperacion"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["TipoOperacion"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Descripcion'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				tipoingresos.Descripcion = oReader["Descripcion"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["Descripcion"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='SelCuenta'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				tipoingresos.SelCuenta = oReader["SelCuenta"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["SelCuenta"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='numVerPlanCuentas'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                tipoingresos.numVerPlanCuentas = oReader["numVerPlanCuentas"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["numVerPlanCuentas"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='filtroCuenta'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				tipoingresos.filtroCuenta = oReader["filtroCuenta"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["filtroCuenta"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='ctaSoles'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                tipoingresos.ctaSoles = oReader["ctaSoles"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["ctaSoles"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='ctaDolares'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                tipoingresos.ctaDolares = oReader["ctaDolares"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["ctaDolares"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='indCtaProvision'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				tipoingresos.indCtaProvision = oReader["indCtaProvision"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["indCtaProvision"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='codCuentaSoles'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				tipoingresos.codCuentaSoles = oReader["codCuentaSoles"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["codCuentaSoles"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='codCuentaDolares'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				tipoingresos.codCuentaDolares = oReader["codCuentaDolares"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["codCuentaDolares"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='indManipularMontos'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                tipoingresos.indManipularMontos = oReader["indManipularMontos"] == DBNull.Value ? false : Convert.ToBoolean(oReader["indManipularMontos"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='indManipularMoneda'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                tipoingresos.indManipularMoneda = oReader["indManipularMoneda"] == DBNull.Value ? false : Convert.ToBoolean(oReader["indManipularMoneda"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='UsuarioRegistro'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                tipoingresos.UsuarioRegistro = oReader["UsuarioRegistro"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["UsuarioRegistro"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='FechaRegistro'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                tipoingresos.FechaRegistro = oReader["FechaRegistro"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["FechaRegistro"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='UsuarioModificacion'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                tipoingresos.UsuarioModificacion = oReader["UsuarioModificacion"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["UsuarioModificacion"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='FechaModificacion'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                tipoingresos.FechaModificacion = oReader["FechaModificacion"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["FechaModificacion"]);

            //Extensiones
            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='desCtaProvSoles'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                tipoingresos.desCtaProvSoles = oReader["desCtaProvSoles"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["desCtaProvSoles"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='desCtaProvDolar'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                tipoingresos.desCtaProvDolar = oReader["desCtaProvDolar"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["desCtaProvDolar"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='NombreEmpresa'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                tipoingresos.NombreEmpresa = oReader["NombreEmpresa"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["NombreEmpresa"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='desCtaSoles'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                tipoingresos.desCtaSoles = oReader["desCtaSoles"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["desCtaSoles"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='desCtaDolar'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                tipoingresos.desCtaDolar = oReader["desCtaDolar"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["desCtaDolar"]);

            return  tipoingresos;        
        }

        public TipoIngresosE InsertarTipoIngresos(TipoIngresosE tipoingresos)
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_InsertarTipoIngresos", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = tipoingresos.idEmpresa;
					oComando.Parameters.Add("@TipoCobro", SqlDbType.VarChar, 5).Value = tipoingresos.TipoCobro;
					oComando.Parameters.Add("@Tipo", SqlDbType.VarChar, 1).Value = tipoingresos.Tipo;
					oComando.Parameters.Add("@TipoOperacion", SqlDbType.VarChar, 1).Value = tipoingresos.TipoOperacion;
					oComando.Parameters.Add("@Descripcion", SqlDbType.VarChar, 100).Value = tipoingresos.Descripcion;
					oComando.Parameters.Add("@SelCuenta", SqlDbType.VarChar, 1).Value = tipoingresos.SelCuenta;
                    oComando.Parameters.Add("@numVerPlanCuentas", SqlDbType.VarChar, 3).Value = tipoingresos.numVerPlanCuentas;
                    oComando.Parameters.Add("@filtroCuenta", SqlDbType.VarChar, 20).Value = tipoingresos.filtroCuenta;
                    oComando.Parameters.Add("@ctaSoles", SqlDbType.VarChar, 20).Value = tipoingresos.ctaSoles;
                    oComando.Parameters.Add("@ctaDolares", SqlDbType.VarChar, 20).Value = tipoingresos.ctaDolares;
                    oComando.Parameters.Add("@indCtaProvision", SqlDbType.VarChar, 1).Value = tipoingresos.indCtaProvision;
					oComando.Parameters.Add("@codCuentaSoles", SqlDbType.VarChar, 20).Value = tipoingresos.codCuentaSoles;
					oComando.Parameters.Add("@codCuentaDolares", SqlDbType.VarChar, 20).Value = tipoingresos.codCuentaDolares;
                    oComando.Parameters.Add("@indManipularMontos", SqlDbType.Bit).Value = tipoingresos.indManipularMontos;
                    oComando.Parameters.Add("@indManipularMoneda", SqlDbType.Bit).Value = tipoingresos.indManipularMoneda;
                    oComando.Parameters.Add("@UsuarioRegistro", SqlDbType.VarChar, 20).Value = tipoingresos.UsuarioRegistro;

                    oConexion.Open();
                    oComando.ExecuteNonQuery();
                }
            }

            return tipoingresos;
        }
        
        public TipoIngresosE ActualizarTipoIngresos(TipoIngresosE tipoingresos)
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ActualizarTipoIngresos", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = tipoingresos.idEmpresa;
					oComando.Parameters.Add("@TipoCobro", SqlDbType.VarChar, 5).Value = tipoingresos.TipoCobro;
					oComando.Parameters.Add("@Tipo", SqlDbType.VarChar, 1).Value = tipoingresos.Tipo;
					oComando.Parameters.Add("@TipoOperacion", SqlDbType.VarChar, 1).Value = tipoingresos.TipoOperacion;
					oComando.Parameters.Add("@Descripcion", SqlDbType.VarChar, 100).Value = tipoingresos.Descripcion;
					oComando.Parameters.Add("@SelCuenta", SqlDbType.VarChar, 1).Value = tipoingresos.SelCuenta;
                    oComando.Parameters.Add("@numVerPlanCuentas", SqlDbType.VarChar, 3).Value = tipoingresos.numVerPlanCuentas;
                    oComando.Parameters.Add("@filtroCuenta", SqlDbType.VarChar, 20).Value = tipoingresos.filtroCuenta;
                    oComando.Parameters.Add("@ctaSoles", SqlDbType.VarChar, 20).Value = tipoingresos.ctaSoles;
                    oComando.Parameters.Add("@ctaDolares", SqlDbType.VarChar, 20).Value = tipoingresos.ctaDolares;
                    oComando.Parameters.Add("@indCtaProvision", SqlDbType.VarChar, 1).Value = tipoingresos.indCtaProvision;
                    oComando.Parameters.Add("@codCuentaSoles", SqlDbType.VarChar, 20).Value = tipoingresos.codCuentaSoles;
                    oComando.Parameters.Add("@codCuentaDolares", SqlDbType.VarChar, 20).Value = tipoingresos.codCuentaDolares;
                    oComando.Parameters.Add("@indManipularMontos", SqlDbType.Bit).Value = tipoingresos.indManipularMontos;
                    oComando.Parameters.Add("@indManipularMoneda", SqlDbType.Bit).Value = tipoingresos.indManipularMoneda;
                    oComando.Parameters.Add("@UsuarioModificacion", SqlDbType.VarChar, 20).Value = tipoingresos.UsuarioModificacion;

                    oConexion.Open();
                    oComando.ExecuteNonQuery();
                }
            }

            return tipoingresos;
        }        

        public int EliminarTipoIngresos(Int32 idEmpresa, String TipoCobro)
        {
            int resp = 0;
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_EliminarTipoIngresos", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
					oComando.Parameters.Add("@TipoCobro", SqlDbType.VarChar, 5).Value = TipoCobro;

                    oConexion.Open();
                    resp = oComando.ExecuteNonQuery();
                }
            }

            return resp;
        }

        public List<TipoIngresosE> ListarTipoIngresos(Int32 idEmpresa)
        {
            List<TipoIngresosE> listaEntidad = new List<TipoIngresosE>();

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ListarTipoIngresos", oConexion))
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
        
        public TipoIngresosE ObtenerTipoIngresos(Int32 idEmpresa, String TipoCobro)
        {        
            TipoIngresosE tipoingresos = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ObtenerTipoIngresos", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
					oComando.Parameters.Add("@TipoCobro", SqlDbType.VarChar, 5).Value = TipoCobro;

                    oConexion.Open();
                    
                    using (SqlDataReader oReader = oComando.ExecuteReader())
                    {
                        while (oReader.Read())
                        {
                            tipoingresos = LlenarEntidad(oReader);
                        }
                    }
                }
            }

            return tipoingresos;
        }

        public Int32 CopiarTipoIngresos(Int32 idEmpresaDe, Int32 idEmpresaA, String UsuarioRegistro)
        {
            int resp = 0;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_CopiarTipoIngresos", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresaDe", SqlDbType.Int).Value = idEmpresaDe;
                    oComando.Parameters.Add("@idEmpresaA", SqlDbType.Int).Value = idEmpresaA;
                    oComando.Parameters.Add("@UsuarioRegistro", SqlDbType.VarChar, 20).Value = UsuarioRegistro;

                    oConexion.Open();
                    resp = oComando.ExecuteNonQuery();
                }
            }

            return resp;
        }

        public List<TipoIngresosE> ListarEmpresaTipIng(Int32 idEmpresa)
        {
            List<TipoIngresosE> listaEntidad = new List<TipoIngresosE>();

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ListarEmpresaTipIng", oConexion))
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

        public List<TipoIngresosE> TipoIngresosCombos(Int32 idEmpresa)
        {
            List<TipoIngresosE> listaEntidad = new List<TipoIngresosE>();

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_TipoIngresosCombos", oConexion))
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

    }
}