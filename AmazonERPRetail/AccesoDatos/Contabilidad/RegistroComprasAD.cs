using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

using Entidades.Contabilidad;
using AccesoDatos.Util;

namespace AccesoDatos.Contabilidad
{
    public class RegistroComprasAD : DbConection
    {

        public RegistroComprasE LlenarEntidad(IDataReader oReader)
        {
            RegistroComprasE oRegCompras = new RegistroComprasE();

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Periodo'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                oRegCompras.Periodo = oReader["Periodo"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["Periodo"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Correlativo'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                oRegCompras.Correlativo = oReader["Correlativo"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["Correlativo"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='PrimerDigito'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                oRegCompras.PrimerDigito = oReader["PrimerDigito"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["PrimerDigito"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idLocal'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                oRegCompras.idLocal = oReader["idLocal"] == DBNull.Value ? 0 : Convert.ToInt32(oReader["idLocal"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='fecDocumento'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                oRegCompras.fecDocumento = oReader["fecDocumento"] == DBNull.Value ? (Nullable<DateTime>)null : Convert.ToDateTime(oReader["fecDocumento"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='fecVencimiento'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                oRegCompras.fecVencimiento = oReader["fecVencimiento"] == DBNull.Value ? (Nullable<DateTime>)null : Convert.ToDateTime(oReader["fecVencimiento"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='tipDocumentoVenta'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                oRegCompras.tipDocumentoVenta = oReader["tipDocumentoVenta"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["tipDocumentoVenta"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='depAduanera'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                oRegCompras.depAduanera = oReader["depAduanera"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["depAduanera"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Anio'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                oRegCompras.Anio = oReader["Anio"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["Anio"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='serDocumento'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                oRegCompras.serDocumento = oReader["serDocumento"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["serDocumento"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='numDocumento'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                oRegCompras.numDocumento = oReader["numDocumento"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["numDocumento"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='tipDocPersona'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                oRegCompras.tipDocPersona = oReader["tipDocPersona"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["tipDocPersona"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='RUC'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                oRegCompras.RUC = oReader["RUC"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["RUC"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='RazonSocial'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                oRegCompras.RazonSocial = oReader["RazonSocial"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["RazonSocial"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='BaseGravado'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                oRegCompras.BaseGravado = oReader["BaseGravado"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["BaseGravado"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='IgvGrabado'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                oRegCompras.IgvGrabado = oReader["IgvGrabado"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["IgvGrabado"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='BaseGravadoNoGravado'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                oRegCompras.BaseGravadoNoGravado = oReader["BaseGravadoNoGravado"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["BaseGravadoNoGravado"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='IgvGravadoNoGravado'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                oRegCompras.IgvGravadoNoGravado = oReader["IgvGravadoNoGravado"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["IgvGravadoNoGravado"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='BaseSinDerecho'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                oRegCompras.BaseSinDerecho = oReader["BaseSinDerecho"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["BaseSinDerecho"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='IgvSinDerecho'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                oRegCompras.IgvSinDerecho = oReader["IgvSinDerecho"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["IgvSinDerecho"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='BaseNoGravado'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                oRegCompras.BaseNoGravado = oReader["BaseNoGravado"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["BaseNoGravado"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='ISC'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                oRegCompras.ISC = oReader["ISC"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["ISC"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Otros'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                oRegCompras.Otros = oReader["Otros"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["Otros"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Total'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                oRegCompras.Total = oReader["Total"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["Total"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='docDomiciliado'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                oRegCompras.docDomiciliado = oReader["docDomiciliado"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["docDomiciliado"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='flagDetraccion'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                oRegCompras.flagDetraccion = oReader["flagDetraccion"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["flagDetraccion"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='numDetraccion'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                oRegCompras.numDetraccion = oReader["numDetraccion"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["numDetraccion"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='fecDetraccion'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                oRegCompras.fecDetraccion = oReader["fecDetraccion"] == DBNull.Value ? (Nullable<DateTime>)null : Convert.ToDateTime(oReader["fecDetraccion"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='codTasa'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                oRegCompras.codTasa = oReader["codTasa"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["codTasa"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='tipCambio'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                oRegCompras.tipCambio = oReader["tipCambio"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["tipCambio"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='fecDocumentoRef'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                oRegCompras.fecDocumentoRef = oReader["fecDocumentoRef"] == DBNull.Value ? (Nullable<DateTime>)null : Convert.ToDateTime(oReader["fecDocumentoRef"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idDocumentoRef'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                oRegCompras.idDocumentoRef = oReader["idDocumentoRef"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["idDocumentoRef"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='serDocumentoRef'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                oRegCompras.serDocumentoRef = oReader["serDocumentoRef"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["serDocumentoRef"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='numDocumentoRef'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                oRegCompras.numDocumentoRef = oReader["numDocumentoRef"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["numDocumentoRef"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='VariacionIgv'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                oRegCompras.VariacionIgv = oReader["VariacionIgv"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["VariacionIgv"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Moneda'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                oRegCompras.Moneda = oReader["Moneda"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["Moneda"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Dua'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                oRegCompras.Dua = oReader["Dua"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["Dua"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='PaisOrigen'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                oRegCompras.PaisOrigen = oReader["PaisOrigen"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["PaisOrigen"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='TipoRenta'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                oRegCompras.TipoRenta = oReader["TipoRenta"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["TipoRenta"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Rectificacion'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                oRegCompras.Rectificacion = oReader["Rectificacion"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["Rectificacion"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='fecRectificacion'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                oRegCompras.fecRectificacion = oReader["fecRectificacion"] == DBNull.Value ? (Nullable<DateTime>)null : Convert.ToDateTime(oReader["fecRectificacion"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='ApePat'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                oRegCompras.ApePat = oReader["ApePat"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["ApePat"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='ApeMat'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                oRegCompras.ApeMat = oReader["ApeMat"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["ApeMat"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Nombres'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                oRegCompras.Nombres = oReader["Nombres"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["Nombres"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='flagRetencion'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                oRegCompras.flagRetencion = oReader["flagRetencion"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["flagRetencion"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='codCuenta'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                oRegCompras.codCuenta = oReader["codCuenta"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["codCuenta"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='desCuenta'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                oRegCompras.desCuenta = oReader["desCuenta"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["desCuenta"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idComprobante'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                oRegCompras.idComprobante = oReader["idComprobante"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["idComprobante"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='numFile'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                oRegCompras.numFile = oReader["numFile"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["numFile"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='numVoucher'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                oRegCompras.numVoucher = oReader["numVoucher"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["numVoucher"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='idDocumento'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                oRegCompras.idDocumento = oReader["idDocumento"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["idDocumento"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='GlosaGeneral'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                oRegCompras.GlosaGeneral = oReader["GlosaGeneral"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["GlosaGeneral"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='desMes'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                oRegCompras.desMes = oReader["desMes"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["desMes"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Direccion'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                oRegCompras.Direccion = oReader["Direccion"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["Direccion"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='OtrosConceptos'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                oRegCompras.OtrosConceptos = oReader["OtrosConceptos"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["OtrosConceptos"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='tipDocCreditoFiscal'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                oRegCompras.tipDocCreditoFiscal = oReader["tipDocCreditoFiscal"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["tipDocCreditoFiscal"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='AnioDua'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                oRegCompras.AnioDua = oReader["AnioDua"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["AnioDua"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='nroDua'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                oRegCompras.nroDua = oReader["nroDua"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["nroDua"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='IdentiBeneficiario'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                oRegCompras.IdentiBeneficiario = oReader["IdentiBeneficiario"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["IdentiBeneficiario"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='RazonBeneficiario'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                oRegCompras.desMes = oReader["RazonBeneficiario"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["RazonBeneficiario"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='PaisBeneficiario'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                oRegCompras.PaisBeneficiario = oReader["PaisBeneficiario"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["PaisBeneficiario"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='VinculacionEconomica'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                oRegCompras.VinculacionEconomica = oReader["VinculacionEconomica"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["VinculacionEconomica"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='RentaBruta'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                oRegCompras.RentaBruta = oReader["RentaBruta"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["RentaBruta"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='EnajenacionBienes'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                oRegCompras.EnajenacionBienes = oReader["EnajenacionBienes"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["EnajenacionBienes"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='RentaNeta'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                oRegCompras.RentaNeta = oReader["RentaNeta"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["RentaNeta"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='TasaRetencion'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                oRegCompras.TasaRetencion = oReader["TasaRetencion"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["TasaRetencion"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='ImpuestoRetenido'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                oRegCompras.ImpuestoRetenido = oReader["ImpuestoRetenido"] == DBNull.Value ? 0 : Convert.ToDecimal(oReader["ImpuestoRetenido"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='ConvenioDobImpo'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                oRegCompras.ConvenioDobImpo = oReader["ConvenioDobImpo"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["ConvenioDobImpo"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='ExoneracionApli'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                oRegCompras.ExoneracionApli = oReader["ExoneracionApli"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["ExoneracionApli"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='ModalidadServicio'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                oRegCompras.ModalidadServicio = oReader["ModalidadServicio"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["ModalidadServicio"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='LeyImpuestoRenta'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                oRegCompras.LeyImpuestoRenta = oReader["LeyImpuestoRenta"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["LeyImpuestoRenta"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Estado'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                oRegCompras.Estado = oReader["Estado"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["Estado"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='desFile'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                oRegCompras.desFile = oReader["desFile"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["desFile"]);

            oReader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='tipoPersoneriaDaot'";
            if (oReader.GetSchemaTable().DefaultView.Count.Equals(1))
                oRegCompras.tipoPersoneriaDaot = oReader["tipoPersoneriaDaot"] == DBNull.Value ? String.Empty : Convert.ToString(oReader["tipoPersoneriaDaot"]);
            

            return oRegCompras;
        }

        public List<RegistroComprasE> RegistroDeComprasLe(Int32 idEmpresa, Int32 idLocal, DateTime fecIni, DateTime fecFin, String idMoneda, String indComprasVarias)
        {
            List<RegistroComprasE> ListaCompras = new List<RegistroComprasE>();
            RegistroComprasE Item = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_RegistroDeComprasLe", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@idLocal", SqlDbType.Int).Value = idLocal;
                    oComando.Parameters.Add("@fecIni", SqlDbType.SmallDateTime).Value = fecIni;
                    oComando.Parameters.Add("@fecFin", SqlDbType.SmallDateTime).Value = fecFin;
                    oComando.Parameters.Add("@idMoneda", SqlDbType.VarChar, 2).Value = idMoneda;
                    oComando.Parameters.Add("@indComprasVarias", SqlDbType.Char, 1).Value = indComprasVarias;

                    oConexion.Open();

                    using (SqlDataReader oReader = oComando.ExecuteReader())
                    {
                        while (oReader.Read())
                        {
                            Item = LlenarEntidad(oReader);
                            ListaCompras.Add(Item);
                        }
                    }
                }
            }

            return ListaCompras;
        }

        public List<RegistroComprasE> RegistroDeComprasLeNoDom(Int32 idEmpresa, Int32 idLocal, DateTime fecIni, DateTime fecFin, String idMoneda)
        {
            List<RegistroComprasE> ListaCompras = new List<RegistroComprasE>();
            RegistroComprasE Item = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_RegistroDeComprasLeNoDom", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@idLocal", SqlDbType.Int).Value = idLocal;
                    oComando.Parameters.Add("@fecIni", SqlDbType.SmallDateTime).Value = fecIni;
                    oComando.Parameters.Add("@fecFin", SqlDbType.SmallDateTime).Value = fecFin;
                    oComando.Parameters.Add("@idMoneda", SqlDbType.VarChar, 2).Value = idMoneda;

                    oConexion.Open();

                    using (SqlDataReader oReader = oComando.ExecuteReader())
                    {
                        while (oReader.Read())
                        {
                            Item = LlenarEntidad(oReader);
                            ListaCompras.Add(Item);
                        }
                    }
                }
            }

            return ListaCompras;
        }

        //Especial
        public List<RegistroComprasE> ReporteDetalleComprasEspecial(Int32 idEmpresa, Int32 idLocal, Int32 idPersona, String numVerPlanCuenta, String AnioPeriodo, String MesIni, String MesFin, String idMoneda)
        {
            List<RegistroComprasE> ListaCompras = new List<RegistroComprasE>();
            RegistroComprasE Item = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ReporteDetalleComprasEspecial", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@idLocal", SqlDbType.Int).Value = idLocal;
                    oComando.Parameters.Add("@idPersona", SqlDbType.Int).Value = idPersona;
                    oComando.Parameters.Add("@numVerPlanCuenta", SqlDbType.VarChar, 3).Value = numVerPlanCuenta;
                    oComando.Parameters.Add("@AnioPeriodo", SqlDbType.VarChar, 4).Value = AnioPeriodo;
                    oComando.Parameters.Add("@MesIni", SqlDbType.VarChar, 2).Value = MesIni;
                    oComando.Parameters.Add("@MesFin", SqlDbType.VarChar, 2).Value = MesFin;
                    oComando.Parameters.Add("@idMoneda", SqlDbType.VarChar, 2).Value = idMoneda;

                    oConexion.Open();

                    using (SqlDataReader oReader = oComando.ExecuteReader())
                    {
                        while (oReader.Read())
                        {
                            Item = LlenarEntidad(oReader);
                            ListaCompras.Add(Item);
                        }
                    }
                }
            }

            return ListaCompras;
        }

        public List<RegistroComprasE> ReporteResumenComprasEspecial(Int32 idEmpresa, Int32 idLocal, Int32 idPersona, String numVerPlanCuenta, String AnioPeriodo, String MesIni, String MesFin, String idMoneda)
        {
            List<RegistroComprasE> ListaCompras = new List<RegistroComprasE>();
            RegistroComprasE Item = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ReporteResumenComprasEspecial", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@idLocal", SqlDbType.Int).Value = idLocal;
                    oComando.Parameters.Add("@idPersona", SqlDbType.Int).Value = idPersona;
                    oComando.Parameters.Add("@numVerPlanCuenta", SqlDbType.VarChar, 3).Value = numVerPlanCuenta;
                    oComando.Parameters.Add("@AnioPeriodo", SqlDbType.VarChar, 4).Value = AnioPeriodo;
                    oComando.Parameters.Add("@MesIni", SqlDbType.VarChar, 2).Value = MesIni;
                    oComando.Parameters.Add("@MesFin", SqlDbType.VarChar, 2).Value = MesFin;
                    oComando.Parameters.Add("@idMoneda", SqlDbType.VarChar, 2).Value = idMoneda;

                    oConexion.Open();

                    using (SqlDataReader oReader = oComando.ExecuteReader())
                    {
                        while (oReader.Read())
                        {
                            Item = LlenarEntidad(oReader);
                            ListaCompras.Add(Item);
                        }
                    }
                }
            }

            return ListaCompras;
        }

        public List<RegistroComprasE> ReporteNaturalezaComprasEspecial(Int32 idEmpresa, Int32 idLocal, Int32 idPersona, String numVerPlanCuenta, String AnioPeriodo, String MesIni, String MesFin, String idMoneda)
        {
            List<RegistroComprasE> ListaCompras = new List<RegistroComprasE>();
            RegistroComprasE Item = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ReporteNaturalezaComprasEspecial", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@idLocal", SqlDbType.Int).Value = idLocal;
                    oComando.Parameters.Add("@idPersona", SqlDbType.Int).Value = idPersona;
                    oComando.Parameters.Add("@numVerPlanCuenta", SqlDbType.VarChar, 3).Value = numVerPlanCuenta;
                    oComando.Parameters.Add("@AnioPeriodo", SqlDbType.VarChar, 4).Value = AnioPeriodo;
                    oComando.Parameters.Add("@MesIni", SqlDbType.VarChar, 2).Value = MesIni;
                    oComando.Parameters.Add("@MesFin", SqlDbType.VarChar, 2).Value = MesFin;
                    oComando.Parameters.Add("@idMoneda", SqlDbType.VarChar, 2).Value = idMoneda;

                    oConexion.Open();

                    using (SqlDataReader oReader = oComando.ExecuteReader())
                    {
                        while (oReader.Read())
                        {
                            Item = LlenarEntidad(oReader);
                            ListaCompras.Add(Item);
                        }
                    }
                }
            }

            return ListaCompras;
        }

        public List<RegistroComprasE> ReporteCuentaComprasEspecial(Int32 idEmpresa, Int32 idLocal, Int32 idPersona, String numVerPlanCuenta, String AnioPeriodo, String MesIni, String MesFin, String idMoneda)
        {
            List<RegistroComprasE> ListaCompras = new List<RegistroComprasE>();
            RegistroComprasE Item = null;

            using (SqlConnection oConexion = ConexionSql())
            {
                using (SqlCommand oComando = new SqlCommand("retail.usp_ReporteCuentaComprasEspecial", oConexion))
                {
                    oComando.CommandType = CommandType.StoredProcedure;
                    oComando.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
                    oComando.Parameters.Add("@idLocal", SqlDbType.Int).Value = idLocal;
                    oComando.Parameters.Add("@idPersona", SqlDbType.Int).Value = idPersona;
                    oComando.Parameters.Add("@numVerPlanCuenta", SqlDbType.VarChar, 3).Value = numVerPlanCuenta;
                    oComando.Parameters.Add("@AnioPeriodo", SqlDbType.VarChar, 4).Value = AnioPeriodo;
                    oComando.Parameters.Add("@MesIni", SqlDbType.VarChar, 2).Value = MesIni;
                    oComando.Parameters.Add("@MesFin", SqlDbType.VarChar, 2).Value = MesFin;
                    oComando.Parameters.Add("@idMoneda", SqlDbType.VarChar, 2).Value = idMoneda;

                    oConexion.Open();

                    using (SqlDataReader oReader = oComando.ExecuteReader())
                    {
                        while (oReader.Read())
                        {
                            Item = LlenarEntidad(oReader);
                            ListaCompras.Add(Item);
                        }
                    }
                }
            }

            return ListaCompras;
        }

    }
}
