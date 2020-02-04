using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

using Entidades.Maestros;
using AccesoDatos.Util;

namespace AccesoDatos.Ventas
{
    public class PartidaPresupuestariaAD : DbConection
    {

        public PartidaPresupuestariaE LlenarEntidad(IDataReader oReader)
        {
            PartidaPresupuestariaE partidapresupuestaria = new PartidaPresupuestariaE();
            
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idEmpresa'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				partidapresupuestaria.idEmpresa = oReader["idEmpresa"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idEmpresa"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='tipPartidaPresu'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				partidapresupuestaria.tipPartidaPresu = oReader["tipPartidaPresu"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["tipPartidaPresu"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='codPartidaPresu'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				partidapresupuestaria.codPartidaPresu = oReader["codPartidaPresu"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["codPartidaPresu"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='DesPartidaPresu'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				partidapresupuestaria.desPartidaPresu = oReader["DesPartidaPresu"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["DesPartidaPresu"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='AbrevPartidaPresu'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				partidapresupuestaria.abrevPartidaPresu = oReader["AbrevPartidaPresu"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["AbrevPartidaPresu"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='numNivel'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				partidapresupuestaria.numNivel = oReader["numNivel"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["numNivel"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='codPartidaPresuSup'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				partidapresupuestaria.codPartidaPresuSup = oReader["codPartidaPresuSup"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["codPartidaPresuSup"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='tipTituloNodo'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				partidapresupuestaria.tipTituloNodo = oReader["tipTituloNodo"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["tipTituloNodo"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='indUltNodo'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				partidapresupuestaria.indUltNodo = oReader["indUltNodo"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["indUltNodo"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='indBaja'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				partidapresupuestaria.indBaja = oReader["indBaja"] == DBNull.Value ? true : Convert.ToBoolean(oReader["indBaja"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='FechaBaja'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				partidapresupuestaria.FechaBaja = oReader["FechaBaja"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["FechaBaja"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='UsuarioRegistro'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				partidapresupuestaria.UsuarioRegistro = oReader["UsuarioRegistro"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["UsuarioRegistro"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='fechaRegistro'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				partidapresupuestaria.fechaRegistro = oReader["fechaRegistro"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["fechaRegistro"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='UsuarioModificacion'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				partidapresupuestaria.UsuarioModificacion = oReader["UsuarioModificacion"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["UsuarioModificacion"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='fechaModificacion'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				partidapresupuestaria.fechaModificacion = oReader["fechaModificacion"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["fechaModificacion"]);
			
            return  partidapresupuestaria;        
        }

        public PartidaPresupuestariaE InsertarPartidaPresupuestaria(PartidaPresupuestariaE partidapresupuestaria)
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_InsertarPartidaPresupuestaria", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = partidapresupuestaria.idEmpresa;
					oComando.Parameters.Add("@tipPartidaPresu", SqlDbType.VarChar, 2).Value = partidapresupuestaria.tipPartidaPresu;
					oComando.Parameters.Add("@codPartidaPresu", SqlDbType.VarChar, 20).Value = partidapresupuestaria.codPartidaPresu;
					oComando.Parameters.Add("@desPartidaPresu", SqlDbType.VarChar, 100).Value = partidapresupuestaria.desPartidaPresu;
					oComando.Parameters.Add("@abrevPartidaPresu", SqlDbType.VarChar, 20).Value = partidapresupuestaria.abrevPartidaPresu;
					oComando.Parameters.Add("@numNivel", SqlDbType.Int).Value = partidapresupuestaria.numNivel;
					oComando.Parameters.Add("@codPartidaPresuSup", SqlDbType.VarChar, 20).Value = partidapresupuestaria.codPartidaPresuSup;
					oComando.Parameters.Add("@tipTituloNodo", SqlDbType.VarChar, 2).Value = partidapresupuestaria.tipTituloNodo;
					oComando.Parameters.Add("@indUltNodo", SqlDbType.Char, 1).Value = partidapresupuestaria.indUltNodo;
					oComando.Parameters.Add("@indBaja", SqlDbType.Bit).Value = partidapresupuestaria.indBaja;
					oComando.Parameters.Add("@FechaBaja", SqlDbType.DateTime).Value = partidapresupuestaria.FechaBaja;
					oComando.Parameters.Add("@UsuarioRegistro", SqlDbType.VarChar, 30).Value = partidapresupuestaria.UsuarioRegistro;
					
