using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

using Entidades.Generales;
using AccesoDatos.Util;

namespace AccesoDatos.Generales
{
    public class ImpuestosPeriodoAD : DbConection
    {
        
        public ImpuestosPeriodoE LlenarEntidad(IDataReader oReader)
        {
            ImpuestosPeriodoE impuestosperiodo = new ImpuestosPeriodoE();
            
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idImpuesto'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				impuestosperiodo.idImpuesto = oReader["idImpuesto"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idImpuesto"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Item'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				impuestosperiodo.Item = oReader["Item"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["Item"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='fecInicio'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				impuestosperiodo.fecInicio = oReader["fecInicio"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["fecInicio"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='fecFin'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				impuestosperiodo.fecFin = oReader["fecFin"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["fecFin"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Porcentaje'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				impuestosperiodo.Porcentaje = oReader["Porcentaje"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["Porcentaje"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='UsuarioRegistro'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				impuestosperiodo.UsuarioRegistro = oReader["UsuarioRegistro"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["UsuarioRegistro"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='FechaRegistro'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				impuestosperiodo.FechaRegistro = oReader["FechaRegistro"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["FechaRegistro"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='UsuarioModificacion'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				impuestosperiodo.UsuarioModificacion = oReader["UsuarioModificacion"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["UsuarioModificacion"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='FechaModificacion'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				impuestosperiodo.FechaModificacion = oReader["FechaModificacion"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["FechaModificacion"]);
			
            //Extensiones
            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='codCuenta'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                impuestosperiodo.codCuenta = oReader["codCuenta"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["codCuenta"]);

            return  impuestosperiodo;        
        }

        public ImpuestosPeriodoE InsertarImpuestosPeriodo(ImpuestosPeriodoE impuestosperiodo)
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_InsertarImpuestosPeriodo", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idImpuesto", SqlDbType.Int).Value = impuestosperiodo.idImpuesto;
					oComando.Parameters.Add("@Item", SqlDbType.Int).Value = impuestosperiodo.Item;
					oComando.Parameters.Add("@fecInicio", SqlDbType.SmallDateTime).Value = impuestosperiodo.fecInicio;
					oComando.Parameters.Add("@fecFin", SqlDbType.SmallDateTime).Value = impuestosperiodo.fecFin;
					oComando.Parameters.Add("@Porcentaje", SqlDbType.Decimal).Value = impuestosperiodo.Porcentaje;
					oComando.Parameters.Add("@UsuarioRegistro", SqlDbType.VarChar, 20).Value = impuestosperiodo.UsuarioRegistro;

                    oConexion.Open();
                    oComando.ExecuteNonQuery();
                }
            }

            return impuestosperiodo;
        }
        
        public ImpuestosPeriodoE ActualizarImpuestosPeriodo(ImpuestosPeriodoE impuestosperiodo)
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ActualizarImpuestosPeriodo", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idImpuesto", SqlDbType.Int).Value = impuestosperiodo.idImpuesto;
					oComando.Parameters.Add("@Item", SqlDbType.Int).Value = impuestosperiodo.Item;
					oComando.Parameters.Add("@fecInicio", SqlDbType.SmallDateTime).Value = impuestosperiodo.fecInicio;
					oComando.Parameters.Add("@fecFin", SqlDbType.SmallDateTime).Value = impuestosperiodo.fecFin;
					oComando.Parameters.Add("@Porcentaje", SqlDbType.Decimal).Value = impuestosperiodo.Porcentaje;
					oComando.Parameters.Add("@UsuarioModificacion", SqlDbType.VarChar, 20).Value = impuestosperiodo.UsuarioModificacion;

                    oConexion.Open();
                    oComando.ExecuteNonQuery();
                }
            }

            return impuestosperiodo;
        }

        public Int32 EliminarImpuestosPeriodo(Int32 idImpuesto)
        {
            Int32 resp = 0;
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_EliminarImpuestosPeriodo", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idImpuesto", SqlDbType.Int).Value = idImpuesto;

                    oConexion.Open();
                    resp = oComando.ExecuteNonQuery();
                }
            }

            return resp;
        }

        public List<ImpuestosPeriodoE> ListarImpuestosPeriodo()
        {
           List<ImpuestosPeriodoE> listaEntidad = new List<ImpuestosPeriodoE>();
           ImpuestosPeriodoE entidad = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ListarImpuestosPeriodo", oConexion))
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
        
        public ImpuestosPeriodoE ObtenerImpuestosPeriodo(Int32 idImpuesto, Int32 Item)
        {        
            ImpuestosPeriodoE impuestosperiodo = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ObtenerImpuestosPeriodo", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idImpuesto", SqlDbType.Int).Value = idImpuesto;
					oComando.Parameters.Add("@Item", SqlDbType.Int).Value = Item;
                    
                    oConexion.Open();
                    
                    using (SqlDataReader oReader = oComando.ExecuteReader())
                    {
                        while (oReader.Read())
                        {
                            impuestosperiodo = LlenarEntidad(oReader);
                        }
                    }
                }
            }

            return impuestosperiodo;
        }

        public ImpuestosPeriodoE ObtenerPorcentajeImpuesto(Int32 idImpuesto, DateTime Fecha)
        {
            ImpuestosPeriodoE impuestosperiodo = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ObtenerPorcentajeImpuesto", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idImpuesto", SqlDbType.Int).Value = idImpuesto;
                    oComando.Parameters.Add("@Fecha", SqlDbType.SmallDateTime).Value = Fecha;

                    oConexion.Open();

                    using (SqlDataReader oReader = oComando.ExecuteReader())
                    {
                        while (oReader.Read())
                        {
                            impuestosperiodo = LlenarEntidad(oReader);
                        }
                    }
                }
            }

            return impuestosperiodo;
        }

        public List<ImpuestosPeriodoE> ListarImpuestosPeriodoPorIdImpuesto(Int32 idImpuesto)
        {
            List<ImpuestosPeriodoE> listaEntidad = new List<ImpuestosPeriodoE>();
            ImpuestosPeriodoE entidad = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ListarImpuestosPeriodoPorIdImpuesto", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idImpuesto", SqlDbType.Int).Value = idImpuesto;

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

        public List<ImpuestosPeriodoE> ListarPorcentajeImpuesto(DateTime Fecha)
        {
            List<ImpuestosPeriodoE> listaEntidad = new List<ImpuestosPeriodoE>();
            ImpuestosPeriodoE entidad = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ListarPorcentajeImpuesto", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@Fecha", SqlDbType.SmallDateTime).Value = Fecha;

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