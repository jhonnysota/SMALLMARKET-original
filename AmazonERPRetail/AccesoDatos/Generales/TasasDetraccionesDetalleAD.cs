using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

using Entidades.Generales;
using AccesoDatos.Util;

namespace AccesoDatos.Generales
{
    public class TasasDetraccionesDetalleAD : DbConection
    {

        public TasasDetraccionesDetalleE LlenarEntidad(IDataReader oReader)
        {
            TasasDetraccionesDetalleE tasasdetraccionesdetalle = new TasasDetraccionesDetalleE();
            
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idTipoDetraccion'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				tasasdetraccionesdetalle.idTipoDetraccion = oReader["idTipoDetraccion"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["idTipoDetraccion"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='item'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				tasasdetraccionesdetalle.item = oReader["item"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["item"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='fecInicio'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                tasasdetraccionesdetalle.fecInicio = oReader["fecInicio"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["fecInicio"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='fecFin'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                tasasdetraccionesdetalle.fecFin = oReader["fecFin"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["fecFin"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Porcentaje'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                tasasdetraccionesdetalle.Porcentaje = oReader["Porcentaje"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["Porcentaje"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='UsuarioRegistro'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				tasasdetraccionesdetalle.UsuarioRegistro = oReader["UsuarioRegistro"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["UsuarioRegistro"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='FechaRegistro'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				tasasdetraccionesdetalle.FechaRegistro = oReader["FechaRegistro"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["FechaRegistro"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='UsuarioModificacion'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				tasasdetraccionesdetalle.UsuarioModificacion = oReader["UsuarioModificacion"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["UsuarioModificacion"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='FechaModificacion'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				tasasdetraccionesdetalle.FechaModificacion = oReader["FechaModificacion"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["FechaModificacion"]);

            //Extensiones
            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Nombre'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                tasasdetraccionesdetalle.Nombre = oReader["Nombre"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["Nombre"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Excluido'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                tasasdetraccionesdetalle.Excluido = oReader["Excluido"] == DBNull.Value ? false : Convert.ToBoolean(oReader["Excluido"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='NombreTemp'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                tasasdetraccionesdetalle.NombreTemp = oReader["NombreTemp"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["NombreTemp"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='BaseAfecta'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                tasasdetraccionesdetalle.BaseAfecta = oReader["BaseAfecta"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["BaseAfecta"]);

            return  tasasdetraccionesdetalle;        
        }

        public TasasDetraccionesDetalleE InsertarTasasDetraccionesDetalle(TasasDetraccionesDetalleE tasasdetraccionesdetalle)
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_InsertarTasasDetraccionesDetalle", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idTipoDetraccion", SqlDbType.VarChar, 3).Value = tasasdetraccionesdetalle.idTipoDetraccion;
                    oComando.Parameters.Add("@fecInicio", SqlDbType.SmallDateTime).Value = tasasdetraccionesdetalle.fecInicio;
                    oComando.Parameters.Add("@fecFin", SqlDbType.SmallDateTime).Value = tasasdetraccionesdetalle.fecFin;
                    oComando.Parameters.Add("@Porcentaje", SqlDbType.Decimal).Value = tasasdetraccionesdetalle.Porcentaje;
                    oComando.Parameters.Add("@UsuarioRegistro", SqlDbType.VarChar, 20).Value = tasasdetraccionesdetalle.UsuarioRegistro;

                    oConexion.Open();
                    tasasdetraccionesdetalle.item = Int32.Parse(oComando.ExecuteScalar().ToString());
                }
            }

            return tasasdetraccionesdetalle;
        }
        
        public TasasDetraccionesDetalleE ActualizarTasasDetraccionesDetalle(TasasDetraccionesDetalleE tasasdetraccionesdetalle)
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ActualizarTasasDetraccionesDetalle", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idTipoDetraccion", SqlDbType.VarChar, 3).Value = tasasdetraccionesdetalle.idTipoDetraccion;
					oComando.Parameters.Add("@item", SqlDbType.Int).Value = tasasdetraccionesdetalle.item;
					oComando.Parameters.Add("@fecInicio", SqlDbType.SmallDateTime).Value = tasasdetraccionesdetalle.fecInicio;
					oComando.Parameters.Add("@fecFin", SqlDbType.SmallDateTime).Value = tasasdetraccionesdetalle.fecFin;
					oComando.Parameters.Add("@Porcentaje", SqlDbType.Decimal).Value = tasasdetraccionesdetalle.Porcentaje;
					oComando.Parameters.Add("@UsuarioModificacion", SqlDbType.VarChar, 20).Value = tasasdetraccionesdetalle.UsuarioModificacion;

                    oConexion.Open();
                    oComando.ExecuteNonQuery();
                }
            }

            return tasasdetraccionesdetalle;
        }        

        public int EliminarTasasDetraccionesDetalle(String idTipoDetraccion, Int32 item)
        {
            int resp = 0;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_EliminarTasasDetraccionesDetalle", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idTipoDetraccion", SqlDbType.VarChar, 3).Value = idTipoDetraccion;
					oComando.Parameters.Add("@item", SqlDbType.Int).Value = item;

                    oConexion.Open();
                    resp = oComando.ExecuteNonQuery();
                }
            }

            return resp;
        }

        public List<TasasDetraccionesDetalleE> ListarTasasDetraccionesDetalle(String idTipoDetraccion)
        {
            List<TasasDetraccionesDetalleE> listaEntidad = new List<TasasDetraccionesDetalleE>();

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ListarTasasDetraccionesDetalle", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idTipoDetraccion", SqlDbType.VarChar, 3).Value = idTipoDetraccion;

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
        
        public TasasDetraccionesDetalleE ObtenerTasasDetraccionesDetalle(String idTipoDetraccion, Int32 item)
        {        
            TasasDetraccionesDetalleE tasasdetraccionesdetalle = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ObtenerTasasDetraccionesDetalle", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;

                    oComando.Parameters.Add("@idTipoDetraccion", SqlDbType.VarChar, 3).Value = idTipoDetraccion;
					oComando.Parameters.Add("@item", SqlDbType.Int).Value = item;
                    oConexion.Open();
                    
                    using (SqlDataReader oReader = oComando.ExecuteReader())
                    {
                        while (oReader.Read())
                        {
                            tasasdetraccionesdetalle = LlenarEntidad(oReader);
                        }
                    }
                }
            }

            return tasasdetraccionesdetalle;
        }

        public List<TasasDetraccionesDetalleE> ListarDetraccionesDetActivas(DateTime fecDetraccion, String idTipoDetraccion = "%")
        {
            List<TasasDetraccionesDetalleE> listaEntidad = new List<TasasDetraccionesDetalleE>();

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ListarDetraccionesDetActivas", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@fecDetraccion", SqlDbType.SmallDateTime).Value = fecDetraccion;
                    oComando.Parameters.Add("@idTipoDetraccion", SqlDbType.VarChar, 3).Value = idTipoDetraccion;

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