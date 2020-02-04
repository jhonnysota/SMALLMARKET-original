using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

using Entidades.Generales;
using AccesoDatos.Util;

namespace AccesoDatos.Generales
{
    public class UsuarioImpresorasAD : DbConection
    {

        public UsuarioImpresorasE LlenarEntidad(IDataReader oReader)
        {
            UsuarioImpresorasE usuarioimpresoras = new UsuarioImpresorasE();
            
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idImpresora'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				usuarioimpresoras.idImpresora = oReader["idImpresora"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idImpresora"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idPersona'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				usuarioimpresoras.idPersona = oReader["idPersona"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idPersona"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Descripcion'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				usuarioimpresoras.Descripcion = oReader["Descripcion"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["Descripcion"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='PorDefecto'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				usuarioimpresoras.PorDefecto = oReader["PorDefecto"] == DBNull.Value ? false : Convert.ToBoolean(oReader["PorDefecto"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='EsMatricial'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                usuarioimpresoras.EsMatricial = oReader["EsMatricial"] == DBNull.Value ? false : Convert.ToBoolean(oReader["EsMatricial"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='ParaTicket'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                usuarioimpresoras.ParaTicket = oReader["ParaTicket"] == DBNull.Value ? false : Convert.ToBoolean(oReader["ParaTicket"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='ParaBarras'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                usuarioimpresoras.ParaBarras = oReader["ParaBarras"] == DBNull.Value ? false : Convert.ToBoolean(oReader["ParaBarras"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='UsuarioRegistro'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				usuarioimpresoras.UsuarioRegistro = oReader["UsuarioRegistro"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["UsuarioRegistro"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='FechaRegistro'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				usuarioimpresoras.FechaRegistro = oReader["FechaRegistro"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["FechaRegistro"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='UsuarioModificacion'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				usuarioimpresoras.UsuarioModificacion = oReader["UsuarioModificacion"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["UsuarioModificacion"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='FechaModificacion'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				usuarioimpresoras.FechaModificacion = oReader["FechaModificacion"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["FechaModificacion"]);

            //Extensiones
            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='AnchoEtiqueta'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                usuarioimpresoras.AnchoEtiqueta = oReader["AnchoEtiqueta"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["AnchoEtiqueta"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='AltoEtiqueta'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                usuarioimpresoras.AltoEtiqueta = oReader["AltoEtiqueta"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["AltoEtiqueta"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='cantEtiqueta'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                usuarioimpresoras.cantEtiqueta = oReader["cantEtiqueta"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["cantEtiqueta"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Gap'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                usuarioimpresoras.Gap = oReader["Gap"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["Gap"]);

            return  usuarioimpresoras;
        }

        public UsuarioImpresorasE InsertarUsuarioImpresoras(UsuarioImpresorasE usuarioimpresoras)
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_InsertarUsuarioImpresoras", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idPersona", SqlDbType.Int).Value = usuarioimpresoras.idPersona;
					oComando.Parameters.Add("@Descripcion", SqlDbType.VarChar, 100).Value = usuarioimpresoras.Descripcion;
					oComando.Parameters.Add("@PorDefecto", SqlDbType.Bit).Value = usuarioimpresoras.PorDefecto;
                    oComando.Parameters.Add("@EsMatricial", SqlDbType.Bit).Value = usuarioimpresoras.EsMatricial;
                    oComando.Parameters.Add("@ParaTicket", SqlDbType.Bit).Value = usuarioimpresoras.ParaTicket;
                    oComando.Parameters.Add("@ParaBarras", SqlDbType.Bit).Value = usuarioimpresoras.ParaBarras;
                    oComando.Parameters.Add("@UsuarioRegistro", SqlDbType.VarChar, 20).Value = usuarioimpresoras.UsuarioRegistro;

                    oConexion.Open();
                    usuarioimpresoras.idImpresora = Int32.Parse(oComando.ExecuteScalar().ToString());
                }
            }

            return usuarioimpresoras;
        }
        
        public UsuarioImpresorasE ActualizarUsuarioImpresoras(UsuarioImpresorasE usuarioimpresoras)
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ActualizarUsuarioImpresoras", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idImpresora", SqlDbType.Int).Value = usuarioimpresoras.idImpresora;
					oComando.Parameters.Add("@idPersona", SqlDbType.Int).Value = usuarioimpresoras.idPersona;
					oComando.Parameters.Add("@Descripcion", SqlDbType.VarChar, 100).Value = usuarioimpresoras.Descripcion;
					oComando.Parameters.Add("@PorDefecto", SqlDbType.Bit).Value = usuarioimpresoras.PorDefecto;
                    oComando.Parameters.Add("@EsMatricial", SqlDbType.Bit).Value = usuarioimpresoras.EsMatricial;
                    oComando.Parameters.Add("@ParaTicket", SqlDbType.Bit).Value = usuarioimpresoras.ParaTicket;
                    oComando.Parameters.Add("@ParaBarras", SqlDbType.Bit).Value = usuarioimpresoras.ParaBarras;
                    oComando.Parameters.Add("@UsuarioModificacion", SqlDbType.VarChar, 20).Value = usuarioimpresoras.UsuarioModificacion;

                    oConexion.Open();
                    oComando.ExecuteNonQuery();
                }
            }

