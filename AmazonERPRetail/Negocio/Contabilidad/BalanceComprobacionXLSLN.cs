using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Transactions;
using System.Linq;

using Entidades.Contabilidad;
using Entidades.Generales;
using AccesoDatos.Contabilidad;
using AccesoDatos.Generales;
using Infraestructura;
using Infraestructura.Extensores;
using Infraestructura.Enumerados;

namespace Negocio.Contabilidad
{
    public class BalanceComprobacionXLSLN
    {

        public Int32 InsertarBalanceComprobacionXLS(List<BalanceComprobacionXLSE> oListaBalanceComp)
        {
            try
            {
                Int32 FilasDevueltas = Variables.Cero;

                TransactionOptions Opciones = new TransactionOptions
                {
                    Timeout = TimeSpan.FromMinutes(240)
                };

                using (TransactionScope oTrans = new TransactionScope(TransactionScopeOption.Required, Opciones))
                {
                    //Insertando a la BD el resultado final de la lista
                    using (DataTable oDt = Colecciones.ToDataTable<BalanceComprobacionXLSE>(oListaBalanceComp))
                    {
                        FilasDevueltas = new BalanceComprobacionXLSAD().InsertarBalanceComprobacionXLS(oDt);
                    }

                    //Cerrando la transaccion
                    oTrans.Complete();
                }

                return FilasDevueltas;
            }
            catch (SqlException ex)
            {
                SqlError err = ex.Errors[0];
                StringBuilder mensaje = new StringBuilder();

                switch (err.Number)
                {
                    default:
                        mensaje.Append("Mensaje: " + err.Message + "\n");
                        mensaje.Append("N° Linea: " + err.LineNumber + "\n");
                        mensaje.Append("Origen: " + err.Source + "\n");
                        mensaje.Append("Procedimiento: " + err.Procedure + "\n");
                        mensaje.Append("N° Error: " + err.Number);
                        break;
                }

                throw new Exception(mensaje.ToString());
            }
        }

