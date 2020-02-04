using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

using Entidades.Ventas;
using AccesoDatos.Util;

namespace AccesoDatos.Ventas
{
    public class PeriodoComisionAD : DbConection
    {
        
        public PeriodoComisionE LlenarEntidad(IDataReader oReader)
        {
            PeriodoComisionE periodocomision = new PeriodoComisionE();
            
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idEmpresa'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				periodocomision.idEmpresa = oReader["idEmpresa"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idEmpresa"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idPeriodo'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				periodocomision.idPeriodo = oReader["idPeriodo"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idPeriodo"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Anio'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				periodocomision.Anio = oReader["Anio"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["Anio"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Mes'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				periodocomision.Mes = oReader["Mes"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["Mes"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='FechaInicial'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				periodocomision.FechaInicial = oReader["FechaInicial"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["FechaInicial"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='FechaFinal'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				periodocomision.FechaFinal = oReader["FechaFinal"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["FechaFinal"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Estado'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				periodocomision.Estado = oReader["Estado"] == DBNull.Value ? true : Convert.ToBoolean(oReader["Estado"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='UsuarioRegistro'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				periodocomision.UsuarioRegistro = oReader["UsuarioRegistro"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["UsuarioRegistro"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='FechaRegistro'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				periodocomision.FechaRegistro = oReader["FechaRegistro"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["FechaRegistro"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='UsuarioModificacion'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				periodocomision.UsuarioModificacion = oReader["UsuarioModificacion"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["UsuarioModificacion"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='FechaModificacion'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				periodocomision.FechaModificacion = oReader["FechaModificacion"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["FechaModificacion"]);

            //Extensores
            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Nombre'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                periodocomision.Nombre = oReader["Nombre"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["Nombre"]);


            return  periodocomision;        
        }

        public PeriodoComisionE InsertarPeriodoComision(PeriodoComisionE periodocomision)
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_InsertarPeriodoComision", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;

                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = periodocomision.idEmpresa;
					oComando.Parameters.Add("@Anio", SqlDbType.VarChar, 4).Value = periodocomision.Anio;
					oComando.Parameters.Add("@Mes", SqlDbType.VarChar, 2).Value = periodocomision.Mes;
					oComando.Parameters.Add("@FechaInicial", SqlDbType.SmallDateTime).Value = periodocomision.FechaInicial;
					oComando.Parameters.Add("@FechaFinal", SqlDbType.SmallDateTime).Value = periodocomision.FechaFinal;
					oComando.Parameters.Add("@Estado", SqlDbType.Bit).Value = periodocomision.Estado;
					oComando.Parameters.Add("@UsuarioRegistro", SqlDbType.VarChar, 20).Value = periodocomision.UsuarioRegistro;
					oComando.Parameters.Add("@FechaRegistro", SqlDbType.SmallDateTime).Value = periodocomision.FechaRegistro;
					oComando.Parameters.Add("@UsuarioModificacion", SqlDbType.VarChar, 20).Value = periodocomision.UsuarioModificacion;
					oComando.Parameters.Add("@FechaModificacion", SqlDbType.SmallDateTime).Value = periodocomision.FechaModificacion;

                    oConexion.Open();
                    periodocomision.idPeriodo = Int32.Parse(oComando.ExecuteScalar().ToString());
                    oConexion.Close();
                }
            }

            return periodocomision;
        }
        
        public PeriodoComisionE ActualizarPeriodoComision(PeriodoComisionE periodocomision)
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ActualizarPeriodoComision", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;

                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = periodocomision.idEmpresa;
					oComando.Parameters.Add("@idPeriodo", SqlDbType.Int).Value = periodocomision.idPeriodo;
					oComando.Parameters.Add("@Anio", SqlDbType.VarChar, 4).Value = periodocomision.Anio;
					oComando.Parameters.Add("@Mes", SqlDbType.VarChar, 2).Value = periodocomision.Mes;
					oComando.Parameters.Add("@FechaInicial", SqlDbType.SmallDateTime).Value = periodocomision.FechaInicial;
					oComando.Parameters.Add("@FechaFinal", SqlDbType.SmallDateTime).Value = periodocomision.FechaFinal;
					oComando.Parameters.Add("@Estado", SqlDbType.Bit).Value = periodocomision.Estado;
					oComando.Parameters.Add("@UsuarioRegistro", SqlDbType.VarChar, 20).Value = periodocomision.UsuarioRegistro;
					oComando.Parameters.Add("@FechaRegistro", SqlDbType.SmallDateTime).Value = periodocomision.FechaRegistro;
					oComando.Parameters.Add("@UsuarioModificacion", SqlDbType.VarChar, 20).Value = periodocomision.UsuarioModificacion;
					oComando.Parameters.Add("@FechaModificacion", SqlDbType.SmallDateTime).Value = periodocomision.FechaModificacion;

                    oConexion.Open();
                    oComando.ExecuteNonQuery();
                    oConexion.Close();
                }
            }

            return periodocomision;
        }        

        public int EliminarPeriodoComision(Int32 idEmpresa, Int32 idPeriodo)
        {
            int resp = 0;
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_EliminarPeriodoComision", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;

                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
					oComando.Parameters.Add("@idPeriodo", SqlDbType.Int).Value = idPeriodo;

                    oConexion.Open();
                    resp = oComando.ExecuteNonQuery();
                    oConexion.Close();
                }
            }

            return resp;
        }

        public List<PeriodoComisionE> ListarPeriodoComision(Int32 idEmpresa)
        {
           List<PeriodoComisionE> listaEntidad = new List<PeriodoComisionE>();
           PeriodoComisionE entidad = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ListarPeriodoComision", oConexion))
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
        
        public PeriodoComisionE ObtenerPeriodoComision(Int32 idEmpresa, Int32 idPeriodo)
        {        
            PeriodoComisionE periodocomision = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ObtenerPeriodoComision", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;

                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
					oComando.Parameters.Add("@idPeriodo", SqlDbType.Int).Value = idPeriodo;
                    oConexion.Open();
                    
                    using (SqlDataReader oReader = oComando.ExecuteReader())
                    {
                        while (oReader.Read())
                        {
                            periodocomision = LlenarEntidad(oReader);
                        }
                    }
                }

                oConexion.Close();
            }

            return periodocomision;
        }




    }
}