using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

using Entidades.Contabilidad;
using AccesoDatos.Util;

namespace AccesoDatos.Contabilidad
{
    public class EEFFItemCtaAD : DbConection
    {

        public EEFFItemCtaE LlenarEntidad(IDataReader oReader)
        {
            EEFFItemCtaE eeffitemcta = new EEFFItemCtaE();
            
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idEMPRESA'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                eeffitemcta.idEmpresa = oReader["idEMPRESA"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idEMPRESA"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idEEFF'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				eeffitemcta.idEEFF = oReader["idEEFF"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idEEFF"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idEEFFItem'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				eeffitemcta.idEEFFItem = oReader["idEEFFItem"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idEEFFItem"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idEEFFItemCta'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				eeffitemcta.idEEFFItemCta = oReader["idEEFFItemCta"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idEEFFItemCta"]);

			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='CodPlaCta'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				eeffitemcta.CodPlaCta = oReader["CodPlaCta"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["CodPlaCta"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='NumPlaCta'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				eeffitemcta.NumPlaCta = oReader["NumPlaCta"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["NumPlaCta"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='TipoCondicion'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				eeffitemcta.TipoCondicion = oReader["TipoCondicion"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["TipoCondicion"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='TipoNivel'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				eeffitemcta.TipoNivel = oReader["TipoNivel"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["TipoNivel"]);

			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='UsuarioRegistro'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				eeffitemcta.UsuarioRegistro = oReader["UsuarioRegistro"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["UsuarioRegistro"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='FechaRegistro'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				eeffitemcta.FechaRegistro = oReader["FechaRegistro"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["FechaRegistro"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='UsuarioModificacion'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				eeffitemcta.UsuarioModificacion = oReader["UsuarioModificacion"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["UsuarioModificacion"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='FechaModificacion'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				eeffitemcta.FechaModificacion = oReader["FechaModificacion"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["FechaModificacion"]);

            //Extensiones
            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='desCuenta'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                eeffitemcta.desCuenta = oReader["desCuenta"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["desCuenta"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='totDebeSoles'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                eeffitemcta.totDebeSoles = oReader["totDebeSoles"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["totDebeSoles"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='totHaberSoles'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                eeffitemcta.totHaberSoles = oReader["totHaberSoles"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["totHaberSoles"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='totHaberDolares'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                eeffitemcta.totHaberDolares = oReader["totHaberDolares"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["totHaberDolares"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='totDebeSoles'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                eeffitemcta.totDebeSoles = oReader["totDebeSoles"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["totDebeSoles"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='SaldoActualSoles'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                eeffitemcta.SaldoActualSoles = oReader["SaldoActualSoles"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["SaldoActualSoles"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='SaldoActualDolares'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                eeffitemcta.SaldoActualDolares = oReader["SaldoActualDolares"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["SaldoActualDolares"]);

            return  eeffitemcta;        
        }

        public EEFFItemCtaE InsertarEEFFItemCta(EEFFItemCtaE eeffitemcta)
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_InsertarEEFFItemCta", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEMPRESA", SqlDbType.Int).Value = eeffitemcta.idEmpresa;
					oComando.Parameters.Add("@idEEFF", SqlDbType.Int).Value = eeffitemcta.idEEFF;
					oComando.Parameters.Add("@idEEFFItem", SqlDbType.Int).Value = eeffitemcta.idEEFFItem;
                    oComando.Parameters.Add("@idEEFFItemCta", SqlDbType.Int).Value = eeffitemcta.idEEFFItemCta;
                    oComando.Parameters.Add("@CodPlaCta", SqlDbType.VarChar, 20).Value = eeffitemcta.CodPlaCta;
                    oComando.Parameters.Add("@NumPlaCta", SqlDbType.VarChar, 3).Value = eeffitemcta.NumPlaCta;
					oComando.Parameters.Add("@TipoCondicion", SqlDbType.Char, 1).Value = eeffitemcta.TipoCondicion;
					oComando.Parameters.Add("@TipoNivel", SqlDbType.Char, 1).Value = eeffitemcta.TipoNivel;
					oComando.Parameters.Add("@UsuarioRegistro", SqlDbType.VarChar, 20).Value = eeffitemcta.UsuarioRegistro;

                    oConexion.Open();
                    oComando.ExecuteNonQuery();
                    oConexion.Close();


                }
            }

            return eeffitemcta;
        }
        
        public EEFFItemCtaE ActualizarEEFFItemCta(EEFFItemCtaE eeffitemcta)
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ActualizarEEFFItemCta", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEMPRESA", SqlDbType.Int).Value = eeffitemcta.idEmpresa;
					oComando.Parameters.Add("@idEEFF", SqlDbType.Int).Value = eeffitemcta.idEEFF;
					oComando.Parameters.Add("@idEEFFItem", SqlDbType.Int).Value = eeffitemcta.idEEFFItem;
					oComando.Parameters.Add("@idEEFFItemCta", SqlDbType.Int).Value = eeffitemcta.idEEFFItemCta;
					oComando.Parameters.Add("@CodPlaCta", SqlDbType.VarChar, 20).Value = eeffitemcta.CodPlaCta;
                    oComando.Parameters.Add("@NumPlaCta", SqlDbType.VarChar, 3).Value = eeffitemcta.NumPlaCta;
					oComando.Parameters.Add("@TipoCondicion", SqlDbType.Char, 1).Value = eeffitemcta.TipoCondicion;
					oComando.Parameters.Add("@TipoNivel", SqlDbType.Char, 1).Value = eeffitemcta.TipoNivel;
                    oComando.Parameters.Add("@UsuarioModificacion", SqlDbType.VarChar, 20).Value = eeffitemcta.UsuarioRegistro;

                    oConexion.Open();
                    oComando.ExecuteNonQuery();
                }
            }

            return eeffitemcta;
        }        

        public int EliminarEEFFItemCta(Int32 idEMPRESA, Int32 idEEFF, Int32 idEEFFItem, Int32 idEEFFItemCta)
        {
            int resp = 0;
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_EliminarEEFFItemCta", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEMPRESA", SqlDbType.Int).Value = idEMPRESA;
					oComando.Parameters.Add("@idEEFF", SqlDbType.Int).Value = idEEFF;
					oComando.Parameters.Add("@idEEFFItem", SqlDbType.Int).Value = idEEFFItem;
					oComando.Parameters.Add("@idEEFFItemCta", SqlDbType.Int).Value = idEEFFItemCta;

                    oConexion.Open();
                    resp = oComando.ExecuteNonQuery();
                }
            }

            return resp;
        }

        public Int32 MaxIdConEEFFItemCta(Int32 idEmpresa, int idEEFF, int idEEFFItem)
        {
            Int32 idConEEFFItemCta = 0;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_MaxIdConEEFFItemCta", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@idEEFF", SqlDbType.Int).Value = idEEFF;
                    oComando.Parameters.Add("@idEEFFItem", SqlDbType.Int).Value = idEEFFItem;
                    oConexion.Open();
                    idConEEFFItemCta = Convert.ToInt32(oComando.ExecuteScalar());
                }
            }

            return idConEEFFItemCta;
        }

        public List<EEFFItemCtaE> ListarEEFFItemCta(Int32 idEmpresa, Int32 idEEFF, Int32 idEEFFItem, Int32 idLocal, String AnioPeriodo, String MesPeriodo)
        {
           List<EEFFItemCtaE> listaEntidad = new List<EEFFItemCtaE>();
           EEFFItemCtaE entidad = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ListarEEFFItemCta", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@idEEFF", SqlDbType.Int).Value = idEEFF;
                    oComando.Parameters.Add("@idEEFFItem", SqlDbType.Int).Value = idEEFFItem;
                    oComando.Parameters.Add("@idLocal", SqlDbType.Int).Value = idLocal;
                    oComando.Parameters.Add("@AnioPeriodo", SqlDbType.VarChar, 4).Value = AnioPeriodo;
                    oComando.Parameters.Add("@MesPeriodo", SqlDbType.VarChar, 2).Value = MesPeriodo;

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
        
        public EEFFItemCtaE ObtenerEEFFItemCta(Int32 idEMPRESA, Int32 idEEFF, Int32 idEEFFItem, Int32 idEEFFItemCta)
        {        
            EEFFItemCtaE eeffitemcta = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ObtenerEEFFItemCta", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEMPRESA", SqlDbType.Int).Value = idEMPRESA;
					oComando.Parameters.Add("@idEEFF", SqlDbType.Int).Value = idEEFF;
					oComando.Parameters.Add("@idEEFFItem", SqlDbType.Int).Value = idEEFFItem;
					oComando.Parameters.Add("@idEEFFItemCta", SqlDbType.Int).Value = idEEFFItemCta;

                    oConexion.Open();
                    
                    using (SqlDataReader oReader = oComando.ExecuteReader())
                    {
                        while (oReader.Read())
                        {
                            eeffitemcta = LlenarEntidad(oReader);
                        }
                    }
                }
            }

            return eeffitemcta;
        }

        public List<EEFFItemCtaE> EEFFCtasNoAsignadas(Int32 idEmpresa, Int32 idEEFF, String AnioPeriodo, String MesPeriodo)
        {
            List<EEFFItemCtaE> listaEntidad = new List<EEFFItemCtaE>();
            EEFFItemCtaE entidad = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_EEFFCtasNoAsignadas", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@idEEFF", SqlDbType.Int).Value = idEEFF;
                    oComando.Parameters.Add("@AnioPeriodo", SqlDbType.VarChar, 4).Value = AnioPeriodo;
                    oComando.Parameters.Add("@MesPeriodo", SqlDbType.VarChar, 2).Value = MesPeriodo;

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

    }
}