        public Int32 IntegrarBalanceComprobacionXLS(List<BalanceComprobacionXLSE> oListaBalance, Int32 idLocal, DateTime Fecha, String VercionPC, Int32 NivelPC, String Usuario)
        {
            try
            {
                Int32 resp = 0;

                using (TransactionScope oTrans = new TransactionScope())
                {
                    Int32 idEmpresa = oListaBalance[0].idEmpresa;
                    Int32 Item = 1;
                    String indDebeHaber = String.Empty;
                    Decimal MontoS = 0;
                    Decimal MontoD = 0;
                    //Tipo de cambio
                    TipoCambioE oTica = new TipoCambioAD().ObtenerTipoCambioPorDia("02", Fecha.ToString("yyyyMMdd"));
                    //Plan de Cuentas...
                    List<PlanCuentasE> oPlanCuentas = new PlanCuentasAD().ListarPlanCuentasPorNivel(idEmpresa, VercionPC, NivelPC);
                    //Parámetros Contables
                    ParametrosContaE oParametro = new ParametrosContaAD().ObtenerParametrosConta(idEmpresa);
                    //Auxiliar
                    Int32? idPersona_ = 0;
                    //Documento
                    String idDoc = String.Empty;
                    String serDoc = String.Empty;
                    String numDoc = String.Empty;
                    DateTime? fec = (DateTime?)null;
                    //C.Costos
                    String cCostos = String.Empty;

                    if (oTica == null)
                    {
                        throw new Exception(String.Format("No existe Tipo de Cambio para la fecha escogida {0}", Fecha.ToString("dd/MM/yyyy")));
                    }

                    if (oParametro.idAuxiliarVarios == 0)
                    {
                        throw new Exception("Falta colocar Auxiliar Varios en Parámetros Contables");
                    }

                    #region Cabecera del Voucher

                    VoucherE oVoucher = new VoucherE
                    {
                        idEmpresa = idEmpresa,
                        idLocal = idLocal,
                        AnioPeriodo = Fecha.ToString("yyyy"),
                        MesPeriodo = Fecha.ToString("MM"),
                        numVoucher = "0",
                        idComprobante = "08",
                        numFile = "04",
                        idMoneda = "01",
                        fecOperacion = Fecha.Date,
                        fecDocumento = Fecha.Date,
                        GlosaGeneral = "BALANCE COMPROBACION A " + Fecha.ToString("MM-yyyy"),
                        tipCambio = oTica.valVenta,
                        RazonSocial = "VARIOS",
                        numDocumentoPresu = String.Empty,
                        indHojaCosto = Variables.NO,
                        numHojaCosto = String.Empty,
                        numOrdenCompra = String.Empty,
                        sistema = "1", //Contabilidad
                        EsAutomatico = false,
                        UsuarioRegistro = Usuario
                    };

                    #endregion Cabecera del Voucher

                    foreach (BalanceComprobacionXLSE item in oListaBalance)
                    {
                        #region Detalle del voucher

                        ////Obteniendo el Plan de Cuentas...
                        PlanCuentasE oCuenta = oPlanCuentas.Find
                        (
                            delegate (PlanCuentasE c) { return c.codCuenta == item.CtaIndusoft; }
                        );

                        if (oCuenta == null)
                        {
                            throw new Exception(String.Format("La cuenta {0} no existe en el Plan Contable. Revise por favor.", item.CtaIndusoft));
                        }

                        #region Si solicita auxiliar

                        if (oCuenta.indSolicitaAnexo == Variables.SI)
                        {
                            idPersona_ = oParametro.idAuxiliarVarios;
                        }
                        else
                        {
                            idPersona_ = (Nullable<Int32>)null;
                        }

                        #endregion

                        #region Si solicita Documento

                        if (oCuenta.indSolicitaDcto == "S")
                        {
                            idDoc = "OT";
                            serDoc = String.Empty;
                            numDoc = Fecha.ToString("MM") + "-" + Fecha.ToString("yyyy");
                            fec = Fecha;
                        }
                        else
                        {
                            idDoc = String.Empty;
                            serDoc = String.Empty;
                            numDoc = String.Empty;
                            fec = (DateTime?)null;
                        }

                        #endregion

                        #region Centro de Costos

                        if (oCuenta.indSolicitaCentroCosto == "S")
                        {
                            cCostos = oParametro.Costo;
                        }
                        else
                        {
                            cCostos = String.Empty;
                        }

                        #endregion

                        if (item.DesviacionAbsoluta > 0)
                        {
                            indDebeHaber = "D";
                            MontoS = item.DesviacionAbsoluta;
                        }
                        else
                        {
                            indDebeHaber = "H";
                            MontoS = Math.Abs(item.DesviacionAbsoluta);
                        }

                        MontoD = Decimal.Round(MontoS / oTica.valVenta, 2);

                        VoucherItemE oItemVoucher = new VoucherItemE
                        {
                            idEmpresa = idEmpresa,
                            idLocal = idLocal,
                            AnioPeriodo = Fecha.ToString("yyyy"),
                            MesPeriodo = Fecha.ToString("MM"),
                            numVoucher = "0",
                            idComprobante = "08",
                            numFile = "04",
                            numItem = String.Format("{0:00000}", Item),
                            idPersona = idPersona_,
                            idMoneda = "01",
                            tipCambio = oTica.valVenta,
                            indCambio = "S",
                            idCCostos = cCostos,
                            numVerPlanCuentas = VercionPC,
                            codCuenta = item.CtaIndusoft,
                            desGlosa = oVoucher.GlosaGeneral,
                            fecDocumento = fec,
                            fecVencimiento = (Nullable<DateTime>)null,
                            idDocumento = idDoc,
                            serDocumento = serDoc,
                            numDocumento = numDoc,
                            fecDocumentoRef = null,
                            idDocumentoRef = String.Empty,
                            serDocumentoRef = String.Empty,
                            numDocumentoRef = String.Empty,
                            indDebeHaber = indDebeHaber,
                            impSoles = MontoS,
                            impDolares = MontoD,
                            indAutomatica = "N",
                            CorrelativoAjuste = String.Empty,
                            codFteFin = String.Empty,
                            codProgramaCred = String.Empty,
                            indMovimientoAnterior = String.Empty,
                            tipPartidaPresu = String.Empty,
                            codPartidaPresu = String.Empty,
                            numDocumentoPresu = String.Empty,
                            codColumnaCoven = (Int32?)null,
                            depAduanera = Variables.Cero,
                            AnioDua = String.Empty,
                            nroDua = String.Empty,
                            flagDetraccion = Variables.NO,
                            numDetraccion = String.Empty,
                            fecDetraccion = null,
                            tipDetraccion = String.Empty,
                            TasaDetraccion = Variables.ValorCeroDecimal,
                            MontoDetraccion = Variables.ValorCeroDecimal,
                            indReparable = "N",
                            idConceptoRep = null,
                            desReferenciaRep = String.Empty,
                            idAlmacen = String.Empty,
                            tipMovimientoAlmacen = String.Empty,
                            numDocumentoAlmacen = String.Empty,
                            numItemAlmacen = String.Empty,
                            CajaSucursal = String.Empty,
                            indCompra = String.Empty,
                            indConciliado = String.Empty,
                            fecRecepcion = null,
                            codMedioPago = 0,
                            idCampana = null,
                            idConceptoGasto = null,
                            UsuarioRegistro = Usuario,

                            indCuentaGastos = oCuenta.indCuentaGastos,
                            codCuentaDestino = oCuenta.codCuentaDestino,
                            codCuentaTransferencia = oCuenta.codCuentaTransferencia
                        };

                        oVoucher.ListaVouchers.Add(oItemVoucher);
                        Item++;
                        oItemVoucher = null;

                        #endregion
                    }

                    #region Cuentas Automáticas

                    List<VoucherItemE> oListaVoucherItems = new List<VoucherItemE>(oVoucher.ListaVouchers);

                    foreach (VoucherItemE item in oListaVoucherItems)
                    {
                        if (item.indCuentaGastos == Variables.SI)
                        {
                            if (!String.IsNullOrEmpty(item.codCuentaDestino))
                            {
                                oVoucher.ListaVouchers.Add(CuentaAutomatica(item, Item, item.codCuentaDestino));
                                Item++;
                            }

                            if (!String.IsNullOrEmpty(item.codCuentaTransferencia))
                            {
                                oVoucher.ListaVouchers.Add(CuentaAutomatica(item, Item, item.codCuentaTransferencia));
                                Item++;
                            }
                        }
                    }

                    #endregion

                    #region Completando datos de la Cabecera del Voucher

                    Decimal totDebeSoles = Decimal.Round((from x in oVoucher.ListaVouchers where x.indDebeHaber == Variables.Debe select x.impSoles).Sum(), 2);
                    Decimal totDebeDolares = Decimal.Round((from x in oVoucher.ListaVouchers where x.indDebeHaber == Variables.Debe select x.impDolares).Sum(), 2);
                    Decimal totHaberSoles = Decimal.Round((from x in oVoucher.ListaVouchers where x.indDebeHaber == Variables.Haber select x.impSoles).Sum(), 2);
                    Decimal totHaberDolares = Decimal.Round((from x in oVoucher.ListaVouchers where x.indDebeHaber == Variables.Haber select x.impDolares).Sum(), 2);
                    Decimal impDifSoles = Variables.ValorCeroDecimal, impDifDolares = Variables.ValorCeroDecimal;

                    impDifSoles = totDebeSoles - totHaberSoles;
                    impDifDolares = totDebeDolares - totHaberDolares;

                    oVoucher.impDebeSoles = totDebeSoles;
                    oVoucher.impHaberSoles = totHaberSoles;
                    oVoucher.impDebeDolares = totDebeDolares;
                    oVoucher.impHaberDolares = totHaberDolares;

                    if (oVoucher.idMoneda == Variables.Soles)
                    {
                        oVoucher.impMonOrigDeb = totDebeSoles;
                        oVoucher.impMonOrigHab = totHaberSoles;
                    }
                    else
                    {
                        oVoucher.impMonOrigDeb = totDebeDolares;
                        oVoucher.impMonOrigHab = totHaberDolares;
                    }

                    if (impDifSoles != Variables.Cero || impDifDolares != Variables.Cero)
                    {
                        oVoucher.indEstado = Variables.VoucherDescuadrado;
                    }
                    else
                    {
                        oVoucher.indEstado = Variables.VoucherCuadrado;
                    }

                    #endregion

                    oVoucher.numItems = oVoucher.ListaVouchers.Count();

                    new VoucherAD().TriggerVouchers(true); //Desabilita Trigger
                    new VoucherLN().GrabarVouchers(oVoucher, EnumOpcionGrabar.Insertar);
                    new VoucherAD().TriggerVouchers(false); //Habilita Trigger

                    oTrans.Complete();
                }

                return resp;
            }
            catch (SqlException ex)
            {
                SqlError err = ex.Errors[0];
                StringBuilder mensaje = new StringBuilder();

                new VoucherAD().TriggerVouchers(false); //Habilita Trigger

                switch (err.Number)
                {
                    default:
                        mensaje.Append("Mensaje: " + err.Message + "\n");
                        mensaje.Append("N° Linea: " + err.LineNumber + "\n");
                        mensaje.Append("Origen: " + err.Source + "\n");
                        mensaje.Append("Procedimiento: " + err.Procedure + "\n");
                        mensaje.Append("N° Error: " + err.Number);
                        break;
                }

                throw new Exception(mensaje.ToString());
            }
        }

