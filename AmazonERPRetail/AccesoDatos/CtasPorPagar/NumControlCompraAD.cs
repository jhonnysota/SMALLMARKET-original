using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

using Entidades.CtasPorPagar;
using AccesoDatos.Util;

namespace AccesoDatos.CtasPorPagar
{
    public class NumControlCompraAD : DbConection
    {
        
        public NumControlCompraE LlenarEntidad(IDataReader oReader)
        {
            NumControlCompraE numcontrolcompra = new NumControlCompraE();
            
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idEmpresa'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				numcontrolcompra.idEmpresa = oReader["idEmpresa"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idEmpresa"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idLocal'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				numcontrolcompra.idLocal = oReader["idLocal"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idLocal"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idControl'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				numcontrolcompra.idControl = oReader["idControl"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idControl"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Descripcion'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				numcontrolcompra.Descripcion = oReader["Descripcion"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["Descripcion"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='UsuarioRegistro'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				numcontrolcompra.UsuarioRegistro = oReader["UsuarioRegistro"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["UsuarioRegistro"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='FechaRegistro'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				numcontrolcompra.FechaRegistro = oReader["FechaRegistro"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["FechaRegistro"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='UsuarioModificacion'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				numcontrolcompra.UsuarioModificacion = oReader["UsuarioModificacion"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["UsuarioModificacion"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='FechaModificacion'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				numcontrolcompra.FechaModificacion = oReader["FechaModificacion"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["FechaModificacion"]);
			

            return  numcontrolcompra;        
        }

        public NumControlCompraE InsertarNumControlCompra(NumControlCompraE numcontrolcompra)
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_InsertarNumControlCompra", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;

                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = numcontrolcompra.idEmpresa;
					oComando.Parameters.Add("@idLocal", SqlDbType.Int).Value = numcontrolcompra.idLocal;
					oComando.Parameters.Add("@Descripcion", SqlDbType.VarChar, 50).Value = numcontrolcompra.Descripcion;
					oComando.Parameters.Add("@UsuarioRegistro", SqlDbType.VarChar, 20).Value = numcontrolcompra.UsuarioRegistro;
					oComando.Parameters.Add("@FechaRegistro", SqlDbType.SmallDateTime).Value = numcontrolcompra.FechaRegistro;
					oComando.Parameters.Add("@UsuarioModificacion", SqlDbType.VarChar, 20).Value = numcontrolcompra.UsuarioModificacion;
					oComando.Parameters.Add("@FechaModificacion", SqlDbType.SmallDateTime).Value = numcontrolcompra.FechaModificacion;

                    oConexion.Open();
                    numcontrolcompra.idControl = Convert.ToInt32(oComando.ExecuteScalar());
                    oConexion.Close();
                }
            }

            return numcontrolcompra;
        }
        
        public NumControlCompraE ActualizarNumControlCompra(NumControlCompraE numcontrolcompra)
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ActualizarNumControlCompra", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;

                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = numcontrolcompra.idEmpresa;
					oComando.Parameters.Add("@idLocal", SqlDbType.Int).Value = numcontrolcompra.idLocal;
					oComando.Parameters.Add("@idControl", SqlDbType.Int).Value = numcontrolcompra.idControl;
					oComando.Parameters.Add("@Descripcion", SqlDbType.VarChar, 50).Value = numcontrolcompra.Descripcion;
					oComando.Parameters.Add("@UsuarioRegistro", SqlDbType.VarChar, 20).Value = numcontrolcompra.UsuarioRegistro;
					oComando.Parameters.Add("@FechaRegistro", SqlDbType.SmallDateTime).Value = numcontrolcompra.FechaRegistro;
					oComando.Parameters.Add("@UsuarioModificacion", SqlDbType.VarChar, 20).Value = numcontrolcompra.UsuarioModificacion;
					oComando.Parameters.Add("@FechaModificacion", SqlDbType.SmallDateTime).Value = numcontrolcompra.FechaModificacion;

                    oConexion.Open();
                    oComando.ExecuteNonQuery();
                    oConexion.Close();
                }
            }

            return numcontrolcompra;
        }        

        public int EliminarNumControlCompra(Int32 idEmpresa, Int32 idLocal, Int32 idControl)
        {
            int resp = 0;
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_EliminarNumControlCompra", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;

                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
					oComando.Parameters.Add("@idLocal", SqlDbType.Int).Value = idLocal;
					oComando.Parameters.Add("@idControl", SqlDbType.Int).Value = idControl;

                    oConexion.Open();
                    resp = oComando.ExecuteNonQuery();
                    oConexion.Close();
                }
            }

            return resp;
        }

        public List<NumControlCompraE> ListarNumControlCompra(Int32 idEmpresa, Int32 idLocal)
        {
           List<NumControlCompraE> listaEntidad = new List<NumControlCompraE>();
           NumControlCompraE entidad = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ListarNumControlCompra", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@idLocal", SqlDbType.Int).Value = idLocal;

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

                oConexion.Close();
            }

            return listaEntidad;
        }
        
        public NumControlCompraE ObtenerNumControlCompra(Int32 idEmpresa, Int32 idLocal, Int32 idControl)
        {        
            NumControlCompraE numcontrolcompra = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ObtenerNumControlCompra", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;

                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
					oComando.Parameters.Add("@idLocal", SqlDbType.Int).Value = idLocal;
					oComando.Parameters.Add("@idControl", SqlDbType.Int).Value = idControl;
                    oConexion.Open();
                    
                    using (SqlDataReader oReader = oComando.ExecuteReader())
                    {
                        while (oReader.Read())
                        {
                            numcontrolcompra = LlenarEntidad(oReader);
                        }
                    }
                }

                oConexion.Close();
            }

            return numcontrolcompra;
        }
    }
}