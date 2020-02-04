using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

using Entidades.Maestros;
using AccesoDatos.Util;

namespace AccesoDatos.Maestros
{
    public class EmpresaAD : DbConection
    {

        public Empresa LlenarEntidad(IDataReader oReader)
        {
            Empresa entidad = new Empresa();

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='IdEmpresa'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                entidad.IdEmpresa = oReader["IdEmpresa"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["IdEmpresa"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='NombreComercial'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                entidad.NombreComercial = oReader["NombreComercial"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["NombreComercial"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='RUC'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                entidad.RUC = oReader["RUC"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["RUC"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='DireccionCompleta'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                entidad.DireccionCompleta = oReader["DireccionCompleta"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["DireccionCompleta"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idUbigeo'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                entidad.idUbigeo = oReader["idUbigeo"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["idUbigeo"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='RazonSocial'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                entidad.RazonSocial = oReader["RazonSocial"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["RazonSocial"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='RepresentanteLegal'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                entidad.RepresentanteLegal = oReader["RepresentanteLegal"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["RepresentanteLegal"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='sNumDocRepresentante'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                entidad.sNumDocRepresentante = oReader["sNumDocRepresentante"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["sNumDocRepresentante"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='sTelefonos'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                entidad.sTelefonos = oReader["sTelefonos"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["sTelefonos"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='sFax'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                entidad.sFax = oReader["sFax"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["sFax"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='sEmail'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                entidad.sEmail = oReader["sEmail"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["sEmail"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='sEmailFe'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                entidad.sEmailFe = oReader["sEmailFe"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["sEmailFe"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='sEmailOtros'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                entidad.sEmailOtros = oReader["sEmailOtros"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["sEmailOtros"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='ClaveOtros'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                entidad.ClaveOtros = oReader["ClaveOtros"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["ClaveOtros"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='PuertoOtros'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                entidad.PuertoOtros = oReader["PuertoOtros"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["PuertoOtros"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='ServidorSalienteOtros'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                entidad.ServidorSalienteOtros = oReader["ServidorSalienteOtros"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["ServidorSalienteOtros"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='HabilitaSslOtros'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                entidad.HabilitaSslOtros = oReader["HabilitaSslOtros"] == DBNull.Value ? false : Convert.ToBoolean(oReader["HabilitaSslOtros"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='sWeb'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                entidad.sWeb = oReader["sWeb"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["sWeb"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Fda'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                entidad.Fda = oReader["Fda"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["Fda"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idUbigeo'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                entidad.idUbigeo = oReader["idUbigeo"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["idUbigeo"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='PrincipalContribuyente'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                entidad.PrincipalContribuyente = oReader["PrincipalContribuyente"] == DBNull.Value ? false : Convert.ToBoolean(oReader["PrincipalContribuyente"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='AgenteRetenedor'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                entidad.AgenteRetenedor = oReader["AgenteRetenedor"] == DBNull.Value ? false : Convert.ToBoolean(oReader["AgenteRetenedor"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='UsuarioSol'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                entidad.UsuarioSol = oReader["UsuarioSol"] == DBNull.Value ? null : (byte[])(oReader["UsuarioSol"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='ClaveSol'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                entidad.ClaveSol = oReader["ClaveSol"] == DBNull.Value ? null : (byte[])(oReader["ClaveSol"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='indCalzado'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                entidad.indCalzado = oReader["indCalzado"] == DBNull.Value ? false : Convert.ToBoolean(oReader["indCalzado"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Estado'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                entidad.Estado = oReader["Estado"] == DBNull.Value ? true : Convert.ToBoolean(oReader["Estado"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='UsuarioRegistro'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                entidad.UsuarioRegistro = oReader["UsuarioRegistro"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["UsuarioRegistro"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='FechaRegistro'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                entidad.FechaRegistro = oReader["FechaRegistro"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["FechaRegistro"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='UsuarioModificacion'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                entidad.UsuarioModificacion = oReader["UsuarioModificacion"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["UsuarioModificacion"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='FechaModificacion'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                entidad.FechaModificacion = oReader["FechaModificacion"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["FechaModificacion"]);          
            
            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Departamento'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                entidad.Departamento = oReader["Departamento"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["Departamento"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Provincia'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                entidad.Provincia = oReader["Provincia"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["Provincia"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Distrito'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                entidad.Distrito = oReader["Distrito"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["Distrito"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Direccion'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                entidad.Direccion = oReader["Direccion"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["Direccion"]);

            return entidad;
        }

        public Empresa InsertarEmpresa(Empresa empresa)
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_InsertarEmpresa", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@NombreComercial", SqlDbType.NVarChar, 25).Value = empresa.NombreComercial;
                    oComando.Parameters.Add("@Ruc", SqlDbType.NVarChar, 25).Value = empresa.RUC;
                    oComando.Parameters.Add("@DireccionCompleta", SqlDbType.NVarChar, 100).Value = empresa.DireccionCompleta;
                    oComando.Parameters.Add("@idUbigeo", SqlDbType.VarChar, 6).Value = empresa.idUbigeo;
                    oComando.Parameters.Add("@RazonSocial", SqlDbType.NVarChar, 100).Value = empresa.RazonSocial;
                    oComando.Parameters.Add("@RepresentanteLegal", SqlDbType.NVarChar, 100).Value = empresa.RepresentanteLegal;
                    oComando.Parameters.Add("@sNumDocRepresentante", SqlDbType.VarChar, 15).Value = empresa.sNumDocRepresentante;
                    oComando.Parameters.Add("@sTelefonos", SqlDbType.VarChar, 50).Value = empresa.sTelefonos;
                    oComando.Parameters.Add("@sFax", SqlDbType.VarChar, 20).Value = empresa.sFax;
                    oComando.Parameters.Add("@sEmail", SqlDbType.VarChar, 50).Value = empresa.sEmail;
                    oComando.Parameters.Add("@sEmailFe", SqlDbType.VarChar, 50).Value = empresa.sEmailFe;
                    oComando.Parameters.Add("@sEmailOtros", SqlDbType.VarChar, 50).Value = empresa.sEmailOtros;
                    oComando.Parameters.Add("@ClaveOtros", SqlDbType.VarChar, 50).Value = empresa.ClaveOtros;
                    oComando.Parameters.Add("@PuertoOtros", SqlDbType.Int).Value = empresa.PuertoOtros;
                    oComando.Parameters.Add("@ServidorSalienteOtros", SqlDbType.VarChar, 50).Value = empresa.ServidorSalienteOtros;
                    oComando.Parameters.Add("@HabilitaSslOtros", SqlDbType.Bit).Value = empresa.HabilitaSslOtros;
                    oComando.Parameters.Add("@sWeb", SqlDbType.VarChar, 50).Value = empresa.sWeb;
                    oComando.Parameters.Add("@Fda", SqlDbType.VarChar, 20).Value = empresa.Fda;
                    oComando.Parameters.Add("@PrincipalContribuyente", SqlDbType.Bit).Value = empresa.PrincipalContribuyente;
                    oComando.Parameters.Add("@AgenteRetenedor", SqlDbType.Bit).Value = empresa.AgenteRetenedor;
                    oComando.Parameters.Add("@UsuarioSol", SqlDbType.VarBinary, 256).Value = empresa.UsuarioSol;
                    oComando.Parameters.Add("@ClaveSol", SqlDbType.VarBinary, 256).Value = empresa.ClaveSol;
                    oComando.Parameters.Add("@indCalzado", SqlDbType.Bit).Value = empresa.indCalzado;
                    oComando.Parameters.Add("@UsuarioRegistro", SqlDbType.VarChar, 20).Value = empresa.UsuarioRegistro;

                    oConexion.Open();
                    empresa.IdEmpresa = Int32.Parse(oComando.ExecuteScalar().ToString());

                    return empresa;
                }
            }   
        }

        public Empresa ActualizarEmpresa(Empresa empresa)
        {   
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ActualizarEmpresa", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@IdEmpresa", SqlDbType.Int).Value = empresa.IdEmpresa;
                    oComando.Parameters.Add("@NombreComercial", SqlDbType.NVarChar, 25).Value = empresa.NombreComercial;
                    oComando.Parameters.Add("@Ruc", SqlDbType.NVarChar, 25).Value = empresa.RUC;
                    oComando.Parameters.Add("@DireccionCompleta", SqlDbType.NVarChar, 100).Value = empresa.DireccionCompleta;
                    oComando.Parameters.Add("@idUbigeo", SqlDbType.VarChar, 6).Value = empresa.idUbigeo;
                    oComando.Parameters.Add("@RazonSocial", SqlDbType.NVarChar, 100).Value = empresa.RazonSocial;
                    oComando.Parameters.Add("@RepresentanteLegal", SqlDbType.NVarChar, 100).Value = empresa.RepresentanteLegal;
                    oComando.Parameters.Add("@sNumDocRepresentante", SqlDbType.VarChar, 15).Value = empresa.sNumDocRepresentante;
                    oComando.Parameters.Add("@sTelefonos", SqlDbType.VarChar, 50).Value = empresa.sTelefonos;
                    oComando.Parameters.Add("@sFax", SqlDbType.VarChar, 20).Value = empresa.sFax;
                    oComando.Parameters.Add("@sEmail", SqlDbType.VarChar, 50).Value = empresa.sEmail;
                    oComando.Parameters.Add("@sEmailFe", SqlDbType.VarChar, 50).Value = empresa.sEmailFe;
                    oComando.Parameters.Add("@sEmailOtros", SqlDbType.VarChar, 50).Value = empresa.sEmailOtros;
                    oComando.Parameters.Add("@ClaveOtros", SqlDbType.VarChar, 50).Value = empresa.ClaveOtros;
                    oComando.Parameters.Add("@PuertoOtros", SqlDbType.Int).Value = empresa.PuertoOtros;
                    oComando.Parameters.Add("@ServidorSalienteOtros", SqlDbType.VarChar, 50).Value = empresa.ServidorSalienteOtros;
                    oComando.Parameters.Add("@HabilitaSslOtros", SqlDbType.Bit).Value = empresa.HabilitaSslOtros;
                    oComando.Parameters.Add("@sWeb", SqlDbType.VarChar, 50).Value = empresa.sWeb;
                    oComando.Parameters.Add("@Fda", SqlDbType.VarChar, 20).Value = empresa.Fda;
                    oComando.Parameters.Add("@PrincipalContribuyente", SqlDbType.Bit).Value = empresa.PrincipalContribuyente;
                    oComando.Parameters.Add("@AgenteRetenedor", SqlDbType.Bit).Value = empresa.AgenteRetenedor;
                    oComando.Parameters.Add("@UsuarioSol", SqlDbType.VarBinary, 256).Value = empresa.UsuarioSol;
                    oComando.Parameters.Add("@ClaveSol", SqlDbType.VarBinary, 256).Value = empresa.ClaveSol;
                    oComando.Parameters.Add("@indCalzado", SqlDbType.Bit).Value = empresa.indCalzado;
                    oComando.Parameters.Add("@Estado", SqlDbType.Bit).Value = empresa.Estado;
                    oComando.Parameters.Add("@UsuarioModificacion", SqlDbType.VarChar, 20).Value = empresa.UsuarioModificacion;

                    oConexion.Open();
                    oComando.ExecuteNonQuery();
                }
            }

            return empresa;
        }

        public List<Empresa> ListarEmpresa(String parametro)
        {
            List<Empresa> listaEntidad = new List<Empresa>();    

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ListarEmpresaPorParametro", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@Parametro", SqlDbType.NVarChar, 100).Value = parametro;
                    
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

        public Empresa RecuperarEmpresaPorID(Int32 idEmpresa)
        {
            Empresa entidad = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_RecuperarEmpresaPorID", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@IdEmpresa", SqlDbType.Int).Value = idEmpresa;
                    
                    oConexion.Open();

                    using (SqlDataReader oReader = oComando.ExecuteReader())
                    {
                        while (oReader.Read())
                        {
                            entidad = LlenarEntidad(oReader);
                        }
                    }
                }
            }

            return entidad;
        }

        public List<Empresa> ListarEmpresaPorEstado(String parametro, Boolean Estado1, Boolean Estado2)
        {
            List<Empresa> listaEntidad = new List<Empresa>();
            Empresa entidad = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ListarEmpresaPorEstados", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.AddWithValue("@Parametro", parametro);
                    oComando.Parameters.AddWithValue("@Estado1", Estado1);
                    oComando.Parameters.AddWithValue("@Estado2", Estado2);

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

        public List<Empresa> ListarEmpresaPorUsuario(Int32 IdPersona)
        {
            List<Empresa> listaEntidad = new List<Empresa>();
            Empresa entidad = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ListarEmpresaPorUsuario", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@IdPersona", SqlDbType.Int).Value = IdPersona;
                    
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

        public Empresa RecuperarEmpresaPorRUC(String ruc)
        {
            Empresa entidad = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_RecuperarEmpresaPorRUC", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@RUC", SqlDbType.NVarChar, 20).Value = ruc;
                    
                    oConexion.Open();

                    using (SqlDataReader oReader = oComando.ExecuteReader())
                    {                        
                        while (oReader.Read())
                        {
                            entidad = LlenarEntidad(oReader);
                        } 
                    }
                }
            }

            return entidad;
        }

        public DateTime RecuperarFechaServidor()
        {
            DateTime FechaServidor;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ObtenerFechaServidor", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    
                    oConexion.Open();
                    FechaServidor = Convert.ToDateTime(oComando.ExecuteScalar());
                }
            }

            return FechaServidor;
        }

    }
}
