using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

using Entidades.Ventas;
using AccesoDatos.Util;

namespace AccesoDatos.Ventas
{
    public class LetrasEstadoLibroFileAD : DbConection
    {

        public LetrasEstadoLibroFileE LlenarEntidad(IDataReader oReader)
        {
            LetrasEstadoLibroFileE letrasestadolibrofile = new LetrasEstadoLibroFileE();
            
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Estado'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				letrasestadolibrofile.Estado = oReader["Estado"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["Estado"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Descripcion'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				letrasestadolibrofile.Descripcion = oReader["Descripcion"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["Descripcion"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idComprobante'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				letrasestadolibrofile.idComprobante = oReader["idComprobante"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["idComprobante"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='numFile'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				letrasestadolibrofile.numFile = oReader["numFile"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["numFile"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='numVerPlanCuentas'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				letrasestadolibrofile.numVerPlanCuentas = oReader["numVerPlanCuentas"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["numVerPlanCuentas"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='CuentaSoles'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				letrasestadolibrofile.CuentaSoles = oReader["CuentaSoles"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["CuentaSoles"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='CuentaDolares'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				letrasestadolibrofile.CuentaDolares = oReader["CuentaDolares"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["CuentaDolares"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='indEndosar'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                letrasestadolibrofile.indEndosar = oReader["indEndosar"] == DBNull.Value ? false : Convert.ToBoolean(oReader["indEndosar"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='ctaSolesEndosada'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                letrasestadolibrofile.ctaSolesEndosada = oReader["ctaSolesEndosada"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["ctaSolesEndosada"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='ctaDolaresEndosada'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                letrasestadolibrofile.ctaDolaresEndosada = oReader["ctaDolaresEndosada"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["ctaDolaresEndosada"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='ctaSolesDscto'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                letrasestadolibrofile.ctaSolesDscto = oReader["ctaSolesDscto"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["ctaSolesDscto"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='ctaDolaresDscto'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                letrasestadolibrofile.ctaDolaresDscto = oReader["ctaDolaresDscto"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["ctaDolaresDscto"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='UsuarioRegistro'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				letrasestadolibrofile.UsuarioRegistro = oReader["UsuarioRegistro"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["UsuarioRegistro"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='FechaRegistro'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				letrasestadolibrofile.FechaRegistro = oReader["FechaRegistro"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["FechaRegistro"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='UsuarioModificacion'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				letrasestadolibrofile.UsuarioModificacion = oReader["UsuarioModificacion"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["UsuarioModificacion"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='FechaModificacion'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				letrasestadolibrofile.FechaModificacion = oReader["FechaModificacion"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["FechaModificacion"]);

            //Extensiones
            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='desCuentaSoles'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                letrasestadolibrofile.desCuentaSoles = oReader["desCuentaSoles"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["desCuentaSoles"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='desCuentaDolares'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                letrasestadolibrofile.desCuentaDolares = oReader["desCuentaDolares"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["desCuentaDolares"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='desComprobante'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                letrasestadolibrofile.desComprobante = oReader["desComprobante"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["desComprobante"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='desFile'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                letrasestadolibrofile.desFile = oReader["desFile"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["desFile"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='desCtaSolesEndosada'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                letrasestadolibrofile.desCtaSolesEndosada = oReader["desCtaSolesEndosada"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["desCtaSolesEndosada"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='desCtaDolaresEndosada'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                letrasestadolibrofile.desCtaDolaresEndosada = oReader["desCtaDolaresEndosada"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["desCtaDolaresEndosada"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='desCtaSolesDscto'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                letrasestadolibrofile.desCtaSolesDscto = oReader["desCtaSolesDscto"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["desCtaSolesDscto"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='desCtaDolaresDscto'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                letrasestadolibrofile.desCtaDolaresDscto = oReader["desCtaDolaresDscto"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["desCtaDolaresDscto"]);

            return  letrasestadolibrofile;        
        }

        public LetrasEstadoLibroFileE InsertarLetrasEstadoLibroFile(LetrasEstadoLibroFileE letrasestadolibrofile)
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_InsertarLetrasEstadoLibroFile", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@Estado", SqlDbType.Char, 1).Value = letrasestadolibrofile.Estado;
					oComando.Parameters.Add("@Descripcion", SqlDbType.VarChar, 100).Value = letrasestadolibrofile.Descripcion;
					oComando.Parameters.Add("@idComprobante", SqlDbType.VarChar, 2).Value = letrasestadolibrofile.idComprobante;
					oComando.Parameters.Add("@numFile", SqlDbType.VarChar, 2).Value = letrasestadolibrofile.numFile;
					oComando.Parameters.Add("@numVerPlanCuentas", SqlDbType.VarChar, 3).Value = letrasestadolibrofile.numVerPlanCuentas;
					oComando.Parameters.Add("@CuentaSoles", SqlDbType.VarChar, 20).Value = letrasestadolibrofile.CuentaSoles;
					oComando.Parameters.Add("@CuentaDolares", SqlDbType.VarChar, 20).Value = letrasestadolibrofile.CuentaDolares;
                    oComando.Parameters.Add("@indEndosar", SqlDbType.Bit).Value = letrasestadolibrofile.indEndosar;
                    oComando.Parameters.Add("@ctaSolesEndosada", SqlDbType.VarChar, 20).Value = letrasestadolibrofile.ctaSolesEndosada;
                    oComando.Parameters.Add("@ctaDolaresEndosada", SqlDbType.VarChar, 20).Value = letrasestadolibrofile.ctaDolaresEndosada;
                    oComando.Parameters.Add("@ctaSolesDscto", SqlDbType.VarChar, 20).Value = letrasestadolibrofile.ctaSolesDscto;
                    oComando.Parameters.Add("@ctaDolaresDscto", SqlDbType.VarChar, 20).Value = letrasestadolibrofile.ctaDolaresDscto;
                    oComando.Parameters.Add("@UsuarioRegistro", SqlDbType.VarChar, 20).Value = letrasestadolibrofile.UsuarioRegistro;

                    oConexion.Open();
                    oComando.ExecuteNonQuery();
                }
            }

            return letrasestadolibrofile;
        }
        
        public LetrasEstadoLibroFileE ActualizarLetrasEstadoLibroFile(LetrasEstadoLibroFileE letrasestadolibrofile)
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ActualizarLetrasEstadoLibroFile", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@Estado", SqlDbType.Char, 1).Value = letrasestadolibrofile.Estado;
					oComando.Parameters.Add("@Descripcion", SqlDbType.VarChar, 100).Value = letrasestadolibrofile.Descripcion;
					oComando.Parameters.Add("@idComprobante", SqlDbType.VarChar, 2).Value = letrasestadolibrofile.idComprobante;
					oComando.Parameters.Add("@numFile", SqlDbType.VarChar, 2).Value = letrasestadolibrofile.numFile;
					oComando.Parameters.Add("@numVerPlanCuentas", SqlDbType.VarChar, 3).Value = letrasestadolibrofile.numVerPlanCuentas;
					oComando.Parameters.Add("@CuentaSoles", SqlDbType.VarChar, 20).Value = letrasestadolibrofile.CuentaSoles;
					oComando.Parameters.Add("@CuentaDolares", SqlDbType.VarChar, 20).Value = letrasestadolibrofile.CuentaDolares;
                    oComando.Parameters.Add("@indEndosar", SqlDbType.Bit).Value = letrasestadolibrofile.indEndosar;
                    oComando.Parameters.Add("@ctaSolesEndosada", SqlDbType.VarChar, 20).Value = letrasestadolibrofile.ctaSolesEndosada;
                    oComando.Parameters.Add("@ctaDolaresEndosada", SqlDbType.VarChar, 20).Value = letrasestadolibrofile.ctaDolaresEndosada;
                    oComando.Parameters.Add("@ctaSolesDscto", SqlDbType.VarChar, 20).Value = letrasestadolibrofile.ctaSolesDscto;
                    oComando.Parameters.Add("@ctaDolaresDscto", SqlDbType.VarChar, 20).Value = letrasestadolibrofile.ctaDolaresDscto;
                    oComando.Parameters.Add("@UsuarioModificacion", SqlDbType.VarChar, 20).Value = letrasestadolibrofile.UsuarioModificacion;

                    oConexion.Open();
                    oComando.ExecuteNonQuery();
                }
            }

            return letrasestadolibrofile;
        }        

        public int EliminarLetrasEstadoLibroFile(String Estado)
        {
            Int32 resp = 0;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_EliminarLetrasEstadoLibroFile", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@Estado", SqlDbType.Char, 1).Value = Estado;

                    oConexion.Open();
                    resp = oComando.ExecuteNonQuery();
                }
            }

            return resp;
        }

        public List<LetrasEstadoLibroFileE> ListarLetrasEstadoLibroFile(Int32 idEmpresa)
        {
            List<LetrasEstadoLibroFileE> listaEntidad = new List<LetrasEstadoLibroFileE>();

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ListarLetrasEstadoLibroFile", oConexion))
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
        
        public LetrasEstadoLibroFileE ObtenerLetrasEstadoLibroFile(String Estado, Int32 idEmpresa)
        {        
            LetrasEstadoLibroFileE letrasestadolibrofile = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ObtenerLetrasEstadoLibroFile", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@Estado", SqlDbType.Char, 1).Value = Estado;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;

                    oConexion.Open();
                    
                    using (SqlDataReader oReader = oComando.ExecuteReader())
                    {
                        while (oReader.Read())
                        {
                            letrasestadolibrofile = LlenarEntidad(oReader);
                        }
                    }
                }
            }

            return letrasestadolibrofile;
        }

    }
}