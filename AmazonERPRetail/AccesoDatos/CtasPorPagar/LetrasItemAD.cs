using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

using Entidades.CtasPorPagar;
using AccesoDatos.Util;

namespace AccesoDatos.CtasPorPagar
{
    public class LetrasItemAD : DbConection
    {

        public LetrasItemE LlenarEntidad(IDataReader oReader)
        {
            LetrasItemE letrasitem = new LetrasItemE();
            
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idEmpresa'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				letrasitem.idEmpresa = oReader["idEmpresa"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idEmpresa"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idLocal'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				letrasitem.idLocal = oReader["idLocal"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idLocal"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idCanje'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				letrasitem.idCanje = oReader["idCanje"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idCanje"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idItemLetra'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				letrasitem.idItemLetra = oReader["idItemLetra"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idItemLetra"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='numLetra'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				letrasitem.numLetra = oReader["numLetra"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["numLetra"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idPersona'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				letrasitem.idPersona = oReader["idPersona"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idPersona"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='FechaEmision'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				letrasitem.FechaEmision = oReader["FechaEmision"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["FechaEmision"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='FechaVencimiento'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				letrasitem.FechaVencimiento = oReader["FechaVencimiento"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["FechaVencimiento"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idMoneda'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				letrasitem.idMoneda = oReader["idMoneda"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["idMoneda"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='MontoLetra'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				letrasitem.MontoLetra = oReader["MontoLetra"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["MontoLetra"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='MontoSoles'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                letrasitem.MontoSoles = oReader["MontoSoles"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["MontoSoles"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='MontoDolares'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                letrasitem.MontoDolares = oReader["MontoDolares"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["MontoDolares"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='numVerPlanCuentas'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                letrasitem.numVerPlanCuentas = oReader["numVerPlanCuentas"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["numVerPlanCuentas"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='codCuenta'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                letrasitem.codCuenta = oReader["codCuenta"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["codCuenta"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idCtaCte'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                letrasitem.idCtaCte = oReader["idCtaCte"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idCtaCte"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idCtaCteItem'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                letrasitem.idCtaCteItem = oReader["idCtaCteItem"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idCtaCteItem"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Estado'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                letrasitem.Estado = oReader["Estado"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["Estado"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='UsuarioRegistro'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				letrasitem.UsuarioRegistro = oReader["UsuarioRegistro"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["UsuarioRegistro"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='FechaRegistro'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				letrasitem.FechaRegistro = oReader["FechaRegistro"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["FechaRegistro"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='UsuarioModificacion'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				letrasitem.UsuarioModificacion = oReader["UsuarioModificacion"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["UsuarioModificacion"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='FechaModificacion'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				letrasitem.FechaModificacion = oReader["FechaModificacion"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["FechaModificacion"]);

            return  letrasitem;        
        }

        public LetrasItemE InsertarLetrasItem(LetrasItemE letrasitem)
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_InsertarLetrasItem", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = letrasitem.idEmpresa;
					oComando.Parameters.Add("@idLocal", SqlDbType.Int).Value = letrasitem.idLocal;
					oComando.Parameters.Add("@idCanje", SqlDbType.Int).Value = letrasitem.idCanje;
					oComando.Parameters.Add("@numLetra", SqlDbType.VarChar, 20).Value = letrasitem.numLetra;
					oComando.Parameters.Add("@idPersona", SqlDbType.Int).Value = letrasitem.idPersona;
					oComando.Parameters.Add("@FechaEmision", SqlDbType.SmallDateTime).Value = letrasitem.FechaEmision;
					oComando.Parameters.Add("@FechaVencimiento", SqlDbType.SmallDateTime).Value = letrasitem.FechaVencimiento;
					oComando.Parameters.Add("@idMoneda", SqlDbType.VarChar, 2).Value = letrasitem.idMoneda;
					oComando.Parameters.Add("@MontoLetra", SqlDbType.Decimal).Value = letrasitem.MontoLetra;
                    oComando.Parameters.Add("@MontoSoles", SqlDbType.Decimal).Value = letrasitem.MontoSoles;
                    oComando.Parameters.Add("@MontoDolares", SqlDbType.Decimal).Value = letrasitem.MontoDolares;
                    oComando.Parameters.Add("@numVerPlanCuentas", SqlDbType.VarChar, 3).Value = letrasitem.numVerPlanCuentas;
                    oComando.Parameters.Add("@codCuenta", SqlDbType.VarChar, 20).Value = letrasitem.codCuenta;
                    oComando.Parameters.Add("@UsuarioRegistro", SqlDbType.VarChar, 20).Value = letrasitem.UsuarioRegistro;

                    oConexion.Open();
                    letrasitem.idItemLetra = Int32.Parse(oComando.ExecuteScalar().ToString());
                }
            }

            return letrasitem;
        }
        
        public LetrasItemE ActualizarLetrasItem(LetrasItemE letrasitem)
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ActualizarLetrasItem", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = letrasitem.idEmpresa;
					oComando.Parameters.Add("@idLocal", SqlDbType.Int).Value = letrasitem.idLocal;
					oComando.Parameters.Add("@idCanje", SqlDbType.Int).Value = letrasitem.idCanje;
					oComando.Parameters.Add("@idItemLetra", SqlDbType.Int).Value = letrasitem.idItemLetra;
					oComando.Parameters.Add("@numLetra", SqlDbType.VarChar, 20).Value = letrasitem.numLetra;
					oComando.Parameters.Add("@idPersona", SqlDbType.Int).Value = letrasitem.idPersona;
					oComando.Parameters.Add("@FechaEmision", SqlDbType.SmallDateTime).Value = letrasitem.FechaEmision;
					oComando.Parameters.Add("@FechaVencimiento", SqlDbType.SmallDateTime).Value = letrasitem.FechaVencimiento;
					oComando.Parameters.Add("@idMoneda", SqlDbType.VarChar, 2).Value = letrasitem.idMoneda;
					oComando.Parameters.Add("@MontoLetra", SqlDbType.Decimal).Value = letrasitem.MontoLetra;
                    oComando.Parameters.Add("@MontoSoles", SqlDbType.Decimal).Value = letrasitem.MontoSoles;
                    oComando.Parameters.Add("@MontoDolares", SqlDbType.Decimal).Value = letrasitem.MontoDolares;
                    oComando.Parameters.Add("@numVerPlanCuentas", SqlDbType.VarChar, 3).Value = letrasitem.numVerPlanCuentas;
                    oComando.Parameters.Add("@codCuenta", SqlDbType.VarChar, 20).Value = letrasitem.codCuenta;
                    oComando.Parameters.Add("@UsuarioModificacion", SqlDbType.VarChar, 20).Value = letrasitem.UsuarioModificacion;

                    oConexion.Open();
                    oComando.ExecuteNonQuery();
                }
            }

            return letrasitem;
        }        

        public int EliminarLetrasItem(Int32 idCanje, Int32 idItemLetra)
        {
            int resp = 0;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_EliminarLetrasItem", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
					oComando.Parameters.Add("@idCanje", SqlDbType.Int).Value = idCanje;
                    oComando.Parameters.Add("@idItemLetra", SqlDbType.Int).Value = idItemLetra;

                    oConexion.Open();
                    resp = oComando.ExecuteNonQuery();
                }
            }

            return resp;
        }

        public List<LetrasItemE> ListarLetrasItem(Int32 idCanje)
        {
            List<LetrasItemE> listaEntidad = new List<LetrasItemE>();

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ListarLetrasItem", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idCanje", SqlDbType.Int).Value = idCanje;

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
        
        public LetrasItemE ObtenerLetrasItem(Int32 idEmpresa, Int32 idLocal, Int32 idCanje, Int32 idItemLetra)
        {        
            LetrasItemE letrasitem = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ObtenerLetrasItem", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
					oComando.Parameters.Add("@idLocal", SqlDbType.Int).Value = idLocal;
					oComando.Parameters.Add("@idCanje", SqlDbType.Int).Value = idCanje;
					oComando.Parameters.Add("@idItemLetra", SqlDbType.Int).Value = idItemLetra;

                    oConexion.Open();
                    
                    using (SqlDataReader oReader = oComando.ExecuteReader())
                    {
                        while (oReader.Read())
                        {
                            letrasitem = LlenarEntidad(oReader);
                        }
                    }
                }
            }

            return letrasitem;
        }

        public LetrasItemE ActualizarLetrasItemCtaCte(LetrasItemE letrasitem)
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ActualizarLetrasItemCtaCte", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idCanje", SqlDbType.Int).Value = letrasitem.idCanje;
                    oComando.Parameters.Add("@idItemLetra", SqlDbType.Int).Value = letrasitem.idItemLetra;
                    oComando.Parameters.Add("@idCtaCte", SqlDbType.Int).Value = letrasitem.idCtaCte;
                    oComando.Parameters.Add("@idCtaCteItem", SqlDbType.Int).Value = letrasitem.idCtaCteItem;
                    oComando.Parameters.Add("@UsuarioModificacion", SqlDbType.VarChar, 20).Value = letrasitem.UsuarioModificacion;

                    oConexion.Open();
                    oComando.ExecuteNonQuery();
                }
            }

            return letrasitem;
        }

    }
}