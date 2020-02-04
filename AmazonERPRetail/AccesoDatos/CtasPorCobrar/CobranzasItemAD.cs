using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

using Entidades.CtasPorCobrar;
using AccesoDatos.Util;

namespace AccesoDatos.CtasPorCobrar
{
    public class CobranzasItemAD : DbConection
    {

        public CobranzasItemE LlenarEntidad(IDataReader oReader)
        {
            CobranzasItemE cobranzasitem = new CobranzasItemE();

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Recibo'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                cobranzasitem.Recibo = oReader["Recibo"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["Recibo"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idPlanilla'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				cobranzasitem.idPlanilla = oReader["idPlanilla"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idPlanilla"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Fecha'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				cobranzasitem.Fecha = oReader["Fecha"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["Fecha"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idMoneda'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				cobranzasitem.idMoneda = oReader["idMoneda"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["idMoneda"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Monto'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				cobranzasitem.Monto = oReader["Monto"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["Monto"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='TipoCobro'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				cobranzasitem.TipoCobro = oReader["TipoCobro"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["TipoCobro"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Descripcion'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				cobranzasitem.Descripcion = oReader["Descripcion"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["Descripcion"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='tipCambioReci'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				cobranzasitem.tipCambioReci = oReader["tipCambioReci"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["tipCambioReci"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='fecVencimiento'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				cobranzasitem.fecVencimiento = oReader["fecVencimiento"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(oReader["fecVencimiento"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='fecCobranza'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				cobranzasitem.fecCobranza = oReader["fecCobranza"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(oReader["fecCobranza"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idDocumento'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				cobranzasitem.idDocumento = oReader["idDocumento"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["idDocumento"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='numSerie'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				cobranzasitem.numSerie = oReader["numSerie"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["numSerie"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='numCheque'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				cobranzasitem.numCheque = oReader["numCheque"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["numCheque"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Comision'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				cobranzasitem.Comision = oReader["Comision"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["Comision"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Interes'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				cobranzasitem.Interes = oReader["Interes"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["Interes"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='numVerPlanCuentas'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				cobranzasitem.numVerPlanCuentas = oReader["numVerPlanCuentas"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["numVerPlanCuentas"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='codCuenta'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				cobranzasitem.codCuenta = oReader["codCuenta"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["codCuenta"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='codCuentaProvision'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				cobranzasitem.codCuentaProvision = oReader["codCuentaProvision"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["codCuentaProvision"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idConceptoGasto'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				cobranzasitem.idConceptoGasto = oReader["idConceptoGasto"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idConceptoGasto"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idConceptoInteres'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				cobranzasitem.idConceptoInteres = oReader["idConceptoInteres"] == DBNull.Value ? 0: Convert.ToInt32(oReader["idConceptoInteres"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idBanco'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				cobranzasitem.idBanco = oReader["idBanco"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idBanco"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='indPresupuesto'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				cobranzasitem.indPresupuesto = oReader["indPresupuesto"] == DBNull.Value ? false : Convert.ToBoolean(oReader["indPresupuesto"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='tipPartidaPresu'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				cobranzasitem.tipPartidaPresu = oReader["tipPartidaPresu"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["tipPartidaPresu"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idPartidaPresu'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				cobranzasitem.idPartidaPresu = oReader["idPartidaPresu"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["idPartidaPresu"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='cheDifCancelando'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				cobranzasitem.cheDifCancelando = oReader["cheDifCancelando"] == DBNull.Value ? false : Convert.ToBoolean(oReader["cheDifCancelando"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idPersona'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                cobranzasitem.idPersona = oReader["idPersona"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idPersona"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='indConciliado'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                cobranzasitem.indConciliado = oReader["indConciliado"] == DBNull.Value ? false : Convert.ToBoolean(oReader["indConciliado"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Estado'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                cobranzasitem.Estado = oReader["Estado"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["Estado"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='UsuarioRegistro'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				cobranzasitem.UsuarioRegistro = oReader["UsuarioRegistro"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["UsuarioRegistro"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='FechaRegistro'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				cobranzasitem.FechaRegistro = oReader["FechaRegistro"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["FechaRegistro"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='UsuarioModificacion'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				cobranzasitem.UsuarioModificacion = oReader["UsuarioModificacion"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["UsuarioModificacion"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='FechaModificacion'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				cobranzasitem.FechaModificacion = oReader["FechaModificacion"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["FechaModificacion"]);

            //Extensiones
            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='desBanco'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                cobranzasitem.desBanco = oReader["desBanco"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["desBanco"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='RucBanco'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                cobranzasitem.RucBanco = oReader["RucBanco"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["RucBanco"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='desCtaDetino'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                cobranzasitem.desCtaDetino = oReader["desCtaDetino"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["desCtaDetino"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='desCtaProvision'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                cobranzasitem.desCtaProvision = oReader["desCtaProvision"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["desCtaProvision"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='desCtaGastos'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                cobranzasitem.desCtaGastos = oReader["desCtaGastos"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["desCtaGastos"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='desCtaInteres'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                cobranzasitem.desCtaInteres = oReader["desCtaInteres"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["desCtaInteres"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='desMoneda'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                cobranzasitem.desMoneda = oReader["desMoneda"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["desMoneda"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='RucAuxiliar'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                cobranzasitem.RucAuxiliar = oReader["RucAuxiliar"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["RucAuxiliar"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='desAuxiliar'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                cobranzasitem.desAuxiliar = oReader["desAuxiliar"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["desAuxiliar"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='desTipoCobranza'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                cobranzasitem.desTipoCobranza = oReader["desTipoCobranza"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["desTipoCobranza"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='desLocal'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                cobranzasitem.desLocal = oReader["desLocal"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["desLocal"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='RazonSocialEmpresa'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                cobranzasitem.RazonSocialEmpresa = oReader["RazonSocialEmpresa"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["RazonSocialEmpresa"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='CuentaBancaria'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                cobranzasitem.CuentaBancaria = oReader["CuentaBancaria"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["CuentaBancaria"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='codPlanilla'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                cobranzasitem.codPlanilla = oReader["codPlanilla"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["codPlanilla"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Operacion'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                cobranzasitem.Operacion = oReader["Operacion"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["Operacion"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='FechaConciliacion'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                cobranzasitem.FechaConciliacion = oReader["FechaConciliacion"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(oReader["FechaConciliacion"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='MontoConciliacion'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                cobranzasitem.MontoConciliacion = oReader["MontoConciliacion"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["MontoConciliacion"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='numRegistros'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                cobranzasitem.numRegistros = oReader["numRegistros"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["numRegistros"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='numClientes'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                cobranzasitem.numClientes = oReader["numClientes"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["numClientes"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='tipDocumento'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                cobranzasitem.tipDocumento = oReader["tipDocumento"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["tipDocumento"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Documento'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                cobranzasitem.Documento = oReader["Documento"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["Documento"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Referencia'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                cobranzasitem.Referencia = oReader["Referencia"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["Referencia"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Saldo'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                cobranzasitem.Saldo = oReader["Saldo"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["Saldo"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Vendedor'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                cobranzasitem.Vendedor = oReader["Vendedor"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["Vendedor"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='CondicionPago'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                cobranzasitem.CondicionPago = oReader["CondicionPago"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["CondicionPago"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='GlosaBanco'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                cobranzasitem.GlosaBanco = oReader["GlosaBanco"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["GlosaBanco"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Orden'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                cobranzasitem.Orden = oReader["Orden"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["Orden"]);

            return  cobranzasitem;        
        }

        public CobranzasItemE InsertarCobranzasItem(CobranzasItemE cobranzasitem)
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_InsertarCobranzasItem", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
					oComando.Parameters.Add("@idPlanilla", SqlDbType.Int).Value = cobranzasitem.idPlanilla;
					oComando.Parameters.Add("@Fecha", SqlDbType.SmallDateTime).Value = cobranzasitem.Fecha;
					oComando.Parameters.Add("@idMoneda", SqlDbType.VarChar, 2).Value = cobranzasitem.idMoneda;
					oComando.Parameters.Add("@Monto", SqlDbType.Decimal).Value = cobranzasitem.Monto;
					oComando.Parameters.Add("@TipoCobro", SqlDbType.VarChar, 3).Value = cobranzasitem.TipoCobro;
					oComando.Parameters.Add("@Descripcion", SqlDbType.VarChar, 500).Value = cobranzasitem.Descripcion;
					oComando.Parameters.Add("@tipCambioReci", SqlDbType.Decimal).Value = cobranzasitem.tipCambioReci;
					oComando.Parameters.Add("@fecVencimiento", SqlDbType.SmallDateTime).Value = cobranzasitem.fecVencimiento;
					oComando.Parameters.Add("@fecCobranza", SqlDbType.SmallDateTime).Value = cobranzasitem.fecCobranza;
					oComando.Parameters.Add("@idDocumento", SqlDbType.VarChar, 2).Value = cobranzasitem.idDocumento;
					oComando.Parameters.Add("@numSerie", SqlDbType.VarChar, 4).Value = cobranzasitem.numSerie;
					oComando.Parameters.Add("@numCheque", SqlDbType.VarChar, 20).Value = cobranzasitem.numCheque;
					oComando.Parameters.Add("@Comision", SqlDbType.Decimal).Value = cobranzasitem.Comision;
                    oComando.Parameters.Add("@Interes", SqlDbType.Decimal).Value = cobranzasitem.Interes;
                    oComando.Parameters.Add("@numVerPlanCuentas", SqlDbType.VarChar, 3).Value = cobranzasitem.numVerPlanCuentas;
					oComando.Parameters.Add("@codCuenta", SqlDbType.VarChar, 20).Value = cobranzasitem.codCuenta;
					oComando.Parameters.Add("@codCuentaProvision", SqlDbType.VarChar, 20).Value = cobranzasitem.codCuentaProvision;
					oComando.Parameters.Add("@idConceptoGasto", SqlDbType.Int).Value = cobranzasitem.idConceptoGasto;
					oComando.Parameters.Add("@idConceptoInteres", SqlDbType.Int).Value = cobranzasitem.idConceptoInteres;
					oComando.Parameters.Add("@idBanco", SqlDbType.Int).Value = cobranzasitem.idBanco;
					oComando.Parameters.Add("@indPresupuesto", SqlDbType.Bit).Value = cobranzasitem.indPresupuesto;
					oComando.Parameters.Add("@tipPartidaPresu", SqlDbType.VarChar, 2).Value = cobranzasitem.tipPartidaPresu;
					oComando.Parameters.Add("@idPartidaPresu", SqlDbType.VarChar, 20).Value = cobranzasitem.idPartidaPresu;
					oComando.Parameters.Add("@cheDifCancelando", SqlDbType.Bit).Value = cobranzasitem.cheDifCancelando;
                    oComando.Parameters.Add("@idPersona", SqlDbType.Int).Value = cobranzasitem.idPersona;
                    oComando.Parameters.Add("@UsuarioRegistro", SqlDbType.VarChar, 20).Value = cobranzasitem.UsuarioRegistro;

                    oConexion.Open();
                    cobranzasitem.Recibo = Int32.Parse(oComando.ExecuteScalar().ToString());
                }
            }

            return cobranzasitem;
        }
        
        public CobranzasItemE ActualizarCobranzasItem(CobranzasItemE cobranzasitem)
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ActualizarCobranzasItem", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
					oComando.Parameters.Add("@idPlanilla", SqlDbType.Int).Value = cobranzasitem.idPlanilla;
					oComando.Parameters.Add("@Recibo", SqlDbType.Int).Value = cobranzasitem.Recibo;
					oComando.Parameters.Add("@Fecha", SqlDbType.SmallDateTime).Value = cobranzasitem.Fecha;
					oComando.Parameters.Add("@idMoneda", SqlDbType.VarChar, 2).Value = cobranzasitem.idMoneda;
					oComando.Parameters.Add("@Monto", SqlDbType.Decimal).Value = cobranzasitem.Monto;
					oComando.Parameters.Add("@TipoCobro", SqlDbType.VarChar, 3).Value = cobranzasitem.TipoCobro;
					oComando.Parameters.Add("@Descripcion", SqlDbType.VarChar, 500).Value = cobranzasitem.Descripcion;
					oComando.Parameters.Add("@tipCambioReci", SqlDbType.Decimal).Value = cobranzasitem.tipCambioReci;
					oComando.Parameters.Add("@fecVencimiento", SqlDbType.SmallDateTime).Value = cobranzasitem.fecVencimiento;
					oComando.Parameters.Add("@fecCobranza", SqlDbType.SmallDateTime).Value = cobranzasitem.fecCobranza;
					oComando.Parameters.Add("@idDocumento", SqlDbType.VarChar, 2).Value = cobranzasitem.idDocumento;
					oComando.Parameters.Add("@numSerie", SqlDbType.VarChar, 4).Value = cobranzasitem.numSerie;
					oComando.Parameters.Add("@numCheque", SqlDbType.VarChar, 20).Value = cobranzasitem.numCheque;
					oComando.Parameters.Add("@Comision", SqlDbType.Decimal).Value = cobranzasitem.Comision;
                    oComando.Parameters.Add("@Interes", SqlDbType.Decimal).Value = cobranzasitem.Interes;
                    oComando.Parameters.Add("@numVerPlanCuentas", SqlDbType.VarChar, 3).Value = cobranzasitem.numVerPlanCuentas;
					oComando.Parameters.Add("@codCuenta", SqlDbType.VarChar, 20).Value = cobranzasitem.codCuenta;
					oComando.Parameters.Add("@codCuentaProvision", SqlDbType.VarChar, 20).Value = cobranzasitem.codCuentaProvision;
                    oComando.Parameters.Add("@idConceptoGasto", SqlDbType.Int).Value = cobranzasitem.idConceptoGasto;
                    oComando.Parameters.Add("@idConceptoInteres", SqlDbType.Int).Value = cobranzasitem.idConceptoInteres;
                    oComando.Parameters.Add("@idBanco", SqlDbType.Int).Value = cobranzasitem.idBanco;
					oComando.Parameters.Add("@indPresupuesto", SqlDbType.Bit).Value = cobranzasitem.indPresupuesto;
					oComando.Parameters.Add("@tipPartidaPresu", SqlDbType.VarChar, 2).Value = cobranzasitem.tipPartidaPresu;
					oComando.Parameters.Add("@idPartidaPresu", SqlDbType.VarChar, 20).Value = cobranzasitem.idPartidaPresu;
					oComando.Parameters.Add("@cheDifCancelando", SqlDbType.Bit).Value = cobranzasitem.cheDifCancelando;
                    oComando.Parameters.Add("@idPersona", SqlDbType.Int).Value = cobranzasitem.idPersona;
                    oComando.Parameters.Add("@UsuarioModificacion", SqlDbType.VarChar, 20).Value = cobranzasitem.UsuarioModificacion;

                    oConexion.Open();
                    oComando.ExecuteNonQuery();
                }
            }

            return cobranzasitem;
        }        

        public int EliminarCobranzasItem(Int32 Recibo)
        {
            int resp = 0;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_EliminarCobranzasItem", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
					oComando.Parameters.Add("@Recibo", SqlDbType.Int).Value = Recibo;

                    oConexion.Open();
                    resp = oComando.ExecuteNonQuery();
                }
            }

            return resp;
        }

        public List<CobranzasItemE> ListarCobranzasItem(Int32 idPlanilla, Int32 idEmpresa)
        {
            List<CobranzasItemE> listaEntidad = new List<CobranzasItemE>();

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ListarCobranzasItem", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idPlanilla", SqlDbType.Int).Value = idPlanilla;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;

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
        
        public CobranzasItemE ObtenerCobranzasItem(Int32 Recibo)
        {        
            CobranzasItemE cobranzasitem = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ObtenerCobranzasItem", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
					oComando.Parameters.Add("@Recibo", SqlDbType.Int).Value = Recibo;

                    oConexion.Open();
                    
                    using (SqlDataReader oReader = oComando.ExecuteReader())
                    {
                        while (oReader.Read())
                        {
                            cobranzasitem = LlenarEntidad(oReader);
                        }
                    }
                }
            }

            return cobranzasitem;
        }

        public List<CobranzasItemE> ListarCobranzasItemPorCuenta(Int32 idEmpresa, String numVerPlanCuentas, String codCuenta, DateTime fecIni, DateTime fecFin)
        {
            List<CobranzasItemE> listaEntidad = new List<CobranzasItemE>();

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ListarCobranzasItemPorCuenta", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@numVerPlanCuentas", SqlDbType.VarChar, 3).Value = numVerPlanCuentas;
                    oComando.Parameters.Add("@codCuenta", SqlDbType.VarChar, 20).Value = codCuenta;
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

        public Int32 ActualizarCobranzasItemConciliado(Int32 idPlanilla, Int32 Recibo, Boolean indConciliado)
        {
            Int32 resp = 0;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ActualizarCobranzasItemConciliado", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idPlanilla", SqlDbType.Int).Value = idPlanilla;
                    oComando.Parameters.Add("@Recibo", SqlDbType.Int).Value = Recibo;
                    oComando.Parameters.Add("@indConciliado", SqlDbType.Bit).Value = indConciliado;

                    oConexion.Open();
                    resp = oComando.ExecuteNonQuery();
                }
            }

            return resp;
        }

        public List<CobranzasItemE> ReporteCobranzasConciliados(Int32 idEmpresa, String numVerPlanCuentas, String codCuenta, DateTime fecIni, DateTime fecFin, Int32 TipoReporte)
        {
            List<CobranzasItemE> listaEntidad = new List<CobranzasItemE>();

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ReporteCobranzasConciliados", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@numVerPlanCuentas", SqlDbType.VarChar, 3).Value = numVerPlanCuentas;
                    oComando.Parameters.Add("@codCuenta", SqlDbType.VarChar, 20).Value = codCuenta;
                    oComando.Parameters.Add("@fecIni", SqlDbType.SmallDateTime).Value = fecIni.Date;
                    oComando.Parameters.Add("@fecFin", SqlDbType.SmallDateTime).Value = fecFin.Date;
                    oComando.Parameters.Add("@TipoReporte", SqlDbType.Int).Value = TipoReporte;

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