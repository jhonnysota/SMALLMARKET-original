using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Transactions;
using System.Linq;

using Entidades.Contabilidad;
using Entidades.Ventas;
using Entidades.Generales;
using AccesoDatos.Contabilidad;
using AccesoDatos.Generales;
using Infraestructura;
using Infraestructura.Enumerados;
using Infraestructura.Extensores;

namespace Negocio.Contabilidad
{
    public class VoucherLN
    {

        public VoucherE GrabarVouchers(VoucherE voucher, EnumOpcionGrabar OpcionGrabar)
        {
            Boolean Inhabilitar = (voucher.ListaVouchers.Count > 50);

            try
            {
                TransactionOptions Opciones = new TransactionOptions
                {
                    Timeout = TimeSpan.FromMinutes(720)
                };

                if (voucher.numDocumentoPresu == null)
                {
                    voucher.numDocumentoPresu = "";
                }

                using (TransactionScope oTrans = new TransactionScope(TransactionScopeOption.Required, Opciones))
                {
                    Int32 numVoucher = Variables.Cero;

                    if (Inhabilitar)
                    {
                        new VoucherAD().TriggerVouchers(true); //Desabilita Trigger 
                    }

                    if (OpcionGrabar == EnumOpcionGrabar.Insertar)
                    {
                        if (voucher.numVoucher == Variables.Cero.ToString())
                        {
                            numVoucher = new VoucherAD().GenerarNumVoucher(voucher.idEmpresa, voucher.idLocal, voucher.AnioPeriodo, voucher.MesPeriodo, voucher.idComprobante, voucher.numFile);
                            numVoucher++;
                            voucher.numVoucher = numVoucher.ToString("000000000");
                        }

                        voucher = new VoucherAD().InsertarVoucher(voucher);

                        if (voucher.ListaVouchers != null && voucher.ListaVouchers.Count > Variables.Cero)
                        {
                            foreach (VoucherItemE item in voucher.ListaVouchers)
                            {
                                item.idEmpresa = voucher.idEmpresa;
                                item.idLocal = voucher.idLocal;
                                item.AnioPeriodo = voucher.AnioPeriodo;
                                item.MesPeriodo = voucher.MesPeriodo;
                                item.numVoucher = voucher.numVoucher;
                                item.idComprobante = voucher.idComprobante;
                                item.numFile = voucher.numFile;

                                if ((voucher.idComprobante == Variables.RegistroCompra || voucher.idComprobante == Variables.RegistroVenta) && !voucher.EsAutomatico)
                                {
                                    if (item.idPersona != null && item.idPersona != 0 && item.indAutomatica == "N" && !String.IsNullOrEmpty(item.idDocumento) && !String.IsNullOrEmpty(item.numDocumento))
                                    {
                                        VoucherE VoucherValida = new VoucherAD().ValidaDocContableExistente(item.idEmpresa, item.idLocal, item.AnioPeriodo, item.MesPeriodo, item.numVoucher,
                                                                        item.idComprobante, item.numFile, item.serDocumento, item.numDocumento, Convert.ToInt32(item.idPersona), item.idDocumento);

                                        if (VoucherValida != null)
                                        {
                                            throw new Exception(String.Format("El documento {0}-{1} {2} ya ha sido ingresado con el voucher {3}-{4}-{5} en el Periodo de {6}-{7}",
                                                                item.idDocumento, item.serDocumento, item.numDocumento, VoucherValida.idComprobante, VoucherValida.numFile, VoucherValida.numVoucher, 
                                                                VoucherValida.MesPeriodo, VoucherValida.AnioPeriodo));
                                        }
                                    }
                                }

                                #region CtaCte No borrar
                                //if (item.indCtaCte == Variables.valorSI)
                                //{
                                //    // PROVISIONES (CARGOS)...
                                //    if (item.idAccion == EnumAccionCtaCte.A.ToString())
                                //    {
                                //        #region Cabecera

                                //        conCtaCteE oConCtaCte = new conCtaCteE();

                                //        oConCtaCte.idEmpresa = item.idEmpresa;
                                //        oConCtaCte.numVerPlanCuentas = item.numVerPlanCuentas;
                                //        oConCtaCte.codCuenta = item.codCuenta;
                                //        oConCtaCte.idPersona = Convert.ToInt32(item.idPersona);
                                //        oConCtaCte.fecDocumento = item.fecDocumento;
                                //        oConCtaCte.fecVencimiento = item.fecVencimiento;
                                //        oConCtaCte.fecCancelacion = Convert.ToDateTime("31-12-2100");
                                //        oConCtaCte.idDocumento = item.idDocumento;
                                //        oConCtaCte.serDocumento = item.serDocumento;
                                //        oConCtaCte.numDocumento = item.numDocumento;
                                //        oConCtaCte.idMoneda = item.idMoneda;
                                //        oConCtaCte.idLocal = voucher.idLocal;
                                //        oConCtaCte.idComprobante = voucher.idComprobante;
                                //        oConCtaCte.numFile = voucher.numFile;
                                //        oConCtaCte.numVoucher = voucher.numVoucher;
                                //        oConCtaCte.Glosa = item.desGlosa;
                                //        oConCtaCte.fecOperacion = voucher.fecOperacion;
                                //        oConCtaCte.UsuarioRegistro = voucher.UsuarioRegistro;

                                //        oConCtaCte = new conCtaCteAD().InsertarConCtaCte(oConCtaCte);

                                //        //Actualizando Columnas de la CtaCte en VoucherItem
                                //        item.idCtaCte = oConCtaCte.idCtaCte;

                                //        #endregion

                                //        #region Detalle

                                //        if (oConCtaCte != null)
                                //        {
                                //            if (Convert.ToInt32(item.idMoneda) == (Int32)EnumTipoMoneda.Soles)
                                //            {
                                //                MontoOriginal = item.impSoles;
                                //            }
                                //            else
                                //            {
                                //                MontoOriginal = item.impDolares;
                                //            }

                                //            conCtaCteItemE oCtaCteItem = new conCtaCteItemE
                                //            {
                                //                idCtaCte = oConCtaCte.idCtaCte,
                                //                idDocumentoMov = item.idDocumento,
                                //                SerieMov = item.serDocumento,
                                //                NumeroMov = item.numDocumento,
                                //                FechaMovimiento = Convert.ToDateTime(voucher.fecOperacion),
                                //                TipoMovimiento = EnumEstadoDocumentos.C.ToString(),
                                //                Monto = MontoOriginal,
                                //                TipoCambio = item.tipCambio,
                                //                indDebeHaber = item.indDebeHaber,
                                //                impSoles = item.impSoles,
                                //                impDolares = item.impDolares,
                                //                idLocal = voucher.idLocal,
                                //                idComprobante = voucher.idComprobante,
                                //                numFile = voucher.numFile,
                                //                numVoucher = voucher.numVoucher,
                                //                UsuarioRegistro = voucher.UsuarioRegistro
                                //            };

                                //            oCtaCteItem = new conCtaCteItemAD().InsertarConCtaCteItem(oCtaCteItem);

                                //            //Actualizando Columnas de la CtaCte en VoucherItem
                                //            item.idCtaCteItem = oCtaCteItem.idCtaCteItem;
                                //        }

                                //        #endregion
                                //    } //MOVIMIENTOS (ABONOS)
                                //    else if (item.idAccion == EnumAccionCtaCte.M.ToString())
                                //    {
                                //        #region Detalle

                                //        VoucherItemE VoucherItemDocumento = voucher.ListaVouchers.Find
                                //        (
                                //            delegate(VoucherItemE vi)
                                //            { 
                                //                return vi.indDebeHaber == Variables.ValorHaber && vi.impSoles != Variables.ValorCeroDecimal && vi.impDolares != Variables.ValorCeroDecimal; 
                                //            }
                                //        );

                                //        if (Convert.ToInt32(item.idMoneda) == (Int32)EnumTipoMoneda.Soles)
                                //        {
                                //            MontoOriginal = item.impSoles;
                                //        }
                                //        else
                                //        {
                                //            MontoOriginal = item.impDolares;
                                //        }

                                //        conCtaCteItemE oCtaCteItem = new conCtaCteItemE
                                //        {
                                //            idCtaCte = Convert.ToInt32(item.idCtaCte),
                                //            idDocumentoMov = VoucherItemDocumento.idDocumento,
                                //            SerieMov = VoucherItemDocumento.serDocumento,
                                //            NumeroMov = VoucherItemDocumento.numDocumento,
                                //            FechaMovimiento = Convert.ToDateTime(voucher.fecOperacion),
                                //            TipoMovimiento = EnumEstadoDocumentos.A.ToString(),
                                //            Monto = MontoOriginal,
                                //            TipoCambio = item.tipCambio,
                                //            indDebeHaber = item.indDebeHaber,
                                //            impSoles = item.impSoles,
                                //            impDolares = item.impDolares,
                                //            idLocal = voucher.idLocal,
                                //            idComprobante = voucher.idComprobante,
                                //            numFile = voucher.numFile,
                                //            numVoucher = voucher.numVoucher,
                                //            UsuarioRegistro = voucher.UsuarioRegistro
                                //        };

                                //        oCtaCteItem = new conCtaCteItemAD().InsertarConCtaCteItem(oCtaCteItem);

                                //        //Actualizando Columnas de la CtaCte en VoucherItem
                                //        item.idCtaCte = Convert.ToInt32(item.idCtaCte);
                                //        item.idCtaCteItem = oCtaCteItem.idCtaCteItem;

                                //        conCtaCteItemE oCtaCteItemTemporal = new conCtaCteItemAD().ObtenerConCtaCtePorDocumento(item.idEmpresa, item.numVerPlanCuentas, item.codCuenta, Convert.ToInt32(item.idPersona), DateTime.Now.Date, item.idDocumento, item.serDocumento, item.numDocumento);

                                //        if (oCtaCteItemTemporal != null)
                                //        {
                                //            if (oCtaCteItemTemporal.SaldoSoles == Variables.ValorCero && oCtaCteItemTemporal.SaldoDolares == Variables.ValorCero)
                                //            {
                                //                new conCtaCteAD().ActualizarConCtaCteFechaCancelacion(oCtaCteItemTemporal.idCtaCte, Convert.ToInt32(item.idEmpresa));
                                //            }
                                //        }

                                //        #endregion
                                //    } 
                                //} 
                                #endregion

                                new VoucherItemAD().InsertarVoucherItem(item);
                            }
                        }

                        #region Detracciones

                        if (voucher.idComprobante == Variables.RegistroCompra)
                        {

                            ParametrosContaE oParametroConta = new ParametrosContaAD().ObtenerParametrosConta(voucher.idEmpresa);

                            if (oParametroConta != null)
                            {
                                if (oParametroConta.indDetraccion && oParametroConta.indDiarioDetra)//Si el check de Detraccion y el check del Diario detracción esta habilitada
                                {
                                    String DiarioDetra = oParametroConta.DiarioDetraccion;
                                    String FileDetra = oParametroConta.FileDetraccion;
                                    String CuentaDetra = oParametroConta.ctaDetraccion;
                                    VoucherEnlaceE oEnlace = new VoucherEnlaceE();

                                    //Llenando el enlace
                                    oEnlace.idEmpresa = voucher.idEmpresa;
                                    oEnlace.idLocal = voucher.idLocal;
                                    oEnlace.AnioPeriodo = voucher.AnioPeriodo;
                                    oEnlace.MesPeriodo = voucher.MesPeriodo;
                                    oEnlace.idComprobante = voucher.idComprobante;
                                    oEnlace.numFile = voucher.numFile;
                                    oEnlace.numVoucher = voucher.numVoucher;

                                    if (String.IsNullOrEmpty(DiarioDetra))
                                    {
                                        throw new Exception("El Parametro Detracción esta habilitado para esta cuenta, pero no esta definido el Libro");
                                    }

                                    if (String.IsNullOrEmpty(FileDetra))
                                    {
                                        throw new Exception("El Parametro Detracción esta habilitado para esta cuenta, pero no esta definido el File");
                                    }

                                    if (String.IsNullOrEmpty(CuentaDetra))
                                    {
                                        throw new Exception("El Parametro Detracción esta habilitado para esta cuenta, pero no esta definido la Cuenta Contable.");
                                    }

                                    Int32 numItem = 1;

                                    foreach (VoucherItemE item in voucher.ListaVouchers)
                                    {
                                        if (item.flagDetraccion == Variables.SI)
                                        {
                                            voucher.idComprobante = DiarioDetra;
                                            voucher.numFile = FileDetra;
                                            numVoucher = new VoucherAD().GenerarNumVoucher(voucher.idEmpresa, voucher.idLocal, voucher.AnioPeriodo, voucher.MesPeriodo, DiarioDetra, FileDetra);
                                            numVoucher++;
                                            voucher.numVoucher = numVoucher.ToString("000000000");

                                            voucher.impDebeSoles = Convert.ToDecimal(item.MontoDetraEntero);
                                            voucher.impDebeDolares = Convert.ToDecimal(voucher.impDebeSoles / item.tipCambio);
                                            voucher.impHaberSoles = Convert.ToDecimal(item.MontoDetraEntero);
                                            voucher.impHaberDolares = Convert.ToDecimal(voucher.impHaberSoles / item.tipCambio);

                                            //Insertando la cabecera - Detracción
                                            voucher = new VoucherAD().InsertarVoucher(voucher);

                                            //Insertando el detalle - Detracción - Debe
                                            List<VoucherItemE> ListaDetraccion = new List<VoucherItemE>();
                                            VoucherItemE ItemDetraccionDeb = Infraestructura.Extensores.Colecciones.CopiarEntidad(item);

                                            ItemDetraccionDeb.idEmpresa = voucher.idEmpresa;
                                            ItemDetraccionDeb.idLocal = voucher.idLocal;
                                            ItemDetraccionDeb.AnioPeriodo = voucher.AnioPeriodo;
                                            ItemDetraccionDeb.MesPeriodo = voucher.MesPeriodo;
                                            ItemDetraccionDeb.numVoucher = voucher.numVoucher;
                                            ItemDetraccionDeb.idComprobante = voucher.idComprobante;
                                            ItemDetraccionDeb.numFile = voucher.numFile;
                                            ItemDetraccionDeb.numItem = String.Format("{0:00000}", numItem);
                                            ItemDetraccionDeb.indDebeHaber = Variables.Debe;
                                            ItemDetraccionDeb.codColumnaCoven = null;
                                            ItemDetraccionDeb.impSoles = Convert.ToDecimal(ItemDetraccionDeb.MontoDetraEntero);
                                            ItemDetraccionDeb.impDolares = Convert.ToDecimal(ItemDetraccionDeb.impSoles / ItemDetraccionDeb.tipCambio);

                                            ListaDetraccion.Add(ItemDetraccionDeb);

                                            // Detracción - Haber
                                            VoucherItemE ItemDetraccionHab = Infraestructura.Extensores.Colecciones.CopiarEntidad(ItemDetraccionDeb);
                                            numItem++;

                                            ItemDetraccionHab.idDocumento = "CD";
                                            ItemDetraccionHab.serDocumento = String.Empty;
                                            ItemDetraccionHab.numDocumento = item.numDetraccion;
                                            ItemDetraccionHab.codCuenta = CuentaDetra;
                                            ItemDetraccionHab.numItem = String.Format("{0:00000}", numItem);
                                            ItemDetraccionHab.indDebeHaber = Variables.Haber;
                                            ItemDetraccionHab.idMoneda = Variables.Soles;

                                            ItemDetraccionHab.impSoles = Convert.ToDecimal(ItemDetraccionHab.MontoDetraEntero);
                                            ItemDetraccionHab.impDolares = Convert.ToDecimal(ItemDetraccionHab.impSoles / ItemDetraccionHab.tipCambio);

                                            ListaDetraccion.Add(ItemDetraccionHab);

                                            foreach (VoucherItemE itemD in ListaDetraccion)
                                            {
                                                new VoucherItemAD().InsertarVoucherItem(itemD);
                                            }

                                            //Terminando de llenar los datos del enlace
                                            oEnlace.numItem = item.numItem;
                                            oEnlace.idEmpresaD = item.idEmpresa;
                                            oEnlace.idLocalD = item.idLocal;
                                            oEnlace.AnioPeriodoD = item.AnioPeriodo;
                                            oEnlace.MesPeriodoD = item.MesPeriodo;
                                            oEnlace.idComprobanteD = DiarioDetra;
                                            oEnlace.numFileD = FileDetra;
                                            oEnlace.numVoucherD = numVoucher.ToString("000000000");

                                            oEnlace = new VoucherEnlaceAD().InsertarVoucherEnlace(oEnlace);

                                            break;
                                        }
                                    }
                                }
                            }

                        }

                        #endregion
                    }
                    else
                    {
                        Int32 Resp = 0;
                        voucher = new VoucherAD().ActualizarVoucher(voucher);
                        Resp = new VoucherItemAD().EliminarVoucherItem(voucher.idEmpresa, voucher.idLocal, voucher.AnioPeriodo, voucher.MesPeriodo, voucher.numVoucher, voucher.idComprobante, voucher.numFile);

                        if (voucher.ListaVouchers != null)
                        {
                            foreach (VoucherItemE item in voucher.ListaVouchers)
                            {
                                item.idEmpresa = voucher.idEmpresa;
                                item.idLocal = voucher.idLocal;
                                item.AnioPeriodo = voucher.AnioPeriodo;
                                item.MesPeriodo = voucher.MesPeriodo;
                                item.numVoucher = voucher.numVoucher;
                                item.idComprobante = voucher.idComprobante;
                                item.numFile = voucher.numFile;

                                if (voucher.idComprobante == Variables.RegistroCompra || voucher.idComprobante == Variables.RegistroVenta)
                                {
                                    if (item.idPersona != null && item.idPersona != 0 && item.indAutomatica == "N" && !String.IsNullOrEmpty(item.idDocumento) && !String.IsNullOrEmpty(item.numDocumento))
                                    {
                                        VoucherE VoucherValida = new VoucherAD().ValidaDocContableExistente(item.idEmpresa, item.idLocal, item.AnioPeriodo, item.MesPeriodo, item.numVoucher,
                                                                        item.idComprobante, item.numFile, item.serDocumento, item.numDocumento, Convert.ToInt32(item.idPersona), item.idDocumento);

                                        if (VoucherValida != null)
                                        {
                                            throw new Exception(String.Format("El documento {0}-{1} {2} ya ha sido ingresado con el voucher {3}-{4}-{5} en el Periodo de {6}-{7}",
                                                                item.idDocumento, item.serDocumento, item.numDocumento, VoucherValida.idComprobante, VoucherValida.numFile, VoucherValida.numVoucher,
                                                                VoucherValida.MesPeriodo, VoucherValida.AnioPeriodo));
                                        }
                                    }
                                }

                                #region CtaCte no Borrar

                                //if (item.indCtaCte == Variables.valorSI)
                                //{
                                //    // PROVISIONES (CARGOS)...
                                //    if (item.idAccion == EnumAccionCtaCte.A.ToString())
                                //    {
                                //        #region Cabecera

                                //        if (item.idComprobante == Variables.LibroRegistroVenta || item.idComprobante == Variables.LibroRegistroCompra)
                                //        {
                                //            conCtaCteE oConCtaCte = new conCtaCteE();

                                //            oConCtaCte.idCtaCte = Convert.ToInt32(item.idCtaCte);
                                //            oConCtaCte.idEmpresa = item.idEmpresa;
                                //            oConCtaCte.numVerPlanCuentas = item.numVerPlanCuentas;
                                //            oConCtaCte.codCuenta = item.codCuenta;
                                //            oConCtaCte.idPersona = Convert.ToInt32(item.idPersona);
                                //            oConCtaCte.fecDocumento = item.fecDocumento;
                                //            oConCtaCte.fecVencimiento = item.fecVencimiento;
                                //            oConCtaCte.fecCancelacion = Convert.ToDateTime("31-12-2100");
                                //            oConCtaCte.idDocumento = item.idDocumento;
                                //            oConCtaCte.serDocumento = item.serDocumento;
                                //            oConCtaCte.numDocumento = item.numDocumento;
                                //            oConCtaCte.idMoneda = item.idMoneda;
                                //            oConCtaCte.idLocal = voucher.idLocal;
                                //            oConCtaCte.idComprobante = voucher.idComprobante;
                                //            oConCtaCte.numFile = voucher.numFile;
                                //            oConCtaCte.numVoucher = voucher.numVoucher;
                                //            oConCtaCte.Glosa = item.desGlosa;
                                //            oConCtaCte.fecOperacion = voucher.fecOperacion;
                                //            oConCtaCte.UsuarioModificacion = voucher.UsuarioModificacion;

                                //            oConCtaCte = new conCtaCteAD().ActualizarConCtaCte(oConCtaCte);
                                //        }

                                //        #endregion

                                //        #region Detalle

                                //        if (Convert.ToInt32(item.idMoneda) == (Int32)EnumTipoMoneda.Soles)
                                //        {
                                //            MontoOriginal = item.impSoles;
                                //        }
                                //        else
                                //        {
                                //            MontoOriginal = item.impDolares;
                                //        }

                                //        conCtaCteItemE oCtaCteItem = new conCtaCteItemE
                                //        {
                                //            idCtaCte = Convert.ToInt32(item.idCtaCte),
                                //            idCtaCteItem = Convert.ToInt32(item.idCtaCteItem),
                                //            idDocumentoMov = item.idDocumento,
                                //            SerieMov = item.serDocumento,
                                //            NumeroMov = item.numDocumento,
                                //            FechaMovimiento = Convert.ToDateTime(voucher.fecOperacion),
                                //            TipoMovimiento = EnumEstadoDocumentos.C.ToString(),
                                //            Monto = MontoOriginal,
                                //            TipoCambio = item.tipCambio,
                                //            indDebeHaber = item.indDebeHaber,
                                //            impSoles = item.impSoles,
                                //            impDolares = item.impDolares,
                                //            idLocal = voucher.idLocal,
                                //            idComprobante = voucher.idComprobante,
                                //            numFile = voucher.numFile,
                                //            numVoucher = voucher.numVoucher,
                                //            UsuarioModificacion = voucher.UsuarioModificacion
                                //        };

                                //        oCtaCteItem = new conCtaCteItemAD().ActualizarConCtaCteItem(oCtaCteItem);
                                //        item.idCtaCteItem = oCtaCteItem.idCtaCteItem;

                                //        #endregion
                                //    }//MOVIMIENTOS (ABONOS)
                                //    else if (item.idAccion == EnumAccionCtaCte.M.ToString())
                                //    {
                                //        #region Detalle

                                //        VoucherItemE VoucherItemDocumento = voucher.ListaVouchers.Find
                                //        (
                                //            delegate(VoucherItemE vi)
                                //            { 
                                //                return vi.indDebeHaber == Variables.ValorHaber && vi.impSoles != Variables.ValorCeroDecimal && vi.impDolares != Variables.ValorCeroDecimal; 
                                //            }
                                //        );

                                //        if (Convert.ToInt32(item.idMoneda) == (Int32)EnumTipoMoneda.Soles)
                                //        {
                                //            MontoOriginal = item.impSoles;
                                //        }
                                //        else
                                //        {
                                //            MontoOriginal = item.impDolares;
                                //        }

                                //        conCtaCteItemE oCtaCteItem = new conCtaCteItemE
                                //        {
                                //            idCtaCte = Convert.ToInt32(item.idCtaCte),
                                //            idDocumentoMov = VoucherItemDocumento.idDocumento,
                                //            SerieMov = VoucherItemDocumento.serDocumento,
                                //            NumeroMov = VoucherItemDocumento.numDocumento,
                                //            FechaMovimiento = Convert.ToDateTime(voucher.fecOperacion),
                                //            TipoMovimiento = EnumEstadoDocumentos.A.ToString(),
                                //            Monto = MontoOriginal,
                                //            TipoCambio = item.tipCambio,
                                //            indDebeHaber = item.indDebeHaber,
                                //            impSoles = item.impSoles,
                                //            impDolares = item.impDolares,
                                //            idLocal = voucher.idLocal,
                                //            idComprobante = voucher.idComprobante,
                                //            numFile = voucher.numFile,
                                //            numVoucher = voucher.numVoucher,
                                //            UsuarioRegistro = voucher.UsuarioRegistro
                                //        };

                                //        oCtaCteItem = new conCtaCteItemAD().ActualizarConCtaCteItem(oCtaCteItem);

                                //        //Actualizando Columnas de la CtaCte en VoucherItem
                                //        item.idCtaCte = Convert.ToInt32(item.idCtaCte);
                                //        item.idCtaCteItem = oCtaCteItem.idCtaCteItem;

                                //        conCtaCteItemE oCtaCteTemporal = new conCtaCteItemAD().ObtenerConCtaCtePorDocumento(item.idEmpresa, item.numVerPlanCuentas, item.codCuenta, Convert.ToInt32(item.idPersona), DateTime.Now.Date, item.idDocumento, item.serDocumento, item.numDocumento);

                                //        if (oCtaCteTemporal != null)
                                //        {
                                //            if (oCtaCteTemporal.SaldoSoles == Variables.ValorCero && oCtaCteTemporal.SaldoDolares == Variables.ValorCero)
                                //            {
                                //                new conCtaCteAD().ActualizarConCtaCteFechaCancelacion(oCtaCteTemporal.idCtaCte, Convert.ToInt32(item.idEmpresa));
                                //            }
                                //        }

                                //        #endregion
                                //    } 
                                //}


                                #endregion

                                new VoucherItemAD().InsertarVoucherItem(item);
                            }
                        }

                        #region Detracciones

                        ParametrosContaE oParametroConta = new ParametrosContaAD().ObtenerParametrosConta(voucher.idEmpresa);

                        if (oParametroConta != null)
                        {
                            if (oParametroConta.indDetraccion && oParametroConta.indDiarioDetra)
                            {
                                String DiarioDetra = oParametroConta.DiarioDetraccion;
                                String FileDetra = oParametroConta.FileDetraccion;
                                String CuentaDetra = oParametroConta.ctaDetraccion;

                                if (String.IsNullOrEmpty(DiarioDetra))
                                {
                                    throw new Exception("El Parametro Detracción esta habilitado para esta cuenta, pero no esta definido el Libro");
                                }

                                if (String.IsNullOrEmpty(FileDetra))
                                {
                                    throw new Exception("El Parametro Detracción esta habilitado para esta cuenta, pero no esta definido el File");
                                }

                                if (String.IsNullOrEmpty(CuentaDetra))
                                {
                                    throw new Exception("El Parametro Detracción esta habilitado para esta cuenta, pero no esta definido la Cuenta Contable.");
                                }

                                Int32 numItem = 1;

                                foreach (VoucherItemE item in voucher.ListaVouchers)
                                {
                                    if (item.flagDetraccion.Substring(0, 1) == Variables.SI)
                                    {
                                        if (item.MontoDetraEntero < 1)
                                        {
                                            if (item.idMoneda == Variables.Soles)
                                            {
                                                item.MontoDetraEntero = Math.Round(Convert.ToDecimal(item.MontoDetraccion), MidpointRounding.AwayFromZero);
                                            }
                                            else
                                            {
                                                item.MontoDetraEntero = Math.Round(Convert.ToDecimal(item.MontoDetraccion) * Convert.ToDecimal(item.tipCambio), MidpointRounding.AwayFromZero);
                                            }
                                        }

                                        VoucherEnlaceE oEnlace = new VoucherEnlaceAD().ObtenerVoucherEnlace(item.idEmpresa, item.idLocal, item.AnioPeriodo, item.MesPeriodo, item.numVoucher, item.idComprobante, item.numFile);

                                        if (oEnlace == null)
                                        {
                                            oEnlace = new VoucherEnlaceE();

                                            //Llenando el enlace
                                            oEnlace.idEmpresa = voucher.idEmpresa;
                                            oEnlace.idLocal = voucher.idLocal;
                                            oEnlace.AnioPeriodo = voucher.AnioPeriodo;
                                            oEnlace.MesPeriodo = voucher.MesPeriodo;
                                            oEnlace.idComprobante = voucher.idComprobante;
                                            oEnlace.numFile = voucher.numFile;
                                            oEnlace.numVoucher = voucher.numVoucher;

                                            voucher.idComprobante = DiarioDetra;
                                            voucher.numFile = FileDetra;
                                            numVoucher = new VoucherAD().GenerarNumVoucher(voucher.idEmpresa, voucher.idLocal, voucher.AnioPeriodo, voucher.MesPeriodo, DiarioDetra, FileDetra);
                                            numVoucher++;
                                            voucher.numVoucher = numVoucher.ToString("000000000");

                                            voucher.impDebeSoles = Convert.ToDecimal(item.MontoDetraEntero);
                                            voucher.impDebeDolares = Convert.ToDecimal(voucher.impDebeSoles / item.tipCambio);
                                            voucher.impHaberSoles = Convert.ToDecimal(item.MontoDetraEntero);
                                            voucher.impHaberDolares = Convert.ToDecimal(voucher.impHaberSoles / item.tipCambio);

                                            //Insertando la cabecera - Detracción
                                            voucher = new VoucherAD().InsertarVoucher(voucher);

                                            //Insertando el detalle - Detracción - Debe
                                            List<VoucherItemE> ListaDetraccion = new List<VoucherItemE>();
                                            VoucherItemE ItemDetraccionDeb = Infraestructura.Extensores.Colecciones.CopiarEntidad(item);

                                            ItemDetraccionDeb.idEmpresa = voucher.idEmpresa;
                                            ItemDetraccionDeb.idLocal = voucher.idLocal;
                                            ItemDetraccionDeb.AnioPeriodo = voucher.AnioPeriodo;
                                            ItemDetraccionDeb.MesPeriodo = voucher.MesPeriodo;
                                            ItemDetraccionDeb.numVoucher = voucher.numVoucher;
                                            ItemDetraccionDeb.idComprobante = voucher.idComprobante;
                                            ItemDetraccionDeb.numFile = voucher.numFile;
                                            ItemDetraccionDeb.numItem = String.Format("{0:00000}", numItem);
                                            ItemDetraccionDeb.indDebeHaber = Variables.Debe;
                                            ItemDetraccionDeb.codColumnaCoven = null;

                                            ItemDetraccionDeb.impSoles = Convert.ToDecimal(ItemDetraccionDeb.MontoDetraEntero);
                                            ItemDetraccionDeb.impDolares = Convert.ToDecimal(ItemDetraccionDeb.impSoles / ItemDetraccionDeb.tipCambio);

                                            ListaDetraccion.Add(ItemDetraccionDeb);

                                            // Detracción - Haber
                                            VoucherItemE ItemDetraccionHab = Infraestructura.Extensores.Colecciones.CopiarEntidad(ItemDetraccionDeb);
                                            numItem++;

                                            ItemDetraccionHab.idDocumento = "CD";
                                            ItemDetraccionHab.serDocumento = String.Empty;
                                            ItemDetraccionHab.numDocumento = item.numDetraccion;
                                            ItemDetraccionHab.codCuenta = CuentaDetra;
                                            ItemDetraccionHab.numItem = String.Format("{0:00000}", numItem);
                                            ItemDetraccionHab.indDebeHaber = Variables.Haber;
                                            ItemDetraccionHab.idMoneda = Variables.Soles;

                                            ItemDetraccionHab.impSoles = Convert.ToDecimal(ItemDetraccionHab.MontoDetraEntero);
                                            ItemDetraccionHab.impDolares = Convert.ToDecimal(ItemDetraccionHab.impSoles / ItemDetraccionHab.tipCambio);

                                            ListaDetraccion.Add(ItemDetraccionHab);

                                            foreach (VoucherItemE itemD in ListaDetraccion)
                                            {
                                                new VoucherItemAD().InsertarVoucherItem(itemD);
                                            }

                                            //Terminando de llenar los datos del enlace
                                            oEnlace.numItem = item.numItem;
                                            oEnlace.idEmpresaD = item.idEmpresa;
                                            oEnlace.idLocalD = item.idLocal;
                                            oEnlace.AnioPeriodoD = item.AnioPeriodo;
                                            oEnlace.MesPeriodoD = item.MesPeriodo;
                                            oEnlace.idComprobanteD = DiarioDetra;
                                            oEnlace.numFileD = FileDetra;
                                            oEnlace.numVoucherD = numVoucher.ToString("000000000");

                                            oEnlace = new VoucherEnlaceAD().InsertarVoucherEnlace(oEnlace);
                                        }
                                        else
                                        {
                                            voucher.idComprobante = oEnlace.idComprobanteD;
                                            voucher.numFile = oEnlace.numFileD;
                                            voucher.numVoucher = oEnlace.numVoucherD;

                                            voucher.impDebeSoles = Convert.ToDecimal(item.MontoDetraEntero);
                                            voucher.impDebeDolares = Convert.ToDecimal(voucher.impDebeSoles / item.tipCambio);
                                            voucher.impHaberSoles = Convert.ToDecimal(item.MontoDetraEntero);
                                            voucher.impHaberDolares = Convert.ToDecimal(voucher.impHaberSoles / item.tipCambio);

                                            //Insertando la cabecera - Detracción
                                            voucher = new VoucherAD().ActualizarVoucher(voucher);

                                            //Insertando el detalle - Detracción - Debe
                                            List<VoucherItemE> ListaDetraccion = new List<VoucherItemE>();
                                            VoucherItemE ItemDetraccionDeb = Infraestructura.Extensores.Colecciones.CopiarEntidad(item);

                                            ItemDetraccionDeb.idEmpresa = voucher.idEmpresa;
                                            ItemDetraccionDeb.idLocal = voucher.idLocal;
                                            ItemDetraccionDeb.AnioPeriodo = voucher.AnioPeriodo;
                                            ItemDetraccionDeb.MesPeriodo = voucher.MesPeriodo;
                                            ItemDetraccionDeb.numVoucher = voucher.numVoucher;
                                            ItemDetraccionDeb.idComprobante = voucher.idComprobante;
                                            ItemDetraccionDeb.numFile = voucher.numFile;
                                            ItemDetraccionDeb.numItem = String.Format("{0:00000}", numItem);
                                            ItemDetraccionDeb.indDebeHaber = Variables.Debe;
                                            ItemDetraccionDeb.codColumnaCoven = null;

                                            ItemDetraccionDeb.impSoles = Convert.ToDecimal(ItemDetraccionDeb.MontoDetraEntero);
                                            ItemDetraccionDeb.impDolares = Convert.ToDecimal(ItemDetraccionDeb.impSoles / ItemDetraccionDeb.tipCambio);

                                            ListaDetraccion.Add(ItemDetraccionDeb);

                                            // Detracción - Haber
                                            VoucherItemE ItemDetraccionHab = Infraestructura.Extensores.Colecciones.CopiarEntidad(ItemDetraccionDeb);
                                            numItem++;

                                            ItemDetraccionHab.idDocumento = "CD";
                                            ItemDetraccionHab.serDocumento = String.Empty;
                                            ItemDetraccionHab.numDocumento = item.numDetraccion;
                                            ItemDetraccionHab.codCuenta = CuentaDetra;
                                            ItemDetraccionHab.numItem = String.Format("{0:00000}", numItem);
                                            ItemDetraccionHab.indDebeHaber = Variables.Haber;
                                            ItemDetraccionHab.idMoneda = Variables.Soles;

                                            ItemDetraccionHab.impSoles = Convert.ToDecimal(ItemDetraccionHab.MontoDetraEntero);
                                            ItemDetraccionHab.impDolares = Convert.ToDecimal(ItemDetraccionHab.impSoles / ItemDetraccionHab.tipCambio);

                                            ListaDetraccion.Add(ItemDetraccionHab);

                                            //Eliminando el detalle de la detracción...
                                            Resp = new VoucherItemAD().EliminarVoucherItem(voucher.idEmpresa, voucher.idLocal, voucher.AnioPeriodo, voucher.MesPeriodo, voucher.numVoucher, voucher.idComprobante, voucher.numFile);

                                            foreach (VoucherItemE itemD in ListaDetraccion)
                                            {
                                                new VoucherItemAD().InsertarVoucherItem(itemD);
                                            }
                                        }

                                        break;
                                    }
                                }
                            }
                        }

                        #endregion

                    }

                    if (Inhabilitar)
                    {
                        new VoucherAD().TriggerVouchers(false); //Habilita Trigger
                    }

                    oTrans.Complete();
                }
                
                return voucher;
            }
            catch (SqlException ex)
            {
                SqlError err = ex.Errors[0];
                StringBuilder mensaje = new StringBuilder();

                if (Inhabilitar)
                {
                    new VoucherAD().TriggerVouchers(false); //Habilita Trigger 
                }

                switch (err.Number)
                {                    
                    default:
                        mensaje.Append("Mensaje: " + err.Message + "\n");
                        mensaje.Append("N° Linea: " + err.LineNumber + "\n");
                        mensaje.Append("Origen: " + err.Source + "\n");
                        mensaje.Append("Procedimiento: " + err.Procedure + "\n");
                        mensaje.Append("N° Error: " + err.Number + "\n");
                        break;
                }

                throw new Exception(mensaje.ToString()+" "+String.Format("Verifique Dcmto: {0} ", voucher.numDocumentoPresu));
            }
        }

