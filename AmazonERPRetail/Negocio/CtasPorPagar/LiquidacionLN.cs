using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Transactions;
using System.Linq;

using Entidades.CtasPorPagar;
using Entidades.Tesoreria;
using Entidades.Generales;
using Entidades.Contabilidad;
using AccesoDatos.CtasPorPagar;
using AccesoDatos.Tesoreria;
using AccesoDatos.Contabilidad;
using AccesoDatos.Generales;
using Negocio.Tesoreria;
using Infraestructura.Enumerados;

namespace Negocio.CtasPorPagar
{
    public class LiquidacionLN 
    {

        public LiquidacionE GrabarLiquidacion(LiquidacionE oLiquidacion, EnumOpcionGrabar OpcionGrabar)
        {
            try
            {
                using (TransactionScope oTrans = new TransactionScope())
                {
                    String EsProvMov = String.Empty;

                    switch (OpcionGrabar)
                    {
                        case EnumOpcionGrabar.Actualizar:

                            //Actualizando 
                            new LiquidacionAD().ActualizarLiquidacion(oLiquidacion);

                            //Revisando el listado de registros eliminados
                            if (oLiquidacion.ListaEliminados != null)
                            {
                                foreach (LiquidacionDetE oitem in oLiquidacion.ListaEliminados)
                                {
                                    //Eliminando el detalle de la liquidación
                                    new LiquidacionDetAD().EliminarLiquidacionDet(oitem.idEmpresa, oitem.idLocal, oitem.idLiquidacion, oitem.idItem);

                                    //Eliminando la Provision
                                    if (oitem.tipoDocumento == 1) //1 = Provision 2 = Movilidad 3 = Otros
                                    {
                                        new ProvisionesLN().EliminarProvisiones(oitem.idEmpresa, oitem.idLocal, oitem.idProvision.Value);
                                    }
                                }
                            }

                            //Actualizando el Detalle 
                            if (oLiquidacion.ListaLiquidacionDet != null)
                            {
                                foreach (LiquidacionDetE oitem in oLiquidacion.ListaLiquidacionDet)
                                {
                                    oitem.idLiquidacion = oLiquidacion.idLiquidacion;

                                    switch (oitem.Opcion)
                                    {
                                        case (Int32)EnumOpcionGrabar.Insertar:

                                            //Provisiones
                                            if (oitem.tipoDocumento == 1 && oitem.oProvision != null) //1 = Provision 2 = Movilidad 3 = Otros
                                            {
                                                EsProvMov = "P";
                                                oitem.oProvision = new ProvisionesLN().GrabarProvision(oitem.oProvision, EnumOpcionGrabar.Insertar);
                                            }

                                            if (EsProvMov == "P")
                                            {
                                                oitem.idProvision = oitem.oProvision.idProvision;
                                            }

                                            new LiquidacionDetAD().InsertarLiquidacionDet(oitem);

                                            break;
                                        case (Int32)EnumOpcionGrabar.Actualizar:

                                            if (oitem.idMovilidad == 0)
                                            {
                                                oitem.idMovilidad = null;
                                            }

                                            if (oitem.idProvision == 0)
                                            {
                                                oitem.idProvision = null;
                                            }

                                            new LiquidacionDetAD().ActualizarLiquidacionDet(oitem);

                                            //Provisiones
                                            if (oitem.tipoDocumento == 1 && oitem.oProvision != null && oitem.ActualizarProvMov) //1 = Provision 2 = Movilidad 3 = Otros
                                            {
                                                new ProvisionesLN().GrabarProvision(oitem.oProvision, EnumOpcionGrabar.Actualizar);
                                            }

                                            break;
                                        default:
                                            break;
                                    }
                                }

                                Decimal TotalLiquidar = Convert.ToDecimal(oLiquidacion.ListaLiquidacionDet.Sum(x => x.Monto));
                                LiquidacionSaldosE oSaldoLiqui = new LiquidacionSaldosAD().ObtenerLiquidacionSaldos(oLiquidacion.idEmpresa, oLiquidacion.idLocal, oLiquidacion.idPersona);

                                if (oSaldoLiqui != null)
                                {
                                    oSaldoLiqui.Liquidacion = TotalLiquidar;
                                    new LiquidacionSaldosAD().ActualizarLiquidacionSaldos(oSaldoLiqui);
                                }
                            }

                            break;
                        case EnumOpcionGrabar.Insertar:

                            //Insertando 
                            oLiquidacion = new LiquidacionAD().InsertarLiquidacion(oLiquidacion);

                            //Lista 
                            if (oLiquidacion.ListaLiquidacionDet != null && oLiquidacion.ListaLiquidacionDet.Count > 0)
                            {
                                foreach (LiquidacionDetE oitem in oLiquidacion.ListaLiquidacionDet)
                                {
                                    //Provisiones
                                    if (oitem.tipoDocumento == 1 && oitem.oProvision != null) //1 = Provision 2 = Movilidad 3 = Otros
                                    {
                                        oitem.oProvision = new ProvisionesLN().GrabarProvision(oitem.oProvision, EnumOpcionGrabar.Insertar);
                                        EsProvMov = "P";
                                    }

                                    oitem.idLiquidacion = oLiquidacion.idLiquidacion;

                                    if (EsProvMov == "P")
                                    {
                                        oitem.idProvision = oitem.oProvision.idProvision;
                                    }

                                    new LiquidacionDetAD().InsertarLiquidacionDet(oitem);
                                }

                                Decimal TotalLiquidar = Convert.ToDecimal(oLiquidacion.ListaLiquidacionDet.Sum(x => x.Monto));
                                LiquidacionSaldosE oSaldoLiqui = new LiquidacionSaldosAD().ObtenerLiquidacionSaldos(oLiquidacion.idEmpresa, oLiquidacion.idLocal, oLiquidacion.idPersona);

                                if (oSaldoLiqui != null)
                                {
                                    oSaldoLiqui.idLiquidacion = oLiquidacion.idLiquidacion;
                                    oSaldoLiqui.Liquidacion = TotalLiquidar;
                                    new LiquidacionSaldosAD().ActualizarLiquidacionSaldos(oSaldoLiqui);
                                }
                            }

                            break;
                        default:
                            break;
                    }

                    oTrans.Complete();
                }

                return oLiquidacion;
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

        public LiquidacionE InsertarLiquidacion(LiquidacionE liquidacion)
        {
            try
            {
                return new LiquidacionAD().InsertarLiquidacion(liquidacion);
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

        public LiquidacionE ActualizarLiquidacion(LiquidacionE liquidacion)
        {
            try
            {
                return new LiquidacionAD().ActualizarLiquidacion(liquidacion);
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

        public int EliminarLiquidacion(Int32 idEmpresa, Int32 idLocal, Int32 idLiquidacion)
        {
            try
            {
                Int32 resp = 0;

                using (TransactionScope oTrans = new TransactionScope())
                {
                    //Obteniendo las provisiones de la liquidación antes de eliminarlas
                    List<LiquidacionDetE> oListaProvisiones = new LiquidacionDetAD().LiquidacionDetPorTipoDoc(idLiquidacion, 1); //1=Provisiones
                    //Eliminando la liquidación
                    resp = new LiquidacionAD().EliminarLiquidacion(idEmpresa, idLocal, idLiquidacion);

                    if (oListaProvisiones != null)
                    {
                        foreach (LiquidacionDetE item in oListaProvisiones)
                        {
                            if (item.idProvision != null && item.idProvision != 0)
                            {
                                ProvisionesE oProvision = new ProvisionesAD().RecuperarProvisionesPorId(idEmpresa, idLocal, item.idProvision.Value);

                                if (oProvision != null)
                                {
                                    if (oProvision.EstadoProvision == "PR")
                                    {
                                        throw new Exception(String.Format("No se puede eliminar la liquidación porque el documento {0} {1}-{2} se encuentra provisionado.", item.idDocumento, item.numSerie, item.numDocumento));
                                    }

                                    new ProvisionesLN().EliminarProvisiones(idEmpresa, idLocal, item.idProvision.Value);
                                }
                            }
                        }
                    }

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

        public List<LiquidacionE> ListarLiquidacion(Int32 idEmpresa, Int32 idLocal, Int32 idPersona, DateTime fecIni, DateTime fecFin, Boolean Estado1, Boolean Estado2, String TipoFondo, Boolean BuscarDcmto, String idDocumento, String NumSerie, String NumDocumento)
        {
            try
            {
                return new LiquidacionAD().ListarLiquidacion(idEmpresa, idLocal, idPersona, fecIni, fecFin, Estado1, Estado2, TipoFondo, BuscarDcmto, idDocumento, NumSerie, NumDocumento);
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

        public LiquidacionE ObtenerLiquidacion(Int32 idEmpresa, Int32 idLocal, Int32 idLiquidacion)
        {
            try
            {
                return new LiquidacionAD().ObtenerLiquidacion(idEmpresa, idLocal, idLiquidacion);
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

        public LiquidacionE ObtenerLiquidacionCompleta(Int32 idEmpresa, Int32 idLocal, Int32 idLiquidacion)
        {
            try
            {
                LiquidacionE OrdenPago = new LiquidacionAD().ObtenerLiquidacion(idEmpresa, idLocal, idLiquidacion);

                if (OrdenPago != null)
                {
                    OrdenPago.ListaLiquidacionDet = new LiquidacionDetAD().ListarLiquidacionDet(idEmpresa, idLocal, idLiquidacion);
                }

                return OrdenPago;
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

        public void CerrarLiquidacion(LiquidacionE oLiquidacion, String Usuario, String TipoFondo, String Tipo)
        {
            try
            {
                using (TransactionScope oTrans = new TransactionScope())
                {
                    Int32 Resp = new LiquidacionAD().GenerarVoucherCxpLiquidacion(oLiquidacion.idEmpresa, oLiquidacion.idLocal, oLiquidacion.idLiquidacion, oLiquidacion.Fecha, Usuario);

                    if (Resp > 0)
                    {
                        //Lista de provisiones...
                        List<ProvisionesE> ListaProvisiones = null;
                        ProvisionesE ItemProv = null;
                        //Actualizando el estado en la liquidación.
                        new LiquidacionAD().ActualizarEstadoLiquidacion(oLiquidacion.idLiquidacion, true, Usuario);

                        //Actualizando el detalle de la liquidacion (Estado de movilidad, provisiones, etc)
                        oLiquidacion.ListaLiquidacionDet = new LiquidacionDetAD().ListarLiquidacionDet(oLiquidacion.idEmpresa, oLiquidacion.idLocal, oLiquidacion.idLiquidacion);

                        if (oLiquidacion.ListaLiquidacionDet != null)
                        {
                            ListaProvisiones = new List<ProvisionesE>();

                            foreach (LiquidacionDetE item in oLiquidacion.ListaLiquidacionDet)
                            {
                                if (item.idMovilidad != null && item.idMovilidad != 0)
                                {
                                    new MovilidadAD().ActualizarEstadoMovi(Convert.ToInt32(item.idMovilidad), true, Usuario);
                                }

                                //Si se trata de una provisión agregar a la lista...
                                if (item.tipoDocumento == 1)
                                {
                                    ItemProv = new ProvisionesAD().RecuperarProvisionesPorId(item.idEmpresa, item.idLocal, Convert.ToInt32(item.idProvision));

                                    if (ItemProv != null)
                                    {
                                        if (!String.IsNullOrWhiteSpace(ItemProv.numVoucher))
                                        {
                                            VoucherE oVoucherExiste = new VoucherAD().ObtenerVoucherPorCodigo(item.idEmpresa, item.idLocal, ItemProv.AnioPeriodo, ItemProv.MesPeriodo, ItemProv.numVoucher, ItemProv.idComprobante, ItemProv.numFile);

                                            if (oVoucherExiste != null)
                                            {
                                                throw new Exception(String.Format("En la provisión {0} el Nro. de Voucher {1} {2}-{3} ya ha sido asignado a {4}, limpie el número de voucher.", ItemProv.idProvision.ToString(), oVoucherExiste.idComprobante, oVoucherExiste.numFile, oVoucherExiste.numVoucher, oVoucherExiste.numDocumentoPresu));
                                            }
                                        }

                                        ListaProvisiones.Add(ItemProv);
                                    }
                                }
                            }
                        }

                        #region Insertando la nueva Orden de Pago

                        OrdenPagoE oOrdenPago = new OrdenPagoE();
                        TipoPagoE oTipoPago = null;
                        Int32? idBanco = 0;
                        Int32? tipCuenta = 0;
                        String idMonedaBanco = String.Empty;
                        String numCtaBancaria = String.Empty;

                        if (TipoFondo == "102")
                        {
                            #region Fondo Fijo

                            oTipoPago = new TipoPagoAD().ObtenerTipoPagoPorTipo("PSR");
                            oTipoPago.DetalleTipoPago = new TipoPagoDetAD().ListarTipoPagoDet(oLiquidacion.idEmpresa, oTipoPago.codTipoPago);

                            TipoPagoDetE oTipoPagoDet = oTipoPago.DetalleTipoPago.Find
                            (
                                delegate (TipoPagoDetE t) { return t.desConcepto.ToUpper().Contains("FONDO FIJO"); }
                            );

                            if (oTipoPagoDet == null)
                            {
                                throw new Exception("No se ha configurado ningún concepto para el Reembolso de Fondo Fijo");
                            }

                            //Obteniendo los datos del Fondo Fijo y Rendiciones
                            List<FondoFijoE> ListaFFRendiciones = new FondoFijoAD().ListarFondoFijoPorResponsable(oLiquidacion.idEmpresa, oLiquidacion.idLocal, oLiquidacion.idPersona);

                            FondoFijoE oDatosFFRendiciones = ListaFFRendiciones.Find
                            (
                                delegate (FondoFijoE f) { return f.TipoFondo == "102"; }
                            );

                            //Validando los datos bancarios
                            if (oDatosFFRendiciones != null)
                            {
                                idBanco = oDatosFFRendiciones.idPersonaBanco;
                                tipCuenta = oDatosFFRendiciones.tipCuenta;
                                idMonedaBanco = oDatosFFRendiciones.idMonedaCuenta;
                                numCtaBancaria = String.IsNullOrWhiteSpace(oDatosFFRendiciones.numCuenta) ? oDatosFFRendiciones.numInterbancaria : oDatosFFRendiciones.numCuenta;

                                if (idBanco == null || idBanco == 0)
                                {
                                    throw new Exception(String.Format("No se ha configurado ningún Banco para {0}", oLiquidacion.RazonSocial));
                                }

                                if (tipCuenta == null || tipCuenta == 0)
                                {
                                    throw new Exception(String.Format("No se ha configurado ningún Tipo de Cuenta para {0}", oLiquidacion.RazonSocial));
                                }

                                if (String.IsNullOrWhiteSpace(idMonedaBanco.Trim()))
                                {
                                    throw new Exception(String.Format("No se ha configurado ninguna Moneda bancaria para {0}", oLiquidacion.RazonSocial));
                                }

                                if (String.IsNullOrWhiteSpace(numCtaBancaria.Trim()))
                                {
                                    throw new Exception(String.Format("No se ha configurado ninguna Cuenta bancaria para {0}", oLiquidacion.RazonSocial));
                                }
                            }
                            else
                            {
                                throw new Exception(String.Format("No se ha configurado ningún dato de Fondo Fijo o Viáticos para {0}", oLiquidacion.RazonSocial));
                            }

                            //Cabecera de la O.P.
                            oOrdenPago.idEmpresa = oLiquidacion.idEmpresa;
                            oOrdenPago.idLocal = oLiquidacion.idLocal;
                            oOrdenPago.codOrdenPago = String.Empty; //codOrdenPago;
                            oOrdenPago.codTipoPago = oTipoPago.codTipoPago;
                            oOrdenPago.idConcepto = oTipoPagoDet.idConcepto;
                            oOrdenPago.codFormaPago = "003"; //Dep. Cta. Bancaria
                            oOrdenPago.Fecha = oLiquidacion.Fecha;//new EmpresaAD().RecuperarFechaServidor().Date;
                            oOrdenPago.idPersonaBeneficiario = oDatosFFRendiciones.idPersonaResponsable;
                            oOrdenPago.idPersona = oDatosFFRendiciones.idPersona;
                            oOrdenPago.idMoneda = oDatosFFRendiciones.idMoneda;
                            oOrdenPago.Monto = oLiquidacion.ListaLiquidacionDet.Sum(x => x.MontoLiquidar);
                            oOrdenPago.Glosa = "Saldo por Regularizar";
                            oOrdenPago.VieneDe = "L"; //Liquidación
                            oOrdenPago.UsuarioRegistro = Usuario;

                            //Detalle de la O.P.
                            foreach (LiquidacionDetE item in oLiquidacion.ListaLiquidacionDet)
                            {
                                OrdenPagoDetE OrdenDetalle = new OrdenPagoDetE()
                                {
                                    idEmpresa = oLiquidacion.idEmpresa,
                                    idLocal = oLiquidacion.idLocal,
                                    codTipoPago = oTipoPago.codTipoPago,
                                    idConcepto = oTipoPagoDet.idConcepto,
                                    codFormaPago = "003", //Dep. Cta. Bancaria
                                    Fecha = item.FechaDocumento.Value,
                                    idProveedor = Convert.ToInt32(item.idPersona),
                                    idDocumento = item.idDocumento,
                                    serDocumento = item.numSerie,
                                    numDocumento = item.numDocumento,
                                    idMoneda = item.idMoneda,
                                    Monto = item.Monto,
                                    idMonedaPago = item.idMoneda,
                                    MontoPago = item.Monto,
                                    TipPartidaPresu = String.Empty,
                                    CodPartidaPresu = String.Empty,
                                    Concepto = String.Empty,
                                    Descripcion = String.Empty,
                                    numVerPlanCuentas = item.numVerPlanCuentas,
                                    codCuenta = item.codCuenta,
                                    idBanco = idBanco,
                                    tipCuenta = tipCuenta,
                                    idMonedaBanco = idMonedaBanco,
                                    numCtaBancaria = numCtaBancaria,
                                    indPago = false,
                                    indAuto = true, //0=Manual 1=Automático
                                    UsuarioRegistro = Usuario
                                };

                                oOrdenPago.ListaOrdenPago.Add(OrdenDetalle);
                            }

                            #endregion
                        }
                        else
                        {
                            #region Rendiciones

                            oTipoPago = new TipoPagoAD().ObtenerTipoPagoPorTipo("RDV");
                            oTipoPago.DetalleTipoPago = new TipoPagoDetAD().ListarTipoPagoDet(oLiquidacion.idEmpresa, oTipoPago.codTipoPago);

                            TipoPagoDetE oTipoPagoDet = oTipoPago.DetalleTipoPago.Find
                            (
                                delegate (TipoPagoDetE t) { return t.desConcepto.ToUpper().Contains("VIATICOS"); }
                            );

                            if (oTipoPagoDet == null)
                            {
                                throw new Exception("No se ha configurado ningún concepto para el Reembolso de Viáticos");
                            }

                            //Obteniendo los datos del Fondo Fijo y Rendiciones
                            FondoFijoE oDatosFFRendiciones = new FondoFijoAD().ObtenerFondoFijo(oLiquidacion.idEmpresa, oLiquidacion.idLocal, oLiquidacion.idPersona);

                            //Validando los datos bancarios
                            if (oDatosFFRendiciones != null)
                            {
                                idBanco = oDatosFFRendiciones.idPersonaBanco;
                                tipCuenta = oDatosFFRendiciones.tipCuenta;
                                idMonedaBanco = oDatosFFRendiciones.idMonedaCuenta;
                                numCtaBancaria = String.IsNullOrWhiteSpace(oDatosFFRendiciones.numCuenta) ? oDatosFFRendiciones.numInterbancaria : oDatosFFRendiciones.numCuenta;

                                if (idBanco == null || idBanco == 0)
                                {
                                    throw new Exception(String.Format("No se ha configurado ningún Banco para {0}", oLiquidacion.RazonSocial));
                                }

                                if (tipCuenta == null || tipCuenta == 0)
                                {
                                    throw new Exception(String.Format("No se ha configurado ningún Tipo de Cuenta para {0}", oLiquidacion.RazonSocial));
                                }

                                if (String.IsNullOrWhiteSpace(idMonedaBanco.Trim()))
                                {
                                    throw new Exception(String.Format("No se ha configurado ninguna Moneda bancaria para {0}", oLiquidacion.RazonSocial));
                                }

                                if (String.IsNullOrWhiteSpace(numCtaBancaria.Trim()))
                                {
                                    throw new Exception(String.Format("No se ha configurado ninguna Cuenta bancaria para {0}", oLiquidacion.RazonSocial));
                                }
                            }
                            else
                            {
                                throw new Exception(String.Format("No se ha configurado ningún dato de Fondo Fijo o Viáticos para {0}", oLiquidacion.RazonSocial));
                            }

                            //Cabecera de la O.P.
                            oOrdenPago.idEmpresa = oLiquidacion.idEmpresa;
                            oOrdenPago.idLocal = oLiquidacion.idLocal;
                            oOrdenPago.codOrdenPago = String.Empty; //codOrdenPago;
                            oOrdenPago.codTipoPago = oTipoPago.codTipoPago;
                            oOrdenPago.idConcepto = oTipoPagoDet.idConcepto;
                            oOrdenPago.codFormaPago = "003"; //Dep. Cta. Bancaria
                            oOrdenPago.Fecha = oLiquidacion.Fecha; //new EmpresaAD().RecuperarFechaServidor().Date;
                            oOrdenPago.idPersonaBeneficiario = oDatosFFRendiciones.idPersonaResponsable;
                            oOrdenPago.idPersona = oDatosFFRendiciones.idPersona;
                            oOrdenPago.idMoneda = oDatosFFRendiciones.idMoneda;
                            oOrdenPago.Monto = oLiquidacion.ListaLiquidacionDet.Sum(x => x.MontoLiquidar);
                            oOrdenPago.Glosa = "Por Regularizar";
                            oOrdenPago.VieneDe = "L"; //Liquidación
                            oOrdenPago.UsuarioRegistro = Usuario;

                            //Detalle de la O.P.
                            foreach (LiquidacionDetE item in oLiquidacion.ListaLiquidacionDet)
                            {
                                OrdenPagoDetE OrdenDetalle = new OrdenPagoDetE()
                                {
                                    idEmpresa = oLiquidacion.idEmpresa,
                                    idLocal = oLiquidacion.idLocal,
                                    codTipoPago = oTipoPago.codTipoPago,
                                    idConcepto = oTipoPagoDet.idConcepto,
                                    codFormaPago = "003", //Dep. Cta. Bancaria
                                    Fecha = item.FechaDocumento.Value,
                                    idProveedor = Convert.ToInt32(item.idPersona),
                                    idDocumento = item.idDocumento,
                                    serDocumento = item.numSerie,
                                    numDocumento = item.numDocumento,
                                    idMoneda = item.idMoneda,
                                    Monto = item.Monto,
                                    idMonedaPago = item.idMoneda,
                                    MontoPago = item.Monto,
                                    TipPartidaPresu = String.Empty,
                                    CodPartidaPresu = String.Empty,
                                    Concepto = String.Empty,
                                    Descripcion = String.Empty,
                                    numVerPlanCuentas = item.numVerPlanCuentas,
                                    codCuenta = item.codCuenta,
                                    idBanco = idBanco,
                                    tipCuenta = tipCuenta,
                                    idMonedaBanco = idMonedaBanco,
                                    numCtaBancaria = numCtaBancaria,
                                    indPago = false,
                                    indAuto = true, //0=Manual 1=Automático
                                    UsuarioRegistro = Usuario
                                };

                                oOrdenPago.ListaOrdenPago.Add(OrdenDetalle);
                            }

                            #endregion
                        }

                        oOrdenPago = new OrdenPagoLN().GrabarOrdenPago(oOrdenPago, EnumOpcionGrabar.Insertar);

                        if (oOrdenPago != null)
                        {
                            new LiquidacionAD().ActualizarLiquidacionIdOp(oLiquidacion.idLiquidacion, oOrdenPago.idOrdenPago);
                        }
                        
                        #endregion

                        //Mandando a cerrar las provisiones
                        if (ListaProvisiones != null && ListaProvisiones.Count > 0)
                        {
                            new ProvisionesLN().GenerarVoucherProvisionMasivo(ListaProvisiones, Usuario);
                        }

                        ////CtaCte de Viáticos
                        if (TipoFondo == "168" && Tipo == "V")
                        {
                            Decimal Monto = 0;

                            foreach (LiquidacionDetE item in oLiquidacion.ListaLiquidacionDet)
                            {
                                if (item.idMoneda == "01")
                                {
                                    Monto += item.TotalSoles;
                                }
                                else
                                {
                                    Monto += item.TotalDolar;
                                }
                            }

                            TipoCambioE Tica = new TipoCambioAD().ObtenerTipoCambioPorDia("02", oLiquidacion.Fecha.ToString("yyyyMMdd"));

                            #region Cabecera

                            CtaCteE oCtaCte = new CtaCteE
                            {
                                idEmpresa = oLiquidacion.idEmpresa,
                                idPersona = oLiquidacion.idPersona,
                                idDocumento = "LI",
                                numSerie = String.Empty,
                                numDocumento = oLiquidacion.idLiquidacion.ToString(),
                                idMoneda = oLiquidacion.ListaLiquidacionDet[0].idMoneda,
                                MontoOrig = Monto,
                                TipoCambio = Tica.valVenta,
                                FechaDocumento = oLiquidacion.Fecha,
                                FechaVencimiento = oLiquidacion.Fecha,
                                FechaCancelacion = Convert.ToDateTime("31-12-2100"),
                                numVerPlanCuentas = oLiquidacion.numVerPlanCuentas,
                                codCuenta = oLiquidacion.codCuenta,
                                AnnoVencimiento = String.Empty,
                                MesVencimiento = String.Empty,
                                SemanaVencimiento = String.Empty,
                                tipPartidaPresu = String.Empty,
                                codPartidaPresu = String.Empty,
                                desGlosa = "REEMBOLSO DE VIATICOS",
                                FechaOperacion = oLiquidacion.Fecha,
                                EsDetraCab = false,
                                idCtaCteOrigen = 0,
                                idSistema = 6, //Tesoreria
                                UsuarioRegistro = Usuario
                            };

                            oCtaCte = new CtaCteAD().InsertarMaeCtaCte(oCtaCte);

                            #endregion

                            #region Detalle

                            CtaCte_DetE oCtaCteDet = new CtaCte_DetE
                            {
                                idEmpresa = oLiquidacion.idEmpresa,
                                idCtaCte = oCtaCte.idCtaCte,
                                idDocumentoMov = "LI",
                                SerieMov = String.Empty,
                                NumeroMov = oLiquidacion.idLiquidacion.ToString(),
                                FechaMovimiento = oLiquidacion.Fecha,
                                idMoneda = oLiquidacion.ListaLiquidacionDet[0].idMoneda,
                                MontoMov = Monto,
                                TipoCambio = Tica.valVenta,
                                TipAccion = EnumEstadoDocumentos.C.ToString(),
                                numVerPlanCuentas = oLiquidacion.numVerPlanCuentas,
                                codCuenta = oLiquidacion.codCuenta,
                                desGlosa = "REEMBOLSO DE VIATICOS",
                                EsDetraccion = false,
                                UsuarioRegistro = Usuario
                            };

                            oCtaCteDet = new CtaCte_DetAD().InsertarMaeCtaCteDet(oCtaCteDet);

                            #endregion
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

        public int LimpiarVoucherLiquidacion(Int32 idLiquidacion, String UsuarioModificacion)
        {
            try
            {
                return new LiquidacionAD().LimpiarVoucherLiquidacion(idLiquidacion, UsuarioModificacion);
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

        public Boolean AbrirLiquidacion(LiquidacionE oLiquidacion, String Usuario)
        {
            try
            {
                Boolean Resp = false;

                using (TransactionScope oTrans = new TransactionScope())
                {
                    //Lista de provisiones...
                    List<ProvisionesE> ListaProvisiones = null;
                    ProvisionesE ItemProv = null;
                    //Eliminando el voucher
                    new VoucherAD().EliminarVoucher(oLiquidacion.idEmpresa, oLiquidacion.idLocal, oLiquidacion.AnioPeriodo, oLiquidacion.MesPeriodo, oLiquidacion.numVoucher, oLiquidacion.idComprobante, oLiquidacion.numFile);

                    //Actualizando el estado en la liquidación.
                    new LiquidacionAD().ActualizarEstadoLiquidacion(oLiquidacion.idLiquidacion, false, Usuario);

                    //Actualizando el detalle de la liquidacion (Estado de movilidad, provisiones, etc)
                    oLiquidacion.ListaLiquidacionDet = new LiquidacionDetAD().ListarLiquidacionDet(oLiquidacion.idEmpresa, oLiquidacion.idLocal, oLiquidacion.idLiquidacion);

                    if (oLiquidacion.ListaLiquidacionDet != null)
                    {
                        ListaProvisiones = new List<ProvisionesE>();

                        foreach (LiquidacionDetE item in oLiquidacion.ListaLiquidacionDet)
                        {
                            if (item.idMovilidad != null && item.idMovilidad != 0)
                            {
                                new MovilidadAD().ActualizarEstadoMovi(Convert.ToInt32(item.idMovilidad), false, Usuario);
                            }

                            if (item.tipoDocumento == 1)//Si se trata de una provisión agregar a la lista...
                            {
                                ItemProv = new ProvisionesAD().RecuperarProvisionesPorId(item.idEmpresa, item.idLocal, Convert.ToInt32(item.idProvision));

                                if (ItemProv != null)
                                {
                                    ListaProvisiones.Add(ItemProv);
                                }
                            }
                        }
                    }

                    //Eliminando la Orden de Pago
                    if (oLiquidacion.idOrdenPago != 0)
                    {
                        new OrdenPagoAD().EliminarOrdenPago(oLiquidacion.idOrdenPago);
                    }

                    if (ListaProvisiones != null && ListaProvisiones.Count > 0)
                    {
                        new ProvisionesLN().EliminarVoucherProvisionMasivo(ListaProvisiones, Usuario);
                    }

                    ////CtaCte de Viáticos
                    if (oLiquidacion.TipoFondo == "168" && oLiquidacion.Tipo168 == "V")
                    {
                        CtaCteE oCtaCteRevision = new CtaCteAD().ObtenerMaeCtaCte(oLiquidacion.idEmpresa, oLiquidacion.idPersona, "LI", "", oLiquidacion.idLiquidacion.ToString(), false);

                        if (oCtaCteRevision != null)
                        {
                            //Para saber si el documento ya tiene abonos
                            List<CtaCte_DetE> oListaCtaCte = new CtaCte_DetAD().ListarMaeCtaCteDetAbonos(oCtaCteRevision.idEmpresa, oCtaCteRevision.idCtaCte);

                            if (oListaCtaCte.Count > 0)
                            {
                                throw new Exception(String.Format("Este documento {0} {1} en la Cta. Cte. ya tiene movimientos, elimine los movimientos..", "LI", oLiquidacion.idLiquidacion.ToString()));
                            }
                            else
                            {
                                //Eliminando toda la CtaCte del documento
                                new CtaCteAD().EliminarMaeCtaCteConDetalle(oCtaCteRevision.idCtaCte);
                            }
                        }
                    }

                    oTrans.Complete();
                    Resp = true;
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

    }
}
