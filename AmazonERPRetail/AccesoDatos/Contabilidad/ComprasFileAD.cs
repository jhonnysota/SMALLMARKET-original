using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

using Entidades.Contabilidad;
using AccesoDatos.Util;

namespace AccesoDatos.Contabilidad
{
    public class ComprasFileAD : DbConection
    {

        public ComprasFileE LlenarEntidad(IDataReader oReader)
        {
            ComprasFileE comprasfile = new ComprasFileE();
            
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idCompraFile'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				comprasfile.idCompraFile = oReader["idCompraFile"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idCompraFile"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idEmpresa'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				comprasfile.idEmpresa = oReader["idEmpresa"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idEmpresa"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Descripcion'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				comprasfile.Descripcion = oReader["Descripcion"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["Descripcion"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idComprobante'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				comprasfile.idComprobante = oReader["idComprobante"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["idComprobante"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='numFile'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				comprasfile.numFile = oReader["numFile"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["numFile"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='codColumnaCoven'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                comprasfile.codColumnaCoven = oReader["codColumnaCoven"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["codColumnaCoven"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='nomColumnaCoven'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                comprasfile.nomColumnaCoven = oReader["nomColumnaCoven"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["nomColumnaCoven"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='indColumnaIgv'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                comprasfile.indColumnaIgv = oReader["indColumnaIgv"] == DBNull.Value ? true : Convert.ToBoolean(oReader["indColumnaIgv"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='codColumnaIgv'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                comprasfile.codColumnaIgv = oReader["codColumnaIgv"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["codColumnaIgv"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='indCtaCorriente'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                comprasfile.indCtaCorriente = oReader["indCtaCorriente"] == DBNull.Value ? true : Convert.ToBoolean(oReader["indCtaCorriente"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='AfectaOc'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                comprasfile.AfectaOc = oReader["AfectaOc"] == DBNull.Value ? true : Convert.ToBoolean(oReader["AfectaOc"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='MostrarOp'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                comprasfile.MostrarOp = oReader["MostrarOp"] == DBNull.Value ? true : Convert.ToBoolean(oReader["MostrarOp"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='UsuarioRegistro'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				comprasfile.UsuarioRegistro = oReader["UsuarioRegistro"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["UsuarioRegistro"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='FechaRegistro'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				comprasfile.FechaRegistro = oReader["FechaRegistro"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["FechaRegistro"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='UsuarioModificacion'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				comprasfile.UsuarioModificacion = oReader["UsuarioModificacion"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["UsuarioModificacion"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='FechaModificacion'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				comprasfile.FechaModificacion = oReader["FechaModificacion"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["FechaModificacion"]);

            //Extensiones
            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='RazonSocial'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                comprasfile.RazonSocial = oReader["RazonSocial"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["RazonSocial"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='desComprobante'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                comprasfile.desComprobante = oReader["desComprobante"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["desComprobante"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='desFile'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                comprasfile.desFile = oReader["desFile"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["desFile"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='nomColumnaIgv'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                comprasfile.nomColumnaIgv = oReader["nomColumnaIgv"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["nomColumnaIgv"]);

            return  comprasfile;        
        }

        public ComprasFileE InsertarComprasFile(ComprasFileE comprasfile)
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_InsertarComprasFile", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = comprasfile.idEmpresa;
					oComando.Parameters.Add("@Descripcion", SqlDbType.VarChar, 100).Value = comprasfile.Descripcion;
					oComando.Parameters.Add("@idComprobante", SqlDbType.VarChar, 2).Value = comprasfile.idComprobante;
					oComando.Parameters.Add("@numFile", SqlDbType.VarChar, 2).Value = comprasfile.numFile;
                    oComando.Parameters.Add("@codColumnaCoven", SqlDbType.Int).Value = comprasfile.codColumnaCoven;
                    oComando.Parameters.Add("@indColumnaIgv", SqlDbType.Bit).Value = comprasfile.indColumnaIgv;
                    oComando.Parameters.Add("@codColumnaIgv", SqlDbType.Int).Value = comprasfile.codColumnaIgv;
                    oComando.Parameters.Add("@indCtaCorriente", SqlDbType.Bit).Value = comprasfile.indCtaCorriente;
                    oComando.Parameters.Add("@AfectaOc", SqlDbType.Bit).Value = comprasfile.AfectaOc;
                    oComando.Parameters.Add("@MostrarOp", SqlDbType.Bit).Value = comprasfile.MostrarOp;
                    oComando.Parameters.Add("@UsuarioRegistro", SqlDbType.VarChar, 20).Value = comprasfile.UsuarioRegistro;

                    oConexion.Open();
                    comprasfile.idCompraFile = Int32.Parse(oComando.ExecuteScalar().ToString());
                }
            }

            return comprasfile;
        }
        
        public ComprasFileE ActualizarComprasFile(ComprasFileE comprasfile)
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ActualizarComprasFile", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idCompraFile", SqlDbType.Int).Value = comprasfile.idCompraFile;
					oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = comprasfile.idEmpresa;
					oComando.Parameters.Add("@Descripcion", SqlDbType.VarChar, 100).Value = comprasfile.Descripcion;
					oComando.Parameters.Add("@idComprobante", SqlDbType.VarChar, 2).Value = comprasfile.idComprobante;
					oComando.Parameters.Add("@numFile", SqlDbType.VarChar, 2).Value = comprasfile.numFile;
                    oComando.Parameters.Add("@codColumnaCoven", SqlDbType.Int).Value = comprasfile.codColumnaCoven;
                    oComando.Parameters.Add("@indColumnaIgv", SqlDbType.Bit).Value = comprasfile.indColumnaIgv;
                    oComando.Parameters.Add("@codColumnaIgv", SqlDbType.Int).Value = comprasfile.codColumnaIgv;
                    oComando.Parameters.Add("@indCtaCorriente", SqlDbType.Bit).Value = comprasfile.indCtaCorriente;
                    oComando.Parameters.Add("@AfectaOc", SqlDbType.Bit).Value = comprasfile.AfectaOc;
                    oComando.Parameters.Add("@MostrarOp", SqlDbType.Bit).Value = comprasfile.MostrarOp;
                    oComando.Parameters.Add("@UsuarioModificacion", SqlDbType.VarChar, 20).Value = comprasfile.UsuarioModificacion;

                    oConexion.Open();
                    oComando.ExecuteNonQuery();
                }
            }

            return comprasfile;
        }        

