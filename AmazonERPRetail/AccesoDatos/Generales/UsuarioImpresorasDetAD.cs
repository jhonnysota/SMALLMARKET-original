using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

using Entidades.Generales;
using AccesoDatos.Util;

namespace AccesoDatos.Generales
{
    public class UsuarioImpresorasDetAD : DbConection
    {

        public UsuarioImpresorasDetE LlenarEntidad(IDataReader oReader)
        {
            UsuarioImpresorasDetE usuarioimpresorasdet = new UsuarioImpresorasDetE();
            
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idImpresora'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				usuarioimpresorasdet.idImpresora = oReader["idImpresora"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idImpresora"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Item'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				usuarioimpresorasdet.Item = oReader["Item"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["Item"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='PorDefecto'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				usuarioimpresorasdet.PorDefecto = oReader["PorDefecto"] == DBNull.Value ? false : Convert.ToBoolean(oReader["PorDefecto"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='AnchoEtiqueta'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				usuarioimpresorasdet.AnchoEtiqueta = oReader["AnchoEtiqueta"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["AnchoEtiqueta"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='AltoEtiqueta'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				usuarioimpresorasdet.AltoEtiqueta = oReader["AltoEtiqueta"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["AltoEtiqueta"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='cantEtiqueta'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				usuarioimpresorasdet.cantEtiqueta = oReader["cantEtiqueta"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["cantEtiqueta"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Gap'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				usuarioimpresorasdet.Gap = oReader["Gap"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["Gap"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='UsuarioRegistro'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				usuarioimpresorasdet.UsuarioRegistro = oReader["UsuarioRegistro"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["UsuarioRegistro"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='FechaRegistro'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				usuarioimpresorasdet.FechaRegistro = oReader["FechaRegistro"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["FechaRegistro"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='UsuarioModificacion'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				usuarioimpresorasdet.UsuarioModificacion = oReader["UsuarioModificacion"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["UsuarioModificacion"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='FechaModificacion'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				usuarioimpresorasdet.FechaModificacion = oReader["FechaModificacion"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["FechaModificacion"]);

            return  usuarioimpresorasdet;        
        }

        public UsuarioImpresorasDetE InsertarUsuarioImpresorasDet(UsuarioImpresorasDetE usuarioimpresorasdet)
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_InsertarUsuarioImpresorasDet", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idImpresora", SqlDbType.Int).Value = usuarioimpresorasdet.idImpresora;
					oComando.Parameters.Add("@Item", SqlDbType.Int).Value = usuarioimpresorasdet.Item;
					oComando.Parameters.Add("@PorDefecto", SqlDbType.Bit).Value = usuarioimpresorasdet.PorDefecto;
					oComando.Parameters.Add("@AnchoEtiqueta", SqlDbType.Decimal).Value = usuarioimpresorasdet.AnchoEtiqueta;
					oComando.Parameters.Add("@AltoEtiqueta", SqlDbType.Decimal).Value = usuarioimpresorasdet.AltoEtiqueta;
					oComando.Parameters.Add("@cantEtiqueta", SqlDbType.Int).Value = usuarioimpresorasdet.cantEtiqueta;
					oComando.Parameters.Add("@Gap", SqlDbType.Int).Value = usuarioimpresorasdet.Gap;
					oComando.Parameters.Add("@UsuarioRegistro", SqlDbType.VarChar, 20).Value = usuarioimpresorasdet.UsuarioRegistro;

                    oConexion.Open();
                    oComando.ExecuteNonQuery();
                }
            }

            return usuarioimpresorasdet;
        }
        
        public UsuarioImpresorasDetE ActualizarUsuarioImpresorasDet(UsuarioImpresorasDetE usuarioimpresorasdet)
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ActualizarUsuarioImpresorasDet", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idImpresora", SqlDbType.Int).Value = usuarioimpresorasdet.idImpresora;
					oComando.Parameters.Add("@Item", SqlDbType.Int).Value = usuarioimpresorasdet.Item;
					oComando.Parameters.Add("@PorDefecto", SqlDbType.Bit).Value = usuarioimpresorasdet.PorDefecto;
					oComando.Parameters.Add("@AnchoEtiqueta", SqlDbType.Decimal).Value = usuarioimpresorasdet.AnchoEtiqueta;
					oComando.Parameters.Add("@AltoEtiqueta", SqlDbType.Decimal).Value = usuarioimpresorasdet.AltoEtiqueta;
					oComando.Parameters.Add("@cantEtiqueta", SqlDbType.Int).Value = usuarioimpresorasdet.cantEtiqueta;
					oComando.Parameters.Add("@Gap", SqlDbType.Int).Value = usuarioimpresorasdet.Gap;
					oComando.Parameters.Add("@UsuarioModificacion", SqlDbType.VarChar, 20).Value = usuarioimpresorasdet.UsuarioModificacion;

                    oConexion.Open();
                    oComando.ExecuteNonQuery();
                }
            }

            return usuarioimpresorasdet;
        }        

        public int EliminarUsuarioImpresorasDet(Int32 idImpresora, Int32 Item)
        {
            int resp = 0;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_EliminarUsuarioImpresorasDet", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idImpresora", SqlDbType.Int).Value = idImpresora;
					oComando.Parameters.Add("@Item", SqlDbType.Int).Value = Item;

                    oConexion.Open();
                    resp = oComando.ExecuteNonQuery();
                }
            }

            return resp;
        }

        public List<UsuarioImpresorasDetE> ListarUsuarioImpresorasDet(Int32 idImpresora)
        {
            List<UsuarioImpresorasDetE> listaEntidad = new List<UsuarioImpresorasDetE>();

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ListarUsuarioImpresorasDet", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idImpresora", SqlDbType.Int).Value = idImpresora;

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
        
        public UsuarioImpresorasDetE ObtenerUsuarioImpresorasDet(Int32 idImpresora, Int32 Item)
        {        
            UsuarioImpresorasDetE usuarioimpresorasdet = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ObtenerUsuarioImpresorasDet", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idImpresora", SqlDbType.Int).Value = idImpresora;
					oComando.Parameters.Add("@Item", SqlDbType.Int).Value = Item;

                    oConexion.Open();
                    
                    using (SqlDataReader oReader = oComando.ExecuteReader())
                    {
                        while (oReader.Read())
                        {
                            usuarioimpresorasdet = LlenarEntidad(oReader);
                        }
                    }
                }
            }

            return usuarioimpresorasdet;
        }

    }
}