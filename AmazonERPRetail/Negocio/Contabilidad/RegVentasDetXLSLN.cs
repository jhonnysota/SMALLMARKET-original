using System;
using System.Text;
using System.Data.SqlClient;
using System.Transactions;
using System.Data;
using System.Collections.Generic;
using System.Linq;

using Entidades.Contabilidad;
using Entidades.Maestros;
using Entidades.Generales;
using AccesoDatos.Contabilidad;
using AccesoDatos.Maestros;
using AccesoDatos.Generales;
using Infraestructura;
using Infraestructura.Extensores;
using Infraestructura.Winform;
using Infraestructura.Enumerados;

namespace Negocio.Contabilidad
{
    public class RegVentasDetXLSLN
    {

        public Int32 InsertarRegVentasDetXLS(List<RegVentasDetXLSE> RegistroVentas)
        {
            try
            {
                Int32 FilasDevueltas = Variables.Cero;
                DateTime fecInicial; DateTime fecFinal;
                TransactionOptions Opciones = new TransactionOptions();
                Opciones.Timeout = TimeSpan.FromMinutes(240);

                using (TransactionScope oTrans = new TransactionScope(TransactionScopeOption.Required, Opciones))
                {
                    fecInicial = Convert.ToDateTime((from mx in RegistroVentas
                                                     select (DateTime?)mx.FechaTurno).Min());

                    fecFinal = Convert.ToDateTime((from mx in RegistroVentas
                                                     select (DateTime?)mx.FechaTurno).Max());

                    if (fecInicial.Month == fecFinal.Month)
                    {
                        PeriodosE oPeriodoContable = new PeriodosAD().ObtenerPeriodoPorMes(RegistroVentas[0].idEmpresa, fecInicial.ToString("yyyy"), fecFinal.ToString("MM"));
                        String MesContable = FechasHelper.NombreMes(fecInicial.Month);

                        if (oPeriodoContable.indCierre)
                        {
                            throw new Exception(String.Format("El Mes de {0} se encuentra cerrado. No podrá ingresar las ventas.", MesContable));
                        }
                    }
                    else
                    {
                        //Fecha de Inicio
                        PeriodosE oPeriodoContable = new PeriodosAD().ObtenerPeriodoPorMes(RegistroVentas[0].idEmpresa, fecInicial.ToString("yyyy"), fecInicial.ToString("MM"));
                        String MesContable = FechasHelper.NombreMes(fecInicial.Month);

                        if (oPeriodoContable.indCierre)
                        {
                            throw new Exception(String.Format("El Mes de {0} se encuentra cerrado. No podrá ingresar las ventas.", MesContable));
                        }
                        //Fecha Final
                        oPeriodoContable = new PeriodosAD().ObtenerPeriodoPorMes(RegistroVentas[0].idEmpresa, fecFinal.ToString("yyyy"), fecFinal.ToString("MM"));
                        MesContable = FechasHelper.NombreMes(fecFinal.Month);

                        if (oPeriodoContable.indCierre)
                        {
                            throw new Exception(String.Format("El Mes de {0} se encuentra cerrado. No podrá ingresar las ventas.", MesContable));
                        }
                    }

                    foreach (RegVentasDetXLSE item in RegistroVentas)
                    {
                        if (item.Ruc.Substring(0, 4) != "9999" && Global.Derecha(item.Ruc, 4) != "0000")
                        {
                            Persona oPersona = new PersonaAD().ObtenerPersonaPorNroRuc(item.Ruc);

                            if (oPersona != null)
                            {
                                item.idPersona = oPersona.IdPersona;
                            }
                            else
                            {
                                item.idPersona = null;
                            }
                        }

                        ArticuloServE oArticulo = new ArticuloServAD().ArticuloPorNombreCorto(item.idEmpresa, item.Producto);

                        if (oArticulo != null)
                        {
                            item.idArticulo = oArticulo.idArticulo;
                            item.idUmedida = oArticulo.codUniMedAlmacen;
                        }
                    }

                    //Insertando a la BD el resultado final de la lista
                    using (DataTable oDt = Colecciones.ToDataTable<RegVentasDetXLSE>(RegistroVentas))
                    {
                        FilasDevueltas = new RegVentasDetXLSAD().InsertarRegVentasDetXLS(oDt);
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

        public Int32 ErroresRegVentasDetXLS(Int32 idEmpresa, Int32 idLocal, Int32 idUsuario)
        {
            try
            {
                return new RegVentasDetXLSAD().ProcesarRegVentasDetXLS(idEmpresa, idLocal, idUsuario);
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

        public Int32 EliminarRegVentasDetXLS(Int32 idEmpresa, Int32 idLocal, Int32 idUsuario)
        {
            try
            {
                return new RegVentasDetXLSAD().EliminarRegVentasDetXLS(idEmpresa, idLocal, idUsuario);
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

        public Int32 IntegrarVentasDetXLS(List<RegVentasDetXLSE> ListaRegVentas, String Sistema, String Usuario)
        {
            try
            {
                Int32 resp = 0;

                using (TransactionScope oTrans = new TransactionScope())
                {
                    //foreach (RegVentasDetXLSE item in ListaRegVentas)
                    //{
                    //    if (item.Ruc.Substring(0, 4) != "9999")
                    //    {
                    //        Persona oPersona = new PersonaAD().ObtenerPersonaPorNroRuc(item.Ruc);
                    //        item.idPersona = oPersona.IdPersona;
                    //    }

                    //    ArticuloServE oArticulo = new ArticuloServAD().ArticuloPorNombreCorto(item.idEmpresa, item.Producto);

                    //    if (oArticulo != null)
                    //    {
                    //        item.idArticulo = oArticulo.idArticulo;
                    //        item.idTipoUmedida = oArticulo.codTipoMedAlmacen;
                    //        item.idUmedida = oArticulo.codUniMedAlmacen;
                    //    }
                    //    else
                    //    {
                    //        throw new Exception("El Producto no existe en el maestro de articulos.");
                    //    }

                    //    new RegVentasDetXLSAD().ActualizarRegVentasDetXLS(item);
                    //}

                    #region Eliminando el registro...

                    DateTime fecInicial; DateTime fecFinal;

                    fecInicial = Convert.ToDateTime((from mx in ListaRegVentas
                                                     where mx.FechaTurno != null
                                                     select (DateTime?)mx.FechaTurno).Min());

                    fecFinal = Convert.ToDateTime((from mx in ListaRegVentas
                                                   where mx.FechaTurno != null
                                                   select (DateTime?)mx.FechaTurno).Max());

                    new RegistroVentasDetAD().EliminarRegistroVentasDet(ListaRegVentas[0].idEmpresa, ListaRegVentas[0].idLocal, ListaRegVentas[0].idCCostos, Sistema, fecInicial, fecFinal);
                    
                    #endregion

                    resp = new RegVentasDetXLSAD().IntegrarRegVentasXLSDet(ListaRegVentas[0].idEmpresa, ListaRegVentas[0].idLocal, ListaRegVentas[0].idUsuario, Sistema, Usuario);

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

        public void GenerarVoucherVentasDet(Int32 idEmpresa, Int32 idLocal, String idCCostos, String Sistema, DateTime fecIni, DateTime fecFin, String Usuario, Int32? ClienteVarios)
        {
            try
            {
                List<RegistroVentasDetE> oListaGeneral = new RegistroVentasDetAD().ListarRegistroVentasDet(idEmpresa, idLocal, idCCostos, Sistema, fecIni, fecFin);

                if (oListaGeneral.Count > 0)
                {
                    using (TransactionScope oTrans = new TransactionScope())
                    {
                        VoucherE oVoucher = new VoucherE();
                        TipoCambioE oTica = new TipoCambioAD().ObtenerTipoCambioPorDia(Variables.Dolares, oListaGeneral[0].FechaTurno.ToString("yyyyMMdd"));
                        String CuentaIgv = new ImpuestosAD().ObtenerImpuestos(1).codCuenta;
                        String Cuenta12 = new ParametrosContaAD().ObtenerParametrosConta(idEmpresa).VentaS;
                        Decimal MontoTotal = Convert.ToDecimal(oListaGeneral.Sum(x => x.Total));
                        Decimal MontoIgv = Convert.ToDecimal(oListaGeneral.Sum(x => x.Igv));
                        Decimal MontoRecaudo = Convert.ToDecimal(oListaGeneral.Sum(x => x.Recaudo));
                        String CuentaItf = "9441211";
                        String CuentaRecaudo = "4699012";
                        Decimal Itf = Math.Round((MontoRecaudo * 0.0001M), 2);
                        MontoRecaudo = MontoRecaudo - Itf;

                        if (oTica == null)
                        {
                            throw new Exception(String.Format("La fecha {0} no tiene Tipo de Cambio.", oListaGeneral[0].FechaTurno.ToString("dd/MM/yyyy")));
                        }

                        List<RegistroVentasDetAgrupado> AgrupadoTotal = (from x in oListaGeneral
                                                                         where (x.numSerie != "FO04") && (x.idDocumento != "NC")
                                                                         group x by new { x.idEmpresa, x.idLocal, x.FechaTurno, x.idCCostos, x.AbrevCCostos, x.codCuentaVenta12 } into g
                                                                         select new RegistroVentasDetAgrupado()
                                                                         {
                                                                             idEmpresa = g.Key.idEmpresa,
                                                                             Sistema = Sistema,
                                                                             idCCostos = g.Key.idCCostos,
                                                                             AbrevCCostos = g.Key.AbrevCCostos,
                                                                             fecTurno = g.Key.FechaTurno,
                                                                             tipCuenta = "TOTAL",
                                                                             idPersona = ClienteVarios,
                                                                             idDocumento = "OT",
                                                                             numSerie = Sistema.Substring(0, 1) + g.Key.AbrevCCostos.Substring(0, 2),
                                                                             numDocumento = g.Key.FechaTurno.ToString("yyyyMMdd"),
                                                                             codCuentaVenta12 = g.Key.codCuentaVenta12,
                                                                             Monto = g.Sum(x => x.Total + x.Recaudo)
                                                                         }).ToList();

                        foreach (RegistroVentasDetE item in oListaGeneral)
                        {
                            if (item.numSerie == "FO04" || item.idDocumento == "NC")
                            {
                                RegistroVentasDetAgrupado oVenta = new RegistroVentasDetAgrupado()
                                {
                                    idEmpresa = item.idEmpresa,
                                    Sistema = Sistema,
                                    idCCostos = item.idCCostos,
                                    AbrevCCostos = item.AbrevCCostos,
                                    fecTurno = item.FechaTurno,
                                    tipCuenta = "TOTAL",
                                    idPersona = item.idPersona,
                                    idDocumento = item.idDocumento,
                                    numSerie = item.numSerie,
                                    numDocumento = item.numDocumentoIni,
                                    codCuentaVenta12 = item.codCuentaVenta12,
                                    Monto = Math.Abs(item.Total) + item.Recaudo,
                                    FechaRef = item.FechaRef,
                                    idDocumentoRef = item.idDocumentoRef,
                                    numSerieRef = item.numSerieRef,
                                    numDocumentoRef = item.numDocumentoRef
                                };

                                AgrupadoTotal.Add(oVenta);
                            }
                        }

                        List<RegistroVentasDetAgrupado> AgrupadoBI = (from x in oListaGeneral
                                                                      group x by new { x.idEmpresa, x.idLocal, x.FechaTurno, x.idCCostos, x.AbrevCCostos, x.codCuentaVenta } into g
                                                                      select new RegistroVentasDetAgrupado()
                                                                      {
                                                                          idEmpresa = g.Key.idEmpresa,
                                                                          Sistema = Sistema,
                                                                          idCCostos = g.Key.idCCostos,
                                                                          AbrevCCostos = g.Key.AbrevCCostos,
                                                                          fecTurno = g.Key.FechaTurno,
                                                                          tipCuenta = "VVENTA",
                                                                          idDocumento = "OT",
                                                                          codCuentaVenta = g.Key.codCuentaVenta,
                                                                          Monto = g.Sum(x => x.BaseImponible)
                                                                      }).ToList();

                        oVoucher.idEmpresa = idEmpresa;
                        oVoucher.idLocal = idLocal;
                        oVoucher.AnioPeriodo = oListaGeneral[0].FechaTurno.ToString("yyyy");
                        oVoucher.MesPeriodo = oListaGeneral[0].FechaTurno.ToString("MM");
                        oVoucher.numVoucher = "0";
                        oVoucher.idComprobante = "02";

                        if (Sistema == "GAS")
                        {
                            oVoucher.numFile = "01";
                            oVoucher.GlosaGeneral = oListaGeneral[0].AbrevCCostos.Substring(0, 2) + " VENTAS TRANS. GASOLUTIONS " +oListaGeneral[0].FechaTurno.ToString("dd-MM-yyy");
                        }
                        else
                        {
                            oVoucher.numFile = "05";
                            oVoucher.GlosaGeneral = oListaGeneral[0].AbrevCCostos.Substring(0, 2) + " VENTAS TRANS. FULLSTATION " +oListaGeneral[0].FechaTurno.ToString("dd-MM-yyy");
                        }

                        oVoucher.fecTransferencia = null;
                        oVoucher.numItems = 0;
                        oVoucher.idMoneda = Variables.Soles;
                        oVoucher.fecOperacion = oListaGeneral[0].FechaTurno.Date;
                        oVoucher.fecDocumento = oListaGeneral[0].FechaTurno.Date;
                        oVoucher.impDebeSoles = MontoTotal;
                        oVoucher.impHaberSoles = MontoTotal;
                        oVoucher.impDebeDolares = Decimal.Round((MontoTotal + MontoRecaudo + Itf) / oTica.valVenta, 2); 
                        oVoucher.impHaberDolares = Decimal.Round((MontoTotal + MontoRecaudo + Itf) / oTica.valVenta, 2); 
                        
                        oVoucher.indEstado = Variables.VoucherCuadrado;
                        oVoucher.tipCambio = oTica.valVenta;
                        oVoucher.RazonSocial = String.Empty;
                        oVoucher.numDocumentoPresu = "OT" + Sistema.Substring(0, 1) + oListaGeneral[0].AbrevCCostos.Substring(0, 2) +'-'+oListaGeneral[0].FechaTurno.ToString("yyyyMMdd");
                        oVoucher.indHojaCosto = "N";
                        oVoucher.numHojaCosto = String.Empty;
                        oVoucher.numOrdenCompra = String.Empty;
                        oVoucher.sistema = Sistema;
                        oVoucher.UsuarioRegistro = Usuario;

                        Int32 ItemDet = 1;
                        VoucherItemE ItemVoucher = new VoucherItemE();

                        #region Total

                        if (Sistema == "GAS")
                        {
                            ItemVoucher.numItem = String.Format("{0:00000}", ItemDet);
                            ItemVoucher.idPersona = ClienteVarios;
                            ItemVoucher.idMoneda = Variables.Soles;
                            ItemVoucher.tipCambio = oTica.valVenta;
                            ItemVoucher.indCambio = "S";
                            ItemVoucher.idCCostos = oListaGeneral[0].idCCostos;
                            ItemVoucher.numVerPlanCuentas = "002";
                            ItemVoucher.codCuenta = Cuenta12;
                            ItemVoucher.desGlosa = "VOUCHER AUTOMATICO";
                            ItemVoucher.fecDocumento = oListaGeneral[0].FechaTurno;
                            ItemVoucher.fecVencimiento = oListaGeneral[0].FechaTurno;
                            ItemVoucher.idDocumento = "OT";
                            ItemVoucher.serDocumento = Sistema.Substring(0,1) + oListaGeneral[0].AbrevCCostos.Substring(0,2);
                            ItemVoucher.numDocumento = oListaGeneral[0].FechaTurno.ToString("yyyyMMdd");
                            ItemVoucher.fecDocumentoRef = null;
                            ItemVoucher.idDocumentoRef = "";
                            ItemVoucher.serDocumentoRef = "";
                            ItemVoucher.numDocumentoRef = "";
                            ItemVoucher.indDebeHaber = Variables.Debe;
                            ItemVoucher.impSoles = (MontoTotal+MontoRecaudo+Itf);
                            ItemVoucher.impDolares = Decimal.Round((MontoTotal+MontoRecaudo+Itf) / oTica.valVenta, 2);
                            ItemVoucher.indAutomatica = "N";
                            ItemVoucher.CorrelativoAjuste = "";
                            ItemVoucher.codFteFin = "";
                            ItemVoucher.codProgramaCred = "";
                            ItemVoucher.indMovimientoAnterior = "N";
                            ItemVoucher.tipPartidaPresu = "";
                            ItemVoucher.codPartidaPresu = "";
                            ItemVoucher.numDocumentoPresu = "";
                            ItemVoucher.codColumnaCoven = 278001;
                            ItemVoucher.depAduanera = null;
                            ItemVoucher.nroDua = "";
                            ItemVoucher.AnioDua = "";
                            ItemVoucher.flagDetraccion = "N";
                            ItemVoucher.numDetraccion = "";
                            ItemVoucher.fecDetraccion = null;
                            ItemVoucher.tipDetraccion = "";
                            ItemVoucher.TasaDetraccion = 0;
                            ItemVoucher.MontoDetraccion = 0;
                            ItemVoucher.indReparable = "N";
                            ItemVoucher.idConceptoRep = null;
                            ItemVoucher.desReferenciaRep = "";
                            ItemVoucher.idAlmacen = "";
                            ItemVoucher.tipMovimientoAlmacen = "";
                            ItemVoucher.numDocumentoAlmacen = "";
                            ItemVoucher.numItemAlmacen = "";
                            ItemVoucher.CajaSucursal = "";
                            ItemVoucher.indCompra = "N";
                            ItemVoucher.indConciliado = "N";
                            ItemVoucher.fecRecepcion = null;
                            ItemVoucher.codMedioPago = 0;
                            ItemVoucher.idCampana = null;
                            ItemVoucher.idConceptoGasto = null;
                            ItemVoucher.UsuarioRegistro = Usuario;

                            oVoucher.ListaVouchers.Add(ItemVoucher);
                        }
                        else
                        {
                            ItemDet = 0;

                            foreach (RegistroVentasDetAgrupado item in AgrupadoTotal)
                            {
                                ItemDet++;

                                ItemVoucher = new VoucherItemE
                                {
                                    numItem = String.Format("{0:00000}", ItemDet),
                                    idPersona = item.idPersona,
                                    idMoneda = Variables.Soles,
                                    tipCambio = oTica.valVenta,
                                    indCambio = "S",
                                    idCCostos = item.idCCostos,
                                    numVerPlanCuentas = "002",
                                    codCuenta = item.codCuentaVenta12,
                                    desGlosa = "VOUCHER AUTOMATICO",
                                    fecDocumento = item.fecTurno,
                                    fecVencimiento = item.fecTurno,
                                    idDocumento = item.idDocumento,
                                    serDocumento = item.numSerie,
                                    numDocumento = item.numDocumento
                                };

                                if (item.idDocumento == "NC")
                                {
                                    ItemVoucher.fecDocumentoRef = item.FechaRef;
                                    ItemVoucher.idDocumentoRef = item.idDocumentoRef;
                                    ItemVoucher.serDocumentoRef = item.numSerieRef;
                                    ItemVoucher.numDocumentoRef = item.numDocumentoRef;
                                    ItemVoucher.indDebeHaber = Variables.Haber;
                                }
                                else
                                {
                                    ItemVoucher.fecDocumentoRef = null;
                                    ItemVoucher.idDocumentoRef = "";
                                    ItemVoucher.serDocumentoRef = "";
                                    ItemVoucher.numDocumentoRef = "";
                                    ItemVoucher.indDebeHaber = Variables.Debe;
                                }

                                ItemVoucher.impSoles = Math.Abs(item.Monto);
                                ItemVoucher.impDolares = Decimal.Round(Math.Abs(item.Monto) / oTica.valVenta, 2);
                                ItemVoucher.indAutomatica = "N";
                                ItemVoucher.CorrelativoAjuste = "";
                                ItemVoucher.codFteFin = "";
                                ItemVoucher.codProgramaCred = "";
                                ItemVoucher.indMovimientoAnterior = "N";
                                ItemVoucher.tipPartidaPresu = "";
                                ItemVoucher.codPartidaPresu = "";
                                ItemVoucher.numDocumentoPresu = "";
                                ItemVoucher.codColumnaCoven = 278001;
                                ItemVoucher.depAduanera = null;
                                ItemVoucher.nroDua = "";
                                ItemVoucher.AnioDua = "";
                                ItemVoucher.flagDetraccion = "N";
                                ItemVoucher.numDetraccion = "";
                                ItemVoucher.fecDetraccion = null;
                                ItemVoucher.tipDetraccion = "";
                                ItemVoucher.TasaDetraccion = 0;
                                ItemVoucher.MontoDetraccion = 0;
                                ItemVoucher.indReparable = "N";
                                ItemVoucher.idConceptoRep = null;
                                ItemVoucher.desReferenciaRep = "";
                                ItemVoucher.idAlmacen = "";
                                ItemVoucher.tipMovimientoAlmacen = "";
                                ItemVoucher.numDocumentoAlmacen = "";
                                ItemVoucher.numItemAlmacen = "";
                                ItemVoucher.CajaSucursal = "";
                                ItemVoucher.indCompra = "N";
                                ItemVoucher.indConciliado = "N";
                                ItemVoucher.fecRecepcion = null;
                                ItemVoucher.codMedioPago = 0;
                                ItemVoucher.idCampana = null;
                                ItemVoucher.idConceptoGasto = null;
                                ItemVoucher.UsuarioRegistro = Usuario;

                                oVoucher.ListaVouchers.Add(ItemVoucher);
                            }
                        }

                        #endregion

                        #region IGV

                        ItemDet++;
                        ItemVoucher = new VoucherItemE
                        {
                            numItem = String.Format("{0:00000}", ItemDet),
                            idPersona = null,
                            idMoneda = Variables.Soles,
                            tipCambio = oTica.valVenta,
                            indCambio = "S",
                            idCCostos = oListaGeneral[0].idCCostos,
                            numVerPlanCuentas = "002",
                            codCuenta = CuentaIgv,
                            desGlosa = "VOUCHER AUTOMATICO",
                            fecDocumento = oListaGeneral[0].FechaTurno,
                            fecVencimiento = oListaGeneral[0].FechaTurno,
                            idDocumento = "OT",
                            serDocumento = Sistema.Substring(0, 1) + oListaGeneral[0].AbrevCCostos.Substring(0, 2),
                            numDocumento = oListaGeneral[0].FechaTurno.ToString("yyyyMMdd"),
                            fecDocumentoRef = null,
                            idDocumentoRef = "",
                            serDocumentoRef = "",
                            numDocumentoRef = "",
                            indDebeHaber = Variables.Haber,
                            impSoles = MontoIgv,
                            impDolares = Decimal.Round(MontoIgv / oTica.valVenta, 2),
                            indAutomatica = "N",
                            CorrelativoAjuste = "",
                            codFteFin = "",
                            codProgramaCred = "",
                            indMovimientoAnterior = "N",
                            tipPartidaPresu = "",
                            codPartidaPresu = "",
                            numDocumentoPresu = "",
                            codColumnaCoven = 277001,
                            depAduanera = null,
                            nroDua = "",
                            AnioDua = "",
                            flagDetraccion = "N",
                            numDetraccion = "",
                            fecDetraccion = null,
                            tipDetraccion = "",
                            TasaDetraccion = 0,
                            MontoDetraccion = 0,
                            indReparable = "N",
                            idConceptoRep = null,
                            desReferenciaRep = "",
                            idAlmacen = "",
                            tipMovimientoAlmacen = "",
                            numDocumentoAlmacen = "",
                            numItemAlmacen = "",
                            CajaSucursal = "",
                            indCompra = "N",
                            indConciliado = "N",
                            fecRecepcion = null,
                            codMedioPago = 0,
                            idCampana = null,
                            idConceptoGasto = null,
                            UsuarioRegistro = Usuario
                        };

                        //Agregando el IGV
                        oVoucher.ListaVouchers.Add(ItemVoucher);

                        #endregion

                        #region Base Imponible

                        foreach (RegistroVentasDetAgrupado item in AgrupadoBI)
                        {
                            ItemDet++;
                            ItemVoucher = new VoucherItemE
                            {
                                numItem = String.Format("{0:00000}", ItemDet),
                                idPersona = null,
                                idMoneda = Variables.Soles,
                                tipCambio = oTica.valVenta,
                                indCambio = "S",
                                idCCostos = item.idCCostos,
                                numVerPlanCuentas = "002",
                                codCuenta = item.codCuentaVenta,
                                desGlosa = "VOUCHER AUTOMATICO",
                                fecDocumento = item.fecTurno,
                                fecVencimiento = item.fecTurno,
                                idDocumento = "OT",
                                serDocumento = Sistema.Substring(0, 1) + item.AbrevCCostos.Substring(0, 2),
                                numDocumento = item.fecTurno.ToString("yyyyMMdd"),
                                fecDocumentoRef = null,
                                idDocumentoRef = "",
                                serDocumentoRef = "",
                                numDocumentoRef = "",
                                indDebeHaber = Variables.Haber,
                                impSoles = item.Monto,
                                impDolares = Decimal.Round(item.Monto / oTica.valVenta, 2),
                                indAutomatica = "N",
                                CorrelativoAjuste = "",
                                codFteFin = "",
                                codProgramaCred = "",
                                indMovimientoAnterior = "N",
                                tipPartidaPresu = "",
                                codPartidaPresu = "",
                                numDocumentoPresu = "",
                                codColumnaCoven = 276001,
                                depAduanera = null,
                                nroDua = "",
                                AnioDua = "",
                                flagDetraccion = "N",
                                numDetraccion = "",
                                fecDetraccion = null,
                                tipDetraccion = "",
                                TasaDetraccion = 0,
                                MontoDetraccion = 0,
                                indReparable = "N",
                                idConceptoRep = null,
                                desReferenciaRep = "",
                                idAlmacen = "",
                                tipMovimientoAlmacen = "",
                                numDocumentoAlmacen = "",
                                numItemAlmacen = "",
                                CajaSucursal = "",
                                indCompra = "N",
                                indConciliado = "N",
                                fecRecepcion = null,
                                codMedioPago = 0,
                                idCampana = null,
                                idConceptoGasto = null,
                                UsuarioRegistro = Usuario
                            };

                            oVoucher.ListaVouchers.Add(ItemVoucher);
                        }

                        #endregion

                        #region Recaudo

                        if (MontoRecaudo != 0)
                        {
                            //Para ASSA - CORPORACION FINANCIERA DE DESARROLLO S.A.
                            Persona Auxiliar = new PersonaAD().ObtenerPersonaPorNroRuc("20100116392");

                            ItemDet++;
                            ItemVoucher = new VoucherItemE
                            {
                                numItem = String.Format("{0:00000}", ItemDet),
                                idPersona = Auxiliar != null ? Auxiliar.IdPersona : (Int32?)null,
                                idMoneda = Variables.Soles,
                                tipCambio = oTica.valVenta,
                                indCambio = "S",
                                idCCostos = oListaGeneral[0].idCCostos,
                                numVerPlanCuentas = "002",
                                codCuenta = CuentaRecaudo,
                                desGlosa = "VOUCHER AUTOMATICO",
                                fecDocumento = oListaGeneral[0].FechaTurno,
                                fecVencimiento = oListaGeneral[0].FechaTurno,
                                idDocumento = "OT",
                                serDocumento = Sistema.Substring(0, 1) + oListaGeneral[0].AbrevCCostos.Substring(0, 2),
                                numDocumento = oListaGeneral[0].FechaTurno.ToString("yyyyMMdd"),
                                fecDocumentoRef = null,
                                idDocumentoRef = "",
                                serDocumentoRef = "",
                                numDocumentoRef = "",
                                indDebeHaber = Variables.Haber,
                                impSoles = MontoRecaudo,
                                impDolares = Decimal.Round(MontoRecaudo / oTica.valVenta, 2),
                                indAutomatica = "N",
                                CorrelativoAjuste = "",
                                codFteFin = "",
                                codProgramaCred = "",
                                indMovimientoAnterior = "N",
                                tipPartidaPresu = "",
                                codPartidaPresu = "",
                                numDocumentoPresu = "",
                                codColumnaCoven = 277001,
                                depAduanera = null,
                                nroDua = "",
                                AnioDua = "",
                                flagDetraccion = "N",
                                numDetraccion = "",
                                fecDetraccion = null,
                                tipDetraccion = "",
                                TasaDetraccion = 0,
                                MontoDetraccion = 0,
                                indReparable = "N",
                                idConceptoRep = null,
                                desReferenciaRep = "",
                                idAlmacen = "",
                                tipMovimientoAlmacen = "",
                                numDocumentoAlmacen = "",
                                numItemAlmacen = "",
                                CajaSucursal = "",
                                indCompra = "N",
                                indConciliado = "N",
                                fecRecepcion = null,
                                codMedioPago = 0,
                                idCampana = null,
                                idConceptoGasto = null,
                                UsuarioRegistro = Usuario
                            };

                            //Agregando el Recaudo
                            oVoucher.ListaVouchers.Add(ItemVoucher);
                        }

                        #endregion

                        #region Itf

                        if (Itf != 0)
                        {
                            ItemDet++;
                            ItemVoucher = new VoucherItemE
                            {
                                numItem = String.Format("{0:00000}", ItemDet),
                                idPersona = null,
                                idMoneda = Variables.Soles,
                                tipCambio = oTica.valVenta,
                                indCambio = "S",
                                idCCostos = oListaGeneral[0].idCCostos,
                                numVerPlanCuentas = "002",
                                codCuenta = CuentaItf,
                                desGlosa = "VOUCHER AUTOMATICO",
                                fecDocumento = oListaGeneral[0].FechaTurno,
                                fecVencimiento = oListaGeneral[0].FechaTurno,
                                idDocumento = "OT",
                                serDocumento = Sistema.Substring(0, 1) + oListaGeneral[0].AbrevCCostos.Substring(0, 2),
                                numDocumento = oListaGeneral[0].FechaTurno.ToString("yyyyMMdd"),
                                fecDocumentoRef = null,
                                idDocumentoRef = "",
                                serDocumentoRef = "",
                                numDocumentoRef = "",
                                indDebeHaber = Variables.Haber,
                                impSoles = Itf,
                                impDolares = Decimal.Round(Itf / oTica.valVenta, 2),
                                indAutomatica = "N",
                                CorrelativoAjuste = "",
                                codFteFin = "",
                                codProgramaCred = "",
                                indMovimientoAnterior = "N",
                                tipPartidaPresu = "",
                                codPartidaPresu = "",
                                numDocumentoPresu = "",
                                codColumnaCoven = 277001,
                                depAduanera = null,
                                nroDua = "",
                                AnioDua = "",
                                flagDetraccion = "N",
                                numDetraccion = "",
                                fecDetraccion = null,
                                tipDetraccion = "",
                                TasaDetraccion = 0,
                                MontoDetraccion = 0,
                                indReparable = "N",
                                idConceptoRep = null,
                                desReferenciaRep = "",
                                idAlmacen = "",
                                tipMovimientoAlmacen = "",
                                numDocumentoAlmacen = "",
                                numItemAlmacen = "",
                                CajaSucursal = "",
                                indCompra = "N",
                                indConciliado = "N",
                                fecRecepcion = null,
                                codMedioPago = 0,
                                idCampana = null,
                                idConceptoGasto = null,
                                UsuarioRegistro = Usuario
                            };

                            //Agregando el Itf.
                            oVoucher.ListaVouchers.Add(ItemVoucher);

                            #region Agregando Destino

                            ItemDet++;
                            ItemVoucher = new VoucherItemE
                            {
                                numItem = String.Format("{0:00000}", ItemDet),
                                idPersona = null,
                                idMoneda = Variables.Soles,
                                tipCambio = oTica.valVenta,
                                indCambio = "S",
                                idCCostos = oListaGeneral[0].idCCostos,
                                numVerPlanCuentas = "002",
                                codCuenta = "6412011",
                                desGlosa = "VOUCHER AUTOMATICO",
                                fecDocumento = oListaGeneral[0].FechaTurno,
                                fecVencimiento = oListaGeneral[0].FechaTurno,
                                idDocumento = "OT",
                                serDocumento = Sistema.Substring(0, 1) + oListaGeneral[0].AbrevCCostos.Substring(0, 2),
                                numDocumento = oListaGeneral[0].FechaTurno.ToString("yyyyMMdd"),
                                fecDocumentoRef = null,
                                idDocumentoRef = "",
                                serDocumentoRef = "",
                                numDocumentoRef = "",
                                indDebeHaber = Variables.Haber,
                                impSoles = Itf,
                                impDolares = Decimal.Round(Itf / oTica.valVenta, 2),
                                indAutomatica = "S",
                                CorrelativoAjuste = "",
                                codFteFin = "",
                                codProgramaCred = "",
                                indMovimientoAnterior = "N",
                                tipPartidaPresu = "",
                                codPartidaPresu = "",
                                numDocumentoPresu = "",
                                codColumnaCoven = 277001,
                                depAduanera = null,
                                nroDua = "",
                                AnioDua = "",
                                flagDetraccion = "N",
                                numDetraccion = "",
                                fecDetraccion = null,
                                tipDetraccion = "",
                                TasaDetraccion = 0,
                                MontoDetraccion = 0,
                                indReparable = "N",
                                idConceptoRep = null,
                                desReferenciaRep = "",
                                idAlmacen = "",
                                tipMovimientoAlmacen = "",
                                numDocumentoAlmacen = "",
                                numItemAlmacen = "",
                                CajaSucursal = "",
                                indCompra = "N",
                                indConciliado = "N",
                                fecRecepcion = null,
                                codMedioPago = 0,
                                idCampana = null,
                                idConceptoGasto = null,
                                UsuarioRegistro = Usuario
                            };

                            oVoucher.ListaVouchers.Add(ItemVoucher);

                            ItemDet++;
                            ItemVoucher = new VoucherItemE
                            {
                                numItem = String.Format("{0:00000}", ItemDet),
                                idPersona = null,
                                idMoneda = Variables.Soles,
                                tipCambio = oTica.valVenta,
                                indCambio = "S",
                                idCCostos = oListaGeneral[0].idCCostos,
                                numVerPlanCuentas = "002",
                                codCuenta = "7910011",
                                desGlosa = "VOUCHER AUTOMATICO",
                                fecDocumento = oListaGeneral[0].FechaTurno,
                                fecVencimiento = oListaGeneral[0].FechaTurno,
                                idDocumento = "OT",
                                serDocumento = Sistema.Substring(0, 1) + oListaGeneral[0].AbrevCCostos.Substring(0, 2),
                                numDocumento = oListaGeneral[0].FechaTurno.ToString("yyyyMMdd"),
                                fecDocumentoRef = null,
                                idDocumentoRef = "",
                                serDocumentoRef = "",
                                numDocumentoRef = "",
                                indDebeHaber = Variables.Debe,
                                impSoles = Itf,
                                impDolares = Decimal.Round(Itf / oTica.valVenta, 2),
                                indAutomatica = "S",
                                CorrelativoAjuste = "",
                                codFteFin = "",
                                codProgramaCred = "",
                                indMovimientoAnterior = "N",
                                tipPartidaPresu = "",
                                codPartidaPresu = "",
                                numDocumentoPresu = "",
                                codColumnaCoven = 277001,
                                depAduanera = null,
                                nroDua = "",
                                AnioDua = "",
                                flagDetraccion = "N",
                                numDetraccion = "",
                                fecDetraccion = null,
                                tipDetraccion = "",
                                TasaDetraccion = 0,
                                MontoDetraccion = 0,
                                indReparable = "N",
                                idConceptoRep = null,
                                desReferenciaRep = "",
                                idAlmacen = "",
                                tipMovimientoAlmacen = "",
                                numDocumentoAlmacen = "",
                                numItemAlmacen = "",
                                CajaSucursal = "",
                                indCompra = "N",
                                indConciliado = "N",
                                fecRecepcion = null,
                                codMedioPago = 0,
                                idCampana = null,
                                idConceptoGasto = null,
                                UsuarioRegistro = Usuario
                            };

                            oVoucher.ListaVouchers.Add(ItemVoucher); 

                            #endregion
                        }

                        #endregion
                   
                        oVoucher = new VoucherLN().GrabarVouchers(oVoucher, EnumOpcionGrabar.Insertar);

                        oTrans.Complete();
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

    }
}
