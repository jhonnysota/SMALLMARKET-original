using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

using Entidades.Maestros;
using AccesoDatos.Util;

namespace AccesoDatos.Maestros
{
    public class ImpresionBarrasDetDetAD : DbConection
    {

        public ImpresionBarrasDetDetE LlenarEntidad(IDataReader oReader)
        {
            ImpresionBarrasDetDetE impresionbarrasdetdet = new ImpresionBarrasDetDetE();
            
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idImpresion'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				impresionbarrasdetdet.idImpresion = oReader["idImpresion"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idImpresion"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idArticulo'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				impresionbarrasdetdet.idArticulo = oReader["idArticulo"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idArticulo"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Item'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				impresionbarrasdetdet.Item = oReader["Item"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["Item"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Talla'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				impresionbarrasdetdet.Talla = oReader["Talla"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["Talla"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='codBarras'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				impresionbarrasdetdet.codBarras = oReader["codBarras"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["codBarras"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Cantidad'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                impresionbarrasdetdet.Cantidad = oReader["Cantidad"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["Cantidad"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='UsuarioRegistro'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				impresionbarrasdetdet.UsuarioRegistro = oReader["UsuarioRegistro"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["UsuarioRegistro"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='FechaRegistro'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				impresionbarrasdetdet.FechaRegistro = oReader["FechaRegistro"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["FechaRegistro"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='UsuarioModficacion'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				impresionbarrasdetdet.UsuarioModficacion = oReader["UsuarioModficacion"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["UsuarioModficacion"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='FechaModificacion'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				impresionbarrasdetdet.FechaModificacion = oReader["FechaModificacion"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["FechaModificacion"]);

            //Extensiones
            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='desModelo'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                impresionbarrasdetdet.desModelo = oReader["desModelo"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["desModelo"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='abrevMaterial'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                impresionbarrasdetdet.abrevMaterial = oReader["abrevMaterial"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["abrevMaterial"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='desColor'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                impresionbarrasdetdet.desColor = oReader["desColor"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["desColor"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='fecImpresion'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                impresionbarrasdetdet.fecImpresion = oReader["fecImpresion"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["fecImpresion"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='nomArticulo'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                impresionbarrasdetdet.nomArticulo = oReader["nomArticulo"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["nomArticulo"]);

            return  impresionbarrasdetdet;        
        }

        public ImpresionBarrasDetDetE InsertarImpresionBarrasDetDet(ImpresionBarrasDetDetE impresionbarrasdetdet)
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_InsertarImpresionBarrasDetDet", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idImpresion", SqlDbType.Int).Value = impresionbarrasdetdet.idImpresion;
					oComando.Parameters.Add("@idArticulo", SqlDbType.Int).Value = impresionbarrasdetdet.idArticulo;
					//oComando.Parameters.Add("@Item", SqlDbType.Int).Value = impresionbarrasdetdet.Item;
					oComando.Parameters.Add("@Talla", SqlDbType.Int).Value = impresionbarrasdetdet.Talla;
					oComando.Parameters.Add("@codBarras", SqlDbType.VarChar, 20).Value = impresionbarrasdetdet.codBarras;
                    oComando.Parameters.Add("@Cantidad", SqlDbType.Int).Value = impresionbarrasdetdet.Cantidad;
                    oComando.Parameters.Add("@UsuarioRegistro", SqlDbType.VarChar, 20).Value = impresionbarrasdetdet.UsuarioRegistro;

                    oConexion.Open();
                    oComando.ExecuteNonQuery();
                }
            }

            return impresionbarrasdetdet;
        }
        
        public ImpresionBarrasDetDetE ActualizarImpresionBarrasDetDet(ImpresionBarrasDetDetE impresionbarrasdetdet)
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ActualizarImpresionBarrasDetDet", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idImpresion", SqlDbType.Int).Value = impresionbarrasdetdet.idImpresion;
					oComando.Parameters.Add("@idArticulo", SqlDbType.Int).Value = impresionbarrasdetdet.idArticulo;
					oComando.Parameters.Add("@Item", SqlDbType.Int).Value = impresionbarrasdetdet.Item;
					oComando.Parameters.Add("@Talla", SqlDbType.Int).Value = impresionbarrasdetdet.Talla;
					oComando.Parameters.Add("@codBarras", SqlDbType.VarChar, 20).Value = impresionbarrasdetdet.codBarras;
                    oComando.Parameters.Add("@Cantidad", SqlDbType.Int).Value = impresionbarrasdetdet.Cantidad;
                    oComando.Parameters.Add("@UsuarioModficacion", SqlDbType.VarChar, 20).Value = impresionbarrasdetdet.UsuarioModficacion;

                    oConexion.Open();
                    oComando.ExecuteNonQuery();
                }
            }

            return impresionbarrasdetdet;
        }        

        public int EliminarImpresionBarrasDetDet(Int32 idImpresion, Int32 idArticulo, Int32 Item)
        {
            int resp = 0;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_EliminarImpresionBarrasDetDet", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idImpresion", SqlDbType.Int).Value = idImpresion;
					oComando.Parameters.Add("@idArticulo", SqlDbType.Int).Value = idArticulo;
					oComando.Parameters.Add("@Item", SqlDbType.Int).Value = Item;

                    oConexion.Open();
                    resp = oComando.ExecuteNonQuery();
                }
            }

            return resp;
        }

        public List<ImpresionBarrasDetDetE> ListarImpresionBarrasDetDet(Int32 idImpresion, Int32 idArticulo)
        {
            List<ImpresionBarrasDetDetE> listaEntidad = new List<ImpresionBarrasDetDetE>();

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ListarImpresionBarrasDetDet", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idImpresion", SqlDbType.Int).Value = idImpresion;
                    oComando.Parameters.Add("@idArticulo", SqlDbType.Int).Value = idArticulo;

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
        
        public ImpresionBarrasDetDetE ObtenerImpresionBarrasDetDet(Int32 idImpresion, Int32 idArticulo, Int32 Item)
        {        
            ImpresionBarrasDetDetE impresionbarrasdetdet = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ObtenerImpresionBarrasDetDet", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idImpresion", SqlDbType.Int).Value = idImpresion;
					oComando.Parameters.Add("@idArticulo", SqlDbType.Int).Value = idArticulo;
					oComando.Parameters.Add("@Item", SqlDbType.Int).Value = Item;

                    oConexion.Open();
                    
                    using (SqlDataReader oReader = oComando.ExecuteReader())
                    {
                        while (oReader.Read())
                        {
                            impresionbarrasdetdet = LlenarEntidad(oReader);
                        }
                    }
                }
            }

            return impresionbarrasdetdet;
        }

        public List<ImpresionBarrasDetDetE> ListarImpresionCodigoBarras(Int32 idImpresion)
        {
            List<ImpresionBarrasDetDetE> listaEntidad = new List<ImpresionBarrasDetDetE>();

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ListarImpresionCodigoBarras", oConexion))
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

        public ImpresionBarrasDetDetE ObtenerImpresionDetDetPorBarras(Int32 idEmpresa, String codBarras)
        {
            ImpresionBarrasDetDetE impresionbarrasdetdet = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ObtenerImpresionDetDetPorBarras", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@codBarras", SqlDbType.VarChar, 20).Value = codBarras;

                    oConexion.Open();

                    using (SqlDataReader oReader = oComando.ExecuteReader())
                    {
                        while (oReader.Read())
                        {
                            impresionbarrasdetdet = LlenarEntidad(oReader);
                        }
                    }
                }
            }

            return impresionbarrasdetdet;
        }

    }
}