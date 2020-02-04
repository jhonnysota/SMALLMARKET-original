using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

using Entidades.Ventas;
using AccesoDatos.Util;

namespace AccesoDatos.Ventas
{
    public class LetrasEstadoAD : DbConection
    {

        public LetrasEstadoE LlenarEntidad(IDataReader oReader)
        {
            LetrasEstadoE letrasestado = new LetrasEstadoE();
            
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idEmpresa'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				letrasestado.idEmpresa = oReader["idEmpresa"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idEmpresa"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idLocal'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				letrasestado.idLocal = oReader["idLocal"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idLocal"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='tipCanje'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				letrasestado.tipCanje = oReader["tipCanje"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["tipCanje"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='codCanje'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				letrasestado.codCanje = oReader["codCanje"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["codCanje"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Numero'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				letrasestado.Numero = oReader["Numero"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["Numero"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Corre'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				letrasestado.Corre = oReader["Corre"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["Corre"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='item'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				letrasestado.item = oReader["item"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["item"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Fecha'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				letrasestado.Fecha = oReader["Fecha"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["Fecha"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Estado'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				letrasestado.Estado = oReader["Estado"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["Estado"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idBanco'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				letrasestado.idBanco = oReader["idBanco"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idBanco"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='numVerPlanCuentas'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				letrasestado.numVerPlanCuentas = oReader["numVerPlanCuentas"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["numVerPlanCuentas"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='codCuenta'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				letrasestado.codCuenta = oReader["codCuenta"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["codCuenta"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='numUnico'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				letrasestado.numUnico = oReader["numUnico"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["numUnico"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='UsuarioRegistro'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                letrasestado.UsuarioRegistro = oReader["UsuarioRegistro"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["UsuarioRegistro"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='FechaRegistro'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                letrasestado.FechaRegistro = oReader["FechaRegistro"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["FechaRegistro"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='UsuarioModificacion'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                letrasestado.UsuarioModificacion = oReader["UsuarioModificacion"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["UsuarioModificacion"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='FechaModificacion'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                letrasestado.FechaModificacion = oReader["FechaModificacion"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["FechaModificacion"]);

            //Extensiones
            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='desEstado'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                letrasestado.desEstado = oReader["desEstado"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["desEstado"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='RazonSocial'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                letrasestado.RazonSocial = oReader["RazonSocial"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["RazonSocial"]);

            return  letrasestado;        
        }

        public LetrasEstadoE InsertarLetrasEstado(LetrasEstadoE letrasestado)
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_InsertarLetrasEstado", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = letrasestado.idEmpresa;
					oComando.Parameters.Add("@idLocal", SqlDbType.Int).Value = letrasestado.idLocal;
					oComando.Parameters.Add("@tipCanje", SqlDbType.Char, 2).Value = letrasestado.tipCanje;
					oComando.Parameters.Add("@codCanje", SqlDbType.Char, 10).Value = letrasestado.codCanje;
					oComando.Parameters.Add("@Numero", SqlDbType.VarChar, 8).Value = letrasestado.Numero;
					oComando.Parameters.Add("@Corre", SqlDbType.Char, 2).Value = letrasestado.Corre;
					oComando.Parameters.Add("@Fecha", SqlDbType.SmallDateTime).Value = letrasestado.Fecha;
					oComando.Parameters.Add("@Estado", SqlDbType.Char, 1).Value = letrasestado.Estado;
					oComando.Parameters.Add("@idBanco", SqlDbType.Int).Value = letrasestado.idBanco;
					oComando.Parameters.Add("@numVerPlanCuentas", SqlDbType.VarChar, 3).Value = letrasestado.numVerPlanCuentas;
					oComando.Parameters.Add("@codCuenta", SqlDbType.VarChar, 20).Value = letrasestado.codCuenta;
					oComando.Parameters.Add("@numUnico", SqlDbType.VarChar, 12).Value = letrasestado.numUnico;
                    oComando.Parameters.Add("@UsuarioRegistro", SqlDbType.VarChar, 20).Value = letrasestado.UsuarioRegistro;

                    oConexion.Open();
                    letrasestado.item = Int32.Parse(oComando.ExecuteScalar().ToString());
                }
            }

            return letrasestado;
        }
        
        public LetrasEstadoE ActualizarLetrasEstado(LetrasEstadoE letrasestado)
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ActualizarLetrasEstado", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = letrasestado.idEmpresa;
					oComando.Parameters.Add("@idLocal", SqlDbType.Int).Value = letrasestado.idLocal;
					oComando.Parameters.Add("@tipCanje", SqlDbType.Char, 2).Value = letrasestado.tipCanje;
					oComando.Parameters.Add("@codCanje", SqlDbType.Char, 10).Value = letrasestado.codCanje;
					oComando.Parameters.Add("@Numero", SqlDbType.VarChar, 8).Value = letrasestado.Numero;
					oComando.Parameters.Add("@Corre", SqlDbType.Char, 2).Value = letrasestado.Corre;
					oComando.Parameters.Add("@item", SqlDbType.Int).Value = letrasestado.item;
					oComando.Parameters.Add("@Fecha", SqlDbType.SmallDateTime).Value = letrasestado.Fecha;
					oComando.Parameters.Add("@Estado", SqlDbType.Char, 1).Value = letrasestado.Estado;
					oComando.Parameters.Add("@idBanco", SqlDbType.Int).Value = letrasestado.idBanco;
					oComando.Parameters.Add("@numVerPlanCuentas", SqlDbType.VarChar, 3).Value = letrasestado.numVerPlanCuentas;
					oComando.Parameters.Add("@codCuenta", SqlDbType.VarChar, 20).Value = letrasestado.codCuenta;
					oComando.Parameters.Add("@numUnico", SqlDbType.VarChar, 12).Value = letrasestado.numUnico;
                    oComando.Parameters.Add("@UsuarioModificacion", SqlDbType.VarChar, 20).Value = letrasestado.UsuarioModificacion;

                    oConexion.Open();
                    oComando.ExecuteNonQuery();
                }
            }

            return letrasestado;
        }

        public int EliminarLetrasEstado(Int32 idEmpresa, Int32 idLocal, String tipCanje, String codCanje, String Numero, String Corre)
        {
            int resp = 0;
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_EliminarLetrasEstado", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@idLocal", SqlDbType.Int).Value = idLocal;
                    oComando.Parameters.Add("@tipCanje", SqlDbType.Char, 2).Value = tipCanje;
                    oComando.Parameters.Add("@codCanje", SqlDbType.Char, 10).Value = codCanje;
                    oComando.Parameters.Add("@Numero", SqlDbType.VarChar, 8).Value = Numero;
                    oComando.Parameters.Add("@Corre", SqlDbType.Char, 2).Value = Corre;

                    oConexion.Open();
                    resp = oComando.ExecuteNonQuery();
                }
            }

            return resp;
        }

        public List<LetrasEstadoE> ListarLetrasEstado()
        {
           List<LetrasEstadoE> listaEntidad = new List<LetrasEstadoE>();
           LetrasEstadoE entidad = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ListarLetrasEstado", oConexion))
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
        
        public LetrasEstadoE ObtenerLetrasEstado(Int32 idEmpresa, Int32 idLocal, String tipCanje, String codCanje, String Numero, String Corre, Int32 item)
        {        
            LetrasEstadoE letrasestado = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ObtenerLetrasEstado", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
					oComando.Parameters.Add("@idLocal", SqlDbType.Int).Value = idLocal;
					oComando.Parameters.Add("@tipCanje", SqlDbType.Char, 2).Value = tipCanje;
					oComando.Parameters.Add("@codCanje", SqlDbType.Char, 10).Value = codCanje;
					oComando.Parameters.Add("@Numero", SqlDbType.VarChar, 8).Value = Numero;
					oComando.Parameters.Add("@Corre", SqlDbType.Char, 2).Value = Corre;
					oComando.Parameters.Add("@item", SqlDbType.Int).Value = item;

                    oConexion.Open();
                    
                    using (SqlDataReader oReader = oComando.ExecuteReader())
                    {
                        while (oReader.Read())
                        {
                            letrasestado = LlenarEntidad(oReader);
                        }
                    }
                }
            }

            return letrasestado;
        }

        public List<LetrasEstadoE> ListarEstadosLetras(Int32 idEmpresa, Int32 idLocal, String tipCanje, String codCanje, String Numero, String Corre)
        {
            List<LetrasEstadoE> listaEntidad = new List<LetrasEstadoE>();
            LetrasEstadoE entidad = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ListarEstadosLetras", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@idLocal", SqlDbType.Int).Value = idLocal;
                    oComando.Parameters.Add("@tipCanje", SqlDbType.Char, 2).Value = tipCanje;
                    oComando.Parameters.Add("@codCanje", SqlDbType.Char, 10).Value = codCanje;
                    oComando.Parameters.Add("@Numero", SqlDbType.VarChar, 8).Value = Numero;
                    oComando.Parameters.Add("@Corre", SqlDbType.Char, 2).Value = Corre;

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

        public int EliminarEstadoPorLetra(Int32 idEmpresa, Int32 idLocal, String tipCanje, String codCanje, String Letra, String Estado)
        {
            Int32 resp = 0;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_EliminarEstadoPorLetra", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@idLocal", SqlDbType.Int).Value = idLocal;
                    oComando.Parameters.Add("@tipCanje", SqlDbType.Char, 2).Value = tipCanje;
                    oComando.Parameters.Add("@codCanje", SqlDbType.Char, 10).Value = codCanje;
                    oComando.Parameters.Add("@Letra", SqlDbType.VarChar, 20).Value = Letra;
                    oComando.Parameters.Add("@Estado", SqlDbType.Char, 1).Value = Estado;

                    oConexion.Open();
                    resp = oComando.ExecuteNonQuery();
                }
            }

            return resp;
        }

    }
}