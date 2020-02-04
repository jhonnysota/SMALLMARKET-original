using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

using Entidades.CtasPorPagar;
using AccesoDatos.Util;

namespace AccesoDatos.CtasPorPagar
{
    public class Plantilla_ConceptoAD : DbConection
    {
        
        public Plantilla_ConceptoE LlenarEntidad(IDataReader oReader)
        {
            Plantilla_ConceptoE plantilla_concepto = new Plantilla_ConceptoE();
            
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idEmpresa'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				plantilla_concepto.idEmpresa = oReader["idEmpresa"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idEmpresa"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idPlantilla'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				plantilla_concepto.idPlantilla = oReader["idPlantilla"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idPlantilla"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='DesPlantilla'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				plantilla_concepto.DesPlantilla = oReader["DesPlantilla"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["DesPlantilla"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idComprobante'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				plantilla_concepto.idComprobante = oReader["idComprobante"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["idComprobante"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='DesComprobante'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                plantilla_concepto.DesComprobante = oReader["DesComprobante"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["DesComprobante"]);

			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='numFile'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				plantilla_concepto.numFile = oReader["numFile"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["numFile"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='DesnumFile'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                plantilla_concepto.DesnumFile = oReader["DesnumFile"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["DesnumFile"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='CodMoneda'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                plantilla_concepto.CodMoneda = oReader["CodMoneda"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["CodMoneda"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='TipoPlantilla'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				plantilla_concepto.TipoPlantilla = oReader["TipoPlantilla"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["TipoPlantilla"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='UsuarioRegistro'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                plantilla_concepto.UsuarioRegistro = oReader["UsuarioRegistro"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["UsuarioRegistro"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='fechaRegistro'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                plantilla_concepto.fechaRegistro = oReader["fechaRegistro"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["fechaRegistro"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='UsuarioModificacion'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                plantilla_concepto.UsuarioModificacion = oReader["UsuarioModificacion"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["UsuarioModificacion"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='fechaModificacion'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                plantilla_concepto.fechaModificacion = oReader["fechaModificacion"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["fechaModificacion"]);
			

            return  plantilla_concepto;        
        }

        public Plantilla_ConceptoE InsertarPlantilla_Concepto(Plantilla_ConceptoE plantilla_concepto)
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_InsertarPlantilla_Concepto", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;

                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = plantilla_concepto.idEmpresa;
					oComando.Parameters.Add("@DesPlantilla", SqlDbType.VarChar, 100).Value = plantilla_concepto.DesPlantilla;
					oComando.Parameters.Add("@idComprobante", SqlDbType.Char, 2).Value = plantilla_concepto.idComprobante;
					oComando.Parameters.Add("@numFile", SqlDbType.Char, 2).Value = plantilla_concepto.numFile;
                    oComando.Parameters.Add("@CodMoneda", SqlDbType.Char, 2).Value = plantilla_concepto.CodMoneda;
					oComando.Parameters.Add("@TipoPlantilla", SqlDbType.VarChar, 4).Value = plantilla_concepto.TipoPlantilla;
                    oComando.Parameters.Add("@UsuarioRegistro", SqlDbType.VarChar, 30).Value = plantilla_concepto.UsuarioRegistro;
                    oComando.Parameters.Add("@fechaRegistro", SqlDbType.DateTime).Value = plantilla_concepto.fechaRegistro;
                    oComando.Parameters.Add("@UsuarioModificacion", SqlDbType.VarChar, 30).Value = plantilla_concepto.UsuarioModificacion;
                    oComando.Parameters.Add("@fechaModificacion", SqlDbType.DateTime).Value = plantilla_concepto.fechaModificacion;

                    oConexion.Open();
                    plantilla_concepto.idPlantilla = Convert.ToInt32(oComando.ExecuteScalar());
                    oConexion.Close();
                }
            }

            return plantilla_concepto;
        }
        
        public Plantilla_ConceptoE ActualizarPlantilla_Concepto(Plantilla_ConceptoE plantilla_concepto)
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ActualizarPlantilla_Concepto", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;

                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = plantilla_concepto.idEmpresa;
					oComando.Parameters.Add("@idPlantilla", SqlDbType.Int).Value = plantilla_concepto.idPlantilla;
					oComando.Parameters.Add("@DesPlantilla", SqlDbType.VarChar, 100).Value = plantilla_concepto.DesPlantilla;
					oComando.Parameters.Add("@idComprobante", SqlDbType.Char, 2).Value = plantilla_concepto.idComprobante;
					oComando.Parameters.Add("@numFile", SqlDbType.Char, 2).Value = plantilla_concepto.numFile;
                    oComando.Parameters.Add("@CodMoneda", SqlDbType.Char, 2).Value = plantilla_concepto.CodMoneda;
					oComando.Parameters.Add("@TipoPlantilla", SqlDbType.VarChar, 4).Value = plantilla_concepto.TipoPlantilla;
                    oComando.Parameters.Add("@UsuarioRegistro", SqlDbType.VarChar, 30).Value = plantilla_concepto.UsuarioRegistro;
                    oComando.Parameters.Add("@fechaRegistro", SqlDbType.DateTime).Value = plantilla_concepto.fechaRegistro;
                    oComando.Parameters.Add("@UsuarioModificacion", SqlDbType.VarChar, 30).Value = plantilla_concepto.UsuarioModificacion;
                    oComando.Parameters.Add("@fechaModificacion", SqlDbType.DateTime).Value = plantilla_concepto.fechaModificacion;

                    oConexion.Open();
                    oComando.ExecuteNonQuery();
                    oConexion.Close();
                }
            }

            return plantilla_concepto;
        }        

        public int EliminarPlantilla_Concepto(Int32 idEmpresa, Int32 idPlantilla)
        {
            int resp = 0;
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_EliminarPlantilla_Concepto", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;

                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
					oComando.Parameters.Add("@idPlantilla", SqlDbType.Int).Value = idPlantilla;

                    oConexion.Open();
                    resp = oComando.ExecuteNonQuery();
                    oConexion.Close();
                }
            }

            return resp;
        }

        public List<Plantilla_ConceptoE> ListarPlantilla_Concepto(Int32 idEmpresa)
        {
           List<Plantilla_ConceptoE> listaEntidad = new List<Plantilla_ConceptoE>();
           Plantilla_ConceptoE entidad = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ListarPlantilla_Concepto", oConexion))
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
        
        public Plantilla_ConceptoE ObtenerPlantilla_Concepto(Int32 idEmpresa, Int32 idPlantilla)
        {        
            Plantilla_ConceptoE plantilla_concepto = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ObtenerPlantilla_Concepto", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;

                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
					oComando.Parameters.Add("@idPlantilla", SqlDbType.Int).Value = idPlantilla;
                    oConexion.Open();
                    
                    using (SqlDataReader oReader = oComando.ExecuteReader())
                    {
                        while (oReader.Read())
                        {
                            plantilla_concepto = LlenarEntidad(oReader);
                        }
                    }
                }

                oConexion.Close();
            }

            return plantilla_concepto;
        }

        public Plantilla_ConceptoE RecuperarPlantilla_ConceptoPorId(Int32 idEmpresa, Int32 idPlantilla)
        {
            Plantilla_ConceptoE plantilla_concepto = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_RecuperarPlantilla_ConceptoPorId", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;

                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@idPlantilla", SqlDbType.Int).Value = idPlantilla;
                    oConexion.Open();

                    using (SqlDataReader oReader = oComando.ExecuteReader())
                    {
                        while (oReader.Read())
                        {
                            plantilla_concepto = LlenarEntidad(oReader);
                        }
                    }
                }

                oConexion.Close();
            }

            return plantilla_concepto;
        }


    }
}