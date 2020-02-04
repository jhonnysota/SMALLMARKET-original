using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

using Entidades.Ventas;
using AccesoDatos.Util;

namespace AccesoDatos.Ventas
{
    public class PlanillaBancosDetAD : DbConection
    {

        public PlanillaBancosDetE LlenarEntidad(IDataReader oReader)
        {
            PlanillaBancosDetE planillabancosdet = new PlanillaBancosDetE();
            
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idPlanillaBanco'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				planillabancosdet.idPlanillaBanco = oReader["idPlanillaBanco"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idPlanillaBanco"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Letra'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				planillabancosdet.Letra = oReader["Letra"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["Letra"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='numVerPlanCuentas'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                planillabancosdet.numVerPlanCuentas = oReader["numVerPlanCuentas"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["numVerPlanCuentas"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='codCuenta'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				planillabancosdet.codCuenta = oReader["codCuenta"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["codCuenta"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Fecha'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				planillabancosdet.Fecha = oReader["Fecha"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["Fecha"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='fecVenc'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				planillabancosdet.fecVenc = oReader["fecVenc"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["fecVenc"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idMoneda'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				planillabancosdet.idMoneda = oReader["idMoneda"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["idMoneda"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Monto'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				planillabancosdet.Monto = oReader["Monto"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["Monto"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idPersona'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				planillabancosdet.idPersona = oReader["idPersona"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idPersona"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Plaza'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				planillabancosdet.Plaza = oReader["Plaza"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["Plaza"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='nroUnico'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                planillabancosdet.nroUnico = oReader["nroUnico"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["nroUnico"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idCtaCte12'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                planillabancosdet.idCtaCte12 = oReader["idCtaCte12"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idCtaCte12"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idCtaCteItem12'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                planillabancosdet.idCtaCteItem12 = oReader["idCtaCteItem12"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idCtaCteItem12"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idCtaCte'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                planillabancosdet.idCtaCte = oReader["idCtaCte"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idCtaCte"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idCtaCteItem'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                planillabancosdet.idCtaCteItem = oReader["idCtaCteItem"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idCtaCteItem"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='UsuarioRegistro'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				planillabancosdet.UsuarioRegistro = oReader["UsuarioRegistro"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["UsuarioRegistro"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='FechaRegistro'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				planillabancosdet.FechaRegistro = oReader["FechaRegistro"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["FechaRegistro"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='UsuarioModificacion'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				planillabancosdet.UsuarioModificacion = oReader["UsuarioModificacion"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["UsuarioModificacion"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='FechaModificacion'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				planillabancosdet.FechaModificacion = oReader["FechaModificacion"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["FechaModificacion"]);

            //Extensiones
            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='desMoneda'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                planillabancosdet.desMoneda = oReader["desMoneda"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["desMoneda"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='RazonSocial'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                planillabancosdet.RazonSocial = oReader["RazonSocial"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["RazonSocial"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='tipCanje'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                planillabancosdet.tipCanje = oReader["tipCanje"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["tipCanje"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='codCanje'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                planillabancosdet.codCanje = oReader["codCanje"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["codCanje"]);

            return  planillabancosdet;        
        }

        public PlanillaBancosDetE InsertarPlanillaBancosDet(PlanillaBancosDetE planillabancosdet)
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_InsertarPlanillaBancosDet", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idPlanillaBanco", SqlDbType.Int).Value = planillabancosdet.idPlanillaBanco;
					oComando.Parameters.Add("@Letra", SqlDbType.VarChar, 20).Value = planillabancosdet.Letra;
                    oComando.Parameters.Add("@numVerPlanCuentas", SqlDbType.VarChar, 3).Value = planillabancosdet.numVerPlanCuentas;
                    oComando.Parameters.Add("@codCuenta", SqlDbType.VarChar, 20).Value = planillabancosdet.codCuenta;
					oComando.Parameters.Add("@Fecha", SqlDbType.SmallDateTime).Value = planillabancosdet.Fecha;
					oComando.Parameters.Add("@fecVenc", SqlDbType.SmallDateTime).Value = planillabancosdet.fecVenc;
					oComando.Parameters.Add("@idMoneda", SqlDbType.VarChar, 2).Value = planillabancosdet.idMoneda;
                    oComando.Parameters.Add("@Monto", SqlDbType.Decimal).Value = planillabancosdet.Monto;
                    oComando.Parameters.Add("@idPersona", SqlDbType.Int).Value = planillabancosdet.idPersona;
					oComando.Parameters.Add("@Plaza", SqlDbType.VarChar, 2).Value = planillabancosdet.Plaza;
                    oComando.Parameters.Add("@nroUnico", SqlDbType.VarChar, 20).Value = planillabancosdet.nroUnico;
                    oComando.Parameters.Add("@idCtaCte12", SqlDbType.Int).Value = planillabancosdet.idCtaCte12;
                    oComando.Parameters.Add("@UsuarioRegistro", SqlDbType.VarChar, 20).Value = planillabancosdet.UsuarioRegistro;

                    oConexion.Open();
                    oComando.ExecuteNonQuery();
                }
            }

            return planillabancosdet;
        }
        
        public PlanillaBancosDetE ActualizarPlanillaBancosDet(PlanillaBancosDetE planillabancosdet)
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ActualizarPlanillaBancosDet", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idPlanillaBanco", SqlDbType.Int).Value = planillabancosdet.idPlanillaBanco;
					oComando.Parameters.Add("@Letra", SqlDbType.VarChar, 20).Value = planillabancosdet.Letra;
                    oComando.Parameters.Add("@numVerPlanCuentas", SqlDbType.VarChar, 3).Value = planillabancosdet.numVerPlanCuentas;
                    oComando.Parameters.Add("@codCuenta", SqlDbType.VarChar, 20).Value = planillabancosdet.codCuenta;
					oComando.Parameters.Add("@Fecha", SqlDbType.SmallDateTime).Value = planillabancosdet.Fecha;
					oComando.Parameters.Add("@fecVenc", SqlDbType.SmallDateTime).Value = planillabancosdet.fecVenc;
					oComando.Parameters.Add("@idMoneda", SqlDbType.VarChar, 2).Value = planillabancosdet.idMoneda;
                    oComando.Parameters.Add("@Monto", SqlDbType.Decimal).Value = planillabancosdet.Monto;
                    oComando.Parameters.Add("@idPersona", SqlDbType.Int).Value = planillabancosdet.idPersona;
					oComando.Parameters.Add("@Plaza", SqlDbType.VarChar, 2).Value = planillabancosdet.Plaza;
                    oComando.Parameters.Add("@nroUnico", SqlDbType.VarChar, 20).Value = planillabancosdet.nroUnico;
                    oComando.Parameters.Add("@idCtaCte12", SqlDbType.Int).Value = planillabancosdet.idCtaCte12;
                    oComando.Parameters.Add("@UsuarioModificacion", SqlDbType.VarChar, 20).Value = planillabancosdet.UsuarioModificacion;

                    oConexion.Open();
                    oComando.ExecuteNonQuery();
                }
            }

            return planillabancosdet;
        }        

        public int EliminarPlanillaBancosDet(Int32 idPlanillaBanco)
        {
            int resp = 0;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_EliminarPlanillaBancosDet", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idPlanillaBanco", SqlDbType.Int).Value = idPlanillaBanco;

                    oConexion.Open();
                    resp = oComando.ExecuteNonQuery();
                }
            }

            return resp;
        }

        public List<PlanillaBancosDetE> ListarPlanillaBancosDet(Int32 idPlanillaBanco)
        {
            List<PlanillaBancosDetE> listaEntidad = new List<PlanillaBancosDetE>();

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ListarPlanillaBancosDet", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idPlanillaBanco", SqlDbType.Int).Value = idPlanillaBanco;
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
        
        public PlanillaBancosDetE ObtenerPlanillaBancosDet(Int32 idPlanillaBanco, String Letra)
        {        
            PlanillaBancosDetE planillabancosdet = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ObtenerPlanillaBancosDet", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idPlanillaBanco", SqlDbType.Int).Value = idPlanillaBanco;
					oComando.Parameters.Add("@Letra", SqlDbType.VarChar, 20).Value = Letra;

                    oConexion.Open();
                    
                    using (SqlDataReader oReader = oComando.ExecuteReader())
                    {
                        while (oReader.Read())
                        {
                            planillabancosdet = LlenarEntidad(oReader);
                        }
                    }
                }
            }

            return planillabancosdet;
        }

        public Int32 ActualizarPlanillaBancosDetCtaCte(PlanillaBancosDetE planillabancosdet)
        {
            Int32 resp = 0;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ActualizarPlanillaBancosDetCtaCte", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idPlanillaBanco", SqlDbType.Int).Value = planillabancosdet.idPlanillaBanco;
                    oComando.Parameters.Add("@Letra", SqlDbType.VarChar, 20).Value = planillabancosdet.Letra;
                    oComando.Parameters.Add("@idCtaCteItem12", SqlDbType.Int).Value = planillabancosdet.idCtaCteItem12;
                    oComando.Parameters.Add("@idCtaCte", SqlDbType.Int).Value = planillabancosdet.idCtaCte;
                    oComando.Parameters.Add("@idCtaCteItem", SqlDbType.Int).Value = planillabancosdet.idCtaCteItem;
                    oComando.Parameters.Add("@UsuarioModificacion", SqlDbType.VarChar, 20).Value = planillabancosdet.UsuarioModificacion;

                    oConexion.Open();
                    resp = oComando.ExecuteNonQuery();
                }
            }

            return resp;
        }

    }
}