        public Int32 ProcesarBalanceXLS(Int32 idEmpresa, Int32 idLocal, Int32 idUsuario, String numVerPlanCuentas)
        {
            try
            {
                return new BalanceComprobacionXLSAD().ProcesarBalanceXLS(idEmpresa, idLocal, idUsuario, numVerPlanCuentas);
            }
            catch (SqlException ex)
            {
                SqlError err = ex.Errors[0];
                StringBuilder mensaje = new StringBuilder();

                switch (err.Number)
                {
                    default:
                        mensaje.Append("Mensaje: " + err.Message + "\n");
                        mensaje.Append("N° Linea: " + err.LineNumber + "\n");
                        mensaje.Append("Origen: " + err.Source + "\n");
                        mensaje.Append("Procedimiento: " + err.Procedure + "\n");
                        mensaje.Append("N° Error: " + err.Number);
                        break;
                }

                throw new Exception(mensaje.ToString());
            }
        }

        public Int32 EliminarBalanceComprobacionXLS(Int32 idEmpresa, Int32 idUsuario)
        {
            try
            {
                return new BalanceComprobacionXLSAD().EliminarBalanceComprobacionXLS(idEmpresa, idUsuario);
            }
            catch (SqlException ex)
            {
                SqlError err = ex.Errors[0];
                StringBuilder mensaje = new StringBuilder();

                switch (err.Number)
                {
                    default:
                        mensaje.Append("Mensaje: " + err.Message + "\n");
                        mensaje.Append("N° Linea: " + err.LineNumber + "\n");
                        mensaje.Append("Origen: " + err.Source + "\n");
                        mensaje.Append("Procedimiento: " + err.Procedure + "\n");
                        mensaje.Append("N° Error: " + err.Number);
                        break;
                }

                throw new Exception(mensaje.ToString());
            }
        }