            return usuarioimpresoras;
        }        

        public int EliminarUsuarioImpresoras(Int32 idImpresora, Int32 idPersona)
        {
            int resp = 0;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_EliminarUsuarioImpresoras", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idImpresora", SqlDbType.Int).Value = idImpresora;
                    oComando.Parameters.Add("@idPersona", SqlDbType.Int).Value = idPersona;

                    oConexion.Open();
                    resp = oComando.ExecuteNonQuery();
                }
            }

            return resp;
        }

        public List<UsuarioImpresorasE> ListarUsuarioImpresoras(Int32 idPersona)
        {
            List<UsuarioImpresorasE> listaEntidad = new List<UsuarioImpresorasE>();
            UsuarioImpresorasE entidad = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ListarUsuarioImpresoras", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idPersona", SqlDbType.Int).Value = idPersona;

                    oConexion.Open();
                    
                    using (SqlDataReader oReader = oComando.ExecuteReader())
                    {
                        int Corre = 0;

                        while (oReader.Read())
                        {
                            Corre++;
                            entidad = LlenarEntidad(oReader);
                            entidad.Correlativo = Corre;
                            listaEntidad.Add(entidad);
                        }
                    }
                }
            }

            return listaEntidad;
        }
        
        public UsuarioImpresorasE ObtenerUsuarioImpresoras(Int32 idImpresora, Int32 idPersona)
        {        
            UsuarioImpresorasE usuarioimpresoras = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ObtenerUsuarioImpresoras", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idImpresora", SqlDbType.Int).Value = idImpresora;
                    oComando.Parameters.Add("@idPersona", SqlDbType.Int).Value = idPersona;

                    oConexion.Open();
                    
                    using (SqlDataReader oReader = oComando.ExecuteReader())
                    {
                        while (oReader.Read())
                        {
                            usuarioimpresoras = LlenarEntidad(oReader);
                        }
                    }
                }
            }

            return usuarioimpresoras;
        }

        public List<UsuarioImpresorasE> ListarUsuarioImpresorasBarras(Int32 idPersona)
        {
            List<UsuarioImpresorasE> listaEntidad = new List<UsuarioImpresorasE>();
            UsuarioImpresorasE entidad = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ListarUsuarioImpresorasBarras", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idPersona", SqlDbType.Int).Value = idPersona;

                    oConexion.Open();

                    using (SqlDataReader oReader = oComando.ExecuteReader())
                    {
                        int Corre = 0;

                        while (oReader.Read())
                        {
                            Corre++;
                            entidad = LlenarEntidad(oReader);
                            entidad.Correlativo = Corre;
                            listaEntidad.Add(entidad);
                        }
                    }
                }
            }

            return listaEntidad;
        }

    }
}