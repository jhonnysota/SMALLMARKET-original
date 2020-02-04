using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

using Entidades.Almacen;
using AccesoDatos.Util;

namespace AccesoDatos.Almacen
{
    public class OrdenConversionAD : DbConection
    {

        public OrdenConversionE LlenarEntidad(IDataReader oReader)
        {
            OrdenConversionE ordenconversion = new OrdenConversionE();
            
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idEmpresa'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				ordenconversion.idEmpresa = oReader["idEmpresa"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idEmpresa"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idOrdenConversion'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				ordenconversion.idOrdenConversion = oReader["idOrdenConversion"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idOrdenConversion"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='FechaOperacion'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				ordenconversion.FechaOperacion = oReader["FechaOperacion"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["FechaOperacion"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Fecha'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                ordenconversion.Fecha = oReader["Fecha"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["Fecha"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Numero'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				ordenconversion.Numero = oReader["Numero"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["Numero"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='indGenerada'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				ordenconversion.indGenerada = oReader["indGenerada"] == DBNull.Value ? false : Convert.ToBoolean(oReader["indGenerada"]);
		

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='TotalPeso'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                ordenconversion.TotalPeso = oReader["TotalPeso"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["TotalPeso"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idMoneda'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                ordenconversion.idMoneda = oReader["idMoneda"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["idMoneda"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='TotalCosto'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                ordenconversion.TotalCosto = oReader["TotalCosto"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["TotalCosto"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idConcepto'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                ordenconversion.idConcepto = oReader["idConcepto"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idConcepto"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Observacion'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                ordenconversion.Observacion = oReader["Observacion"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["Observacion"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idDocumento'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                ordenconversion.idDocumento = oReader["idDocumento"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["idDocumento"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='numSerie'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                ordenconversion.numSerie = oReader["numSerie"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["numSerie"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='numDocumento'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                ordenconversion.numDocumento = oReader["numDocumento"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["numDocumento"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idOrdenCompra'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                ordenconversion.idOrdenCompra = oReader["idOrdenCompra"] == DBNull.Value ? 0 : Convert.ToInt64(oReader["idOrdenCompra"]);            

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='UsuarioRegistro'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				ordenconversion.UsuarioRegistro = oReader["UsuarioRegistro"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["UsuarioRegistro"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='FechaRegistro'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				ordenconversion.FechaRegistro = oReader["FechaRegistro"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["FechaRegistro"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='UsuarioModificacion'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				ordenconversion.UsuarioModificacion = oReader["UsuarioModificacion"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["UsuarioModificacion"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='FechaModificacion'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				ordenconversion.FechaModificacion = oReader["FechaModificacion"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["FechaModificacion"]);

            //Extensiones
            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='codArticulo'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                ordenconversion.codArticulo = oReader["codArticulo"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["codArticulo"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='NombreArt'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                ordenconversion.NombreArt = oReader["NombreArt"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["NombreArt"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Contenido'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                ordenconversion.Contenido = oReader["Contenido"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["Contenido"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='nomAlmacen'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                ordenconversion.nomAlmacen = oReader["nomAlmacen"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["nomAlmacen"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='nomUMedidaPres'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                ordenconversion.nomUMedidaPres = oReader["nomUMedidaPres"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["nomUMedidaPres"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='nomUMedidaEnv'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                ordenconversion.nomUMedidaEnv = oReader["nomUMedidaEnv"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["nomUMedidaEnv"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='nomTipoMov'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                ordenconversion.nomTipoMov = oReader["nomTipoMov"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["nomTipoMov"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='indIngreso'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                ordenconversion.indIngreso = oReader["indIngreso"] == DBNull.Value ? false : Convert.ToBoolean(oReader["indIngreso"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='NombreCompleto'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                ordenconversion.NombreCompleto = oReader["NombreCompleto"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["NombreCompleto"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='CostoUnitario'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                ordenconversion.CostoUnitario = oReader["CostoUnitario"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["CostoUnitario"]);

            return  ordenconversion;        
        }

        public OrdenConversionE InsertarOrdenConversion(OrdenConversionE ordenconversion)
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_InsertarOrdenConversion", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = ordenconversion.idEmpresa;
                    oComando.Parameters.Add("@FechaOperacion", SqlDbType.SmallDateTime).Value = ordenconversion.FechaOperacion;
                    oComando.Parameters.Add("@Fecha", SqlDbType.SmallDateTime).Value = ordenconversion.Fecha;
					oComando.Parameters.Add("@Numero", SqlDbType.VarChar, 20).Value = ordenconversion.Numero;
					oComando.Parameters.Add("@indGenerada", SqlDbType.Bit).Value = ordenconversion.indGenerada;
                    oComando.Parameters.Add("@TotalPeso", SqlDbType.Decimal).Value = ordenconversion.TotalPeso;
                    oComando.Parameters.Add("@idMoneda", SqlDbType.VarChar, 2).Value = ordenconversion.idMoneda;
                    oComando.Parameters.Add("@TotalCosto", SqlDbType.Decimal).Value = ordenconversion.TotalCosto;
                    oComando.Parameters.Add("@idConcepto", SqlDbType.Int).Value = ordenconversion.idConcepto;
                    oComando.Parameters.Add("@Observacion", SqlDbType.VarChar, 300).Value = ordenconversion.Observacion;
                    oComando.Parameters.Add("@idDocumento", SqlDbType.VarChar, 2).Value = ordenconversion.idDocumento;
                    oComando.Parameters.Add("@numSerie", SqlDbType.VarChar, 20).Value = ordenconversion.numSerie;
                    oComando.Parameters.Add("@numDocumento", SqlDbType.VarChar, 20).Value = ordenconversion.numDocumento;
                    oComando.Parameters.Add("@idOrdenCompra", SqlDbType.Int).Value = ordenconversion.idConcepto;
                    oComando.Parameters.Add("@UsuarioRegistro", SqlDbType.VarChar, 20).Value = ordenconversion.UsuarioRegistro;

                    oConexion.Open();
                    ordenconversion.idOrdenConversion = Int32.Parse(oComando.ExecuteScalar().ToString());
                }
            }

            return ordenconversion;
        }
        
        public OrdenConversionE ActualizarOrdenConversion(OrdenConversionE ordenconversion)
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ActualizarOrdenConversion", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = ordenconversion.idEmpresa;
					oComando.Parameters.Add("@idOrdenConversion", SqlDbType.Int).Value = ordenconversion.idOrdenConversion;
                    oComando.Parameters.Add("@FechaOperacion", SqlDbType.SmallDateTime).Value = ordenconversion.FechaOperacion;
                    oComando.Parameters.Add("@Fecha", SqlDbType.SmallDateTime).Value = ordenconversion.Fecha;
					oComando.Parameters.Add("@Numero", SqlDbType.VarChar, 20).Value = ordenconversion.Numero;
					oComando.Parameters.Add("@indGenerada", SqlDbType.Bit).Value = ordenconversion.indGenerada;
                    oComando.Parameters.Add("@TotalPeso", SqlDbType.Decimal).Value = ordenconversion.TotalPeso;
                    oComando.Parameters.Add("@idMoneda", SqlDbType.VarChar, 2).Value = ordenconversion.idMoneda;
                    oComando.Parameters.Add("@TotalCosto", SqlDbType.Decimal).Value = ordenconversion.TotalCosto;
                    oComando.Parameters.Add("@idConcepto", SqlDbType.Int).Value = ordenconversion.idConcepto;
                    oComando.Parameters.Add("@Observacion", SqlDbType.VarChar, 300).Value = ordenconversion.Observacion;
                    oComando.Parameters.Add("@idDocumento", SqlDbType.VarChar, 2).Value = ordenconversion.idDocumento;
                    oComando.Parameters.Add("@numSerie", SqlDbType.VarChar, 20).Value = ordenconversion.numSerie;
                    oComando.Parameters.Add("@numDocumento", SqlDbType.VarChar, 20).Value = ordenconversion.numDocumento;
                    oComando.Parameters.Add("@idOrdenCompra", SqlDbType.Int).Value = ordenconversion.idConcepto;
                    oComando.Parameters.Add("@UsuarioModificacion", SqlDbType.VarChar, 20).Value = ordenconversion.UsuarioModificacion;

                    oConexion.Open();
                    oComando.ExecuteNonQuery();
                }
            }

            return ordenconversion;
        }        
        
        public int EliminarOrdenConversion(Int32 idEmpresa, Int32 idOrdenConversion)
        {
            int resp = 0;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_EliminarOrdenConversion", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
					oComando.Parameters.Add("@idOrdenConversion", SqlDbType.Int).Value = idOrdenConversion;

                    oConexion.Open();
                    resp = oComando.ExecuteNonQuery();
                }
            }

            return resp;
        }

        public String GenerarNroConversion(Int32 idEmpresa, DateTime Fecha)
        {
            Int32 NroOP = 0;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_GenerarNroConversion", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@Fecha", SqlDbType.DateTime).Value = Fecha;

                    oConexion.Open();
                    NroOP = Convert.ToInt32(oComando.ExecuteScalar());
                }
            }

            return NroOP.ToString();
        }

        public List<OrdenConversionE> ListarOrdenConversion(Int32 idEmpresa, DateTime FechaIni, DateTime FechaFin, Int32 idConcepto, Int32 idArticulo, String desArticulo, String tipFecha)
        {
            List<OrdenConversionE> listaEntidad = new List<OrdenConversionE>();

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ListarOrdenConversion", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@FechaIni", SqlDbType.SmallDateTime).Value = FechaIni;
                    oComando.Parameters.Add("@FechaFin", SqlDbType.SmallDateTime).Value = FechaFin;
                    oComando.Parameters.Add("@idConcepto", SqlDbType.Int).Value = idConcepto;
                    oComando.Parameters.Add("@idArticulo", SqlDbType.Int).Value = idArticulo;
                    oComando.Parameters.Add("@desArticulo", SqlDbType.VarChar,50).Value = desArticulo;
                    oComando.Parameters.Add("@tipFecha", SqlDbType.Char, 1).Value = tipFecha;

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
        
        public OrdenConversionE ObtenerOrdenConversion(Int32 idEmpresa, Int32 idOrdenConversion)
        {        
            OrdenConversionE ordenconversion = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ObtenerOrdenConversion", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
					oComando.Parameters.Add("@idOrdenConversion", SqlDbType.Int).Value = idOrdenConversion;
                    oConexion.Open();
                    
                    using (SqlDataReader oReader = oComando.ExecuteReader())
                    {
                        while (oReader.Read())
                        {
                            ordenconversion = LlenarEntidad(oReader);
                        }
                    }
                }
            }

            return ordenconversion;
        }

        public List<OrdenConversionE> ListarOrdenConversionProvision(Int32 idEmpresa, DateTime FechaIni, DateTime FechaFin)
        {
            List<OrdenConversionE> listaEntidad = new List<OrdenConversionE>();

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ListarOrdenConversionProvision", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@FechaIni", SqlDbType.SmallDateTime).Value = FechaIni;
                    oComando.Parameters.Add("@FechaFin", SqlDbType.SmallDateTime).Value = FechaFin;

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

    }
}