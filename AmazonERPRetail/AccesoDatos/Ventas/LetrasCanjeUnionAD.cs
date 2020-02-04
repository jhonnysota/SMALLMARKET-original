using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

using Entidades.Ventas;
using AccesoDatos.Util;

namespace AccesoDatos.Ventas
{
    public class LetrasCanjeUnionAD : DbConection
    {

        public LetrasCanjeUnionE LlenarEntidad(IDataReader oReader)
        {
            LetrasCanjeUnionE letrascanjeunion = new LetrasCanjeUnionE();
            
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idEmpresa'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				letrascanjeunion.idEmpresa = oReader["idEmpresa"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idEmpresa"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idLocal'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				letrascanjeunion.idLocal = oReader["idLocal"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idLocal"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='nomZona'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                letrascanjeunion.nomZona = oReader["nomZona"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["nomZona"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='nomVendedor'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                letrascanjeunion.nomVendedor = oReader["nomVendedor"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["nomVendedor"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='ruc'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                letrascanjeunion.ruc = oReader["ruc"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["ruc"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='RazonSocial'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                letrascanjeunion.RazonSocial = oReader["RazonSocial"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["RazonSocial"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='RazonSocial'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                letrascanjeunion.RazonSocial = oReader["RazonSocial"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["RazonSocial"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idDocumento'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                letrascanjeunion.idDocumento = oReader["idDocumento"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["idDocumento"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='numSerie'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                letrascanjeunion.numSerie = oReader["numSerie"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["numSerie"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='numDocumento'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                letrascanjeunion.numDocumento = oReader["numDocumento"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["numDocumento"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='fecDocumento'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                letrascanjeunion.fecDocumento = oReader["fecDocumento"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["fecDocumento"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='fecVencimiento'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                letrascanjeunion.fecVencimiento = oReader["fecVencimiento"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["fecVencimiento"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='numDocumento'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                letrascanjeunion.numDocumento = oReader["numDocumento"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["numDocumento"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='NomMoneda'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                letrascanjeunion.NomMoneda = oReader["NomMoneda"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["NomMoneda"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Importe'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                letrascanjeunion.Importe = oReader["Importe"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["Importe"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='SaldoDoc'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                letrascanjeunion.SaldoDoc = oReader["SaldoDoc"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["SaldoDoc"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='EstadoDocumento'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                letrascanjeunion.EstadoDocumento = oReader["EstadoDocumento"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["EstadoDocumento"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='tipCanje'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				letrascanjeunion.tipCanje = oReader["tipCanje"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["tipCanje"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='codCanje'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				letrascanjeunion.codCanje = oReader["codCanje"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["codCanje"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Estado'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				letrascanjeunion.Estado = oReader["Estado"] == DBNull.Value ? true : Convert.ToBoolean(oReader["Estado"]);

            return  letrascanjeunion;        
        }

        public LetrasCanjeUnionE InsertarLetrasCanjeUnion(LetrasCanjeUnionE letrascanjeunion)
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_InsertarLetrasCanjeUnion", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = letrascanjeunion.idEmpresa;
					oComando.Parameters.Add("@idLocal", SqlDbType.Int).Value = letrascanjeunion.idLocal;
					oComando.Parameters.Add("@tipCanje", SqlDbType.Char, 2).Value = letrascanjeunion.tipCanje;
					oComando.Parameters.Add("@codCanje", SqlDbType.Char, 10).Value = letrascanjeunion.codCanje;
					oComando.Parameters.Add("@Estado", SqlDbType.Bit).Value = letrascanjeunion.Estado;

                    oConexion.Open();
                    oComando.ExecuteNonQuery();
                }
            }

            return letrascanjeunion;
        }
        
        public LetrasCanjeUnionE ActualizarLetrasCanjeUnion(LetrasCanjeUnionE letrascanjeunion)
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ActualizarLetrasCanjeUnion", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = letrascanjeunion.idEmpresa;
					oComando.Parameters.Add("@idLocal", SqlDbType.Int).Value = letrascanjeunion.idLocal;
					oComando.Parameters.Add("@tipCanje", SqlDbType.Char, 2).Value = letrascanjeunion.tipCanje;
					oComando.Parameters.Add("@codCanje", SqlDbType.Char, 10).Value = letrascanjeunion.codCanje;
					oComando.Parameters.Add("@Estado", SqlDbType.Bit).Value = letrascanjeunion.Estado;

                    oConexion.Open();
                    oComando.ExecuteNonQuery();
                }
            }

            return letrascanjeunion;
        }        

        public int EliminarLetrasCanjeUnion(Int32 idEmpresa, Int32 idLocal, String tipCanje, String codCanje)
        {
            int resp = 0;
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_EliminarLetrasCanjeUnion", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
					oComando.Parameters.Add("@idLocal", SqlDbType.Int).Value = idLocal;
					oComando.Parameters.Add("@tipCanje", SqlDbType.Char, 2).Value = tipCanje;
					oComando.Parameters.Add("@codCanje", SqlDbType.Char, 10).Value = codCanje;

                    oConexion.Open();
                    resp = oComando.ExecuteNonQuery();
                }
            }

            return resp;
        }

        public List<LetrasCanjeUnionE> ListarLetrasCanjeUnion()
        {
            List<LetrasCanjeUnionE> listaEntidad = new List<LetrasCanjeUnionE>();
            LetrasCanjeUnionE entidad = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ListarLetrasCanjeUnion", oConexion))
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
        
        public LetrasCanjeUnionE ObtenerLetrasCanjeUnion(Int32 idEmpresa, Int32 idLocal, String tipCanje, String codCanje)
        {        
            LetrasCanjeUnionE letrascanjeunion = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ObtenerLetrasCanjeUnion", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
					oComando.Parameters.Add("@idLocal", SqlDbType.Int).Value = idLocal;
					oComando.Parameters.Add("@tipCanje", SqlDbType.Char, 2).Value = tipCanje;
					oComando.Parameters.Add("@codCanje", SqlDbType.Char, 10).Value = codCanje;

                    oConexion.Open();
                    
                    using (SqlDataReader oReader = oComando.ExecuteReader())
                    {
                        while (oReader.Read())
                        {
                            letrascanjeunion = LlenarEntidad(oReader);
                        }
                    }
                }
            }

            return letrascanjeunion;
        }

        public List<LetrasCanjeUnionE> ReporteCanjeLetra(Int32 idEmpresa, Int32 idLocal, String tipCanje, String codCanje)
        {
            List<LetrasCanjeUnionE> listaEntidad = new List<LetrasCanjeUnionE>();

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ReporteCanjeLetra", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;

                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@idLocal", SqlDbType.Int).Value = idLocal;
                    oComando.Parameters.Add("@tipCanje", SqlDbType.Char, 2).Value = tipCanje;
                    oComando.Parameters.Add("@codCanje", SqlDbType.Char, 10).Value = codCanje;

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

        public List<LetrasCanjeUnionE> ReporteCanjeLetraPorEstado(Int32 idEmpresa, Int32 idLocal, Int32 idPersona, String Estado)
        {
            List<LetrasCanjeUnionE> listaEntidad = new List<LetrasCanjeUnionE>();

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ReporteCanjeLetraPorEstado", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;

                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@idLocal", SqlDbType.Int).Value = idLocal;
                    oComando.Parameters.Add("@idPersona", SqlDbType.Int).Value = idPersona;
                    oComando.Parameters.Add("@Estado", SqlDbType.VarChar, 1).Value = Estado;

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

    }
}