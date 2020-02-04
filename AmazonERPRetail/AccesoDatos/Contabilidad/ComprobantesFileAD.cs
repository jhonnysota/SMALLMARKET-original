using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

using Entidades.Contabilidad;
using AccesoDatos.Util;

namespace AccesoDatos.Contabilidad
{
    public class ComprobantesFileAD : DbConection
    {
        
        public ComprobantesFileE LlenarEntidad(IDataReader oReader)
        {
            ComprobantesFileE comprobantesfile = new ComprobantesFileE();
            String desFile = String.Empty;

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idEmpresa'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                comprobantesfile.idEmpresa = oReader["idEmpresa"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idEmpresa"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idComprobante'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                comprobantesfile.idComprobante = oReader["idComprobante"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["idComprobante"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='numFile'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                comprobantesfile.numFile = oReader["numFile"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["numFile"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Descripcion'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                comprobantesfile.Descripcion = desFile = oReader["Descripcion"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["Descripcion"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='DesLarga'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                comprobantesfile.DesLarga = oReader["DesLarga"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["DesLarga"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='flagAutomatico'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                comprobantesfile.flagAutomatico = oReader["flagAutomatico"] == DBNull.Value ? true : Convert.ToBoolean(oReader["flagAutomatico"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='flagIndFlujo'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                comprobantesfile.flagIndFlujo = oReader["flagIndFlujo"] == DBNull.Value ? true : Convert.ToBoolean(oReader["flagIndFlujo"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='IndForma'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                comprobantesfile.IndForma = oReader["IndForma"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["IndForma"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='flagIndPartidaPres'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                comprobantesfile.flagIndPartidaPres = oReader["flagIndPartidaPres"] == DBNull.Value ? true : Convert.ToBoolean(oReader["flagIndPartidaPres"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idMoneda'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                comprobantesfile.idMoneda = oReader["idMoneda"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["idMoneda"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='LLevaCuenta'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                comprobantesfile.LLevaCuenta = oReader["LLevaCuenta"] == DBNull.Value ? false : Convert.ToBoolean(oReader["LLevaCuenta"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='numVerPlanCuentas'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                comprobantesfile.numVerPlanCuentas = oReader["numVerPlanCuentas"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["numVerPlanCuentas"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='codCuenta'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                comprobantesfile.codCuenta = oReader["codCuenta"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["codCuenta"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='codCuentaSoles'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                comprobantesfile.codCuentaSoles = oReader["codCuentaSoles"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["codCuentaSoles"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='codCuentaDolar'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                comprobantesfile.codCuentaDolar = oReader["codCuentaDolar"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["codCuentaDolar"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='indPorExtornar'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                comprobantesfile.indPorExtornar = oReader["indPorExtornar"] == DBNull.Value ? false : Convert.ToBoolean(oReader["indPorExtornar"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='UsuarioRegistro'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                comprobantesfile.UsuarioRegistro = oReader["UsuarioRegistro"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["UsuarioRegistro"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='FechaRegistro'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                comprobantesfile.FechaRegistro = oReader["FechaRegistro"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["FechaRegistro"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='UsuarioModificacion'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                comprobantesfile.UsuarioModificacion = oReader["UsuarioModificacion"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["UsuarioModificacion"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='FechaModificacion'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                comprobantesfile.FechaModificacion = oReader["FechaModificacion"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["FechaModificacion"]);

            //Extensiones
            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='numFile'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                comprobantesfile.desFileComp = oReader["numFile"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["numFile"]) + " - " + desFile;

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='desCuenta'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                comprobantesfile.desCuenta = oReader["desCuenta"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["desCuenta"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='desCuentaSoles'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                comprobantesfile.desCuentaSoles = oReader["desCuentaSoles"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["desCuentaSoles"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='desCuentaDolar'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                comprobantesfile.desCuentaDolar = oReader["desCuentaDolar"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["desCuentaDolar"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='desFileComp'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                comprobantesfile.desFileComp = oReader["desFileComp"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["desFileComp"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idBanco'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                comprobantesfile.idBanco = oReader["idBanco"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idBanco"]);

            return comprobantesfile;
        }

        public ComprobantesFileE InsertarComprobantesFile(ComprobantesFileE comprobantesfile)
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_InsertarComprobantesFile", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = comprobantesfile.idEmpresa;
                    oComando.Parameters.Add("@idComprobante", SqlDbType.Char, 2).Value = comprobantesfile.idComprobante;
                    oComando.Parameters.Add("@numFile", SqlDbType.Char, 2).Value = comprobantesfile.numFile;
                    oComando.Parameters.Add("@Descripcion", SqlDbType.VarChar, 50).Value = comprobantesfile.Descripcion;
                    oComando.Parameters.Add("@DesLarga", SqlDbType.VarChar, 200).Value = comprobantesfile.DesLarga;
                    oComando.Parameters.Add("@flagAutomatico", SqlDbType.Bit).Value = comprobantesfile.flagAutomatico;
                    oComando.Parameters.Add("@flagIndFlujo", SqlDbType.Bit).Value = comprobantesfile.flagIndFlujo;
                    oComando.Parameters.Add("@IndForma", SqlDbType.Char, 1).Value = comprobantesfile.IndForma;
                    oComando.Parameters.Add("@flagIndPartidaPres", SqlDbType.Bit).Value = comprobantesfile.flagIndPartidaPres;
                    oComando.Parameters.Add("@idMoneda", SqlDbType.Char, 2).Value = comprobantesfile.idMoneda;
                    oComando.Parameters.Add("@LlevaCuenta", SqlDbType.Bit).Value = comprobantesfile.LLevaCuenta;
                    oComando.Parameters.Add("@numVerPlanCuentas", SqlDbType.VarChar, 3).Value = comprobantesfile.numVerPlanCuentas;
                    oComando.Parameters.Add("@codCuenta", SqlDbType.VarChar, 20).Value = comprobantesfile.codCuenta;
                    oComando.Parameters.Add("@codCuentaSoles", SqlDbType.VarChar, 20).Value = comprobantesfile.codCuentaSoles;
                    oComando.Parameters.Add("@codCuentaDolar", SqlDbType.VarChar, 20).Value = comprobantesfile.codCuentaDolar;
                    oComando.Parameters.Add("@indPorExtornar", SqlDbType.Bit).Value = comprobantesfile.indPorExtornar;
                    oComando.Parameters.Add("@UsuarioRegistro", SqlDbType.VarChar, 20).Value = comprobantesfile.UsuarioRegistro;

                    oConexion.Open();
                    oComando.ExecuteNonQuery();
                }
            }

            return comprobantesfile;        
        }
        
        public ComprobantesFileE ActualizarComprobantesFile(ComprobantesFileE comprobantesfile)
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ActualizarComprobantesFile", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = comprobantesfile.idEmpresa;
                    oComando.Parameters.Add("@idComprobante", SqlDbType.Char, 2).Value = comprobantesfile.idComprobante;
                    oComando.Parameters.Add("@numFile", SqlDbType.Char, 2).Value = comprobantesfile.numFile;
                    oComando.Parameters.Add("@Descripcion", SqlDbType.VarChar, 50).Value = comprobantesfile.Descripcion;
                    oComando.Parameters.Add("@DesLarga", SqlDbType.VarChar, 200).Value = comprobantesfile.DesLarga;
                    oComando.Parameters.Add("@flagAutomatico", SqlDbType.Bit).Value = comprobantesfile.flagAutomatico;
                    oComando.Parameters.Add("@flagIndFlujo", SqlDbType.Bit).Value = comprobantesfile.flagIndFlujo;
                    oComando.Parameters.Add("@IndForma", SqlDbType.Char, 1).Value = comprobantesfile.IndForma;
                    oComando.Parameters.Add("@flagIndPartidaPres", SqlDbType.Bit).Value = comprobantesfile.flagIndPartidaPres;
                    oComando.Parameters.Add("@idMoneda", SqlDbType.Char, 2).Value = comprobantesfile.idMoneda;
                    oComando.Parameters.Add("@LlevaCuenta", SqlDbType.Bit).Value = comprobantesfile.LLevaCuenta;
                    oComando.Parameters.Add("@numVerPlanCuentas", SqlDbType.VarChar, 3).Value = comprobantesfile.numVerPlanCuentas;
                    oComando.Parameters.Add("@codCuenta", SqlDbType.VarChar, 20).Value = comprobantesfile.codCuenta;
                    oComando.Parameters.Add("@codCuentaSoles", SqlDbType.VarChar, 20).Value = comprobantesfile.codCuentaSoles;
                    oComando.Parameters.Add("@codCuentaDolar", SqlDbType.VarChar, 20).Value = comprobantesfile.codCuentaDolar;
                    oComando.Parameters.Add("@indPorExtornar", SqlDbType.Bit).Value = comprobantesfile.indPorExtornar;
                    oComando.Parameters.Add("@UsuarioModificacion", SqlDbType.VarChar, 20).Value = comprobantesfile.UsuarioModificacion;

                    oConexion.Open();
                    oComando.ExecuteNonQuery();
                }
            }

            return comprobantesfile;
        }

        public List<ComprobantesFileE> ListarComprobantesFile(Int32 idEmpresa)
        {
            List<ComprobantesFileE> listaEntidad = new List<ComprobantesFileE>();
            ComprobantesFileE entidad = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ListarComprobantesFile", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oConexion.Open();

                    using (SqlDataReader oReader = oComando.ExecuteReader())
                    {
                        while (oReader.Read())
                        {
                            entidad = LlenarEntidad(oReader);
                            listaEntidad.Add(entidad);
                        }
                    }
                }
            }

            return listaEntidad;
        }

        public List<ComprobantesFileE> ObtenerFilesPorIdComprobante(Int32 idEmpresa, String idComprobante)
        {
            List<ComprobantesFileE> ListaFiles = new List<ComprobantesFileE>();
            ComprobantesFileE comprobantesfile = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ObtenerFilesPorIdComprobante", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@idComprobante", SqlDbType.Char, 2).Value = idComprobante;
                    
                    oConexion.Open();

                    using (SqlDataReader oReader = oComando.ExecuteReader())
                    {
                        while (oReader.Read())
                        {
                            comprobantesfile = LlenarEntidad(oReader);
                            ListaFiles.Add(comprobantesfile);
                        }
                    }
                }
            }

            return ListaFiles;
        }

        public Int32 EliminarComprobantesFile(Int32 idEmpresa, String idComprobante, String numFile)
        {
            Int32 resp = 0;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_EliminarComprobantesFile", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@idComprobante", SqlDbType.Char, 2).Value = idComprobante;
                    oComando.Parameters.Add("@numFile", SqlDbType.Char, 2).Value = numFile;

                    oConexion.Open();
                    resp = oComando.ExecuteNonQuery();
                }
            }

            return resp;
        }

        public ComprobantesFileE ObtenerComprobantesFile(Int32 idEmpresa, String idComprobante, String numFile)
        {
            ComprobantesFileE comprobantesfile = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ObtenerComprobantesFile", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@idComprobante", SqlDbType.Char, 2).Value = idComprobante;
                    oComando.Parameters.Add("@numFile", SqlDbType.Char, 2).Value = numFile;

                    oConexion.Open();

                    using (SqlDataReader oReader = oComando.ExecuteReader())
                    {
                        while (oReader.Read())
                        {
                            comprobantesfile = LlenarEntidad(oReader);
                        }
                    }
                }
            }

            return comprobantesfile;
        }

        public ComprobantesFileE ObtenerFilePorCuenta(Int32 idEmpresa, String idComprobante, String idMoneda, String numVerPlanCuentas, String codCuenta)
        {
            ComprobantesFileE comprobantesfile = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ObtenerFilePorCuenta", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@idComprobante", SqlDbType.VarChar, 2).Value = idComprobante;
                    oComando.Parameters.Add("@idMoneda", SqlDbType.VarChar, 2).Value = idMoneda;
                    oComando.Parameters.Add("@numVerPlanCuentas", SqlDbType.VarChar, 3).Value = numVerPlanCuentas;
                    oComando.Parameters.Add("@codCuenta", SqlDbType.VarChar, 20).Value = codCuenta;

                    oConexion.Open();

                    using (SqlDataReader oReader = oComando.ExecuteReader())
                    {
                        while (oReader.Read())
                        {
                            comprobantesfile = LlenarEntidad(oReader);
                        }
                    }
                }
            }

            return comprobantesfile;
        }

    }
}