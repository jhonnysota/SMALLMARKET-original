using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;

using Entidades.Maestros;
using AccesoDatos.Util;

namespace AccesoDatos.Maestros
{
    public class ProveedorAD : DbConection
    {

        public ProveedorE LlenarEntidad(IDataReader oReader)
        {
            ProveedorE entidad = new ProveedorE();

            #region Entidad

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='IdPersona'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                entidad.IdPersona = oReader["IdPersona"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["IdPersona"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='IdEmpresa'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                entidad.IdEmpresa = oReader["IdEmpresa"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["IdEmpresa"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='TipoProveedor'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                entidad.TipoProveedor = oReader["TipoProveedor"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["TipoProveedor"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='SiglaComercial'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                entidad.SiglaComercial = oReader["SiglaComercial"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["SiglaComercial"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='fecInscripcion'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                entidad.fecInscripcion = oReader["fecInscripcion"] == DBNull.Value ? (Nullable<DateTime>)null : Convert.ToDateTime(oReader["fecInscripcion"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='fecInicioActividad'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                entidad.fecInicioActividad = oReader["fecInicioActividad"] == DBNull.Value ? (Nullable<DateTime>)null : Convert.ToDateTime(oReader["fecInicioActividad"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='tipConstitucion'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                entidad.tipConstitucion = oReader["tipConstitucion"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["tipConstitucion"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='tipRegimen'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                entidad.tipRegimen = oReader["tipRegimen"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["tipRegimen"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='catProveedor'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                entidad.catProveedor = oReader["catProveedor"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["catProveedor"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='indBaja'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                entidad.indBaja = oReader["indBaja"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["indBaja"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='fecBaja'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                entidad.fecBaja = oReader["fecBaja"] == DBNull.Value ? (Nullable<DateTime>)null : Convert.ToDateTime(oReader["fecBaja"]);

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

            #endregion

            #region Extensiones

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='NombreCompleto'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                entidad.NombreCompleto = oReader["NombreCompleto"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["NombreCompleto"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='NroDocumento'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                entidad.NroDocumento = oReader["NroDocumento"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["NroDocumento"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='TipoDocumento'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                entidad.TipoDocumento = oReader["TipoDocumento"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["TipoDocumento"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='NombreTipoProveedor'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                entidad.NombreTipoProveedor = oReader["NombreTipoProveedor"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["NombreTipoProveedor"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='RazonSocial'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                entidad.RazonSocial = oReader["RazonSocial"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["RazonSocial"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='RUC'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                entidad.RUC = oReader["RUC"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["RUC"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='DireccionCompleta'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                entidad.DireccionCompleta = oReader["DireccionCompleta"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["DireccionCompleta"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idCanalVenta'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                entidad.idCanalVenta = oReader["idCanalVenta"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idCanalVenta"]);

            #endregion

            return entidad;
        }

        public ProveedorE InsertarProveedor(ProveedorE proveedor)
        {
            SqlDateTime FechaNula = SqlDateTime.Null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_InsertarProveedor", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@IdPersona", SqlDbType.Int).Value = proveedor.IdPersona;
                    oComando.Parameters.Add("@IdEmpresa", SqlDbType.Int).Value = proveedor.IdEmpresa;
                    oComando.Parameters.Add("@TipoProveedor", SqlDbType.Int).Value = proveedor.TipoProveedor;
                    oComando.Parameters.Add("@SiglaComercial", SqlDbType.VarChar, 100).Value = proveedor.SiglaComercial;
                    
                    if (proveedor.fecInscripcion == null)
                    {
                        oComando.Parameters.Add("@fecInscripcion", SqlDbType.DateTime).Value = FechaNula;
                    }
                    else
                    {
                        oComando.Parameters.Add("@fecInscripcion", SqlDbType.DateTime).Value = proveedor.fecInscripcion;
                    }

                    if (proveedor.fecInicioActividad == null)
                    {
                        oComando.Parameters.Add("@fecInicioActividad", SqlDbType.DateTime).Value = FechaNula;
                    }
                    else
                    {
                        oComando.Parameters.Add("@fecInicioActividad", SqlDbType.DateTime).Value = proveedor.fecInicioActividad;
                    }
                    
                    oComando.Parameters.Add("@tipConstitucion", SqlDbType.Int).Value = proveedor.tipConstitucion;
                    oComando.Parameters.Add("@tipRegimen", SqlDbType.Int).Value = proveedor.tipRegimen;
                    oComando.Parameters.Add("@catProveedor", SqlDbType.Int).Value = proveedor.catProveedor;
                    oComando.Parameters.Add("@indBaja", SqlDbType.Char, 1).Value = proveedor.indBaja;

                    if (proveedor.fecBaja == null)
                    {
                        oComando.Parameters.Add("@fecBaja", SqlDbType.SmallDateTime).Value = FechaNula;
                    }
                    else
                    {
                        oComando.Parameters.Add("@fecBaja", SqlDbType.SmallDateTime).Value = proveedor.fecBaja;
                    }
                    
                    oComando.Parameters.Add("@UsuarioRegistro", SqlDbType.VarChar, 20).Value = proveedor.UsuarioRegistro;

                    oConexion.Open();
                    oComando.ExecuteNonQuery();
                }
            }

            return proveedor;
        }

        public ProveedorE ActualizarProveedor(ProveedorE proveedor)
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ActualizarProveedor", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@IdPersona", SqlDbType.Int).Value = proveedor.IdPersona;
                    oComando.Parameters.Add("@IdEmpresa", SqlDbType.Int).Value = proveedor.IdEmpresa;
                    oComando.Parameters.Add("@TipoProveedor", SqlDbType.Int).Value = proveedor.TipoProveedor;
                    oComando.Parameters.Add("@SiglaComercial", SqlDbType.VarChar, 100).Value = proveedor.SiglaComercial;
                    oComando.Parameters.Add("@fecInscripcion", SqlDbType.DateTime).Value = proveedor.fecInscripcion;
                    oComando.Parameters.Add("@fecInicioActividad", SqlDbType.DateTime).Value = proveedor.fecInicioActividad;
                    oComando.Parameters.Add("@tipConstitucion", SqlDbType.Int).Value = proveedor.tipConstitucion;
                    oComando.Parameters.Add("@tipRegimen", SqlDbType.Int).Value = proveedor.tipRegimen;
                    oComando.Parameters.Add("@catProveedor", SqlDbType.Int).Value = proveedor.catProveedor;
                    oComando.Parameters.Add("@indBaja", SqlDbType.Char, 1).Value = proveedor.indBaja;
                    oComando.Parameters.Add("@fecBaja", SqlDbType.SmallDateTime).Value = proveedor.fecBaja;
                    oComando.Parameters.Add("@UsuarioModificacion", SqlDbType.VarChar, 20).Value = proveedor.UsuarioModificacion;

                    oConexion.Open();
                    oComando.ExecuteNonQuery();
                }
            }

            return proveedor;
        }
                
        public ProveedorE RecuperarProveedorPorID(Int32 idPersona, Int32 idEmpresa)
        {
            ProveedorE entidad = new ProveedorE();

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_RecuperarProveedorPorID", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@IdPersona", SqlDbType.Int).Value = idPersona;
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

        public List<ProveedorE> ListarProveedorPorParametro(Int32 idEmpresa, String RazonSocial, String NroDocumento, Int32? TipoPersona, String indBaja)
        {
            List<ProveedorE> listaEntidad = new List<ProveedorE>();

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ListarProveedorPorParametro", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@RazonSocial", SqlDbType.NVarChar, 300).Value = RazonSocial;
                    oComando.Parameters.Add("@NroDocumento", SqlDbType.NVarChar, 25).Value = NroDocumento;
                    oComando.Parameters.Add("@TipoPersona", SqlDbType.Int).Value = TipoPersona;
                    oComando.Parameters.Add("@indBaja", SqlDbType.Char, 1).Value = indBaja;

                    oConexion.Open();

                    using (SqlDataReader oReader = oComando.ExecuteReader())
                    {
                        while (oReader.Read())
                        {
                            ProveedorE entidad = new ProveedorE();
                            entidad.IdEmpresa = Convert.ToInt32(oReader["IdEmpresa"]);
                            entidad.IdPersona = Convert.ToInt32(oReader["IdPersona"]);
                            entidad.RazonSocial = Convert.ToString(oReader["RazonSocial"]);
                            entidad.RUC = Convert.ToString(oReader["RUC"]);
                            entidad.indBaja = Convert.ToString(oReader["indBaja"]);
                            entidad.UsuarioRegistro = Convert.ToString(oReader["UsuarioRegistro"]);
                            entidad.FechaRegistro = Convert.ToDateTime(oReader["FechaRegistro"]);
                            entidad.UsuarioModificacion = Convert.ToString(oReader["UsuarioModificacion"]);
                            entidad.FechaModificacion = Convert.ToDateTime(oReader["FechaModificacion"]);

                            listaEntidad.Add(entidad);
                        }
                    }
                }
            }
            return listaEntidad;
        }

        /*****************************************************************************************************************************/

        public Int32 ActualizarEstadoProveedor(Int32 idPersona, bool estado, Int32 idEmpresa, String usuarioModificacion, DateTime fechaModificacion)
        {
            Int32 RESP = 0;
            fechaModificacion = DateTime.Now;
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ActualizarEstadoProveedor", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.AddWithValue("@IdPersona", idPersona);
                    oComando.Parameters.AddWithValue("@Estado", estado);
                    oComando.Parameters.AddWithValue("@IdEmpresa", idEmpresa);
                    oComando.Parameters.AddWithValue("@UsuarioModificacion", usuarioModificacion);                    
                    oComando.Parameters.AddWithValue("@FechaModificacion", fechaModificacion);

                    oConexion.Open();
                    RESP = oComando.ExecuteNonQuery();
                }
            }

            return RESP;
        }
                
        //public Int32 InsertarProveedorCompleto(Proveedor proveedor)
        //{
        //    using (TransactionScope tx = new TransactionScope())
        //    {
        //        Int32 idPersona;
        //        PersonaAD personaAD = new PersonaAD();

        //        //Obtengo el idPersona que acabo de insertar
        //        idPersona = personaAD.InsertarPersona(proveedor.DetallePersona);

        //        //Igualo a la entidad provedor el idPersona que se acaba de insertar.
        //        proveedor.IdPersona = idPersona;

        //        //Inserto al proveedor
        //        InsertarProveedor(proveedor);

        //        tx.Complete();

        //        //Retorno el idPersona Insertado.
        //        return idPersona;

        //    }

        //}

        //public Int32 ActualizarProveedorCompleto(Proveedor proveedor)
        //{
        //    using (TransactionScope tx = new TransactionScope())
        //    {
        //        PersonaAD personaAD = new PersonaAD();

        //        personaAD.ActualizarPersona(proveedor.DetallePersona);

        //        ActualizarProveedor(proveedor);

        //        tx.Complete();

        //        //Retorno el IdPersona Actualizado.
        //        return proveedor.IdPersona;

        //    }

        //}

        public List<ProveedorE> BuscarProveedor(Int32 idEmpresa, String RazonSocial, String NroDocumento, Int32 TipoProveedor)
        {
            List<ProveedorE> listaEntidad = new List<ProveedorE>();
            ProveedorE entidad = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_BuscarProveedor", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@RazonSocial", SqlDbType.NVarChar, 300).Value = RazonSocial;
                    oComando.Parameters.Add("@NroDocumento", SqlDbType.NVarChar, 25).Value = NroDocumento;
                    oComando.Parameters.Add("@TipoProveedor", SqlDbType.Int).Value = TipoProveedor;

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

        public int EliminarProveedor(Int32 idEmpresa, Int32 idPersona)
        {
            int resp = 0;
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_EliminarProveedor", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;

                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@idPersona", SqlDbType.Int).Value = idPersona;

                    oConexion.Open();
                    resp = oComando.ExecuteNonQuery();
                    oConexion.Close();
                }
            }

            return resp;
        }

    }
}
