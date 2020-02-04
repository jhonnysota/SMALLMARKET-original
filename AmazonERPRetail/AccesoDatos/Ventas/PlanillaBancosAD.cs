using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

using Entidades.Ventas;
using AccesoDatos.Util;

namespace AccesoDatos.Ventas
{
    public class PlanillaBancosAD : DbConection
    {

        public PlanillaBancosE LlenarEntidad(IDataReader oReader)
        {
            PlanillaBancosE planillabancos = new PlanillaBancosE();
            
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idPlanillaBanco'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				planillabancos.idPlanillaBanco = oReader["idPlanillaBanco"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idPlanillaBanco"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idEmpresa'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				planillabancos.idEmpresa = oReader["idEmpresa"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idEmpresa"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idLocal'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				planillabancos.idLocal = oReader["idLocal"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idLocal"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Numero'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				planillabancos.Numero = oReader["Numero"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["Numero"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idBanco'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				planillabancos.idBanco = oReader["idBanco"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idBanco"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='numCuenta'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				planillabancos.numCuenta = oReader["numCuenta"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["numCuenta"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idMoneda'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				planillabancos.idMoneda = oReader["idMoneda"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["idMoneda"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Fecha'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				planillabancos.Fecha = oReader["Fecha"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["Fecha"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Producto'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				planillabancos.Producto = oReader["Producto"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["Producto"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='flagProtesto'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				planillabancos.flagProtesto = oReader["flagProtesto"] == DBNull.Value ? true : Convert.ToBoolean(oReader["flagProtesto"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='fecAbono'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				planillabancos.fecAbono = oReader["fecAbono"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(oReader["fecAbono"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='MontoAbono'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				planillabancos.MontoAbono = oReader["MontoAbono"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["MontoAbono"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='AnioPeriodo'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				planillabancos.AnioPeriodo = oReader["AnioPeriodo"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["AnioPeriodo"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='MesPeriodo'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				planillabancos.MesPeriodo = oReader["MesPeriodo"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["MesPeriodo"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idComprobante'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				planillabancos.idComprobante = oReader["idComprobante"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["idComprobante"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='numFile'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				planillabancos.numFile = oReader["numFile"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["numFile"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='numVoucher'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				planillabancos.numVoucher = oReader["numVoucher"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["numVoucher"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Generado'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				planillabancos.Generado = oReader["Generado"] == DBNull.Value ? false : Convert.ToBoolean(oReader["Generado"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='tipPlanilla'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				planillabancos.tipPlanilla = oReader["tipPlanilla"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["tipPlanilla"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idConceptoGasto'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				planillabancos.idConceptoGasto = oReader["idConceptoGasto"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idConceptoGasto"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idConceptoInteres'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                planillabancos.idConceptoInteres = oReader["idConceptoInteres"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idConceptoInteres"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Comision'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                planillabancos.Comision = oReader["Comision"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["Comision"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Interes'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                planillabancos.Interes = oReader["Interes"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["Interes"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idComprobanteRec'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				planillabancos.idComprobanteRec = oReader["idComprobanteRec"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["idComprobanteRec"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='numFileRec'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				planillabancos.numFileRec = oReader["numFileRec"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["numFileRec"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='numVoucherRec'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				planillabancos.numVoucherRec = oReader["numVoucherRec"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["numVoucherRec"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='GeneradoRec'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				planillabancos.GeneradoRec = oReader["GeneradoRec"] == DBNull.Value ? false : Convert.ToBoolean(oReader["GeneradoRec"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idDocumento'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				planillabancos.idDocumento = oReader["idDocumento"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["idDocumento"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='numDocumento'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                planillabancos.numDocumento = oReader["numDocumento"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["numDocumento"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='indEndosar'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                planillabancos.indEndosar = oReader["indEndosar"] == DBNull.Value ? false : Convert.ToBoolean(oReader["indEndosar"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idPersonaEndoso'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                planillabancos.idPersonaEndoso = oReader["idPersonaEndoso"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idPersonaEndoso"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Estado'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                planillabancos.Estado = oReader["Estado"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["Estado"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='UsuarioRegistro'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				planillabancos.UsuarioRegistro = oReader["UsuarioRegistro"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["UsuarioRegistro"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='FechaRegistro'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				planillabancos.FechaRegistro = oReader["FechaRegistro"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["FechaRegistro"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='UsuarioModificacion'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				planillabancos.UsuarioModificacion = oReader["UsuarioModificacion"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["UsuarioModificacion"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='FechaModificacion'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				planillabancos.FechaModificacion = oReader["FechaModificacion"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["FechaModificacion"]);

            //Extensiones
            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='desBanco'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                planillabancos.desBanco = oReader["desBanco"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["desBanco"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='desMoneda'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                planillabancos.desMoneda = oReader["desMoneda"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["desMoneda"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='desProducto'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                planillabancos.desProducto = oReader["desProducto"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["desProducto"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='RazonSocialEndoso'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                planillabancos.RazonSocialEndoso = oReader["RazonSocialEndoso"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["RazonSocialEndoso"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='RucEndoso'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                planillabancos.RucEndoso = oReader["RucEndoso"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["RucEndoso"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='MontoLetras'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                planillabancos.MontoLetras = oReader["MontoLetras"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["MontoLetras"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idPersonaEmpresa'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                planillabancos.idPersonaEmpresa = oReader["idPersonaEmpresa"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idPersonaEmpresa"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='RucEmpresa'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                planillabancos.RucEmpresa = oReader["RucEmpresa"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["RucEmpresa"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='RazonSocialEmpresa'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                planillabancos.RazonSocialEmpresa = oReader["RazonSocialEmpresa"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["RazonSocialEmpresa"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idAuxiliar'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                planillabancos.idAuxiliar = oReader["idAuxiliar"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idAuxiliar"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='RazonSocialAuxiliar'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                planillabancos.RazonSocialAuxiliar = oReader["RazonSocialAuxiliar"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["RazonSocialAuxiliar"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Letra'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                planillabancos.Letra = oReader["Letra"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["Letra"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='fecVenc'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                planillabancos.fecVenc = oReader["fecVenc"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["fecVenc"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='codCuenta'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                planillabancos.codCuenta = oReader["codCuenta"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["codCuenta"]);

            return  planillabancos;
        }

        public PlanillaBancosE InsertarPlanillaBancos(PlanillaBancosE planillabancos)
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_InsertarPlanillaBancos", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = planillabancos.idEmpresa;
					oComando.Parameters.Add("@idLocal", SqlDbType.Int).Value = planillabancos.idLocal;
					oComando.Parameters.Add("@Numero", SqlDbType.VarChar, 15).Value = planillabancos.Numero;
					oComando.Parameters.Add("@idBanco", SqlDbType.Int).Value = planillabancos.idBanco;
					oComando.Parameters.Add("@numCuenta", SqlDbType.VarChar, 20).Value = planillabancos.numCuenta;
					oComando.Parameters.Add("@idMoneda", SqlDbType.VarChar, 2).Value = planillabancos.idMoneda;
					oComando.Parameters.Add("@Fecha", SqlDbType.SmallDateTime).Value = planillabancos.Fecha;
					oComando.Parameters.Add("@Producto", SqlDbType.Char, 1).Value = planillabancos.Producto;
					oComando.Parameters.Add("@flagProtesto", SqlDbType.Bit).Value = planillabancos.flagProtesto;
					oComando.Parameters.Add("@fecAbono", SqlDbType.SmallDateTime).Value = planillabancos.fecAbono;
					oComando.Parameters.Add("@MontoAbono", SqlDbType.Decimal).Value = planillabancos.MontoAbono;
                    oComando.Parameters.Add("@AnioPeriodo", SqlDbType.VarChar, 4).Value = planillabancos.AnioPeriodo;
                    oComando.Parameters.Add("@MesPeriodo", SqlDbType.VarChar, 2).Value = planillabancos.MesPeriodo;
                    oComando.Parameters.Add("@idComprobante", SqlDbType.VarChar, 2).Value = planillabancos.idComprobante;
                    oComando.Parameters.Add("@numFile", SqlDbType.VarChar, 2).Value = planillabancos.numFile;
                    oComando.Parameters.Add("@tipPlanilla", SqlDbType.Char, 1).Value = planillabancos.tipPlanilla;
					oComando.Parameters.Add("@idConceptoGasto", SqlDbType.Int).Value = planillabancos.idConceptoGasto;
                    oComando.Parameters.Add("@idConceptoInteres", SqlDbType.Int).Value = planillabancos.idConceptoInteres;
                    oComando.Parameters.Add("@Comision", SqlDbType.Decimal).Value = planillabancos.Comision;
                    oComando.Parameters.Add("@Interes", SqlDbType.Decimal).Value = planillabancos.Interes;
                    oComando.Parameters.Add("@idComprobanteRec", SqlDbType.VarChar, 2).Value = planillabancos.idComprobanteRec;
                    oComando.Parameters.Add("@numFileRec", SqlDbType.VarChar, 2).Value = planillabancos.numFileRec;
                    oComando.Parameters.Add("@idDocumento", SqlDbType.VarChar, 2).Value = planillabancos.idDocumento;
                    oComando.Parameters.Add("@numDocumento", SqlDbType.VarChar, 20).Value = planillabancos.numDocumento;
                    oComando.Parameters.Add("@indEndosar", SqlDbType.Bit).Value = planillabancos.indEndosar;
                    oComando.Parameters.Add("@idPersonaEndoso", SqlDbType.Int).Value = planillabancos.idPersonaEndoso;
                    oComando.Parameters.Add("@UsuarioRegistro", SqlDbType.VarChar, 20).Value = planillabancos.UsuarioRegistro;

                    oConexion.Open();
                    planillabancos.idPlanillaBanco = Int32.Parse(oComando.ExecuteScalar().ToString());
                }
            }

            return planillabancos;
        }
        
        public PlanillaBancosE ActualizarPlanillaBancos(PlanillaBancosE planillabancos)
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ActualizarPlanillaBancos", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idPlanillaBanco", SqlDbType.Int).Value = planillabancos.idPlanillaBanco;
					oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = planillabancos.idEmpresa;
					oComando.Parameters.Add("@idLocal", SqlDbType.Int).Value = planillabancos.idLocal;
					oComando.Parameters.Add("@Numero", SqlDbType.VarChar, 15).Value = planillabancos.Numero;
					oComando.Parameters.Add("@idBanco", SqlDbType.Int).Value = planillabancos.idBanco;
					oComando.Parameters.Add("@numCuenta", SqlDbType.VarChar, 20).Value = planillabancos.numCuenta;
					oComando.Parameters.Add("@idMoneda", SqlDbType.VarChar, 2).Value = planillabancos.idMoneda;
					oComando.Parameters.Add("@Fecha", SqlDbType.SmallDateTime).Value = planillabancos.Fecha;
					oComando.Parameters.Add("@Producto", SqlDbType.Char, 1).Value = planillabancos.Producto;
					oComando.Parameters.Add("@flagProtesto", SqlDbType.Bit).Value = planillabancos.flagProtesto;
					oComando.Parameters.Add("@fecAbono", SqlDbType.SmallDateTime).Value = planillabancos.fecAbono;
					oComando.Parameters.Add("@MontoAbono", SqlDbType.Decimal).Value = planillabancos.MontoAbono;
                    oComando.Parameters.Add("@AnioPeriodo", SqlDbType.VarChar, 4).Value = planillabancos.AnioPeriodo;
                    oComando.Parameters.Add("@MesPeriodo", SqlDbType.VarChar, 2).Value = planillabancos.MesPeriodo;
                    oComando.Parameters.Add("@idComprobante", SqlDbType.VarChar, 2).Value = planillabancos.idComprobante;
                    oComando.Parameters.Add("@numFile", SqlDbType.VarChar, 2).Value = planillabancos.numFile;
                    oComando.Parameters.Add("@tipPlanilla", SqlDbType.Char, 1).Value = planillabancos.tipPlanilla;
                    oComando.Parameters.Add("@idConceptoGasto", SqlDbType.Int).Value = planillabancos.idConceptoGasto;
                    oComando.Parameters.Add("@idConceptoInteres", SqlDbType.Int).Value = planillabancos.idConceptoInteres;
                    oComando.Parameters.Add("@Comision", SqlDbType.Decimal).Value = planillabancos.Comision;
                    oComando.Parameters.Add("@Interes", SqlDbType.Decimal).Value = planillabancos.Interes;
                    oComando.Parameters.Add("@idComprobanteRec", SqlDbType.VarChar, 2).Value = planillabancos.idComprobanteRec;
                    oComando.Parameters.Add("@numFileRec", SqlDbType.VarChar, 2).Value = planillabancos.numFileRec;
                    oComando.Parameters.Add("@idDocumento", SqlDbType.VarChar, 2).Value = planillabancos.idDocumento;
                    oComando.Parameters.Add("@numDocumento", SqlDbType.VarChar, 20).Value = planillabancos.numDocumento;
                    oComando.Parameters.Add("@indEndosar", SqlDbType.Bit).Value = planillabancos.indEndosar;
                    oComando.Parameters.Add("@idPersonaEndoso", SqlDbType.Int).Value = planillabancos.idPersonaEndoso;
                    oComando.Parameters.Add("@UsuarioModificacion", SqlDbType.VarChar, 20).Value = planillabancos.UsuarioModificacion;

                    oConexion.Open();
                    oComando.ExecuteNonQuery();
                }
            }

            return planillabancos;
        }        

        public int EliminarPlanillaBancos(Int32 idPlanillaBanco)
        {
            int resp = 0;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_EliminarPlanillaBancos", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idPlanillaBanco", SqlDbType.Int).Value = idPlanillaBanco;

                    oConexion.Open();
                    resp = oComando.ExecuteNonQuery();
                }
            }

            return resp;
        }

        public List<PlanillaBancosE> ListarPlanillaBancos(Int32 idEmpresa, Int32 idLocal, Int32 idBanco, String Producto, String tipFecha, DateTime fecIni, DateTime fecFin, String Tipo)
        {
            List<PlanillaBancosE> listaEntidad = new List<PlanillaBancosE>();

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ListarPlanillaBancos", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@idLocal", SqlDbType.Int).Value = idLocal;
                    oComando.Parameters.Add("@idBanco", SqlDbType.Int).Value = idBanco;
                    oComando.Parameters.Add("@Producto", SqlDbType.Char, 1).Value = Producto;
                    oComando.Parameters.Add("@tipFecha", SqlDbType.Char, 1).Value = tipFecha;
                    oComando.Parameters.Add("@fecIni", SqlDbType.SmallDateTime).Value = fecIni;
                    oComando.Parameters.Add("@fecFin", SqlDbType.SmallDateTime).Value = fecFin;
                    oComando.Parameters.Add("@Tipo", SqlDbType.Char, 1).Value = Tipo;

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
        
        public PlanillaBancosE ObtenerPlanillaBancos(Int32 idPlanillaBanco)
        {        
            PlanillaBancosE planillabancos = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ObtenerPlanillaBancos", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idPlanillaBanco", SqlDbType.Int).Value = idPlanillaBanco;

                    oConexion.Open();
                    
                    using (SqlDataReader oReader = oComando.ExecuteReader())
                    {
                        while (oReader.Read())
                        {
                            planillabancos = LlenarEntidad(oReader);
                        }
                    }
                }
            }

            return planillabancos;
        }

        public int ActualizarPlanillaBancosConta(Int32 idPlanillaBanco, String numVoucher, String numVoucherRec, String UsuarioModificacion, String Estado, Boolean Generar, String Tipo)
        {
            int resp = 0;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ActualizarPlanillaBancosConta", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idPlanillaBanco", SqlDbType.Int).Value = idPlanillaBanco;
                    oComando.Parameters.Add("@numVoucher", SqlDbType.VarChar, 9).Value = numVoucher;
                    oComando.Parameters.Add("@numVoucherRec", SqlDbType.VarChar, 9).Value = numVoucherRec;
                    oComando.Parameters.Add("@UsuarioModificacion", SqlDbType.VarChar, 20).Value = UsuarioModificacion;
                    oComando.Parameters.Add("@Estado", SqlDbType.Char, 1).Value = Estado;
                    oComando.Parameters.Add("@Generar", SqlDbType.Bit).Value = Generar;
                    oComando.Parameters.Add("@Tipo", SqlDbType.Char, 1).Value = Tipo;

                    oConexion.Open();
                    resp = oComando.ExecuteNonQuery();
                }
            }

            return resp;
        }

        public String GenerarNumPlanillaBancos(Int32 idEmpresa, Int32 idLocal, DateTime Fecha, String Producto)
        {
            String Codigo = String.Empty;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_GenerarNumPlanillaBancos", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@idLocal", SqlDbType.Int).Value = idLocal;
                    oComando.Parameters.Add("@Fecha", SqlDbType.SmallDateTime).Value = Fecha.Date;
                    oComando.Parameters.Add("@Producto", SqlDbType.VarChar, 1).Value = Producto;

                    oConexion.Open();

                    using (SqlDataReader oReader = oComando.ExecuteReader())
                    {
                        if (oReader.Read())
                        {
                            Codigo = oReader["Numero"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["Numero"]);
                        }
                    }
                }
            }

            return Codigo;
        }

        public String GenerarAsientoLetrasDiferidas(Int32 idPlanillaBanco, Int32 idEmpresa, Int32 idLocal, String Usuario)
        {
            String Codigo = String.Empty;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_GenerarAsientoLetrasDiferidas", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idPlanillaBanco", SqlDbType.Int).Value = idPlanillaBanco;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@idLocal", SqlDbType.Int).Value = idLocal;
                    oComando.Parameters.Add("@Usuario", SqlDbType.VarChar, 20).Value = Usuario;

                    oConexion.Open();

                    using (SqlDataReader oReader = oComando.ExecuteReader())
                    {
                        if (oReader.Read())
                        {
                            Codigo = (oReader["idComprobante"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["idComprobante"])) + " " +
                                    (oReader["numFile"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["numFile"])) + " " +
                                    (oReader["numVoucher"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["numVoucher"]));
                        }
                    }
                }
            }

            return Codigo;
        }

        public String GenerarAsientoReclasificacion(Int32 idPlanillaBanco, Int32 idEmpresa, Int32 idLocal, String Usuario)
        {
            String Codigo = String.Empty;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_GenerarAsientoReclasificacion", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idPlanillaBanco", SqlDbType.Int).Value = idPlanillaBanco;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@idLocal", SqlDbType.Int).Value = idLocal;
                    oComando.Parameters.Add("@Usuario", SqlDbType.VarChar, 20).Value = Usuario;

                    oConexion.Open();

                    using (SqlDataReader oReader = oComando.ExecuteReader())
                    {
                        if (oReader.Read())
                        {
                            Codigo = (oReader["idComprobanteRec"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["idComprobanteRec"])) + " " +
                                    (oReader["numFileRec"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["numFileRec"])) + " " +
                                    (oReader["numVoucherRec"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["numVoucherRec"]));
                        }
                    }
                }
            }

            return Codigo;
        }

        public List<PlanillaBancosE> ListarPlaBanLetrasEndosadas(Int32 idPersonaEndoso)
        {
            List<PlanillaBancosE> listaEntidad = new List<PlanillaBancosE>();

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ListarPlaBanLetrasEndosadas", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idPersonaEndoso", SqlDbType.Int).Value = idPersonaEndoso;

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