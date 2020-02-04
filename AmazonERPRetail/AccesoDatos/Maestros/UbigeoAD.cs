using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

using Entidades.Maestros;
using AccesoDatos.Util;

namespace AccesoDatos.Ventas
{
    public class UbigeoAD : DbConection
    {

        public UbigeoE LlenarEntidad(IDataReader oReader)
        {
            UbigeoE entidad = new UbigeoE();

            DataView dvSchema = oReader.GetSchemaTable().DefaultView;

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idUbigeo'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                entidad.idUbigeo = oReader["idUbigeo"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["idUbigeo"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Departamento'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                entidad.Departamento = oReader["Departamento"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["Departamento"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Provincia'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                entidad.Provincia = oReader["Provincia"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["Provincia"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Distrito'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                entidad.Distrito = oReader["Distrito"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["Distrito"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='indBaja'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                entidad.indBaja = oReader["indBaja"] == DBNull.Value ? true : Convert.ToBoolean(oReader["indBaja"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idPais'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                entidad.idPais = oReader["idPais"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idPais"]);

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

            //Otros Campos
            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='NombrePais'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                entidad.NombrePais = oReader["NombrePais"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["NombrePais"]);

            return entidad;
        }

        public UbigeoE InsertarUbigeo(UbigeoE ubigeo)
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_InsertarUbigeo", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idUbigeo", SqlDbType.VarChar, 6).Value = ubigeo.idUbigeo;
                    oComando.Parameters.Add("@Departamento", SqlDbType.VarChar, 20).Value = ubigeo.Departamento;
                    oComando.Parameters.Add("@Provincia", SqlDbType.VarChar, 30).Value = ubigeo.Provincia;
                    oComando.Parameters.Add("@Distrito", SqlDbType.VarChar, 40).Value = ubigeo.Distrito;
                    oComando.Parameters.Add("@idPais", SqlDbType.Int).Value = ubigeo.idPais;
                    oComando.Parameters.Add("@UsuarioRegistro", SqlDbType.VarChar, 20).Value = ubigeo.UsuarioRegistro;

                    oConexion.Open();
                    oComando.ExecuteNonQuery();
                }
            }
            return ubigeo;      
        }

        public UbigeoE ActualizarUbigeo(UbigeoE ubigeo)
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ActualizarUbigeo", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idUbigeo", SqlDbType.VarChar, 6).Value = ubigeo.idUbigeo;
                    oComando.Parameters.Add("@Departamento", SqlDbType.VarChar, 20).Value = ubigeo.Departamento;
                    oComando.Parameters.Add("@Provincia", SqlDbType.VarChar, 30).Value = ubigeo.Provincia;
                    oComando.Parameters.Add("@Distrito", SqlDbType.VarChar, 40).Value = ubigeo.Distrito;
                    oComando.Parameters.Add("@idPais", SqlDbType.Int).Value = ubigeo.idPais;
                    oComando.Parameters.Add("@UsuarioModificacion", SqlDbType.VarChar, 20).Value = ubigeo.UsuarioModificacion;

                    oConexion.Open();
                    oComando.ExecuteNonQuery();
                }
            }
            return ubigeo;      
        }

        public UbigeoE ObtenerUbigeo(String idUbigeo)
        {
            UbigeoE ubigeo = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ObtenerUbigeo", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idUbigeo", SqlDbType.VarChar, 6).Value = idUbigeo;

                    oConexion.Open();

                    using (SqlDataReader oReader = oComando.ExecuteReader())
                    {
                        while (oReader.Read())
                        {
                            ubigeo = LlenarEntidad(oReader);
                        }
                    }
                }
            }

            return ubigeo;
        }

        public UbigeoE ObtenerubigeosunatPorDepProDis(String Departamento, String Provincia, String Distrito)
        {
            UbigeoE ubigeo = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ObtenerubigeosunatPorDepProDis", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@Departamento", SqlDbType.VarChar, 60).Value = Departamento;
                    oComando.Parameters.Add("@Provincia", SqlDbType.VarChar, 60).Value = Provincia;
                    oComando.Parameters.Add("@Distrito", SqlDbType.VarChar, 60).Value = Distrito;

                    oConexion.Open();

                    using (SqlDataReader oReader = oComando.ExecuteReader())
                    {
                        while (oReader.Read())
                        {
                            ubigeo = LlenarEntidad(oReader);
                        }
                    }
                }
            }

            return ubigeo;
        }

        public List<UbigeoE> ListarDepartamentos()
        {
            List<UbigeoE> listaubigeo = new List<UbigeoE>();

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ListarDepartamento", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;       
                    oConexion.Open();

                    using (SqlDataReader oReader = oComando.ExecuteReader())
                    {
                        while (oReader.Read())
                        {
                            UbigeoE ubigeo = new UbigeoE();
                            ubigeo.Departamento = oReader["Departamento"].ToString();
                            listaubigeo.Add(ubigeo);
                        }
                    }
                }
            }

            return listaubigeo;
        }

        public List<UbigeoE> ListarProvincias(String Departamento)
        {
            List<UbigeoE> listaubigeo = new List<UbigeoE>();

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ListarProvincia", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@Departamento", SqlDbType.VarChar, 20).Value = Departamento;

                    oConexion.Open();

                    using (SqlDataReader oReader = oComando.ExecuteReader())
                    {
                        while (oReader.Read())
                        {
                            UbigeoE ubigeo = new UbigeoE();

                            ubigeo.Provincia = oReader["Provincia"].ToString();
                            listaubigeo.Add(ubigeo);
                        }
                    }
                }
            }

            return listaubigeo;
        }

        public List<UbigeoE> ListarDistritos(String Departamento, String Provincia)
        {
            List<UbigeoE> listaubigeo = new List<UbigeoE>();            

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ListarDistrito", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@Departamento", SqlDbType.VarChar, 20).Value = Departamento;
                    oComando.Parameters.Add("@Provincia", SqlDbType.VarChar, 30).Value = Provincia;

                    oConexion.Open();

                    using (SqlDataReader oReader = oComando.ExecuteReader())
                    {
                        while (oReader.Read())
                        {
                            UbigeoE ubigeo = new UbigeoE();

                            ubigeo.idUbigeo = oReader["idUbigeo"].ToString();
                            ubigeo.Distrito = oReader["Distrito"].ToString();
                            listaubigeo.Add(ubigeo);
                        }
                    }
                }
            }

            return listaubigeo;
        }

        public UbigeoE RecuperarUbigeoPorId(String idUbigeo)
        {
            UbigeoE ubigeo = new UbigeoE();
            List<UbigeoE> listUbigeo = new List<UbigeoE>(); 

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_RecuperarUbigeoPorId", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idUbigeo", SqlDbType.VarChar, 6).Value = idUbigeo;

                    oConexion.Open();

                    using (SqlDataReader oReader = oComando.ExecuteReader())
                    {                        
                        while (oReader.Read())
                        {
                            ubigeo = LlenarEntidad(oReader);
                            listUbigeo.Add(ubigeo);
                        }
                    }
                }
            }

            return ubigeo;
        }

        public List<UbigeoE> ListarUbigeo(Int32 idPais, Boolean Activo, Boolean Inactivo)
        {
            List<UbigeoE> listaubigeo = new List<UbigeoE>();
            UbigeoE ubigeo = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ListarUbigeo", oConexion))
                {
                    oComando.CommandType = System.Data.CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idPais", SqlDbType.Int).Value = idPais;
                    oComando.Parameters.Add("@Activo", SqlDbType.Bit).Value = Activo;
                    oComando.Parameters.Add("@Inactivo", SqlDbType.Bit).Value = Inactivo;

                    oConexion.Open();

                    using (SqlDataReader oReader = oComando.ExecuteReader())
                    {
                        while (oReader.Read())
                        {
                            ubigeo = LlenarEntidad(oReader);
                            listaubigeo.Add(ubigeo);
                        } 
                    }

                }
            }

            return listaubigeo;
        }

        public Int32 AnularUbigeo(String idUbigeo, String UsuarioModificacion)
        {
            Int32 resp = 0;
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_AnularUbigeo", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idUbigeo", SqlDbType.VarChar, 6).Value = idUbigeo;
                    oComando.Parameters.Add("@UsuarioModificacion", SqlDbType.VarChar, 30).Value = UsuarioModificacion;

                    oConexion.Open();
                    resp = oComando.ExecuteNonQuery();
                }
            }

            return resp;
        }

        #region Por Revisar si se usa           
        
        public List<UbigeoE> ListarUbigeoPorParametro(String parametro)
        {
            List<UbigeoE> listaubigeo = new List<UbigeoE>();
            UbigeoE ubigeo = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ListarUbigeoPorParametro", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add(new SqlParameter("@Parametro", parametro));
                    oConexion.Open();
                    SqlDataReader oReader = oComando.ExecuteReader();
                    while (oReader.Read())
                    {
                        ubigeo = LlenarEntidad(oReader);
                        listaubigeo.Add(ubigeo);
                    }

                }
                oConexion.Close();
            }

            return listaubigeo;
        }
        
        public int MaxDepartamento()
        {
            int MaxID = 0;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_MaxDepartamento", oConexion))
                {
                    oComando.CommandType = System.Data.CommandType.StoredProcedure;
                    oConexion.Open();
                    MaxID = Convert.ToInt32(oComando.ExecuteScalar());
                }
                oConexion.Close();

                return MaxID;
            }
        }

        public int MaxProvincia(String departamento)
        {
            int MaxID = 0;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_MaxProvinciaPorDepartamento", oConexion))
                {
                    oComando.CommandType = System.Data.CommandType.StoredProcedure;
                    oComando.Parameters.Add(new SqlParameter("@Departamento", departamento));
                    oConexion.Open();
                    MaxID = Convert.ToInt32(oComando.ExecuteScalar());
                }
                oConexion.Close();

                return MaxID;
            }
        }

        public int MaxDistrito(String provincia)
        {
            int MaxID = 0;
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_MaxDistritoPorProvincia", oConexion))
                {
                    oComando.CommandType = System.Data.CommandType.StoredProcedure;
                    oComando.Parameters.Add(new SqlParameter("@Provincia", provincia));
                    oConexion.Open();
                    MaxID = Convert.ToInt32(oComando.ExecuteScalar());
                }
                oConexion.Close();
                return MaxID;
            }
        }

        public List<UbigeoE> ListarUbigeoPorDistritoPorParametro(String parametro)
        {
            List<UbigeoE> listaubigeo = new List<UbigeoE>();
            UbigeoE ubigeo = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ListarDistritoPorParametro", oConexion))
                {
                    oComando.CommandType = System.Data.CommandType.StoredProcedure;
                    oComando.Parameters.Add(new SqlParameter("@Parametro", parametro));
                    oConexion.Open();
                    SqlDataReader oReader = oComando.ExecuteReader();
                    while (oReader.Read())
                    {
                        ubigeo = LlenarEntidad(oReader);
                        listaubigeo.Add(ubigeo);
                    }

                }
                oConexion.Close();
            }

            return listaubigeo;
        }

        #endregion

    }
}
