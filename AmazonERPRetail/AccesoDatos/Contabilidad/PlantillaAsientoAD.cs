using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

using Entidades.Contabilidad;
using AccesoDatos.Util;

namespace AccesoDatos.Contabilidad
{
    public class PlantillaAsientoAD : DbConection
    {
        
        public PlantillaAsientoE LlenarEntidad(IDataReader oReader)
        {
            PlantillaAsientoE plantillaasiento = new PlantillaAsientoE();
            
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idPlantilla'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				plantillaasiento.idPlantilla = oReader["idPlantilla"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idPlantilla"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idEmpresa'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				plantillaasiento.idEmpresa = oReader["idEmpresa"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idEmpresa"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idLocal'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                plantillaasiento.idLocal = oReader["idLocal"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idLocal"]);

			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Descripcion'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				plantillaasiento.Descripcion = oReader["Descripcion"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["Descripcion"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idComprobante'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				plantillaasiento.idComprobante = oReader["idComprobante"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["idComprobante"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='numFile'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				plantillaasiento.numFile = oReader["numFile"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["numFile"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idMoneda'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				plantillaasiento.idMoneda = oReader["idMoneda"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["idMoneda"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='TipoVoucher'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                plantillaasiento.TipoVoucher = oReader["TipoVoucher"] == DBNull.Value ? (Nullable<Int32>)null : Convert.ToInt32(oReader["TipoVoucher"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='indExcel'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				plantillaasiento.indExcel = oReader["indExcel"] == DBNull.Value ? false : Convert.ToBoolean(oReader["indExcel"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Hoja'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                plantillaasiento.Hoja = oReader["Hoja"] == DBNull.Value ? (Nullable<Int32>)null : Convert.ToInt32(oReader["Hoja"]);

			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='filInicial'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                plantillaasiento.filInicial = oReader["filInicial"] == DBNull.Value ? (Nullable<Int32>)null : Convert.ToInt32(oReader["filInicial"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='colInicial'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                plantillaasiento.colInicial = oReader["colInicial"] == DBNull.Value ? (Nullable<Int32>)null : Convert.ToInt32(oReader["colInicial"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='filFinal'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                plantillaasiento.filFinal = oReader["filFinal"] == DBNull.Value ? (Nullable<Int32>)null : Convert.ToInt32(oReader["filFinal"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='colFinal'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                plantillaasiento.colFinal = oReader["colFinal"] == DBNull.Value ? (Nullable<Int32>)null : Convert.ToInt32(oReader["colFinal"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='GlosaGeneral'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                plantillaasiento.GlosaGeneral = oReader["GlosaGeneral"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["GlosaGeneral"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='sumCCostos'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                plantillaasiento.sumCCostos = oReader["sumCCostos"] == DBNull.Value ? false : Convert.ToBoolean(oReader["sumCCostos"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='UsuarioRegistro'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				plantillaasiento.UsuarioRegistro = oReader["UsuarioRegistro"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["UsuarioRegistro"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='FechaRegistro'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				plantillaasiento.FechaRegistro = oReader["FechaRegistro"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["FechaRegistro"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='UsuarioModificacion'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				plantillaasiento.UsuarioModificacion = oReader["UsuarioModificacion"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["UsuarioModificacion"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='FechaModificacion'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				plantillaasiento.FechaModificacion = oReader["FechaModificacion"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["FechaModificacion"]);

            return  plantillaasiento;        
        }

        public PlantillaAsientoE InsertarPlantillaAsiento(PlantillaAsientoE plantillaasiento)
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_InsertarPlantillaAsiento", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = plantillaasiento.idEmpresa;
					oComando.Parameters.Add("@Descripcion", SqlDbType.VarChar, 100).Value = plantillaasiento.Descripcion;
					oComando.Parameters.Add("@idComprobante", SqlDbType.Char, 2).Value = plantillaasiento.idComprobante;
					oComando.Parameters.Add("@numFile", SqlDbType.Char, 2).Value = plantillaasiento.numFile;
					oComando.Parameters.Add("@idMoneda", SqlDbType.Char, 2).Value = plantillaasiento.idMoneda;
					oComando.Parameters.Add("@TipoVoucher", SqlDbType.Int).Value = plantillaasiento.TipoVoucher;
					oComando.Parameters.Add("@indExcel", SqlDbType.Bit).Value = plantillaasiento.indExcel;
                    oComando.Parameters.Add("@Hoja", SqlDbType.Int).Value = plantillaasiento.Hoja;
                    oComando.Parameters.Add("@filInicial", SqlDbType.Int).Value = plantillaasiento.filInicial;
					oComando.Parameters.Add("@colInicial", SqlDbType.Int).Value = plantillaasiento.colInicial;
					oComando.Parameters.Add("@filFinal", SqlDbType.Int).Value = plantillaasiento.filFinal;
					oComando.Parameters.Add("@colFinal", SqlDbType.Int).Value = plantillaasiento.colFinal;
                    oComando.Parameters.Add("@GlosaGeneral", SqlDbType.VarChar, 200).Value = plantillaasiento.GlosaGeneral;
                    oComando.Parameters.Add("@sumCCostos", SqlDbType.Bit).Value = plantillaasiento.sumCCostos;
					oComando.Parameters.Add("@UsuarioRegistro", SqlDbType.VarChar, 20).Value = plantillaasiento.UsuarioRegistro;

                    oConexion.Open();
                    plantillaasiento.idPlantilla = Int32.Parse(oComando.ExecuteScalar().ToString());
                }
            }

            return plantillaasiento;
        }
        
        public PlantillaAsientoE ActualizarPlantillaAsiento(PlantillaAsientoE plantillaasiento)
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ActualizarPlantillaAsiento", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idPlantilla", SqlDbType.Int).Value = plantillaasiento.idPlantilla;
					oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = plantillaasiento.idEmpresa;
					oComando.Parameters.Add("@Descripcion", SqlDbType.VarChar, 100).Value = plantillaasiento.Descripcion;
					oComando.Parameters.Add("@idComprobante", SqlDbType.Char, 2).Value = plantillaasiento.idComprobante;
					oComando.Parameters.Add("@numFile", SqlDbType.Char, 2).Value = plantillaasiento.numFile;
					oComando.Parameters.Add("@idMoneda", SqlDbType.Char, 2).Value = plantillaasiento.idMoneda;
					oComando.Parameters.Add("@TipoVoucher", SqlDbType.Int).Value = plantillaasiento.TipoVoucher;
					oComando.Parameters.Add("@indExcel", SqlDbType.Bit).Value = plantillaasiento.indExcel;
                    oComando.Parameters.Add("@Hoja", SqlDbType.Int).Value = plantillaasiento.Hoja;
					oComando.Parameters.Add("@filInicial", SqlDbType.Int).Value = plantillaasiento.filInicial;
					oComando.Parameters.Add("@colInicial", SqlDbType.Int).Value = plantillaasiento.colInicial;
					oComando.Parameters.Add("@filFinal", SqlDbType.Int).Value = plantillaasiento.filFinal;
					oComando.Parameters.Add("@colFinal", SqlDbType.Int).Value = plantillaasiento.colFinal;
                    oComando.Parameters.Add("@GlosaGeneral", SqlDbType.VarChar, 200).Value = plantillaasiento.GlosaGeneral;
                    oComando.Parameters.Add("@sumCCostos", SqlDbType.Bit).Value = plantillaasiento.sumCCostos;
					oComando.Parameters.Add("@UsuarioModificacion", SqlDbType.VarChar, 20).Value = plantillaasiento.UsuarioModificacion;

                    oConexion.Open();
                    oComando.ExecuteNonQuery();
                }
            }

            return plantillaasiento;
        }        

        public Int32 EliminarPlantillaAsiento(Int32 idPlantilla)
        {
            Int32 resp = 0;
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_EliminarPlantillaAsiento", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;

                    oComando.Parameters.Add("@idPlantilla", SqlDbType.Int).Value = idPlantilla;

                    oConexion.Open();
                    resp = oComando.ExecuteNonQuery();
                }
            }

            return resp;
        }

        public List<PlantillaAsientoE> ListarPlantillaAsiento(Int32 idEmpresa)
        {
            List<PlantillaAsientoE> listaEntidad = new List<PlantillaAsientoE>();
            PlantillaAsientoE entidad = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ListarPlantillaAsiento", oConexion))
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
            }

            return listaEntidad;
        }

        public PlantillaAsientoE ObtenerPlantillaAsiento(Int32 idPlantilla, Int32 idEmpresa)
        {        
            PlantillaAsientoE plantillaasiento = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ObtenerPlantillaAsiento", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;

                    oComando.Parameters.Add("@idPlantilla", SqlDbType.Int).Value = idPlantilla;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;

                    oConexion.Open();
                    
                    using (SqlDataReader oReader = oComando.ExecuteReader())
                    {
                        while (oReader.Read())
                        {
                            plantillaasiento = LlenarEntidad(oReader);
                        }
                    }
                }
            }

            return plantillaasiento;
        }
    }
}