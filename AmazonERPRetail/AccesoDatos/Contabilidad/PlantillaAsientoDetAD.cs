using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

using Entidades.Contabilidad;
using AccesoDatos.Util;

namespace AccesoDatos.Contabilidad
{
    public class PlantillaAsientoDetAD : DbConection
    {

        public PlantillaAsientoDetE LlenarEntidad(IDataReader oReader)
        {
            PlantillaAsientoDetE plantillaasientodet = new PlantillaAsientoDetE();
            
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idPlantilla'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				plantillaasientodet.idPlantilla = oReader["idPlantilla"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idPlantilla"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idEmpresa'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				plantillaasientodet.idEmpresa = oReader["idEmpresa"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idEmpresa"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idLocal'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                plantillaasientodet.idLocal = oReader["idLocal"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idLocal"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Item'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				plantillaasientodet.Item = oReader["Item"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["Item"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='numVerPlanCuentas'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				plantillaasientodet.numVerPlanCuentas = oReader["numVerPlanCuentas"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["numVerPlanCuentas"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='codCuenta'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				plantillaasientodet.codCuenta = oReader["codCuenta"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["codCuenta"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='indDebeHaber'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				plantillaasientodet.indDebeHaber = oReader["indDebeHaber"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["indDebeHaber"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='codColumnaCoven'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				plantillaasientodet.codColumnaCoven = oReader["codColumnaCoven"] == DBNull.Value ? (Nullable<Int32>)null : Convert.ToInt32(oReader["codColumnaCoven"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Calculo'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                plantillaasientodet.Calculo = oReader["Calculo"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["Calculo"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='indDetalle'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                plantillaasientodet.indDetalle = oReader["indDetalle"] == DBNull.Value ? false : Convert.ToBoolean(oReader["indDetalle"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Hoja'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                plantillaasientodet.Hoja = oReader["Hoja"] == DBNull.Value ? (Nullable<Int32>)null : Convert.ToInt32(oReader["Hoja"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Refe1'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                plantillaasientodet.Refe1 = oReader["Refe1"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["Refe1"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Refe2'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                plantillaasientodet.Refe2 = oReader["Refe2"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["Refe2"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='QuitarDH'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                plantillaasientodet.QuitarDH = oReader["QuitarDH"] == DBNull.Value ? false : Convert.ToBoolean(oReader["QuitarDH"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='indContraPart'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                plantillaasientodet.indContraPart = oReader["indContraPart"] == DBNull.Value ? false : Convert.ToBoolean(oReader["indContraPart"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='ctaContraPart'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                plantillaasientodet.ctaContraPart = oReader["ctaContraPart"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["ctaContraPart"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Seguir'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                plantillaasientodet.Seguir = oReader["Seguir"] == DBNull.Value ? false : Convert.ToBoolean(oReader["Seguir"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Saltar'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                plantillaasientodet.Saltar = oReader["Saltar"] == DBNull.Value ? false : Convert.ToBoolean(oReader["Saltar"]);

			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='UsuarioRegistro'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				plantillaasientodet.UsuarioRegistro = oReader["UsuarioRegistro"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["UsuarioRegistro"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='FechaRegistro'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				plantillaasientodet.FechaRegistro = oReader["FechaRegistro"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["FechaRegistro"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='UsuarioModificacion'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				plantillaasientodet.UsuarioModificacion = oReader["UsuarioModificacion"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["UsuarioModificacion"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='FechaModificacion'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				plantillaasientodet.FechaModificacion = oReader["FechaModificacion"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["FechaModificacion"]);
			

            return  plantillaasientodet;        
        }

        public PlantillaAsientoDetE InsertarPlantillaAsientoDet(PlantillaAsientoDetE plantillaasientodet)
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_InsertarPlantillaAsientoDet", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;

                    oComando.Parameters.Add("@idPlantilla", SqlDbType.Int).Value = plantillaasientodet.idPlantilla;
					oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = plantillaasientodet.idEmpresa;
					oComando.Parameters.Add("@Item", SqlDbType.Int).Value = plantillaasientodet.Item;
					oComando.Parameters.Add("@numVerPlanCuentas", SqlDbType.VarChar, 3).Value = plantillaasientodet.numVerPlanCuentas;
					oComando.Parameters.Add("@codCuenta", SqlDbType.VarChar, 20).Value = plantillaasientodet.codCuenta;
					oComando.Parameters.Add("@indDebeHaber", SqlDbType.Char, 1).Value = plantillaasientodet.indDebeHaber;
					oComando.Parameters.Add("@codColumnaCoven", SqlDbType.Int).Value = plantillaasientodet.codColumnaCoven;
                    oComando.Parameters.Add("@Calculo", SqlDbType.Char, 2).Value = plantillaasientodet.Calculo;
                    oComando.Parameters.Add("@indDetalle", SqlDbType.Bit).Value = plantillaasientodet.indDetalle;
                    oComando.Parameters.Add("@Hoja", SqlDbType.Int).Value = plantillaasientodet.Hoja;
                    oComando.Parameters.Add("@Refe1", SqlDbType.VarChar, 20).Value = plantillaasientodet.Refe1;
                    oComando.Parameters.Add("@Refe2", SqlDbType.VarChar, 20).Value = plantillaasientodet.Refe2;
                    oComando.Parameters.Add("@QuitarDH", SqlDbType.Bit).Value = plantillaasientodet.QuitarDH;
                    oComando.Parameters.Add("@indContraPart", SqlDbType.Bit).Value = plantillaasientodet.indContraPart;
                    oComando.Parameters.Add("@ctaContraPart", SqlDbType.VarChar, 20).Value = plantillaasientodet.ctaContraPart;
                    oComando.Parameters.Add("@Seguir", SqlDbType.Bit).Value = plantillaasientodet.Seguir;
                    oComando.Parameters.Add("@Saltar", SqlDbType.Bit).Value = plantillaasientodet.Saltar;
                    oComando.Parameters.Add("@UsuarioRegistro", SqlDbType.VarChar, 20).Value = plantillaasientodet.UsuarioRegistro;

                    oConexion.Open();
                    oComando.ExecuteNonQuery();
                }
            }

            return plantillaasientodet;
        }
        
        public PlantillaAsientoDetE ActualizarPlantillaAsientoDet(PlantillaAsientoDetE plantillaasientodet)
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ActualizarPlantillaAsientoDet", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idPlantilla", SqlDbType.Int).Value = plantillaasientodet.idPlantilla;
					oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = plantillaasientodet.idEmpresa;
					oComando.Parameters.Add("@Item", SqlDbType.Int).Value = plantillaasientodet.Item;
					oComando.Parameters.Add("@numVerPlanCuentas", SqlDbType.VarChar, 3).Value = plantillaasientodet.numVerPlanCuentas;
					oComando.Parameters.Add("@codCuenta", SqlDbType.VarChar, 20).Value = plantillaasientodet.codCuenta;
					oComando.Parameters.Add("@indDebeHaber", SqlDbType.Char, 1).Value = plantillaasientodet.indDebeHaber;
					oComando.Parameters.Add("@codColumnaCoven", SqlDbType.Int).Value = plantillaasientodet.codColumnaCoven;
                    oComando.Parameters.Add("@Calculo", SqlDbType.Char, 2).Value = plantillaasientodet.Calculo;
                    oComando.Parameters.Add("@indDetalle", SqlDbType.Bit).Value = plantillaasientodet.indDetalle;
                    oComando.Parameters.Add("@Hoja", SqlDbType.Int).Value = plantillaasientodet.Hoja;
                    oComando.Parameters.Add("@Refe1", SqlDbType.VarChar, 20).Value = plantillaasientodet.Refe1;
                    oComando.Parameters.Add("@Refe2", SqlDbType.VarChar, 20).Value = plantillaasientodet.Refe2;
                    oComando.Parameters.Add("@QuitarDH", SqlDbType.Bit).Value = plantillaasientodet.QuitarDH;
                    oComando.Parameters.Add("@indContraPart", SqlDbType.Bit).Value = plantillaasientodet.indContraPart;
                    oComando.Parameters.Add("@ctaContraPart", SqlDbType.VarChar, 20).Value = plantillaasientodet.ctaContraPart;
                    oComando.Parameters.Add("@Seguir", SqlDbType.Bit).Value = plantillaasientodet.Seguir;
                    oComando.Parameters.Add("@Saltar", SqlDbType.Bit).Value = plantillaasientodet.Saltar;
					oComando.Parameters.Add("@UsuarioModificacion", SqlDbType.VarChar, 20).Value = plantillaasientodet.UsuarioModificacion;

                    oConexion.Open();
                    oComando.ExecuteNonQuery();
                }
            }

            return plantillaasientodet;
        }        

        public Int32 EliminarPlantillaAsientoDet(Int32 idPlantilla, Int32 idEmpresa, Int32 Item)
        {
            Int32 resp = 0;
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_EliminarPlantillaAsientoDet", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idPlantilla", SqlDbType.Int).Value = idPlantilla;
					oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
					oComando.Parameters.Add("@Item", SqlDbType.Int).Value = Item;

                    oConexion.Open();
                    resp = oComando.ExecuteNonQuery();
                }
            }

            return resp;
        }

        public List<PlantillaAsientoDetE> ListarPlantillaAsientoDet(Int32 idPlantilla, Int32 idEmpresa)
        {
            List<PlantillaAsientoDetE> listaEntidad = new List<PlantillaAsientoDetE>();
            PlantillaAsientoDetE entidad = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ListarPlantillaAsientoDet", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idPlantilla", SqlDbType.Int).Value = idPlantilla;
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
        
        public PlantillaAsientoDetE ObtenerPlantillaAsientoDet(Int32 idPlantilla, Int32 idEmpresa, Int32 Item)
        {        
            PlantillaAsientoDetE plantillaasientodet = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ObtenerPlantillaAsientoDet", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idPlantilla", SqlDbType.Int).Value = idPlantilla;
					oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
					oComando.Parameters.Add("@Item", SqlDbType.Int).Value = Item;

                    oConexion.Open();
                    
                    using (SqlDataReader oReader = oComando.ExecuteReader())
                    {
                        while (oReader.Read())
                        {
                            plantillaasientodet = LlenarEntidad(oReader);
                        }
                    }
                }
            }

            return plantillaasientodet;
        }

    }
}