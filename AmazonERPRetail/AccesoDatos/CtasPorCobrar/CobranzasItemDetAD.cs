using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

using Entidades.CtasPorCobrar;
using AccesoDatos.Util;

namespace AccesoDatos.CtasPorCobrar
{
    public class CobranzasItemDetAD : DbConection
    {

        public CobranzasItemDetE LlenarEntidad(IDataReader oReader)
        {
            CobranzasItemDetE cobranzasitemdet = new CobranzasItemDetE();

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='item'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                cobranzasitemdet.item = oReader["item"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["item"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idPlanilla'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				cobranzasitemdet.idPlanilla = oReader["idPlanilla"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idPlanilla"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Recibo'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				cobranzasitemdet.Recibo = oReader["Recibo"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["Recibo"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idPersona'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                cobranzasitemdet.idPersona = oReader["idPersona"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idPersona"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idDocumento'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				cobranzasitemdet.idDocumento = oReader["idDocumento"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["idDocumento"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='numSerie'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				cobranzasitemdet.numSerie = oReader["numSerie"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["numSerie"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='numDocumento'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				cobranzasitemdet.numDocumento = oReader["numDocumento"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["numDocumento"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='fecEmision'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				cobranzasitemdet.fecEmision = oReader["fecEmision"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["fecEmision"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idMoneda'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				cobranzasitemdet.idMoneda = oReader["idMoneda"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["idMoneda"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Monto'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				cobranzasitemdet.Monto = oReader["Monto"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["Monto"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idMonedaReci'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				cobranzasitemdet.idMonedaReci = oReader["idMonedaReci"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["idMonedaReci"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='MontoReci'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				cobranzasitemdet.MontoReci = oReader["MontoReci"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["MontoReci"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='tipCambioReci'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				cobranzasitemdet.tipCambioReci = oReader["tipCambioReci"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["tipCambioReci"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='numVerPlanCuentas'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				cobranzasitemdet.numVerPlanCuentas = oReader["numVerPlanCuentas"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["numVerPlanCuentas"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='codCuenta'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				cobranzasitemdet.codCuenta = oReader["codCuenta"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["codCuenta"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='fecVencimiento'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                cobranzasitemdet.fecVencimiento = oReader["fecVencimiento"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(oReader["fecVencimiento"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idCtaCte'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                cobranzasitemdet.idCtaCte = oReader["idCtaCte"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idCtaCte"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idCtaCteItem'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                cobranzasitemdet.idCtaCteItem = oReader["idCtaCteItem"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idCtaCteItem"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idCtaCte45'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                cobranzasitemdet.idCtaCte45 = oReader["idCtaCte45"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idCtaCte45"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idCtaCteItem45'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                cobranzasitemdet.idCtaCteItem45 = oReader["idCtaCteItem45"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idCtaCteItem45"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='LetraEndosadaA'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                cobranzasitemdet.LetraEndosadaA = oReader["LetraEndosadaA"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["LetraEndosadaA"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='indTercero'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                cobranzasitemdet.indTercero = oReader["indTercero"] == DBNull.Value ? false : Convert.ToBoolean(oReader["indTercero"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='UsuarioRegistro'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				cobranzasitemdet.UsuarioRegistro = oReader["UsuarioRegistro"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["UsuarioRegistro"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='FechaRegistro'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				cobranzasitemdet.FechaRegistro = oReader["FechaRegistro"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["FechaRegistro"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='UsuarioModificacion'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				cobranzasitemdet.UsuarioModificacion = oReader["UsuarioModificacion"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["UsuarioModificacion"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='FechaModificacion'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				cobranzasitemdet.FechaModificacion = oReader["FechaModificacion"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["FechaModificacion"]);

            //Extensiones
            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Moneda'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                cobranzasitemdet.Moneda = oReader["Moneda"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["Moneda"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='MonedaReci'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                cobranzasitemdet.MonedaReci = oReader["MonedaReci"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["MonedaReci"]);
            
            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='RazonSocial'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                cobranzasitemdet.RazonSocial = oReader["RazonSocial"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["RazonSocial"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Ruc'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                cobranzasitemdet.Ruc = oReader["Ruc"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["Ruc"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='indEndosar'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                cobranzasitemdet.indEndosar = oReader["indEndosar"] == DBNull.Value ? false : Convert.ToBoolean(oReader["indEndosar"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='RazonSocialEndose'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                cobranzasitemdet.RazonSocialEndose = oReader["RazonSocialEndose"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["RazonSocialEndose"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='codPlanilla'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                cobranzasitemdet.codPlanilla = oReader["codPlanilla"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["codPlanilla"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='NroOperacion'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                cobranzasitemdet.NroOperacion = oReader["NroOperacion"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["NroOperacion"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='EstadoDoc'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                cobranzasitemdet.EstadoDoc = oReader["EstadoDoc"] == DBNull.Value ? false : Convert.ToBoolean(oReader["EstadoDoc"]);

            return  cobranzasitemdet;
        }

        public CobranzasItemDetE InsertarCobranzasItemDet(CobranzasItemDetE cobranzasitemdet)
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_InsertarCobranzasItemDet", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idPlanilla", SqlDbType.Int).Value = cobranzasitemdet.idPlanilla;
					oComando.Parameters.Add("@Recibo", SqlDbType.Int).Value = cobranzasitemdet.Recibo;
                    oComando.Parameters.Add("@idPersona", SqlDbType.Int).Value = cobranzasitemdet.idPersona;
                    oComando.Parameters.Add("@idDocumento", SqlDbType.VarChar, 2).Value = cobranzasitemdet.idDocumento;
					oComando.Parameters.Add("@numSerie", SqlDbType.VarChar, 20).Value = cobranzasitemdet.numSerie;
					oComando.Parameters.Add("@numDocumento", SqlDbType.VarChar, 20).Value = cobranzasitemdet.numDocumento;
					oComando.Parameters.Add("@fecEmision", SqlDbType.SmallDateTime).Value = cobranzasitemdet.fecEmision;
					oComando.Parameters.Add("@idMoneda", SqlDbType.VarChar, 2).Value = cobranzasitemdet.idMoneda;
					oComando.Parameters.Add("@Monto", SqlDbType.Decimal).Value = cobranzasitemdet.Monto;
					oComando.Parameters.Add("@idMonedaReci", SqlDbType.VarChar, 2).Value = cobranzasitemdet.idMonedaReci;
					oComando.Parameters.Add("@MontoReci", SqlDbType.Decimal).Value = cobranzasitemdet.MontoReci;
					oComando.Parameters.Add("@tipCambioReci", SqlDbType.Decimal).Value = cobranzasitemdet.tipCambioReci;
					oComando.Parameters.Add("@numVerPlanCuentas", SqlDbType.VarChar, 3).Value = cobranzasitemdet.numVerPlanCuentas;
					oComando.Parameters.Add("@codCuenta", SqlDbType.VarChar, 20).Value = cobranzasitemdet.codCuenta;
                    oComando.Parameters.Add("@fecVencimiento", SqlDbType.SmallDateTime).Value = cobranzasitemdet.fecVencimiento;
                    oComando.Parameters.Add("@idCtaCte", SqlDbType.Int).Value = cobranzasitemdet.idCtaCte;
                    oComando.Parameters.Add("@LetraEndosadaA", SqlDbType.Int).Value = cobranzasitemdet.LetraEndosadaA;
                    oComando.Parameters.Add("@indTercero", SqlDbType.Bit).Value = cobranzasitemdet.indTercero;
                    oComando.Parameters.Add("@UsuarioRegistro", SqlDbType.VarChar, 20).Value = cobranzasitemdet.UsuarioRegistro;

                    oConexion.Open();
                    cobranzasitemdet.item = Int32.Parse(oComando.ExecuteScalar().ToString());
                }
            }

            return cobranzasitemdet;
        }
        
        public CobranzasItemDetE ActualizarCobranzasItemDet(CobranzasItemDetE cobranzasitemdet)
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ActualizarCobranzasItemDet", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@item", SqlDbType.Int).Value = cobranzasitemdet.item;
                    oComando.Parameters.Add("@idPlanilla", SqlDbType.Int).Value = cobranzasitemdet.idPlanilla;
					oComando.Parameters.Add("@Recibo", SqlDbType.Int).Value = cobranzasitemdet.Recibo;
                    oComando.Parameters.Add("@idPersona", SqlDbType.Int).Value = cobranzasitemdet.idPersona;
					oComando.Parameters.Add("@idDocumento", SqlDbType.VarChar, 2).Value = cobranzasitemdet.idDocumento;
					oComando.Parameters.Add("@numSerie", SqlDbType.VarChar, 20).Value = cobranzasitemdet.numSerie;
					oComando.Parameters.Add("@numDocumento", SqlDbType.VarChar, 20).Value = cobranzasitemdet.numDocumento;
					oComando.Parameters.Add("@fecEmision", SqlDbType.SmallDateTime).Value = cobranzasitemdet.fecEmision;
					oComando.Parameters.Add("@idMoneda", SqlDbType.VarChar, 2).Value = cobranzasitemdet.idMoneda;
					oComando.Parameters.Add("@Monto", SqlDbType.Decimal).Value = cobranzasitemdet.Monto;
					oComando.Parameters.Add("@idMonedaReci", SqlDbType.VarChar, 2).Value = cobranzasitemdet.idMonedaReci;
					oComando.Parameters.Add("@MontoReci", SqlDbType.Decimal).Value = cobranzasitemdet.MontoReci;
					oComando.Parameters.Add("@tipCambioReci", SqlDbType.Decimal).Value = cobranzasitemdet.tipCambioReci;
					oComando.Parameters.Add("@numVerPlanCuentas", SqlDbType.VarChar, 3).Value = cobranzasitemdet.numVerPlanCuentas;
					oComando.Parameters.Add("@codCuenta", SqlDbType.VarChar, 20).Value = cobranzasitemdet.codCuenta;
                    oComando.Parameters.Add("@fecVencimiento", SqlDbType.SmallDateTime).Value = cobranzasitemdet.fecVencimiento;
                    oComando.Parameters.Add("@idCtaCte", SqlDbType.Int).Value = cobranzasitemdet.idCtaCte;
                    oComando.Parameters.Add("@LetraEndosadaA", SqlDbType.Int).Value = cobranzasitemdet.LetraEndosadaA;
                    oComando.Parameters.Add("@indTercero", SqlDbType.Bit).Value = cobranzasitemdet.indTercero;
                    oComando.Parameters.Add("@UsuarioModificacion", SqlDbType.VarChar, 20).Value = cobranzasitemdet.UsuarioModificacion;

                    oConexion.Open();
                    oComando.ExecuteNonQuery();
                }
            }

            return cobranzasitemdet;
        }        

        public int EliminarCobranzasItemDet(Int32 idPlanilla, Int32 Recibo, Int32 item)
        {
            int resp = 0;
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_EliminarCobranzasItemDet", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idPlanilla", SqlDbType.Int).Value = idPlanilla;
					oComando.Parameters.Add("@Recibo", SqlDbType.Int).Value = Recibo;
					oComando.Parameters.Add("@item", SqlDbType.Int).Value = item;

                    oConexion.Open();
                    resp = oComando.ExecuteNonQuery();
                }
            }

            return resp;
        }

        public List<CobranzasItemDetE> ListarCobranzasItemDet(Int32 idPlanilla, Int32 Recibo)
        {
            List<CobranzasItemDetE> listaEntidad = new List<CobranzasItemDetE>();

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ListarCobranzasItemDet", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idPlanilla", SqlDbType.Int).Value = idPlanilla;
                    oComando.Parameters.Add("@Recibo", SqlDbType.Int).Value = Recibo;

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
        
        public CobranzasItemDetE ObtenerCobranzasItemDet(Int32 idPlanilla, Int32 Recibo, Int32 item)
        {        
            CobranzasItemDetE cobranzasitemdet = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ObtenerCobranzasItemDet", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idPlanilla", SqlDbType.Int).Value = idPlanilla;
					oComando.Parameters.Add("@Recibo", SqlDbType.Int).Value = Recibo;
					oComando.Parameters.Add("@item", SqlDbType.Int).Value = item;

                    oConexion.Open();
                    
                    using (SqlDataReader oReader = oComando.ExecuteReader())
                    {
                        while (oReader.Read())
                        {
                            cobranzasitemdet = LlenarEntidad(oReader);
                        }
                    }
                }
            }

            return cobranzasitemdet;
        }

        public CobranzasItemDetE CobranzasItemDetPorDocumento(Int32 idEmpresa, String idDocumento, String numSerie, String numDocumento)
        {
            CobranzasItemDetE cobranzasitemdet = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_CobranzasItemDetPorDocumento", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@idDocumento", SqlDbType.VarChar, 2).Value = idDocumento;
                    oComando.Parameters.Add("@numSerie", SqlDbType.VarChar, 20).Value = numSerie;
                    oComando.Parameters.Add("@numDocumento", SqlDbType.VarChar, 20).Value = numDocumento;

                    oConexion.Open();

                    using (SqlDataReader oReader = oComando.ExecuteReader())
                    {
                        while (oReader.Read())
                        {
                            cobranzasitemdet = LlenarEntidad(oReader);
                        }
                    }
                }
            }

            return cobranzasitemdet;
        }

        public CobranzasItemDetE ActualizarCobranzasItemDetCtaCte(CobranzasItemDetE cobranzasitemdet)
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ActualizarCobranzasItemDetCtaCte", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@item", SqlDbType.Int).Value = cobranzasitemdet.item;
                    oComando.Parameters.Add("@idCtaCte", SqlDbType.Int).Value = cobranzasitemdet.idCtaCte;
                    oComando.Parameters.Add("@idCtaCteItem", SqlDbType.Int).Value = cobranzasitemdet.idCtaCteItem;
                    oComando.Parameters.Add("@idCtaCte45", SqlDbType.Int).Value = cobranzasitemdet.idCtaCte45;
                    oComando.Parameters.Add("@idCtaCteItem45", SqlDbType.Int).Value = cobranzasitemdet.idCtaCteItem45;
                    oComando.Parameters.Add("@UsuarioModificacion", SqlDbType.VarChar, 20).Value = cobranzasitemdet.UsuarioModificacion;

