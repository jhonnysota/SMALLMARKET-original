using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Transactions;
using System.Linq;

using Entidades.Tesoreria;
using Entidades.CtasPorPagar;
using Entidades.Contabilidad;
using AccesoDatos.Tesoreria;
using AccesoDatos.CtasPorPagar;
using AccesoDatos.Contabilidad;
using Infraestructura;

namespace Negocio.Tesoreria
{
    public class ProgramaPagoLN
    {

        public void GrabarListaPagos(List<ProgramaPagoE> Lista, List<OrdenPagoE> oListaOP = null, String Usuario = "")
        {
            try
            {
                using (TransactionScope oTrans = new TransactionScope())
                {
                    if (Lista != null && Lista.Count > Variables.Cero)
                    {
                        foreach (ProgramaPagoE item in Lista)
                        {
                            new ProgramaPagoAD().InsertarProgramaPago(item);
                        }
                    }

                    if (oListaOP != null)
                    {
                        foreach (OrdenPagoE item in oListaOP)
                        {
                            if (item.VieneDe != "D") //Si es diferente a Detracciones
                            {
                                if (item.Monto == item.MontoPago)
                                {
                                    if (item.idDocumento == "OP" && item.VieneDe == "L")
                                    {
                                        List<OrdenPagoDetE> ordenPagoDet = new OrdenPagoDetAD().ListarOrdenPagoDet(item.idOrdenPago);

                                        if (ordenPagoDet != null && ordenPagoDet.Count > 0)
                                        {
                                            foreach (OrdenPagoDetE item2 in ordenPagoDet)
                                            {
                                                new OrdenPagoDetAD().ActualizarEstadoOpDet(item2.idEmpresa, item2.idLocal, item2.idOrdenPago, item2.idProveedor, item2.idDocumento, item2.serDocumento, item2.numDocumento, true, Usuario);
                                            }
                                        }
                                    }
                                    else
                                    {
                                        new OrdenPagoDetAD().ActualizarEstadoOpDet(item.idEmpresa, item.idLocal, item.idOrdenPago, Convert.ToInt32(item.idPersona), item.idDocumento, item.serDocumento, item.numDocumento, true, Usuario);
                                    }
                                }
                            }
                            else
                            {
                                new OrdenPagoDetAD().ActualizarEstadoOpDet(item.idEmpresa, item.idLocal, item.idOrdenPago, Convert.ToInt32(item.idPersona), item.idDocumento, item.serDocumento, item.numDocumento, true, Usuario);
                            }
                        }

                        var ListaTemp = oListaOP.GroupBy(x => new
                        {
                            x.idOrdenPago
                        }).ToList();

                        foreach (var item in ListaTemp)
                        {
                            List<OrdenPagoDetE> oListaDetalle = new OrdenPagoDetAD().ListarOPDetCancelados(item.Key.idOrdenPago);

                            if (oListaDetalle.Count > 0)
                            {
                                new OrdenPagoAD().CambiarEstadoOP(item.Key.idOrdenPago, "C", Usuario);
                            }
                        }
                    }

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

        public ProgramaPagoE InsertarProgramaPago(ProgramaPagoE programapago)
        {
            try
            {
                return new ProgramaPagoAD().InsertarProgramaPago(programapago);
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

        public ProgramaPagoE ActualizarProgramaPago(ProgramaPagoE programapago)
        {
            try
            {
                return new ProgramaPagoAD().ActualizarProgramaPago(programapago);
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

        public Int32 EliminarProgramaPago(Int32 idEmpresa, Int32 idLocal, Int32 idProgramaPago, String Usuario)
        {
            try
            {
                ProgramaPagoE oPrograma = new ProgramaPagoAD().ObtenerProgramaPago(idEmpresa, idLocal, idProgramaPago);

                if (oPrograma != null)
                {
                    List<OrdenPagoDetE> ListaDocumentos = new OrdenPagoDetAD().ListarOrdenPagoDet(Convert.ToInt32(oPrograma.idOrdenPago));

                    if (ListaDocumentos.Count > 0)
                    {
                        foreach (OrdenPagoDetE item in ListaDocumentos)
                        {
                            new OrdenPagoDetAD().ActualizarEstadoOpDet(item.idEmpresa, item.idLocal, item.idOrdenPago, item.idProveedor, item.idDocumento, item.serDocumento, item.numDocumento, false, Usuario);
                        }
                    }
                    
                    new OrdenPagoAD().CambiarEstadoOP(Convert.ToInt32(oPrograma.idOrdenPago), "P", Usuario);
                }

                return new ProgramaPagoAD().EliminarProgramaPago(idEmpresa, idLocal, idProgramaPago);
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

        public Int32 EliminarProgramaPagoMasivo(List<ProgramaPagoE> oListaProgramaPago, String Usuario)
        {
            try
            {
                Int32 Resp = 0;
                TransactionOptions Opciones = new TransactionOptions();
                Opciones.Timeout = TimeSpan.FromMinutes(300);

                using (TransactionScope oTrans = new TransactionScope(TransactionScopeOption.Required, Opciones))
                {
                    foreach (ProgramaPagoE item in oListaProgramaPago)
                    {
                        Resp += EliminarProgramaPago(item.idEmpresa, item.idLocal, item.idProgramaPago, Usuario);
                        //ProgramaPagoE oPrograma = new ProgramaPagoAD().ObtenerProgramaPago(item.idEmpresa, item.idLocal, item.idProgramaPago);

                        //if (oPrograma != null)
                        //{
                        //    new OrdenPagoDetAD().ActualizarEstadoOpDet(oPrograma.idEmpresa, oPrograma.idLocal, Convert.ToInt32(oPrograma.idOrdenPago), oPrograma.idPersona, oPrograma.idDocumento, oPrograma.serDocumento, oPrograma.numDocumento, false, Usuario);
                        //    new OrdenPagoAD().CambiarEstadoOP(Convert.ToInt32(oPrograma.idOrdenPago), "P", Usuario);
                        //}

                        //Resp += new ProgramaPagoAD().EliminarProgramaPago(item.idEmpresa, item.idLocal, item.idProgramaPago);
                    }

                    oTrans.Complete();
                }

                return Resp;
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

        public List<ProgramaPagoE> ListarProgramaPagos(Int32 idEmpresa, Int32 idLocal, DateTime fecIni, DateTime fecFin, String Estado, String codFormaPago, Int32 idPersonaBanco, Int32 idPersona)
        {
            try
            {
                List<ProgramaPagoE> oListaFinal = new List<ProgramaPagoE>();
                List<ProgramaPagoE> oListaPagos = new ProgramaPagoAD().ListarProgramaPagos(idEmpresa, idLocal, fecIni, fecFin, Estado, codFormaPago, idPersonaBanco, idPersona);

                foreach (ProgramaPagoE item in oListaPagos)
                {
                    if (item.idMoneda == Variables.Soles)
                    {
                        if (item.indDebeHaber == Variables.Haber)
                        {
                            item.CargoSoles = Convert.ToDecimal(item.Monto);
                            item.AbonoSoles = Variables.ValorCeroDecimal;
                        }
                        else
                        {
                            item.CargoSoles = Variables.ValorCeroDecimal;
                            item.AbonoSoles = Convert.ToDecimal(item.Monto);
                        }
                    }
                    else
                    {
                        if (item.indDebeHaber == Variables.Haber)
                        {
                            item.CargoDolares = Convert.ToDecimal(item.Monto);
                            item.AbonoDolares = Variables.ValorCeroDecimal;
                        }
                        else
                        {
                            item.CargoDolares = Variables.ValorCeroDecimal;
                            item.AbonoDolares = Convert.ToDecimal(item.Monto);
                        }
                    }

                    oListaFinal.Add(item);
                }

                return oListaFinal;
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

        public ProgramaPagoE ObtenerProgramaPago(Int32 idEmpresa, Int32 idLocal, Int32 idProgramaPago)
        {
            try
            {
                return new ProgramaPagoAD().ObtenerProgramaPago(idEmpresa, idLocal, idProgramaPago);
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

        public Int32 MaxGrupoProgramaPagos(Int32 idEmpresa, Int32 idLocal, Int32 idPersona, DateTime Fecha)
        {
            try
            {
                return new ProgramaPagoAD().MaxGrupoProgramaPagos(idEmpresa, idLocal, idPersona, Fecha);
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

        public List<ProgramaPagoE> ListarPagosParaAprobacion(Int32 idEmpresa, Int32 idLocal, DateTime fecIni, DateTime fecFin, String Aprobado)
        {
            try
            {
                List<ProgramaPagoE> oListaFinal = new List<ProgramaPagoE>();
                List<ProgramaPagoE> oListaPagos = new ProgramaPagoAD().ListarPagosParaAprobacion(idEmpresa, idLocal, fecIni, fecFin, Aprobado);

                foreach (ProgramaPagoE item in oListaPagos)
                {
                    if (item.idMoneda == Variables.Soles)
                    {
                        if (item.indDebeHaber == Variables.Haber)
                        {
                            item.CargoSoles = Convert.ToDecimal(item.Monto);
                            item.AbonoSoles = Variables.ValorCeroDecimal;
                        }
                        else
                        {
                            item.CargoSoles = Variables.ValorCeroDecimal;
                            item.AbonoSoles = Convert.ToDecimal(item.Monto);
                        }
                    }
                    else
                    {
                        if (item.indDebeHaber == Variables.Haber)
                        {
                            item.CargoDolares = Convert.ToDecimal(item.Monto);
                            item.AbonoDolares = Variables.ValorCeroDecimal;
                        }
                        else
                        {
                            item.CargoDolares = Variables.ValorCeroDecimal;
                            item.AbonoDolares = Convert.ToDecimal(item.Monto);
                        }
                    }

                    oListaFinal.Add(item);
                }

                return oListaFinal;
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

        public void ActualizarProgramaPagoAprobacion(List<ProgramaPagoE> oListaAprobacion)
        {
            try
            {
                if (oListaAprobacion != null && oListaAprobacion.Count > Variables.Cero)
                {
                    foreach (ProgramaPagoE item in oListaAprobacion)
                    {
                        new ProgramaPagoAD().ActualizarProgramaPagoAprobacion(item);
                    }
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

        public void GenerarCheque(Int32 idEmpresa, Int32 idLocal, Int32 idProgramaPago, DateTime Fecha, Int32 idPersona, String idDocumento, String Usuario, String Estado, String Grupo, String UsuarioActual)
        {
            try
            {
                using (TransactionScope oTran = new TransactionScope())
                {
                    new ProgramaPagoAD().GenerarCheque(idEmpresa, idLocal, Fecha, idPersona, Usuario, Estado, Grupo);

                    if (idDocumento != "OP")
                    {
                        List<ProgramaPagoE> oListaPagos = new ProgramaPagoAD().ListarProgramaPagoPorGrupo(idEmpresa, idLocal, Fecha, idPersona, Grupo, "");//po revisar

                        if (oListaPagos.Count > 0)
                        {
                            List<CtaCte_DetE> oListaCtaCte = new List<CtaCte_DetE>();
                            EgresoE oEgreso = new EgresoAD().ObtenerEgreso(idEmpresa, idLocal, Convert.ToInt32(oListaPagos[0].idNumEgreso));
                            oEgreso.ListaEgresos = new EgresoItemAD().ListarEgresoItemPorIdNumEgreso(idEmpresa, idLocal, Convert.ToInt32(oListaPagos[0].idNumEgreso));

                            foreach (ProgramaPagoE item in oListaPagos)
                            {
                                if (oEgreso != null && oEgreso.ListaEgresos.Count > Variables.Cero)
                                {
                                    CtaCte_DetE oCtaCteItem = null;
                                    CtaCteE oCtaCTeCabecera = new CtaCteAD().ObtenerMaeCtaCtePorDocumento(item.idEmpresa, item.idDocumento, item.serDocumento, item.numDocumento);

                                    if (oCtaCTeCabecera != null)
                                    {
                                        foreach (EgresoItemE itemEgreso in oEgreso.ListaEgresos)
                                        {
                                            oCtaCteItem = new CtaCte_DetE();

                                            if (itemEgreso.idDocumento != "CH")
                                            {
                                                if (item.idDocumento == itemEgreso.idDocumento && item.serDocumento == itemEgreso.serDocumento && item.numDocumento == itemEgreso.numDocumento)
                                                {
                                                    EgresoItemE ItemTmp = null;

                                                    ItemTmp = oEgreso.ListaEgresos.Find
                                                    (
                                                        delegate (EgresoItemE eItem) { return eItem.idDocumento == "CH"; }
                                                    );

                                                    if (ItemTmp == null)
                                                    {
                                                        ItemTmp = oEgreso.ListaEgresos.Find
                                                        (
                                                            delegate (EgresoItemE eItem) { return eItem.idDocumento == "TR"; }
                                                        );
                                                    }

                                                    oCtaCteItem.idEmpresa = idEmpresa;
                                                    oCtaCteItem.idCtaCte = oCtaCTeCabecera.idCtaCte;
                                                    oCtaCteItem.idDocumentoMov = ItemTmp.idDocumento;
                                                    oCtaCteItem.SerieMov = ItemTmp.serDocumento;
                                                    oCtaCteItem.NumeroMov = ItemTmp.numDocumento;
                                                    oCtaCteItem.FechaMovimiento = Convert.ToDateTime(oEgreso.fechaProceso);
                                                    oCtaCteItem.idMoneda = itemEgreso.idMoneda;
                                                    oCtaCteItem.MontoMov = Convert.ToDecimal(itemEgreso.impPagoBase);
                                                    oCtaCteItem.TipoCambio = Convert.ToDecimal(itemEgreso.tipCambio);
                                                    oCtaCteItem.TipAccion = "A";
                                                    oCtaCteItem.numVerPlanCuentas = itemEgreso.numVerPlanCuentas;
                                                    oCtaCteItem.codCuenta = itemEgreso.codCuenta;
                                                    oCtaCteItem.UsuarioRegistro = UsuarioActual;

                                                    oListaCtaCte.Add(oCtaCteItem);
                                                    break;
                                                }
                                            }
                                            else
                                            {
                                                //oCtaCteItem.idDocumentoOrig = itemEgreso.idDocumento;
                                                //oCtaCteItem.NumSerieOrig = itemEgreso.serDocumento;
                                                //oCtaCteItem.NumDocOrig = itemEgreso.numDocumento;
                                            }
                                        }
                                    }
                                    else
                                    {
                                        throw new Exception(String.Format("No existe CtaCte con el documento {0} {1}-{2}", item.idDocumento, item.serDocumento, item.numDocumento));
                                    }
                                }
                            }

                            foreach (CtaCte_DetE itemCtaCte in oListaCtaCte)
                            {
                                //item.idDocumentoOrig = oCtaCteItem.idDocumentoOrig;
                                //item.NumSerieOrig = oCtaCteItem.NumSerieOrig;
                                //item.NumDocOrig = oCtaCteItem.NumDocOrig;

                                new CtaCte_DetAD().InsertarMaeCtaCteDet(itemCtaCte);
                            }
                        }
                    }
                    else
                    {
                        ProgramaPagoE oPago = new ProgramaPagoAD().ObtenerProgramaPago(idEmpresa, idLocal, idProgramaPago);

                        if (oPago != null)
                        {
                            String indEstado = "A";
                            LiquidacionSaldosE oSaldoLiqui = new LiquidacionSaldosAD().ObtenerLiquidacionSaldos(idEmpresa, idLocal, idPersona);

                            if (oSaldoLiqui == null)
                            {
                                oSaldoLiqui = new LiquidacionSaldosAD().ObtenerLiquidacionSaldosC(idEmpresa, idLocal, idPersona);
                                indEstado = "C";
                            }

                            LiquidacionSaldosE LiquiSaldo = null;

                            if (oSaldoLiqui != null)
                            {
                                LiquiSaldo = new LiquidacionSaldosE()
                                {
                                    idEmpresa = oPago.idEmpresa,
                                    idLocal = oPago.idLocal,
                                    idPersona = oPago.idPersona,
                                    codOrdenPago = oPago.numDocumento,
                                    idLiquidacion = null,
                                    SaldoAnterior = indEstado == "A" ? 0 : oSaldoLiqui.Abono - oSaldoLiqui.Liquidacion,
                                    Abono = Convert.ToDecimal(oPago.Monto),
                                    Liquidacion = 0,
                                };
                            }
                            else
                            {
                                LiquiSaldo = new LiquidacionSaldosE()
                                {
                                    idEmpresa = oPago.idEmpresa,
                                    idLocal = oPago.idLocal,
                                    idPersona = oPago.idPersona,
                                    codOrdenPago = oPago.numDocumento,
                                    idLiquidacion = null,
                                    SaldoAnterior = 0,
                                    Abono = Convert.ToDecimal(oPago.Monto),
                                    Liquidacion = 0,
                                };
                            }

                            new LiquidacionSaldosAD().InsertarLiquidacionSaldos(LiquiSaldo);
                        }
                    }

                    oTran.Complete();
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

        public String GenerarVoucherTesTransferencia(List<ProgramaPagoE> oListaPP, String Usuario, String Estado, String Grupo)
        {
            try
            {
                String resp = String.Empty;
                ProgramaPagoE programa = null;

                using (TransactionScope oTran = new TransactionScope())
                {
                    foreach (ProgramaPagoE item in oListaPP)
                    {
                        if (!String.IsNullOrWhiteSpace(item.numVoucher))
                        {
                            VoucherE oVoucher = new VoucherAD().ObtenerVoucherPorCodigo(item.idEmpresa, item.idLocal, item.AnioPeriodo, item.MesPeriodo, item.numVoucher, item.idComprobante, item.numFile);

                            if (oVoucher != null)
                            {
                                throw new Exception(String.Format("El número de voucher {0} {1} {2} ya existe en contabilidad.\n\rDebe limpiar el N° de voucher antes de generar el pago.", item.idComprobante, item.numFile, item.idComprobante, item.numFile));
                            }
                        }

                        new ProgramaPagoAD().ActualizarGrupoPP(item.idProgramaPago, Grupo, item.idDocumentoBanco, item.SerieBanco, item.NumeroBanco, item.Glosa);
                    }

                    // Verificar si es de un proveedor si es varios colocamos 0
                    Int32 idProveedor = oListaPP[0].idPersona;

                    foreach (ProgramaPagoE item in oListaPP)
                    {
                       if (idProveedor != item.idPersona)
                        {
                            idProveedor = 0;
                        }
                    }

                    programa = new ProgramaPagoAD().GenerarVoucherTesTransferencia(oListaPP[0].idEmpresa, oListaPP[0].idLocal, oListaPP[0].Fecha, idProveedor, Usuario, Estado, Grupo, oListaPP[0].codTipoPago);

                    if (programa != null)
                    {
                        resp = String.Format("Se generó el Voucher {0} {1}-{2}", programa.idComprobante, programa.numFile, programa.numVoucher);
                    }
                    ////if (idDocumento != "OP")
                    ////{
                    //List<ProgramaPagoE> oListaPagos = new ProgramaPagoAD().ListarProgramaPagoPorGrupo(oListaPP[0].idEmpresa, oListaPP[0].idLocal, Fecha, oListaPP[0].idPersona, Grupo, "C");//po revisar

                    //if (oListaPagos.Count > 0)
                    //{
                    //    List<CtaCte_DetE> oListaCtaCte = new List<CtaCte_DetE>();
                    //    EgresoE oEgreso = new EgresoAD().ObtenerEgreso(oListaPP[0].idEmpresa, oListaPP[0].idLocal, Convert.ToInt32(oListaPagos[0].idNumEgreso));

                    //    if (oEgreso != null)
                    //    {
                    //        oEgreso.ListaEgresos = new EgresoItemAD().ListarEgresoItemPorIdNumEgreso(oListaPP[0].idEmpresa, oListaPP[0].idLocal, Convert.ToInt32(oListaPagos[0].idNumEgreso));

                    //        foreach (ProgramaPagoE item in oListaPagos)
                    //        {
                    //            if (oEgreso.ListaEgresos.Count > Variables.Cero)
                    //            {
                    //                CtaCte_DetE oCtaCteItem = null;
                    //                CtaCteE oCtaCTeCabecera = new CtaCteAD().ObtenerMaeCtaCtePorDocumento(item.idEmpresa, item.idDocumento, item.serDocumento, item.numDocumento);

                    //                if (oCtaCTeCabecera != null)
                    //                {
                    //                    oCtaCteItem.idEmpresa = item.idEmpresa;
                    //                    oCtaCteItem.idCtaCte = oCtaCTeCabecera.idCtaCte;

                    //                    //foreach (EgresoItemE itemEgreso in oEgreso.ListaEgresos)
                    //                    //{
                    //                    //    oCtaCteItem = new CtaCte_DetE();

                    //                    //    if (itemEgreso.idDocumento != "CH")
                    //                    //    {
                    //                    //        if (item.idDocumento == itemEgreso.idDocumento && item.serDocumento == itemEgreso.serDocumento && item.numDocumento == itemEgreso.numDocumento)
                    //                    //        {
                    //                    //            EgresoItemE ItemTmp = null;

                    //                    //            ItemTmp = oEgreso.ListaEgresos.Find
                    //                    //            (
                    //                    //                delegate (EgresoItemE eItem) { return eItem.idDocumento == "CH"; }
                    //                    //            );

                    //                    //            if (ItemTmp == null)
                    //                    //            {
                    //                    //                ItemTmp = oEgreso.ListaEgresos.Find
                    //                    //                (
                    //                    //                    delegate (EgresoItemE eItem) { return eItem.idDocumento == "TR"; }
                    //                    //                );
                    //                    //            }

                    //                    //            oCtaCteItem.idEmpresa = idEmpresa;
                    //                    //            oCtaCteItem.idCtaCte = oCtaCTeCabecera.idCtaCte;
                    //                    //            oCtaCteItem.idDocumentoMov = ItemTmp.idDocumento;
                    //                    //            oCtaCteItem.SerieMov = ItemTmp.serDocumento;
                    //                    //            oCtaCteItem.NumeroMov = ItemTmp.numDocumento;
                    //                    //            oCtaCteItem.FechaMovimiento = Convert.ToDateTime(oEgreso.fechaProceso);
                    //                    //            oCtaCteItem.idMoneda = itemEgreso.idMoneda;
                    //                    //            oCtaCteItem.MontoMov = Convert.ToDecimal(itemEgreso.impPagoBase);
                    //                    //            oCtaCteItem.TipoCambio = Convert.ToDecimal(itemEgreso.tipCambio);
                    //                    //            oCtaCteItem.TipAccion = "A";
                    //                    //            oCtaCteItem.numVerPlanCuentas = itemEgreso.numVerPlanCuentas;
                    //                    //            oCtaCteItem.codCuenta = itemEgreso.codCuenta;
                    //                    //            oCtaCteItem.UsuarioRegistro = UsuarioActual;

                    //                    //            oListaCtaCte.Add(oCtaCteItem);
                    //                    //            break;
                    //                    //        }
                    //                    //    }
                    //                    //    else
                    //                    //    {
                    //                    //        //oCtaCteItem.idDocumentoOrig = itemEgreso.idDocumento;
                    //                    //        //oCtaCteItem.NumSerieOrig = itemEgreso.serDocumento;
                    //                    //        //oCtaCteItem.NumDocOrig = itemEgreso.numDocumento;
                    //                    //    }
                    //                    //}
                    //                }
                    //                else
                    //                {
                    //                    throw new Exception(String.Format("No existe CtaCte con el documento {0} {1}-{2}", item.idDocumento, item.serDocumento, item.numDocumento));
                    //                }
                    //            }
                    //        } 
                    //    }

                    //    //foreach (CtaCte_DetE itemCtaCte in oListaCtaCte)
                    //    //{
                    //    //    //item.idDocumentoOrig = oCtaCteItem.idDocumentoOrig;
                    //    //    //item.NumSerieOrig = oCtaCteItem.NumSerieOrig;
                    //    //    //item.NumDocOrig = oCtaCteItem.NumDocOrig;

                    //    //    new CtaCte_DetAD().InsertarMaeCtaCteDet(itemCtaCte);
                    //    //}
                    //}
                    //}

                    oTran.Complete();
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

        public String CancelarPagos(List<ProgramaPagoE> oListaPP, String UsuarioModificacion)
        {
            try
            {
                String MensajeResp = String.Empty;

                using (TransactionScope oTran = new TransactionScope())
                {
                    var ListaTemp = oListaPP.GroupBy(x => new { x.idEmpresa, x.idLocal, x.idPersona, x.Grupo, x.idOrdenPago, x.idNumEgreso, x.AnioPeriodo, x.MesPeriodo, x.numVoucher,
                        x.idComprobante, x.numFile, x.Fecha }).ToList();

                    foreach (var item in ListaTemp)
                    {
                        //Actualizando el estado - P=Pendiente C=Cancelado
                        new ProgramaPagoAD().ActualizarPPagoEstadoPorGrupo(item.Key.idEmpresa, item.Key.idLocal, item.Key.idPersona, item.Key.Grupo, Convert.ToInt32(item.Key.idOrdenPago), item.Key.Fecha, 0, "P", UsuarioModificacion);
                        //Eliminando el voucher
                        new VoucherAD().EliminarVoucher(item.Key.idEmpresa, item.Key.idLocal, item.Key.AnioPeriodo, item.Key.MesPeriodo, item.Key.numVoucher, item.Key.idComprobante, item.Key.numFile);

                        //Eliminando el Egreso y de la Cta. Cte.
                        if (item.Key.idNumEgreso > 0)
                        {
                            if (item.First().VieneDeOp != "A")
                            {
                                //Obteniendo la lista de de items de la Tabla Egresos
                                List<EgresoItemE> oListaEgresosItem = new EgresoItemAD().ListarEgresoItemPorIdNumEgreso(item.Key.idEmpresa, item.Key.idLocal, Convert.ToInt32(item.Key.idNumEgreso));

                                if (oListaEgresosItem != null && oListaEgresosItem.Count > 0)
                                {
                                    //Eliminar de la Cta.Cte. por documento y actualizar la fecha de cancelación de la cabecera...
                                    foreach (EgresoItemE itemEgreso in oListaEgresosItem)
                                    {
                                        //Eliminación
                                        new CtaCte_DetAD().EliminarCtaCteDetPorDocumento(itemEgreso.idEmpresa, itemEgreso.idDocumento, itemEgreso.serDocumento, itemEgreso.numDocumento);
                                        //Actualizar
                                        new CtaCteAD().ActualizarFecCancelacionCtaCte(itemEgreso.idEmpresa, itemEgreso.idCtaCte, Convert.ToDateTime("31-12-2100"), UsuarioModificacion);
                                    }
                                } 
                            }

                            //Eliminando el egreso...
                            new EgresoAD().EliminarEgreso(item.Key.idEmpresa, item.Key.idLocal, Convert.ToInt32(item.Key.idNumEgreso));
                        }
                    }

                    oTran.Complete();
                    //Si todo esta bien respuesta final...
                    MensajeResp = "ok";
                }

                return MensajeResp;
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

        public Int32 LimpiarVoucherPP(Int32 idEmpresa, Int32 idLocal, Int32 idPersona, String Grupo, Int32 idNumEgreso, String UsuarioModificacion)
        {
            try
            {
                return new ProgramaPagoAD().LimpiarVoucherPP(idEmpresa, idLocal, idPersona, Grupo, idNumEgreso, UsuarioModificacion);
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
    
    }
}
