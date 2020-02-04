using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

using Entidades.Almacen;
using AccesoDatos.Util;

namespace AccesoDatos.Almacen
{
    public class AlmacenAD : DbConection
    {

        public AlmacenE LlenarEntidad(IDataReader oReader)
        {
            AlmacenE almacen = new AlmacenE();

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idEmpresa'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                almacen.idEmpresa = oReader["idEmpresa"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idEmpresa"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idAlmacen'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                almacen.idAlmacen = oReader["idAlmacen"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idAlmacen"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Clase'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                almacen.Clase = oReader["Clase"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["Clase"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='tipAlmacen'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                almacen.tipAlmacen = oReader["tipAlmacen"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["tipAlmacen"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='desAlmacen'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                almacen.desAlmacen = oReader["desAlmacen"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["desAlmacen"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='desCorta'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                almacen.desCorta = oReader["desCorta"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["desCorta"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Direccion'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                almacen.Direccion = oReader["Direccion"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["Direccion"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='VerificaStock'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                almacen.VerificaStock = oReader["VerificaStock"] == DBNull.Value ? false : Convert.ToBoolean(oReader["VerificaStock"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='VerificaLote'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                almacen.VerificaLote = oReader["VerificaLote"] == DBNull.Value ? false : Convert.ToBoolean(oReader["VerificaLote"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='TipoNumeracion'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                almacen.TipoNumeracion = oReader["TipoNumeracion"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["TipoNumeracion"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='desResponsable'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                almacen.desResponsable = oReader["desResponsable"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["desResponsable"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='EmailResponsable'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                almacen.EmailResponsable = oReader["EmailResponsable"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["EmailResponsable"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='tlfResponsable'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                almacen.tlfResponsable = oReader["tlfResponsable"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["tlfResponsable"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idCCostos'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                almacen.idCCostos = oReader["idCCostos"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["idCCostos"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='indEstado'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                almacen.indEstado = oReader["indEstado"] == DBNull.Value ? false : Convert.ToBoolean(oReader["indEstado"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='fecBaja'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                almacen.fecBaja = oReader["fecBaja"] == DBNull.Value ? (Nullable<DateTime>)null : Convert.ToDateTime(oReader["fecBaja"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='indUbiGenerica'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                almacen.indUbiGenerica = oReader["indUbiGenerica"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["indUbiGenerica"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idUbicacion'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                almacen.idUbicacion = oReader["idUbicacion"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["idUbicacion"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='CodEstablecimiento'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                almacen.CodEstablecimiento = oReader["CodEstablecimiento"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["CodEstablecimiento"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='UsuarioRegistro'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                almacen.UsuarioRegistro = oReader["UsuarioRegistro"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["UsuarioRegistro"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='FechaRegistro'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                almacen.FechaRegistro = oReader["FechaRegistro"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["FechaRegistro"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='UsuarioModificacion'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                almacen.UsuarioModificacion = oReader["UsuarioModificacion"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["UsuarioModificacion"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='FechaModificacion'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                almacen.FechaModificacion = oReader["FechaModificacion"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["FechaModificacion"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='SiglaLoteAlmacen'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                almacen.SiglaLoteAlmacen = oReader["SiglaLoteAlmacen"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["SiglaLoteAlmacen"]);

            //Extensiones
            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='desCostos'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                almacen.desCostos = oReader["desCostos"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["desCostos"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='desUbicacion'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                almacen.desUbicacion = oReader["desUbicacion"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["desUbicacion"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='EsCalzado'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                almacen.EsCalzado = oReader["EsCalzado"] == DBNull.Value ? false : Convert.ToBoolean(oReader["EsCalzado"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='TipoAlmacen'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                almacen.TipoAlmacen = oReader["TipoAlmacen"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["TipoAlmacen"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='desTipAlmacen'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                almacen.desTipAlmacen = oReader["desTipAlmacen"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["desTipAlmacen"]);

            return almacen;
        }

        public AlmacenE InsertarAlmacen(AlmacenE almacen)
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_InsertarAlmacen", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = almacen.idEmpresa;
                    oComando.Parameters.Add("@Clase", SqlDbType.Int).Value = almacen.Clase;
                    oComando.Parameters.Add("@tipAlmacen", SqlDbType.Int).Value = almacen.tipAlmacen;
                    oComando.Parameters.Add("@desAlmacen", SqlDbType.VarChar, 100).Value = almacen.desAlmacen;
                    oComando.Parameters.Add("@desCorta", SqlDbType.VarChar, 50).Value = almacen.desCorta;
                    oComando.Parameters.Add("@Direccion", SqlDbType.VarChar, 200).Value = almacen.Direccion;
                    oComando.Parameters.Add("@VerificaStock", SqlDbType.Bit).Value = almacen.VerificaStock;
                    oComando.Parameters.Add("@VerificaLote", SqlDbType.Bit).Value = almacen.VerificaLote;
                    oComando.Parameters.Add("@TipoNumeracion", SqlDbType.Char, 1).Value = almacen.TipoNumeracion;
                    oComando.Parameters.Add("@desResponsable", SqlDbType.VarChar, 100).Value = almacen.desResponsable;
                    oComando.Parameters.Add("@EmailResponsable", SqlDbType.VarChar, 50).Value = almacen.EmailResponsable;
                    oComando.Parameters.Add("@tlfResponsable", SqlDbType.VarChar, 50).Value = almacen.tlfResponsable;
                    oComando.Parameters.Add("@idCCostos", SqlDbType.VarChar, 10).Value = almacen.idCCostos;
                    oComando.Parameters.Add("@indUbiGenerica", SqlDbType.Char, 1).Value = almacen.indUbiGenerica;
                    oComando.Parameters.Add("@idUbicacion", SqlDbType.VarChar, 20).Value = almacen.idUbicacion;
                    oComando.Parameters.Add("@SiglaLoteAlmacen", SqlDbType.VarChar, 4).Value = almacen.SiglaLoteAlmacen;
                    oComando.Parameters.Add("@CodEstablecimiento", SqlDbType.VarChar, 4).Value = almacen.CodEstablecimiento;
                    oComando.Parameters.Add("@UsuarioRegistro", SqlDbType.VarChar, 20).Value = almacen.UsuarioRegistro;

                    oConexion.Open();
                    almacen.idAlmacen = Convert.ToInt32(oComando.ExecuteScalar());
                }
            }

            return almacen;
        }
        
        public AlmacenE ActualizarAlmacen(AlmacenE almacen)
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ActualizarAlmacen", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = almacen.idEmpresa;
                    oComando.Parameters.Add("@idAlmacen", SqlDbType.Int).Value = almacen.idAlmacen;
                    oComando.Parameters.Add("@Clase", SqlDbType.Int).Value = almacen.Clase;
                    oComando.Parameters.Add("@tipAlmacen", SqlDbType.Int).Value = almacen.tipAlmacen;
                    oComando.Parameters.Add("@desAlmacen", SqlDbType.VarChar, 100).Value = almacen.desAlmacen;
                    oComando.Parameters.Add("@desCorta", SqlDbType.VarChar, 50).Value = almacen.desCorta;
                    oComando.Parameters.Add("@Direccion", SqlDbType.VarChar, 200).Value = almacen.Direccion;
                    oComando.Parameters.Add("@VerificaStock", SqlDbType.Bit).Value = almacen.VerificaStock;
                    oComando.Parameters.Add("@VerificaLote", SqlDbType.Bit).Value = almacen.VerificaLote;
                    oComando.Parameters.Add("@TipoNumeracion", SqlDbType.Char, 1).Value = almacen.TipoNumeracion;
                    oComando.Parameters.Add("@desResponsable", SqlDbType.VarChar, 100).Value = almacen.desResponsable;
                    oComando.Parameters.Add("@EmailResponsable", SqlDbType.VarChar, 50).Value = almacen.EmailResponsable;
                    oComando.Parameters.Add("@tlfResponsable", SqlDbType.VarChar, 50).Value = almacen.tlfResponsable;
                    oComando.Parameters.Add("@idCCostos", SqlDbType.VarChar, 10).Value = almacen.idCCostos;
                    oComando.Parameters.Add("@indUbiGenerica", SqlDbType.Char, 1).Value = almacen.indUbiGenerica;
                    oComando.Parameters.Add("@idUbicacion", SqlDbType.VarChar, 20).Value = almacen.idUbicacion;
                    oComando.Parameters.Add("@SiglaLoteAlmacen", SqlDbType.VarChar, 4).Value = almacen.SiglaLoteAlmacen;
                    oComando.Parameters.Add("@CodEstablecimiento", SqlDbType.VarChar, 4).Value = almacen.CodEstablecimiento;
                    oComando.Parameters.Add("@UsuarioModificacion", SqlDbType.VarChar, 20).Value = almacen.UsuarioModificacion;

                    oConexion.Open();
                    oComando.ExecuteNonQuery();
                }
            }

            return almacen;
        }        

        public Int32 AnularAlmacen(Int32 idEmpresa, Int32 idAlmacen)
        {
            Int32 resp = 0;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_AnularAlmacen", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
					oComando.Parameters.Add("@idAlmacen", SqlDbType.Int).Value = idAlmacen;

                    oConexion.Open();
                    resp = oComando.ExecuteNonQuery();
                }
            }

            return resp;
        }

        public List<AlmacenE> ListarAlmacen(Int32 idEmpresa, String desAlmacen, Int32 tipAlmacen, Boolean Activo, Boolean Inactivo)
        {
            List<AlmacenE> listaEntidad = new List<AlmacenE>();

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ListarAlmacen", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@desAlmacen", SqlDbType.VarChar).Value = desAlmacen;
                    oComando.Parameters.Add("@tipAlmacen", SqlDbType.Int).Value = tipAlmacen;
                    oComando.Parameters.Add("@Activo", SqlDbType.Bit).Value = Activo;
                    oComando.Parameters.Add("@Inactivo", SqlDbType.Bit).Value = Inactivo;

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

        public List<AlmacenE> ListarAlmacenPorUsuario(Int32 idEmpresa, Int32 idPersona)
        {
            List<AlmacenE> listaEntidad = new List<AlmacenE>();

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ListarAlmacenPorUsuario", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@idPersona", SqlDbType.Int).Value = idPersona;

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

        public List<AlmacenE> ListarAlmacenPorEmpresa(Int32 idEmpresa)
        {
            List<AlmacenE> listaEntidad = new List<AlmacenE>();

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ListarAlmacenPorEmpresa", oConexion))
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

        public AlmacenE ObtenerAlmacen(Int32 idEmpresa, Int32 idAlmacen)
        {
            AlmacenE almacen = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ObtenerAlmacen", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
					oComando.Parameters.Add("@idAlmacen", SqlDbType.Int).Value = idAlmacen;

                    oConexion.Open();
                    
                    using (SqlDataReader oReader = oComando.ExecuteReader())
                    {
                        while (oReader.Read())
                        {
                            almacen = LlenarEntidad(oReader);
                        }
                    }
                }
            }

            return almacen;        
        }

