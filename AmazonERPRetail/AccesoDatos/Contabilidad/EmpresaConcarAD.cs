using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

using Entidades.Contabilidad;
using AccesoDatos.Util;

namespace AccesoDatos.Contabilidad
{
    public class EmpresaConcarAD : DbConection
    {

        public EmpresaConcarE LlenarEntidad(IDataReader oReader)
        {
            EmpresaConcarE EmpresaConcar = new EmpresaConcarE();

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='CodEmpresa'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                EmpresaConcar.CodEmpresa = oReader["CodEmpresa"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["CodEmpresa"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='NomEmpresa'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                EmpresaConcar.NomEmpresa = oReader["NomEmpresa"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["NomEmpresa"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idEmpresa'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                EmpresaConcar.idEmpresa = oReader["idEmpresa"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idEmpresa"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='UsuarioRegistro'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                EmpresaConcar.UsuarioRegistro = oReader["UsuarioRegistro"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["UsuarioRegistro"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='FechaRegistro'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                EmpresaConcar.FechaRegistro = oReader["FechaRegistro"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["FechaRegistro"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='UsuarioModificacion'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                EmpresaConcar.UsuarioModificacion = oReader["UsuarioModificacion"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["UsuarioModificacion"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='FechaModificacion'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                EmpresaConcar.FechaModificacion = oReader["FechaModificacion"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["FechaModificacion"]);

            //extension 
            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='EmpresaDescripcion'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                EmpresaConcar.EmpresaDescripcion = oReader["EmpresaDescripcion"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["EmpresaDescripcion"]);

            return EmpresaConcar;
        }

        public EmpresaConcarE InsertarEmpresaConcar(EmpresaConcarE EmpresaConcar)
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_InsertarEmpresaConcar", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@CodEmpresa", SqlDbType.VarChar, 4).Value = EmpresaConcar.CodEmpresa;
                    oComando.Parameters.Add("@NomEmpresa", SqlDbType.VarChar, 100).Value = EmpresaConcar.NomEmpresa;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = EmpresaConcar.idEmpresa;
                    oComando.Parameters.Add("@UsuarioRegistro", SqlDbType.VarChar, 30).Value = EmpresaConcar.UsuarioRegistro;

                    oConexion.Open();
                    oComando.ExecuteNonQuery();
                }
            }

            return EmpresaConcar;
        }

        public EmpresaConcarE ActualizarEmpresaConcar(EmpresaConcarE EmpresaConcar)
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ActualizarEmpresaConcar", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@CodEmpresa", SqlDbType.VarChar, 4).Value = EmpresaConcar.CodEmpresa;
                    oComando.Parameters.Add("@NomEmpresa", SqlDbType.VarChar, 100).Value = EmpresaConcar.NomEmpresa;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = EmpresaConcar.idEmpresa;
                    oComando.Parameters.Add("@UsuarioModificacion", SqlDbType.VarChar, 30).Value = EmpresaConcar.UsuarioModificacion;

                    oConexion.Open();
                    oComando.ExecuteNonQuery();
                }
            }

            return EmpresaConcar;
        }

        public int EliminarEmpresaConcar(Int32 idEmpresa)
        {
            int resp = 0;
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_EliminarEmpresaConcar", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;

                    oConexion.Open();
                    resp = oComando.ExecuteNonQuery();
                }
            }

            return resp;
        }

        public List<EmpresaConcarE> ListarEmpresaConcar()
        {
            List<EmpresaConcarE> listaEntidad = new List<EmpresaConcarE>();
            EmpresaConcarE entidad = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ListarEmpresaConcar", oConexion))
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

        public EmpresaConcarE ObtenerEmpresaConcar(Int32 idEmpresa)
        {
            EmpresaConcarE EmpresaConcar = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ObtenerEmpresaConcar", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;

                    oConexion.Open();

                    using (SqlDataReader oReader = oComando.ExecuteReader())
                    {
                        while (oReader.Read())
                        {
                            EmpresaConcar = LlenarEntidad(oReader);
                        }
                    }
                }
            }

            return EmpresaConcar;
        }

    }
}