                    oConexion.Open();
                    oComando.ExecuteNonQuery();
                }
            }

            return cobranzasitemdet;
        }

        public List<CobranzasItemDetE> ListarCobranzasItemDetPorLetra(Int32 idEmpresa, Int32 idLocal, Int32 idPersona, String numLetra)
        {
            List<CobranzasItemDetE> listaEntidad = new List<CobranzasItemDetE>();

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ListarCobranzasItemDetPorLetra", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@idLocal", SqlDbType.Int).Value = idLocal;
                    oComando.Parameters.Add("@idPersona", SqlDbType.Int).Value = idPersona;
                    oComando.Parameters.Add("@numLetra", SqlDbType.VarChar, 20).Value = numLetra;

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

        public List<CobranzasItemDetE> ListarCobranzasLetrasPorPlanilla(Int32 idPlanilla)
        {
            List<CobranzasItemDetE> listaEntidad = new List<CobranzasItemDetE>();

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ListarCobranzasLetrasPorPlanilla", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idPlanilla", SqlDbType.Int).Value = idPlanilla;

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

        public List<CobranzasItemDetE> CobranzasItemDetPorPlanillaDifDoc(Int32 idPlanilla, String idDocumento, String numSerie, String numDocumento)
        {
            List<CobranzasItemDetE> listaEntidad = new List<CobranzasItemDetE>();

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_CobranzasItemDetPorPlanillaDifDoc", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idPlanilla", SqlDbType.Int).Value = idPlanilla;
                    oComando.Parameters.Add("@idDocumento", SqlDbType.VarChar, 2).Value = idDocumento;
                    oComando.Parameters.Add("@numSerie", SqlDbType.VarChar, 20).Value = numSerie;
                    oComando.Parameters.Add("@numDocumento", SqlDbType.VarChar, 20).Value = numDocumento;

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