        public VoucherE InsertarVoucher(VoucherE voucher)
        {
            try
            {
                return new VoucherAD().InsertarVoucher(voucher);
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

        public VoucherE ActualizarVoucher(VoucherE voucher)
        {
            try
            {
                return new VoucherAD().ActualizarVoucher(voucher);
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

        public List<VoucherE> ListarVoucher(Int32 idEmpresa, Int32 idLocal, String AnioPeriodo, String MesPeriodo, String idComprobante, String numFile)
        {
            try
            {
                return new VoucherAD().ListarVoucher(idEmpresa, idLocal, AnioPeriodo, MesPeriodo, idComprobante, numFile);
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

        public List<VoucherE> ListarVoucherNumVoucher(Int32 idEmpresa, Int32 idLocal, String AnioPeriodo, String MesPeriodo, String idComprobante, String numFile, String numVoucher)
        {
            try
            {
                return new VoucherAD().ListarVoucherNumVoucher(idEmpresa, idLocal, AnioPeriodo, MesPeriodo, idComprobante, numFile, numVoucher);
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

        public Int32 EliminarVoucher(Int32 idEmpresa, Int32 idLocal, String AnioPeriodo, String MesPeriodo, String numVoucher, String idComprobantes, String numFile)
        {
            try
            {
                return new VoucherAD().EliminarVoucher(idEmpresa, idLocal, AnioPeriodo, MesPeriodo, numVoucher, idComprobantes, numFile);
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

        public void AnularVoucher(VoucherE voucher, String UsuarioAnula, String Tipo)
        {
            try
            {
                using (TransactionScope oTrans = new TransactionScope())
                {
                    if (voucher.numItems > 50)
                    {
                        new VoucherAD().TriggerVouchers(true); //Desabilita Trigger
                    }

                    new VoucherAD().AnularVoucher(voucher.idEmpresa, voucher.idLocal, voucher.AnioPeriodo, voucher.MesPeriodo, voucher.numVoucher, voucher.idComprobante, voucher.numFile, UsuarioAnula, Tipo);

                    if (voucher.idComprobante == Variables.RegistroCompra)
                    {
                        VoucherEnlaceE oEnlace = new VoucherEnlaceAD().ObtenerVoucherEnlace(voucher.idEmpresa, voucher.idLocal, voucher.AnioPeriodo, voucher.MesPeriodo, voucher.numVoucher, voucher.idComprobante, voucher.numFile);

                        if (oEnlace != null)
                        {
                            //Borrando el voucher de la detracción
                            new VoucherAD().AnularVoucher(oEnlace.idEmpresaD, oEnlace.idLocalD, oEnlace.AnioPeriodoD, oEnlace.MesPeriodoD, oEnlace.numVoucherD, oEnlace.idComprobanteD, oEnlace.numFileD, "", "E");
                            //Borrando el enlace
                            new VoucherEnlaceAD().EliminarVoucherEnlace(voucher.idEmpresa, voucher.idLocal, voucher.AnioPeriodo, voucher.MesPeriodo, voucher.numVoucher, voucher.idComprobante, voucher.numFile, "00001");
                        }
                    }

                    if (voucher.numItems > 50)
                    {
                        new VoucherAD().TriggerVouchers(false); //Habilita Trigger
                    }

                    //Completando la transacción si todo esta ok...
                    oTrans.Complete();
                }
            }
            catch (SqlException ex)
            {
                SqlError err = ex.Errors[0];
                StringBuilder mensaje = new StringBuilder();

                if (voucher.numItems > 50)
                {
                    new VoucherAD().TriggerVouchers(false); //Habilita Trigger
                }

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

        public VoucherE ObtenerVoucherPorCodigo(Int32 idEmpresa, Int32 idLocal, String AnioPeriodo, String MesPeriodo, String numVoucher, String idComprobantes, String numFile, String ConDetalle = "S")
        {
            try
            {
                // Cabecera
                VoucherE Voucher = new VoucherAD().ObtenerVoucherPorCodigo(idEmpresa, idLocal, AnioPeriodo, MesPeriodo, numVoucher, idComprobantes, numFile);

                // Detalle
                if (Voucher != null && ConDetalle == "S")
                {
                    Voucher.ListaVouchers = new VoucherItemAD().ObtenerVoucherItemPorCodigo(idEmpresa, idLocal, AnioPeriodo, MesPeriodo, numVoucher, idComprobantes, numFile);
                }
                //foreach (VoucherItemE item in Voucher.ListaVouchers)
                //{
                //    PlanCuentasE Cuenta = new PlanCuentasAD().ObtenerPlanCuentasPorCodigo(item.idEmpresa, item.numVerPlanCuentas, item.codCuenta);

                //    if (Cuenta.indCuentaGastos == Variables.valorSI)
                //    {
                //        item.indCuentaGastos = Variables.valorSI;
                //        item.codCuentaDestino = Cuenta.codCuentaDestino;
                //        item.codCuentaTransferencia = Cuenta.codCuentaTransferencia;
                //    }
                //}

                return Voucher;
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

        public VoucherE GenerarVoucherCancelacionCompra(Int32 idEmpresa, Int32 idLocal, String AnioPeriodo, String MesPeriodo, String numVoucher, String idComprobantes, String numFile, VoucherItemE oCancela)
        {
            try
            {
                // Cabecera
                VoucherE Voucher = new VoucherAD().ObtenerVoucherPorCodigo(idEmpresa, idLocal, AnioPeriodo, MesPeriodo, numVoucher, idComprobantes, numFile);

                // Detalle
                if (Voucher != null )
                {
                    Voucher.ListaVouchers = new VoucherItemAD().ObtenerVoucherItemPorCodigo(idEmpresa, idLocal, AnioPeriodo, MesPeriodo, numVoucher, idComprobantes, numFile);
                }

                foreach (VoucherItemE item in Voucher.ListaVouchers)
                {
                    if (item.codColumnaCoven == 278001)
                    {
                        PlanCuentasE Cuenta = new PlanCuentasAD().ObtenerPlanCuentasPorCodigo(item.idEmpresa, item.numVerPlanCuentas, item.codCuenta);

                        if (Cuenta.indCtaCte == Variables.SI && Cuenta.indSolicitaDcto == Variables.SI && Cuenta.indSolicitaAnexo == Variables.SI)
                        {
                          VoucherE oVoucherCancela = null;

                            oVoucherCancela = new VoucherE
                            {
                                idEmpresa = Voucher.idEmpresa,
                                idLocal = Voucher.idLocal,
                                AnioPeriodo = Voucher.AnioPeriodo,
                                MesPeriodo = Voucher.MesPeriodo,
                                numVoucher = "0",
                                idComprobante = oCancela.idComprobante,
                                numFile = oCancela.numFile,
                                idMoneda = Voucher.idMoneda,
                                fecOperacion = Voucher.fecOperacion,
                                fecDocumento = oCancela.fecDocumento,
                                impDebeSoles = Voucher.impDebeSoles,
                                impHaberSoles = Voucher.impHaberSoles,
                                impDebeDolares = Voucher.impDebeDolares,
                                impHaberDolares = Voucher.impHaberDolares,
                                GlosaGeneral = Voucher.GlosaGeneral,
                                indEstado = "C",
                                tipCambio = oCancela.tipCambio,
                                RazonSocial = Voucher.RazonSocial,
                                indHojaCosto = "N",
                                numHojaCosto = "",
                                numOrdenCompra = "",
                                sistema = "CON",
                                EsAutomatico = true,
                                numDocumentoPresu = Voucher.numDocumentoPresu,
                                impMonOrigDeb = Voucher.impMonOrigDeb,
                                impMonOrigHab = Voucher.impMonOrigHab,
                                UsuarioRegistro = Voucher.UsuarioRegistro,
                                UsuarioModificacion = Voucher.UsuarioModificacion
                            };

                         item.indDebeHaber = "D";
                         item.idComprobante = oCancela.idComprobante;
                         item.numFile = oCancela.numFile;
                         item.numItem = "00001";

                         oVoucherCancela.ListaVouchers.Add(item);

                         VoucherItemE oItem = Colecciones.CopiarEntidad<VoucherItemE>(item);

                         oItem.indDebeHaber = "H";
                         oItem.codCuenta = oCancela.codCuenta;
                         oItem.fecDocumento = oCancela.fecDocumento;
                         oItem.tipCambio = oCancela.tipCambio;
                         oItem.numItem = "00002";

                         oVoucherCancela.ListaVouchers.Add(oItem);

                         new VoucherLN().GrabarVouchers(oVoucherCancela, EnumOpcionGrabar.Insertar);

                        }
                    }

                }

                return Voucher;
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

        public VoucherE GenerarVoucherCopia(Int32 idEmpresa, Int32 idLocal, String AnioPeriodo, String MesPeriodo, String numVoucher, String idComprobantes, String numFile, VoucherItemE oCancela)
        {
            try
            {
                // Cabecera
                VoucherE Voucher = new VoucherAD().ObtenerVoucherPorCodigo(idEmpresa, idLocal, AnioPeriodo, MesPeriodo, numVoucher, idComprobantes, numFile);

                // Detalle
                if (Voucher != null)
                {
                    Voucher.ListaVouchers = new VoucherItemAD().ObtenerVoucherItemPorCodigo(idEmpresa, idLocal, AnioPeriodo, MesPeriodo, numVoucher, idComprobantes, numFile);
                }

                VoucherE oVoucherCopiar = new VoucherE();

                oVoucherCopiar = Voucher;
                oVoucherCopiar.numVoucher = "0";
                oVoucherCopiar.fecOperacion = oCancela.fecDocumento;
                oVoucherCopiar.numFile = oCancela.numFile;
                oVoucherCopiar.idComprobante = oCancela.idComprobante;
                oVoucherCopiar.MesPeriodo = oCancela.MesPeriodo;
                oVoucherCopiar.EsAutomatico = false;
                oVoucherCopiar.sistema = "COPIA";
              
                //foreach (VoucherItemE item in Voucher.ListaVouchers)
                //{           
                   
                    //VoucherItemE oItem = Colecciones.CopiarEntidad<VoucherItemE>(item);

                //    oVoucherCopiar.ListaVouchers.Add(item);

                //}

                new VoucherLN().GrabarVouchers(oVoucherCopiar, EnumOpcionGrabar.Insertar);


                return Voucher;
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

        public Int32 TransferirVentasVoucher(Int32 idEmpresa, Int32 idLocal, DateTime fecIni, DateTime fecFin, String Usuario)
        {
            try
            {
                Int32 Resp;

                using (TransactionScope oTrans = new TransactionScope())
                {
                    //Parametros de contabilidad
                    ParametrosContaE oParametrosConta = new ParametrosContaAD().ObtenerParametrosConta(idEmpresa);

                    if (oParametrosConta != null)
                    {
                        if (string.IsNullOrEmpty(oParametrosConta.VentaS.Trim()))
                        {
                            throw new Exception("No se ha configurado la cuenta de ventas en soles.");
                        }

                        if (string.IsNullOrEmpty(oParametrosConta.VentaD.Trim()))
                        {
                            throw new Exception("No se ha configurado la cuenta de ventas en dólares.");
                        }

                        if (oParametrosConta.idAnulado == null || oParametrosConta.idAnulado == 0)
                        {
                            throw new Exception("No se ha configurado el parámetro de anulación.");
                        }
                    }
                    else
                    {
                        throw new Exception("No se ha configurado ningún parametro de contabilidad para esta empresa.");
                    }

                    Resp = new VoucherAD().TransferirVentasVoucher(idEmpresa, idLocal, fecIni, fecFin, Usuario);

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

        public void GenerarVoucherVentas(String indNuevo, String idComprobante, String numFile, EmisionDocumentoE oDocumentoVenta)
        {
            try
            {
                #region Variables Generales

                VoucherE oVoucher = null;
                String numVoucher = String.Empty;
                String Glosa = oDocumentoVenta.ListaItemsDocumento[0].nomArticulo;
                Int32 idArticulo = Convert.ToInt32(oDocumentoVenta.ListaItemsDocumento[0].idArticulo);
                Decimal TicaDolar = Variables.ValorCeroDecimal;
                Decimal impSoles = Variables.ValorCeroDecimal;
                Decimal impDolares = Variables.ValorCeroDecimal;
                String MonedaVoucher = String.Empty;
                String numDocuPresu = oDocumentoVenta.idDocumento + " " + oDocumentoVenta.numSerie + "-" + oDocumentoVenta.numDocumento;
                Decimal DebeOrigen = Variables.ValorCeroDecimal;
                Decimal HaberOrigen = Variables.ValorCeroDecimal;
                String ctaTotal = String.Empty;
                String ctaBase = String.Empty;
                String numVerPlanCuentas = String.Empty;
                String DebeHaber = String.Empty;
                String TipoCuenta = String.Empty;
                String CCostos = String.Empty;
                Int32? idPersona = Variables.Cero;
                //DateTime? fecEmisionTmp;
				String TipoDocuTmp = String.Empty;
				String SerieTmp = String.Empty;
				String NumeroTmp = String.Empty;
				DateTime? fecRefeDocuTmp;
				String tipRefeDocuTmp = String.Empty;
				String SerieRefeDocuTmp = String.Empty;
                String numRefeDocuTmp = String.Empty;
                Decimal ImporteDocumento = Variables.ValorCeroDecimal;

                #endregion

                #region Variables para la Factura
                
                //DateTime fecEmisDocu = oDocumentoVenta.fecEmision.Date; //Revisar
                Int32 Auxiliar = oDocumentoVenta.idPersona.Value;
                String idMoneda = oDocumentoVenta.idMoneda;
                Decimal TipoCambioDocu = oDocumentoVenta.tipCambio;
                Decimal TicaReal = oDocumentoVenta.tipCambio;
                Decimal subTotalDocu = oDocumentoVenta.totsubTotal;
                Decimal FleteDocu = oDocumentoVenta.Flete.Value;
                Decimal SeguroDocu = oDocumentoVenta.seguro.Value;
                Decimal IscDocu = oDocumentoVenta.totIsc.Value;
                Decimal IgvDocu = oDocumentoVenta.totIgv.Value;
                Decimal TotalDocu = oDocumentoVenta.totTotal;
                String EstadoDocu = oDocumentoVenta.indEstado;
                DateTime fecRefeDocu = oDocumentoVenta.fecDocumentoRef.Value.Date;
                String tipRefeDocu = oDocumentoVenta.idDocumentoRef;
                String SerieRefeDocu = oDocumentoVenta.serDocumentoRef;
                String numRefeDocu = oDocumentoVenta.numDocumentoRef;
                String Proveedor = oDocumentoVenta.RazonSocial.Substring(0, 20);
                String RazonSocial = oDocumentoVenta.RazonSocial;
                String PeriodoAnio = "Año: " + oDocumentoVenta.Anio;
                String AnioPeriodo = oDocumentoVenta.Anio;
                String MesPeriodo = oDocumentoVenta.Mes;
                //DateTime fecCanDocu; 

                #endregion

                #region Numero del Voucher
                
                if (indNuevo == "S")
                {
                    //Int32 numVoucherMax = Variables.ValorCero;

                    //numVoucherMax = new VoucherAD().GenerarNumVoucher(oDocumentoVenta.idEmpresa, oDocumentoVenta.idLocal, oDocumentoVenta.AnioPeriodo, oDocumentoVenta.MesPeriodo, idComprobante, numFile);
                    numVoucher = Variables.Cero.ToString();
                }
                else
                {
                    numVoucher = oDocumentoVenta.numVoucher;
                } 

                #endregion

                if (EstadoDocu == "A")
                {
                    Auxiliar = 179; //IdPersona de Anulado
                    Proveedor = "ANULADO";
                    Glosa = String.Empty;
                    PeriodoAnio = String.Empty;
                    TotalDocu = Variables.ValorCeroDecimal;
                }

                #region Tipo de Cambio
                
                TipoCambioE oTica = null;

                if (EstadoDocu != "A" && idMoneda != Variables.Soles)
                {
                    //oTica = new TipoCambioAD().ObtenerTipoCambioPorDia(idMoneda, fecEmisDocu.ToString("yyyyMMdd")); //Revisar
                    TipoCambioDocu = oTica.valVenta;
                }

                //oTica = new TipoCambioAD().ObtenerTipoCambioPorDia(Variables.Dolares, fecEmisDocu.ToString("yyyyMMdd")); //Revisar
                TicaDolar = oTica.valVenta; 

                #endregion

                #region Importes para la cabecera
                
                switch (idMoneda)
                {
                    case "01":
                        impSoles = TotalDocu;
                        impDolares = Decimal.Round(impSoles / TipoCambioDocu, 2);
                        MonedaVoucher = idMoneda;
                        DebeOrigen = impSoles;
                        HaberOrigen = impSoles;

                        break;
                    case "02":
                        impDolares = TotalDocu;
                        impSoles = Decimal.Round(impDolares * TicaReal, 2);
                        MonedaVoucher = idMoneda;
                        DebeOrigen = impDolares;
                        HaberOrigen = impDolares;

                        break;
                    default:
                        impSoles = Decimal.Round(TotalDocu * TicaReal, 2);
                        impDolares = Decimal.Round(impSoles / TicaDolar, 2);
                        MonedaVoucher = Variables.Dolares;
                        DebeOrigen = impDolares;
                        HaberOrigen = impDolares;

                        break;
                }

                if (EstadoDocu == "A")
                {
                    impSoles = Variables.ValorCeroDecimal;
                    impDolares = Variables.ValorCeroDecimal;
                    DebeOrigen = Variables.ValorCeroDecimal;
                    HaberOrigen = Variables.ValorCeroDecimal;
                } 

                #endregion

                Glosa = Proveedor + " " + Glosa + " " + PeriodoAnio;

                #region Cuentas

                switch (idArticulo)
                {
                    case 1:
                        ctaTotal = "168912";
                        ctaBase = "754511";
                        break;
                    case 2:
                        ctaTotal = "168912";
                        ctaBase = "754511";
                        break;
                    case 3:
                        ctaTotal = "168912";
                        ctaBase = "759918";
                        break;
                    case 4:
                        ctaTotal = "168912";
                        ctaBase = "759918";
                        break;
                    case 6:
                        ctaTotal = "168912";
                        ctaBase = "759918";
                        break;
                    case 7:
                        ctaTotal = "128913";
                        ctaBase = "759914";
                        break;
                    case 8:
                        ctaTotal = "128913";
                        ctaBase = "759916";
                        break;
                    case 9:
                        ctaTotal = "168912";
                        ctaBase = "754511";
                        break;
                    case 10:
                        ctaTotal = "168912";
                        ctaBase = "754511";
                        break;
                    case 11:
                        ctaTotal = "168912";
                        ctaBase = "754511";
                        break;
                    case 12:
                        ctaTotal = "168912";
                        ctaBase = "754511";
                        break;
                    case 13:
                        ctaTotal = "168912";
                        ctaBase = "754511";
                        break;
                    case 14:
                        ctaTotal = "168912";
                        ctaBase = "754511";
                        break;
                    case 15:
                        ctaTotal = "168912";
                        ctaBase = "759918";
                        break;
                    case 16:
                        ctaTotal = "168914";
                        ctaBase = "759917";
                        break;
                    case 17:
                        ctaTotal = "168912";
                        ctaBase = "754511";
                        break;
                    default:
                        break;
                } 

                #endregion

                PlanCuentasVersionE VersionPc = new PlanCuentasVersionAD().VersionPlanCuentasActual(oDocumentoVenta.idEmpresa);
                numVerPlanCuentas = VersionPc.numVerPlanCuentas;

                List<PlanCuentasE> oPlanContable = new List<PlanCuentasE>();
                oPlanContable.Add(new PlanCuentasAD().ObtenerPlanCuentasPorCodigo(oDocumentoVenta.idEmpresa, numVerPlanCuentas, ctaTotal));
                oPlanContable.Add(new PlanCuentasAD().ObtenerPlanCuentasPorCodigo(oDocumentoVenta.idEmpresa, numVerPlanCuentas, "401111"));
                oPlanContable.Add(new PlanCuentasAD().ObtenerPlanCuentasPorCodigo(oDocumentoVenta.idEmpresa, numVerPlanCuentas, ctaBase));

                foreach (PlanCuentasE item in oPlanContable)
                {
                    #region Debe/Haber

                    if (item.codCuenta == ctaTotal)
                    {
                        if (oDocumentoVenta.idDocumento == "NC")
                        {
                            DebeHaber = Variables.Haber;
                        }
                        else
                        {
                            DebeHaber = Variables.Debe;
                        }
                    }

                    if (item.codCuenta == "401111")
                    {
                        if (oDocumentoVenta.idDocumento == "NC")
                        {
                            DebeHaber = Variables.Debe;
                        }
                        else
                        {
                            DebeHaber = Variables.Haber;
                        }
                    }

                    if (item.codCuenta == ctaBase)
                    {
                        if (oDocumentoVenta.idDocumento == "NC")
                        {
                            DebeHaber = Variables.Debe;
                        }
                        else
                        {
                            DebeHaber = Variables.Haber;
                        }
                    } 

                    #endregion

                    CCostos = item.indSolicitaCentroCosto == Variables.SI ? "1001" : String.Empty;
                    idPersona = item.indSolicitaAnexo == Variables.SI ? Auxiliar : (Nullable<Int32>)null;

                    #region Si Solicita Documento
                    
                    if (item.indSolicitaDcto == Variables.SI)
                    {
                        //fecEmisionTmp = fecEmisDocu; //Revisar
                        TipoDocuTmp = oDocumentoVenta.idDocumento;
                        SerieTmp = oDocumentoVenta.numSerie;
                        NumeroTmp = oDocumentoVenta.numDocumento;

                        fecRefeDocuTmp = fecRefeDocu;
                        tipRefeDocuTmp = tipRefeDocu;
                        SerieRefeDocuTmp = SerieRefeDocu;
                        numRefeDocuTmp = numRefeDocu;
                    }
                    else
                    {
                        //fecEmisionTmp = (Nullable<DateTime>)null;
                        TipoDocuTmp = null;
                        SerieTmp = null;
                        NumeroTmp = null;

                        fecRefeDocuTmp = (Nullable<DateTime>)null;
                        tipRefeDocuTmp = null;
                        SerieRefeDocuTmp = null;
                        numRefeDocuTmp = null;
                    } 

                    #endregion

                    ParTabla oParametro = new ParTablaAD().RecuperarParTablaPorId(Convert.ToInt32(item.codColumnaCoven));
                    TipoCuenta = oParametro.Descripcion;

                    if (TipoCuenta == "TOTAL")
                    {
                        ImporteDocumento = TotalDocu;

                    }

                    if (TipoCuenta == "IGV")
                    {

                    }

                    if (TipoCuenta.Substring(0, 4) == "BASE")
                    {

                    }
                }

                oVoucher = new VoucherE
                {
                    idEmpresa = oDocumentoVenta.idEmpresa,
                    idLocal = oDocumentoVenta.idLocal,
                    AnioPeriodo = AnioPeriodo,
                    MesPeriodo = MesPeriodo,
                    numVoucher = numVoucher,
                    idComprobante = idComprobante,
                    numFile = numFile,
                    idMoneda = MonedaVoucher,
                    //fecOperacion = fecEmisDocu, //Revisar
                    //fecDocumento = fecEmisDocu, // Revisar
                    impDebeSoles = impSoles,
                    impHaberSoles = impSoles,
                    impDebeDolares = impDolares,
                    impHaberDolares = impDolares,
                    GlosaGeneral = Glosa,
                    indEstado = "C",
                    tipCambio = TipoCambioDocu,
                    RazonSocial = RazonSocial,
                    sistema = "VEN",
                    numDocumentoPresu = numDocuPresu,
                    impMonOrigDeb = DebeOrigen,
                    impMonOrigHab = HaberOrigen,
                    UsuarioRegistro = oDocumentoVenta.UsuarioRegistro,
                    UsuarioModificacion = oDocumentoVenta.UsuarioModificacion
                };

                oVoucher.ListaVouchers = new List<VoucherItemE> 
                { 
                
                };
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

        public Int32 EliminarVoucherMasivo(List<VoucherE> oListaVouchers, String Usuario, String indEliminar = "S")
        {
            Int32 cantItems = 0;

            try
            {
                Int32 Resp = 0;

                TransactionOptions Opciones = new TransactionOptions
                {
                    Timeout = TimeSpan.FromMinutes(300)
                };

                using (TransactionScope oTrans = new TransactionScope(TransactionScopeOption.Required, Opciones))
                {
                    cantItems = Convert.ToInt32(oListaVouchers.Sum(x => x.numItems));

                    if (cantItems > 50)
                    {
                        new VoucherAD().TriggerVouchers(true); //Desabilita Trigger
                    }

                    foreach (VoucherE item in oListaVouchers)
                    {
                        if (indEliminar == "S")
                        {
                            Resp += new VoucherAD().EliminarVoucher(item.idEmpresa, item.idLocal, item.AnioPeriodo, item.MesPeriodo, item.numVoucher, item.idComprobante, item.numFile);
                        }
                        else
                        {
                            Resp += new VoucherAD().AnularVoucher(item.idEmpresa, item.idLocal, item.AnioPeriodo, item.MesPeriodo, item.numVoucher, item.idComprobante, item.numFile, Usuario, "A");
                        }
                    }

                    if (cantItems > 50)
                    {
                        new VoucherAD().TriggerVouchers(false); //Habilita Trigger
                    }

                    oTrans.Complete();
                }

                return Resp;
            }
            catch (SqlException ex)
            {
                SqlError err = ex.Errors[0];
                StringBuilder mensaje = new StringBuilder();

                if (cantItems > 50)
                {
                    new VoucherAD().TriggerVouchers(false); //Habilita Trigger
                }

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

        //public Int32 EliminarVoucherMasivoRapido(List<VoucherE> oListaVouchers, String Usuario )
        //{
        //    try
        //    {
        //        Int32 Resp = 0;
        //        TransactionOptions Opciones = new TransactionOptions
        //        {
        //            Timeout = TimeSpan.FromMinutes(300)
        //        };

        //        using (TransactionScope oTrans = new TransactionScope(TransactionScopeOption.Required, Opciones))
        //        {
        //            foreach (VoucherE item in oListaVouchers)
        //            {
        //                    new VoucherAD().TriggerVouchers(true); //Desabilita Trigger
        //                    Resp += new VoucherAD().EliminarVoucher(item.idEmpresa, item.idLocal, item.AnioPeriodo, item.MesPeriodo, item.numVoucher, item.idComprobante, item.numFile);
        //                    new VoucherAD().TriggerVouchers(false); //Habilita Trigger
                                          
        //            }

        //            oTrans.Complete();
        //        }

        //        return Resp;
        //    }
        //    catch (SqlException ex)
        //    {
        //        SqlError err = ex.Errors[0];
        //        StringBuilder mensaje = new StringBuilder();

        //        switch (err.Number)
        //        {
        //            default:
        //                mensaje.Append("Mensaje: " + err.Message + "\n");
        //                mensaje.Append("N° Linea: " + err.LineNumber + "\n");
        //                mensaje.Append("Origen: " + err.Source + "\n");
        //                mensaje.Append("Procedimiento: " + err.Procedure + "\n");
        //                mensaje.Append("N° Error: " + err.Number);
        //                break;
        //        }

        //        throw new Exception(mensaje.ToString());
        //    }
        //}

        public Int32 EliminarVoucherPorPeriodoyFechas(Int32 idEmpresa, Int32 idLocal, String AnioPeriodo, String MesPeriodo, String idComprobante, String numFile, DateTime fecIni, DateTime fecFin)
        {
            try
            {
                Int32 Resp = 0;
                TransactionOptions Opciones = new TransactionOptions();
                Opciones.Timeout = TimeSpan.FromMinutes(300);

                using (TransactionScope oTrans = new TransactionScope(TransactionScopeOption.Required, Opciones))
                {
                    new VoucherAD().TriggerVouchers(true); //Desabilita Trigger
                    Resp += new VoucherAD().EliminarVoucherPorPeriodoyFechas(idEmpresa,idLocal,AnioPeriodo,MesPeriodo,idComprobante,numFile,fecIni,fecFin);
                    new VoucherAD().TriggerVouchers(false); //Habilita Trigger
                    oTrans.Complete();
                }

                return Resp;
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

    }
}
