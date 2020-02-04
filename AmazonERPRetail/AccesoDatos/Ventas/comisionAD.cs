using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

using Entidades.Ventas;
using AccesoDatos.Util;

namespace AccesoDatos.Ventas
{
    public class comisionAD : DbConection
    {
        
        public comisionE LlenarEntidad(IDataReader oReader)
        {
            comisionE comision = new comisionE();
            
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idEmpresa'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				comision.idEmpresa = oReader["idEmpresa"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idEmpresa"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idPeriodo'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				comision.idPeriodo = oReader["idPeriodo"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idPeriodo"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idVendedor'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				comision.idVendedor = oReader["idVendedor"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idVendedor"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Categoria'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				comision.Categoria = oReader["Categoria"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["Categoria"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Categoria1'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				comision.Categoria1 = oReader["Categoria1"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["Categoria1"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Categoria2'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				comision.Categoria2 = oReader["Categoria2"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["Categoria2"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Subjetivo'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				comision.Subjetivo = oReader["Subjetivo"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["Subjetivo"]);

            //EXTENSIONES

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Nombres'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                comision.Nombres = oReader["Nombres"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["Nombres"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='ApeMaterno'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                comision.ApeMaterno = oReader["ApeMaterno"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["ApeMaterno"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='ApePaterno'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                comision.ApePaterno = oReader["ApePaterno"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["ApePaterno"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='NroDocumento'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                comision.NroDocumento = oReader["NroDocumento"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["NroDocumento"]);
			

            return  comision;        
        }

        public comisionE Insertarcomision(comisionE comision)
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_Insertarcomision", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;

                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = comision.idEmpresa;
					oComando.Parameters.Add("@idPeriodo", SqlDbType.Int).Value = comision.idPeriodo;
					oComando.Parameters.Add("@idVendedor", SqlDbType.Int).Value = comision.idVendedor;
					oComando.Parameters.Add("@Categoria", SqlDbType.Decimal).Value = comision.Categoria;
					oComando.Parameters.Add("@Categoria1", SqlDbType.Decimal).Value = comision.Categoria1;
					oComando.Parameters.Add("@Categoria2", SqlDbType.Decimal).Value = comision.Categoria2;
					oComando.Parameters.Add("@Subjetivo", SqlDbType.Decimal).Value = comision.Subjetivo;

                    oConexion.Open();
                    oComando.ExecuteNonQuery();
                    oConexion.Close();
                }
            }

            return comision;
        }
        
        public comisionE Actualizarcomision(comisionE comision)
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_Actualizarcomision", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;

                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = comision.idEmpresa;
					oComando.Parameters.Add("@idPeriodo", SqlDbType.Int).Value = comision.idPeriodo;
					oComando.Parameters.Add("@idVendedor", SqlDbType.Int).Value = comision.idVendedor;
					oComando.Parameters.Add("@Categoria", SqlDbType.Decimal).Value = comision.Categoria;
					oComando.Parameters.Add("@Categoria1", SqlDbType.Decimal).Value = comision.Categoria1;
					oComando.Parameters.Add("@Categoria2", SqlDbType.Decimal).Value = comision.Categoria2;
					oComando.Parameters.Add("@Subjetivo", SqlDbType.Decimal).Value = comision.Subjetivo;

                    oConexion.Open();
                    oComando.ExecuteNonQuery();
                    oConexion.Close();
                }
            }

            return comision;
        }        

        public int Eliminarcomision(Int32 idEmpresa, Int32 idPeriodo, Int32 idVendedor)
        {
            int resp = 0;
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_Eliminarcomision", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;

                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
					oComando.Parameters.Add("@idPeriodo", SqlDbType.Int).Value = idPeriodo;
					oComando.Parameters.Add("@idVendedor", SqlDbType.Int).Value = idVendedor;

                    oConexion.Open();
                    resp = oComando.ExecuteNonQuery();
                    oConexion.Close();
                }
            }

            return resp;
        }

        public List<comisionE> Listarcomision()
        {
           List<comisionE> listaEntidad = new List<comisionE>();
           comisionE entidad = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_Listarcomision", oConexion))
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

                oConexion.Close();
            }

            return listaEntidad;
        }
        
        public comisionE Obtenercomision(Int32 idEmpresa, Int32 idPeriodo, Int32 idVendedor)
        {        
            comisionE comision = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_Obtenercomision", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;

                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
					oComando.Parameters.Add("@idPeriodo", SqlDbType.Int).Value = idPeriodo;
					oComando.Parameters.Add("@idVendedor", SqlDbType.Int).Value = idVendedor;
                    oConexion.Open();
                    
                    using (SqlDataReader oReader = oComando.ExecuteReader())
                    {
                        while (oReader.Read())
                        {
                            comision = LlenarEntidad(oReader);
                        }
                    }
                }

                oConexion.Close();
            }

            return comision;
        }


        public List<comisionE> ResumenComisiones(Int32 idEmpresa, Int32 idPeriodo)
        {
            List<comisionE> listaEntidad = new List<comisionE>();
            comisionE articulo = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ResumenComisiones", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@idPeriodo", SqlDbType.Int).Value = idPeriodo;

                    oConexion.Open();

                    using (SqlDataReader oReader = oComando.ExecuteReader())
                    {
                        while (oReader.Read())
                        {
                            articulo = LlenarEntidad(oReader);
                            listaEntidad.Add(articulo);
                        }
                    }
                }

                oConexion.Close();
            }

            return listaEntidad;
        }

    }
}