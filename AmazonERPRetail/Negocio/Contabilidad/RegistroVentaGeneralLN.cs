using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Transactions;
using System.Linq;

using Entidades.Contabilidad;
using Entidades.Maestros;
using Entidades.Generales;
using AccesoDatos.Generales;
using AccesoDatos.Contabilidad;
using AccesoDatos.Maestros;
using Infraestructura;
using Infraestructura.Extensores;
using Infraestructura.Enumerados;

namespace Negocio.Contabilidad
{
    public class RegistroVentaGeneralLN
    {

        public Int32 ProcesarVentaGeneralMasivo(List<RegistroVentaGeneralE> oListaTienda)
        {            
            try
            { 
                Int32 FilasDevueltas = Variables.Cero;
                 
                TransactionOptions Opciones = new TransactionOptions();
                Opciones.Timeout = TimeSpan.FromMinutes(50);
                 
                using (TransactionScope oTrans = new TransactionScope(TransactionScopeOption.Required, Opciones))
                {
                    DataTable oDt = Colecciones.ToDataTable<RegistroVentaGeneralE>(oListaTienda);
                    
                    //Insertando a la BD el resultado final de la lista
                    FilasDevueltas = new RegistroVentaGeneralAD().InsertarVentaGeneralMasivo(oListaTienda[0].idEmpresa, oDt);

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

        public Boolean GenerarVoucherVentasGeneral(List<RegistroVentaGeneralE> oListaVentas)
        {
            try
            {
                Boolean ValorDevuelto = false;

                if (oListaVentas.Count > 0)
                {
                    TransactionOptions Opciones = new TransactionOptions();
                    Opciones.Timeout = TimeSpan.FromMinutes(50);

                    using (TransactionScope oTrans = new TransactionScope(TransactionScopeOption.Required, Opciones))
                    {
                        new VoucherAD().TriggerVouchers(true); //Desabilita Trigger

                        VoucherE oVoucher = null; // new VoucherE();
                        VoucherItemE ItemVoucher = null;
                        
                        ParametrosContaE oParametros = new ParametrosContaAD().ObtenerParametrosConta(oListaVentas[0].idEmpresa);
                        List<ParTabla> BasesImponibles = new ParTablaAD().ListarParTablaPorNemo("TIPBA");
                        ParTabla oBaseImponible = null;
                        ParTabla parTotal = new ParTablaAD().ParTablaPorNemo("TOTOT");
                        ParTabla parIgv = new ParTablaAD().ParTablaPorNemo("IGV");
                        PlanCuentasE oPlanCuentas = null;
                        String CuentaIgv = new ImpuestosAD().ObtenerImpuestos(1).codCuenta;
                        String Cuenta12 = String.Empty;
                        String RazonSocial = String.Empty;
                        String TipoDocumento = String.Empty;
                        String TipoDocumentoRef = String.Empty;
                        String Glosa = "VOUCHER AUTOMATICO";
                        String VersionPlanCuentas = String.Empty;
                        String indDebeHaber = String.Empty;
                        String Estado = String.Empty;
                        String idDoc = String.Empty; String Serie = String.Empty; String NumeroDoc = String.Empty;
                        DateTime? fecDoc = null;
                        DateTime? fecVenc = null;
                        Decimal MontoSoles = 0;
                        Decimal MontoDolares = 0;
                        Int32 ItemDet = 1;
                        Int32? idPersona = null;
                        PlanCuentasE oPlanCuentas12Soles = null;
                        PlanCuentasE oPlanCuentas12Dolar = null;
                        PlanCuentasE oPlanCuentasIgv = null;
                        VersionPlanCuentas = oParametros.numVerPlanCuentas;

                        oPlanCuentas12Soles = new PlanCuentasAD().ObtenerPlanCuentasPorCodigo(oListaVentas[0].idEmpresa, VersionPlanCuentas, oParametros.VentaS);
                        if (oPlanCuentas12Soles == null)
                         {
                            throw new Exception(String.Format("La cuenta 12 {0} ingresada en Parametros de Contabilidad - Cuentas, no existe.", oParametros.VentaS));
                         }

                        oPlanCuentas12Dolar = new PlanCuentasAD().ObtenerPlanCuentasPorCodigo(oListaVentas[0].idEmpresa, VersionPlanCuentas, oParametros.VentaD);
                        if (oPlanCuentas12Dolar == null)
                         {
                            throw new Exception(String.Format("La cuenta 12 {0} ingresada en Parametros de Contabilidad - Cuentas, no existe.", oParametros.VentaD));
                         }

                        oPlanCuentasIgv = new PlanCuentasAD().ObtenerPlanCuentasPorCodigo(oListaVentas[0].idEmpresa, VersionPlanCuentas, CuentaIgv);
                        if (oPlanCuentasIgv == null)
                         {
                            throw new Exception(String.Format("La cuenta IGV {0} No Existe de Contabilidad - Cuentas, no existe.", CuentaIgv));
                         }

                        if (oParametros == null)
                        {
                            throw new Exception("Falta configurar los parámetros de contabilidad.");
                        }

                        foreach (RegistroVentaGeneralE item in oListaVentas)
                        {
                            Estado = item.Estado;

                            if (Estado == "ANUL")
                            {
                                Glosa = "ANULADO";
                                Estado = "A";
                            }
                            else
                            {
                                Glosa = "VOUCHER AUTOMATICO";
                                Estado = "C";
                            }

                            #region Cabecera del Voucher

                            if (item.Moneda == Variables.Soles)
                            {
                                Cuenta12 = oParametros.VentaS;
                                oPlanCuentas = oPlanCuentas12Soles;
                                MontoSoles = item.ImporteTotal;
                                MontoDolares = item.ImporteTotal / item.TipoCambio;
                            }
                            else
                            {
                                Cuenta12 = oParametros.VentaD;
                                oPlanCuentas = oPlanCuentas12Dolar;
                                MontoSoles = item.ImporteTotal * item.TipoCambio;
                                MontoDolares = item.ImporteTotal;
                            }

                            if (String.IsNullOrWhiteSpace(Cuenta12))
                            {
                                throw new Exception("Falta configurar la cuenta de ventas en los parámetros de contabilidad.");
                            }

                           
                            if (item.idDocumento == "01" || item.idDocumento == "1")
                            {
                                TipoDocumento = "FV";
                            }

                            if (item.idDocumento == "03" || item.idDocumento == "3")
                            {
                                TipoDocumento = "BV";
                            }

                            if (item.idDocumento == "07" || item.idDocumento == "7")
                            {
                                TipoDocumento = "NC";
                            }

                            if (item.idDocumento == "08" || item.idDocumento == "8")
                            {
                                TipoDocumento = "ND";
                            }

                            if (item.idDocumento == "12")
                            {
                                TipoDocumento = "TK";
                            }




                            if (item.idDocumentoRef == "01" || item.idDocumentoRef == "1")
                            {
                                TipoDocumentoRef = "FV";
                            }

                            if (item.idDocumentoRef == "03" || item.idDocumentoRef == "3")
                            {
                                TipoDocumentoRef = "BV";
                            }

                            if (item.idDocumentoRef == "07" || item.idDocumentoRef == "7")
                            {
                                TipoDocumentoRef = "NC";
                            }

                            if (item.idDocumentoRef == "08" || item.idDocumentoRef == "8")
                            {
                                TipoDocumentoRef = "ND";
                            }

                            if (item.idDocumentoRef == "12")
                            {
                                TipoDocumentoRef = "TK";
                            }

                            Persona oPersona = new PersonaAD().ObtenerPersonaPorNroRuc(item.NumeroDocIdentidad);

                            oVoucher = new VoucherE();
                            oVoucher.idEmpresa = item.idEmpresa;
                            oVoucher.idLocal = item.idLocal;
                            oVoucher.AnioPeriodo = item.fecOperacion.ToString("yyyy");
                            oVoucher.MesPeriodo = item.fecOperacion.ToString("MM");
                            oVoucher.numVoucher = item.numCorrelativo;// String.Format("{0:000000000}", Convert.ToInt32(item.numCorrelativo));
                            oVoucher.idComprobante = item.idComprobante;// String.Format("{0:00}", Convert.ToInt32(item.idComprobante));
                            oVoucher.numFile = item.numFile;// String.Format("{0:00}", Convert.ToInt32(item.numFile));
                            oVoucher.fecTransferencia = null;
                            oVoucher.numItems = 0; //-
                            oVoucher.idMoneda = item.Moneda;
                            oVoucher.fecOperacion = item.fecOperacion;
                            oVoucher.fecDocumento = item.fecDocumento;
                            oVoucher.impDebeSoles = 0; //-
                            oVoucher.impHaberSoles = 0; //-
                            oVoucher.impDebeDolares = 0; //-
                            oVoucher.impHaberDolares = 0; //-
                            oVoucher.impMonOrigDeb = 0; //-
                            oVoucher.impMonOrigHab = 0; //-
                            oVoucher.GlosaGeneral = Glosa;
                            oVoucher.indEstado = Estado;
                            oVoucher.tipCambio = item.TipoCambio;
                            oVoucher.RazonSocial = oPersona.RazonSocial;
                            oVoucher.numDocumentoPresu = TipoDocumento + ' ' + item.SerieDocumento + "-" + item.NumeroDocumento;
                            oVoucher.indHojaCosto = "N";
                            oVoucher.numHojaCosto = String.Empty;
                            oVoucher.numOrdenCompra = String.Empty;
                            oVoucher.sistema = "2";
                            oVoucher.EsAutomatico = false;
                            oVoucher.UsuarioRegistro = item.UsuarioRegistro;

                            #endregion

                            ///DETALLE DEL VOUCHER
                            #region Total

                            ItemVoucher = new VoucherItemE();
                            
                            if (oPlanCuentas.indSolicitaAnexo == "S")
                             {
                               idPersona = oPersona.IdPersona; 
                             }
                            else
                             {
                               idPersona = null;
                             }

                            if (oPlanCuentas.indSolicitaDcto == "S")
                             {
                                idDoc = TipoDocumento;
                                Serie = item.SerieDocumento;
                                NumeroDoc = item.NumeroDocumento;
                                fecDoc = item.fecDocumento;
                                fecVenc = item.fecVencimiento;
                             }
                            else
                             {
                               idDoc = String.Empty;
                               Serie = String.Empty;
                               NumeroDoc = String.Empty;
                               fecDoc = null;
                               fecVenc = null;
                             }
                            

                            if (TipoDocumento == "NC")
                            {
                              indDebeHaber = Variables.Haber;
                            }
                            else
                            {
                              indDebeHaber = Variables.Debe;
                            }

                            ItemVoucher.numItem = String.Format("{0:00000}", ItemDet);
                            ItemVoucher.idPersona = idPersona;
                            ItemVoucher.idMoneda = item.Moneda;
                            ItemVoucher.tipCambio = item.TipoCambio;
                            ItemVoucher.indCambio = "S";
                            ItemVoucher.idCCostos = item.CentroCostos;
                            ItemVoucher.numVerPlanCuentas = VersionPlanCuentas;
                            ItemVoucher.codCuenta = Cuenta12;
                            ItemVoucher.desGlosa = Glosa;
                            ItemVoucher.fecDocumento = fecDoc;
                            ItemVoucher.fecVencimiento = fecVenc;

                            ItemVoucher.idDocumento = idDoc;

                            ItemVoucher.serDocumento = Serie;
                            ItemVoucher.numDocumento = NumeroDoc;

                            if (TipoDocumento == "NC")
                            {
                                ItemVoucher.fecDocumentoRef = item.FechaRef;
                                ItemVoucher.idDocumentoRef = TipoDocumentoRef;
                                ItemVoucher.serDocumentoRef = item.serDocumentoRef;
                                ItemVoucher.numDocumentoRef = item.numDocumentoRef;
                            }
                            else
                            {
                                ItemVoucher.fecDocumentoRef = null;
                                ItemVoucher.idDocumentoRef = "";
                                ItemVoucher.serDocumentoRef = "";
                                ItemVoucher.numDocumentoRef = "";
                            }

                            ItemVoucher.indDebeHaber = indDebeHaber;
                            ItemVoucher.impSoles = Math.Abs(MontoSoles);
                            ItemVoucher.impDolares = Math.Abs(MontoDolares);
                            ItemVoucher.indAutomatica = "N";
                            ItemVoucher.CorrelativoAjuste = "";
                            ItemVoucher.codFteFin = "";
                            ItemVoucher.codProgramaCred = "";
                            ItemVoucher.indMovimientoAnterior = "N";
                            ItemVoucher.tipPartidaPresu = "";
                            ItemVoucher.codPartidaPresu = "";
                            ItemVoucher.numDocumentoPresu = "";
                            ItemVoucher.codColumnaCoven = parTotal.IdParTabla;
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
                            ItemVoucher.UsuarioRegistro = item.UsuarioRegistro;

                            //Añadiendo el total
                            oVoucher.ListaVouchers.Add(ItemVoucher);

                            #endregion

                            //IGV
                            #region Igv

                            if (Math.Abs(item.IGV) > 0)
                            {
                                ItemDet++;

                                if (item.Moneda == Variables.Soles)
                                {
                                    MontoSoles = item.IGV;
                                    MontoDolares = item.IGV / item.TipoCambio;
                                }
                                else
                                {
                                    MontoSoles = item.IGV * item.TipoCambio;
                                    MontoDolares = item.IGV;
                                }

                                ItemVoucher = new VoucherItemE();
                                                            
                               if (oPlanCuentasIgv.indSolicitaAnexo == "S")
                                {
                                    idPersona = oPersona.IdPersona;
                                }
                               else
                                {
                                    idPersona = null;
                                }

                               if (oPlanCuentasIgv.indSolicitaDcto == "S")
                                {
                                    idDoc = TipoDocumento;
                                    Serie = item.SerieDocumento;
                                    NumeroDoc = item.NumeroDocumento;
                                    fecDoc = item.fecDocumento;
                                    fecVenc = item.fecVencimiento;
                                }
                               else
                                {
                                    idDoc = String.Empty;
                                    Serie = String.Empty;
                                    NumeroDoc = String.Empty;
                                    fecDoc = null;
                                    fecVenc = null;
                                }
                           

                                if (TipoDocumento == "NC")
                                {
                                    indDebeHaber = Variables.Debe;
                                }
                                else
                                {
                                    indDebeHaber = Variables.Haber;
                                }

                                ItemVoucher.numItem = String.Format("{0:00000}", ItemDet);
                                ItemVoucher.idPersona = idPersona;
                                ItemVoucher.idMoneda = item.Moneda;
                                ItemVoucher.tipCambio = item.TipoCambio;
                                ItemVoucher.indCambio = "S";
                                ItemVoucher.idCCostos = item.CentroCostos;
                                ItemVoucher.numVerPlanCuentas = VersionPlanCuentas;
                                ItemVoucher.codCuenta = CuentaIgv;
                                ItemVoucher.desGlosa = Glosa;
                                ItemVoucher.fecDocumento = fecDoc;
                                ItemVoucher.fecVencimiento = fecVenc;
                                ItemVoucher.idDocumento = idDoc;
                                ItemVoucher.serDocumento = Serie;
                                ItemVoucher.numDocumento = NumeroDoc;

                                if (TipoDocumento == "NC")
                                {
                                    ItemVoucher.fecDocumentoRef = item.FechaRef;
                                    ItemVoucher.idDocumentoRef = TipoDocumentoRef;
                                    ItemVoucher.serDocumentoRef = item.serDocumentoRef;
                                    ItemVoucher.numDocumentoRef = item.numDocumentoRef;
                                }
                                else
                                {
                                    ItemVoucher.fecDocumentoRef = null;
                                    ItemVoucher.idDocumentoRef = "";
                                    ItemVoucher.serDocumentoRef = "";
                                    ItemVoucher.numDocumentoRef = "";
                                }


                                ItemVoucher.indDebeHaber = indDebeHaber;
                                ItemVoucher.impSoles = Math.Abs(MontoSoles);
                                ItemVoucher.impDolares = Math.Abs(MontoDolares);
                                ItemVoucher.indAutomatica = "N";
                                ItemVoucher.CorrelativoAjuste = "";
                                ItemVoucher.codFteFin = "";
                                ItemVoucher.codProgramaCred = "";
                                ItemVoucher.indMovimientoAnterior = "N";
                                ItemVoucher.tipPartidaPresu = "";
                                ItemVoucher.codPartidaPresu = "";
                                ItemVoucher.numDocumentoPresu = "";
                                ItemVoucher.codColumnaCoven = parIgv.IdParTabla;
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
                                ItemVoucher.UsuarioRegistro = item.UsuarioRegistro;

                                //Añadiendo el IGV
                                oVoucher.ListaVouchers.Add(ItemVoucher);
                            }

                            #endregion

                            //Bases imponibles
                            #region base Imponible
                            idPersona = oPersona.IdPersona;
                            idDoc = TipoDocumento;
                            Serie = item.SerieDocumento;
                            NumeroDoc = item.NumeroDocumento;
                            fecDoc = item.fecDocumento;
                            fecVenc = item.fecVencimiento;
                              
                            if (TipoDocumento == "NC")
                            {
                                indDebeHaber = Variables.Debe;
                            }
                            else
                            {
                                indDebeHaber = Variables.Haber;
                            }

                            if (Math.Abs(item.BaseImponibleExportacion) > 0)
                            {
                                ItemDet++;

                                if (item.Moneda == Variables.Soles)
                                {
                                    MontoSoles = item.BaseImponibleExportacion;
                                    MontoDolares = item.BaseImponibleExportacion / item.TipoCambio;
                                }
                                else
                                {
                                    MontoSoles = item.BaseImponibleExportacion * item.TipoCambio;
                                    MontoDolares = item.BaseImponibleExportacion;
                                }

                                oBaseImponible = BasesImponibles.Find
                                (
                                    delegate (ParTabla p) { return p.NemoTecnico == "BAEXP"; }
                                );

                                ItemVoucher = new VoucherItemE();

                                ItemVoucher.numItem = String.Format("{0:00000}", ItemDet);
                                ItemVoucher.idPersona = idPersona;
                                ItemVoucher.idMoneda = item.Moneda;
                                ItemVoucher.tipCambio = item.TipoCambio;
                                ItemVoucher.indCambio = "S";
                                ItemVoucher.idCCostos = item.CentroCostos;
                                ItemVoucher.numVerPlanCuentas = VersionPlanCuentas;
                                ItemVoucher.codCuenta = item.Cuenta70;
                                ItemVoucher.desGlosa = Glosa;
                                ItemVoucher.fecDocumento = fecDoc;
                                ItemVoucher.fecVencimiento = fecVenc;
                                ItemVoucher.idDocumento = idDoc;
                                ItemVoucher.serDocumento = Serie;
                                ItemVoucher.numDocumento = NumeroDoc;


                                if (TipoDocumento == "NC")
                                {
                                    ItemVoucher.fecDocumentoRef = item.FechaRef;
                                    ItemVoucher.idDocumentoRef = TipoDocumentoRef;
                                    ItemVoucher.serDocumentoRef = item.serDocumentoRef;
                                    ItemVoucher.numDocumentoRef = item.numDocumentoRef;
                                }
                                else
                                {
                                    ItemVoucher.fecDocumentoRef = null;
                                    ItemVoucher.idDocumentoRef = "";
                                    ItemVoucher.serDocumentoRef = "";
                                    ItemVoucher.numDocumentoRef = "";
                                }

                                ItemVoucher.indDebeHaber = indDebeHaber;
                                ItemVoucher.impSoles = Math.Abs(MontoSoles);
                                ItemVoucher.impDolares = Math.Abs(MontoDolares);
                                ItemVoucher.indAutomatica = "N";
                                ItemVoucher.CorrelativoAjuste = "";
                                ItemVoucher.codFteFin = "";
                                ItemVoucher.codProgramaCred = "";
                                ItemVoucher.indMovimientoAnterior = "N";
                                ItemVoucher.tipPartidaPresu = "";
                                ItemVoucher.codPartidaPresu = "";
                                ItemVoucher.numDocumentoPresu = "";
                                ItemVoucher.codColumnaCoven = oBaseImponible.IdParTabla;
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
                                ItemVoucher.UsuarioRegistro = item.UsuarioRegistro;

                                //Añadiendo el Base Exportación
                                oVoucher.ListaVouchers.Add(ItemVoucher);
                            }

                            if (Math.Abs(item.BaseImponibleGravada) > 0)
                            {
                                ItemDet++;

                                if (item.Moneda == Variables.Soles)
                                {
                                    MontoSoles = item.BaseImponibleGravada;
                                    MontoDolares = item.BaseImponibleGravada / item.TipoCambio;
                                }
                                else
                                {
                                    MontoSoles = item.BaseImponibleGravada * item.TipoCambio;
                                    MontoDolares = item.BaseImponibleGravada;
                                }

                                oBaseImponible = BasesImponibles.Find
                                (
                                    delegate (ParTabla p) { return p.NemoTecnico == "BAIMP"; }
                                );

                                ItemVoucher = new VoucherItemE();

                                ItemVoucher.numItem = String.Format("{0:00000}", ItemDet);
                                ItemVoucher.idPersona = idPersona;
                                ItemVoucher.idMoneda = item.Moneda;
                                ItemVoucher.tipCambio = item.TipoCambio;
                                ItemVoucher.indCambio = "S";
                                ItemVoucher.idCCostos = item.CentroCostos;
                                ItemVoucher.numVerPlanCuentas = VersionPlanCuentas;
                                ItemVoucher.codCuenta = item.Cuenta70;
                                ItemVoucher.desGlosa = Glosa;
                                ItemVoucher.fecDocumento = fecDoc;
                                ItemVoucher.fecVencimiento = fecVenc;
                                ItemVoucher.idDocumento = idDoc;
                                ItemVoucher.serDocumento = Serie;
                                ItemVoucher.numDocumento = NumeroDoc;

                                if (TipoDocumento == "NC")
                                {
                                    ItemVoucher.fecDocumentoRef = item.FechaRef;
                                    ItemVoucher.idDocumentoRef = TipoDocumentoRef;
                                    ItemVoucher.serDocumentoRef = item.serDocumentoRef;
                                    ItemVoucher.numDocumentoRef = item.numDocumentoRef;
                                }
                                else
                                {
                                    ItemVoucher.fecDocumentoRef = null;
                                    ItemVoucher.idDocumentoRef = "";
                                    ItemVoucher.serDocumentoRef = "";
                                    ItemVoucher.numDocumentoRef = "";
                                }

                                ItemVoucher.indDebeHaber = indDebeHaber;
                                ItemVoucher.impSoles = Math.Abs(MontoSoles);
                                ItemVoucher.impDolares = Math.Abs(MontoDolares);
                                ItemVoucher.indAutomatica = "N";
                                ItemVoucher.CorrelativoAjuste = "";
                                ItemVoucher.codFteFin = "";
                                ItemVoucher.codProgramaCred = "";
                                ItemVoucher.indMovimientoAnterior = "N";
                                ItemVoucher.tipPartidaPresu = "";
                                ItemVoucher.codPartidaPresu = "";
                                ItemVoucher.numDocumentoPresu = "";
                                ItemVoucher.codColumnaCoven = oBaseImponible.IdParTabla;
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
                                ItemVoucher.UsuarioRegistro = item.UsuarioRegistro;

                                //Añadiendo el Base Imponible Gravada
                                oVoucher.ListaVouchers.Add(ItemVoucher);
                            }

                            if (Math.Abs(item.ImporteTotalExonerada) > 0)
                            {
                                ItemDet++;

                                if (item.Moneda == Variables.Soles)
                                {
                                    MontoSoles = item.ImporteTotalExonerada;
                                    MontoDolares = item.ImporteTotalExonerada / item.TipoCambio;
                                }
                                else
                                {
                                    MontoSoles = item.ImporteTotalExonerada * item.TipoCambio;
                                    MontoDolares = item.ImporteTotalExonerada;
                                }

                                oBaseImponible = BasesImponibles.Find
                                (
                                    delegate (ParTabla p) { return p.NemoTecnico == "BAINA"; }
                                );

                                ItemVoucher = new VoucherItemE();

                                ItemVoucher.numItem = String.Format("{0:00000}", ItemDet);
                                ItemVoucher.idPersona = idPersona;
                                ItemVoucher.idMoneda = item.Moneda;
                                ItemVoucher.tipCambio = item.TipoCambio;
                                ItemVoucher.indCambio = "S";
                                ItemVoucher.idCCostos = item.CentroCostos;
                                ItemVoucher.numVerPlanCuentas = VersionPlanCuentas;
                                ItemVoucher.codCuenta = item.Cuenta70;
                                ItemVoucher.desGlosa = Glosa;
                                ItemVoucher.fecDocumento = fecDoc;
                                ItemVoucher.fecVencimiento = fecVenc;
                                ItemVoucher.idDocumento = idDoc;
                                ItemVoucher.serDocumento = Serie;
                                ItemVoucher.numDocumento = NumeroDoc;

                                if (TipoDocumento == "NC")
                                {
                                    ItemVoucher.fecDocumentoRef = item.FechaRef;
                                    ItemVoucher.idDocumentoRef = TipoDocumentoRef;
                                    ItemVoucher.serDocumentoRef = item.serDocumentoRef;
                                    ItemVoucher.numDocumentoRef = item.numDocumentoRef;
                                }
                                else
                                {
                                    ItemVoucher.fecDocumentoRef = null;
                                    ItemVoucher.idDocumentoRef = "";
                                    ItemVoucher.serDocumentoRef = "";
                                    ItemVoucher.numDocumentoRef = "";
                                }

                                ItemVoucher.indDebeHaber = indDebeHaber;
                                ItemVoucher.impSoles = Math.Abs(MontoSoles);
                                ItemVoucher.impDolares = Math.Abs(MontoDolares);
                                ItemVoucher.indAutomatica = "N";
                                ItemVoucher.CorrelativoAjuste = "";
                                ItemVoucher.codFteFin = "";
                                ItemVoucher.codProgramaCred = "";
                                ItemVoucher.indMovimientoAnterior = "N";
                                ItemVoucher.tipPartidaPresu = "";
                                ItemVoucher.codPartidaPresu = "";
                                ItemVoucher.numDocumentoPresu = "";
                                ItemVoucher.codColumnaCoven = oBaseImponible.IdParTabla;
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
                                ItemVoucher.UsuarioRegistro = item.UsuarioRegistro;

                                //Añadiendo el Base Exonerada
                                oVoucher.ListaVouchers.Add(ItemVoucher);
                            }

                            if (Math.Abs(item.ImporteTotalInafecto) > 0)
                            {
                                ItemDet++;

                                if (item.Moneda == Variables.Soles)
                                {
                                    MontoSoles = item.ImporteTotalInafecto;
                                    MontoDolares = item.ImporteTotalInafecto / item.TipoCambio;
                                }
                                else
                                {
                                    MontoSoles = item.ImporteTotalInafecto * item.TipoCambio;
                                    MontoDolares = item.ImporteTotalInafecto;
                                }

                                oBaseImponible = BasesImponibles.Find
                                (
                                    delegate (ParTabla p) { return p.NemoTecnico == "BAINA"; }
                                );

                                ItemVoucher = new VoucherItemE();

                                ItemVoucher.numItem = String.Format("{0:00000}", ItemDet);
                                ItemVoucher.idPersona = idPersona;
                                ItemVoucher.idMoneda = item.Moneda;
                                ItemVoucher.tipCambio = item.TipoCambio;
                                ItemVoucher.indCambio = "S";
                                ItemVoucher.idCCostos = item.CentroCostos;
                                ItemVoucher.numVerPlanCuentas = VersionPlanCuentas;
                                ItemVoucher.codCuenta = item.Cuenta70;
                                ItemVoucher.desGlosa = Glosa;
                                ItemVoucher.fecDocumento = fecDoc;
                                ItemVoucher.fecVencimiento = fecVenc;
                                ItemVoucher.idDocumento = idDoc;
                                ItemVoucher.serDocumento = Serie;
                                ItemVoucher.numDocumento = NumeroDoc;

                                if (TipoDocumento == "NC")
                                {
                                    ItemVoucher.fecDocumentoRef = item.FechaRef;
                                    ItemVoucher.idDocumentoRef = TipoDocumentoRef;
                                    ItemVoucher.serDocumentoRef = item.serDocumentoRef;
                                    ItemVoucher.numDocumentoRef = item.numDocumentoRef;
                                }
                                else
                                {
                                    ItemVoucher.fecDocumentoRef = null;
                                    ItemVoucher.idDocumentoRef = "";
                                    ItemVoucher.serDocumentoRef = "";
                                    ItemVoucher.numDocumentoRef = "";
                                }

                                ItemVoucher.indDebeHaber = indDebeHaber;
                                ItemVoucher.impSoles = Math.Abs(MontoSoles);
                                ItemVoucher.impDolares = Math.Abs(MontoDolares);
                                ItemVoucher.indAutomatica = "N";
                                ItemVoucher.CorrelativoAjuste = "";
                                ItemVoucher.codFteFin = "";
                                ItemVoucher.codProgramaCred = "";
                                ItemVoucher.indMovimientoAnterior = "N";
                                ItemVoucher.tipPartidaPresu = "";
                                ItemVoucher.codPartidaPresu = "";
                                ItemVoucher.numDocumentoPresu = "";
                                ItemVoucher.codColumnaCoven = oBaseImponible.IdParTabla;
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
                                ItemVoucher.UsuarioRegistro = item.UsuarioRegistro;

                                //Añadiendo el Base Exonerada
                                oVoucher.ListaVouchers.Add(ItemVoucher);
                            }

                            #endregion

                            //Otros Cargos 469915
                            if (Math.Abs(item.OtrosTributos) > 0)
                            {
                                idPersona = oPersona.IdPersona;
                                idDoc = TipoDocumento;
                                Serie = item.SerieDocumento;
                                NumeroDoc = item.NumeroDocumento;
                                fecDoc = item.fecDocumento;
                                fecVenc = item.fecVencimiento;

                                if (TipoDocumento == "NC")
                                {
                                    indDebeHaber = Variables.Debe;
                                }
                                else
                                {
                                    indDebeHaber = Variables.Haber;
                                }

                                ItemDet++;

                                if (item.Moneda == Variables.Soles)
                                {
                                    MontoSoles = item.OtrosTributos;
                                    MontoDolares = item.OtrosTributos / item.TipoCambio;
                                }
                                else
                                {
                                    MontoSoles = item.OtrosTributos * item.TipoCambio;
                                    MontoDolares = item.OtrosTributos;
                                }

                                oBaseImponible = BasesImponibles.Find
                                (
                                    delegate (ParTabla p) { return p.NemoTecnico == "BAIMP"; }
                                );

                                ItemVoucher = new VoucherItemE();

                                ItemVoucher.numItem = String.Format("{0:00000}", ItemDet);
                                ItemVoucher.idPersona = idPersona;
                                ItemVoucher.idMoneda = item.Moneda;
                                ItemVoucher.tipCambio = item.TipoCambio;
                                ItemVoucher.indCambio = "S";
                                ItemVoucher.idCCostos = item.CentroCostos;
                                ItemVoucher.numVerPlanCuentas = VersionPlanCuentas;
                                ItemVoucher.codCuenta = "469915";
                                ItemVoucher.desGlosa = Glosa;
                                ItemVoucher.fecDocumento = fecDoc;
                                ItemVoucher.fecVencimiento = fecVenc;
                                ItemVoucher.idDocumento = idDoc;
                                ItemVoucher.serDocumento = Serie;
                                ItemVoucher.numDocumento = NumeroDoc;

                                if (TipoDocumento == "NC")
                                {
                                    ItemVoucher.fecDocumentoRef = item.FechaRef;
                                    ItemVoucher.idDocumentoRef = TipoDocumentoRef;
                                    ItemVoucher.serDocumentoRef = item.serDocumentoRef;
                                    ItemVoucher.numDocumentoRef = item.numDocumentoRef;
                                }
                                else
                                {
                                    ItemVoucher.fecDocumentoRef = null;
                                    ItemVoucher.idDocumentoRef = "";
                                    ItemVoucher.serDocumentoRef = "";
                                    ItemVoucher.numDocumentoRef = "";
                                }

                                ItemVoucher.indDebeHaber = indDebeHaber;
                                ItemVoucher.impSoles = Math.Abs(MontoSoles);
                                ItemVoucher.impDolares = Math.Abs(MontoDolares);
                                ItemVoucher.indAutomatica = "N";
                                ItemVoucher.CorrelativoAjuste = "";
                                ItemVoucher.codFteFin = "";
                                ItemVoucher.codProgramaCred = "";
                                ItemVoucher.indMovimientoAnterior = "N";
                                ItemVoucher.tipPartidaPresu = "";
                                ItemVoucher.codPartidaPresu = "";
                                ItemVoucher.numDocumentoPresu = "";
                                ItemVoucher.codColumnaCoven = oBaseImponible.IdParTabla;
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
                                ItemVoucher.UsuarioRegistro = item.UsuarioRegistro;

                                //Añadiendo los otros Cargos
                                oVoucher.ListaVouchers.Add(ItemVoucher);
                            }

                            oVoucher.numItems = oVoucher.ListaVouchers.Count;
                            oVoucher.impDebeSoles = Convert.ToDecimal(oVoucher.ListaVouchers.Where(s => s.indDebeHaber == Variables.Debe).Sum(x => x.impSoles));
                            oVoucher.impHaberSoles = Convert.ToDecimal(oVoucher.ListaVouchers.Where(s => s.indDebeHaber == Variables.Haber).Sum(x => x.impSoles));
                            oVoucher.impDebeDolares = Convert.ToDecimal(oVoucher.ListaVouchers.Where(s => s.indDebeHaber == Variables.Debe).Sum(x => x.impDolares));
                            oVoucher.impHaberDolares = Convert.ToDecimal(oVoucher.ListaVouchers.Where(s => s.indDebeHaber == Variables.Haber).Sum(x => x.impDolares));

                            oVoucher = new VoucherLN().GrabarVouchers(oVoucher, EnumOpcionGrabar.Insertar);
                            ItemDet = 1;
                        }

                        new VoucherAD().TriggerVouchers(false); //Habilita Trigger

                        oTrans.Complete();
                        ValorDevuelto = true;
                    }
                }

                return ValorDevuelto;
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

        public Boolean GenerarVoucherIngresosGeneral(List<RegistroVentaGeneralE> oListaVentas, RegistroVentaGeneralE Cabecera)
        {
            try
            {
                Boolean ValorDevuelto = false;

                if (oListaVentas.Count > 0)
                {
                    TransactionOptions Opciones = new TransactionOptions();
                    Opciones.Timeout = TimeSpan.FromMinutes(50);

                    using (TransactionScope oTrans = new TransactionScope(TransactionScopeOption.Required, Opciones))
                    {

                    new VoucherAD().TriggerVouchers(true); //Desabilita Trigger
                    VoucherE oVoucher = null; 
                    VoucherItemE ItemVoucher = null;
                    int ItemDet = 0;
                    String indDebeHaber = "";
                    String TipoDocumento = "";
                    String idDoc;
                    String Serie;
                    String NumeroDoc;
                    DateTime? fecDoc;
                    DateTime? fecVenc;
                    ParametrosContaE oParametros = new ParametrosContaAD().ObtenerParametrosConta(oListaVentas[0].idEmpresa);
                    PlanCuentasE oPlanCuentas = null;
                    PlanCuentasE oPlanCuentas12Soles = null;
                    PlanCuentasE oPlanCuentas12Dolar = null;
                    PlanCuentasE oPlanCuentas10 = null;
                    String VersionPlanCuentas = oParametros.numVerPlanCuentas;

                    oPlanCuentas12Soles = new PlanCuentasAD().ObtenerPlanCuentasPorCodigo(oListaVentas[0].idEmpresa, VersionPlanCuentas, oParametros.VentaS);
                     if (oPlanCuentas12Soles == null)
                     {
                     throw new Exception(String.Format("La cuenta 12 {0} ingresada en Parametros de Contabilidad - Cuentas, no existe.", oParametros.VentaS));
                     }

                    oPlanCuentas12Dolar = new PlanCuentasAD().ObtenerPlanCuentasPorCodigo(oListaVentas[0].idEmpresa, VersionPlanCuentas, oParametros.VentaD);
                     if (oPlanCuentas12Dolar == null)
                     {
                     throw new Exception(String.Format("La cuenta 12 {0} ingresada en Parametros de Contabilidad - Cuentas, no existe.", oParametros.VentaD));
                     }

                     
                     // Inicio de Cabecera
                        
                        oPlanCuentas10 = new PlanCuentasAD().ObtenerPlanCuentasPorCodigo(oListaVentas[0].idEmpresa, VersionPlanCuentas, Cabecera.CuentaEgresos);
                         if (oPlanCuentas10 == null)
                         {
                         throw new Exception(String.Format("La cuenta de Ingresos {0} No Existe de Contabilidad - Cuentas, no existe.", Cabecera.CuentaEgresos));
                         }

                            if (Cabecera.Moneda == Variables.Soles)
                            {
                               oPlanCuentas = oPlanCuentas12Soles;
                            }
                            else
                            {
                               oPlanCuentas = oPlanCuentas12Dolar;
                            }

                            var oListaItem = oListaVentas.Where(x => x.Estado == "CONT" && 
                                                                 x.idComprobanteEgresos == Cabecera.idComprobanteEgresos &&
                                                                 x.numFileEgresos == Cabecera.numFileEgresos &&
                                                                 x.FechaEgresos == Cabecera.FechaEgresos &&
                                                                 x.NumeroDocumentoIngresos == Cabecera.NumeroDocumentoIngresos &&
                                                                 x.Moneda == Cabecera.Moneda &&
                                                                 x.CuentaEgresos == Cabecera.CuentaEgresos);
                            #region Cabecera 
                            oVoucher = new VoucherE();
                            oVoucher.idEmpresa = Cabecera.idEmpresa;
                            oVoucher.idLocal = oListaVentas[0].idLocal;
                            oVoucher.AnioPeriodo = oListaVentas[0].fecOperacion.ToString("yyyy");
                            oVoucher.MesPeriodo = oListaVentas[0].fecOperacion.ToString("MM");
                            oVoucher.numVoucher = "0";
                            oVoucher.idComprobante = Cabecera.idComprobanteEgresos;
                            oVoucher.numFile = Cabecera.numFileEgresos;
                            oVoucher.fecTransferencia = null;
                            oVoucher.numItems = 0; 
                            oVoucher.idMoneda = Cabecera.Moneda;
                            oVoucher.fecOperacion = Cabecera.FechaEgresos;
                            oVoucher.fecDocumento = Cabecera.FechaEgresos;
                            oVoucher.impDebeSoles = 0; 
                            oVoucher.impHaberSoles = 0; 
                            oVoucher.impDebeDolares = 0; 
                            oVoucher.impHaberDolares = 0; 
                            oVoucher.impMonOrigDeb = 0; 
                            oVoucher.impMonOrigHab = 0; 
                            oVoucher.GlosaGeneral = "Cobranza en Efectivo "+Cabecera.NumeroDocumentoIngresos;
                            oVoucher.indEstado = "C";
                            oVoucher.tipCambio = Cabecera.TipoCambio;
                            oVoucher.RazonSocial = "";
                            oVoucher.numDocumentoPresu = "OT"+"-"+Cabecera.NumeroDocumentoIngresos;
                            oVoucher.indHojaCosto = "N";
                            oVoucher.numHojaCosto = String.Empty;
                            oVoucher.numOrdenCompra = String.Empty;
                            oVoucher.sistema = "2";
                            oVoucher.EsAutomatico = false;
                            oVoucher.UsuarioRegistro = oListaVentas[0].UsuarioRegistro;
                            #endregion

                            #region Detalle de Ingresos (Ingresos)
                            ItemVoucher = new VoucherItemE();
                            ItemDet = 1;

                            Int32? idPersona;
                            decimal MontoSoles = 0;
                            decimal MontoDolares = 0;

                            if (Cabecera.Moneda == Variables.Soles)
                               {
                               MontoSoles = Cabecera.efectivoEgresos;
                               MontoDolares = Cabecera.efectivoEgresos / Cabecera.TipoCambio;
                               }
                               else
                               {
                               MontoSoles = Cabecera.efectivoEgresos * Cabecera.TipoCambio;
                               MontoDolares = Cabecera.efectivoEgresos;
                               }
                        indDebeHaber = Variables.Debe;

                        ItemVoucher.numItem = String.Format("{0:00000}", ItemDet);
                        ItemVoucher.idPersona = null;
                        ItemVoucher.idMoneda = Cabecera.Moneda;
                        ItemVoucher.tipCambio = Cabecera.TipoCambio;
                        ItemVoucher.indCambio = "S";
                        ItemVoucher.idCCostos = "";
                        ItemVoucher.numVerPlanCuentas = VersionPlanCuentas;
                        ItemVoucher.codCuenta = oPlanCuentas10.codCuenta;
                        ItemVoucher.desGlosa = "";
                        ItemVoucher.fecDocumento = Cabecera.FechaEgresos;
                        ItemVoucher.fecVencimiento = Cabecera.FechaEgresos;
                        ItemVoucher.idDocumento = "OT";
                        ItemVoucher.serDocumento = "";
                        ItemVoucher.numDocumento = Cabecera.NumeroDocumentoIngresos;
                        ItemVoucher.fecDocumentoRef = null;
                        ItemVoucher.idDocumentoRef = "";
                        ItemVoucher.serDocumentoRef = "";
                        ItemVoucher.numDocumentoRef = "";
                        ItemVoucher.indDebeHaber = indDebeHaber;
                        ItemVoucher.impSoles = Math.Abs(MontoSoles);
                        ItemVoucher.impDolares = Math.Abs(MontoDolares);
                        ItemVoucher.indAutomatica = "N";
                        ItemVoucher.CorrelativoAjuste = "";
                        ItemVoucher.codFteFin = "";
                        ItemVoucher.codProgramaCred = "";
                        ItemVoucher.indMovimientoAnterior = "N";
                        ItemVoucher.tipPartidaPresu = "";
                        ItemVoucher.codPartidaPresu = "";
                        ItemVoucher.numDocumentoPresu = "";
                        ItemVoucher.codColumnaCoven = null;
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
                        ItemVoucher.UsuarioRegistro = oListaVentas[0].UsuarioRegistro;
                        //Añadiendo 
                        oVoucher.ListaVouchers.Add(ItemVoucher);
                        #endregion

                            foreach (RegistroVentaGeneralE Detalle in oListaItem)
                            {
                                #region Detalle de Ventas (Ventas)
                                ItemVoucher = new VoucherItemE();
                                ItemDet = ItemDet + 1;
                                                                
                                if (Detalle.Moneda == Variables.Soles)
                                {
                                    oPlanCuentas = oPlanCuentas12Soles;
                                    MontoSoles = Detalle.ImporteTotal;
                                    MontoDolares = Detalle.ImporteTotal / Detalle.TipoCambio;
                                }
                                else
                                {
                                    oPlanCuentas = oPlanCuentas12Dolar;
                                    MontoSoles = Detalle.ImporteTotal * Detalle.TipoCambio;
                                    MontoDolares = Detalle.ImporteTotal;
                                }

                                Persona oPersona = new PersonaAD().ObtenerPersonaPorNroRuc(Detalle.NumeroDocIdentidad);

                                if (oPlanCuentas.indSolicitaAnexo == "S")
                                {
                                    idPersona = oPersona.IdPersona;
                                }
                                else
                                {
                                    idPersona = null;
                                }


                            TipoDocumento = "";

                            if (Detalle.idDocumento == "01" || Detalle.idDocumento == "1")
                            {
                                TipoDocumento = "FV";
                            }

                            if (Detalle.idDocumento == "03" || Detalle.idDocumento == "3")
                            {
                                TipoDocumento = "BV";
                            }

                            if (Detalle.idDocumento == "07" || Detalle.idDocumento == "7")
                            {
                                TipoDocumento = "NC";
                            }

                            if (Detalle.idDocumento == "08" || Detalle.idDocumento == "8")
                            {
                                TipoDocumento = "ND";
                            }

                            if (Detalle.idDocumento == "12")
                            {
                                TipoDocumento = "TK";
                            }



                            if (oPlanCuentas.indSolicitaDcto == "S")
                                {
                                    idDoc = TipoDocumento;
                                    Serie = Detalle.SerieDocumento;
                                    NumeroDoc = Detalle.NumeroDocumento;
                                    fecDoc = Detalle.fecDocumento;
                                    fecVenc = Detalle.fecVencimiento.Value;
                                }
                                else
                                {
                                    idDoc = String.Empty;
                                    Serie = String.Empty;
                                    NumeroDoc = String.Empty;
                                    fecDoc = null;
                                    fecVenc = null;
                                }


                                if (Detalle.idDocumento == "NC")
                                {
                                    indDebeHaber = Variables.Debe;
                                }
                                else
                                {
                                    indDebeHaber = Variables.Haber;
                                }

                                ItemVoucher.numItem = String.Format("{0:00000}", ItemDet);
                                ItemVoucher.idPersona = idPersona;
                                ItemVoucher.idMoneda = Detalle.Moneda;
                                ItemVoucher.tipCambio = Detalle.TipoCambio;
                                ItemVoucher.indCambio = "S";
                                ItemVoucher.idCCostos = Detalle.CentroCostos;
                                ItemVoucher.numVerPlanCuentas = VersionPlanCuentas;
                                ItemVoucher.codCuenta = oPlanCuentas.codCuenta;
                                ItemVoucher.desGlosa = "";
                                ItemVoucher.fecDocumento = fecDoc;
                                ItemVoucher.fecVencimiento = fecVenc;
                                ItemVoucher.idDocumento = idDoc;
                                ItemVoucher.serDocumento = Serie;
                                ItemVoucher.numDocumento = NumeroDoc;
                                ItemVoucher.fecDocumentoRef = null;
                                ItemVoucher.idDocumentoRef = "";
                                ItemVoucher.serDocumentoRef = "";
                                ItemVoucher.numDocumentoRef = "";
                                ItemVoucher.indDebeHaber = indDebeHaber;
                                ItemVoucher.impSoles = Math.Abs(MontoSoles);
                                ItemVoucher.impDolares = Math.Abs(MontoDolares);
                                ItemVoucher.indAutomatica = "N";
                                ItemVoucher.CorrelativoAjuste = "";
                                ItemVoucher.codFteFin = "";
                                ItemVoucher.codProgramaCred = "";
                                ItemVoucher.indMovimientoAnterior = "N";
                                ItemVoucher.tipPartidaPresu = "";
                                ItemVoucher.codPartidaPresu = "";
                                ItemVoucher.numDocumentoPresu = "";
                                ItemVoucher.codColumnaCoven = null;
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
                                ItemVoucher.UsuarioRegistro = Detalle.UsuarioRegistro;

                                //Añadiendo el total
                                oVoucher.ListaVouchers.Add(ItemVoucher);
                                #endregion
                            }

                            oVoucher.numItems = oVoucher.ListaVouchers.Count;
                            oVoucher.impDebeSoles = Convert.ToDecimal(oVoucher.ListaVouchers.Where(s => s.indDebeHaber == Variables.Debe).Sum(x => x.impSoles));
                            oVoucher.impHaberSoles = Convert.ToDecimal(oVoucher.ListaVouchers.Where(s => s.indDebeHaber == Variables.Haber).Sum(x => x.impSoles));
                            oVoucher.impDebeDolares = Convert.ToDecimal(oVoucher.ListaVouchers.Where(s => s.indDebeHaber == Variables.Debe).Sum(x => x.impDolares));
                            oVoucher.impHaberDolares = Convert.ToDecimal(oVoucher.ListaVouchers.Where(s => s.indDebeHaber == Variables.Haber).Sum(x => x.impDolares));

                            oVoucher = new VoucherLN().GrabarVouchers(oVoucher, EnumOpcionGrabar.Insertar);

                        // Fin de Cabecera

                    new VoucherAD().TriggerVouchers(false); //Habilita Trigger
                    oTrans.Complete();
                    ValorDevuelto = true;
                    }
                }
                return ValorDevuelto;
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

        public int CrearClientes(List<ErrorImportGeneralE> ListaClientesErrores, String Usuario, List<RegistroVentaGeneralE> oListaVentas = null)
        {
            try
            {
                Int32 resp = 0;

                using (TransactionScope oTrans = new TransactionScope())
                {
                    List<ParTabla> oListaTipoPersona = new ParTablaAD().ListarParTablaPorNemo("TIPPER");
                    List<ParTabla> oListaTipoDocumento = new ParTablaAD().ListarParTablaPorNemo("TIPDOCPER");
                    ParTabla oTipoPer = null;
                    ParTabla oTipoDoc = null;
                    Int32 TipoPersona = 0;
                    Int32 TipoDocPersona = 0;

                    foreach (RegistroVentaGeneralE item in oListaVentas)
                    {
                        Persona oPersonaRev = new PersonaAD().ObtenerPersonaPorNroRuc(item.NumeroDocIdentidad);

                        if (oPersonaRev == null)
                        {
                            if (item.TipoDocIdentidad == "6")
                            {
                                oTipoPer = oListaTipoPersona.Find
                                (
                                    delegate (ParTabla p) { return p.NemoTecnico == "PERJU"; }
                                );

                                oTipoDoc = oListaTipoDocumento.Find
                                (
                                    delegate (ParTabla p) { return p.NemoTecnico == "PERRUC"; }
                                );
                            }

                            if (item.TipoDocIdentidad == "0" || item.TipoDocIdentidad == "4" || item.TipoDocIdentidad == "7")
                            {
                                oTipoPer = oListaTipoPersona.Find
                                (
                                    delegate (ParTabla p) { return p.NemoTecnico == "OTR"; }
                                );

                                if (item.TipoDocIdentidad == "0")
                                {
                                    oTipoDoc = oListaTipoDocumento.Find
                                    (
                                        delegate (ParTabla p) { return p.NemoTecnico == "PEROTR"; }
                                    );
                                }

                                if (item.TipoDocIdentidad == "4")
                                {
                                    oTipoDoc = oListaTipoDocumento.Find
                                    (
                                        delegate (ParTabla p) { return p.NemoTecnico == "PERCE"; }
                                    );
                                }

                                if (item.TipoDocIdentidad == "7")
                                {
                                    oTipoDoc = oListaTipoDocumento.Find
                                    (
                                        delegate (ParTabla p) { return p.NemoTecnico == "PERPAS"; }
                                    );
                                }
                            }

                            if (item.TipoDocIdentidad == "1")
                            {
                                oTipoPer = oListaTipoPersona.Find
                                (
                                    delegate (ParTabla cc) { return cc.NemoTecnico == "PERSR"; }
                                );

                                oTipoDoc = oListaTipoDocumento.Find
                                (
                                    delegate (ParTabla p) { return p.NemoTecnico == "PERDNI"; }
                                );
                            }

                            if (oTipoPer != null)
                            {
                                TipoPersona = oTipoPer.IdParTabla;
                            }

                            if (oTipoDoc != null)
                            {
                                TipoDocPersona = oTipoDoc.IdParTabla;
                            }

                            Persona oPersona = new Persona()
                            {
                                TipoPersona = TipoPersona,
                                RazonSocial = item.RazonSocial,
                                RUC = item.NumeroDocIdentidad,
                                ApePaterno = String.Empty,
                                ApeMaterno = String.Empty,
                                Nombres = String.Empty,
                                TipoDocumento = TipoDocPersona,
                                NroDocumento = item.NumeroDocIdentidad,
                                PrincipalContribuyente = false,
                                AgenteRetenedor = false,
                                UsuarioRegistro = Usuario
                            };

                            oPersona = new PersonaAD().InsertarPersona(oPersona);

                            ClienteE oCliente = new ClienteE()
                            {
                                idPersona = oPersona.IdPersona,
                                idEmpresa = item.idEmpresa,
                                SiglaComercial = item.RazonSocial,
                                TipoCliente = 104006,
                                indEstado = false,
                                UsuarioRegistro = Usuario
                            };

                            resp++; 
                        }
                    }
                    //foreach (ErrorImportGeneralE item in ListaClientesErrores)
                    //{
                    //    Persona oPersona = new Persona()
                    //    {
                    //        TipoPersona = 102001,
                    //        RazonSocial = item.RazonSocial,
                    //        RUC = item.ValorCampo,
                    //        ApePaterno = String.Empty,
                    //        ApeMaterno = String.Empty,
                    //        Nombres = String.Empty,
                    //        TipoDocumento = 101004,
                    //        NroDocumento = item.ValorCampo,
                    //        PrincipalContribuyente = false,
                    //        AgenteRetenedor = false,
                    //        UsuarioRegistro = Usuario
                    //    };

                    //    oPersona = new PersonaAD().InsertarPersona(oPersona);

                    //    ClienteE oCliente = new ClienteE()
                    //    {
                    //        idPersona = oPersona.IdPersona,
                    //        idEmpresa = item.idEmpresa,
                    //        SiglaComercial = item.RazonSocial,
                    //        TipoCliente = 104006,
                    //        indEstado = false,
                    //        UsuarioRegistro = Usuario
                    //    };

                    //    resp++;
                    //}

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

    }
}



