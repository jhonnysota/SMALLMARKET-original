using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

using Entidades.Maestros;
using AccesoDatos.Util;

namespace AccesoDatos.Maestros
{
    public class ImpresionBarrasDetAD : DbConection
    {

        public ImpresionBarrasDetE LlenarEntidad(IDataReader oReader)
        {
            ImpresionBarrasDetE impresionbarrasdet = new ImpresionBarrasDetE();
            
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idImpresion'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				impresionbarrasdet.idImpresion = oReader["idImpresion"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idImpresion"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idArticulo'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				impresionbarrasdet.idArticulo = oReader["idArticulo"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idArticulo"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='UsuarioRegistro'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				impresionbarrasdet.UsuarioRegistro = oReader["UsuarioRegistro"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["UsuarioRegistro"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='FechaRegistro'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				impresionbarrasdet.FechaRegistro = oReader["FechaRegistro"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["FechaRegistro"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='UsuarioModficacion'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				impresionbarrasdet.UsuarioModficacion = oReader["UsuarioModficacion"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["UsuarioModficacion"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='FechaModificacion'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				impresionbarrasdet.FechaModificacion = oReader["FechaModificacion"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["FechaModificacion"]);

            //Extensiones
            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idArticulo'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                impresionbarrasdet.idArticuloAnte = oReader["idArticulo"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idArticulo"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='codArticulo'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                impresionbarrasdet.codArticulo = oReader["codArticulo"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["codArticulo"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='nomArticulo'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                impresionbarrasdet.nomArticulo = oReader["nomArticulo"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["nomArticulo"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='codSerie'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                impresionbarrasdet.codSerie = oReader["codSerie"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["codSerie"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='nomSerie'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                impresionbarrasdet.nomSerie = oReader["nomSerie"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["nomSerie"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idModelo'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                impresionbarrasdet.idModelo = oReader["idModelo"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idModelo"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='desModelo'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                impresionbarrasdet.desModelo = oReader["desModelo"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["desModelo"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='desColor'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                impresionbarrasdet.desColor = oReader["desColor"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["desColor"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='codBarras'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                impresionbarrasdet.codBarras = oReader["codBarras"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["codBarras"]);

            return  impresionbarrasdet;        
        }

        public ImpresionBarrasDetE InsertarImpresionBarrasDet(ImpresionBarrasDetE impresionbarrasdet)
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_InsertarImpresionBarrasDet", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idImpresion", SqlDbType.Int).Value = impresionbarrasdet.idImpresion;
					oComando.Parameters.Add("@idArticulo", SqlDbType.Int).Value = impresionbarrasdet.idArticulo;
					oComando.Parameters.Add("@UsuarioRegistro", SqlDbType.VarChar, 20).Value = impresionbarrasdet.UsuarioRegistro;

                    oConexion.Open();
                    oComando.ExecuteNonQuery();
                }
            }

            return impresionbarrasdet;
        }
        
        public ImpresionBarrasDetE ActualizarImpresionBarrasDet(ImpresionBarrasDetE impresionbarrasdet)
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ActualizarImpresionBarrasDet", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idImpresion", SqlDbType.Int).Value = impresionbarrasdet.idImpresion;
					oComando.Parameters.Add("@idArticulo", SqlDbType.Int).Value = impresionbarrasdet.idArticulo;
                    oComando.Parameters.Add("@idArticuloAnte", SqlDbType.Int).Value = impresionbarrasdet.idArticuloAnte;
                    oComando.Parameters.Add("@UsuarioModficacion", SqlDbType.VarChar, 20).Value = impresionbarrasdet.UsuarioModficacion;

                    oConexion.Open();
                    oComando.ExecuteNonQuery();
                }
            }

            return impresionbarrasdet;
        }        

        public int EliminarImpresionBarrasDet(Int32 idImpresion, Int32 idArticulo)
        {
            int resp = 0;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_EliminarImpresionBarrasDet", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idImpresion", SqlDbType.Int).Value = idImpresion;
					oComando.Parameters.Add("@idArticulo", SqlDbType.Int).Value = idArticulo;

                    oConexion.Open();
                    resp = oComando.ExecuteNonQuery();
                }
            }

            return resp;
        }

        public List<ImpresionBarrasDetE> ListarImpresionBarrasDet(Int32 idImpresion)
        {
            List<ImpresionBarrasDetE> listaEntidad = new List<ImpresionBarrasDetE>();

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ListarImpresionBarrasDet", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idImpresion", SqlDbType.Int).Value = idImpresion;

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
        
        public ImpresionBarrasDetE ObtenerImpresionBarrasDet(Int32 idImpresion, Int32 idArticulo)
        {        
            ImpresionBarrasDetE impresionbarrasdet = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ObtenerImpresionBarrasDet", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idImpresion", SqlDbType.Int).Value = idImpresion;
					oComando.Parameters.Add("@idArticulo", SqlDbType.Int).Value = idArticulo;

                    oConexion.Open();
                    
                    using (SqlDataReader oReader = oComando.ExecuteReader())
                    {
                        while (oReader.Read())
                        {
                            impresionbarrasdet = LlenarEntidad(oReader);
                        }
                    }
                }
            }

            return impresionbarrasdet;
        }

    }
}