using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

using Entidades.Tesoreria;
using AccesoDatos.Util;

namespace AccesoDatos.Tesoreria
{
    public class OrdenPagoAD : DbConection
    {

        public OrdenPagoE LlenarEntidad(IDataReader oReader)
        {
            OrdenPagoE ordenpago = new OrdenPagoE();
            
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idEmpresa'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				ordenpago.idEmpresa = oReader["idEmpresa"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idEmpresa"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idLocal'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				ordenpago.idLocal = oReader["idLocal"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idLocal"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idOrdenPago'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				ordenpago.idOrdenPago = oReader["idOrdenPago"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idOrdenPago"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='codOrdenPago'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                ordenpago.codOrdenPago = oReader["codOrdenPago"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["codOrdenPago"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='codTipoPago'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				ordenpago.codTipoPago = oReader["codTipoPago"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["codTipoPago"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idConcepto'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                ordenpago.idConcepto = oReader["idConcepto"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idConcepto"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='codFormaPago'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				ordenpago.codFormaPago = oReader["codFormaPago"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["codFormaPago"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Fecha'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				ordenpago.Fecha = oReader["Fecha"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["Fecha"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idPersonaBeneficiario'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				ordenpago.idPersonaBeneficiario = oReader["idPersonaBeneficiario"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idPersonaBeneficiario"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idMoneda'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				ordenpago.idMoneda = oReader["idMoneda"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["idMoneda"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Monto'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				ordenpago.Monto = oReader["Monto"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["Monto"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='MontoPagoDet'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                ordenpago.MontoPagoDet = oReader["MontoPagoDet"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["MontoPagoDet"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='TipPartidaPresu'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                ordenpago.TipPartidaPresu = oReader["TipPartidaPresu"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["TipPartidaPresu"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='CodPartidaPresu'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                ordenpago.CodPartidaPresu = oReader["CodPartidaPresu"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["CodPartidaPresu"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='DesPartida'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                ordenpago.DesPartida = oReader["DesPartida"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["DesPartida"]);


            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='MontoDolar'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                ordenpago.MontoDolar = oReader["MontoDolar"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["MontoDolar"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idMonedaPago'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                ordenpago.idMonedaPago = oReader["idMonedaPago"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["idMonedaPago"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Glosa'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				ordenpago.Glosa = oReader["Glosa"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["Glosa"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='indEstado'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                ordenpago.indEstado = oReader["indEstado"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["indEstado"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='VieneDe'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                ordenpago.VieneDe = oReader["VieneDe"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["VieneDe"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='UsuarioRegistro'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                ordenpago.UsuarioRegistro = oReader["UsuarioRegistro"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["UsuarioRegistro"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='FechaRegistro'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				ordenpago.FechaRegistro = oReader["FechaRegistro"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["FechaRegistro"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='UsuarioModificacion'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                ordenpago.UsuarioModificacion = oReader["UsuarioModificacion"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["UsuarioModificacion"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='FechaModificacion'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				ordenpago.FechaModificacion = oReader["FechaModificacion"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["FechaModificacion"]);

            //Extensiones
            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idPersona'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                ordenpago.idPersona = oReader["idPersona"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idPersona"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='RUC'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                ordenpago.RUC = oReader["RUC"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["RUC"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='RazonSocial'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                ordenpago.RazonSocial = oReader["RazonSocial"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["RazonSocial"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='RucBen'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                ordenpago.RucBen = oReader["RucBen"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["RucBen"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='NombreBen'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                ordenpago.NombreBen = oReader["NombreBen"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["NombreBen"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='desMoneda'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                ordenpago.desMoneda = oReader["desMoneda"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["desMoneda"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='desMonedaPago'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                ordenpago.desMonedaPago = oReader["desMonedaPago"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["desMonedaPago"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='numVerPlanCuentas'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                ordenpago.numVerPlanCuentas = oReader["numVerPlanCuentas"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["numVerPlanCuentas"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='codCuenta'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                ordenpago.codCuenta = oReader["codCuenta"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["codCuenta"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='desTipoPago'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                ordenpago.desTipoPago = oReader["desTipoPago"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["desTipoPago"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idDocumento'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                ordenpago.idDocumento = oReader["idDocumento"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["idDocumento"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='serDocumento'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                ordenpago.serDocumento = oReader["serDocumento"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["serDocumento"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='numDocumento'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                ordenpago.numDocumento = oReader["numDocumento"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["numDocumento"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='FecDocumento'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                ordenpago.FecDocumento = oReader["FecDocumento"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["FecDocumento"]);


            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idBanco'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                ordenpago.idBanco = oReader["idBanco"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idBanco"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='tipCuenta'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                ordenpago.tipCuenta = oReader["tipCuenta"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["tipCuenta"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idMonedaBanco'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                ordenpago.idMonedaBanco = oReader["idMonedaBanco"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["idMonedaBanco"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='numCtaBancaria'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                ordenpago.numCtaBancaria = oReader["numCtaBancaria"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["numCtaBancaria"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='desBanco'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                ordenpago.desBanco = oReader["desBanco"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["desBanco"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='indPP'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                ordenpago.indPP = oReader["indPP"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["indPP"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='desVieneDe'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                ordenpago.desVieneDe = oReader["desVieneDe"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["desVieneDe"]);

            return ordenpago;        
        }

        public OrdenPagoE InsertarOrdenPago(OrdenPagoE ordenpago)
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_InsertarOrdenPago", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = ordenpago.idEmpresa;
					oComando.Parameters.Add("@idLocal", SqlDbType.Int).Value = ordenpago.idLocal;
                    oComando.Parameters.Add("@codOrdenPago", SqlDbType.VarChar, 10).Value = ordenpago.codOrdenPago;
                    oComando.Parameters.Add("@codTipoPago", SqlDbType.VarChar, 3).Value = ordenpago.codTipoPago;
                    oComando.Parameters.Add("@idConcepto", SqlDbType.Int).Value = ordenpago.idConcepto;
                    oComando.Parameters.Add("@codFormaPago", SqlDbType.VarChar, 3).Value = ordenpago.codFormaPago;
					oComando.Parameters.Add("@Fecha", SqlDbType.SmallDateTime).Value = ordenpago.Fecha.Date;
					oComando.Parameters.Add("@idPersonaBeneficiario", SqlDbType.Int).Value = ordenpago.idPersonaBeneficiario;
                    oComando.Parameters.Add("@idPersona", SqlDbType.Int).Value = ordenpago.idPersona;
                    oComando.Parameters.Add("@idMoneda", SqlDbType.VarChar, 2).Value = ordenpago.idMoneda;
					oComando.Parameters.Add("@Monto", SqlDbType.Decimal).Value = ordenpago.Monto;
                    oComando.Parameters.Add("@MontoDolar", SqlDbType.Decimal).Value = ordenpago.MontoDolar;
                    oComando.Parameters.Add("@Glosa", SqlDbType.VarChar, 250).Value = ordenpago.Glosa;
                    oComando.Parameters.Add("@VieneDe", SqlDbType.Char, 1).Value = ordenpago.VieneDe;
                    oComando.Parameters.Add("@UsuarioRegistro", SqlDbType.VarChar, 20).Value = ordenpago.UsuarioRegistro;

                    oConexion.Open();
                    ordenpago.idOrdenPago = Int32.Parse(oComando.ExecuteScalar().ToString());
                }
            }

            return ordenpago;
        }
        
        public OrdenPagoE ActualizarOrdenPago(OrdenPagoE ordenpago)
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ActualizarOrdenPago", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = ordenpago.idEmpresa;
					oComando.Parameters.Add("@idLocal", SqlDbType.Int).Value = ordenpago.idLocal;
					oComando.Parameters.Add("@idOrdenPago", SqlDbType.Int).Value = ordenpago.idOrdenPago;
                    oComando.Parameters.Add("@codOrdenPago", SqlDbType.VarChar, 10).Value = ordenpago.codOrdenPago;
                    oComando.Parameters.Add("@codTipoPago", SqlDbType.VarChar, 3).Value = ordenpago.codTipoPago;
                    oComando.Parameters.Add("@idConcepto", SqlDbType.Int).Value = ordenpago.idConcepto;
                    oComando.Parameters.Add("@codFormaPago", SqlDbType.VarChar, 3).Value = ordenpago.codFormaPago;
					oComando.Parameters.Add("@Fecha", SqlDbType.DateTime).Value = ordenpago.Fecha.Date;
					oComando.Parameters.Add("@idPersonaBeneficiario", SqlDbType.Int).Value = ordenpago.idPersonaBeneficiario;
                    oComando.Parameters.Add("@idPersona", SqlDbType.Int).Value = ordenpago.idPersona;
                    oComando.Parameters.Add("@idMoneda", SqlDbType.VarChar, 2).Value = ordenpago.idMoneda;
					oComando.Parameters.Add("@Monto", SqlDbType.Decimal).Value = ordenpago.Monto;
                    oComando.Parameters.Add("@MontoDolar", SqlDbType.Decimal).Value = ordenpago.MontoDolar;
                    oComando.Parameters.Add("@Glosa", SqlDbType.VarChar, 250).Value = ordenpago.Glosa;
					oComando.Parameters.Add("@UsuarioModificacion", SqlDbType.VarChar, 20).Value = ordenpago.UsuarioModificacion;

                    oConexion.Open();
                    oComando.ExecuteNonQuery();
                }
            }

            return ordenpago;
        }        

        public int EliminarOrdenPago(Int32 idOrdenPago)
        {
            int resp = 0;
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_EliminarOrdenPago", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
					oComando.Parameters.Add("@idOrdenPago", SqlDbType.Int).Value = idOrdenPago;

                    oConexion.Open();
                    resp = oComando.ExecuteNonQuery();
                }
            }

            return resp;
        }

        public int CambiarEstadoOP(Int32 idOrdenPago, String indEstado, String UsuarioModificacion)
        {
            int resp = 0;
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_CambiarEstadoOP", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idOrdenPago", SqlDbType.Int).Value = idOrdenPago;
                    oComando.Parameters.Add("@indEstado", SqlDbType.VarChar, 1).Value = indEstado;
                    oComando.Parameters.Add("@UsuarioModificacion", SqlDbType.VarChar, 20).Value = UsuarioModificacion;

                    oConexion.Open();
                    resp = oComando.ExecuteNonQuery();
                }
            }

            return resp;
        }

        public List<OrdenPagoE> ListarOrdenPago(Int32 idEmpresa, Int32 idLocal, String codOrdenPago, DateTime fecIni, DateTime fecFin, String indEstado)
        {
            List<OrdenPagoE> listaEntidad = new List<OrdenPagoE>();

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ListarOrdenPago", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@idLocal", SqlDbType.Int).Value = idLocal;
                    oComando.Parameters.Add("@codOrdenPago", SqlDbType.VarChar, 10).Value = codOrdenPago;
                    oComando.Parameters.Add("@fecIni", SqlDbType.SmallDateTime).Value = fecIni;
                    oComando.Parameters.Add("@fecFin", SqlDbType.SmallDateTime).Value = fecFin;
                    oComando.Parameters.Add("@indEstado", SqlDbType.Char, 1).Value = indEstado;

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

        public List<OrdenPagoE> ListarOrdenPagoPorIdPersona(Int32 idEmpresa, Int32 idLocal, Int32 idPersona, DateTime fecIni, DateTime fecFin)
        {
            List<OrdenPagoE> listaEntidad = new List<OrdenPagoE>();

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ListarOrdenPagoPorIdPersona", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@idLocal", SqlDbType.Int).Value = idLocal;
                    oComando.Parameters.Add("@idPersona", SqlDbType.Int).Value = idPersona;
                    oComando.Parameters.Add("@fecIni", SqlDbType.SmallDateTime).Value = fecIni;
                    oComando.Parameters.Add("@fecFin", SqlDbType.SmallDateTime).Value = fecFin;

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

        public OrdenPagoE ObtenerOrdenPago(Int32 idOrdenPago)
        {        
            OrdenPagoE ordenpago = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ObtenerOrdenPago", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
					oComando.Parameters.Add("@idOrdenPago", SqlDbType.Int).Value = idOrdenPago;

                    oConexion.Open();
                    
                    using (SqlDataReader oReader = oComando.ExecuteReader())
                    {
                        while (oReader.Read())
                        {
                            ordenpago = LlenarEntidad(oReader);
                        }
                    }
                }
            }

            return ordenpago;
        }

        public String GenerarNumOrdenPago(Int32 idEmpresa, Int32 idLocal)
        {
            String Codigo = String.Empty;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_GenerarNumOrdenPago", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@idLocal", SqlDbType.Int).Value = idLocal;

                    oConexion.Open();

                    using (SqlDataReader oReader = oComando.ExecuteReader())
                    {
                        if (oReader.Read())
                        {
                            Codigo = Convert.ToString(oReader["codOrdenPago"]);
                        }
                    }
                }
            }

            return Codigo;
        }

        public OrdenPagoE OpAbiertosPorIdPersona(Int32 idEmpresa, Int32 idLocal, Int32 idPersona)
        {
            OrdenPagoE ordenpago = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_OpAbiertosPorIdPersona", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@idLocal", SqlDbType.Int).Value = idLocal;
                    oComando.Parameters.Add("@idPersona", SqlDbType.Int).Value = idPersona;

                    oConexion.Open();

                    using (SqlDataReader oReader = oComando.ExecuteReader())
                    {
                        while (oReader.Read())
                        {
                            ordenpago = LlenarEntidad(oReader);
                        }
                    }
                }
            }

            return ordenpago;
        }

        public Int32 ObtenerOpProgramaPago(Int32 idEmpresa, Int32 idLocal, Int32 idOrdenPago)
        {
            int resp = 0;
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ObtenerOpProgramaPago", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@idLocal", SqlDbType.Int).Value = idLocal;
                    oComando.Parameters.Add("@idOrdenPago", SqlDbType.Int).Value = idOrdenPago;

                    oConexion.Open();
                    resp = Int32.Parse(oComando.ExecuteScalar().ToString());
                }
            }

            return resp;
        }

    }
}