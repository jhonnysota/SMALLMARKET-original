using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

using Entidades.Contabilidad;
using AccesoDatos.Util;

namespace AccesoDatos.Contabilidad
{
    public class ReciboHonorariosAD : DbConection
    {

        public ReciboHonorariosE LlenarEntidad(IDataReader oReader)
        {
            ReciboHonorariosE recibohonorarios = new ReciboHonorariosE();
            
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idEmpresa'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				recibohonorarios.idEmpresa = oReader["idEmpresa"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idEmpresa"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idLocal'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                recibohonorarios.idLocal = oReader["idLocal"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idLocal"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idReciboHonorarios'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				recibohonorarios.idReciboHonorarios = oReader["idReciboHonorarios"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idReciboHonorarios"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='AnioPeriodo'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				recibohonorarios.AnioPeriodo = oReader["AnioPeriodo"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["AnioPeriodo"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='MesPeriodo'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				recibohonorarios.MesPeriodo = oReader["MesPeriodo"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["MesPeriodo"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idPersona'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				recibohonorarios.idPersona = oReader["idPersona"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idPersona"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='impRecibo'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				recibohonorarios.impRecibo = oReader["impRecibo"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["impRecibo"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='impCuartaCat'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				recibohonorarios.impCuartaCat = oReader["impCuartaCat"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["impCuartaCat"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='impIES'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				recibohonorarios.impIES = oReader["impIES"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["impIES"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='EsCancelado'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                recibohonorarios.EsCancelado = oReader["EsCancelado"] == DBNull.Value ? false : Convert.ToBoolean(oReader["EsCancelado"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='indEstado'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                recibohonorarios.indEstado = oReader["indEstado"] == DBNull.Value ? false : Convert.ToBoolean(oReader["indEstado"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='UsuarioRegistro'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				recibohonorarios.UsuarioRegistro = oReader["UsuarioRegistro"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["UsuarioRegistro"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='FechaRegistro'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				recibohonorarios.FechaRegistro = oReader["FechaRegistro"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["FechaRegistro"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='UsuarioModificacion'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				recibohonorarios.UsuarioModificacion = oReader["UsuarioModificacion"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["UsuarioModificacion"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='FechaModificacion'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				recibohonorarios.FechaModificacion = oReader["FechaModificacion"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["FechaModificacion"]);

            //Extensiones
            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='RUC'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                recibohonorarios.RUC = oReader["RUC"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["RUC"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='NroDocumento'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                recibohonorarios.NroDocumento = oReader["NroDocumento"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["NroDocumento"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='TipoDocumento'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                recibohonorarios.TipoDocumento = oReader["TipoDocumento"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["TipoDocumento"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='desDocumento'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                recibohonorarios.desDocumento = oReader["desDocumento"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["desDocumento"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='RazonSocial'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                recibohonorarios.RazonSocial = oReader["RazonSocial"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["RazonSocial"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='NomPersona'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                recibohonorarios.NomPersona = oReader["NomPersona"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["NomPersona"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='desEstado'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                recibohonorarios.desEstado = oReader["desEstado"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["desEstado"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idDocumento'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                recibohonorarios.idDocumento = oReader["idDocumento"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["idDocumento"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='serDocumento'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                recibohonorarios.serDocumento = oReader["serDocumento"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["serDocumento"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='numDocumento'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                recibohonorarios.numDocumento = oReader["numDocumento"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["numDocumento"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='AnioDet'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                recibohonorarios.AnioDet = oReader["AnioDet"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["AnioDet"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='MesDet'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                recibohonorarios.MesDet = oReader["MesDet"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["MesDet"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idComprobante'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                recibohonorarios.idComprobante = oReader["idComprobante"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["idComprobante"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='numFile'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                recibohonorarios.numFile = oReader["numFile"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["numFile"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='numVoucher'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                recibohonorarios.numVoucher = oReader["numVoucher"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["numVoucher"]);

            return  recibohonorarios;        
        }

        public ReciboHonorariosE InsertarReciboHonorarios(ReciboHonorariosE recibohonorarios)
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_InsertarReciboHonorarios", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = recibohonorarios.idEmpresa;
                    oComando.Parameters.Add("@idLocal", SqlDbType.Int).Value = recibohonorarios.idLocal;
                    oComando.Parameters.Add("@AnioPeriodo", SqlDbType.VarChar, 4).Value = recibohonorarios.AnioPeriodo;
					oComando.Parameters.Add("@MesPeriodo", SqlDbType.VarChar, 2).Value = recibohonorarios.MesPeriodo;
					oComando.Parameters.Add("@idPersona", SqlDbType.Int).Value = recibohonorarios.idPersona;
					oComando.Parameters.Add("@impRecibo", SqlDbType.Decimal).Value = recibohonorarios.impRecibo;
					oComando.Parameters.Add("@impCuartaCat", SqlDbType.Decimal).Value = recibohonorarios.impCuartaCat;
					oComando.Parameters.Add("@impIES", SqlDbType.Decimal).Value = recibohonorarios.impIES;
					oComando.Parameters.Add("@UsuarioRegistro", SqlDbType.VarChar, 20).Value = recibohonorarios.UsuarioRegistro;

                    oConexion.Open();
                    recibohonorarios.idReciboHonorarios = Int32.Parse(oComando.ExecuteScalar().ToString());
                }
            }

            return recibohonorarios;
        }
        
        public ReciboHonorariosE ActualizarReciboHonorarios(ReciboHonorariosE recibohonorarios)
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ActualizarReciboHonorarios", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = recibohonorarios.idEmpresa;
                    oComando.Parameters.Add("@idLocal", SqlDbType.Int).Value = recibohonorarios.idLocal;
                    oComando.Parameters.Add("@idReciboHonorarios", SqlDbType.Int).Value = recibohonorarios.idReciboHonorarios;
					oComando.Parameters.Add("@AnioPeriodo", SqlDbType.VarChar, 4).Value = recibohonorarios.AnioPeriodo;
					oComando.Parameters.Add("@MesPeriodo", SqlDbType.VarChar, 2).Value = recibohonorarios.MesPeriodo;
					oComando.Parameters.Add("@idPersona", SqlDbType.Int).Value = recibohonorarios.idPersona;
					oComando.Parameters.Add("@impRecibo", SqlDbType.Decimal).Value = recibohonorarios.impRecibo;
					oComando.Parameters.Add("@impCuartaCat", SqlDbType.Decimal).Value = recibohonorarios.impCuartaCat;
					oComando.Parameters.Add("@impIES", SqlDbType.Decimal).Value = recibohonorarios.impIES;
					oComando.Parameters.Add("@UsuarioModificacion", SqlDbType.VarChar, 20).Value = recibohonorarios.UsuarioModificacion;

                    oConexion.Open();
                    oComando.ExecuteNonQuery();
                }
            }

            return recibohonorarios;
        }        

        public int EliminarReciboHonorarios(Int32 idEmpresa, Int32 idLocal, Int32 idReciboHonorarios)
        {
            int resp = 0;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_EliminarReciboHonorarios", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@idLocal", SqlDbType.Int).Value = idLocal;
                    oComando.Parameters.Add("@idReciboHonorarios", SqlDbType.Int).Value = idReciboHonorarios;

                    oConexion.Open();
                    resp = oComando.ExecuteNonQuery();
                }
            }

            return resp;
        }

        public List<ReciboHonorariosE> ListarReciboHonorarios(Int32 idEmpresa, Int32 idLocal, String Anio, String mes, String RazonSocial, String Tipo)
        {
            List<ReciboHonorariosE> listaEntidad = new List<ReciboHonorariosE>();

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ListarReciboHonorarios", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@idLocal", SqlDbType.Int).Value = idLocal;
                    oComando.Parameters.Add("@Anio", SqlDbType.VarChar, 4).Value = Anio;
                    oComando.Parameters.Add("@mes", SqlDbType.VarChar, 2).Value = mes;
                    oComando.Parameters.Add("@RazonSocial", SqlDbType.VarChar, 50).Value = RazonSocial;
                    oComando.Parameters.Add("@Tipo", SqlDbType.Char, 1).Value = Tipo;

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
        
        public ReciboHonorariosE ObtenerReciboHonorarios(Int32 idEmpresa, Int32 idLocal, Int32 idReciboHonorarios)
        {        
            ReciboHonorariosE recibohonorarios = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ObtenerReciboHonorarios", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@idLocal", SqlDbType.Int).Value = idLocal;
                    oComando.Parameters.Add("@idReciboHonorarios", SqlDbType.Int).Value = idReciboHonorarios;

                    oConexion.Open();
                    
                    using (SqlDataReader oReader = oComando.ExecuteReader())
                    {
                        while (oReader.Read())
                        {
                            recibohonorarios = LlenarEntidad(oReader);
                        }
                    }
                }
            }

            return recibohonorarios;
        }

    }
}