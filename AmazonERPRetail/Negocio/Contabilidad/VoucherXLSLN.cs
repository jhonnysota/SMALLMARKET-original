using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Transactions;
using System.Linq;

using Entidades.Contabilidad;
using Entidades.Maestros;
using AccesoDatos.Contabilidad;
using AccesoDatos.Maestros;
using Infraestructura;
using Infraestructura.Extensores;

namespace Negocio.Contabilidad
{
    public class VoucherXLSLN 
    {

        public Int32 InsertarVoucherXLS(List<VoucherXLSE> oListaVoucher)//, Int32 idEmpresa, Int32 idLocal, Boolean Eliminar)
        {
            try
            {
                Int32 FilasDevueltas = Variables.Cero;

                TransactionOptions Opciones = new TransactionOptions();
                Opciones.Timeout = TimeSpan.FromMinutes(240);

                using (TransactionScope oTrans = new TransactionScope(TransactionScopeOption.Required, Opciones))
                {
                    //Insertando a la BD el resultado final de la lista
                    using (DataTable oDt = Colecciones.ToDataTable<VoucherXLSE>(oListaVoucher))
                    {
                        FilasDevueltas = new VoucherXLSAD().InsertarVoucherXLS(oDt);
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

        public Int32 ErroresVoucherXLS(List<VoucherXLSE> oListaErrores)
        {
            try
            {
                Int32 FilasDevueltas = Variables.Cero;

                foreach (VoucherXLSE item in oListaErrores)
                {
                    FilasDevueltas += new VoucherXLSAD().ProcesarVoucherXLS(item.idEmpresa, item.idLocal);
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

        public Int32 IntegrarVoucherXLS(Int32 idEmpresa, Int32 idLocal, String Usuario, List<VoucherXLSE> oListaVoucher, Boolean EliminarVouchers, String Borrar)
        {
            String DiarioErr = String.Empty;
            String FileErr = String.Empty;
            String numVoucherErr = String.Empty;
            Boolean GenerarDestino = true;
            Int32 Linea = 0;

            try
            {
                #region Variables

                Int32 FilasDevueltas = Variables.Cero;
                var ListaAgrupada = oListaVoucher.GroupBy(x => new { x.idLocal, x.Anio, x.Mes, x.Diario, x.NumFile, x.Numero }).Select(g => g.First()).ToList();

                List<VoucherXLSE> ListaOrdenada = new List<VoucherXLSE>(from x in ListaAgrupada.ToList()
                                                                        orderby x.Anio, x.Mes, x.Diario, x.NumFile, x.Numero
                                                                        select x).ToList();
                VoucherE oVoucher = null;
                Int32 Item = 1;
                //Obteniendo la Version del Plan de Cuentas
                PlanCuentasVersionE oNumVerPlanCuentas = new PlanCuentasVersionAD().VersionPlanCuentasActual(idEmpresa);
                //Plan de Cuentas...
                List<PlanCuentasE> oPlanCuentas = new PlanCuentasAD().ListarPlanCuentasPorNivel(idEmpresa, oNumVerPlanCuentas.numVerPlanCuentas, Convert.ToInt32(oNumVerPlanCuentas.UltimoNivel));
                //Auxiliar
                Persona oPersona = null;
                Int32? idPersona_ = 0;
                String Ruc_ = String.Empty;
                //Documento
                String idDoc = String.Empty;
                String serDoc = String.Empty;
                String numDoc = String.Empty;
                DateTime? fec = (DateTime?)null;
                //Documento de referencia
                String idDocRef = String.Empty;
                String serDocRef = String.Empty;
                String numDocRef = String.Empty;
                DateTime? fecRef = (DateTime?)null;
                Boolean EsAnulado = false;
                Boolean EsCabecera = true;
                Int32? idPartabla = 0;
                //C.Costos
                String cCostos = String.Empty;

                #endregion

                TransactionOptions Opciones = new TransactionOptions
                {
                    Timeout = TimeSpan.FromMinutes(300)
                };

                using (TransactionScope oTrans = new TransactionScope(TransactionScopeOption.Required, Opciones))
                {
                    if (Borrar == "S")
                    {
                        if (EliminarVouchers)
                        {
                            var ListaPorBorrar = oListaVoucher.GroupBy(x => new { x.idLocal, x.Anio, x.Mes, x.Diario, x.NumFile }).Select(g => g.First()).ToList();

                            ////Eliminando Voucher...
                            foreach (VoucherXLSE item in ListaPorBorrar.ToList())
                            {
                                new VoucherAD().EliminarVoucherPorPeriodos(idEmpresa, item.idLocal, item.Diario, item.NumFile, item.Anio + item.Mes);
                            }

                            ListaPorBorrar = null;
                        }
                    }

                    new VoucherAD().TriggerVouchers(true); //Desabilita Trigger

                    foreach (VoucherXLSE itemTmp in ListaOrdenada.ToList())
                    {
                        Linea = itemTmp.Linea;
                        DiarioErr = itemTmp.Diario;
                        FileErr = itemTmp.NumFile;
                        numVoucherErr = itemTmp.Numero;

                        #region Preparando Archivo de Carga

                        List<VoucherXLSE> oListita = new List<VoucherXLSE>(from x in oListaVoucher
                                                                           where x.idLocal == itemTmp.idLocal
                                                                           && x.Anio == itemTmp.Anio
                                                                           && x.Mes == itemTmp.Mes
                                                                           && x.Diario == itemTmp.Diario
                                                                           && x.NumFile == itemTmp.NumFile
                                                                           && x.Numero == itemTmp.Numero
                                                                           select x).ToList();
                        foreach (VoucherXLSE itemReal in oListita)
                        {
                            Linea = itemReal.Linea;

                            if (EsCabecera)
                            {
                                #region Cabecera del Voucher

                                oVoucher = new VoucherE
                                {
                                    idEmpresa = idEmpresa,
                                    idLocal = itemReal.idLocal,
                                    AnioPeriodo = itemReal.Anio,
                                    MesPeriodo = itemReal.Mes,
                                    numVoucher = String.Format("{0:000000000}", Convert.ToInt32(itemReal.Numero)),
                                    idComprobante = itemReal.Diario,
                                    numFile = itemReal.NumFile,
                                    idMoneda = itemReal.Moneda,
                                    fecOperacion = itemReal.FechaOperacion,
                                    fecDocumento = itemReal.Fecha,
                                    GlosaGeneral = itemReal.GlosaGeneral,
                                    tipCambio = itemReal.TipoCambio,
                                    RazonSocial = itemReal.DescripcionLarga,
                                    numDocumentoPresu = String.Empty,
                                    indHojaCosto = Variables.NO,
                                    numHojaCosto = String.Empty,
                                    numOrdenCompra = String.Empty,
                                    sistema = "1", //Contabilidad
                                    EsAutomatico = false,
                                    UsuarioRegistro = Usuario
                                };

                                EsCabecera = false;

                                #endregion Cabecera del Voucher
                            }

                            #region Detalle del voucher

                            ////Obteniendo el Plan de Cuentas...
                            PlanCuentasE oCuenta = oPlanCuentas.Find
                            (
                                delegate (PlanCuentasE c) { return c.codCuenta == itemReal.Cuenta; }
                            );

                            if (oCuenta == null)
                            {
                                throw new Exception(String.Format("La cuenta {0} no existe en el Plan Contable. Revise por favor.", itemReal.Cuenta));
                            }

                            idPartabla = itemReal.Codigo;

                            #region Si solicita auxiliar

                            if (oCuenta.indSolicitaAnexo == Variables.SI)
                            {
                                if (Ruc_ != itemReal.RUC)//oPersona == null || idPersona_ == null)
                                {
                                    oPersona = new PersonaAD().ObtenerPersonaPorNroRuc(itemReal.RUC);

                                    if (oPersona != null)
                                    {
                                        idPersona_ = oPersona.IdPersona;
                                    }
                                    else
                                    {
                                        idPersona_ = (Nullable<Int32>)null;
                                    }
                                }

                                Ruc_ = itemReal.RUC;

                                if (itemReal.DescripcionLarga.Contains("ANULADO") || itemReal.DescripcionLarga.Contains("ANULADA"))
                                {
                                    ParametrosContaE oParametroCon = new ParametrosContaAD().ObtenerParametrosConta(idEmpresa);

                                    if (oParametroCon == null)
                                    {
                                        throw new Exception("No se ha configurado el Parámetro de Anulado en los Parámetros de Contabilidad.");
                                    }
                                    else
                                    {
                                        idPersona_ = oParametroCon.idAnulado;
                                    }

                                    EsAnulado = true;
                                }
                            }
                            else
                            {
                                idPersona_ = (Nullable<Int32>)null;
                                Ruc_ = String.Empty;
                            }

                            #endregion

                            #region Si solicita Documento

                            if (oCuenta.indSolicitaDcto == "S")
                            {
                                idDoc = itemReal.TipoDoc;
                                serDoc = String.IsNullOrWhiteSpace(itemReal.Serie) ? String.Empty : itemReal.Serie;
                                numDoc = itemReal.Documentos;
                                fec = itemReal.Fecha;

                                if (itemReal.TipoDoc == "NC" || itemReal.TipoDoc == "CR" || itemReal.TipoDoc == "ND")
                                {
                                    idDocRef = itemReal.TipoDocRef;
                                    serDocRef = itemReal.SerieDocRef;
                                    numDocRef = itemReal.NumDocRef;
                                    fecRef = itemReal.FechaRef;
                                }
                                else
                                {
                                    idDocRef = String.Empty;
                                    serDocRef = String.Empty;
                                    numDocRef = String.Empty;
                                    fecRef = (DateTime?)null;
                                }
                            }
                            else
                            {
                                idDoc = String.Empty;
                                serDoc = String.Empty;
                                numDoc = String.Empty;
                                fec = (DateTime?)null;
                                idDocRef = String.Empty;
                                serDocRef = String.Empty;
                                numDocRef = String.Empty;
                                fecRef = (DateTime?)null;
                            }

                            #endregion

                            #region Centro de Costos

                            if (oCuenta.indSolicitaCentroCosto == "S")
                            {
                                cCostos = itemReal.CentroCosto;
                            }
                            else
                            {
                                cCostos = String.Empty;
                            }

                            #endregion

                            VoucherItemE oItemVoucher = new VoucherItemE
                            {
                                idEmpresa = idEmpresa,
                                idLocal = itemReal.idLocal,
                                AnioPeriodo = itemReal.Anio,
                                MesPeriodo = itemReal.Mes,
                                numVoucher = String.Format("{0:000000000}", Convert.ToInt32(itemReal.Numero)),
                                idComprobante = itemReal.Diario,
                                numFile = itemReal.NumFile,
                                numItem = String.Format("{0:00000}", Item),
                                idPersona = idPersona_,
                                idMoneda = itemReal.Moneda,
                                tipCambio = EsAnulado ? 1 : itemReal.TipoCambio,
                                indCambio = itemReal.indTipoCambio.Substring(0, 1),
                                idCCostos = cCostos,
                                numVerPlanCuentas = oNumVerPlanCuentas.numVerPlanCuentas,
                                codCuenta = itemReal.Cuenta,
                                desGlosa = (itemReal.Glosa != null ? itemReal.Glosa : String.Empty),
                                fecDocumento = fec,
                                fecVencimiento = oCuenta.indSolicitaDcto == Variables.SI ? (itemReal.Fecha != null ? itemReal.FechaVen : (Nullable<DateTime>)null) : (Nullable<DateTime>)null,
                                idDocumento = idDoc,
                                serDocumento = serDoc,
                                numDocumento = numDoc,
                                fecDocumentoRef = fecRef,
                                idDocumentoRef = idDocRef,
                                serDocumentoRef = serDocRef,
                                numDocumentoRef = numDocRef,
                                indDebeHaber = itemReal.indDH,
                                impSoles = itemReal.MontoSoles,
                                impDolares = itemReal.MontoDolares,
                                indAutomatica = itemReal.CtaDes,
                                CorrelativoAjuste = String.Empty,
                                codFteFin = String.Empty,
                                codProgramaCred = String.Empty,
                                indMovimientoAnterior = String.Empty,
                                tipPartidaPresu = String.Empty,
                                codPartidaPresu = String.Empty,
                                numDocumentoPresu = String.Empty,
                                codColumnaCoven = idPartabla,
                                depAduanera = Variables.Cero,
                                AnioDua = String.Empty,
                                nroDua = String.Empty,
                                flagDetraccion = Variables.NO,
                                numDetraccion = String.Empty,
                                fecDetraccion = null,
                                tipDetraccion = String.Empty,
                                TasaDetraccion = Variables.ValorCeroDecimal,
                                MontoDetraccion = Variables.ValorCeroDecimal,
                                indReparable = itemReal.indReparable.Substring(0, 1),
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

                        oListita = null;

                        #endregion

                        #region Cuentas Automáticas

                        if (GenerarDestino)
                        {
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

                        if (EsAnulado)
                        {
                            oVoucher.tipCambio = 1;
                            oVoucher.indEstado = Variables.VoucherAnulado;
                        }

                        #endregion

                        oVoucher.numItems = oVoucher.ListaVouchers.Count();

                        //Insertando el Voucher
                        new VoucherAD().InsertarVoucher(oVoucher);
                        FilasDevueltas++;

                        //Insertando el los Items del Voucher
                        if (oVoucher.ListaVouchers.Count > 0)
                        {
                            foreach (VoucherItemE item in oVoucher.ListaVouchers)
                            {
                                new VoucherItemAD().InsertarVoucherItemSt(item);
                            }
                        }

                        EsCabecera = true;
                        Item = 1;
                        oPersona = null;
                        EsAnulado = false;
                    }

                    oPlanCuentas = null;
                    new VoucherAD().TriggerVouchers(false); //Habilita Trigger
                    //Cerrando la transaccion
                    oTrans.Complete();
                }

                return FilasDevueltas;
            }
            catch (SqlException ex)
            {
                //En caso de error se vuelven habilitar los triggers
                new VoucherAD().TriggerVouchers(false); //Habilita

                SqlError err = ex.Errors[0];
                StringBuilder mensaje = new StringBuilder();

                switch (err.Number)
                {
                    default:
                        mensaje.Append("Linea: " + Linea.ToString() + " Voucher: Diario " + DiarioErr + " File " + FileErr + " Número " + numVoucherErr + "\n");
                        mensaje.Append("Mensaje: " + err.Message + "\n");
                        mensaje.Append("N° Linea: " + err.LineNumber + "\n");
                        mensaje.Append("Origen: " + err.Source + "\n");
                        mensaje.Append("Procedimiento: " + err.Procedure + "\n");
                        mensaje.Append("N° Error: " + err.Number);
                        break;
                }

                throw new Exception(mensaje.ToString());
            }
            catch (Exception ex2)
            {
                String Mensajito = "Linea: " + Linea.ToString() + " Voucher: Diario " + DiarioErr + " File " + FileErr + " Número " + numVoucherErr + "\n";
                throw new Exception(Mensajito + ex2.Message);
            }
        }

        public Int32 EliminarVoucherXLS(List<VoucherXLSE> oListaPorEliminar)
        {
            try
            {
                Int32 resp = 0;

                foreach (VoucherXLSE item in oListaPorEliminar)
                {
                    resp += new VoucherXLSAD().EliminarVoucherXLS(item.idEmpresa, item.idLocal);
                }

                return resp;
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