        #region Privadas

        private VoucherItemE CuentaAutomatica(VoucherItemE oItemTemp, Int32 numItem, String Cuenta)
        {
            String DebeHaber = String.Empty;

            if (oItemTemp.codCuentaDestino == Cuenta)
            {
                DebeHaber = oItemTemp.indDebeHaber;
            }

            if (oItemTemp.codCuentaTransferencia == Cuenta)
            {
                if (oItemTemp.indDebeHaber == Variables.Debe)
                {
                    DebeHaber = Variables.Haber;
                }
                else
                {
                    DebeHaber = Variables.Debe;
                }
            }

            VoucherItemE oItemVoucher = new VoucherItemE
            {
                idEmpresa = oItemTemp.idEmpresa,
                idLocal = oItemTemp.idLocal,
                AnioPeriodo = oItemTemp.AnioPeriodo,
                MesPeriodo = oItemTemp.MesPeriodo,
                numVoucher = oItemTemp.numVoucher,
                idComprobante = oItemTemp.idComprobante,
                numFile = oItemTemp.numFile,
                numItem = String.Format("{0:00000}", numItem),
                idPersona = (Nullable<Int32>)null,
                idMoneda = oItemTemp.idMoneda,
                tipCambio = oItemTemp.tipCambio,
                indCambio = Variables.SI,
                idCCostos = String.Empty,
                numVerPlanCuentas = oItemTemp.numVerPlanCuentas,
                codCuenta = Cuenta,
                desGlosa = oItemTemp.desGlosa,
                fecDocumento = (Nullable<DateTime>)null,
                fecVencimiento = (Nullable<DateTime>)null,
                idDocumento = String.Empty,
                serDocumento = String.Empty,
                numDocumento = String.Empty,
                fecDocumentoRef = (Nullable<DateTime>)null,
                idDocumentoRef = String.Empty,
                serDocumentoRef = String.Empty,
                numDocumentoRef = String.Empty,
                indDebeHaber = DebeHaber,
                impSoles = oItemTemp.impSoles,
                impDolares = oItemTemp.impDolares,
                indAutomatica = Variables.SI,
                CorrelativoAjuste = String.Empty,
                codFteFin = String.Empty,
                codProgramaCred = String.Empty,
                indMovimientoAnterior = String.Empty,
                tipPartidaPresu = String.Empty,
                codPartidaPresu = String.Empty,
                numDocumentoPresu = String.Empty,
                codColumnaCoven = Variables.Cero,
                depAduanera = Variables.Cero,
                AnioDua = String.Empty,
                nroDua = String.Empty,
                flagDetraccion = Variables.NO,
                numDetraccion = String.Empty,
                fecDetraccion = (Nullable<DateTime>)null,
                tipDetraccion = String.Empty,
                TasaDetraccion = Variables.ValorCeroDecimal,
                MontoDetraccion = Variables.ValorCeroDecimal,
                indReparable = Variables.NO,
                idConceptoRep = (Nullable<Int32>)null,
                desReferenciaRep = String.Empty,
                idAlmacen = String.Empty,
                tipMovimientoAlmacen = String.Empty,
                numDocumentoAlmacen = String.Empty,
                numItemAlmacen = String.Empty,
                CajaSucursal = String.Empty,
                indCompra = String.Empty,
                indConciliado = String.Empty,
                fecRecepcion = (Nullable<DateTime>)null,
                codMedioPago = 0,
                idCampana = (Nullable<Int32>)null,
                idConceptoGasto = (Nullable<Int32>)null,
                UsuarioRegistro = oItemTemp.UsuarioRegistro
            };

            return oItemVoucher;
        }

        #endregion

    }
}
