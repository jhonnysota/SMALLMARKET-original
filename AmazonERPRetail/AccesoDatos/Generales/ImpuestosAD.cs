using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

using Entidades.Generales;
using AccesoDatos.Util;

namespace AccesoDatos.Generales
{
    public class ImpuestosAD : DbConection
    {
        
        public ImpuestosE LlenarEntidad(IDataReader oReader)
        {
            ImpuestosE impuestos = new ImpuestosE();
            
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idImpuesto'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				impuestos.idImpuesto = oReader["idImpuesto"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idImpuesto"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='numVerPlanCuentas'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				impuestos.numVerPlanCuentas = oReader["numVerPlanCuentas"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["numVerPlanCuentas"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='codCuenta'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				impuestos.codCuenta = oReader["codCuenta"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["codCuenta"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='desImpuesto'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				impuestos.desImpuesto = oReader["desImpuesto"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["desImpuesto"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='desAbreviatura'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				impuestos.desAbreviatura = oReader["desAbreviatura"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["desAbreviatura"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='UsuarioRegistro'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				impuestos.UsuarioRegistro = oReader["UsuarioRegistro"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["UsuarioRegistro"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='FechaRegistro'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				impuestos.FechaRegistro = oReader["FechaRegistro"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["FechaRegistro"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='UsuarioModificacion'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				impuestos.UsuarioModificacion = oReader["UsuarioModificacion"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["UsuarioModificacion"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='FechaModificacion'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				impuestos.FechaModificacion = oReader["FechaModificacion"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["FechaModificacion"]);
			
            //Extensiones
            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='desCuenta'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                impuestos.desCuenta = oReader["desCuenta"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["desCuenta"]);

            return  impuestos;        
        }

        public ImpuestosE InsertarImpuestos(ImpuestosE impuestos)
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_InsertarImpuestos", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@numVerPlanCuentas", SqlDbType.VarChar, 3).Value = impuestos.numVerPlanCuentas;
                    oComando.Parameters.Add("@codCuenta", SqlDbType.VarChar, 20).Value = impuestos.codCuenta;
                    oComando.Parameters.Add("@desImpuesto", SqlDbType.VarChar, 50).Value = impuestos.desImpuesto;
                    oComando.Parameters.Add("@desAbreviatura", SqlDbType.VarChar, 10).Value = impuestos.desAbreviatura;
                    oComando.Parameters.Add("@UsuarioRegistro", SqlDbType.VarChar, 20).Value = impuestos.UsuarioRegistro;

                    oConexion.Open();
                    impuestos.idImpuesto = Int32.Parse(oComando.ExecuteScalar().ToString());
                }
            }

            return impuestos;
        }
        
        public ImpuestosE ActualizarImpuestos(ImpuestosE impuestos)
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ActualizarImpuestos", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idImpuesto", SqlDbType.Int).Value = impuestos.idImpuesto;
					oComando.Parameters.Add("@numVerPlanCuentas", SqlDbType.VarChar, 3).Value = impuestos.numVerPlanCuentas;
					oComando.Parameters.Add("@codCuenta", SqlDbType.VarChar, 20).Value = impuestos.codCuenta;
					oComando.Parameters.Add("@desImpuesto", SqlDbType.VarChar, 50).Value = impuestos.desImpuesto;
					oComando.Parameters.Add("@desAbreviatura", SqlDbType.VarChar, 10).Value = impuestos.desAbreviatura;
					oComando.Parameters.Add("@UsuarioModificacion", SqlDbType.VarChar, 20).Value = impuestos.UsuarioModificacion;

                    oConexion.Open();
                    oComando.ExecuteNonQuery();
                }
            }

            return impuestos;
        }

        public Int32 EliminarImpuestos(Int32 idImpuesto)
        {
            Int32 resp = 0;
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_EliminarImpuestos", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idImpuesto", SqlDbType.Int).Value = idImpuesto;

                    oConexion.Open();
                    resp = oComando.ExecuteNonQuery();
                }
            }

            return resp;
        }

        public List<ImpuestosE> ListarImpuestos()
        {
           List<ImpuestosE> listaEntidad = new List<ImpuestosE>();
           ImpuestosE entidad = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ListarImpuestos", oConexion))
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
        
        public ImpuestosE ObtenerImpuestos(Int32 idImpuesto)
        {        
            ImpuestosE impuestos = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ObtenerImpuestos", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idImpuesto", SqlDbType.Int).Value = idImpuesto;
                    
                    oConexion.Open();
                    
                    using (SqlDataReader oReader = oComando.ExecuteReader())
                    {
                        while (oReader.Read())
                        {
                            impuestos = LlenarEntidad(oReader);
                        }
                    }
                }
            }

            return impuestos;
        }

    }
}