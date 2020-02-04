using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

using Entidades.CtasPorPagar;
using AccesoDatos.Util;

namespace AccesoDatos.CtasPorPagar
{
    public class Provisiones_PorCCostoAD : DbConection
    {

        public Provisiones_PorCCostoE LlenarEntidad(IDataReader oReader)
        {
            Provisiones_PorCCostoE provisiones_porccosto = new Provisiones_PorCCostoE();
            
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idEmpresa'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				provisiones_porccosto.idEmpresa = oReader["idEmpresa"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idEmpresa"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idLocal'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				provisiones_porccosto.idLocal = oReader["idLocal"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idLocal"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idProvision'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				provisiones_porccosto.idProvision = oReader["idProvision"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idProvision"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idItem'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				provisiones_porccosto.idItem = oReader["idItem"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idItem"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idArticulo'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                provisiones_porccosto.idArticulo = oReader["idArticulo"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idArticulo"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idConcepto'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                provisiones_porccosto.idConcepto = oReader["idConcepto"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idConcepto"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Descripcion'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                provisiones_porccosto.Descripcion = oReader["Descripcion"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["Descripcion"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='numVerPlanCuentas'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				provisiones_porccosto.numVerPlanCuentas = oReader["numVerPlanCuentas"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["numVerPlanCuentas"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='codCuenta'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				provisiones_porccosto.codCuenta = oReader["codCuenta"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["codCuenta"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idMoneda'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				provisiones_porccosto.idMoneda = oReader["idMoneda"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["idMoneda"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='tipCambio'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				provisiones_porccosto.tipCambio = oReader["tipCambio"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["tipCambio"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='indCambio'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				provisiones_porccosto.indCambio = oReader["indCambio"] == DBNull.Value ? true : Convert.ToBoolean(oReader["indCambio"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Cantidad'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                provisiones_porccosto.Cantidad = oReader["Cantidad"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["Cantidad"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='PrecioUnitario'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                provisiones_porccosto.PrecioUnitario = oReader["PrecioUnitario"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["PrecioUnitario"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='indIgv'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                provisiones_porccosto.indIgv = oReader["indIgv"] == DBNull.Value ? false : Convert.ToBoolean(oReader["indIgv"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='porIgv'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                provisiones_porccosto.porIgv = oReader["porIgv"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["porIgv"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Igv'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                provisiones_porccosto.Igv = oReader["Igv"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["Igv"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='subTotal'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                provisiones_porccosto.subTotal = oReader["subTotal"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["subTotal"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='impSoles'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				provisiones_porccosto.impSoles = oReader["impSoles"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["impSoles"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='impDolares'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				provisiones_porccosto.impDolares = oReader["impDolares"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["impDolares"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='MontoCuenta'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				provisiones_porccosto.MontoCuenta = oReader["MontoCuenta"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["MontoCuenta"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idCCostos'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				provisiones_porccosto.idCCostos = oReader["idCCostos"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["idCCostos"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='desGlosa'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				provisiones_porccosto.desGlosa = oReader["desGlosa"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["desGlosa"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='codColumnaCoven'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				provisiones_porccosto.codColumnaCoven = oReader["codColumnaCoven"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["codColumnaCoven"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Tipo'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                provisiones_porccosto.Tipo = oReader["Tipo"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["Tipo"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Calculo'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                provisiones_porccosto.Calculo = oReader["Calculo"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["Calculo"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='PorRecibir'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                provisiones_porccosto.PorRecibir = oReader["PorRecibir"] == DBNull.Value ? true : Convert.ToBoolean(oReader["PorRecibir"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='indCostoArticulo'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                provisiones_porccosto.indCostoArticulo = oReader["indCostoArticulo"] == DBNull.Value ? true : Convert.ToBoolean(oReader["indCostoArticulo"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idAlmacen'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                provisiones_porccosto.idAlmacen = oReader["idAlmacen"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idAlmacen"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='notasdeIngreso'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                provisiones_porccosto.notasdeIngreso = oReader["notasdeIngreso"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["notasdeIngreso"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='EsActivoFijo'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                provisiones_porccosto.EsActivoFijo = oReader["EsActivoFijo"] == DBNull.Value ? false : Convert.ToBoolean(oReader["EsActivoFijo"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idActivoFijo'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                provisiones_porccosto.idActivoFijo = oReader["idActivoFijo"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idActivoFijo"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='FlagHC'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                provisiones_porccosto.FlagHC = oReader["FlagHC"] == DBNull.Value ? false : Convert.ToBoolean(oReader["FlagHC"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idCtaCteAnticipo'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                provisiones_porccosto.idCtaCteAnticipo = oReader["idCtaCteAnticipo"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idCtaCteAnticipo"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='UsuarioRegistro'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				provisiones_porccosto.UsuarioRegistro = oReader["UsuarioRegistro"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["UsuarioRegistro"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='FechaRegistro'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				provisiones_porccosto.FechaRegistro = oReader["FechaRegistro"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["FechaRegistro"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='UsuarioModificacion'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				provisiones_porccosto.UsuarioModificacion = oReader["UsuarioModificacion"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["UsuarioModificacion"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='FechaModificacion'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				provisiones_porccosto.FechaModificacion = oReader["FechaModificacion"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["FechaModificacion"]);

            //Extensiones
            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='DesColumnaCoven'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                provisiones_porccosto.DesColumnaCoven = oReader["DesColumnaCoven"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["DesColumnaCoven"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='DesCuenta'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                provisiones_porccosto.DesCuenta = oReader["DesCuenta"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["DesCuenta"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='DesCCosto'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                provisiones_porccosto.DesCCosto = oReader["DesCCosto"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["DesCCosto"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Codigo'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                provisiones_porccosto.Codigo = oReader["Codigo"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["Codigo"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='desMoneda'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                provisiones_porccosto.desMoneda = oReader["desMoneda"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["desMoneda"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Cantidad'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                provisiones_porccosto.CantidadTmp = oReader["Cantidad"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["Cantidad"]);

            return  provisiones_porccosto;        
        }

        public Provisiones_PorCCostoE InsertarProvisiones_PorCCosto(Provisiones_PorCCostoE provisiones_porccosto)
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_InsertarProvisiones_PorCCosto", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = provisiones_porccosto.idEmpresa;
					oComando.Parameters.Add("@idLocal", SqlDbType.Int).Value = provisiones_porccosto.idLocal;
					oComando.Parameters.Add("@idProvision", SqlDbType.Int).Value = provisiones_porccosto.idProvision;
					oComando.Parameters.Add("@idItem", SqlDbType.Int).Value = provisiones_porccosto.idItem;
                    oComando.Parameters.Add("@idArticulo", SqlDbType.Int).Value = provisiones_porccosto.idArticulo;
                    oComando.Parameters.Add("@idConcepto", SqlDbType.Int).Value = provisiones_porccosto.idConcepto;
                    oComando.Parameters.Add("@Descripcion", SqlDbType.VarChar, 100).Value = provisiones_porccosto.Descripcion;
                    oComando.Parameters.Add("@numVerPlanCuentas", SqlDbType.VarChar, 3).Value = provisiones_porccosto.numVerPlanCuentas;
					oComando.Parameters.Add("@codCuenta", SqlDbType.VarChar, 20).Value = provisiones_porccosto.codCuenta;
					oComando.Parameters.Add("@idMoneda", SqlDbType.Char, 2).Value = provisiones_porccosto.idMoneda;
					oComando.Parameters.Add("@tipCambio", SqlDbType.Decimal).Value = provisiones_porccosto.tipCambio;
					oComando.Parameters.Add("@indCambio", SqlDbType.Bit).Value = provisiones_porccosto.indCambio;
                    oComando.Parameters.Add("@Cantidad", SqlDbType.Decimal).Value = provisiones_porccosto.Cantidad;
                    oComando.Parameters.Add("@PrecioUnitario", SqlDbType.Decimal).Value = provisiones_porccosto.PrecioUnitario;
                    oComando.Parameters.Add("@indIgv", SqlDbType.Bit).Value = provisiones_porccosto.indIgv;
                    oComando.Parameters.Add("@porIgv", SqlDbType.Decimal).Value = provisiones_porccosto.porIgv;
                    oComando.Parameters.Add("@Igv", SqlDbType.Decimal).Value = provisiones_porccosto.Igv;
                    oComando.Parameters.Add("@subTotal", SqlDbType.Decimal).Value = provisiones_porccosto.subTotal;
                    oComando.Parameters.Add("@impSoles", SqlDbType.Decimal).Value = provisiones_porccosto.impSoles;
					oComando.Parameters.Add("@impDolares", SqlDbType.Decimal).Value = provisiones_porccosto.impDolares;
					oComando.Parameters.Add("@MontoCuenta", SqlDbType.Decimal).Value = provisiones_porccosto.MontoCuenta;
					oComando.Parameters.Add("@idCCostos", SqlDbType.VarChar, 10).Value = provisiones_porccosto.idCCostos;
					oComando.Parameters.Add("@desGlosa", SqlDbType.VarChar, 200).Value = provisiones_porccosto.desGlosa;
					oComando.Parameters.Add("@codColumnaCoven", SqlDbType.Int).Value = provisiones_porccosto.codColumnaCoven;
                    oComando.Parameters.Add("@Tipo", SqlDbType.Char, 1).Value = provisiones_porccosto.Tipo;
                    oComando.Parameters.Add("@Calculo", SqlDbType.Char, 1).Value = provisiones_porccosto.Calculo;
                    oComando.Parameters.Add("@PorRecibir", SqlDbType.Bit).Value = provisiones_porccosto.PorRecibir;
                    oComando.Parameters.Add("@indCostoArticulo", SqlDbType.Bit).Value = provisiones_porccosto.indCostoArticulo;
                    oComando.Parameters.Add("@idAlmacen", SqlDbType.Int).Value = provisiones_porccosto.idAlmacen;
                    oComando.Parameters.Add("@notasdeIngreso", SqlDbType.VarChar, 200).Value = provisiones_porccosto.notasdeIngreso;
                    oComando.Parameters.Add("@EsActivoFijo", SqlDbType.Bit).Value = provisiones_porccosto.EsActivoFijo;
                    oComando.Parameters.Add("@idActivoFijo", SqlDbType.Int).Value = provisiones_porccosto.idActivoFijo;
                    oComando.Parameters.Add("@FlagHC", SqlDbType.Bit).Value = provisiones_porccosto.FlagHC;
                    oComando.Parameters.Add("@idCtaCteAnticipo", SqlDbType.Int).Value = provisiones_porccosto.idCtaCteAnticipo;
                    oComando.Parameters.Add("@UsuarioRegistro", SqlDbType.VarChar, 20).Value = provisiones_porccosto.UsuarioRegistro;

                    oConexion.Open();
                    oComando.ExecuteNonQuery();
                }
            }

            return provisiones_porccosto;
        }
        
        public Provisiones_PorCCostoE ActualizarProvisiones_PorCCosto(Provisiones_PorCCostoE provisiones_porccosto)
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ActualizarProvisiones_PorCCosto", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = provisiones_porccosto.idEmpresa;
					oComando.Parameters.Add("@idLocal", SqlDbType.Int).Value = provisiones_porccosto.idLocal;
					oComando.Parameters.Add("@idProvision", SqlDbType.Int).Value = provisiones_porccosto.idProvision;
					oComando.Parameters.Add("@idItem", SqlDbType.Int).Value = provisiones_porccosto.idItem;
                    oComando.Parameters.Add("@idArticulo", SqlDbType.Int).Value = provisiones_porccosto.idArticulo;
                    oComando.Parameters.Add("@idConcepto", SqlDbType.Int).Value = provisiones_porccosto.idConcepto;
                    oComando.Parameters.Add("@Descripcion", SqlDbType.VarChar, 100).Value = provisiones_porccosto.Descripcion;
                    oComando.Parameters.Add("@numVerPlanCuentas", SqlDbType.VarChar, 3).Value = provisiones_porccosto.numVerPlanCuentas;
					oComando.Parameters.Add("@codCuenta", SqlDbType.VarChar, 20).Value = provisiones_porccosto.codCuenta;
					oComando.Parameters.Add("@idMoneda", SqlDbType.Char, 2).Value = provisiones_porccosto.idMoneda;
					oComando.Parameters.Add("@tipCambio", SqlDbType.Decimal).Value = provisiones_porccosto.tipCambio;
					oComando.Parameters.Add("@indCambio", SqlDbType.Bit).Value = provisiones_porccosto.indCambio;
                    oComando.Parameters.Add("@Cantidad", SqlDbType.Decimal).Value = provisiones_porccosto.Cantidad;
                    oComando.Parameters.Add("@PrecioUnitario", SqlDbType.Decimal).Value = provisiones_porccosto.PrecioUnitario;
                    oComando.Parameters.Add("@indIgv", SqlDbType.Bit).Value = provisiones_porccosto.indIgv;
                    oComando.Parameters.Add("@porIgv", SqlDbType.Decimal).Value = provisiones_porccosto.porIgv;
                    oComando.Parameters.Add("@Igv", SqlDbType.Decimal).Value = provisiones_porccosto.Igv;
                    oComando.Parameters.Add("@subTotal", SqlDbType.Decimal).Value = provisiones_porccosto.subTotal;
                    oComando.Parameters.Add("@impSoles", SqlDbType.Decimal).Value = provisiones_porccosto.impSoles;
					oComando.Parameters.Add("@impDolares", SqlDbType.Decimal).Value = provisiones_porccosto.impDolares;
					oComando.Parameters.Add("@MontoCuenta", SqlDbType.Decimal).Value = provisiones_porccosto.MontoCuenta;
					oComando.Parameters.Add("@idCCostos", SqlDbType.VarChar, 10).Value = provisiones_porccosto.idCCostos;
					oComando.Parameters.Add("@desGlosa", SqlDbType.VarChar, 200).Value = provisiones_porccosto.desGlosa;
					oComando.Parameters.Add("@codColumnaCoven", SqlDbType.Int).Value = provisiones_porccosto.codColumnaCoven;
                    oComando.Parameters.Add("@Tipo", SqlDbType.Char, 1).Value = provisiones_porccosto.Tipo;
                    oComando.Parameters.Add("@Calculo", SqlDbType.Char, 1).Value = provisiones_porccosto.Calculo;
                    oComando.Parameters.Add("@PorRecibir", SqlDbType.Bit).Value = provisiones_porccosto.PorRecibir;
                    oComando.Parameters.Add("@indCostoArticulo", SqlDbType.Bit).Value = provisiones_porccosto.indCostoArticulo;
                    oComando.Parameters.Add("@idAlmacen", SqlDbType.Int).Value = provisiones_porccosto.idAlmacen;
                    oComando.Parameters.Add("@notasdeIngreso", SqlDbType.VarChar, 200).Value = provisiones_porccosto.notasdeIngreso;
                    oComando.Parameters.Add("@EsActivoFijo", SqlDbType.Bit).Value = provisiones_porccosto.EsActivoFijo;
                    oComando.Parameters.Add("@idActivoFijo", SqlDbType.Int).Value = provisiones_porccosto.idActivoFijo;
                    oComando.Parameters.Add("@FlagHC", SqlDbType.Bit).Value = provisiones_porccosto.FlagHC;
                    oComando.Parameters.Add("@idCtaCteAnticipo", SqlDbType.Int).Value = provisiones_porccosto.idCtaCteAnticipo;
                    oComando.Parameters.Add("@UsuarioModificacion", SqlDbType.VarChar, 30).Value = provisiones_porccosto.UsuarioModificacion;

                    oConexion.Open();
                    oComando.ExecuteNonQuery();
                }
            }

            return provisiones_porccosto;
        }
        
        public Int32 ActualizarPorRecibir_PorCCosto(Int32 idEmpresa, Int32 idLocal, Int32? idProvision, Int32 idProvisionRec, Int32 idItemRec, String UsuarioModificacion)
        {
            int resp = 0;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ActualizarPorRecibir_PorCCosto", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@idLocal", SqlDbType.Int).Value = idLocal;
                    oComando.Parameters.Add("@idProvision", SqlDbType.Int).Value = idProvision;
                    oComando.Parameters.Add("@idProvisionRec", SqlDbType.Int).Value = idProvisionRec;
                    oComando.Parameters.Add("@idItemRec", SqlDbType.Int).Value = idItemRec;
                    oComando.Parameters.Add("@UsuarioModificacion", SqlDbType.VarChar, 20).Value = UsuarioModificacion;

                    oConexion.Open();
                    resp = oComando.ExecuteNonQuery();
                }
            }

            return resp;
        }

        public int EliminarProvisiones_PorCCosto(Int32 idEmpresa, Int32 idLocal, Int32 idProvision)
        {
            int resp = 0;
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_EliminarProvisiones_PorCCosto", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
					oComando.Parameters.Add("@idLocal", SqlDbType.Int).Value = idLocal;
					oComando.Parameters.Add("@idProvision", SqlDbType.Int).Value = idProvision;

                    oConexion.Open();
                    resp = oComando.ExecuteNonQuery();
                }
            }

            return resp;
        }

        public List<Provisiones_PorCCostoE> ListarProvisiones_PorCCosto()
        {
            List<Provisiones_PorCCostoE> listaEntidad = new List<Provisiones_PorCCostoE>();

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ListarProvisiones_PorCCosto", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
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
        
        public Provisiones_PorCCostoE ObtenerProvisiones_PorCCosto(Int32 idEmpresa, Int32 idLocal, Int32 idProvision, Int32 idItem)
        {        
            Provisiones_PorCCostoE provisiones_porccosto = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ObtenerProvisiones_PorCCosto", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
					oComando.Parameters.Add("@idLocal", SqlDbType.Int).Value = idLocal;
					oComando.Parameters.Add("@idProvision", SqlDbType.Int).Value = idProvision;
					oComando.Parameters.Add("@idItem", SqlDbType.Int).Value = idItem;

                    oConexion.Open();
                    
                    using (SqlDataReader oReader = oComando.ExecuteReader())
                    {
                        while (oReader.Read())
                        {
                            provisiones_porccosto = LlenarEntidad(oReader);
                        }
                    }
                }
            }

            return provisiones_porccosto;
        }

        public List<Provisiones_PorCCostoE> RecuperarProvisiones_PorCCostoPorId(Int32 idEmpresa, Int32 idLocal, Int32 idProvision)
        {
            List<Provisiones_PorCCostoE> listaEntidad = new List<Provisiones_PorCCostoE>();

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_RecuperarProvisiones_PorCCostoPorId", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@idLocal", SqlDbType.Int).Value = idLocal;
                    oComando.Parameters.Add("@idProvision", SqlDbType.Int).Value = idProvision;

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

        public List<Provisiones_PorCCostoE> RecuperarProvisiones_PorCCostoPorIdPorRecibir(Int32 idEmpresa, Int32 idLocal, Int32 idProvision)
        {
            List<Provisiones_PorCCostoE> listaEntidad = new List<Provisiones_PorCCostoE>();

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_RecuperarProvisiones_PorCCostoPorIdPorRecibir", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@idLocal", SqlDbType.Int).Value = idLocal;
                    oComando.Parameters.Add("@idProvision", SqlDbType.Int).Value = idProvision;

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

        public Provisiones_PorCCostoE RecuperarProvisionDetAnticipo(Int32 idProvision)
        {
            Provisiones_PorCCostoE Entidad = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_RecuperarProvisionDetAnticipo", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idProvision", SqlDbType.Int).Value = idProvision;

                    oConexion.Open();

                    using (SqlDataReader oReader = oComando.ExecuteReader())
                    {
                        while (oReader.Read())
                        {
                            Entidad = LlenarEntidad(oReader);
                        }
                    }
                }
            }

            return Entidad;
        }

    }
}