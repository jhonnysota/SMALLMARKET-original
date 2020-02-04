using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

using Entidades.Contabilidad;
using AccesoDatos.Util;

namespace AccesoDatos.Contabilidad
{
    public class ActivacionDetAD : DbConection
    {

        public ActivacionDetE LlenarEntidad(IDataReader oReader)
        {
            ActivacionDetE activaciondet = new ActivacionDetE();
            
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idActivacion'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				activaciondet.idActivacion = oReader["idActivacion"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idActivacion"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Item'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                activaciondet.Item = oReader["Item"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["Item"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='numVerPlanCuentas'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                activaciondet.numVerPlanCuentas = oReader["numVerPlanCuentas"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["numVerPlanCuentas"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='codCuenta'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				activaciondet.codCuenta = oReader["codCuenta"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["codCuenta"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='MontoDebe'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				activaciondet.MontoDebe = oReader["MontoDebe"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["MontoDebe"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='MontoHaber'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				activaciondet.MontoHaber = oReader["MontoHaber"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["MontoHaber"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='MontoDebeDolares'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                activaciondet.MontoDebeDolares = oReader["MontoDebeDolares"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["MontoDebeDolares"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='MontoHaberDolares'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                activaciondet.MontoHaberDolares = oReader["MontoHaberDolares"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["MontoHaberDolares"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='UsuarioRegistro'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				activaciondet.UsuarioRegistro = oReader["UsuarioRegistro"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["UsuarioRegistro"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='FechaRegistro'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				activaciondet.FechaRegistro = oReader["FechaRegistro"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["FechaRegistro"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='UsuarioModificacion'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				activaciondet.UsuarioModificacion = oReader["UsuarioModificacion"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["UsuarioModificacion"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='FechaModificacion'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				activaciondet.FechaModificacion = oReader["FechaModificacion"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["FechaModificacion"]);

            //Extensiones
            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='desCuenta'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                activaciondet.desCuenta = oReader["desCuenta"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["desCuenta"]);

            return  activaciondet;        
        }

        public ActivacionDetE InsertarActivacionDet(ActivacionDetE activaciondet)
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_InsertarActivacionDet", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idActivacion", SqlDbType.Int).Value = activaciondet.idActivacion;
                    oComando.Parameters.Add("@Item", SqlDbType.Int).Value = activaciondet.Item;
                    oComando.Parameters.Add("@codCuenta", SqlDbType.VarChar, 20).Value = activaciondet.codCuenta;
					oComando.Parameters.Add("@numVerPlanCuentas", SqlDbType.VarChar, 3).Value = activaciondet.numVerPlanCuentas;
					oComando.Parameters.Add("@MontoDebe", SqlDbType.Decimal).Value = activaciondet.MontoDebe;
					oComando.Parameters.Add("@MontoHaber", SqlDbType.Decimal).Value = activaciondet.MontoHaber;
                    oComando.Parameters.Add("@MontoDebeDolares", SqlDbType.Decimal).Value = activaciondet.MontoDebeDolares;
                    oComando.Parameters.Add("@MontoHaberDolares", SqlDbType.Decimal).Value = activaciondet.MontoHaberDolares;
                    oComando.Parameters.Add("@UsuarioRegistro", SqlDbType.VarChar, 20).Value = activaciondet.UsuarioRegistro;

                    oConexion.Open();
                    oComando.ExecuteNonQuery();
                }
            }

            return activaciondet;
        }
        
        public ActivacionDetE ActualizarActivacionDet(ActivacionDetE activaciondet)
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ActualizarActivacionDet", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idActivacion", SqlDbType.Int).Value = activaciondet.idActivacion;
                    oComando.Parameters.Add("@Item", SqlDbType.Int).Value = activaciondet.Item;
                    oComando.Parameters.Add("@codCuenta", SqlDbType.VarChar, 20).Value = activaciondet.codCuenta;
					oComando.Parameters.Add("@numVerPlanCuentas", SqlDbType.VarChar, 3).Value = activaciondet.numVerPlanCuentas;
					oComando.Parameters.Add("@MontoDebe", SqlDbType.Decimal).Value = activaciondet.MontoDebe;
					oComando.Parameters.Add("@MontoHaber", SqlDbType.Decimal).Value = activaciondet.MontoHaber;
                    oComando.Parameters.Add("@MontoDebeDolares", SqlDbType.Decimal).Value = activaciondet.MontoDebeDolares;
                    oComando.Parameters.Add("@MontoHaberDolares", SqlDbType.Decimal).Value = activaciondet.MontoHaberDolares;
                    oComando.Parameters.Add("@UsuarioModificacion", SqlDbType.VarChar, 20).Value = activaciondet.UsuarioModificacion;

                    oConexion.Open();
                    oComando.ExecuteNonQuery();
                }
            }

            return activaciondet;
        }        

        public int EliminarActivacionDet(Int32 idActivacion)
        {
            int resp = 0;
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_EliminarActivacionDet", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idActivacion", SqlDbType.Int).Value = idActivacion;

                    oConexion.Open();
                    resp = oComando.ExecuteNonQuery();
                }
            }

            return resp;
        }

        public List<ActivacionDetE> ListarActivacionDet(Int32 idActivacion, Int32 idEmpresa)
        {
           List<ActivacionDetE> listaEntidad = new List<ActivacionDetE>();
           ActivacionDetE entidad = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ListarActivacionDet", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idActivacion", SqlDbType.Int).Value = idActivacion;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;

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
        
        public ActivacionDetE ObtenerActivacionDet(Int32 idActivacion, String codCuenta, String numVerPlanCuentas)
        {        
            ActivacionDetE activaciondet = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ObtenerActivacionDet", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idActivacion", SqlDbType.Int).Value = idActivacion;
					oComando.Parameters.Add("@codCuenta", SqlDbType.VarChar, 20).Value = codCuenta;
					oComando.Parameters.Add("@numVerPlanCuentas", SqlDbType.VarChar, 3).Value = numVerPlanCuentas;

                    oConexion.Open();
                    
                    using (SqlDataReader oReader = oComando.ExecuteReader())
                    {
                        while (oReader.Read())
                        {
                            activaciondet = LlenarEntidad(oReader);
                        }
                    }
                }
            }

            return activaciondet;
        }

    }
}