        public List<AlmacenE> ListarAlmacenPorClase(Int32 idEmpresa, Int32 Clase)
        {
            List<AlmacenE> listaEntidad = new List<AlmacenE>();

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ListarAlmacenPorClase", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@Clase", SqlDbType.Int).Value = Clase;

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

        public List<AlmacenE> ListarAlmacenCombo(Int32 idEmpresa, Int32 tipAlmacen)
        {
            List<AlmacenE> oListaAlmacen = new List<AlmacenE>();

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ListarAlmacenCombo", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@tipAlmacen", SqlDbType.Int).Value = tipAlmacen;

                    oConexion.Open();

                    using (SqlDataReader oReader = oComando.ExecuteReader())
                    {
                        while (oReader.Read())
                        {
                            oListaAlmacen.Add(LlenarEntidad(oReader));
                        }
                    }
                }
            }

            return oListaAlmacen;
        }

        public Int32 VerificaMovAlmacen(Int32 idEmpresa, Int32 idAlmacen)
        {
            Int32 resp = 0;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_VerificaMovAlmacen", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@idAlmacen", SqlDbType.Int).Value = idAlmacen;

                    oConexion.Open();
                    resp = Convert.ToInt32(oComando.ExecuteScalar());
                }
            }

            return resp;
        }

        public List<AlmacenE> ListarAlmacenPorDireccion(Int32 idEmpresa)
        {
            List<AlmacenE> listaEntidad = new List<AlmacenE>();

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ListarAlmacenPorDireccion", oConexion))
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

        public AlmacenE ObtenerSiglaLoteAlmacen(Int32 idEmpresa, Int32 idAlmacen)
        {
            AlmacenE almacen = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ObtenerSiglaLoteAlmacen", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@idAlmacen", SqlDbType.Int).Value = idAlmacen;

                    oConexion.Open();

                    using (SqlDataReader oReader = oComando.ExecuteReader())
                    {
                        while (oReader.Read())
                        {
                            almacen = LlenarEntidad(oReader);
                        }
                    }
                }
            }

            return almacen;
        }

    }
}