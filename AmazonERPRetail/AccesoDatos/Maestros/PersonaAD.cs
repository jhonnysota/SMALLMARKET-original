using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

using Entidades.Maestros;
using AccesoDatos.Util;

namespace AccesoDatos.Maestros
{
    public class PersonaAD : DbConection
    {

        public Persona LlenarEntidad(IDataReader oReader)
        {
            Persona entidad = new Persona();

            #region Entidad

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='IdPersona'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                entidad.IdPersona = oReader["IdPersona"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["IdPersona"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='TipoPersona'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                entidad.TipoPersona = oReader["TipoPersona"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["TipoPersona"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='RazonSocial'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                entidad.RazonSocial = oReader["RazonSocial"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["RazonSocial"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='RUC'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                entidad.RUC = oReader["RUC"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["RUC"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='ApePaterno'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                entidad.ApePaterno = oReader["ApePaterno"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["ApePaterno"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='ApeMaterno'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                entidad.ApeMaterno = oReader["ApeMaterno"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["ApeMaterno"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Nombres'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                entidad.Nombres = oReader["Nombres"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["Nombres"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='TipoDocumento'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                entidad.TipoDocumento = oReader["TipoDocumento"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["TipoDocumento"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='NroDocumento'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                entidad.NroDocumento = oReader["NroDocumento"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["NroDocumento"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Telefonos'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                entidad.Telefonos = oReader["Telefonos"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["Telefonos"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='fax'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                entidad.Fax = oReader["fax"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["fax"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Correo'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                entidad.Correo = oReader["Correo"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["Correo"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='web'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                entidad.Web = oReader["web"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["web"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='DireccionCompleta'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                entidad.DireccionCompleta = oReader["DireccionCompleta"] == DBNull.Value ? String.Empty : oReader["DireccionCompleta"].ToString();

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idPais'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                entidad.idPais = oReader["idPais"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idPais"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idUbigeo'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                entidad.idUbigeo = oReader["idUbigeo"] == DBNull.Value ? String.Empty : oReader["idUbigeo"].ToString();

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='PrincipalContribuyente'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                entidad.PrincipalContribuyente = oReader["PrincipalContribuyente"] == DBNull.Value ? false : Convert.ToBoolean(oReader["PrincipalContribuyente"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='AgenteRetenedor'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                entidad.AgenteRetenedor = oReader["AgenteRetenedor"] == DBNull.Value ? false : Convert.ToBoolean(oReader["AgenteRetenedor"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idCanalVenta'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                entidad.idCanalVenta = oReader["idCanalVenta"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idCanalVenta"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Estado'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                entidad.Estado = oReader["Estado"] == DBNull.Value ? true : Convert.ToBoolean(oReader["Estado"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='FechaRegistro'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                entidad.FechaRegistro = oReader["FechaRegistro"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["FechaRegistro"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='UsuarioRegistro'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                entidad.UsuarioRegistro = oReader["UsuarioRegistro"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["UsuarioRegistro"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='FechaModificacion'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                entidad.FechaModificacion = oReader["FechaModificacion"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["FechaModificacion"]);            

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='UsuarioModificacion'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                entidad.UsuarioModificacion = oReader["UsuarioModificacion"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["UsuarioModificacion"]);

            //Otros Campos por revisar...            
            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='DireccionCompleta'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                entidad.DirecCompleta = oReader["DireccionCompleta"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["DireccionCompleta"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='TipoPersonaDes'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                entidad.TipoPersonaDes = oReader["TipoPersonaDes"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["TipoPersonaDes"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='TipoDocumentoDes'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                entidad.TipoDocumentoDes = oReader["TipoDocumentoDes"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["TipoDocumentoDes"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='CodigoTrabajador'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                entidad.CodigoTrabajador = oReader["CodigoTrabajador"] == DBNull.Value ? String.Empty : oReader["CodigoTrabajador"].ToString();

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='TipoRelacionPersona'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                entidad.TipoRelacionPersona = oReader["TipoRelacionPersona"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["TipoRelacionPersona"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='desPais'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                entidad.desPais = oReader["desPais"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["desPais"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='desDep'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                entidad.desDep = oReader["desDep"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["desDep"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='desDis'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                entidad.desDis = oReader["desDis"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["desDis"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='desPro'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                entidad.desPro = oReader["desPro"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["desPro"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Cli'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                entidad.Cli = oReader["Cli"] == DBNull.Value ? false : Convert.ToBoolean(oReader["Cli"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Pro'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                entidad.Pro = oReader["Pro"] == DBNull.Value ? false : Convert.ToBoolean(oReader["Pro"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Tra'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                entidad.Tra = oReader["Tra"] == DBNull.Value ? false : Convert.ToBoolean(oReader["Tra"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Ban'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                entidad.Ban = oReader["Ban"] == DBNull.Value ? false : Convert.ToBoolean(oReader["Ban"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idCanalVenta'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                entidad.idCanalVenta = oReader["idCanalVenta"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idCanalVenta"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='NemoTipPer'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                entidad.NemoTipPer = oReader["NemoTipPer"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["NemoTipPer"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idAsociado'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                entidad.idAsociado = oReader["idAsociado"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idAsociado"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='ManejaCartera'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                entidad.ManejaCartera = oReader["ManejaCartera"] == DBNull.Value ? false : Convert.ToBoolean(oReader["ManejaCartera"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idPersonaResponsable'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                entidad.idPersonaResponsable = oReader["idPersonaResponsable"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idPersonaResponsable"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='desResponsable'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                entidad.desResponsable = oReader["desResponsable"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["desResponsable"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='nroDocResponsable'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                entidad.nroDocResponsable = oReader["nroDocResponsable"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["nroDocResponsable"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idBancoPago'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                entidad.idBancoPago = oReader["idBancoPago"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idBancoPago"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idTipoCuentaPago'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                entidad.idTipoCuentaPago = oReader["idTipoCuentaPago"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idTipoCuentaPago"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idMonedaPago'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                entidad.idMonedaPago = oReader["idMonedaPago"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["idMonedaPago"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='NumCuentaPago'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                entidad.NumCuentaPago = oReader["NumCuentaPago"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["NumCuentaPago"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idDivision'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                entidad.idDivision = oReader["idDivision"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idDivision"]);
            //extencion

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idMoneda'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                entidad.idMoneda = oReader["idMoneda"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["idMoneda"]);


            #endregion

            return entidad;
        }

        public Persona InsertarPersona(Persona persona)
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_InsertarPersona", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@TipoPersona", SqlDbType.Int).Value = persona.TipoPersona;
                    oComando.Parameters.Add("@RazonSocial", SqlDbType.NVarChar, 200).Value = persona.RazonSocial;
                    oComando.Parameters.Add("@RUC", SqlDbType.NVarChar, 25).Value = persona.RUC;
                    oComando.Parameters.Add("@ApePaterno", SqlDbType.NVarChar, 100).Value = persona.ApePaterno;
                    oComando.Parameters.Add("@ApeMaterno", SqlDbType.NVarChar, 100).Value = persona.ApeMaterno;
                    oComando.Parameters.Add("@Nombres", SqlDbType.NVarChar, 100).Value = persona.Nombres;
                    oComando.Parameters.Add("@TipoDocumento", SqlDbType.Int).Value = persona.TipoDocumento;
                    oComando.Parameters.Add("@NroDocumento", SqlDbType.NVarChar, 25).Value = persona.NroDocumento;
                    oComando.Parameters.Add("@Telefonos", SqlDbType.NVarChar, 100).Value = persona.Telefonos;
                    oComando.Parameters.Add("@fax", SqlDbType.NVarChar, 20).Value = persona.Fax;
                    oComando.Parameters.Add("@Correo", SqlDbType.NVarChar, 100).Value = persona.Correo;
                    oComando.Parameters.Add("@web", SqlDbType.NVarChar, 50).Value = persona.Web;
                    oComando.Parameters.Add("@DireccionCompleta", SqlDbType.NVarChar, 300).Value = persona.DireccionCompleta;
                    oComando.Parameters.Add("@idPais", SqlDbType.Int).Value = persona.idPais;
                    oComando.Parameters.Add("@idUbigeo", SqlDbType.VarChar, 6).Value = persona.idUbigeo;
                    oComando.Parameters.Add("@PrincipalContribuyente", SqlDbType.Bit).Value = persona.PrincipalContribuyente;
                    oComando.Parameters.Add("@AgenteRetenedor", SqlDbType.Bit).Value = persona.AgenteRetenedor;
                    oComando.Parameters.Add("@idCanalVenta", SqlDbType.Int).Value = persona.idCanalVenta;
                    oComando.Parameters.Add("@UsuarioRegistro", SqlDbType.VarChar, 20).Value = persona.UsuarioRegistro;

                    oConexion.Open();
                    persona.IdPersona = Int32.Parse(oComando.ExecuteScalar().ToString());
                }
            }

            return persona;
        }

        public Persona ActualizarPersona(Persona persona)
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ActualizarPersona", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.AddWithValue("@IdPersona", persona.IdPersona);
                    oComando.Parameters.Add("@TipoPersona", SqlDbType.Int).Value = persona.TipoPersona;
                    oComando.Parameters.Add("@RazonSocial", SqlDbType.NVarChar, 300).Value = persona.RazonSocial;
                    oComando.Parameters.Add("@RUC", SqlDbType.NVarChar, 25).Value = persona.RUC;
                    oComando.Parameters.Add("@ApePaterno", SqlDbType.NVarChar, 100).Value = persona.ApePaterno;
                    oComando.Parameters.Add("@ApeMaterno", SqlDbType.NVarChar, 100).Value = persona.ApeMaterno;
                    oComando.Parameters.Add("@Nombres", SqlDbType.NVarChar, 100).Value = persona.Nombres;
                    oComando.Parameters.Add("@TipoDocumento", SqlDbType.Int).Value = persona.TipoDocumento;
                    oComando.Parameters.Add("@NroDocumento", SqlDbType.NVarChar, 25).Value = persona.NroDocumento;
                    oComando.Parameters.Add("@Telefonos", SqlDbType.VarChar, 100).Value = persona.Telefonos;
                    oComando.Parameters.Add("@fax", SqlDbType.NVarChar, 20).Value = persona.Fax;
                    oComando.Parameters.Add("@Correo", SqlDbType.NVarChar, 100).Value = persona.Correo;
                    oComando.Parameters.Add("@web", SqlDbType.NVarChar, 50).Value = persona.Web;
                    oComando.Parameters.Add("@DireccionCompleta", SqlDbType.NVarChar, 300).Value = persona.DireccionCompleta;
                    oComando.Parameters.Add("@idPais", SqlDbType.Int).Value = persona.idPais;
                    oComando.Parameters.Add("@idUbigeo", SqlDbType.VarChar, 6).Value = persona.idUbigeo;
                    oComando.Parameters.Add("@PrincipalContribuyente", SqlDbType.Bit).Value = persona.PrincipalContribuyente;
                    oComando.Parameters.Add("@AgenteRetenedor", SqlDbType.Bit).Value = persona.AgenteRetenedor;
                    oComando.Parameters.Add("@idCanalVenta", SqlDbType.Int).Value = persona.idCanalVenta;
                    oComando.Parameters.Add("@UsuarioModificacion", SqlDbType.VarChar, 20).Value = persona.UsuarioModificacion;
                    

                    oConexion.Open();
                    oComando.ExecuteNonQuery();
                }
            }

            return persona;
        }

        public Persona RecuperarPersonaPorID(Int32 idPersona)
        {
            Persona entidad = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_RecuperarPersonaPorID", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@IdPersona", SqlDbType.Int).Value = idPersona;
                    oConexion.Open();

                    using (SqlDataReader oReader = oComando.ExecuteReader())
                    {
                        if (oReader.Read())
                        {
                            entidad = LlenarEntidad(oReader);
                        }
                    }
                }
            }

            return entidad;
        }

        public Persona RecuperarPersonaPorRUC(Int32 tipoDocumento, String ruc)
        {
            Persona entidad = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_RecuperarPersonaPorRUC", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@TipoDocumento", SqlDbType.Int).Value = tipoDocumento;
                    oComando.Parameters.Add("@RUC", SqlDbType.NVarChar, 25).Value = ruc;
                    
                    oConexion.Open();

                    using (SqlDataReader oReader = oComando.ExecuteReader())
                    {
                        if (oReader.Read())
                        {
                            entidad = LlenarEntidad(oReader);
                        }
                    }
                }
            }

            return entidad;
        }

        public Persona RecuperarPersonaPorDNI(String DNI)
        {
            Persona entidad = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_RecuperarPersonaPorDNI", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@DNI", SqlDbType.NVarChar, 20).Value = DNI;

                    oConexion.Open();

                    using (SqlDataReader oReader = oComando.ExecuteReader())
                    {
                        if (oReader.Read())
                        {
                            entidad = LlenarEntidad(oReader);
                        }
                    }
                }
            }

            return entidad;
        }

        public Persona RecuperarPersonaPorNroDocumento(String nroDocumento)
        {
            Persona entidad = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_RecuperarPersonaPorNroDocumento", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@NroDocumento", SqlDbType.NVarChar, 25).Value = nroDocumento;
                    
                    oConexion.Open();

                    using (SqlDataReader oReader = oComando.ExecuteReader())
                    {
                        if (oReader.Read())
                        {
                            entidad = LlenarEntidad(oReader);
                        }
                    }
                }
            }

            return entidad;
        }

        public List<Persona> BusquedaPersonaPorTipo(String Tipo, Int32 idEmpresa, String RazonSocial, String nroDocumento, Boolean EsReferente = false)
        {
            List<Persona> listaEntidad = new List<Persona>();
            Persona entidad = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_BusquedaPersonaPorTipo", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@Tipo", SqlDbType.VarChar, 2).Value = Tipo;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@RazonSocial", SqlDbType.NVarChar, 100).Value = RazonSocial;
                    oComando.Parameters.Add("@nroDocumento", SqlDbType.NVarChar, 25).Value = nroDocumento;
                    oComando.Parameters.Add("@EsReferente", SqlDbType.Bit).Value = EsReferente;
                    
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

        public Persona ObtenerPersonaPorNroRuc(String Ruc, Int32 idEmpresa = 0)
        {
            Persona entidad = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ObtenerPersonaPorNroRuc", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@Ruc", SqlDbType.NVarChar, 25).Value = Ruc;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;

                    oConexion.Open();

                    using (SqlDataReader oReader = oComando.ExecuteReader())
                    {
                        if (oReader.Read())
                        {
                            entidad = LlenarEntidad(oReader);
                        } 
                    }
                }
            }

            return entidad;
        }

        public List<Persona> ListarPersonaPorFiltro(Int32 idEmpresa, String Tipo, String Filtro)
        {
            List<Persona> listaEntidad = new List<Persona>();
            Persona entidad = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ListarPersonasPorFiltro", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@Tipo", SqlDbType.Char, 2).Value = Tipo;
                    oComando.Parameters.Add("@Filtro", SqlDbType.NVarChar, 50).Value = Filtro;

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

        public Persona ValidaNroDocumentoExistente(Int32 tipoDocumento, String nroDocumento, Int32 IdPersona)
        {
            Persona persona = null;
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ValidaNroDocumentoExistente",oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.AddWithValue("@TipoDocumento", tipoDocumento);
                    oComando.Parameters.AddWithValue("@nroDocumento", nroDocumento);
                    oComando.Parameters.AddWithValue("@IdPersona", IdPersona);
                    oConexion.Open();

                    using (SqlDataReader oReader = oComando.ExecuteReader())
                    {
                        while (oReader.Read())
                        {
                            persona = LlenarEntidad(oReader);
                        } 
                    }
                    oConexion.Close();
                }
            }
            return persona;
        }

        public Persona ValidaRUCExistente(String RUC)
        {
            Persona persona = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ValidaRUCExistente", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@Ruc", SqlDbType.NVarChar, 25).Value = RUC;
                 
                    oConexion.Open();

                    using (SqlDataReader oReader = oComando.ExecuteReader())
                    {
                        while (oReader.Read())
                        {
                            persona = LlenarEntidad(oReader);
                        }    
                    }
                }
            }

            return persona;
        }

        public List<Persona> ListarCorreosTrabajador()
        {
            List<Persona> listaEntidad = new List<Persona>();
            Persona entidad = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ListarCorreosTrabajador", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
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

        public List<Persona> ListarCarteraClientesPorFiltro(Int32 idEmpresa, String Tipo, String Filtro, Int32 idVendedor)
        {
            List<Persona> listaEntidad = new List<Persona>();
            Persona entidad = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ListarCarteraClientesPorFiltro", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@Tipo", SqlDbType.Char, 2).Value = Tipo;
                    oComando.Parameters.Add("@Filtro", SqlDbType.NVarChar, 50).Value = Filtro;
                    oComando.Parameters.Add("@idVendedor", SqlDbType.Int).Value = idVendedor;

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

        public List<Persona> ListarPersonasPorTipPer(Int32 idEmpresa, String Tipo, String Filtro, String TipoPersona)
        {
            List<Persona> listaEntidad = new List<Persona>();
            Persona entidad = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ListarPersonasPorTipPer", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@Tipo", SqlDbType.Char, 2).Value = Tipo;
                    oComando.Parameters.Add("@Filtro", SqlDbType.NVarChar, 50).Value = Filtro;
                    oComando.Parameters.Add("@TipoPersona", SqlDbType.VarChar, 3).Value = TipoPersona;

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

    }
}
