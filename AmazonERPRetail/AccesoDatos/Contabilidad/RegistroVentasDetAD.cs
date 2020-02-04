using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

using Entidades.Contabilidad;
using AccesoDatos.Util;

namespace AccesoDatos.Contabilidad
{
    public class RegistroVentasDetAD : DbConection
    {

        public RegistroVentasDetE LlenarEntidad(IDataReader oReader)
        {
            RegistroVentasDetE registroventasdet = new RegistroVentasDetE();
            
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idVentas'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				registroventasdet.idVentas = oReader["idVentas"] == DBNull.Value ? 0: Convert.ToInt32(oReader["idVentas"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idEmpresa'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				registroventasdet.idEmpresa = oReader["idEmpresa"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idEmpresa"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idLocal'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				registroventasdet.idLocal = oReader["idLocal"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idLocal"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idCCostos'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				registroventasdet.idCCostos = oReader["idCCostos"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["idCCostos"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idDocumento'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				registroventasdet.idDocumento = oReader["idDocumento"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["idDocumento"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='numSerie'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				registroventasdet.numSerie = oReader["numSerie"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["numSerie"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='numDocumentoIni'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				registroventasdet.numDocumentoIni = oReader["numDocumentoIni"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["numDocumentoIni"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='numDocumentoFin'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				registroventasdet.numDocumentoFin = oReader["numDocumentoFin"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["numDocumentoFin"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='SerieMaquina'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				registroventasdet.SerieMaquina = oReader["SerieMaquina"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["SerieMaquina"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='FechaReal'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				registroventasdet.FechaReal = oReader["FechaReal"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["FechaReal"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='FechaTurno'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				registroventasdet.FechaTurno = oReader["FechaTurno"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["FechaTurno"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idArticulo'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                registroventasdet.idArticulo = oReader["idArticulo"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idArticulo"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idPersona'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				registroventasdet.idPersona = oReader["idPersona"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idPersona"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Placa'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				registroventasdet.Placa = oReader["Placa"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["Placa"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='OpeInafecta'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				registroventasdet.OpeInafecta = oReader["OpeInafecta"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["OpeInafecta"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='BaseImponible'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				registroventasdet.BaseImponible = oReader["BaseImponible"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["BaseImponible"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Igv'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				registroventasdet.Igv = oReader["Igv"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["Igv"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Total'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				registroventasdet.Total = oReader["Total"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["Total"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Recaudo'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				registroventasdet.Recaudo = oReader["Recaudo"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["Recaudo"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Cantidad'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				registroventasdet.Cantidad = oReader["Cantidad"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["Cantidad"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idTipoUmedida'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				registroventasdet.idTipoUmedida = oReader["idTipoUmedida"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idTipoUmedida"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idUmedida'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				registroventasdet.idUmedida = oReader["idUmedida"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idUmedida"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idDocumentoRef'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				registroventasdet.idDocumentoRef = oReader["idDocumentoRef"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["idDocumentoRef"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='numSerieRef'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				registroventasdet.numSerieRef = oReader["numSerieRef"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["numSerieRef"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='numDocumentoRef'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				registroventasdet.numDocumentoRef = oReader["numDocumentoRef"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["numDocumentoRef"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='FechaRef'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                registroventasdet.FechaRef = oReader["FechaRef"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["FechaRef"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Sistema'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                registroventasdet.Sistema = oReader["Sistema"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["Sistema"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='UsuarioRegistro'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				registroventasdet.UsuarioRegistro = oReader["UsuarioRegistro"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["UsuarioRegistro"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='FechaRegistro'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				registroventasdet.FechaRegistro = oReader["FechaRegistro"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["FechaRegistro"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='UsuarioModificacion'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				registroventasdet.UsuarioModificacion = oReader["UsuarioModificacion"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["UsuarioModificacion"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='FechaModificacion'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				registroventasdet.FechaModificacion = oReader["FechaModificacion"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["FechaModificacion"]);

            //Extensiones
            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='codCuentaVenta'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                registroventasdet.codCuentaVenta = oReader["codCuentaVenta"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["codCuentaVenta"]);
            
            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='codCuentaVenta12'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                registroventasdet.codCuentaVenta12 = oReader["codCuentaVenta12"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["codCuentaVenta12"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='RazonSocial'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                registroventasdet.RazonSocial = oReader["RazonSocial"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["RazonSocial"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='AbrevCCostos'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                registroventasdet.AbrevCCostos = oReader["AbrevCCostos"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["AbrevCCostos"]);

            return  registroventasdet;        
        }

        public RegistroVentasDetE InsertarRegistroVentasDet(RegistroVentasDetE registroventasdet)
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_InsertarRegistroVentasDet", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = registroventasdet.idEmpresa;
					oComando.Parameters.Add("@idLocal", SqlDbType.Int).Value = registroventasdet.idLocal;
					oComando.Parameters.Add("@idCCostos", SqlDbType.VarChar, 20).Value = registroventasdet.idCCostos;
					oComando.Parameters.Add("@idDocumento", SqlDbType.VarChar, 2).Value = registroventasdet.idDocumento;
					oComando.Parameters.Add("@numSerie", SqlDbType.VarChar, 20).Value = registroventasdet.numSerie;
					oComando.Parameters.Add("@numDocumentoIni", SqlDbType.VarChar, 20).Value = registroventasdet.numDocumentoIni;
					oComando.Parameters.Add("@numDocumentoFin", SqlDbType.VarChar, 20).Value = registroventasdet.numDocumentoFin;
					oComando.Parameters.Add("@SerieMaquina", SqlDbType.VarChar, 20).Value = registroventasdet.SerieMaquina;
					oComando.Parameters.Add("@FechaReal", SqlDbType.SmallDateTime).Value = registroventasdet.FechaReal;
					oComando.Parameters.Add("@FechaTurno", SqlDbType.SmallDateTime).Value = registroventasdet.FechaTurno;
                    oComando.Parameters.Add("@idArticulo", SqlDbType.Int).Value = registroventasdet.idArticulo;
                    oComando.Parameters.Add("@idPersona", SqlDbType.Int).Value = registroventasdet.idPersona;
					oComando.Parameters.Add("@Placa", SqlDbType.VarChar, 20).Value = registroventasdet.Placa;
					oComando.Parameters.Add("@OpeInafecta", SqlDbType.VarChar, 20).Value = registroventasdet.OpeInafecta;
					oComando.Parameters.Add("@BaseImponible", SqlDbType.Decimal).Value = registroventasdet.BaseImponible;
					oComando.Parameters.Add("@Igv", SqlDbType.Decimal).Value = registroventasdet.Igv;
					oComando.Parameters.Add("@Total", SqlDbType.Decimal).Value = registroventasdet.Total;
					oComando.Parameters.Add("@Recaudo", SqlDbType.Decimal).Value = registroventasdet.Recaudo;
					oComando.Parameters.Add("@Cantidad", SqlDbType.Decimal).Value = registroventasdet.Cantidad;
					oComando.Parameters.Add("@idTipoUmedida", SqlDbType.Int).Value = registroventasdet.idTipoUmedida;
					oComando.Parameters.Add("@idUmedida", SqlDbType.Int).Value = registroventasdet.idUmedida;
					oComando.Parameters.Add("@idDocumentoRef", SqlDbType.VarChar, 2).Value = registroventasdet.idDocumentoRef;
					oComando.Parameters.Add("@numSerieRef", SqlDbType.VarChar, 20).Value = registroventasdet.numSerieRef;
					oComando.Parameters.Add("@numDocumentoRef", SqlDbType.VarChar, 20).Value = registroventasdet.numDocumentoRef;
                    oComando.Parameters.Add("@FechaRef", SqlDbType.SmallDateTime).Value = registroventasdet.FechaRef;
                    oComando.Parameters.Add("@Sistema", SqlDbType.VarChar, 3).Value = registroventasdet.Sistema;
                    oComando.Parameters.Add("@UsuarioRegistro", SqlDbType.VarChar, 20).Value = registroventasdet.UsuarioRegistro;

                    oConexion.Open();
                    registroventasdet.idVentas = Int32.Parse(oComando.ExecuteScalar().ToString());
                }
            }

            return registroventasdet;
        }
        
        public RegistroVentasDetE ActualizarRegistroVentasDet(RegistroVentasDetE registroventasdet)
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ActualizarRegistroVentasDet", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = registroventasdet.idEmpresa;
					oComando.Parameters.Add("@idLocal", SqlDbType.Int).Value = registroventasdet.idLocal;
					oComando.Parameters.Add("@idCCostos", SqlDbType.VarChar, 20).Value = registroventasdet.idCCostos;
					oComando.Parameters.Add("@idDocumento", SqlDbType.VarChar, 2).Value = registroventasdet.idDocumento;
					oComando.Parameters.Add("@numSerie", SqlDbType.VarChar, 20).Value = registroventasdet.numSerie;
					oComando.Parameters.Add("@numDocumentoIni", SqlDbType.VarChar, 20).Value = registroventasdet.numDocumentoIni;
					oComando.Parameters.Add("@numDocumentoFin", SqlDbType.VarChar, 20).Value = registroventasdet.numDocumentoFin;
					oComando.Parameters.Add("@SerieMaquina", SqlDbType.VarChar, 20).Value = registroventasdet.SerieMaquina;
					oComando.Parameters.Add("@FechaReal", SqlDbType.SmallDateTime).Value = registroventasdet.FechaReal;
					oComando.Parameters.Add("@FechaTurno", SqlDbType.SmallDateTime).Value = registroventasdet.FechaTurno;
                    oComando.Parameters.Add("@idArticulo", SqlDbType.Int).Value = registroventasdet.idArticulo;
                    oComando.Parameters.Add("@idPersona", SqlDbType.Int).Value = registroventasdet.idPersona;
                    oComando.Parameters.Add("@Placa", SqlDbType.VarChar, 20).Value = registroventasdet.Placa;
					oComando.Parameters.Add("@OpeInafecta", SqlDbType.VarChar, 20).Value = registroventasdet.OpeInafecta;
					oComando.Parameters.Add("@BaseImponible", SqlDbType.Decimal).Value = registroventasdet.BaseImponible;
					oComando.Parameters.Add("@Igv", SqlDbType.Decimal).Value = registroventasdet.Igv;
					oComando.Parameters.Add("@Total", SqlDbType.Decimal).Value = registroventasdet.Total;
					oComando.Parameters.Add("@Recaudo", SqlDbType.Decimal).Value = registroventasdet.Recaudo;
					oComando.Parameters.Add("@Cantidad", SqlDbType.Decimal).Value = registroventasdet.Cantidad;
					oComando.Parameters.Add("@idTipoUmedida", SqlDbType.Int).Value = registroventasdet.idTipoUmedida;
					oComando.Parameters.Add("@idUmedida", SqlDbType.Int).Value = registroventasdet.idUmedida;
					oComando.Parameters.Add("@idDocumentoRef", SqlDbType.VarChar, 2).Value = registroventasdet.idDocumentoRef;
					oComando.Parameters.Add("@numSerieRef", SqlDbType.VarChar, 20).Value = registroventasdet.numSerieRef;
					oComando.Parameters.Add("@numDocumentoRef", SqlDbType.VarChar, 20).Value = registroventasdet.numDocumentoRef;
                    oComando.Parameters.Add("@FechaRef", SqlDbType.SmallDateTime).Value = registroventasdet.FechaRef;
                    oComando.Parameters.Add("@Sistema", SqlDbType.VarChar, 3).Value = registroventasdet.Sistema;
                    oComando.Parameters.Add("@UsuarioModificacion", SqlDbType.VarChar, 20).Value = registroventasdet.UsuarioModificacion;

                    oConexion.Open();
                    oComando.ExecuteNonQuery();
                }
            }

            return registroventasdet;
        }        

        public int EliminarRegistroVentasDet(Int32 idEmpresa, Int32 idLocal, String idCCostos, String Sistema, DateTime fecIni, DateTime fecFin)
        {
            int resp = 0;
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_EliminarRegistroVentasDet", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@idLocal", SqlDbType.Int).Value = idLocal;
                    oComando.Parameters.Add("@idCCostos", SqlDbType.VarChar, 20).Value = idCCostos;
                    oComando.Parameters.Add("@Sistema", SqlDbType.VarChar, 3).Value = Sistema;
                    oComando.Parameters.Add("@fecIni", SqlDbType.SmallDateTime).Value = fecIni.Date;
                    oComando.Parameters.Add("@fecFin", SqlDbType.SmallDateTime).Value = fecFin.Date;

                    oConexion.Open();
                    resp = oComando.ExecuteNonQuery();
                }
            }

            return resp;
        }

        public List<RegistroVentasDetE> ListarRegistroVentasDet(Int32 idEmpresa, Int32 idLocal, String idCCostos, String Sistema, DateTime fecIni, DateTime fecFin)
        {
           List<RegistroVentasDetE> listaEntidad = new List<RegistroVentasDetE>();
           RegistroVentasDetE entidad = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ListarRegistroVentasDet", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@idLocal", SqlDbType.Int).Value = idLocal;
                    oComando.Parameters.Add("@idCCostos", SqlDbType.VarChar, 20).Value = idCCostos;
                    oComando.Parameters.Add("@Sistema", SqlDbType.VarChar, 3).Value = Sistema;
                    oComando.Parameters.Add("@fecIni", SqlDbType.SmallDateTime).Value = fecIni.Date;
                    oComando.Parameters.Add("@fecFin", SqlDbType.SmallDateTime).Value = fecFin.Date;

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
        
        public RegistroVentasDetE ObtenerRegistroVentasDet()
        {        
            RegistroVentasDetE registroventasdet = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ObtenerRegistroVentasDet", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oConexion.Open();
                    
                    using (SqlDataReader oReader = oComando.ExecuteReader())
                    {
                        while (oReader.Read())
                        {
                            registroventasdet = LlenarEntidad(oReader);
                        }
                    }
                }
            }

            return registroventasdet;
        }

    }
}