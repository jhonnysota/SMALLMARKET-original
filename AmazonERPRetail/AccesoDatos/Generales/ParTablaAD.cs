using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

using Entidades.Generales;
using AccesoDatos.Util;
using Infraestructura.Enumerados;

namespace AccesoDatos.Generales
{
    public class ParTablaAD : DbConection
    {
        
        public ParTabla LlenarEntidad(IDataReader oReader)
        {
            ParTabla entidad = new ParTabla();
            
            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='IdParTabla'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                entidad.IdParTabla = oReader["IdParTabla"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["IdParTabla"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Nombre'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                entidad.Nombre = oReader["Nombre"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["Nombre"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Descripcion'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                entidad.Descripcion = oReader["Descripcion"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["Descripcion"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='NemoTecnico'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                entidad.NemoTecnico = oReader["NemoTecnico"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["NemoTecnico"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Grupo'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                entidad.Grupo = oReader["Grupo"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["Grupo"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='EsEditable'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                entidad.EsEditable = oReader["EsEditable"] == DBNull.Value ? false : Convert.ToBoolean(oReader["EsEditable"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='EquivalenciaSunat'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                entidad.EquivalenciaSunat = oReader["EquivalenciaSunat"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["EquivalenciaSunat"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Estado'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                entidad.Estado = oReader["Estado"] == DBNull.Value ? false : Convert.ToBoolean(oReader["Estado"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='ValorCadena'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                entidad.ValorCadena = oReader["ValorCadena"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["ValorCadena"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='ValorEntero'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                entidad.ValorEntero = oReader["ValorEntero"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["ValorEntero"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='FlagCorrelativo'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                entidad.FlagCorrelativo = oReader["FlagCorrelativo"] == DBNull.Value ? false : Convert.ToBoolean(oReader["FlagCorrelativo"]);

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

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Nombre'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                entidad.desTemporal = oReader["Nombre"] == DBNull.Value ? String.Empty : entidad.EquivalenciaSunat + " - " + Convert.ToString(oReader["Nombre"]);

            return entidad;
        }

        public Int32 InsertarParTabla(ParTabla partabla)
        {
            Int32 Resp = 0;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_InsertarParTabla", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add(new SqlParameter("@IdParTabla", partabla.IdParTabla));
                    oComando.Parameters.Add(new SqlParameter("@Nombre", partabla.Nombre));
                    oComando.Parameters.Add(new SqlParameter("@Descripcion", partabla.Descripcion));
                    oComando.Parameters.Add(new SqlParameter("@NemoTecnico", partabla.NemoTecnico));
                    oComando.Parameters.Add(new SqlParameter("@Grupo", partabla.Grupo));
                    oComando.Parameters.Add(new SqlParameter("@EsEditable", partabla.EsEditable));
                    oComando.Parameters.Add(new SqlParameter("@EquivalenciaSunat", partabla.EquivalenciaSunat));
                    oComando.Parameters.Add(new SqlParameter("@UsuarioRegistro", partabla.UsuarioRegistro));
                    oComando.Parameters.Add(new SqlParameter("@ValorCadena", partabla.ValorCadena));
                    oComando.Parameters.Add(new SqlParameter("@ValorEntero", partabla.ValorEntero));
                    oComando.Parameters.Add(new SqlParameter("@FlagCorrelativo", partabla.FlagCorrelativo));

                    oConexion.Open();
                    Resp = oComando.ExecuteNonQuery();
                }
            }

            return Resp;
        }

        public List<ParTabla> ListarParTablaCabecera(String parametro)
        {
            List<ParTabla> listaEntidad = new List<ParTabla>();

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ListarParTablaCabecera", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;

                    oComando.Parameters.AddWithValue("@Parametro", parametro);
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

        public List<ParTabla> ListarParTabla(String parametro, Boolean activo, Boolean inactivo)
        {
            List<ParTabla> listaEntidad = new List<ParTabla>();

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ListarParTabla", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.AddWithValue("@Parametro", parametro);
                    oComando.Parameters.AddWithValue("@activo", activo);
                    oComando.Parameters.AddWithValue("@inactivo", inactivo);

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

        public List<ParTabla> ListarParTablaPorGrupo(Int32 grupo, String parametro)
        {
            List<ParTabla> listaEntidad = new List<ParTabla>();

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ListarParTablaPorGrupo", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.AddWithValue("@Grupo", grupo);
                    oComando.Parameters.AddWithValue("@Parametro", parametro);

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

        public List<ParTabla> ListarParTablaPorGrupo(EnumParTabla grupo)
        {
            return ListarParTablaPorGrupo((Int32)grupo, "");
        }

        public Dictionary<EnumParTabla, List<ParTabla>> ListarParTablaPorListaGrupo(List<EnumParTabla> listaGrupo)
        {
            Dictionary<EnumParTabla, List<ParTabla>> lista = new Dictionary<EnumParTabla, List<ParTabla>>();

            foreach (EnumParTabla item in listaGrupo)
            {
                lista.Add(item, ListarParTablaPorGrupo(item));
            }

            return lista;
        }

        public Int32 AnularParTabla(Int32 idPartabla)
        {
            Int32 Resp = 0;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_AnularParTabla", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add(new SqlParameter("@IdParTabla", idPartabla));

                    oConexion.Open();
                    Resp = oComando.ExecuteNonQuery();
                }
            }

            return Resp;
        }

        public Int32 ActualizarParTabla(ParTabla partabla)
        {
            Int32 Resp = 0;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ActualizarParTabla", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add(new SqlParameter("@IdParTabla", partabla.IdParTabla));
                    oComando.Parameters.Add(new SqlParameter("@Nombre", partabla.Nombre));
                    oComando.Parameters.Add(new SqlParameter("@Descripcion", partabla.Descripcion));
                    oComando.Parameters.Add(new SqlParameter("@NemoTecnico", partabla.NemoTecnico));
                    oComando.Parameters.Add(new SqlParameter("@EsEditable", partabla.EsEditable));
                    oComando.Parameters.Add(new SqlParameter("@EquivalenciaSunat", partabla.EquivalenciaSunat));
                    oComando.Parameters.Add(new SqlParameter("@Estado", partabla.Estado));
                    oComando.Parameters.Add(new SqlParameter("@UsuarioModificacion", partabla.UsuarioModificacion));
                    oComando.Parameters.Add(new SqlParameter("@ValorCadena", partabla.ValorCadena));
                    oComando.Parameters.Add(new SqlParameter("@ValorEntero", partabla.ValorEntero));
                    oComando.Parameters.Add(new SqlParameter("@FlagCorrelativo", partabla.FlagCorrelativo));

                    oConexion.Open();
                    Resp = oComando.ExecuteNonQuery();
                }
            }

            return Resp;
        }

        public ParTabla RecuperarParTablaPorId(Int32 idPartabla)
        {
            ParTabla entidad = new ParTabla();

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_RecuperarParTablaPorId", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@IdPartabla", SqlDbType.Int).Value = idPartabla;

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

        public Int32 RecuperarMaxIdParTablaPorGrupo(Int32 grupo)
        {
            Int32 MaxID = 0;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_MaxIdParTabla", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@Grupo", SqlDbType.Int).Value = grupo;

                    oConexion.Open();
                    MaxID = Convert.ToInt32(oComando.ExecuteScalar());
                }
            }

            return MaxID;
        }

        public Int32 RecuperarMaxGrupoPartabla()
        {
            Int32 MaxGrupo = 0;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_MaxGrupoPartabla", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oConexion.Open();

                    MaxGrupo = Convert.ToInt32(oComando.ExecuteScalar());
                }
            }

            return MaxGrupo;
        }

        public String RecuperarNombreGrupoParTabla(Int32 IdParTabla)
        {
            String Nombre = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_RecuperarNombreGrupoParTabla", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@IdPartabla", SqlDbType.Int).Value = IdParTabla;

                    oConexion.Open();

                    Nombre = Convert.ToString(oComando.ExecuteScalar());
                }
            }

            return Nombre;
        }

        public List<ParTabla> ListarParTablaxGrupoXestado(Int32 grupo, Boolean activo, Boolean inactivo)
        {
            List<ParTabla> listaEntidad = new List<ParTabla>();

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ListarParTablaxGrupoXestado", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@Grupo", SqlDbType.Int).Value = grupo;
                    oComando.Parameters.Add("@activo", SqlDbType.Bit).Value = activo;
                    oComando.Parameters.Add("@inactivo", SqlDbType.Bit).Value = inactivo;

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

        public List<ParTabla> ListarParTablaCorrelativo()
        {
            List<ParTabla> listaEntidad = new List<ParTabla>();

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ListarParTablaCorrelativo", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
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

        public List<ParTabla> ListarParTablaEnlace(Int32 ValorCadena)
        {
            List<ParTabla> oLista = new List<ParTabla>();

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ListarParTablaEnlace", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@ValorCadena", SqlDbType.Int).Value = ValorCadena;

                    oConexion.Open();

                    using (SqlDataReader oReader = oComando.ExecuteReader())
                    {
                        while (oReader.Read())
                        {
                            oLista.Add(LlenarEntidad(oReader));
                        }
                    }
                }
            }

