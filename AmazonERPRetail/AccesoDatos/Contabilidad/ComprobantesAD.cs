using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

using Entidades.Contabilidad;
using AccesoDatos.Util;

namespace AccesoDatos.Contabilidad
{
    public class ComprobantesAD : DbConection
    {

        public ComprobantesE LlenarEntidad(IDataReader oReader)
        {
            ComprobantesE comprobantes = new ComprobantesE();

            comprobantes.idEmpresa = Convert.ToInt32(oReader["idEmpresa"]);
            comprobantes.idComprobante = Convert.ToString(oReader["idComprobante"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Descripcion'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                comprobantes.Descripcion = oReader["Descripcion"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["Descripcion"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='tpoComprobante'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                comprobantes.tpoComprobante = oReader["tpoComprobante"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["tpoComprobante"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='indTCVenta'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                comprobantes.indTCVenta = oReader["indTCVenta"] == DBNull.Value ? false : Convert.ToBoolean(oReader["indTCVenta"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='UsuarioRegistro'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                comprobantes.UsuarioRegistro = oReader["UsuarioRegistro"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["UsuarioRegistro"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='FechaRegistro'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                comprobantes.FechaRegistro = oReader["FechaRegistro"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["FechaRegistro"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='UsuarioModificacion'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                comprobantes.UsuarioModificacion = oReader["UsuarioModificacion"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["UsuarioModificacion"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='FechaModificacion'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                comprobantes.FechaModificacion = oReader["FechaModificacion"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["FechaModificacion"]);

            //Extensiones
            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idComprobante'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                comprobantes.desComprobanteComp = oReader["idComprobante"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["idComprobante"]) + " - " + Convert.ToString(oReader["Descripcion"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Exportar'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                comprobantes.Check = oReader["Exportar"] == DBNull.Value ? true : Convert.ToBoolean(oReader["Exportar"]);

            return comprobantes;
        }

        public ComprobantesE InsertarComprobantes(ComprobantesE comprobantes)
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_InsertarComprobantes", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = comprobantes.idEmpresa;
                    oComando.Parameters.Add("@idComprobante", SqlDbType.Char, 2).Value = comprobantes.idComprobante;
                    oComando.Parameters.Add("@Descripcion", SqlDbType.VarChar, 40).Value = comprobantes.Descripcion; 
					oComando.Parameters.Add("@tpoComprobante", SqlDbType.Int).Value = comprobantes.tpoComprobante;
                    oComando.Parameters.Add("@indTCVenta", SqlDbType.Bit).Value = comprobantes.indTCVenta;
                    oComando.Parameters.Add("@UsuarioRegistro", SqlDbType.VarChar, 20).Value = comprobantes.UsuarioRegistro;

                    oConexion.Open();
                    oComando.ExecuteNonQuery();
                }
            }

            return comprobantes;        
        }
        
        public ComprobantesE ActualizarComprobantes(ComprobantesE comprobantes)
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ActualizarComprobantes", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = comprobantes.idEmpresa;
                    oComando.Parameters.Add("@idComprobante", SqlDbType.Char, 2).Value = comprobantes.idComprobante;
                    oComando.Parameters.Add("@Descripcion", SqlDbType.VarChar, 40).Value = comprobantes.Descripcion;
                    oComando.Parameters.Add("@tpoComprobante", SqlDbType.Int).Value = comprobantes.tpoComprobante;
                    oComando.Parameters.Add("@indTCVenta", SqlDbType.Bit).Value = comprobantes.indTCVenta;
                    oComando.Parameters.Add("@UsuarioModificacion", SqlDbType.VarChar, 20).Value = comprobantes.UsuarioModificacion;

                    oConexion.Open();
                    oComando.ExecuteNonQuery();
                }
            }

            return comprobantes;
        }

        public String EliminarComprobantes( Int32 idEmpresa, String idComprobante)
        {
            String resp ;
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_EliminarComprobantes", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@idComprobante", SqlDbType.Char,2).Value = idComprobante;

                    oConexion.Open();
                    resp = Convert.ToString(oComando.ExecuteNonQuery());
                }
            }

            return resp;
        }

        public List<ComprobantesE> ListarComprobantes(Int32 idEmpresa)
        {
            List<ComprobantesE> listaEntidad = new List<ComprobantesE>();
            ComprobantesE entidad = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ListarComprobantes", oConexion))
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

        public ComprobantesE ObtenerComprobantePorId(Int32 idEmpresa, String idComprobante)
        {
            ComprobantesE comprobantes = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ObtenerComprobantePorId", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@idComprobante", SqlDbType.Char, 2).Value = idComprobante;

                    oConexion.Open();

                    using (SqlDataReader oReader = oComando.ExecuteReader())
                    {
                        while (oReader.Read())
                        {
                            comprobantes = LlenarEntidad(oReader);
                        }
                    }
                }
            }

            return comprobantes;
        }

    }
}