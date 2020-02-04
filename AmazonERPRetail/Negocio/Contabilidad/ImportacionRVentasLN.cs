using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Transactions;
using System.Linq;

using Entidades.Contabilidad;
using Entidades.Maestros;
using Entidades.Generales;
using Entidades.Ventas;
using AccesoDatos.Contabilidad;
using AccesoDatos.Maestros;
using AccesoDatos.Generales;
using AccesoDatos.Ventas;
using Infraestructura.Enumerados;

namespace Negocio.Contabilidad
{
    public class ImportacionRVentasLN
    {

        public int ImportarRVentas(List<ImportacionRVentasE> oLista)
        {
            try
            {
                TransactionOptions Opciones = new TransactionOptions
                {
                    Timeout = TimeSpan.FromMinutes(120)
                };

                int Registros = 0;

                using (TransactionScope oTrans = new TransactionScope(TransactionScopeOption.Required, Opciones))
                {
                    foreach (ImportacionRVentasE item in oLista)
                    {
                        new ImportacionRVentasAD().InsertarRVENTAS(item);

                        Registros++;
                    }

                    //Cerrando la transaccion
                    oTrans.Complete();
                }

                return Registros;
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

        public ImportacionRVentasE InsertarRVENTAS(ImportacionRVentasE rventas)
        {
            try
            {
                return new ImportacionRVentasAD().InsertarRVENTAS(rventas);
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

        public ImportacionRVentasE ActualizarRVENTAS(ImportacionRVentasE rventas)
        {
            try
            {
                return new ImportacionRVentasAD().ActualizarRVENTAS(rventas);
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

        public int EliminarRVENTAS(Int32 idEmpresa, String Libro, DateTime fecIni, DateTime fecFin)
        {
            try
            {
                return new ImportacionRVentasAD().EliminarRVENTAS(idEmpresa, Libro, fecIni, fecFin);
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

        public List<ImportacionRVentasE> ListarRVENTAS()
        {
            try
            {
                return new ImportacionRVentasAD().ListarRVENTAS();
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

        public ImportacionRVentasE ObtenerRVENTAS()
        {
            try
            {
                return new ImportacionRVentasAD().ObtenerRVENTAS();
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

        public int GenerarVouchersRVentas(List<ImportacionRVentasE> oListaImportacion, String Usuario, Boolean EliminarVouchers, DateTime fecInicial, DateTime fecFinal)
        {
            try
            {
                #region Variables

                Int32 idEmpresa = oListaImportacion[0].idEmpresa;
                Int32 idLocal = oListaImportacion[0].idLocal;
                List<ImportacionRVentasE> oListaCompras = (from x in oListaImportacion where x.T == "01" select x).ToList(); //Compras
                List<ImportacionRVentasE> oListaVentas = (from x in oListaImportacion where x.T == "02" select x).ToList(); //Ventas
                List<ImportacionRVentasE> oListaCobranzas = (from x in oListaImportacion where x.T == "21" select x).ToList(); //Cobranzas
                ParametrosContaE oParametroCon = new ParametrosContaAD().ObtenerParametrosConta(idEmpresa);
                venParametrosE oParametroVen = new venParametrosAD().ObtenerVenParametros(idEmpresa);
                int FilasDevueltas = 0;
                VoucherE oVoucher = null;
                String Moneda = String.Empty;
                String TipoDocumento = String.Empty;
                Int32 BaseImponible = 0;
                //Obteniendo la Version del Plan de Cuentas
                PlanCuentasVersionE oNumVerPlanCuentas = new PlanCuentasVersionAD().VersionPlanCuentasActual(idEmpresa);
                //Plan de Cuentas...
                List<PlanCuentasE> oPlanCuentas = new PlanCuentasAD().ListarPlanCuentasPorNivel(idEmpresa, oNumVerPlanCuentas.numVerPlanCuentas, oNumVerPlanCuentas.Longitud);
                //Auxiliar
                Persona oPersona = null;
                Int32? idPersona_ = 0;
                String Ruc_ = String.Empty;
                //Documento
                String idDoc = String.Empty;
                String serDoc = String.Empty;
                String numDoc = String.Empty;
                DateTime? fec = null;
                DateTime? fecVen = null;
                //Documento de referencia
                String idDocRef = String.Empty;
                String serDocRef = String.Empty;
                String numDocRef = String.Empty;
                DateTime? fecRef = null;
                Boolean EsAnulado = false;
                Boolean EsCabecera = true;
                Int32? idPartabla = 0;
                //C.Costos
                String cCostos = String.Empty;

                #endregion
                
                TransactionOptions Opciones = new TransactionOptions
                {
                    Timeout = TimeSpan.FromMinutes(720)
                };

                using (TransactionScope oTrans = new TransactionScope(TransactionScopeOption.Required, Opciones))
                {

                    new VoucherAD().TriggerVouchers(true); //Desabilita los Trigger

                    if (EliminarVouchers)
                    {
                        var ListaPorBorrar = oListaImportacion.GroupBy(x => new { x.idEmpresa, x.idLocal, x.AnioPeriodo, x.MesPeriodo, x.Libro, x.numFile, x.Fecha }).Select(g => g.First()).ToList();

                        ////Eliminando Voucher...
                        foreach (ImportacionRVentasE item in ListaPorBorrar.ToList())
                        {
                            new VoucherAD().EliminarVoucherPorPeriodoyFechas(item.idEmpresa, item.idLocal, item.AnioPeriodo, item.MesPeriodo, item.Libro, item.numFile, fecInicial, fecFinal);
                        }

                        ListaPorBorrar = null;
                    }

                    #region Ventas
              
                    if (oListaVentas != null && oListaVentas.Count > 0)
                    {
                        //Agrupando la lista para saber cuantos vouchers hay...
                        var ListaAgrupada = oListaVentas.GroupBy(x => new { x.idEmpresa, x.idLocal, x.AnioPeriodo, x.MesPeriodo, x.T, x.VOU }).Select(g => g.First()).ToList();
                        //Ordenando la lista agrupada
                        List<ImportacionRVentasE> ListaOrdenada = new List<ImportacionRVentasE>(from x in ListaAgrupada.ToList()
                                                                                                orderby x.idEmpresa, x.idLocal, x.AnioPeriodo, x.MesPeriodo, x.T, x.VOU
                                                                                                select x).ToList();
                        //Recorriendo la lista ordenada para generar los asientos
                        foreach (ImportacionRVentasE itemOrdenado in ListaOrdenada)
                        {
                            if (itemOrdenado.Moneda == "S")
                            {
                                Moneda = "01";
                            }
                            else
                            {
                                Moneda = "02";
                            }

                            //Obteniendo la lista de items de acuerdo al voucher y ordenandolo por Item
                            List<ImportacionRVentasE> oListita = new List<ImportacionRVentasE>(from x in oListaVentas
                                                                                               where x.idEmpresa == itemOrdenado.idEmpresa
                                                                                               && x.idLocal == itemOrdenado.idLocal
                                                                                               && x.AnioPeriodo == itemOrdenado.AnioPeriodo
                                                                                               && x.MesPeriodo == itemOrdenado.MesPeriodo
                                                                                               && x.T == itemOrdenado.T
                                                                                               && x.VOU == itemOrdenado.VOU
                                                                                               orderby x.Item
                                                                                               select x).ToList();

                            Decimal totIgv = oListita.Sum(x => Convert.ToDecimal(x.IGV)); //Para saber si lleva o no IGV

                            foreach (ImportacionRVentasE item in oListita)
                            {
                                #region Cabecera del Voucher

                                switch (item.Doc.Trim())
                                {
                                    case "12":
                                        idDoc = "TK";
                                        break;
                                    case "01":
                                        idDoc = "FV";
                                        break;
                                    case "03":
                                        idDoc = "BV";
                                        break;
                                    case "07":
                                        idDoc = "NC";
                                        break;
                                    case "08":
                                        idDoc = "ND";
                                        break;
                                    default:
                                        throw new Exception("Tipo de documento por configurar.");
                                }

                                if (EsCabecera)
                                {
                                    oVoucher = new VoucherE
                                    {
                                        idEmpresa = idEmpresa,
                                        idLocal = idLocal,
                                        AnioPeriodo = item.AnioPeriodo,
                                        MesPeriodo = item.MesPeriodo,
                                        numVoucher = "0",
                                        idComprobante = item.Libro,
                                        numFile = item.numFile,
                                        idMoneda = Moneda,
                                        fecOperacion = Convert.ToDateTime(item.Fecha),
                                        fecDocumento = Convert.ToDateTime(item.FechaD),
                                        GlosaGeneral = item.Glosa.Trim(),
                                        tipCambio = Convert.ToDecimal(item.TC),
                                        RazonSocial = item.Rs.Trim(),
                                        numDocumentoPresu = idDoc+"-"+item.Numero,
                                        indHojaCosto = "N",
                                        numHojaCosto = String.Empty,
                                        numOrdenCompra = String.Empty,
                                        sistema = "1", //Contabilidad... van directamente a los asientos
                                        EsAutomatico = false,
                                        UsuarioRegistro = Usuario
                                    };

                                    EsCabecera = false;
                                }

                                #endregion Cabecera del Voucher

                                #region Detalle del Voucher

                                ////Obteniendo el Plan de Cuentas...
                                PlanCuentasE oCuenta = oPlanCuentas.Find
                                (
                                    delegate (PlanCuentasE c) { return c.codCuenta == item.Cuenta; }
                                );

                                if (oCuenta == null)
                                {
                                    throw new Exception(String.Format("La cuenta {0} no existe en el Plan Contable. Revise por favor.", item.Cuenta));
                                }

                                List<ParTabla> ListaCoVen = new ParTablaAD().ListarParTablaPorValorEntero(oCuenta.codColumnaCoven.Value);
                                ParTabla par = null;

                                #region Columna Compras y Ventas

                                if (ListaCoVen != null && ListaCoVen.Count > 0)
                                {
                                    par = ListaCoVen.Find
                                    (
                                        delegate (ParTabla cc) { return cc.NemoTecnico == "IGV"; }
                                    );

                                    if (par != null) //Se trata de IGV
                                    {
                                        idPartabla = par.IdParTabla;
                                    }
                                    else
                                    {
                                        par = ListaCoVen.Find
                                        (
                                            delegate (ParTabla cc) { return cc.NemoTecnico == "TOTOT"; }
                                        );

                                        if (par != null) //Se trata del total
                                        {
                                            idPartabla = par.IdParTabla;
                                        }
                                        else //sino de una base imponible
                                        {
                                            if (totIgv > 0)
                                            {
                                                par = ListaCoVen.Find
                                                (
                                                    delegate (ParTabla cc) { return cc.NemoTecnico == "BAIMP"; }
                                                );
                                            }
                                            else
                                            {
                                                par = ListaCoVen.Find
                                                (
                                                    delegate (ParTabla cc) { return cc.NemoTecnico == "BAINA"; }
                                                );
                                            }

                                            if (par != null)
                                            {
                                                idPartabla = par.IdParTabla;
                                            }
                                            else
                                            {
                                                idPartabla = 0;
                                            }
                                        }
                                    }
                                }

                                #endregion Columna Compras y Ventas

                                #region Si solicita auxiliar

                                if (oCuenta.indSolicitaAnexo == "S")
                                {
                                    if (Ruc_ != item.RUC)//oPersona == null || idPersona_ == null)
                                    {
                                        if (item.RUC.Trim() != "0")
                                        {
                                            oPersona = new PersonaAD().ObtenerPersonaPorNroRuc(item.RUC);

                                            if (oPersona != null)
                                            {
                                                idPersona_ = oPersona.IdPersona;
                                            }
                                            else
                                            {
                                                oPersona = CrearAuxiliarRVentas(idEmpresa, item.Rs.Trim(), item.RUC.Trim(), Usuario, item.TDoci.Trim(), "C");
                                                idPersona_ = oPersona.IdPersona;
                                            }
                                        }
                                        else
                                        {
                                            if (oParametroVen == null)
                                            {
                                                throw new Exception("No se ha configurado el Parámetro de Clientes Varios en los Parámetros de Ventas.");
                                            }
                                            else
                                            {
                                                idPersona_ = oParametroVen.ClienteVarios;
                                            }
                                        }
                                    }

                                    Ruc_ = item.RUC.Trim();

                                    if (item.Glosa.Contains("ANULADO") || item.Glosa.Contains("ANULADA"))
                                    {
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
                                    idPersona_ = null;
                                    Ruc_ = String.Empty;

                                    if (item.Glosa.Contains("ANULADO") || item.Glosa.Contains("ANULADA"))
                                    {
                                        EsAnulado = true;
                                    }
                                }

                                #endregion

                                #region Si solicita Documento

                                if (oCuenta.indSolicitaDcto == "S")
                                {
                                    switch (item.Doc.Trim())
                                    {
                                        case "12":
                                            idDoc = "TK";
                                            break;
                                        case "01":
                                            idDoc = "FV";
                                            break;
                                        case "03":
                                            idDoc = "BV";
                                            break;
                                        case "07":
                                            idDoc = "NC";
                                            break;
                                        case "08":
                                            idDoc = "ND";
                                            break;
                                        default:
                                            throw new Exception("Tipo de documento por configurar.");
                                    }

                                    if (String.IsNullOrWhiteSpace(TipoDocumento))
                                    {
                                        TipoDocumento = idDoc;
                                    }

                                    List<String> ListaDoc = new List<String>(item.Numero.Split('-'));
                                    serDoc = ListaDoc[0].Trim();
                                    numDoc = ListaDoc[1].Trim();

                                    if (String.IsNullOrWhiteSpace(serDoc))
                                    {
                                        throw new Exception("El documento no tiene serie.");
                                    }

                                    if (String.IsNullOrWhiteSpace(numDoc))
                                    {
                                        throw new Exception("El documento no tiene número.");
                                    }

                                    fec = Convert.ToDateTime(item.Fecha);
                                    fecVen = item.FechaV;

                                    if (!String.IsNullOrWhiteSpace(item.RNumero.Trim()))
                                    {
                                        switch (item.RTdoc.Trim())
                                        {
                                            case "12":
                                                idDocRef = "TK";
                                                break;
                                            case "01":
                                                idDocRef = "FV";
                                                break;
                                            case "03":
                                                idDocRef = "BV";
                                                break;
                                            case "08":
                                                idDocRef = "NC";
                                                break;
                                            case "09":
                                                idDocRef = "ND";
                                                break;
                                            default:
                                                throw new Exception("Tipo de documento de referencia por configurar.");
                                        }

                                        ListaDoc = new List<String>(item.RNumero.Split('-'));
                                        serDocRef = ListaDoc[0].Trim();
                                        numDocRef = ListaDoc[1].Trim();
                                        fecRef = Convert.ToDateTime(item.RFecha);
                                    }
                                    else
                                    {
                                        idDocRef = String.Empty;
                                        serDocRef = String.Empty;
                                        numDocRef = String.Empty;
                                        fecRef = null;
                                    }
                                }
                                else
                                {
                                    idDoc = String.Empty;
                                    serDoc = String.Empty;
                                    numDoc = String.Empty;
                                    fec = null;
                                    fecVen = null;
                                    idDocRef = String.Empty;
                                    serDocRef = String.Empty;
                                    numDocRef = String.Empty;
                                    fecRef = null;
                                }

                                #endregion

                                #region Centro de Costos

                                if (oCuenta.indSolicitaCentroCosto == "S")
                                {
                                    cCostos = String.Empty; //itemReal.CentroCosto;
                                }
                                else
                                {
                                    cCostos = String.Empty;
                                }

                                #endregion

                                VoucherItemE oItemVoucher = new VoucherItemE
                                {
                                    idEmpresa = idEmpresa,
                                    idLocal = idLocal,
                                    AnioPeriodo = item.AnioPeriodo,
                                    MesPeriodo = item.MesPeriodo,
                                    numVoucher = String.Empty,
                                    idComprobante = item.Libro,
                                    numFile = item.numFile,
                                    numItem = String.Format("{0:00000}", item.Item),
                                    idPersona = idPersona_,
                                    idMoneda = Moneda,
                                    tipCambio = EsAnulado ? 1 : Convert.ToDecimal(item.TC),
                                    indCambio = "S",
                                    idCCostos = cCostos,
                                    numVerPlanCuentas = oNumVerPlanCuentas.numVerPlanCuentas,
                                    codCuenta = item.Cuenta.Trim(),
                                    desGlosa = item.Glosa.Trim(),
                                    fecDocumento = fec,
                                    fecVencimiento = fecVen,
                                    idDocumento = idDoc,
                                    serDocumento = serDoc,
                                    numDocumento = numDoc,
                                    fecDocumentoRef = fecRef,
                                    idDocumentoRef = idDocRef,
                                    serDocumentoRef = serDocRef,
                                    numDocumentoRef = numDocRef,
                                    indDebeHaber = item.DebeHaber,
                                    //impSoles = itemReal.MontoSoles,
                                    //impDolares = itemReal.MontoDolares,
                                    indAutomatica = "N",
                                    CorrelativoAjuste = String.Empty,
                                    codFteFin = String.Empty,
                                    codProgramaCred = String.Empty,
                                    indMovimientoAnterior = String.Empty,
                                    tipPartidaPresu = String.Empty,
                                    codPartidaPresu = String.Empty,
                                    numDocumentoPresu = String.Empty,
                                    codColumnaCoven = idPartabla,
                                    depAduanera = 0,
                                    AnioDua = String.Empty,
                                    nroDua = String.Empty,
                                    flagDetraccion = "N",
                                    numDetraccion = String.Empty,
                                    fecDetraccion = null,
                                    tipDetraccion = String.Empty,
                                    TasaDetraccion = 0,
                                    MontoDetraccion = 0,
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
                                    UsuarioRegistro = Usuario
                                };

                                if (oItemVoucher.indDebeHaber == "D")
                                {
                                    if (oItemVoucher.idMoneda == "01")
                                    {
                                        oItemVoucher.impSoles = item.Debe;
                                        oItemVoucher.impDolares = Decimal.Round(item.Debe / oItemVoucher.tipCambio, 2);
                                    }
                                    else
                                    {
                                        oItemVoucher.impDolares = item.Debe;
                                        oItemVoucher.impSoles = Decimal.Round(item.Debe * oItemVoucher.tipCambio, 2);
                                    }
                                }
                                else
                                {
                                    if (oItemVoucher.idMoneda == "01")
                                    {
                                        oItemVoucher.impSoles = Convert.ToDecimal(item.Haber);
                                        oItemVoucher.impDolares = Decimal.Round(item.Haber / oItemVoucher.tipCambio, 2);
                                    }
                                    else
                                    {
                                        oItemVoucher.impDolares = Convert.ToDecimal(item.Haber);
                                        oItemVoucher.impSoles = Decimal.Round(item.Haber * oItemVoucher.tipCambio, 2);
                                    }
                                }

                                oVoucher.ListaVouchers.Add(oItemVoucher);
                                oItemVoucher = null;

                                #endregion 
                            }

                            #region Completando datos de la Cabecera del Voucher

                            Decimal totDebeSoles = Decimal.Round((from x in oVoucher.ListaVouchers where x.indDebeHaber == "D" select x.impSoles).Sum(), 2);
                            Decimal totDebeDolares = Decimal.Round((from x in oVoucher.ListaVouchers where x.indDebeHaber == "D" select x.impDolares).Sum(), 2);
                            Decimal totHaberSoles = Decimal.Round((from x in oVoucher.ListaVouchers where x.indDebeHaber == "H" select x.impSoles).Sum(), 2);
                            Decimal totHaberDolares = Decimal.Round((from x in oVoucher.ListaVouchers where x.indDebeHaber == "H" select x.impDolares).Sum(), 2);
                            Decimal impDifSoles = 0, impDifDolares = 0;

                            if (TipoDocumento == "NC")
                            {
                                impDifSoles = totHaberSoles - totDebeSoles;
                                impDifDolares = totHaberDolares - totDebeDolares;
                            }
                            else
                            {
                                impDifSoles = totDebeSoles - totHaberSoles;
                                impDifDolares = totDebeDolares - totHaberDolares;
                            }

                            if ((impDifSoles != 0 && Moneda == "02" && Math.Abs(impDifSoles) <= 0.03M) || (impDifDolares != 0 && Moneda == "01" && Math.Abs(impDifDolares) <= 0.03M) || (impDifSoles != 0 && Moneda == "01" && Math.Abs(impDifSoles) <= 0.03M))
                            {
                                String numitem = (from x in oVoucher.ListaVouchers
                                                  where x.codCuenta.Substring(0, 1) == "7"
                                                  select x.numItem).Max();

                                //foreach (VoucherItemE item in oVoucher.ListaVouchers)
                                //{
                                //    if (item.numItem == numitem)
                                //    {
                                //        item.impSoles += impDifSoles;
                                //        item.impDolares += impDifDolares;
                                //        break;
                                //    }
                                //}
                                oVoucher.ListaVouchers.Where(x => x.numItem == numitem).Select(x =>
                                                           {
                                                               x.impSoles = x.impSoles + impDifSoles;
                                                               x.impDolares = x.impDolares + impDifDolares;
                                                               x.indCambio = "N";
                                                               return x;
                                                           }).ToList();
                            }

                            totDebeSoles = Decimal.Round((from x in oVoucher.ListaVouchers where x.indDebeHaber == "D" select x.impSoles).Sum(), 2);
                            totDebeDolares = Decimal.Round((from x in oVoucher.ListaVouchers where x.indDebeHaber == "D" select x.impDolares).Sum(), 2);
                            totHaberSoles = Decimal.Round((from x in oVoucher.ListaVouchers where x.indDebeHaber == "H" select x.impSoles).Sum(), 2);
                            totHaberDolares = Decimal.Round((from x in oVoucher.ListaVouchers where x.indDebeHaber == "H" select x.impDolares).Sum(), 2);

                            if (TipoDocumento == "NC")
                            {
                                impDifSoles = totHaberSoles - totDebeSoles;
                                impDifDolares = totHaberDolares - totDebeDolares;
                            }
                            else
                            {
                                impDifSoles = totDebeSoles - totHaberSoles;
                                impDifDolares = totDebeDolares - totHaberDolares;
                            }

                            if (impDifSoles != 0 || impDifDolares != 0)
                            {
                                oVoucher.indEstado = "D";
                            }
                            else
                            {
                                oVoucher.indEstado = "C";
                            }

                            oVoucher.impDebeSoles = totDebeSoles;
                            oVoucher.impHaberSoles = totHaberSoles;
                            oVoucher.impDebeDolares = totDebeDolares;
                            oVoucher.impHaberDolares = totHaberDolares;

                            if (EsAnulado)
                            {
                                oVoucher.tipCambio = 1;
                                oVoucher.indEstado = "A";
                            }

                            oVoucher.numItems = oVoucher.ListaVouchers.Count();

                            #endregion Completando datos de la Cabecera del Voucher

                            new VoucherLN().GrabarVouchers(oVoucher, EnumOpcionGrabar.Insertar);

                            TipoDocumento = String.Empty;
                            EsCabecera = true;
                            oPersona = null;
                            EsAnulado = false;
                            oListita = null;
                        }
                    }

                    #endregion

                    #region Compras

                    if (oListaCompras != null && oListaCompras.Count > 0)
                    {
                        Decimal BaseInafecta = 0;
                        Int32 idBaseInafecta = 0;
                        //Agrupando la lista para saber cuantos vouchers hay...
                        var ListaAgrupada = oListaCompras.GroupBy(x => new { x.idEmpresa, x.idLocal, x.AnioPeriodo, x.MesPeriodo, x.T, x.VOU }).Select(g => g.First()).ToList();
                        //Ordenando la lista agrupada
                        List<ImportacionRVentasE> ListaOrdenada = new List<ImportacionRVentasE>(from x in ListaAgrupada.ToList()
                                                                                                orderby x.idEmpresa, x.idLocal, x.AnioPeriodo, x.MesPeriodo, x.T, x.VOU
                                                                                                select x).ToList();
                        //Recorriendo la lista ordenada para generar los asientos
                        foreach (ImportacionRVentasE itemOrdenado in ListaOrdenada)
                        {
                            if (itemOrdenado.Moneda == "S")
                            {
                                Moneda = "01";
                            }
                            else
                            {
                                Moneda = "02";
                            }

                            //Obteniendo la lista de items de acuerdo al voucher y ordenandolo por Item
                            List<ImportacionRVentasE> oListita = new List<ImportacionRVentasE>(from x in oListaCompras
                                                                                               where x.idEmpresa == itemOrdenado.idEmpresa
                                                                                               && x.idLocal == itemOrdenado.idLocal
                                                                                               && x.AnioPeriodo == itemOrdenado.AnioPeriodo
                                                                                               && x.MesPeriodo == itemOrdenado.MesPeriodo
                                                                                               && x.T == itemOrdenado.T
                                                                                               && x.VOU == itemOrdenado.VOU
                                                                                               orderby x.Item
                                                                                               select x).ToList();

                            Decimal totIgv = oListita.Sum(x => Convert.ToDecimal(x.IGV)); //Para saber si lleva o no IGV

                            foreach (ImportacionRVentasE item in oListita)
                            {
                                #region Cabecera del Voucher

                                if (EsCabecera)
                                {
                                    oVoucher = new VoucherE
                                    {
                                        idEmpresa = idEmpresa,
                                        idLocal = idLocal,
                                        AnioPeriodo = item.AnioPeriodo,
                                        MesPeriodo = item.MesPeriodo,
                                        numVoucher = "0",
                                        idComprobante = item.Libro,
                                        numFile = item.numFile,
                                        idMoneda = Moneda,
                                        fecOperacion = Convert.ToDateTime(item.Fecha),
                                        fecDocumento = Convert.ToDateTime(item.FechaD),
                                        GlosaGeneral = item.Glosa.Trim(),
                                        tipCambio = Convert.ToDecimal(item.TC),
                                        RazonSocial = item.Rs.Trim(),
                                        numDocumentoPresu = String.Empty,
                                        indHojaCosto = "N",
                                        numHojaCosto = String.Empty,
                                        numOrdenCompra = String.Empty,
                                        sistema = "1", //Contabilidad... van directamente a los asientos
                                        EsAutomatico = false,
                                        UsuarioRegistro = Usuario
                                    };

                                    EsCabecera = false;
                                }

                                #endregion Cabecera del Voucher

                                #region Detalle del Voucher

                                ////Obteniendo el Plan de Cuentas...
                                PlanCuentasE oCuenta = oPlanCuentas.Find
                                (
                                    delegate (PlanCuentasE c) { return c.codCuenta == item.Cuenta; }
                                );

                                if (oCuenta == null)
                                {
                                    throw new Exception(String.Format("La cuenta {0} no existe en el Plan Contable. Revise por favor.", item.Cuenta));
                                }

                                List<ParTabla> ListaCoVen = new ParTablaAD().ListarParTablaPorValorEntero(oCuenta.codColumnaCoven.Value);
                                ParTabla par = null;

                                #region Columna Compras y Ventas

                                if (ListaCoVen != null && ListaCoVen.Count > 0)
                                {
                                    par = ListaCoVen.Find
                                    (
                                        delegate (ParTabla cc) { return cc.NemoTecnico == "IGV"; }
                                    );

                                    if (par != null) //Se trata de IGV
                                    {
                                        idPartabla = par.IdParTabla;
                                    }
                                    else
                                    {
                                        par = ListaCoVen.Find
                                        (
                                            delegate (ParTabla cc) { return cc.NemoTecnico == "TOTOT"; }
                                        );

                                        if (par != null) //Se trata del total
                                        {
                                            idPartabla = par.IdParTabla;
                                        }
                                        else //sino de una base imponible
                                        {
                                            if (totIgv > 0)
                                            {
                                                par = ListaCoVen.Find
                                                (
                                                    delegate (ParTabla cc) { return cc.NemoTecnico == "BAIMP"; }
                                                );

                                                //Revisando si hay alguna Base inafecta
                                                if (BaseInafecta > 0)
                                                {
                                                    ParTabla inafecto = ListaCoVen.Find
                                                    (
                                                        delegate (ParTabla cc) { return cc.NemoTecnico == "BAINA"; }
                                                    );

                                                    if (inafecto != null)
                                                    {
                                                        idBaseInafecta = inafecto.IdParTabla;
                                                    }
                                                }
                                            }
                                            else
                                            {
                                                par = ListaCoVen.Find
                                                (
                                                    delegate (ParTabla cc) { return cc.NemoTecnico == "BAINA"; }
                                                );
                                            }

                                            if (par != null)
                                            {
                                                idPartabla = BaseImponible = par.IdParTabla;
                                            }
                                            else
                                            {
                                                idPartabla = 0;
                                            }
                                        }
                                    }

                                    //Para capturar la base inafecta si en caso hubiese
                                    if (BaseInafecta == 0 && item.BaseNoImponible > 0)
                                    {
                                        BaseInafecta = item.BaseNoImponible;
                                    }
                                }
                                else
                                {
                                    throw new Exception(String.Format("La cuenta {0} no tiene tipo de columna de Compra y Venta.", item.Cuenta));
                                }

                                #endregion Columna Compras y Ventas

                                #region Si solicita auxiliar

                                if (oCuenta.indSolicitaAnexo == "S")
                                {
                                    if (Ruc_ != item.RUC)//oPersona == null || idPersona_ == null)
                                    {
                                        if (item.RUC.Trim() != "99999999999")
                                        {
                                            oPersona = new PersonaAD().ObtenerPersonaPorNroRuc(item.RUC);

                                            if (oPersona != null)
                                            {
                                                idPersona_ = oPersona.IdPersona;
                                            }
                                            else
                                            {
                                                oPersona = CrearAuxiliarRVentas(idEmpresa, item.Rs.Trim(), item.RUC.Trim(), Usuario, item.TDoci.Trim(), "P");
                                                idPersona_ = oPersona.IdPersona;
                                            }
                                        }
                                        else
                                        {
                                            if (oParametroVen == null)
                                            {
                                                throw new Exception("No se ha configurado el Parámetro de Clientes Varios en los Parámetros de Ventas.");
                                            }
                                            else
                                            {
                                                idPersona_ = oParametroVen.ClienteVarios;
                                            }
                                        }
                                    }

                                    Ruc_ = item.RUC.Trim();

                                    if (item.Glosa.Contains("ANULADO") || item.Glosa.Contains("ANULADA"))
                                    {
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
                                    idPersona_ = null;
                                    Ruc_ = String.Empty;

                                    if (item.Glosa.Contains("ANULADO") || item.Glosa.Contains("ANULADA"))
                                    {
                                        EsAnulado = true;
                                    }
                                }

                                #endregion

                                #region Si solicita Documento

                                if (oCuenta.indSolicitaDcto == "S")
                                {
                                    switch (item.Doc.Trim())
                                    {
                                        case "12":
                                            idDoc = "TK";
                                            break;
                                        case "01":
                                            idDoc = "FC";
                                            break;
                                        case "03":
                                            idDoc = "BR";
                                            break;
                                        case "04":
                                            idDoc = "LI";
                                            break;
                                        case "07":
                                            idDoc = "CR";
                                            break;
                                        case "08":
                                            idDoc = "DR";
                                            break;
                                        default:
                                            throw new Exception("Tipo de documento por configurar.");
                                    }

                                    if (String.IsNullOrWhiteSpace(TipoDocumento))
                                    {
                                        TipoDocumento = idDoc;
                                    }

                                    List<String> ListaDoc = new List<String>(item.Numero.Split('-'));
                                    serDoc = ListaDoc[0].Trim();
                                    numDoc = ListaDoc[1].Trim();

                                    if (String.IsNullOrWhiteSpace(serDoc))
                                    {
                                        throw new Exception("El documento no tiene serie.");
                                    }

                                    if (String.IsNullOrWhiteSpace(numDoc))
                                    {
                                        throw new Exception("El documento no tiene número.");
                                    }

                                    fec = Convert.ToDateTime(item.Fecha);
                                    fecVen = item.FechaV;

                                    if (!String.IsNullOrWhiteSpace(item.RNumero.Trim()))
                                    {
                                        switch (item.RTdoc.Trim())
                                        {
                                            case "12":
                                                idDocRef = "TK";
                                                break;
                                            case "01":
                                                idDocRef = "FV";
                                                break;
                                            case "03":
                                                idDocRef = "BV";
                                                break;
                                            case "08":
                                                idDocRef = "NC";
                                                break;
                                            case "09":
                                                idDocRef = "ND";
                                                break;
                                            default:
                                                throw new Exception("Tipo de documento de referencia por configurar.");
                                        }

                                        ListaDoc = new List<String>(item.RNumero.Split('-'));
                                        serDocRef = ListaDoc[0].Trim();
                                        numDocRef = ListaDoc[1].Trim();
                                        fecRef = Convert.ToDateTime(item.RFecha);
                                    }
                                    else
                                    {
                                        idDocRef = String.Empty;
                                        serDocRef = String.Empty;
                                        numDocRef = String.Empty;
                                        fecRef = null;
                                    }
                                }
                                else
                                {
                                    idDoc = String.Empty;
                                    serDoc = String.Empty;
                                    numDoc = String.Empty;
                                    fec = null;
                                    fecVen = null;
                                    idDocRef = String.Empty;
                                    serDocRef = String.Empty;
                                    numDocRef = String.Empty;
                                    fecRef = null;
                                }

                                #endregion

                                #region Centro de Costos

                                if (oCuenta.indSolicitaCentroCosto == "S")
                                {
                                                       
                                    if (String.IsNullOrEmpty(oCuenta.idCCostos))
                                    {
                                        throw new Exception(String.Format("La cuenta {0} no existe se ha definido C.Costo. Reviselo por favor.", item.Cuenta));
                                    }

                                    cCostos = oCuenta.idCCostos;
                                }
                                else
                                {
                                    cCostos = String.Empty;
                                }

                                #endregion

                                VoucherItemE oItemVoucher = new VoucherItemE
                                {
                                    idEmpresa = idEmpresa,
                                    idLocal = idLocal,
                                    AnioPeriodo = item.AnioPeriodo,
                                    MesPeriodo = item.MesPeriodo,
                                    numVoucher = String.Empty,
                                    idComprobante = item.Libro,
                                    numFile = item.numFile,
                                    numItem = String.Format("{0:00000}", item.Item),
                                    idPersona = idPersona_,
                                    idMoneda = Moneda,
                                    tipCambio = EsAnulado ? 1 : Convert.ToDecimal(item.TC),
                                    indCambio = "S",
                                    idCCostos = cCostos,
                                    numVerPlanCuentas = oNumVerPlanCuentas.numVerPlanCuentas,
                                    codCuenta = item.Cuenta.Trim(),
                                    desGlosa = item.Glosa.Trim(),
                                    fecDocumento = fec,
                                    fecVencimiento = fecVen,
                                    idDocumento = idDoc,
                                    serDocumento = serDoc,
                                    numDocumento = numDoc,
                                    fecDocumentoRef = fecRef,
                                    idDocumentoRef = idDocRef,
                                    serDocumentoRef = serDocRef,
                                    numDocumentoRef = numDocRef,
                                    indDebeHaber = item.DebeHaber,
                                    //impSoles = itemReal.MontoSoles,
                                    //impDolares = itemReal.MontoDolares,
                                    indAutomatica = "N",
                                    CorrelativoAjuste = String.Empty,
                                    codFteFin = String.Empty,
                                    codProgramaCred = String.Empty,
                                    indMovimientoAnterior = String.Empty,
                                    tipPartidaPresu = String.Empty,
                                    codPartidaPresu = String.Empty,
                                    numDocumentoPresu = String.Empty,
                                    codColumnaCoven = idPartabla,
                                    depAduanera = 0,
                                    AnioDua = String.Empty,
                                    nroDua = String.Empty,
                                    flagDetraccion = "N",
                                    numDetraccion = String.Empty,
                                    fecDetraccion = null,
                                    tipDetraccion = String.Empty,
                                    TasaDetraccion = 0,
                                    MontoDetraccion = 0,
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

                                if (oItemVoucher.indDebeHaber == "D")
                                {
                                    if (oItemVoucher.idMoneda == "01")
                                    {
                                        oItemVoucher.impSoles = item.Debe;
                                        oItemVoucher.impDolares = Decimal.Round(item.Debe / oItemVoucher.tipCambio, 2);
                                    }
                                    else
                                    {
                                        oItemVoucher.impDolares = item.Debe;
                                        oItemVoucher.impSoles = Decimal.Round(item.Debe * oItemVoucher.tipCambio, 2);
                                    }
                                }
                                else
                                {
                                    if (oItemVoucher.idMoneda == "01")
                                    {
                                        oItemVoucher.impSoles = Convert.ToDecimal(item.Haber);
                                        oItemVoucher.impDolares = Decimal.Round(item.Haber / oItemVoucher.tipCambio, 2);
                                    }
                                    else
                                    {
                                        oItemVoucher.impDolares = Convert.ToDecimal(item.Haber);
                                        oItemVoucher.impSoles = Decimal.Round(item.Haber * oItemVoucher.tipCambio, 2);
                                    }
                                }

                                oVoucher.ListaVouchers.Add(oItemVoucher);
                                oItemVoucher = null;

                                #endregion 
                            }

                            #region Actualizando Columna CoVen

                            if (BaseInafecta > 0)
                            {
                                foreach (VoucherItemE item in oVoucher.ListaVouchers)
                                {
                                    if (item.idMoneda == Moneda)
                                    {
                                        if (item.impSoles == BaseInafecta && idBaseInafecta > 0)
                                        {
                                            item.codColumnaCoven = idBaseInafecta;
                                        }
                                    }
                                    else
                                    {
                                        if (item.impDolares == BaseInafecta && idBaseInafecta > 0)
                                        {
                                            item.codColumnaCoven = idBaseInafecta;
                                        }
                                    }
                                }
                            }

                            #endregion

                            #region Completando datos de la Cabecera del Voucher

                            Decimal totDebeSoles = Decimal.Round((from x in oVoucher.ListaVouchers where x.indDebeHaber == "D" select x.impSoles).Sum(), 2);
                            Decimal totDebeDolares = Decimal.Round((from x in oVoucher.ListaVouchers where x.indDebeHaber == "D" select x.impDolares).Sum(), 2);
                            Decimal totHaberSoles = Decimal.Round((from x in oVoucher.ListaVouchers where x.indDebeHaber == "H" select x.impSoles).Sum(), 2);
                            Decimal totHaberDolares = Decimal.Round((from x in oVoucher.ListaVouchers where x.indDebeHaber == "H" select x.impDolares).Sum(), 2);
                            Decimal impDifSoles = 0, impDifDolares = 0;

                            if (TipoDocumento == "NC")
                            {
                                impDifSoles = totHaberSoles - totDebeSoles;
                                impDifDolares = totHaberDolares - totDebeDolares;
                            }
                            else
                            {
                                impDifSoles = totDebeSoles - totHaberSoles;
                                impDifDolares = totDebeDolares - totHaberDolares;
                            }

                            if ((impDifSoles != 0 && Moneda == "02" && Math.Abs(impDifSoles) <= 0.03M) || (impDifDolares != 0 && Moneda == "01" && Math.Abs(impDifDolares) <= 0.03M) || (impDifSoles != 0 && Moneda == "01" && Math.Abs(impDifSoles) <= 0.03M))
                            {
                                String numitem = (from x in oVoucher.ListaVouchers
                                                  where x.codColumnaCoven == BaseImponible
                                                  select x.numItem).Max();

                                if (impDifSoles != 0)
                                {
                                    oVoucher.ListaVouchers.Where(x => x.numItem == numitem).Select(x =>
                                    {
                                        x.impSoles = x.impSoles + (impDifSoles * -1);
                                        x.indCambio = "N";
                                        return x;
                                    }).ToList();
                                }

                                if (impDifDolares != 0)
                                {
                                    oVoucher.ListaVouchers.Where(x => x.numItem == numitem).Select(x =>
                                    {
                                        x.impDolares = x.impDolares + (impDifDolares * -1);
                                        x.indCambio = "N";
                                        return x;
                                    }).ToList();
                                }
                            }

                            totDebeSoles = Decimal.Round((from x in oVoucher.ListaVouchers where x.indDebeHaber == "D" select x.impSoles).Sum(), 2);
                            totDebeDolares = Decimal.Round((from x in oVoucher.ListaVouchers where x.indDebeHaber == "D" select x.impDolares).Sum(), 2);
                            totHaberSoles = Decimal.Round((from x in oVoucher.ListaVouchers where x.indDebeHaber == "H" select x.impSoles).Sum(), 2);
                            totHaberDolares = Decimal.Round((from x in oVoucher.ListaVouchers where x.indDebeHaber == "H" select x.impDolares).Sum(), 2);

                            if (TipoDocumento == "NC")
                            {
                                impDifSoles = totHaberSoles - totDebeSoles;
                                impDifDolares = totHaberDolares - totDebeDolares;
                            }
                            else
                            {
                                impDifSoles = totDebeSoles - totHaberSoles;
                                impDifDolares = totDebeDolares - totHaberDolares;
                            }

                            if (impDifSoles != 0 || impDifDolares != 0)
                            {
                                oVoucher.indEstado = "D";
                            }
                            else
                            {
                                oVoucher.indEstado = "C";
                            }
                            
                            var DocumentoAgrupado = oVoucher.ListaVouchers.GroupBy(x => new { x.idDocumento, x.serDocumento, x.numDocumento }).Select(g => g.First()).ToList();

                            if (DocumentoAgrupado.ToList().Count > 1)
                            {
                                oVoucher.numDocumentoPresu = "VARIOS";
                            }
                            else
                            {
                                oVoucher.numDocumentoPresu = DocumentoAgrupado.ToList()[0].idDocumento + " " + DocumentoAgrupado.ToList()[0].serDocumento + "-" + DocumentoAgrupado.ToList()[0].numDocumento;
                            }

                            if (EsAnulado)
                            {
                                oVoucher.tipCambio = 1;
                                oVoucher.indEstado = "A";
                            }

                            oVoucher.numItems = oVoucher.ListaVouchers.Count();

                            if (Moneda == "01")
                            {
                                oVoucher.impMonOrigDeb = totDebeSoles;
                                oVoucher.impMonOrigHab = totHaberSoles;
                            }
                            else
                            {
                                oVoucher.impMonOrigDeb = totDebeDolares;
                                oVoucher.impMonOrigHab = totDebeDolares;
                            }

                            #endregion Completando datos de la Cabecera del Voucher

                            #region Cuentas Automáticas

                            List<VoucherItemE> oListaVoucherItems = new List<VoucherItemE>(oVoucher.ListaVouchers);
                            Int32 corre = Convert.ToInt32((from x in oListaVoucherItems
                                                           select x.numItem).Max());

                            foreach (VoucherItemE item in oListaVoucherItems)
                            {
                                if (item.indCuentaGastos == "S")
                                {
                                    if (!String.IsNullOrEmpty(item.codCuentaDestino))
                                    {
                                        corre++;
                                        oVoucher.ListaVouchers.Add(CuentaAutomaticaRVentas(item, corre, item.codCuentaDestino));
                                    }

                                    if (!String.IsNullOrEmpty(item.codCuentaTransferencia))
                                    {
                                        corre++;
                                        oVoucher.ListaVouchers.Add(CuentaAutomaticaRVentas(item, corre, item.codCuentaTransferencia));
                                    }
                                }
                            }

                            #endregion

                            //Actualizando totales
                            oVoucher.impDebeSoles = Decimal.Round((from x in oVoucher.ListaVouchers where x.indDebeHaber == "D" select x.impSoles).Sum(), 2);
                            oVoucher.impHaberSoles = Decimal.Round((from x in oVoucher.ListaVouchers where x.indDebeHaber == "H" select x.impSoles).Sum(), 2);
                            oVoucher.impDebeDolares = Decimal.Round((from x in oVoucher.ListaVouchers where x.indDebeHaber == "D" select x.impDolares).Sum(), 2);
                            oVoucher.impHaberDolares = Decimal.Round((from x in oVoucher.ListaVouchers where x.indDebeHaber == "H" select x.impDolares).Sum(), 2);
                                       
                            new VoucherLN().GrabarVouchers(oVoucher, EnumOpcionGrabar.Insertar);

                            TipoDocumento = String.Empty;
                            EsCabecera = true;
                            oPersona = null;
                            EsAnulado = false;
                            oListita = null;
                            BaseImponible = 0;
                            BaseInafecta = 0;
                            idBaseInafecta = 0;
                        }
                    }

                    #endregion

                    oPlanCuentas = null;
                    oNumVerPlanCuentas = null;
                    new VoucherAD().TriggerVouchers(false); //Habilitar los Trigger
                    //Cerrando la transaccion
                    oTrans.Complete();
                    FilasDevueltas++;
                }

                return FilasDevueltas;
            }
            catch (SqlException ex)
            {
                //En caso de error se vuelven habilitar los triggers
                new VoucherAD().TriggerVouchers(false);

                SqlError err = ex.Errors[0];
                StringBuilder mensaje = new StringBuilder();

                switch (err.Number)
                {
                    default:
                        //mensaje.Append("Linea: " + Linea.ToString() + " Voucher: Diario " + DiarioErr + " File " + FileErr + " Número " + numVoucherErr + "\n");
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
                //En caso de error se vuelven habilitar los triggers
                new VoucherAD().TriggerVouchers(false);
                //String Mensajito = "Linea: " + Linea.ToString() + " Voucher: Diario " + DiarioErr + " File " + FileErr + " Número " + numVoucherErr + "\n";
                //throw new Exception(Mensajito + ex2.Message);
                throw new Exception(ex2.Message);
            }
        }

        #region Privadas

        private Persona CrearAuxiliarRVentas(Int32 idEmpresa, String RazonSocial, String RUC, String Usuario, String TipoDoc, String Tipo) //C=Clientes P=Proveedor
        {
            try
            {
                Persona oPersona = null;

                using (TransactionScope oTrans = new TransactionScope())
                {
                    List<ParTabla> oListaTipoPersona = new ParTablaAD().ListarParTablaPorNemo("TIPPER");
                    List<ParTabla> oListaTipoDocumento = new ParTablaAD().ListarParTablaPorNemo("TIPDOCPER");
                    ParTabla oTipoPer = null;
                    ParTabla oTipoDoc = null;
                    Int32 TipoPersona = 0;
                    Int32 TipoDocPersona = 0;

                    #region Tipo Persona

                    if (!String.IsNullOrWhiteSpace(RUC))
                    {
                        if (TipoDoc == "6")
                        {
                            if (RUC.Substring(0, 2) == "20")
                            {
                                oTipoPer = oListaTipoPersona.Find
                                (
                                    delegate (ParTabla p) { return p.NemoTecnico == "PERJU"; }
                                );
                            }
                            else
                            {
                                oTipoPer = oListaTipoPersona.Find
                                (
                                    delegate (ParTabla p) { return p.NemoTecnico == "PERCR"; }
                                );
                            }
                        }

                        if (TipoDoc == "1")
                        {
                            if (RUC.Length == 11)
                            {
                                if (RUC.Substring(0, 2) == "20")
                                {
                                    oTipoPer = oListaTipoPersona.Find
                                    (
                                        delegate (ParTabla p) { return p.NemoTecnico == "PERJU"; } //Persona Jurídica
                                    );
                                }
                                else
                                {
                                    oTipoPer = oListaTipoPersona.Find
                                    (
                                        delegate (ParTabla p) { return p.NemoTecnico == "PERCR"; } //Persona Natural con RUC
                                    );
                                }
                            }
                            else if (RUC.Length == 8)
                            {
                                oTipoPer = oListaTipoPersona.Find
                                (
                                    delegate (ParTabla cc) { return cc.NemoTecnico == "PERSR"; }  //Persona Natural sin RUC
                                );
                            }
                            else
                            {
                                oTipoPer = oListaTipoPersona.Find
                                (
                                    delegate (ParTabla cc) { return cc.NemoTecnico == "OTR"; }  //Otro
                                );
                            }
                        }
                    }
                    else
                    {
                        oTipoPer = oListaTipoPersona.Find
                        (
                            delegate (ParTabla cc) { return cc.NemoTecnico == "OTR"; }  //Otro
                        );
                    }

                    #endregion

                    #region Tipo Documento

                    if (String.IsNullOrWhiteSpace(RUC))
                    {
                        if (TipoDoc == "6")
                        {
                            oTipoDoc = oListaTipoDocumento.Find
                            (
                                delegate (ParTabla cc) { return cc.NemoTecnico == "PERRUC"; }
                            );
                        }

                        if (TipoDoc == "1")
                        {
                            if (RUC.Length == 11)
                            {
                                oTipoDoc = oListaTipoDocumento.Find
                                (
                                    delegate (ParTabla cc) { return cc.NemoTecnico == "PERRUC"; } //Ruc
                                );
                            }
                            else if (RUC.Length == 8)
                            {
                                oTipoDoc = oListaTipoDocumento.Find
                                (
                                    delegate (ParTabla cc) { return cc.NemoTecnico == "PERDNI"; } //Dni
                                );
                            }
                            else
                            {
                                oTipoDoc = oListaTipoDocumento.Find
                                (
                                    delegate (ParTabla cc) { return cc.NemoTecnico == "PEROTR"; }  //Otro
                                );
                            }
                        }
                    }
                    else
                    {
                        oTipoDoc = oListaTipoDocumento.Find
                        (
                            delegate (ParTabla cc) { return cc.NemoTecnico == "PEROTR"; }  //Otro
                        );
                    }

                    #endregion

                    if (oTipoPer != null)
                    {
                        TipoPersona = oTipoPer.IdParTabla;
                    }

                    if (oTipoDoc != null)
                    {
                        TipoDocPersona = oTipoDoc.IdParTabla;
                    }

                    //Insertando la Persona
                    oPersona = new Persona()
                    {
                        TipoPersona = TipoPersona,
                        RazonSocial = RazonSocial,
                        RUC = RUC,
                        ApePaterno = String.Empty,
                        ApeMaterno = String.Empty,
                        Nombres = String.Empty,
                        TipoDocumento = TipoDocPersona,
                        NroDocumento = RUC,
                        PrincipalContribuyente = false,
                        AgenteRetenedor = false,
                        UsuarioRegistro = Usuario
                    };

                    oPersona = new PersonaAD().InsertarPersona(oPersona);

                    //Insertando el auxiliar
                    if (Tipo == "C")
                    {
                        ClienteE oCliente = new ClienteE()
                        {
                            idPersona = oPersona.IdPersona,
                            idEmpresa = idEmpresa,
                            SiglaComercial = RazonSocial,
                            TipoCliente = 104006,
                            indEstado = false,
                            UsuarioRegistro = Usuario
                        };

                        new ClienteAD().InsertarCliente(oCliente);
                    }
                    else
                    {
                        ProveedorE oProveedor = new ProveedorE()
                        {
                            IdPersona = oPersona.IdPersona,
                            IdEmpresa = idEmpresa,
                            SiglaComercial = RazonSocial,
                            TipoProveedor = 283001,
                            indBaja = "N",
                            UsuarioRegistro = Usuario
                        };

                        new ProveedorAD().InsertarProveedor(oProveedor);
                    }

                    oTrans.Complete();
                }

                return oPersona;
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

        private VoucherItemE CuentaAutomaticaRVentas(VoucherItemE oItemTemp, Int32 numItem, String Cuenta)
        {
            String DebeHaber = String.Empty;

            if (oItemTemp.codCuentaDestino == Cuenta)
            {
                DebeHaber = oItemTemp.indDebeHaber;
            }

            if (oItemTemp.codCuentaTransferencia == Cuenta)
            {
                if (oItemTemp.indDebeHaber == "D")
                {
                    DebeHaber = "H";
                }
                else
                {
                    DebeHaber = "D";
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
                idPersona = null,
                idMoneda = oItemTemp.idMoneda,
                tipCambio = oItemTemp.tipCambio,
                indCambio = "S",
                idCCostos = String.Empty,
                numVerPlanCuentas = oItemTemp.numVerPlanCuentas,
                codCuenta = Cuenta,
                desGlosa = oItemTemp.desGlosa,
                fecDocumento = null,
                fecVencimiento = null,
                idDocumento = String.Empty,
                serDocumento = String.Empty,
                numDocumento = String.Empty,
                fecDocumentoRef = null,
                idDocumentoRef = String.Empty,
                serDocumentoRef = String.Empty,
                numDocumentoRef = String.Empty,
                indDebeHaber = DebeHaber,
                impSoles = oItemTemp.impSoles,
                impDolares = oItemTemp.impDolares,
                indAutomatica = "S",
                CorrelativoAjuste = String.Empty,
                codFteFin = String.Empty,
                codProgramaCred = String.Empty,
                indMovimientoAnterior = String.Empty,
                tipPartidaPresu = String.Empty,
                codPartidaPresu = String.Empty,
                numDocumentoPresu = String.Empty,
                codColumnaCoven = null,
                depAduanera = 0,
                AnioDua = String.Empty,
                nroDua = String.Empty,
                flagDetraccion = "N",
                numDetraccion = String.Empty,
                fecDetraccion = null,
                tipDetraccion = String.Empty,
                TasaDetraccion = 0M,
                MontoDetraccion = 0M,
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
                UsuarioRegistro = oItemTemp.UsuarioRegistro
            };

            return oItemVoucher;
        }

        #endregion

    }
}
