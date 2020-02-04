using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

using Entidades.Maestros;
using AccesoDatos.Util;

namespace AccesoDatos.Maestros
{
    public class OpeLogisticoAD : DbConection
    {

        public OpeLogisticoE LlenarEntidad(IDataReader oReader)
        {
            OpeLogisticoE opelogistico = new OpeLogisticoE();
            
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idPersona'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				opelogistico.idPersona = oReader["idPersona"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idPersona"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idEmpresa'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				opelogistico.idEmpresa = oReader["idEmpresa"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idEmpresa"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='SiglaComercial'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				opelogistico.SiglaComercial = oReader["SiglaComercial"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["SiglaComercial"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='indBaja'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				opelogistico.indBaja = oReader["indBaja"] == DBNull.Value ? false : Convert.ToBoolean(oReader["indBaja"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='fecBaja'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				opelogistico.fecBaja = oReader["fecBaja"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["fecBaja"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='UsuarioRegistro'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				opelogistico.UsuarioRegistro = oReader["UsuarioRegistro"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["UsuarioRegistro"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='FechaRegistro'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				opelogistico.FechaRegistro = oReader["FechaRegistro"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["FechaRegistro"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='UsuarioModificacion'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				opelogistico.UsuarioModificacion = oReader["UsuarioModificacion"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["UsuarioModificacion"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='FechaModificacion'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				opelogistico.FechaModificacion = oReader["FechaModificacion"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["FechaModificacion"]);

            //OTROS CAMPOS
            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='RazonSocial'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                opelogistico.RazonSocial = oReader["RazonSocial"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["RazonSocial"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='RUC'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                opelogistico.RUC = oReader["RUC"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["RUC"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='DireccionCompleta'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                opelogistico.DireccionCompleta = oReader["DireccionCompleta"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["DireccionCompleta"]);

            return  opelogistico;        
        }

        public OpeLogisticoE InsertarOpeLogistico(OpeLogisticoE opelogistico)
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_InsertarOpeLogistico", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idPersona", SqlDbType.Int).Value = opelogistico.idPersona;
					oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = opelogistico.idEmpresa;
					oComando.Parameters.Add("@SiglaComercial", SqlDbType.VarChar, 100).Value = opelogistico.SiglaComercial;
					oComando.Parameters.Add("@indBaja", SqlDbType.Bit).Value = opelogistico.indBaja;
					oComando.Parameters.Add("@fecBaja", SqlDbType.SmallDateTime).Value = opelogistico.fecBaja;
					oComando.Parameters.Add("@UsuarioRegistro", SqlDbType.VarChar, 20).Value = opelogistico.UsuarioRegistro;

                    oConexion.Open();
                    oComando.ExecuteNonQuery();
                }
            }

            return opelogistico;
        }
        
        public OpeLogisticoE ActualizarOpeLogistico(OpeLogisticoE opelogistico)
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ActualizarOpeLogistico", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idPersona", SqlDbType.Int).Value = opelogistico.idPersona;
					oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = opelogistico.idEmpresa;
					oComando.Parameters.Add("@SiglaComercial", SqlDbType.VarChar, 100).Value = opelogistico.SiglaComercial;
					oComando.Parameters.Add("@indBaja", SqlDbType.Bit).Value = opelogistico.indBaja;
					oComando.Parameters.Add("@fecBaja", SqlDbType.SmallDateTime).Value = opelogistico.fecBaja;
					oComando.Parameters.Add("@UsuarioModificacion", SqlDbType.VarChar, 20).Value = opelogistico.UsuarioModificacion;

                    oConexion.Open();
                    oComando.ExecuteNonQuery();
                }
            }

            return opelogistico;
        }        

        public List<OpeLogisticoE> ListarOpeLogistico()
        {
           List<OpeLogisticoE> listaEntidad = new List<OpeLogisticoE>();
           OpeLogisticoE entidad = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ListarOpeLogistico", oConexion))
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
        
        public OpeLogisticoE ObtenerOpeLogistico(Int32 idPersona, Int32 idEmpresa)
        {        
            OpeLogisticoE opelogistico = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ObtenerOpeLogistico", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;

                    oComando.Parameters.Add("@idPersona", SqlDbType.Int).Value = idPersona;
					oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oConexion.Open();
                    
                    using (SqlDataReader oReader = oComando.ExecuteReader())
                    {
                        while (oReader.Read())
                        {
                            opelogistico = LlenarEntidad(oReader);
                        }
                    }
                }
            }

            return opelogistico;
        }

        public List<OpeLogisticoE> ListarOpeLogPorParametro(Int32 idEmpresa, String RazonSocial, String NroDocumento, Boolean activo, Boolean inactivo)
        {
            List<OpeLogisticoE> listaEntidad = new List<OpeLogisticoE>();
            OpeLogisticoE entidad = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ListarOpeLogPorParametro", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@RazonSocial", SqlDbType.NVarChar, 300).Value = RazonSocial;
                    oComando.Parameters.Add("@NroDocumento", SqlDbType.NVarChar, 25).Value = NroDocumento;
                    oComando.Parameters.Add("@activo", SqlDbType.Bit).Value = activo;
                    oComando.Parameters.Add("@inactivo", SqlDbType.Bit).Value = inactivo;

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

        public OpeLogisticoE RecuperarOpeLogPorId(Int32 idPersona, Int32 idEmpresa)
        {
            OpeLogisticoE operador = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_RecuperarOpeLogPorId", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idPersona", SqlDbType.Int).Value = idPersona;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oConexion.Open();

                    using (SqlDataReader oReader = oComando.ExecuteReader())
                    {
                        while (oReader.Read())
                        {
                            operador = LlenarEntidad(oReader);
                        }
                    }
                }
            }

            return operador;
        }

    }
}