                    oConexion.Open();
                    oComando.ExecuteNonQuery();
                }
            }

            return partidapresupuestaria;
        }
        
        public PartidaPresupuestariaE ActualizarPartidaPresupuestaria(PartidaPresupuestariaE partidapresupuestaria)
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ActualizarPartidaPresupuestaria", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = partidapresupuestaria.idEmpresa;
					oComando.Parameters.Add("@tipPartidaPresu", SqlDbType.VarChar, 2).Value = partidapresupuestaria.tipPartidaPresu;
					oComando.Parameters.Add("@codPartidaPresu", SqlDbType.VarChar, 20).Value = partidapresupuestaria.codPartidaPresu;
					oComando.Parameters.Add("@desPartidaPresu", SqlDbType.VarChar, 100).Value = partidapresupuestaria.desPartidaPresu;
					oComando.Parameters.Add("@abrevPartidaPresu", SqlDbType.VarChar, 20).Value = partidapresupuestaria.abrevPartidaPresu;
					oComando.Parameters.Add("@numNivel", SqlDbType.Int).Value = partidapresupuestaria.numNivel;
					oComando.Parameters.Add("@codPartidaPresuSup", SqlDbType.VarChar, 20).Value = partidapresupuestaria.codPartidaPresuSup;
					oComando.Parameters.Add("@tipTituloNodo", SqlDbType.VarChar, 2).Value = partidapresupuestaria.tipTituloNodo;
					oComando.Parameters.Add("@indUltNodo", SqlDbType.Char, 1).Value = partidapresupuestaria.indUltNodo;
					oComando.Parameters.Add("@indBaja", SqlDbType.Bit).Value = partidapresupuestaria.indBaja;
					oComando.Parameters.Add("@FechaBaja", SqlDbType.DateTime).Value = partidapresupuestaria.FechaBaja;
					oComando.Parameters.Add("@UsuarioModificacion", SqlDbType.VarChar, 30).Value = partidapresupuestaria.UsuarioModificacion;

                    oConexion.Open();
                    oComando.ExecuteNonQuery();
                }
            }

            return partidapresupuestaria;
        }        

        public Int32 EliminarPartidaPresupuestaria(Int32 idEmpresa, String tipPartidaPresu, String codPartidaPresu)
        {
            Int32 resp = 0;
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_EliminarPartidaPresupuestaria", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
					oComando.Parameters.Add("@tipPartidaPresu", SqlDbType.VarChar, 2).Value = tipPartidaPresu;
					oComando.Parameters.Add("@codPartidaPresu", SqlDbType.VarChar, 20).Value = codPartidaPresu;

                    oConexion.Open();
                    resp = oComando.ExecuteNonQuery();
                }
            }

            return resp;
        }

        public List<PartidaPresupuestariaE> ListarPartidaPresupuestaria()
        {
            List<PartidaPresupuestariaE> listaEntidad = new List<PartidaPresupuestariaE>();

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ListarPartidaPresupuestaria", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
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

        public PartidaPresupuestariaE ListarPartidaPresupuestariaPorCodigo(Int32 idEmpresa, String codPartidaPresu)
        {
            PartidaPresupuestariaE partidapresupuestaria = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ListarPartidaPresupuestariaPorCodigo", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;


                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@codPartidaPresu", SqlDbType.VarChar, 20).Value = codPartidaPresu;
                    oConexion.Open();

                    using (SqlDataReader oReader = oComando.ExecuteReader())
                    {
                        while (oReader.Read())
                        {
                            partidapresupuestaria = LlenarEntidad(oReader);
                        }
                    }
                }
            }

            return partidapresupuestaria;
        }

        public PartidaPresupuestariaE ObtenerPartidaPresupuestaria(Int32 idEmpresa, String tipPartidaPresu, String codPartidaPresu)
        {        
            PartidaPresupuestariaE partidapresupuestaria = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ObtenerPartidaPresupuestaria", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;

                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
					oComando.Parameters.Add("@tipPartidaPresu", SqlDbType.VarChar, 2).Value = tipPartidaPresu;
					oComando.Parameters.Add("@codPartidaPresu", SqlDbType.VarChar, 20).Value = codPartidaPresu;
                    oConexion.Open();
                    
                    using (SqlDataReader oReader = oComando.ExecuteReader())
                    {
                        while (oReader.Read())
                        {
                            partidapresupuestaria = LlenarEntidad(oReader);
                        }
                    }
                }
            }

            return partidapresupuestaria;
        }

        public List<PartidaPresupuestariaE> ListarPartidaPresupuestariaPorTipo(Int32 idEmpresa, String TipoPartida, String desPartidaPresu, Int32 numNivel)
        {
            List<PartidaPresupuestariaE> listaEntidad = new List<PartidaPresupuestariaE>();
            PartidaPresupuestariaE entidad = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ListarPartidaPresupuestariaPorTipo", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@tipPartidaPresu", SqlDbType.VarChar, 2).Value = TipoPartida;
                    oComando.Parameters.Add("@desPartidaPresu", SqlDbType.VarChar, 100).Value = desPartidaPresu;
                    oComando.Parameters.Add("@numNivel", SqlDbType.Int).Value = numNivel;

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

        public Int32 ObtenerNivelPartida(Int32 idEmpresa)
        {
            Int32 Nivel = 0;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ObtenerNivelPartida", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;

                    oConexion.Open();
                    Nivel = Int32.Parse(oComando.ExecuteScalar().ToString());
                }
            }

            return Nivel;
        }

        public Int32 EliminarPartidaPresupuestariaDetalle(Int32 idEmpresa, String tipPartidaPresu, String codPartidaPresuSup)
        {
            Int32 resp = 0;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_EliminarPartidaPresupuestariaDetalle", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@tipPartidaPresu", SqlDbType.VarChar, 2).Value = tipPartidaPresu;
                    oComando.Parameters.Add("@codPartidaPresuSup", SqlDbType.VarChar, 20).Value = codPartidaPresuSup;

                    oConexion.Open();
                    resp = oComando.ExecuteNonQuery();
                }
            }

            return resp;
        }

    }
}