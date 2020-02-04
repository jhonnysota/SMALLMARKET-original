using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

using Entidades.Tesoreria;
using AccesoDatos.Util;

namespace AccesoDatos
{
    public class AperturaCtaCteAD : DbConection
    {
        
        public AperturaCtaCteE LlenarEntidad(IDataReader oReader)
        {
            AperturaCtaCteE aperturactacte = new AperturaCtaCteE();
            
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idEmpresa'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				aperturactacte.idEmpresa = oReader["idEmpresa"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idEmpresa"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idRegistro'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				aperturactacte.idRegistro = oReader["idRegistro"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idRegistro"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='FechaOperacion'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				aperturactacte.FechaOperacion = oReader["FechaOperacion"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["FechaOperacion"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='numVerPlanCuenta'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				aperturactacte.numVerPlanCuenta = oReader["numVerPlanCuenta"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["numVerPlanCuenta"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='CodCuenta'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				aperturactacte.CodCuenta = oReader["CodCuenta"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["CodCuenta"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idPersona'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				aperturactacte.idPersona = oReader["idPersona"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idPersona"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Glosa'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				aperturactacte.Glosa = oReader["Glosa"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["Glosa"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idDocumento'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				aperturactacte.idDocumento = oReader["idDocumento"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["idDocumento"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Serie'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				aperturactacte.Serie = oReader["Serie"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["Serie"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Numero'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				aperturactacte.Numero = oReader["Numero"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["Numero"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='FechaEmision'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				aperturactacte.FechaEmision = oReader["FechaEmision"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["FechaEmision"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='TipoCambio'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				aperturactacte.TipoCambio = oReader["TipoCambio"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["TipoCambio"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idMoneda'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				aperturactacte.idMoneda = oReader["idMoneda"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["idMoneda"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='importe'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				aperturactacte.importe = oReader["importe"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["importe"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='indDebeHaber'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				aperturactacte.indDebeHaber = oReader["indDebeHaber"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["indDebeHaber"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='tipPartidaPresu'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                aperturactacte.tipPartidaPresu = oReader["tipPartidaPresu"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["tipPartidaPresu"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='codPartidaPresu'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                aperturactacte.codPartidaPresu = oReader["codPartidaPresu"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["codPartidaPresu"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='UsuarioRegistro'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				aperturactacte.UsuarioRegistro = oReader["UsuarioRegistro"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["UsuarioRegistro"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='FechaRegistro'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				aperturactacte.FechaRegistro = oReader["FechaRegistro"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["FechaRegistro"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='UsuarioModificacion'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				aperturactacte.UsuarioModificacion = oReader["UsuarioModificacion"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["UsuarioModificacion"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='FechaModificacion'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				aperturactacte.FechaModificacion = oReader["FechaModificacion"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["FechaModificacion"]);
			

            return  aperturactacte;        
        }

        public AperturaCtaCteE InsertarAperturaCtaCte(AperturaCtaCteE aperturactacte)
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_InsertarAperturaCtaCte", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;

                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = aperturactacte.idEmpresa;
					oComando.Parameters.Add("@idRegistro", SqlDbType.Int).Value = aperturactacte.idRegistro;
					oComando.Parameters.Add("@FechaOperacion", SqlDbType.SmallDateTime).Value = aperturactacte.FechaOperacion;
					oComando.Parameters.Add("@numVerPlanCuenta", SqlDbType.VarChar, 3).Value = aperturactacte.numVerPlanCuenta;
					oComando.Parameters.Add("@CodCuenta", SqlDbType.VarChar, 20).Value = aperturactacte.CodCuenta;
					oComando.Parameters.Add("@idPersona", SqlDbType.Int).Value = aperturactacte.idPersona;
					oComando.Parameters.Add("@Glosa", SqlDbType.VarChar, 200).Value = aperturactacte.Glosa;
					oComando.Parameters.Add("@idDocumento", SqlDbType.VarChar, 2).Value = aperturactacte.idDocumento;
					oComando.Parameters.Add("@Serie", SqlDbType.VarChar, 10).Value = aperturactacte.Serie;
					oComando.Parameters.Add("@Numero", SqlDbType.VarChar, 20).Value = aperturactacte.Numero;
					oComando.Parameters.Add("@FechaEmision", SqlDbType.SmallDateTime).Value = aperturactacte.FechaEmision;
					oComando.Parameters.Add("@TipoCambio", SqlDbType.Decimal).Value = aperturactacte.TipoCambio;
					oComando.Parameters.Add("@idMoneda", SqlDbType.VarChar, 2).Value = aperturactacte.idMoneda;
					oComando.Parameters.Add("@importe", SqlDbType.Decimal).Value = aperturactacte.importe;
					oComando.Parameters.Add("@indDebeHaber", SqlDbType.VarChar, 50).Value = aperturactacte.indDebeHaber;
                    oComando.Parameters.Add("@tipPartidaPresu", SqlDbType.VarChar, 2).Value = aperturactacte.indDebeHaber;
                    oComando.Parameters.Add("@codPartidaPresu", SqlDbType.VarChar, 20).Value = aperturactacte.indDebeHaber;
					oComando.Parameters.Add("@UsuarioRegistro", SqlDbType.VarChar, 20).Value = aperturactacte.UsuarioRegistro;
					oComando.Parameters.Add("@FechaRegistro", SqlDbType.SmallDateTime).Value = aperturactacte.FechaRegistro;
					oComando.Parameters.Add("@UsuarioModificacion", SqlDbType.VarChar, 20).Value = aperturactacte.UsuarioModificacion;
					oComando.Parameters.Add("@FechaModificacion", SqlDbType.SmallDateTime).Value = aperturactacte.FechaModificacion;

                    oConexion.Open();
                    oComando.ExecuteNonQuery();
                    oConexion.Close();
                }
            }

            return aperturactacte;
        }
        
        public AperturaCtaCteE ActualizarAperturaCtaCte(AperturaCtaCteE aperturactacte)
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ActualizarAperturaCtaCte", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;

                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = aperturactacte.idEmpresa;
					oComando.Parameters.Add("@idRegistro", SqlDbType.Int).Value = aperturactacte.idRegistro;
					oComando.Parameters.Add("@FechaOperacion", SqlDbType.SmallDateTime).Value = aperturactacte.FechaOperacion;
					oComando.Parameters.Add("@numVerPlanCuenta", SqlDbType.VarChar, 3).Value = aperturactacte.numVerPlanCuenta;
					oComando.Parameters.Add("@CodCuenta", SqlDbType.VarChar, 20).Value = aperturactacte.CodCuenta;
					oComando.Parameters.Add("@idPersona", SqlDbType.Int).Value = aperturactacte.idPersona;
					oComando.Parameters.Add("@Glosa", SqlDbType.VarChar, 200).Value = aperturactacte.Glosa;
					oComando.Parameters.Add("@idDocumento", SqlDbType.VarChar, 2).Value = aperturactacte.idDocumento;
					oComando.Parameters.Add("@Serie", SqlDbType.VarChar, 10).Value = aperturactacte.Serie;
					oComando.Parameters.Add("@Numero", SqlDbType.VarChar, 20).Value = aperturactacte.Numero;
					oComando.Parameters.Add("@FechaEmision", SqlDbType.SmallDateTime).Value = aperturactacte.FechaEmision;
					oComando.Parameters.Add("@TipoCambio", SqlDbType.Decimal).Value = aperturactacte.TipoCambio;
					oComando.Parameters.Add("@idMoneda", SqlDbType.VarChar, 2).Value = aperturactacte.idMoneda;
					oComando.Parameters.Add("@importe", SqlDbType.Decimal).Value = aperturactacte.importe;
					oComando.Parameters.Add("@indDebeHaber", SqlDbType.VarChar, 50).Value = aperturactacte.indDebeHaber;
                    oComando.Parameters.Add("@tipPartidaPresu", SqlDbType.VarChar, 2).Value = aperturactacte.indDebeHaber;
                    oComando.Parameters.Add("@codPartidaPresu", SqlDbType.VarChar, 20).Value = aperturactacte.indDebeHaber;
					oComando.Parameters.Add("@UsuarioRegistro", SqlDbType.VarChar, 20).Value = aperturactacte.UsuarioRegistro;
					oComando.Parameters.Add("@FechaRegistro", SqlDbType.SmallDateTime).Value = aperturactacte.FechaRegistro;
					oComando.Parameters.Add("@UsuarioModificacion", SqlDbType.VarChar, 20).Value = aperturactacte.UsuarioModificacion;
					oComando.Parameters.Add("@FechaModificacion", SqlDbType.SmallDateTime).Value = aperturactacte.FechaModificacion;

                    oConexion.Open();
                    oComando.ExecuteNonQuery();
                    oConexion.Close();
                }
            }

            return aperturactacte;
        }        

        public int EliminarAperturaCtaCte(Int32 idEmpresa, Int32 idRegistro)
        {
            int resp = 0;
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_EliminarAperturaCtaCte", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;

                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
					oComando.Parameters.Add("@idRegistro", SqlDbType.Int).Value = idRegistro;

                    oConexion.Open();
                    resp = oComando.ExecuteNonQuery();
                    oConexion.Close();
                }
            }

            return resp;
        }

        public List<AperturaCtaCteE> ListarAperturaCtaCte( Int32 idEmpresa)
        {
           List<AperturaCtaCteE> listaEntidad = new List<AperturaCtaCteE>();
           AperturaCtaCteE entidad = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ListarAperturaCtaCte", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;

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

                oConexion.Close();
            }

            return listaEntidad;
        }
        
        public AperturaCtaCteE ObtenerAperturaCtaCte(Int32 idEmpresa, Int32 idRegistro)
        {        
            AperturaCtaCteE aperturactacte = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ObtenerAperturaCtaCte", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;

                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
					oComando.Parameters.Add("@idRegistro", SqlDbType.Int).Value = idRegistro;
                    oConexion.Open();
                    
                    using (SqlDataReader oReader = oComando.ExecuteReader())
                    {
                        while (oReader.Read())
                        {
                            aperturactacte = LlenarEntidad(oReader);
                        }
                    }
                }

                oConexion.Close();
            }

            return aperturactacte;
        }
    }
}