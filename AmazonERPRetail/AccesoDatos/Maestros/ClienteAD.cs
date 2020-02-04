using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

using Entidades.Maestros;
using AccesoDatos.Util;

namespace AccesoDatos.Maestros
{
    public class ClienteAD : DbConection
    {

        public ClienteE LlenarEntidad(IDataReader oReader)
        {
            ClienteE cliente = new ClienteE();
            cliente.idPersona = Convert.ToInt32(oReader["idPersona"]);
            cliente.idEmpresa = Convert.ToInt32(oReader["idEmpresa"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='SiglaComercial'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                cliente.SiglaComercial = oReader["SiglaComercial"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["SiglaComercial"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='TipoCliente'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                cliente.TipoCliente = oReader["TipoCliente"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["TipoCliente"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='fecInscripcion'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                cliente.fecInscripcion = oReader["fecInscripcion"] == DBNull.Value ? (Nullable<DateTime>)null : Convert.ToDateTime(oReader["fecInscripcion"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='fecInicioEmpresa'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                cliente.fecInicioEmpresa = oReader["fecInicioEmpresa"] == DBNull.Value ? (Nullable<DateTime>)null : Convert.ToDateTime(oReader["fecInicioEmpresa"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='tipConstitucion'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                cliente.tipConstitucion = oReader["tipConstitucion"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["tipConstitucion"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='tipRegimen'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                cliente.tipRegimen = oReader["tipRegimen"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["tipRegimen"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='catCliente'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                cliente.catCliente = oReader["catCliente"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["catCliente"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='indEstado'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                cliente.indEstado = oReader["indEstado"] == DBNull.Value ? false : Convert.ToBoolean(oReader["indEstado"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='fecBaja'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                cliente.fecBaja = oReader["fecBaja"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["fecBaja"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='indVinculada'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                cliente.indVinculada = oReader["indVinculada"] == DBNull.Value ? false : Convert.ToBoolean(oReader["indVinculada"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='UsuarioRegistro'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                cliente.UsuarioRegistro = oReader["UsuarioRegistro"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["UsuarioRegistro"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='FechaRegistro'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                cliente.FechaRegistro = oReader["FechaRegistro"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["FechaRegistro"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='UsuarioModificacion'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                cliente.UsuarioModificacion = oReader["UsuarioModificacion"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["UsuarioModificacion"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='FechaModificacion'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                cliente.FechaModificacion = oReader["FechaModificacion"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["FechaModificacion"]);

            //OTROS CAMPOS
            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='RazonSocial'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                cliente.RazonSocial = oReader["RazonSocial"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["RazonSocial"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='RUC'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                cliente.RUC = oReader["RUC"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["RUC"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='DireccionCompleta'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                cliente.DireccionCompleta = oReader["DireccionCompleta"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["DireccionCompleta"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idCanalVenta'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                cliente.idCanalVenta = oReader["idCanalVenta"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idCanalVenta"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='AgenteRetenedor'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                cliente.AgenteRetenedor = oReader["AgenteRetenedor"] == DBNull.Value ? false : Convert.ToBoolean(oReader["AgenteRetenedor"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='DesPais'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                cliente.DesPais = oReader["DesPais"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["DesPais"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='DesDep'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                cliente.DesDep = oReader["DesDep"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["DesDep"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='DesDis'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                cliente.DesDis = oReader["DesDis"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["DesDis"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='DesPro'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                cliente.DesPro = oReader["DesPro"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["DesPro"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idMoneda'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                cliente.idMoneda = oReader["idMoneda"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["idMoneda"]);

            return cliente;
        }

        public ClienteE InsertarCliente(ClienteE cliente)
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_InsertarCliente", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idPersona", SqlDbType.Int).Value = cliente.idPersona;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = cliente.idEmpresa;
                    oComando.Parameters.Add("@SiglaComercial", SqlDbType.VarChar, 50).Value = cliente.SiglaComercial;
                    oComando.Parameters.Add("@TipoCliente", SqlDbType.Int).Value = cliente.TipoCliente;
                    oComando.Parameters.Add("@fecInscripcion", SqlDbType.DateTime).Value = cliente.fecInscripcion;
                    oComando.Parameters.Add("@fecInicioEmpresa", SqlDbType.DateTime).Value = cliente.fecInicioEmpresa;
                    oComando.Parameters.Add("@tipConstitucion", SqlDbType.Int).Value = cliente.tipConstitucion;
                    oComando.Parameters.Add("@tipRegimen", SqlDbType.Int).Value = cliente.tipRegimen;
                    oComando.Parameters.Add("@catCliente", SqlDbType.Int).Value = cliente.catCliente;
                    oComando.Parameters.Add("@indEstado", SqlDbType.Bit).Value = cliente.indEstado;
                    oComando.Parameters.Add("@fecBaja", SqlDbType.DateTime).Value = cliente.fecBaja;
                    oComando.Parameters.Add("@indVinculada", SqlDbType.Bit).Value = cliente.indVinculada;

                    oComando.Parameters.Add("@idMoneda", SqlDbType.Char,2).Value = cliente.idMoneda;
                    
                    oComando.Parameters.Add("@UsuarioRegistro", SqlDbType.VarChar, 20).Value = cliente.UsuarioRegistro;

                    oConexion.Open();
                    oComando.ExecuteNonQuery();
                }
            }

            return cliente;
        }
        
        public ClienteE ActualizarCliente(ClienteE cliente)
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ActualizarCliente", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idPersona", SqlDbType.Int).Value = cliente.idPersona;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = cliente.idEmpresa;
                    oComando.Parameters.Add("@SiglaComercial", SqlDbType.VarChar, 50).Value = cliente.SiglaComercial;
                    oComando.Parameters.Add("@TipoCliente", SqlDbType.Int).Value = cliente.TipoCliente;
                    oComando.Parameters.Add("@fecInscripcion", SqlDbType.DateTime).Value = cliente.fecInscripcion;
                    oComando.Parameters.Add("@fecInicioEmpresa", SqlDbType.DateTime).Value = cliente.fecInicioEmpresa;
                    oComando.Parameters.Add("@tipConstitucion", SqlDbType.Int).Value = cliente.tipConstitucion;
                    oComando.Parameters.Add("@tipRegimen", SqlDbType.Int).Value = cliente.tipRegimen;
                    oComando.Parameters.Add("@catCliente", SqlDbType.Int).Value = cliente.catCliente;
                    oComando.Parameters.Add("@indEstado", SqlDbType.Bit).Value = cliente.indEstado;
                    oComando.Parameters.Add("@fecBaja", SqlDbType.SmallDateTime).Value = cliente.fecBaja;
                    oComando.Parameters.Add("@indVinculada", SqlDbType.Bit).Value = cliente.indVinculada;

                    oComando.Parameters.Add("@idMoneda", SqlDbType.Char, 2).Value = cliente.idMoneda;

                    oComando.Parameters.Add("@UsuarioModificacion", SqlDbType.VarChar, 20).Value = cliente.UsuarioModificacion;

                    oConexion.Open();
                    oComando.ExecuteNonQuery();
                }
            }

            return cliente;
        }

        public Int32 AnularCliente(Int32 idPersona, Int32 idEmpresa, Boolean indBaja, String UsuarioModificacion)
        {
            Int32 resp = 0;
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_AnularCliente", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;

                    oComando.Parameters.Add("@idPersona", SqlDbType.Int).Value = idPersona;
					oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@indEstado", SqlDbType.Bit).Value = indBaja;
                    oComando.Parameters.Add("@UsuarioModificacion", SqlDbType.VarChar, 20).Value = UsuarioModificacion;

                    oConexion.Open();
                    resp = oComando.ExecuteNonQuery();
                }
            }

            return resp;
        }

        public Int32 EliminarCliente(Int32 idEmpresa ,Int32 idPersona )
        {
            Int32 resp = 0;
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_EliminarCliente", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;

                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@idPersona", SqlDbType.Int).Value = idPersona;

                    oConexion.Open();
                    resp = oComando.ExecuteNonQuery();
                }
            }

            return resp;
        }

        public List<ClienteE> BuscarClientes(Int32 idEmpresa, String RazonSocial, String NroDocumento, Int32 TipoCliente)
        {
            List<ClienteE> listaEntidad = new List<ClienteE>();
            ClienteE cliente = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_BuscarClientes", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@RazonSocial", SqlDbType.NVarChar, 100).Value = RazonSocial;
                    oComando.Parameters.Add("@NroDocumento", SqlDbType.NVarChar, 25).Value = NroDocumento;
                    oComando.Parameters.Add("@TipoCliente", SqlDbType.Int).Value = TipoCliente;

                    oConexion.Open();

                    using (SqlDataReader oReader = oComando.ExecuteReader())
                    {
                        while (oReader.Read())
                        {
                            cliente = LlenarEntidad(oReader);
                            listaEntidad.Add(cliente);
                        }
                    }
                }
            }

            return listaEntidad;
        }

        public ClienteE RecuperarClientePorId(Int32 idPersona, Int32 idEmpresa)
        {
            ClienteE cliente = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_RecuperarClientePorId", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idPersona", SqlDbType.Int).Value = idPersona;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    
                    oConexion.Open();

                    using (SqlDataReader oReader = oComando.ExecuteReader())
                    {
                        while (oReader.Read())
                        {
                            cliente = LlenarEntidad(oReader);
                        }
                    }
                }
            }

            return cliente;
        }

        public List<ClienteE> ListarClientePorParametro(Int32 idEmpresa, String RazonSocial, String NroDocumento, Boolean activo, Boolean inactivo)
        {
           List<ClienteE> listaEntidad = new List<ClienteE>();
           ClienteE entidad = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ListarClientePorParametro", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@RazonSocial", SqlDbType.NVarChar, 300).Value = RazonSocial;
                    oComando.Parameters.Add("@NroDocumento", SqlDbType.NVarChar, 25).Value = NroDocumento;
                    oComando.Parameters.Add("@activo", SqlDbType.Bit).Value = activo;
                    oComando.Parameters.Add("@inactivo", SqlDbType.Bit).Value = inactivo;
                    
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