        public int EliminarComprasFile(Int32 idCompraFile)
        {
            int resp = 0;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_EliminarComprasFile", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idCompraFile", SqlDbType.Int).Value = idCompraFile;

                    oConexion.Open();
                    resp = oComando.ExecuteNonQuery();
                }
            }

            return resp;
        }

        public List<ComprasFileE> ListarComprasFile(int idEmpresa)
        {
            List<ComprasFileE> listaEntidad = new List<ComprasFileE>();

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ListarComprasFile", oConexion))
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
        
        public ComprasFileE ObtenerComprasFile(Int32 idCompraFile)
        {        
            ComprasFileE comprasfile = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ObtenerComprasFile", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idCompraFile", SqlDbType.Int).Value = idCompraFile;

                    oConexion.Open();
                    
                    using (SqlDataReader oReader = oComando.ExecuteReader())
                    {
                        while (oReader.Read())
                        {
                            comprasfile = LlenarEntidad(oReader);
                        }
                    }
                }
            }

            return comprasfile;
        }

        public List<ComprasFileE> ComprasFileEmpresas()
        {
            List<ComprasFileE> listaEntidad = new List<ComprasFileE>();
            ComprasFileE entidad = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ComprasFileEmpresas", oConexion))
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

        public List<ComprasFileE> InsertComprasFileOtraEmpresa(Int32 idEmpresa, Int32 idEmpresaNuevo)
        {
            List<ComprasFileE> listaEntidad = new List<ComprasFileE>();
            ComprasFileE entidad = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_InsertComprasFileOtraEmpresa", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@idEmpresaNuevo", SqlDbType.Int).Value = idEmpresaNuevo;

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

        public List<ComprasFileE> ListarComprasDiario(Int32 idEmpresa)
        {
            List<ComprasFileE> oLista = new List<ComprasFileE>();

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ListarComprasDiario", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;

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

        public List<ComprasFileE> ListarComprasDiarioFile(Int32 idEmpresa, String idComprobante)
        {
            List<ComprasFileE> oLista = new List<ComprasFileE>();

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ListarComprasDiarioFile", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@idComprobante", SqlDbType.VarChar, 2).Value = idComprobante;

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