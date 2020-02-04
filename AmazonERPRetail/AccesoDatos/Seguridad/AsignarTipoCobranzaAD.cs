using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

using Entidades.Seguridad;
using AccesoDatos.Util;

namespace AccesoDatos.Seguridad
{
    public class AsignarTipoCobranzaAD : DbConection
    {

        public AsignarTipoCobranzaE LlenarEntidad(IDataReader oReader)
        {
            AsignarTipoCobranzaE asignartipocobranza = new AsignarTipoCobranzaE();
            
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idEmpresa'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				asignartipocobranza.idEmpresa = oReader["idEmpresa"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idEmpresa"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idLocal'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				asignartipocobranza.idLocal = oReader["idLocal"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idLocal"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idUsuario'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				asignartipocobranza.idUsuario = oReader["idUsuario"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idUsuario"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idTipoPlanilla'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				asignartipocobranza.idTipoPlanilla = oReader["idTipoPlanilla"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idTipoPlanilla"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='AbrirPlanilla'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				asignartipocobranza.AbrirPlanilla = oReader["AbrirPlanilla"] == DBNull.Value ? false : Convert.ToBoolean(oReader["AbrirPlanilla"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='CerrarPlanilla'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				asignartipocobranza.CerrarPlanilla = oReader["CerrarPlanilla"] == DBNull.Value ? false : Convert.ToBoolean(oReader["CerrarPlanilla"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='UsuarioRegistro'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				asignartipocobranza.UsuarioRegistro = oReader["UsuarioRegistro"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["UsuarioRegistro"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='FechaRegistro'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				asignartipocobranza.FechaRegistro = oReader["FechaRegistro"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["FechaRegistro"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='UsuarioModificacion'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				asignartipocobranza.UsuarioModificacion = oReader["UsuarioModificacion"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["UsuarioModificacion"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='FechaModificacion'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				asignartipocobranza.FechaModificacion = oReader["FechaModificacion"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["FechaModificacion"]);

            //Extensiones
            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='desTipoPlanilla'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                asignartipocobranza.desTipoPlanilla = oReader["desTipoPlanilla"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["desTipoPlanilla"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='nomEmpresa'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                asignartipocobranza.nomEmpresa = oReader["nomEmpresa"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["nomEmpresa"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='nomLocal'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                asignartipocobranza.nomLocal = oReader["nomLocal"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["nomLocal"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='nomUsuario'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                asignartipocobranza.nomUsuario = oReader["nomUsuario"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["nomUsuario"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='NemoTecnico'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                asignartipocobranza.NemoTecnico = oReader["NemoTecnico"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["NemoTecnico"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idComprobante'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                asignartipocobranza.idComprobante = oReader["idComprobante"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["idComprobante"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='numFile'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                asignartipocobranza.numFile = oReader["numFile"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["numFile"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='TipoCobro'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                asignartipocobranza.TipoCobro = oReader["TipoCobro"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["TipoCobro"]);

            return  asignartipocobranza;        
        }

        public AsignarTipoCobranzaE InsertarAsignarTipoCobranza(AsignarTipoCobranzaE asignartipocobranza)
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_InsertarAsignarTipoCobranza", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = asignartipocobranza.idEmpresa;
					oComando.Parameters.Add("@idLocal", SqlDbType.Int).Value = asignartipocobranza.idLocal;
					oComando.Parameters.Add("@idUsuario", SqlDbType.Int).Value = asignartipocobranza.idUsuario;
					oComando.Parameters.Add("@idTipoPlanilla", SqlDbType.Int).Value = asignartipocobranza.idTipoPlanilla;
					oComando.Parameters.Add("@AbrirPlanilla", SqlDbType.Bit).Value = asignartipocobranza.AbrirPlanilla;
					oComando.Parameters.Add("@CerrarPlanilla", SqlDbType.Bit).Value = asignartipocobranza.CerrarPlanilla;
					oComando.Parameters.Add("@UsuarioRegistro", SqlDbType.VarChar, 20).Value = asignartipocobranza.UsuarioRegistro;

                    oConexion.Open();
                    oComando.ExecuteNonQuery();
                }
            }

            return asignartipocobranza;
        }
        
        public AsignarTipoCobranzaE ActualizarAsignarTipoCobranza(AsignarTipoCobranzaE asignartipocobranza)
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ActualizarAsignarTipoCobranza", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = asignartipocobranza.idEmpresa;
					oComando.Parameters.Add("@idLocal", SqlDbType.Int).Value = asignartipocobranza.idLocal;
					oComando.Parameters.Add("@idUsuario", SqlDbType.Int).Value = asignartipocobranza.idUsuario;
					oComando.Parameters.Add("@idTipoPlanilla", SqlDbType.Int).Value = asignartipocobranza.idTipoPlanilla;
					oComando.Parameters.Add("@AbrirPlanilla", SqlDbType.Bit).Value = asignartipocobranza.AbrirPlanilla;
					oComando.Parameters.Add("@CerrarPlanilla", SqlDbType.Bit).Value = asignartipocobranza.CerrarPlanilla;
					oComando.Parameters.Add("@UsuarioModificacion", SqlDbType.VarChar, 20).Value = asignartipocobranza.UsuarioModificacion;
                    oComando.Parameters.Add("@idTipoPlanillaAnte", SqlDbType.Int).Value = asignartipocobranza.idTipoPlanillaAnte;

                    oConexion.Open();
                    oComando.ExecuteNonQuery();
                }
            }

            return asignartipocobranza;
        }        

        public int EliminarAsignarTipoCobranza(Int32 idEmpresa, Int32 idLocal, Int32 idUsuario, Int32 idTipoPlanilla)
        {
            int resp = 0;
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_EliminarAsignarTipoCobranza", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
					oComando.Parameters.Add("@idLocal", SqlDbType.Int).Value = idLocal;
					oComando.Parameters.Add("@idUsuario", SqlDbType.Int).Value = idUsuario;
					oComando.Parameters.Add("@idTipoPlanilla", SqlDbType.Int).Value = idTipoPlanilla;

                    oConexion.Open();
                    resp = oComando.ExecuteNonQuery();
                }
            }

            return resp;
        }

        public List<AsignarTipoCobranzaE> ListarTipCobranzaPorUsuario(Int32 idUsuario)
        {
            List<AsignarTipoCobranzaE> listaEntidad = new List<AsignarTipoCobranzaE>();

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ListarTipCobranzaPorUsuario", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idUsuario", SqlDbType.Int).Value = idUsuario;

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
        
        public AsignarTipoCobranzaE ObtenerAsignarTipoCobranza(Int32 idEmpresa, Int32 idLocal, Int32 idUsuario, Int32 idTipoPlanilla)
        {        
            AsignarTipoCobranzaE asignartipocobranza = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ObtenerAsignarTipoCobranza", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
					oComando.Parameters.Add("@idLocal", SqlDbType.Int).Value = idLocal;
					oComando.Parameters.Add("@idUsuario", SqlDbType.Int).Value = idUsuario;
					oComando.Parameters.Add("@idTipoPlanilla", SqlDbType.Int).Value = idTipoPlanilla;

                    oConexion.Open();
                    
                    using (SqlDataReader oReader = oComando.ExecuteReader())
                    {
                        while (oReader.Read())
                        {
                            asignartipocobranza = LlenarEntidad(oReader);
                        }
                    }
                }
            }

            return asignartipocobranza;
        }

        public List<AsignarTipoCobranzaE> ListarTipoCobranza(Int32 idEmpresa, Int32 idLocal, Int32 idUsuario)
        {
            List<AsignarTipoCobranzaE> listaEntidad = new List<AsignarTipoCobranzaE>();

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ListarTipoCobranza", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@idLocal", SqlDbType.Int).Value = idLocal;
                    oComando.Parameters.Add("@idUsuario", SqlDbType.Int).Value = idUsuario;

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