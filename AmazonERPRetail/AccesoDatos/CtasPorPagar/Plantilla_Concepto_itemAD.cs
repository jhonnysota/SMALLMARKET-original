using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

using Entidades.CtasPorPagar;
using AccesoDatos.Util;

namespace AccesoDatos.CtasPorPagar
{
    public class Plantilla_Concepto_itemAD : DbConection
    {
        
        public Plantilla_Concepto_itemE LlenarEntidad(IDataReader oReader)
        {
            Plantilla_Concepto_itemE plantilla_concepto_item = new Plantilla_Concepto_itemE();
            
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idEmpresa'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				plantilla_concepto_item.idEmpresa = oReader["idEmpresa"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idEmpresa"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idPlantilla'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				plantilla_concepto_item.idPlantilla = oReader["idPlantilla"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idPlantilla"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idItem'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				plantilla_concepto_item.idItem = oReader["idItem"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idItem"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='numVerPlanCuentas'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				plantilla_concepto_item.numVerPlanCuentas = oReader["numVerPlanCuentas"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["numVerPlanCuentas"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='codCuenta'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				plantilla_concepto_item.codCuenta = oReader["codCuenta"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["codCuenta"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='DesCuenta'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                plantilla_concepto_item.DesCuenta = oReader["DesCuenta"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["DesCuenta"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='indDebeHaber'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				plantilla_concepto_item.indDebeHaber = oReader["indDebeHaber"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["indDebeHaber"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='codColumnaCoven'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                plantilla_concepto_item.codColumnaCoven = oReader["codColumnaCoven"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["codColumnaCoven"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='DesColumna'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                plantilla_concepto_item.DesColumna = oReader["DesColumna"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["DesColumna"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='UsuarioRegistro'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                plantilla_concepto_item.UsuarioRegistro = oReader["UsuarioRegistro"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["UsuarioRegistro"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='fechaRegistro'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                plantilla_concepto_item.fechaRegistro = oReader["fechaRegistro"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["fechaRegistro"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='UsuarioModificacion'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                plantilla_concepto_item.UsuarioModificacion = oReader["UsuarioModificacion"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["UsuarioModificacion"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='fechaModificacion'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                plantilla_concepto_item.fechaModificacion = oReader["fechaModificacion"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["fechaModificacion"]);
			

            return  plantilla_concepto_item;        
        }

        public Plantilla_Concepto_itemE InsertarPlantilla_Concepto_item(Plantilla_Concepto_itemE plantilla_concepto_item)
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_InsertarPlantilla_Concepto_item", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;

                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = plantilla_concepto_item.idEmpresa;
					oComando.Parameters.Add("@idPlantilla", SqlDbType.Int).Value = plantilla_concepto_item.idPlantilla;
					oComando.Parameters.Add("@numVerPlanCuentas", SqlDbType.VarChar, 3).Value = plantilla_concepto_item.numVerPlanCuentas;
					oComando.Parameters.Add("@codCuenta", SqlDbType.VarChar, 20).Value = plantilla_concepto_item.codCuenta;
					oComando.Parameters.Add("@indDebeHaber", SqlDbType.Char, 10).Value = plantilla_concepto_item.indDebeHaber;
                    oComando.Parameters.Add("@codColumnaCoven", SqlDbType.Int).Value = plantilla_concepto_item.codColumnaCoven;
                    oComando.Parameters.Add("@UsuarioRegistro", SqlDbType.VarChar, 30).Value = plantilla_concepto_item.UsuarioRegistro;
                    oComando.Parameters.Add("@fechaRegistro", SqlDbType.DateTime).Value = plantilla_concepto_item.fechaRegistro;
                    oComando.Parameters.Add("@UsuarioModificacion", SqlDbType.VarChar, 30).Value = plantilla_concepto_item.UsuarioModificacion;
                    oComando.Parameters.Add("@fechaModificacion", SqlDbType.DateTime).Value = plantilla_concepto_item.fechaModificacion;

                    oConexion.Open();
                    plantilla_concepto_item.idItem = Convert.ToInt32(oComando.ExecuteScalar());
                    oConexion.Close();
                }
            }

            return plantilla_concepto_item;
        }
        
        public Plantilla_Concepto_itemE ActualizarPlantilla_Concepto_item(Plantilla_Concepto_itemE plantilla_concepto_item)
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ActualizarPlantilla_Concepto_item", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;

                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = plantilla_concepto_item.idEmpresa;
					oComando.Parameters.Add("@idPlantilla", SqlDbType.Int).Value = plantilla_concepto_item.idPlantilla;
					oComando.Parameters.Add("@idItem", SqlDbType.Int).Value = plantilla_concepto_item.idItem;
					oComando.Parameters.Add("@numVerPlanCuentas", SqlDbType.VarChar, 3).Value = plantilla_concepto_item.numVerPlanCuentas;
					oComando.Parameters.Add("@codCuenta", SqlDbType.VarChar, 20).Value = plantilla_concepto_item.codCuenta;
					oComando.Parameters.Add("@indDebeHaber", SqlDbType.Char, 10).Value = plantilla_concepto_item.indDebeHaber;
                    oComando.Parameters.Add("@codColumnaCoven", SqlDbType.Int).Value = plantilla_concepto_item.codColumnaCoven;
                    oComando.Parameters.Add("@UsuarioRegistro", SqlDbType.VarChar, 30).Value = plantilla_concepto_item.UsuarioRegistro;
                    oComando.Parameters.Add("@fechaRegistro", SqlDbType.DateTime).Value = plantilla_concepto_item.fechaRegistro;
                    oComando.Parameters.Add("@UsuarioModificacion", SqlDbType.VarChar, 30).Value = plantilla_concepto_item.UsuarioModificacion;
                    oComando.Parameters.Add("@fechaModificacion", SqlDbType.DateTime).Value = plantilla_concepto_item.fechaModificacion;

                    oConexion.Open();
                    oComando.ExecuteNonQuery();
                    oConexion.Close();
                }
            }

            return plantilla_concepto_item;
        }        

        public int EliminarPlantilla_Concepto_item(Int32 idEmpresa, Int32 idPlantilla)
        {
            int resp = 0;
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_EliminarPlantilla_Concepto_item", oConexion))
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

        public List<Plantilla_Concepto_itemE> ListarPlantilla_Concepto_item()
        {
           List<Plantilla_Concepto_itemE> listaEntidad = new List<Plantilla_Concepto_itemE>();
           Plantilla_Concepto_itemE entidad = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ListarPlantilla_Concepto_item", oConexion))
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

                oConexion.Close();
            }

            return listaEntidad;
        }
        
        public Plantilla_Concepto_itemE ObtenerPlantilla_Concepto_item(Int32 idEmpresa, Int32 idPlantilla, Int32 idItem)
        {        
            Plantilla_Concepto_itemE plantilla_concepto_item = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ObtenerPlantilla_Concepto_item", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;

                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
					oComando.Parameters.Add("@idPlantilla", SqlDbType.Int).Value = idPlantilla;
					oComando.Parameters.Add("@idItem", SqlDbType.Int).Value = idItem;
                    oConexion.Open();
                    
                    using (SqlDataReader oReader = oComando.ExecuteReader())
                    {
                        while (oReader.Read())
                        {
                            plantilla_concepto_item = LlenarEntidad(oReader);
                        }
                    }
                }

                oConexion.Close();
            }

            return plantilla_concepto_item;
        }

        public List<Plantilla_Concepto_itemE> RecuperarPlantilla_Concepto_itemPorId(Int32 idEmpresa, Int32 idPlantilla)
        {
            Plantilla_Concepto_itemE entidad = null;

            List<Plantilla_Concepto_itemE> ListaPlantillaItem = new List<Plantilla_Concepto_itemE>();

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_RecuperarPlantilla_Concepto_itemPorId", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;

                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@idPlantilla", SqlDbType.Int).Value = idPlantilla;
                    oConexion.Open();

                    using (SqlDataReader oReader = oComando.ExecuteReader())
                    {
                        while (oReader.Read())
                        {
                            entidad = LlenarEntidad(oReader);
                            ListaPlantillaItem.Add(entidad);
                        }
                    }
                }

                oConexion.Close();
            }

            return ListaPlantillaItem;
        }




    }
}