            return oLista;
        }

        public List<ParTabla> ListarParTablaTemperaturas(Int32 grupo)
        {
            List<ParTabla> listaEntidad = new List<ParTabla>();

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ListarParTablaTemperaturas", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@Grupo", SqlDbType.Int).Value = grupo;

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

        public List<ParTabla> ListarParTablaPorNemo(String NemoTecnico)
        {
            List<ParTabla> listaEntidad = new List<ParTabla>();

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ListarParTablaPorNemo", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@NemoTecnico", SqlDbType.NVarChar, 50).Value = NemoTecnico;

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

        public ParTabla ParTablaPorNemo(String NemoTecnico)
        {
            ParTabla entidad = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ParTablaPorNemo", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@NemoTecnico", SqlDbType.NVarChar, 50).Value = NemoTecnico;

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

        public Int32 ObtenerIdCalibre(String Nemotecnico)
        {
            ParTabla calibre = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ObtenerIdCalibre", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@Nemotecnico", SqlDbType.VarChar, 50).Value = Nemotecnico;

                    oConexion.Open();

                    using (SqlDataReader oReader = oComando.ExecuteReader())
                    {
                        while (oReader.Read())
                        {
                            calibre = LlenarEntidad(oReader);
                        }
                    }
                }
            }

            return calibre.IdParTabla;
        }

        public Int32 ObtenerIdCategoria(String Nombre)
        {
            ParTabla categoria = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ObtenerIdcategoria", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@Nombre", SqlDbType.VarChar, 100).Value = Nombre;

                    oConexion.Open();

                    using (SqlDataReader oReader = oComando.ExecuteReader())
                    {
                        while (oReader.Read())
                        {
                            categoria = LlenarEntidad(oReader);
                        }
                    }
                }
            }

            return categoria.IdParTabla;
        }

        public Int32 ObtenerIdColor(String Descripcion)
        {
            ParTabla color = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ObtenerIdcolor", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@Descripcion", SqlDbType.VarChar, 250).Value = Descripcion;

                    oConexion.Open();

                    using (SqlDataReader oReader = oComando.ExecuteReader())
                    {
                        while (oReader.Read())
                        {
                            color = LlenarEntidad(oReader);
                        }
                    }
                }
            }

            return color.IdParTabla;
        }

        public List<ParTabla> ListarParTablaPorValorCadena(String ValorCadena)
        {
            List<ParTabla> oLista = new List<ParTabla>();

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ListarParTablaPorValorCadena", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@ValorCadena", SqlDbType.VarChar, 20).Value = ValorCadena;

                    oConexion.Open();

                    using (SqlDataReader oReader = oComando.ExecuteReader())
                    {
                        while (oReader.Read())
                        {
                            oLista.Add(LlenarEntidad(oReader));
                        }
                    }
                }
            }

            return oLista;
        }

        public List<ParTabla> ListarParTablaPorValorEntero(Int32 ValorEntero)
        {
            List<ParTabla> oLista = new List<ParTabla>();

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ListarParTablaPorValorEntero", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@ValorEntero", SqlDbType.Int).Value = ValorEntero;

                    oConexion.Open();

                    using (SqlDataReader oReader = oComando.ExecuteReader())
                    {
                        while (oReader.Read())
                        {
                            oLista.Add(LlenarEntidad(oReader));
                        }
                    }
                }
            }

            return oLista;
        }
    }
}
