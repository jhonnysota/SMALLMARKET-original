using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

using Entidades.Almacen;
using AccesoDatos.Util;

namespace AccesoDatos.Almacen
{
    public class ConceptosVariosAD : DbConection
    {
            
        public ConceptosVariosE LlenarEntidad(IDataReader oReader)
        {
            ConceptosVariosE conceptosvarios = new ConceptosVariosE();
            
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idConcepto'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				conceptosvarios.idConcepto = oReader["idConcepto"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idConcepto"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idEmpresa'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                conceptosvarios.idEmpresa = oReader["idEmpresa"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idEmpresa"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Tipo'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				conceptosvarios.Tipo = oReader["Tipo"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["Tipo"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='codConcepto'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				conceptosvarios.codConcepto = oReader["codConcepto"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["codConcepto"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Descripcion'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				conceptosvarios.Descripcion = oReader["Descripcion"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["Descripcion"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='numVerPlanCuentas'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				conceptosvarios.numVerPlanCuentas = oReader["numVerPlanCuentas"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["numVerPlanCuentas"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='indCuentaAdm'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                conceptosvarios.indCuentaAdm = oReader["indCuentaAdm"] == DBNull.Value ? false : Convert.ToBoolean(oReader["indCuentaAdm"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='codCuentaAdm'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				conceptosvarios.codCuentaAdm = oReader["codCuentaAdm"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["codCuentaAdm"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='indCuentaVen'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                conceptosvarios.indCuentaVen = oReader["indCuentaVen"] == DBNull.Value ? false : Convert.ToBoolean(oReader["indCuentaVen"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='codCuentaVen'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                conceptosvarios.codCuentaVen = oReader["codCuentaVen"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["codCuentaVen"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='indCuentaPro'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                conceptosvarios.indCuentaPro = oReader["indCuentaPro"] == DBNull.Value ? false : Convert.ToBoolean(oReader["indCuentaPro"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='codCuentaPro'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                conceptosvarios.codCuentaPro = oReader["codCuentaPro"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["codCuentaPro"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='indCuentaFin'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                conceptosvarios.indCuentaFin = oReader["indCuentaFin"] == DBNull.Value ? false : Convert.ToBoolean(oReader["indCuentaFin"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='codCuentaFin'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                conceptosvarios.codCuentaFin = oReader["codCuentaFin"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["codCuentaFin"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='indConceptoLiqui'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                conceptosvarios.indConceptoLiqui = oReader["indConceptoLiqui"] == DBNull.Value ? false : Convert.ToBoolean(oReader["indConceptoLiqui"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='indDetraccion'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                conceptosvarios.indDetraccion = oReader["indDetraccion"] == DBNull.Value ? false : Convert.ToBoolean(oReader["indDetraccion"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idTipoDetraccion'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                conceptosvarios.idTipoDetraccion = oReader["idTipoDetraccion"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["idTipoDetraccion"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='indRetencion'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                conceptosvarios.indRetencion = oReader["indRetencion"] == DBNull.Value ? false : Convert.ToBoolean(oReader["indRetencion"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='porImpuesto'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                conceptosvarios.porImpuesto = oReader["porImpuesto"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["porImpuesto"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='ParaMovi'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                conceptosvarios.ParaMovi = oReader["ParaMovi"] == DBNull.Value ? false : Convert.ToBoolean(oReader["ParaMovi"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='indCuentasMon'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                conceptosvarios.indCuentasMon = oReader["indCuentasMon"] == DBNull.Value ? false : Convert.ToBoolean(oReader["indCuentasMon"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='CtaSoles'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                conceptosvarios.CtaSoles = oReader["CtaSoles"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["CtaSoles"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='CtaDolares'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                conceptosvarios.CtaDolares = oReader["CtaDolares"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["CtaDolares"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='indTransferencia'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                conceptosvarios.indTransferencia = oReader["indTransferencia"] == DBNull.Value ? false : Convert.ToBoolean(oReader["indTransferencia"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='indContraPartida'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                conceptosvarios.indContraPartida = oReader["indContraPartida"] == DBNull.Value ? false : Convert.ToBoolean(oReader["indContraPartida"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='CtaContraSoles'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                conceptosvarios.CtaContraSoles = oReader["CtaContraSoles"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["CtaContraSoles"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='CtaContraDolares'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                conceptosvarios.CtaContraDolares = oReader["CtaContraDolares"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["CtaContraDolares"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='indAnticipo'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                conceptosvarios.indAnticipo = oReader["indAnticipo"] == DBNull.Value ? false : Convert.ToBoolean(oReader["indAnticipo"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='indPlanillas'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                conceptosvarios.indPlanillas = oReader["indPlanillas"] == DBNull.Value ? false : Convert.ToBoolean(oReader["indPlanillas"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='indCompras'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                conceptosvarios.indCompras = oReader["indCompras"] == DBNull.Value ? false : Convert.ToBoolean(oReader["indCompras"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='indTesoreria'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                conceptosvarios.indTesoreria = oReader["indTesoreria"] == DBNull.Value ? false : Convert.ToBoolean(oReader["indTesoreria"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='indCobranzas'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                conceptosvarios.indCobranzas = oReader["indCobranzas"] == DBNull.Value ? false : Convert.ToBoolean(oReader["indCobranzas"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='TipoSolicitud'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                conceptosvarios.TipoSolicitud = oReader["TipoSolicitud"] == DBNull.Value ? "R" : Convert.ToString(oReader["TipoSolicitud"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='UsuarioRegistro'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				conceptosvarios.UsuarioRegistro = oReader["UsuarioRegistro"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["UsuarioRegistro"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='FechaRegistro'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				conceptosvarios.FechaRegistro = oReader["FechaRegistro"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["FechaRegistro"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='UsuarioModificacion'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				conceptosvarios.UsuarioModificacion = oReader["UsuarioModificacion"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["UsuarioModificacion"]);
			
			oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='FechaModificacion'";
			if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
				conceptosvarios.FechaModificacion = oReader["FechaModificacion"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(oReader["FechaModificacion"]);

            //Extensiones
            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='desCuentaAdm'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                conceptosvarios.desCuentaAdm = oReader["desCuentaAdm"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["desCuentaAdm"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='desCuentaVen'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                conceptosvarios.desCuentaVen = oReader["desCuentaVen"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["desCuentaVen"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='desCuentaPro'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                conceptosvarios.desCuentaPro = oReader["desCuentaPro"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["desCuentaPro"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='desCuentaFin'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                conceptosvarios.desCuentaFin = oReader["desCuentaFin"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["desCuentaFin"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='indCCAdm'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                conceptosvarios.indCCAdm = oReader["indCCAdm"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["indCCAdm"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='indCCVen'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                conceptosvarios.indCCVen = oReader["indCCVen"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["indCCVen"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='indCCPro'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                conceptosvarios.indCCPro = oReader["indCCPro"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["indCCPro"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='indCCFin'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                conceptosvarios.indCCFin = oReader["indCCFin"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["indCCFin"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='indAuxiliar'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                conceptosvarios.indAuxiliar = oReader["indAuxiliar"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["indAuxiliar"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='indCentroCosto'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                conceptosvarios.indCentroCosto = oReader["indCentroCosto"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["indCentroCosto"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='NombreEmpresa'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                conceptosvarios.NombreEmpresa = oReader["NombreEmpresa"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["NombreEmpresa"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='CtaDesSoles'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                conceptosvarios.CtaDesSoles = oReader["CtaDesSoles"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["CtaDesSoles"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='CtaDesDolares'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                conceptosvarios.CtaDesDolares = oReader["CtaDesDolares"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["CtaDesDolares"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='CtaDesContraSoles'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                conceptosvarios.CtaDesContraSoles = oReader["CtaDesContraSoles"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["CtaDesContraSoles"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='CtaDesContraDolares'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                conceptosvarios.CtaDesContraDolares = oReader["CtaDesContraDolares"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["CtaDesContraDolares"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Nemo'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                conceptosvarios.Nemo = oReader["Nemo"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["Nemo"]);

            return  conceptosvarios;        
        }

        public ConceptosVariosE InsertarConceptosVarios(ConceptosVariosE conceptosvarios)
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_InsertarConceptosVarios", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = conceptosvarios.idEmpresa;
                    oComando.Parameters.Add("@Tipo", SqlDbType.Int).Value = conceptosvarios.Tipo;
					oComando.Parameters.Add("@codConcepto", SqlDbType.VarChar, 20).Value = conceptosvarios.codConcepto;
					oComando.Parameters.Add("@Descripcion", SqlDbType.VarChar, 100).Value = conceptosvarios.Descripcion;
                    oComando.Parameters.Add("@numVerPlanCuentas", SqlDbType.VarChar, 3).Value = conceptosvarios.numVerPlanCuentas;
                    oComando.Parameters.Add("@indCuentaAdm", SqlDbType.Bit).Value = conceptosvarios.indCuentaAdm;
                    oComando.Parameters.Add("@codCuentaAdm", SqlDbType.VarChar, 20).Value = conceptosvarios.codCuentaAdm;
                    oComando.Parameters.Add("@indCuentaVen", SqlDbType.Bit).Value = conceptosvarios.indCuentaVen;
                    oComando.Parameters.Add("@codCuentaVen", SqlDbType.VarChar, 20).Value = conceptosvarios.codCuentaVen;
                    oComando.Parameters.Add("@indCuentaPro", SqlDbType.Bit).Value = conceptosvarios.indCuentaPro;
                    oComando.Parameters.Add("@codCuentaPro", SqlDbType.VarChar, 20).Value = conceptosvarios.codCuentaPro;
                    oComando.Parameters.Add("@indCuentaFin", SqlDbType.Bit).Value = conceptosvarios.indCuentaFin;
                    oComando.Parameters.Add("@codCuentaFin", SqlDbType.VarChar, 20).Value = conceptosvarios.codCuentaFin;
                    oComando.Parameters.Add("@indConceptoLiqui", SqlDbType.Bit).Value = conceptosvarios.indConceptoLiqui;
                    oComando.Parameters.Add("@indDetraccion", SqlDbType.Bit).Value = conceptosvarios.indDetraccion;
                    oComando.Parameters.Add("@idTipoDetraccion", SqlDbType.VarChar, 3).Value = conceptosvarios.idTipoDetraccion;
                    oComando.Parameters.Add("@indRetencion", SqlDbType.Bit).Value = conceptosvarios.indRetencion;
                    oComando.Parameters.Add("@porImpuesto", SqlDbType.Decimal).Value = conceptosvarios.porImpuesto;
                    oComando.Parameters.Add("@ParaMovi", SqlDbType.Bit).Value = conceptosvarios.ParaMovi;
                    oComando.Parameters.Add("@indCuentasMon", SqlDbType.Bit).Value = conceptosvarios.indCuentasMon;
                    oComando.Parameters.Add("@CtaSoles", SqlDbType.VarChar, 20).Value = conceptosvarios.CtaSoles;
                    oComando.Parameters.Add("@CtaDolares", SqlDbType.VarChar, 20).Value = conceptosvarios.CtaDolares;
                    oComando.Parameters.Add("@indTransferencia", SqlDbType.Bit).Value = conceptosvarios.indTransferencia;
                    oComando.Parameters.Add("@indContraPartida", SqlDbType.Bit).Value = conceptosvarios.indContraPartida;
                    oComando.Parameters.Add("@CtaContraSoles", SqlDbType.VarChar, 20).Value = conceptosvarios.CtaContraSoles;
                    oComando.Parameters.Add("@CtaContraDolares", SqlDbType.VarChar, 20).Value = conceptosvarios.CtaContraDolares;
                    oComando.Parameters.Add("@indAnticipo", SqlDbType.Bit).Value = conceptosvarios.indAnticipo;
                    oComando.Parameters.Add("@indPlanillas", SqlDbType.Bit).Value = conceptosvarios.indPlanillas;
                    oComando.Parameters.Add("@indCompras", SqlDbType.Bit).Value = conceptosvarios.indCompras;
                    oComando.Parameters.Add("@indTesoreria", SqlDbType.Bit).Value = conceptosvarios.indTesoreria;
                    oComando.Parameters.Add("@indCobranzas", SqlDbType.Bit).Value = conceptosvarios.indCobranzas;
                    oComando.Parameters.Add("@TipoSolicitud", SqlDbType.Char, 1).Value = conceptosvarios.TipoSolicitud;
                    oComando.Parameters.Add("@UsuarioRegistro", SqlDbType.VarChar, 20).Value = conceptosvarios.UsuarioRegistro;

                    oConexion.Open();
                    conceptosvarios.idConcepto = Int32.Parse(oComando.ExecuteScalar().ToString());
                }
            }

            return conceptosvarios;
        }
        
        public ConceptosVariosE ActualizarConceptosVarios(ConceptosVariosE conceptosvarios)
        {
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ActualizarConceptosVarios", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idConcepto", SqlDbType.Int).Value = conceptosvarios.idConcepto;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = conceptosvarios.idEmpresa;
                    oComando.Parameters.Add("@Tipo", SqlDbType.Int).Value = conceptosvarios.Tipo;
					oComando.Parameters.Add("@codConcepto", SqlDbType.VarChar, 20).Value = conceptosvarios.codConcepto;
					oComando.Parameters.Add("@Descripcion", SqlDbType.VarChar, 100).Value = conceptosvarios.Descripcion;
                    oComando.Parameters.Add("@numVerPlanCuentas", SqlDbType.VarChar, 3).Value = conceptosvarios.numVerPlanCuentas;
                    oComando.Parameters.Add("@indCuentaAdm", SqlDbType.Bit).Value = conceptosvarios.indCuentaAdm;
                    oComando.Parameters.Add("@codCuentaAdm", SqlDbType.VarChar, 20).Value = conceptosvarios.codCuentaAdm;
                    oComando.Parameters.Add("@indCuentaVen", SqlDbType.Bit).Value = conceptosvarios.indCuentaVen;
                    oComando.Parameters.Add("@codCuentaVen", SqlDbType.VarChar, 20).Value = conceptosvarios.codCuentaVen;
                    oComando.Parameters.Add("@indCuentaPro", SqlDbType.Bit).Value = conceptosvarios.indCuentaPro;
                    oComando.Parameters.Add("@codCuentaPro", SqlDbType.VarChar, 20).Value = conceptosvarios.codCuentaPro;
                    oComando.Parameters.Add("@indCuentaFin", SqlDbType.Bit).Value = conceptosvarios.indCuentaFin;
                    oComando.Parameters.Add("@codCuentaFin", SqlDbType.VarChar, 20).Value = conceptosvarios.codCuentaFin;
                    oComando.Parameters.Add("@indConceptoLiqui", SqlDbType.Bit).Value = conceptosvarios.indConceptoLiqui;
                    oComando.Parameters.Add("@indDetraccion", SqlDbType.Bit).Value = conceptosvarios.indDetraccion;
                    oComando.Parameters.Add("@idTipoDetraccion", SqlDbType.VarChar, 3).Value = conceptosvarios.idTipoDetraccion;
                    oComando.Parameters.Add("@indRetencion", SqlDbType.Bit).Value = conceptosvarios.indRetencion;
                    oComando.Parameters.Add("@porImpuesto", SqlDbType.Decimal).Value = conceptosvarios.porImpuesto;
                    oComando.Parameters.Add("@ParaMovi", SqlDbType.Bit).Value = conceptosvarios.ParaMovi;
                    oComando.Parameters.Add("@indCuentasMon", SqlDbType.Bit).Value = conceptosvarios.indCuentasMon;
                    oComando.Parameters.Add("@CtaSoles", SqlDbType.VarChar, 20).Value = conceptosvarios.CtaSoles;
                    oComando.Parameters.Add("@CtaDolares", SqlDbType.VarChar, 20).Value = conceptosvarios.CtaDolares;
                    oComando.Parameters.Add("@indTransferencia", SqlDbType.Bit).Value = conceptosvarios.indTransferencia;
                    oComando.Parameters.Add("@indContraPartida", SqlDbType.Bit).Value = conceptosvarios.indContraPartida;
                    oComando.Parameters.Add("@CtaContraSoles", SqlDbType.VarChar, 20).Value = conceptosvarios.CtaContraSoles;
                    oComando.Parameters.Add("@CtaContraDolares", SqlDbType.VarChar, 20).Value = conceptosvarios.CtaContraDolares;
                    oComando.Parameters.Add("@indAnticipo", SqlDbType.Bit).Value = conceptosvarios.indAnticipo;
                    oComando.Parameters.Add("@indPlanillas", SqlDbType.Bit).Value = conceptosvarios.indPlanillas;
                    oComando.Parameters.Add("@indCompras", SqlDbType.Bit).Value = conceptosvarios.indCompras;
                    oComando.Parameters.Add("@indTesoreria", SqlDbType.Bit).Value = conceptosvarios.indTesoreria;
                    oComando.Parameters.Add("@indCobranzas", SqlDbType.Bit).Value = conceptosvarios.indCobranzas;
                    oComando.Parameters.Add("@TipoSolicitud", SqlDbType.Char, 1).Value = conceptosvarios.TipoSolicitud;
                    oComando.Parameters.Add("@UsuarioModificacion", SqlDbType.VarChar, 20).Value = conceptosvarios.UsuarioModificacion;

                    oConexion.Open();
                    oComando.ExecuteNonQuery();
                }
            }

            return conceptosvarios;
        }        

        public int EliminarConceptosVarios(Int32 idConcepto)
        {
            int resp = 0;
            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_EliminarConceptosVarios", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idConcepto", SqlDbType.Int).Value = idConcepto;

                    oConexion.Open();
                    resp = oComando.ExecuteNonQuery();
                }
            }

            return resp;
        }

        public List<ConceptosVariosE> ListarConceptosVarios(Int32 idEmpresa, Int32 Tipo)
        {
            List<ConceptosVariosE> listaEntidad = new List<ConceptosVariosE>();

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ListarConceptosVarios", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@Tipo", SqlDbType.Int).Value = Tipo;
                    //oComando.Parameters.Add("@idSistema", SqlDbType.Int).Value = idSistema;

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
        
        public ConceptosVariosE ObtenerConceptosVarios(Int32 idConcepto, Int32 idEmpresa)
        {        
            ConceptosVariosE conceptosvarios = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ObtenerConceptosVarios", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idConcepto", SqlDbType.Int).Value = idConcepto;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;

                    oConexion.Open();
                    
                    using (SqlDataReader oReader = oComando.ExecuteReader())
                    {
                        while (oReader.Read())
                        {
                            conceptosvarios = LlenarEntidad(oReader);
                        }
                    }
                }
            }

            return conceptosvarios;
        }

        public List<ConceptosVariosE> ConceptosVariosBusqueda(Int32 Tipo, Int32 idEmpresa, String Descripcion, Boolean indConceptoLiqui)//, Int32 idSistema = 0)
        {
            List<ConceptosVariosE> listaEntidad = new List<ConceptosVariosE>();

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ConceptosVariosBusqueda", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@Tipo", SqlDbType.Int).Value = Tipo;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@Descripcion", SqlDbType.VarChar, 50).Value = Descripcion;
                    oComando.Parameters.Add("@indConceptoLiqui", SqlDbType.Bit).Value = indConceptoLiqui;
                    //oComando.Parameters.Add("@idSistema", SqlDbType.Int).Value = idSistema;

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

        public ConceptosVariosE RecuperarConceptosVarios(Int32 idConcepto, Int32 idEmpresa, Boolean indConceptoLiqui)
        {
            ConceptosVariosE conceptosvarios = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_RecuperarConceptosVarios", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idConcepto", SqlDbType.Int).Value = idConcepto;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@indConceptoLiqui", SqlDbType.Bit).Value = indConceptoLiqui;

                    oConexion.Open();

                    using (SqlDataReader oReader = oComando.ExecuteReader())
                    {
                        while (oReader.Read())
                        {
                            conceptosvarios = LlenarEntidad(oReader);
                        }
                    }
                }
            }

            return conceptosvarios;
        }

        public List<ConceptosVariosE> ConceptosVariosTesoreria(Int32 Tipo, Int32 idEmpresa, String Descripcion)
        {
            List<ConceptosVariosE> listaEntidad = new List<ConceptosVariosE>();

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ConceptosVariosTesoreria", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@Tipo", SqlDbType.Int).Value = Tipo;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@Descripcion", SqlDbType.VarChar, 50).Value = Descripcion;

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

        public List<ConceptosVariosE> ConceptosVariosCobranzas(Int32 idEmpresa)
        {
            List<ConceptosVariosE> listaEntidad = new List<ConceptosVariosE>();

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ConceptosVariosCobranzas", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
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

        public List<ConceptosVariosE> ListarEmpresaConceptosVarios(Int32 idEmpresa)
        {
            List<ConceptosVariosE> listaEntidad = new List<ConceptosVariosE>();

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ListarEmpresaConceptosVarios", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
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

        public Int32 CopiarConceptosVarios(Int32 idEmpresaDe, Int32 idEmpresaA, String UsuarioRegistro)
        {
            int resp = 0;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_CopiarConceptosVarios", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresaDe", SqlDbType.Int).Value = idEmpresaDe;
                    oComando.Parameters.Add("@idEmpresaA", SqlDbType.Int).Value = idEmpresaA;
                    oComando.Parameters.Add("@UsuarioRegistro", SqlDbType.VarChar, 20).Value = UsuarioRegistro;

                    oConexion.Open();
                    resp = oComando.ExecuteNonQuery();
                }
            }

            return resp;
        }

        public ConceptosVariosE RecuperarCuentasMovilidad(Int32 idEmpresa)
        {
            ConceptosVariosE conceptosvarios = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_RecuperarCuentasMovilidad", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;

                    oConexion.Open();

                    using (SqlDataReader oReader = oComando.ExecuteReader())
                    {
                        while (oReader.Read())
                        {
                            conceptosvarios = LlenarEntidad(oReader);
                        }
                    }
                }
            }

            return conceptosvarios;
        }

        public List<ConceptosVariosE> ConceptosVariosPlanillas(Int32 idEmpresa)
        {
            List<ConceptosVariosE> listaEntidad = new List<ConceptosVariosE>();

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ConceptosVariosPlanillas", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
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

        public List<ConceptosVariosE> ConceptosVariosCompras(Int32 Tipo, Int32 idEmpresa, String Descripcion, Boolean indConceptoLiqui)
        {
            List<ConceptosVariosE> listaEntidad = new List<ConceptosVariosE>();

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ConceptosVariosCompras", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@Tipo", SqlDbType.Int).Value = Tipo;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@Descripcion", SqlDbType.VarChar, 50).Value = Descripcion;
                    oComando.Parameters.Add("@indConceptoLiqui", SqlDbType.Bit).Value = indConceptoLiqui;

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