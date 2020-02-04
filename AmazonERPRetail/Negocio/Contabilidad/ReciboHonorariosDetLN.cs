using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Transactions;
using System.Linq;

using Entidades.Contabilidad;
using AccesoDatos.Contabilidad;
using Infraestructura;
using Entidades.Generales;
using AccesoDatos.Generales;
using Infraestructura.Enumerados;
using Entidades.Tesoreria;
using AccesoDatos.Tesoreria;

namespace Negocio.Contabilidad
{
    public class ReciboHonorariosDetLN
    {

        public ReciboHonorariosDetE InsertarReciboHonorariosDet(ReciboHonorariosDetE recibohonorariosdet)
        {
            try
            {
                return new ReciboHonorariosDetAD().InsertarReciboHonorariosDet(recibohonorariosdet);
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

        public ReciboHonorariosDetE ActualizarrecibohonorariosDet(ReciboHonorariosDetE recibohonorariosdet)
        {
            try
            {
                return new ReciboHonorariosDetAD().ActualizarReciboHonorariosDet(recibohonorariosdet);
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

        public int EliminarReciboHonorariosDet(Int32 idEmpresa, Int32 idLocal, Int32 idReciboHonorarios, Int32 idReciboHonorariosDet)
        {
            try
            {
                return new ReciboHonorariosDetAD().EliminarReciboHonorariosDet( idEmpresa, idLocal, idReciboHonorarios, idReciboHonorariosDet);
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

        public List<ReciboHonorariosDetE> ListarReciboHonorariosDet(Int32 idEmpresa, Int32 idLocal, Int32 idReciboHonorarios)
        {
            try
            {
                return new ReciboHonorariosDetAD().ListarReciboHonorariosDet( idEmpresa, idLocal,  idReciboHonorarios);
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

        public ReciboHonorariosDetE ObtenerReciboHonorariosDet(Int32 idEmpresa, Int32 idLocal, Int32 idReciboHonorarios, Int32 idReciboHonorariosDet)
        {
            try
            {
                return new ReciboHonorariosDetAD().ObtenerReciboHonorariosDet(idEmpresa, idLocal, idReciboHonorarios, idReciboHonorariosDet);
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

        public ReciboHonorariosDetE CerrarReciboHonorariosDet(ReciboHonorariosDetE recibohonorariosdet)
        {
            try
            {
                ReciboHonorariosDetE oRecibo = null;

                using (TransactionScope oTrans = new TransactionScope())
                {
                    Int32 Resultado = new VoucherAD().EliminarVoucher(recibohonorariosdet.idEmpresa, recibohonorariosdet.idLocal, recibohonorariosdet.AnioPeriodo, recibohonorariosdet.MesPeriodo, recibohonorariosdet.numVoucher, recibohonorariosdet.idComprobante, recibohonorariosdet.numFile);

                    recibohonorariosdet.indVoucher = false;
                    recibohonorariosdet.AnioPeriodo = String.Empty;
                    recibohonorariosdet.MesPeriodo = String.Empty;
                    recibohonorariosdet.numVoucher = String.Empty;
                    recibohonorariosdet.idComprobante = String.Empty;
                    recibohonorariosdet.numFile = String.Empty;

                    oRecibo = new ReciboHonorariosDetAD().CerrarReciboHonorariosDet(recibohonorariosdet);
                    EliminarCtaCte(recibohonorariosdet);

                    //Completando la transacción...
                    oTrans.Complete();
                }
                return oRecibo;
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

        public Int32 GeneraAsientoReciboHonorariosDet(ReciboHonorariosE recibohonorarios, String Usuario)
        {
            Int32 resp = 0;

            try
            {
                using (TransactionScope oTrans = new TransactionScope())
                {
                    #region Genera Asiento

                    ParametrosContaE oParametroConta = new ParametrosContaAD().ObtenerParametrosConta(recibohonorarios.idEmpresa);

                    if (oParametroConta != null)
                    {
                        String DiarioHonorario = oParametroConta.DiarioHonorario;
                        String FileHonorario = oParametroConta.FileHonorario;
                        String CuentaHonorario = String.Empty;
                        String CuentaImpuesto = String.Empty;
                        Decimal TotalHaber = 0;//Convert.ToDecimal(recibohonorariosdet.impRecibo - recibohonorariosdet.impCuartaCat);
                        Decimal ImpuestoHaber = 0;// Convert.ToDecimal(recibohonorariosdet.impCuartaCat);
                        Decimal GastoDebe = 0;// Convert.ToDecimal(recibohonorariosdet.impRecibo);
                        ImpuestosPeriodoE impuestos = null;
                        Int32 numItem = 1;
                        VoucherE voucher = null;

                        if (String.IsNullOrEmpty(DiarioHonorario))
                        {
                            throw new Exception("No esta definido el Libro en los Parámetros Contables");
                        }

                        if (String.IsNullOrEmpty(FileHonorario))
                        {
                            throw new Exception("No esta definido el File en los Parámetros Contables");
                        }

                        foreach (ReciboHonorariosDetE item in recibohonorarios.oListaRecibos)
                        {
                            TotalHaber = Convert.ToDecimal(item.impRecibo - item.impCuartaCat);
                            GastoDebe = Convert.ToDecimal(item.impRecibo);
                            CuentaHonorario = item.codCuenta;

                            if (String.IsNullOrEmpty(CuentaHonorario))
                            {
                                throw new Exception("No esta defininido la Cuenta Contable en los parámetros contables");
                            }

                            if (item.indCuartaCat)
                            {
                                if (impuestos == null)
                                {
                                    impuestos = new ImpuestosPeriodoAD().ObtenerPorcentajeImpuesto(2, item.FechaRecibo);
                                }

                                if (impuestos != null)
                                {
                                    CuentaImpuesto = impuestos.codCuenta;

                                    if (String.IsNullOrWhiteSpace(CuentaImpuesto))
                                    {
                                        throw new Exception("En el impuesto de Cuarta Categoria no esta configurado su cuenta contable.");
                                    }
                                }
                                else
                                {
                                    throw new Exception("El impuesto de Cuarta Categoria no esta configurado.");
                                }
                            }

                            // Cabecera del Voucher Contable //
                            voucher = new VoucherE
                            {
                                idEmpresa = item.idEmpresa,
                                idLocal = item.idLocal,
                                AnioPeriodo = item.FechaOperacion.ToString("yyyy"),
                                MesPeriodo = item.FechaOperacion.ToString("MM"),
                                idComprobante = DiarioHonorario,
                                numFile = FileHonorario,
                                numVoucher = "0",
                                idMoneda = item.idMoneda,
                                fecDocumento = item.FechaRecibo,
                                fecOperacion = item.FechaOperacion,
                                tipCambio = item.TipoCambio,
                                GlosaGeneral = item.Glosa,
                                RazonSocial = recibohonorarios.NomPersona,
                                numDocumentoPresu = item.idDocumento + " " + item.serDocumento + '-' + item.numDocumento,
                                indEstado = "C",
                                indHojaCosto = item.indHojaCosto ? "S" : "N",
                                numHojaCosto = item.indHojaCosto ? item.idHojaCosto.ToString() : String.Empty,
                                numOrdenCompra = String.Empty,
                                sistema = "9", //Ctas por pagar
                                EsAutomatico = true,
                                UsuarioRegistro = Usuario
                            };

                            #region Item 1

                            VoucherItemE ItemHab = new VoucherItemE
                            {
                                idEmpresa = voucher.idEmpresa,
                                idLocal = voucher.idLocal,
                                AnioPeriodo = voucher.AnioPeriodo,
                                MesPeriodo = voucher.MesPeriodo,
                                numVoucher = voucher.numVoucher,
                                idComprobante = voucher.idComprobante,
                                numFile = voucher.numFile,
                                numItem = String.Format("{0:00000}", numItem),
                                idMoneda = item.idMoneda,
                                indDebeHaber = Variables.Haber,
                                codColumnaCoven = null,
                                numVerPlanCuentas = item.numVerPlanCuenta,
                                codCuenta = CuentaHonorario,
                                idPersona = item.idPersona,
                                idDocumento = item.idDocumento,
                                serDocumento = item.serDocumento,
                                numDocumento = item.numDocumento,
                                tipCambio = item.TipoCambio,
                                indCambio = "S",
                                indAutomatica = "N",
                                desGlosa = item.Glosa,
                                fecDocumento = item.FechaRecibo,
                                fecVencimiento = item.FechaRecibo,
                                indMovimientoAnterior = "N",
                                idCCostos = item.idCCostos,
                                idDocumentoRef = String.Empty,
                                serDocumentoRef = String.Empty,
                                numDocumentoRef = String.Empty,
                                CorrelativoAjuste = String.Empty,
                                codFteFin = String.Empty,
                                codProgramaCred = String.Empty,
                                tipPartidaPresu = String.Empty,
                                codPartidaPresu = String.Empty,
                                numDocumentoPresu = String.Empty,
                                depAduanera = null,
                                nroDua = String.Empty,
                                flagDetraccion = "N",
                                numDetraccion = String.Empty,
                                TasaDetraccion = 0,
                                MontoDetraccion = 0,
                                AnioDua = String.Empty,
                                indReparable = "N",
                                desReferenciaRep = String.Empty,
                                idAlmacen = String.Empty,
                                tipMovimientoAlmacen = String.Empty,
                                numDocumentoAlmacen = String.Empty,
                                numItemAlmacen = String.Empty,
                                CajaSucursal = String.Empty,
                                indCompra = "N",
                                indConciliado = "N",
                                tipDetraccion = String.Empty,
                                codMedioPago = null,
                                idCampana = null,
                                idConceptoGasto = null,
                                UsuarioRegistro = Usuario
                            };

                            if (item.idMoneda == Variables.Soles)
                            {
                                ItemHab.impSoles = Convert.ToDecimal(TotalHaber);
                                ItemHab.impDolares = Math.Round(Convert.ToDecimal(TotalHaber / ItemHab.tipCambio), 2);
                            }
                            else
                            {
                                ItemHab.impSoles = Math.Round(Convert.ToDecimal(TotalHaber * ItemHab.tipCambio), 2);
                                ItemHab.impDolares = Convert.ToDecimal(TotalHaber);
                            }

                            voucher.ListaVouchers.Add(ItemHab);

                            #endregion

                            #region Item Cuarta

                            if (item.indCuartaCat)
                            {
                                ImpuestoHaber = Convert.ToDecimal(item.impCuartaCat);
                                VoucherItemE ItemHab40 = Infraestructura.Extensores.Colecciones.CopiarEntidad(ItemHab);
                                numItem++;

                                ItemHab40.codCuenta = CuentaImpuesto;
                                ItemHab40.numItem = String.Format("{0:00000}", numItem);
                                ItemHab40.indDebeHaber = Variables.Haber;

                                if (ItemHab40.idMoneda == Variables.Soles)
                                {
                                    ItemHab40.impSoles = Convert.ToDecimal(ImpuestoHaber);
                                    ItemHab40.impDolares = Math.Round(Convert.ToDecimal(ImpuestoHaber / ItemHab.tipCambio), 2);
                                }
                                else
                                {
                                    ItemHab40.impSoles = Math.Round(Convert.ToDecimal(ImpuestoHaber * ItemHab.tipCambio));
                                    ItemHab40.impDolares = Convert.ToDecimal(ImpuestoHaber);
                                }

                                voucher.ListaVouchers.Add(ItemHab40);
                            } 

                            #endregion

                            #region Item 2

                            VoucherItemE ItemDeb = Infraestructura.Extensores.Colecciones.CopiarEntidad(ItemHab);
                            numItem++;

                            ItemDeb.codCuenta = item.CuentaGastos;
                            ItemDeb.numItem = String.Format("{0:00000}", numItem);
                            ItemDeb.indDebeHaber = Variables.Debe;

                            if (item.idMoneda == Variables.Soles)
                            {
                                ItemDeb.impSoles = Convert.ToDecimal(GastoDebe);
                                ItemDeb.impDolares = Math.Round(Convert.ToDecimal(GastoDebe / ItemHab.tipCambio), 2);
                            }
                            else
                            {
                                ItemDeb.impSoles = Math.Round(Convert.ToDecimal(GastoDebe * ItemHab.tipCambio), 2);
                                ItemDeb.impDolares = Convert.ToDecimal(GastoDebe);
                            }

                            voucher.ListaVouchers.Add(ItemDeb);

                            #endregion

                            #region Verificando la cuenta de gasto

                            voucher.impDebeSoles = (from x in voucher.ListaVouchers where x.indDebeHaber == "D" select x.impSoles).Sum();
                            voucher.impHaberSoles = (from x in voucher.ListaVouchers where x.indDebeHaber == "H" select x.impSoles).Sum();
                            voucher.impDebeDolares = (from x in voucher.ListaVouchers where x.indDebeHaber == "D" select x.impDolares).Sum();
                            voucher.impHaberDolares = (from x in voucher.ListaVouchers where x.indDebeHaber == "H" select x.impDolares).Sum();

                            if (item.idMoneda == Variables.Soles)
                            {
                                if (voucher.impDebeDolares != voucher.impHaberDolares)
                                {
                                    foreach (VoucherItemE VoucherItem in voucher.ListaVouchers)
                                    {
                                        if (VoucherItem.indDebeHaber == Variables.Debe)
                                        {
                                            Decimal Diferencia = voucher.impHaberDolares - voucher.impDebeDolares;

                                            VoucherItem.impDolares = VoucherItem.impDolares + Diferencia;
                                            VoucherItem.indCambio = Variables.NO;

                                            break;
                                        }
                                    }
                                }
                            }
                            else
                            {
                                if (voucher.impDebeSoles != voucher.impHaberSoles)
                                {
                                    foreach (VoucherItemE VoucherItem in voucher.ListaVouchers)
                                    {
                                        if (VoucherItem.indDebeHaber == Variables.Debe)
                                        {
                                            Decimal Diferencia = voucher.impHaberSoles - voucher.impDebeSoles;

                                            VoucherItem.impSoles = VoucherItem.impSoles + Diferencia;
                                            VoucherItem.indCambio = Variables.NO;

                                            break;
                                        }
                                    }
                                }

                            }


                            #endregion

                            #region Verificando la cuenta de gasto

                            PlanCuentasE oPlanCuenta = new PlanCuentasAD().ObtenerPlanCuentasPorCodigo(item.idEmpresa, item.numVerPlanCuenta, item.CuentaGastos);

                            if (oPlanCuenta.indCuentaGastos == "S")
                            {
                                VoucherItemE ItemDebe = Infraestructura.Extensores.Colecciones.CopiarEntidad(ItemDeb);
                                numItem++;

                                ItemDebe.codCuenta = oPlanCuenta.codCuentaDestino;
                                ItemDebe.numItem = String.Format("{0:00000}", numItem);
                                ItemDebe.indDebeHaber = Variables.Debe;
                                ItemDebe.idMoneda = Variables.Soles;
                                ItemDebe.indAutomatica = "S";
                                voucher.ListaVouchers.Add(ItemDebe);

                                VoucherItemE ItemHaber = Infraestructura.Extensores.Colecciones.CopiarEntidad(ItemDebe);
                                numItem++;

                                ItemHaber.codCuenta = oPlanCuenta.codCuentaTransferencia;
                                ItemHaber.numItem = String.Format("{0:00000}", numItem);
                                ItemHaber.indDebeHaber = Variables.Haber;
                                ItemHaber.idMoneda = Variables.Soles;
                                ItemHaber.indAutomatica = "S";
                                voucher.ListaVouchers.Add(ItemHaber);
                            } 

                            #endregion

                            //Ultimos campos de la cabecera
                            voucher.impDebeSoles = (from x in voucher.ListaVouchers where x.indDebeHaber == "D" select x.impSoles).Sum();
                            voucher.impHaberSoles = (from x in voucher.ListaVouchers where x.indDebeHaber == "H" select x.impSoles).Sum();
                            voucher.impDebeDolares = (from x in voucher.ListaVouchers where x.indDebeHaber == "D" select x.impDolares).Sum();
                            voucher.impHaberDolares = (from x in voucher.ListaVouchers where x.indDebeHaber == "H" select x.impDolares).Sum();
                            voucher.numItems = voucher.ListaVouchers.Count;

                            voucher = new VoucherLN().GrabarVouchers(voucher, EnumOpcionGrabar.Insertar);

                            // Cerrando el recibo por honorario
                            item.indVoucher = true;
                            item.AnioPeriodo = voucher.AnioPeriodo;
                            item.MesPeriodo = voucher.MesPeriodo;
                            item.numVoucher = voucher.numVoucher;
                            item.idComprobante = voucher.idComprobante;
                            item.numFile = voucher.numFile;
                            item.UsuarioModificacion = Usuario;
                            
                            new ReciboHonorariosDetAD().CerrarReciboHonorariosDet(item);

                            //Cta. Cte.
                            CrearCtaCte(item);
                        }

                        resp = 1;
                    }

                    #endregion 

                    oTrans.Complete();
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

        private void CrearCtaCte(ReciboHonorariosDetE RecDetalle)
        {
            try
            {
                Int32 idCtaCte = Variables.Cero;
                Int32 idCtaCteItem = Variables.Cero;

                using (TransactionScope oTrans = new TransactionScope())
                {
                    #region Cabecera

                    CtaCteE oCtaCte = new CtaCteE
                    {
                        idEmpresa = RecDetalle.idEmpresa,
                        idPersona = Convert.ToInt32(RecDetalle.idPersona),
                        idDocumento = RecDetalle.idDocumento,
                        numSerie = RecDetalle.serDocumento,
                        numDocumento = RecDetalle.numDocumento,
                        idMoneda = RecDetalle.idMoneda,
                        MontoOrig = Convert.ToDecimal(RecDetalle.impRecibo - RecDetalle.impCuartaCat),
                        TipoCambio = Convert.ToDecimal(RecDetalle.TipoCambio),
                        FechaDocumento = Convert.ToDateTime(RecDetalle.FechaRecibo),
                        FechaVencimiento = Convert.ToDateTime(RecDetalle.FechaRecibo),
                        FechaCancelacion = Convert.ToDateTime("31-12-2100"),
                        numVerPlanCuentas = RecDetalle.numVerPlanCuenta,
                        codCuenta = RecDetalle.codCuenta,
                        AnnoVencimiento = String.Empty,
                        MesVencimiento = String.Empty,
                        SemanaVencimiento = String.Empty,
                        tipPartidaPresu = String.Empty,
                        codPartidaPresu = String.Empty,
                        desGlosa = RecDetalle.Glosa,
                        FechaOperacion = Convert.ToDateTime(RecDetalle.FechaOperacion),
                        EsDetraCab = false,
                        idCtaCteOrigen = 0,
                        idSistema = 9, //Ctas por pagar
                        UsuarioRegistro = RecDetalle.UsuarioModificacion
                    };

                    oCtaCte = new CtaCteAD().InsertarMaeCtaCte(oCtaCte);
                    ////Obteniendo el id de la ctacte...
                    idCtaCte = oCtaCte.idCtaCte;

                    #endregion

                    #region Detalle

                    CtaCte_DetE oCtaCteDet = new CtaCte_DetE
                    {
                        idEmpresa = RecDetalle.idEmpresa,
                        idCtaCte = idCtaCte,
                        idDocumentoMov = RecDetalle.idDocumento,
                        SerieMov = RecDetalle.serDocumento,
                        NumeroMov = RecDetalle.numDocumento,
                        FechaMovimiento = Convert.ToDateTime(RecDetalle.FechaOperacion),
                        idMoneda = RecDetalle.idMoneda,
                        MontoMov = Convert.ToDecimal(RecDetalle.impRecibo - RecDetalle.impCuartaCat),
                        TipoCambio = Convert.ToDecimal(RecDetalle.TipoCambio),
                        TipAccion = EnumEstadoDocumentos.C.ToString(),
                        numVerPlanCuentas = RecDetalle.numVerPlanCuenta,
                        codCuenta = RecDetalle.codCuenta,
                        desGlosa = RecDetalle.Glosa,
                        EsDetraccion = false,
                        UsuarioRegistro = RecDetalle.UsuarioModificacion
                    };

                    oCtaCteDet = new CtaCte_DetAD().InsertarMaeCtaCteDet(oCtaCteDet);
                    ////Recuperando el item
                    idCtaCteItem = oCtaCteDet.idCtaCteItem;

                    #endregion

                    //Actualizando el idCtaCte al Recibo
                    new ReciboHonorariosDetAD().ActualizarRHonorariosCtaCte(RecDetalle.idReciboHonorariosDet, idCtaCte, idCtaCteItem, RecDetalle.UsuarioModificacion);
                    //Completando la transacción
                    oTrans.Complete();
                }
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

        private void EliminarCtaCte(ReciboHonorariosDetE RecDetalle)
        {
            try
            {
                using (TransactionScope oTrans = new TransactionScope())
                {
                    List<CtaCte_DetE> oListaCtaCteDet = new CtaCte_DetAD().ListarMaeCtaCteDetAbonos(RecDetalle.idEmpresa, Convert.ToInt32(RecDetalle.idCtaCte));

                    //Si hay Abonos no se puede eliminar hasta que se borren esos abonos
                    if (oListaCtaCteDet.Count > 0)
                    {
                        throw new Exception(String.Format("Este documento {0} {1}-{2} en la Cta. Cte. ya tiene Movimientos de Abono, elimine los dichos movimientos antes de eliminar", RecDetalle.idDocumento, RecDetalle.serDocumento, RecDetalle.numDocumento));
                    }
                    else
                    {
                        // Eliminando la cabecera y el detalle
                        new CtaCteAD().EliminarMaeCtaCteConDetalle(Convert.ToInt32(RecDetalle.idCtaCte));
                    }

                    //Actualizando el idCtaCte al Recibo
                    new ReciboHonorariosDetAD().ActualizarRHonorariosCtaCte(RecDetalle.idReciboHonorariosDet, null, null, RecDetalle.UsuarioModificacion);

                    //Completando la transacción
                    oTrans.Complete();
                }
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

        #endregion

    }
}
