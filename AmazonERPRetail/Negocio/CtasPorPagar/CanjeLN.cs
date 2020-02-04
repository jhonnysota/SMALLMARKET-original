using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Transactions;
using System.Linq;

using Entidades.CtasPorPagar;
using Entidades.Contabilidad;
using Entidades.Tesoreria;
using AccesoDatos.CtasPorPagar;
using AccesoDatos.Contabilidad;
using AccesoDatos.Tesoreria;
using Negocio.Contabilidad;
using Infraestructura.Enumerados;
using Infraestructura.Extensores;

namespace Negocio.CtasPorPagar
{
    public class CanjeLN
    {

        public CanjeE GrabarCanje(CanjeE oCanje, EnumOpcionGrabar OpcionGrabar)
        {
            try
            {
                using (TransactionScope oTrans = new TransactionScope())
                {
                    switch (OpcionGrabar)
                    {
                        case EnumOpcionGrabar.Actualizar:

                            #region Actualización
                            
                            //Actualizando la cabecera
                            oCanje.numLetras = oCanje.ListaLetrasItem == null ? 0 : oCanje.ListaLetrasItem.Count;
                            new CanjeAD().ActualizarCanje(oCanje);

                            //Revisando si hay documentos por eliminar
                            if (oCanje.ListaDocsEliminados != null)
                            {
                                foreach (CanjeDctoItemE item in oCanje.ListaDocsEliminados)
                                {
                                    new CanjeDctoItemAD().EliminarCanjeDctoItem(item.idCanje, item.idItemDcmto);
                                }
                            }

                            //Insertar el detalle de los documentos
                            if (oCanje.ListaCanjeDctoItem != null)
                            {
                                foreach (CanjeDctoItemE oitem in oCanje.ListaCanjeDctoItem)
                                {
                                    if (oitem.Opcion == (Int32)EnumOpcionGrabar.Insertar)
                                    {
                                        oitem.idEmpresa = oCanje.idEmpresa;
                                        oitem.idLocal = oCanje.idLocal;
                                        oitem.idCanje = oCanje.idCanje;

                                        new CanjeDctoItemAD().InsertarCanjeDctoItem(oitem);
                                    }
                                }
                            }

                            //Revisando si hay letras por eliminar
                            if (oCanje.ListaLetrasEliminados != null)
                            {
                                foreach (LetrasItemE item in oCanje.ListaLetrasEliminados)
                                {
                                    new LetrasItemAD().EliminarLetrasItem(item.idCanje, item.idItemLetra);
                                }
                            }

                            //Insertando en las nuevas letras...
                            if (oCanje.ListaLetrasItem != null)
                            {
                                foreach (LetrasItemE oitem in oCanje.ListaLetrasItem)
                                {
                                    if (oitem.Opcion == (Int32)EnumOpcionGrabar.Insertar)
                                    {
                                        oitem.idEmpresa = oCanje.idEmpresa;
                                        oitem.idLocal = oCanje.idLocal;
                                        oitem.idCanje = oCanje.idCanje;

                                        new LetrasItemAD().InsertarLetrasItem(oitem);
                                    }
                                }
                            } 

                            #endregion

                            break;
                        case EnumOpcionGrabar.Insertar:

                            #region Insertar

                            //Insertando
                            oCanje.numCanje = new CanjeAD().GenerarNumCanjeLetra(oCanje.idEmpresa, oCanje.FechaCanje.ToString("MM"), oCanje.FechaCanje.ToString("yyyy"));
                            oCanje.numLetras = oCanje.ListaLetrasItem == null ? 0 : oCanje.ListaLetrasItem.Count;
                            oCanje = new CanjeAD().InsertarCanje(oCanje);

                            //Lista 
                            if (oCanje.ListaCanjeDctoItem != null && oCanje.ListaCanjeDctoItem.Count > 0)
                            {
                                foreach (CanjeDctoItemE oitem in oCanje.ListaCanjeDctoItem)
                                {
                                    oitem.idEmpresa = oCanje.idEmpresa;
                                    oitem.idLocal = oCanje.idLocal;
                                    oitem.idCanje = oCanje.idCanje;

                                    new CanjeDctoItemAD().InsertarCanjeDctoItem(oitem);
                                }
                            }

                            //Lista 
                            if (oCanje.ListaLetrasItem != null && oCanje.ListaLetrasItem.Count > 0)
                            {
                                foreach (LetrasItemE oitem in oCanje.ListaLetrasItem)
                                {
                                    oitem.idEmpresa = oCanje.idEmpresa;
                                    oitem.idLocal = oCanje.idLocal;
                                    oitem.idCanje = oCanje.idCanje;

                                    new LetrasItemAD().InsertarLetrasItem(oitem);
                                }
                            }

                            #endregion

                            break;
                        default:
                            break;
                    }

                    oTrans.Complete();
                }

                return oCanje;
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

        public CanjeE InsertarCanje(CanjeE canje)
        {
            try
            {
                return new CanjeAD().InsertarCanje(canje);
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

        public CanjeE ActualizarCanje(CanjeE canje)
        {
            try
            {
                return new CanjeAD().ActualizarCanje(canje);
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

        public int EliminarCanje(Int32 idEmpresa, Int32 idLocal, Int32 idCanje)
        {
            try
            {
                return new CanjeAD().EliminarCanje(idEmpresa, idLocal, idCanje);
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

        public List<CanjeE> ListarCanje(Int32 idEmpresa, Int32 idLocal, Int32 idPersona, DateTime fecIni, DateTime fecFin)
        {
            try
            {
                return new CanjeAD().ListarCanje(idEmpresa, idLocal, idPersona, fecIni, fecFin);
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

        public CanjeE ObtenerCanje(Int32 idCanje)
        {
            try
            {
                return new CanjeAD().ObtenerCanje(idCanje);
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

        public CanjeE ObtenerCanjeCompleto(Int32 idCanje, Boolean ListarDoc = true, Boolean ListarLetras = true)
        {
            try
            {
                CanjeE oCanje = new CanjeAD().ObtenerCanje(idCanje);

                if (oCanje != null)
                {
                    if (ListarDoc)
                    {
                        oCanje.ListaCanjeDctoItem = new CanjeDctoItemAD().ListarCanjeDctoItem(idCanje);
                    }

                    if (ListarLetras)
                    {
                        oCanje.ListaLetrasItem = new LetrasItemAD().ListarLetrasItem(idCanje);
                    }
                }

                return oCanje;
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

        public int CambiarEstadoCanje(Int32 idCanje, String Estado, String Usuario)
        {
            try
            {
                return new CanjeAD().CambiarEstadoCanje(idCanje, Estado, Usuario);
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

        public VoucherE CerrarCanje(CanjeE oCanje, ParametrosContaE oConParametros, String Usuario)
        {
            try
            {
                VoucherE oVoucher = null;

                using (TransactionScope oTrans = new TransactionScope())
                {
                    String Libro = oConParametros.DiarioLetra;
                    String numFile = oConParametros.FileLetra;
                    String Glosa = String.Empty;
                    String NumeroVoucher = "0";
                    Boolean ExisteVoucher = false;
                    String MesPeriodo = oCanje.FechaCanje.ToString("MM");
                    String AnioPeriodo = oCanje.FechaCanje.ToString("yyyy");
                    Decimal TipoCambio = oCanje.TipoCambio;

                    Glosa = "CANJE N° " + oCanje.numCanje + " " + MesPeriodo + "-" + AnioPeriodo;

                    #region Cabecera

                    if (!String.IsNullOrWhiteSpace(oCanje.idComprobante) && !String.IsNullOrWhiteSpace(oCanje.numFile) && !String.IsNullOrWhiteSpace(oCanje.numVoucher))
                    {
                        VoucherE oVoucherTmp = new VoucherAD().ObtenerVoucherPorCodigo(oCanje.idEmpresa, oCanje.idLocal, AnioPeriodo, MesPeriodo, oCanje.numVoucher, Libro, numFile);

                        if (oVoucherTmp != null)
                        {
                            ExisteVoucher = true;
                            NumeroVoucher = oVoucherTmp.numVoucher;
                        }
                        else
                        {
                            NumeroVoucher = oCanje.numVoucher;
                        }
                    }

                    oVoucher = new VoucherE()
                    {
                        idEmpresa = oCanje.idEmpresa,
                        idLocal = oCanje.idLocal,
                        AnioPeriodo = AnioPeriodo,
                        MesPeriodo = MesPeriodo,
                        numVoucher = NumeroVoucher,
                        idComprobante = Libro,
                        numFile = numFile,
                        fecTransferencia = null,
                        numItems = 0,
                        idMoneda = "01",
                        fecOperacion = oCanje.FechaCanje,
                        fecDocumento = oCanje.FechaCanje,
                        impDebeSoles = 0,
                        impHaberSoles = 0,
                        impDebeDolares = 0,
                        impHaberDolares = 0,
                        impMonOrigDeb = 0,
                        impMonOrigHab = 0,
                        GlosaGeneral = Glosa,
                        indEstado = "C",
                        tipCambio = TipoCambio,
                        RazonSocial = "VARIOS",
                        numDocumentoPresu = "LC-" + MesPeriodo + AnioPeriodo,
                        indHojaCosto = "N",
                        numHojaCosto = String.Empty,
                        numOrdenCompra = String.Empty,
                        sistema = "9", //Ctas por pagar
                        EsAutomatico = true
                    };

                    #endregion

                    #region Detalle

                    VoucherItemE oLinea = null;
                    PlanCuentasE oCuentaContable = null;
                    Int32 numItem = 0;
                    String CuentaTmp = String.Empty;
                    Int32? idPersona = 0;
                    String idDocumento = String.Empty;
                    String Serie = String.Empty;
                    String numDocumento = String.Empty;
                    String idCCostos = String.Empty;
                    String indCuentaGastos_ = "N";

                    #region Documentos

                    foreach (CanjeDctoItemE item in oCanje.ListaCanjeDctoItem)
                    {
                        if (CuentaTmp != item.codCuenta)
                        {
                            oCuentaContable = new PlanCuentasAD().ObtenerPlanCuentasPorCodigo(oCanje.idEmpresa, item.numVerPlanCuentas, item.codCuenta);
                        }

                        if (oCuentaContable != null)
                        {
                            if (oCuentaContable.indSolicitaAnexo == "S")
                            {
                                if (item.idPersona != 0)
                                {
                                    idPersona = item.idPersona;
                                }
                                else
                                {
                                    idPersona = null;
                                }
                            }
                            else
                            {
                                idPersona = null;
                            }

                            if (oCuentaContable.indSolicitaDcto == "S")
                            {
                                idDocumento = item.idDocumento;
                                Serie = item.serDocumento;
                                numDocumento = item.numDocumento;
                            }
                            else
                            {
                                idDocumento = String.Empty;
                                Serie = String.Empty;
                                numDocumento = String.Empty;
                            }

                            idCCostos = String.Empty;
                            indCuentaGastos_ = oCuentaContable.indCuentaGastos;
                        }

                        numItem++;

                        oLinea = new VoucherItemE
                        {
                            numItem = String.Format("{0:00000}", numItem),
                            idPersona = idPersona,
                            idMoneda = "01",
                            tipCambio = TipoCambio,
                            indCambio = "S",
                            idCCostos = idCCostos,
                            numVerPlanCuentas = item.numVerPlanCuentas,
                            codCuenta = item.codCuenta,
                            desGlosa = Glosa,
                            fecDocumento = item.FechaDocumento,
                            fecVencimiento = item.FechaVencimiento,
                            idDocumento = idDocumento,
                            serDocumento = Serie,
                            numDocumento = numDocumento,
                            fecDocumentoRef = null,
                            idDocumentoRef = String.Empty,
                            serDocumentoRef = String.Empty,
                            numDocumentoRef = String.Empty,
                            indDebeHaber = item.indDebeHaber,
                            impSoles = item.MontoSoles,
                            impDolares = item.MontoDolares,
                            indAutomatica = "N",
                            CorrelativoAjuste = String.Empty,
                            codFteFin = String.Empty,
                            codProgramaCred = String.Empty,
                            indMovimientoAnterior = String.Empty,
                            tipPartidaPresu = String.Empty,
                            codPartidaPresu = String.Empty,
                            numDocumentoPresu = item.idDocumento + " " + Serie + "-" + NumeroVoucher,
                            codColumnaCoven = null,
                            depAduanera = null,
                            nroDua = String.Empty,
                            AnioDua = String.Empty,
                            flagDetraccion = "N",
                            numDetraccion = String.Empty,
                            fecDetraccion = null,
                            tipDetraccion = String.Empty,
                            TasaDetraccion = 0,
                            MontoDetraccion = 0,
                            indPagoDetra = true,
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
                            codMedioPago = null,
                            idCampana = null,
                            idConceptoGasto = null,
                            idAccion = String.Empty,
                            idCtaCte = null,
                            idCtaCteItem = null,
                            UsuarioRegistro = Usuario,

                            indCuentaGastos = indCuentaGastos_,
                            PlanCuenta = oCuentaContable
                        };

                        oVoucher.ListaVouchers.Add(oLinea);
                        CuentaTmp = item.codCuenta;
                    } 

                    #endregion

                    CuentaTmp = String.Empty;

                    #region Letras

                    foreach (LetrasItemE item in oCanje.ListaLetrasItem)
                    {
                        if (CuentaTmp != item.codCuenta)
                        {
                            oCuentaContable = new PlanCuentasAD().ObtenerPlanCuentasPorCodigo(oCanje.idEmpresa, item.numVerPlanCuentas, item.codCuenta);
                        }

                        if (oCuentaContable != null)
                        {
                            if (oCuentaContable.indSolicitaAnexo == "S")
                            {
                                if (item.idPersona != 0)
                                {
                                    idPersona = item.idPersona;
                                }
                                else
                                {
                                    idPersona = null;
                                }
                            }
                            else
                            {
                                idPersona = null;
                            }

                            if (oCuentaContable.indSolicitaDcto == "S")
                            {
                                idDocumento = "LC";
                                numDocumento = item.numLetra;
                            }
                            else
                            {
                                idDocumento = String.Empty;
                                numDocumento = String.Empty;
                            }

                            idCCostos = String.Empty;
                            indCuentaGastos_ = oCuentaContable.indCuentaGastos;
                        }

                        numItem++;

                        oLinea = new VoucherItemE
                        {
                            numItem = String.Format("{0:00000}", numItem),
                            idPersona = idPersona,
                            idMoneda = "01",
                            tipCambio = TipoCambio,
                            indCambio = "S",
                            idCCostos = idCCostos,
                            numVerPlanCuentas = item.numVerPlanCuentas,
                            codCuenta = item.codCuenta,
                            desGlosa = Glosa,
                            fecDocumento = item.FechaEmision,
                            fecVencimiento = item.FechaVencimiento,
                            idDocumento = idDocumento,
                            serDocumento = String.Empty,
                            numDocumento = numDocumento,
                            fecDocumentoRef = null,
                            idDocumentoRef = String.Empty,
                            serDocumentoRef = String.Empty,
                            numDocumentoRef = String.Empty,
                            indDebeHaber = "H",
                            impSoles = item.MontoSoles,
                            impDolares = item.MontoDolares,
                            indAutomatica = "N",
                            CorrelativoAjuste = String.Empty,
                            codFteFin = String.Empty,
                            codProgramaCred = String.Empty,
                            indMovimientoAnterior = String.Empty,
                            tipPartidaPresu = String.Empty,
                            codPartidaPresu = String.Empty,
                            numDocumentoPresu = "LC-" + item.numLetra,
                            codColumnaCoven = null,
                            depAduanera = null,
                            nroDua = String.Empty,
                            AnioDua = String.Empty,
                            flagDetraccion = "N",
                            numDetraccion = String.Empty,
                            fecDetraccion = null,
                            tipDetraccion = String.Empty,
                            TasaDetraccion = 0,
                            MontoDetraccion = 0,
                            indPagoDetra = true,
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
                            codMedioPago = null,
                            idCampana = null,
                            idConceptoGasto = null,
                            idAccion = String.Empty,
                            idCtaCte = null,
                            idCtaCteItem = null,
                            UsuarioRegistro = Usuario,

                            indCuentaGastos = indCuentaGastos_,
                            PlanCuenta = oCuentaContable
                        };

                        oVoucher.ListaVouchers.Add(oLinea);
                        CuentaTmp = item.codCuenta;
                    } 

                    #endregion

                    Decimal totDebeSoles = Decimal.Round((from x in oVoucher.ListaVouchers where x.indDebeHaber == "D" select x.impSoles).Sum(), 2);
                    Decimal totHaberSoles = Decimal.Round((from x in oVoucher.ListaVouchers where x.indDebeHaber == "H" select x.impSoles).Sum(), 2);
                    Decimal totDebeDolares = Decimal.Round((from x in oVoucher.ListaVouchers where x.indDebeHaber == "D" select x.impDolares).Sum(), 2);
                    Decimal totHaberDolares = Decimal.Round((from x in oVoucher.ListaVouchers where x.indDebeHaber == "H" select x.impDolares).Sum(), 2);
                    Decimal DiferenciaSoles = 0, DiferenciaDolares = 0;

                    DiferenciaSoles = totDebeSoles - totHaberSoles;
                    DiferenciaDolares = totDebeDolares - totHaberDolares;

                    #region Ajuste

                    if (Math.Abs(DiferenciaSoles) <= 0.3M || Math.Abs(DiferenciaDolares) <= 0.3M)
                    {
                        foreach (VoucherItemE item in oVoucher.ListaVouchers)
                        {
                            if (Convert.ToInt32(item.numItem) == numItem - 1)
                            {
                                if (DiferenciaSoles != 0)
                                {
                                    if (item.indDebeHaber == "D")
                                    {
                                        item.impSoles -= DiferenciaSoles;
                                    }
                                    else
                                    {
                                        item.impSoles += DiferenciaSoles;
                                    }
                                }

                                if (DiferenciaDolares != 0)
                                {
                                    if (item.indDebeHaber == "D")
                                    {
                                        item.impDolares -= DiferenciaDolares;
                                    }
                                    else
                                    {
                                        item.impDolares += DiferenciaDolares;
                                    }
                                }
                            }
                        }

                        totDebeSoles = Decimal.Round((from x in oVoucher.ListaVouchers where x.indDebeHaber == "D" select x.impSoles).Sum(), 2);
                        totHaberSoles = Decimal.Round((from x in oVoucher.ListaVouchers where x.indDebeHaber == "H" select x.impSoles).Sum(), 2);
                        totDebeDolares = Decimal.Round((from x in oVoucher.ListaVouchers where x.indDebeHaber == "D" select x.impDolares).Sum(), 2);
                        totHaberDolares = Decimal.Round((from x in oVoucher.ListaVouchers where x.indDebeHaber == "H" select x.impDolares).Sum(), 2);

                        DiferenciaSoles = totDebeSoles - totHaberSoles;
                        DiferenciaDolares = totDebeDolares - totHaberDolares;
                    }

                    #endregion

                    #region Diferencia de Cambio

                    if (Math.Abs(DiferenciaSoles) > 0.3M || Math.Abs(DiferenciaDolares) > 0.3M)
                    {
                        ParametrosContaE oParametros = new ParametrosContaAD().ObtenerParametrosConta(oCanje.idEmpresa);

                        if (oParametros == null)
                        {
                            throw new Exception("Falta configurar los parámetros contables.");
                        }

                        Boolean Ajustar = false;
                        String NaturalezaDH = String.Empty;
                        Decimal MontoDiferencia = 0;
                        String CuentaDif = String.Empty;
                        String CuentaGanancia = oParametros.Ganancia;
                        String CuentaPerdida = oParametros.Perdida;

                        if (!String.IsNullOrWhiteSpace(CuentaGanancia) && !String.IsNullOrWhiteSpace(CuentaPerdida))
                        {
                            #region Direncia Soles

                            if (DiferenciaSoles != 0)
                            {
                                if (DiferenciaSoles < 0)
                                {
                                    CuentaDif = CuentaPerdida;
                                    NaturalezaDH = "D";
                                    Ajustar = true;
                                }
                                else //if (DiferenciaSoles > 0)
                                {
                                    CuentaDif = CuentaGanancia;
                                    NaturalezaDH = "H";
                                    Ajustar = true;
                                }

                                if (Ajustar)
                                {
                                    numItem++;
                                    MontoDiferencia = Math.Abs(DiferenciaSoles);
                                    oCuentaContable = new PlanCuentasAD().ObtenerPlanCuentasPorCodigo(oCanje.idEmpresa, oCanje.ListaCanjeDctoItem[0].numVerPlanCuentas, CuentaDif);

                                    oLinea = new VoucherItemE
                                    {
                                        numItem = String.Format("{0:00000}", numItem),
                                        idPersona = null,
                                        idMoneda = "01",
                                        tipCambio = 0,
                                        indCambio = "S",
                                        idCCostos = String.Empty,
                                        numVerPlanCuentas = oCanje.ListaCanjeDctoItem[0].numVerPlanCuentas,
                                        codCuenta = CuentaDif,
                                        desGlosa = Glosa,
                                        fecDocumento = null,
                                        fecVencimiento = null,
                                        idDocumento = String.Empty,
                                        serDocumento = String.Empty,
                                        numDocumento = String.Empty,
                                        fecDocumentoRef = null,
                                        idDocumentoRef = String.Empty,
                                        serDocumentoRef = String.Empty,
                                        numDocumentoRef = String.Empty,
                                        indDebeHaber = NaturalezaDH,
                                        impSoles = MontoDiferencia,
                                        impDolares = 0,
                                        indAutomatica = "N",
                                        CorrelativoAjuste = String.Empty,
                                        codFteFin = String.Empty,
                                        codProgramaCred = String.Empty,
                                        indMovimientoAnterior = String.Empty,
                                        tipPartidaPresu = String.Empty,
                                        codPartidaPresu = String.Empty,
                                        numDocumentoPresu = String.Empty,
                                        codColumnaCoven = null,
                                        depAduanera = null,
                                        nroDua = String.Empty,
                                        AnioDua = String.Empty,
                                        flagDetraccion = "N",
                                        numDetraccion = String.Empty,
                                        fecDetraccion = null,
                                        tipDetraccion = String.Empty,
                                        TasaDetraccion = 0,
                                        MontoDetraccion = 0,
                                        indPagoDetra = true,
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
                                        codMedioPago = null,
                                        idCampana = null,
                                        idConceptoGasto = null,
                                        //idAccion = String.Empty,
                                        //idCtaCte = null,
                                        //idCtaCteItem = null,
                                        UsuarioRegistro = Usuario,

                                        indCuentaGastos = oCuentaContable.indCuentaGastos,
                                        PlanCuenta = oCuentaContable
                                    };

                                    oVoucher.ListaVouchers.Add(oLinea);
                                }
                            }

                            #endregion

                            #region Diferencia Dólares

                            if (DiferenciaDolares != 0)
                            {
                                if (DiferenciaDolares < 0)
                                {
                                    CuentaDif = CuentaPerdida;
                                    NaturalezaDH = "D";
                                    Ajustar = true;
                                }
                                else //if (DiferenciaDolares > 0)
                                {
                                    CuentaDif = CuentaGanancia;
                                    NaturalezaDH = "H";
                                    Ajustar = true;
                                }

                                if (Ajustar)
                                {
                                    numItem++;
                                    MontoDiferencia = Math.Abs(DiferenciaDolares);
                                    oCuentaContable = new PlanCuentasAD().ObtenerPlanCuentasPorCodigo(oCanje.idEmpresa, oCanje.ListaCanjeDctoItem[0].numVerPlanCuentas, CuentaDif);

                                    oLinea = new VoucherItemE
                                    {
                                        numItem = String.Format("{0:00000}", numItem),
                                        idPersona = null,
                                        idMoneda = "02",
                                        tipCambio = 0,
                                        indCambio = "S",
                                        idCCostos = String.Empty,
                                        numVerPlanCuentas = oCanje.ListaCanjeDctoItem[0].numVerPlanCuentas,
                                        codCuenta = CuentaDif,
                                        desGlosa = Glosa,
                                        fecDocumento = null,
                                        fecVencimiento = null,
                                        idDocumento = String.Empty,
                                        serDocumento = String.Empty,
                                        numDocumento = String.Empty,
                                        fecDocumentoRef = null,
                                        idDocumentoRef = String.Empty,
                                        serDocumentoRef = String.Empty,
                                        numDocumentoRef = String.Empty,
                                        indDebeHaber = NaturalezaDH,
                                        impSoles = 0,
                                        impDolares = MontoDiferencia,
                                        indAutomatica = "N",
                                        CorrelativoAjuste = String.Empty,
                                        codFteFin = String.Empty,
                                        codProgramaCred = String.Empty,
                                        indMovimientoAnterior = String.Empty,
                                        tipPartidaPresu = String.Empty,
                                        codPartidaPresu = String.Empty,
                                        numDocumentoPresu = String.Empty,
                                        codColumnaCoven = null,
                                        depAduanera = null,
                                        nroDua = String.Empty,
                                        AnioDua = String.Empty,
                                        flagDetraccion = "N",
                                        numDetraccion = String.Empty,
                                        fecDetraccion = null,
                                        tipDetraccion = String.Empty,
                                        TasaDetraccion = 0,
                                        MontoDetraccion = 0,
                                        indPagoDetra = true,
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
                                        codMedioPago = null,
                                        idCampana = null,
                                        idConceptoGasto = null,
                                        //idAccion = String.Empty,
                                        //idCtaCte = null,
                                        //idCtaCteItem = null,
                                        UsuarioRegistro = Usuario,

                                        indCuentaGastos = oCuentaContable.indCuentaGastos,
                                        PlanCuenta = oCuentaContable
                                    };

                                    oVoucher.ListaVouchers.Add(oLinea);
                                }
                            } 

                            #endregion
                        }
                        else
                        {
                            throw new Exception("Falta las cuenta de ganancia y pérdida.");
                        }
                    }

                    #endregion

                    #region Cuenta Automaticas

                    String CuentaDestino = String.Empty;
                    String CuentaTransferencia = String.Empty;
                    VoucherItemE itemGasto = null;

                    foreach (VoucherItemE item in (from x in oVoucher.ListaVouchers where x.indCuentaGastos == "S" select x).ToList())
                    {
                        if (!String.IsNullOrWhiteSpace(item.PlanCuenta.codCuentaDestino) && !String.IsNullOrWhiteSpace(item.PlanCuenta.codCuentaTransferencia))
                        {
                            itemGasto = Colecciones.CopiarEntidad<VoucherItemE>(item);

                            #region Cuenta Destino

                            if (CuentaDestino != item.PlanCuenta.codCuentaDestino)
                            {
                                oCuentaContable = new PlanCuentasAD().ObtenerPlanCuentasPorCodigo(oCanje.idEmpresa, item.PlanCuenta.numVerPlanCuentas, item.PlanCuenta.codCuentaDestino);
                            }

                            if (oCuentaContable != null)
                            {
                                if (oCuentaContable.indSolicitaAnexo == "S")
                                {
                                    if (item.idPersona != 0)
                                    {
                                        idPersona = item.idPersona;
                                    }
                                    else
                                    {
                                        idPersona = null;
                                    }
                                }
                                else
                                {
                                    idPersona = null;
                                }

                                idDocumento = String.Empty;
                                numDocumento = String.Empty;

                                //if (oCuentaContable.indSolicitaDcto == "S")
                                //{
                                //    idDocumento = "PL";
                                //    numDocumento = MesPeriodo + oPlanillaPeriodo.codAnno;
                                //}
                                //else
                                //{
                                //    idDocumento = String.Empty;
                                //    numDocumento = String.Empty;
                                //}

                                idCCostos = String.Empty;

                                //if (oCuentaContable.indSolicitaCentroCosto == "S")
                                //{
                                //    idCCostos = item.idCCostos;
                                //}
                                //else
                                //{
                                //    idCCostos = String.Empty;
                                //}
                            }

                            numItem++;
                            itemGasto.numItem = String.Format("{0:00000}", numItem);
                            itemGasto.idPersona = idPersona;
                            itemGasto.idDocumento = idDocumento;
                            itemGasto.numDocumento = numDocumento;
                            itemGasto.idCCostos = idCCostos;
                            itemGasto.codCuenta = CuentaDestino = item.PlanCuenta.codCuentaDestino;
                            itemGasto.indAutomatica = "S";
                            oVoucher.ListaVouchers.Add(itemGasto);

                            #endregion

                            itemGasto = Colecciones.CopiarEntidad<VoucherItemE>(item);

                            #region Cuenta Transferencia

                            if (CuentaTransferencia != item.PlanCuenta.codCuentaTransferencia)
                            {
                                oCuentaContable = new PlanCuentasAD().ObtenerPlanCuentasPorCodigo(oCanje.idEmpresa, item.PlanCuenta.numVerPlanCuentas, item.PlanCuenta.codCuentaTransferencia);
                            }

                            if (oCuentaContable != null)
                            {
                                if (oCuentaContable.indSolicitaAnexo == "S")
                                {
                                    if (item.idPersona != 0)
                                    {
                                        idPersona = item.idPersona;
                                    }
                                    else
                                    {
                                        idPersona = null;
                                    }
                                }
                                else
                                {
                                    idPersona = null;
                                }

                                idDocumento = String.Empty;
                                numDocumento = String.Empty;
                                //if (oCuentaContable.indSolicitaDcto == "S")
                                //{
                                //    idDocumento = "PL";
                                //    numDocumento = MesPeriodo + oPlanillaPeriodo.codAnno;
                                //}
                                //else
                                //{
                                //    idDocumento = String.Empty;
                                //    numDocumento = String.Empty;
                                //}

                                idCCostos = String.Empty;
                                //if (oCuentaContable.indSolicitaCentroCosto == "S")
                                //{
                                //    idCCostos = item.idCCostos;
                                //}
                                //else
                                //{
                                //    idCCostos = String.Empty;
                                //}
                            }

                            numItem++;
                            itemGasto.numItem = String.Format("{0:00000}", numItem);
                            itemGasto.idPersona = idPersona;
                            itemGasto.idDocumento = idDocumento;
                            itemGasto.numDocumento = numDocumento;
                            itemGasto.idCCostos = idCCostos;
                            itemGasto.indDebeHaber = item.indDebeHaber == "D" ? "H" : "D";
                            itemGasto.codCuenta = CuentaTransferencia = item.PlanCuenta.codCuentaTransferencia;
                            itemGasto.indAutomatica = "S";
                            oVoucher.ListaVouchers.Add(itemGasto);

                            #endregion
                        }
                    }

                    #endregion

                    #endregion

                    oVoucher.impDebeSoles = (from x in oVoucher.ListaVouchers where x.indDebeHaber == "D" select x.impSoles).Sum();
                    oVoucher.impHaberSoles = (from x in oVoucher.ListaVouchers where x.indDebeHaber == "H" select x.impSoles).Sum();
                    oVoucher.impDebeDolares = (from x in oVoucher.ListaVouchers where x.indDebeHaber == "D" select x.impDolares).Sum();
                    oVoucher.impHaberDolares = (from x in oVoucher.ListaVouchers where x.indDebeHaber == "H" select x.impDolares).Sum();
                    oVoucher.numItems = oVoucher.ListaVouchers.Count;

                    if (!ExisteVoucher)
                    {
                        oVoucher.UsuarioRegistro = Usuario;
                        oVoucher = new VoucherLN().GrabarVouchers(oVoucher, EnumOpcionGrabar.Insertar);
                    }
                    else
                    {
                        oVoucher.UsuarioModificacion = Usuario;
                        oVoucher = new VoucherLN().GrabarVouchers(oVoucher, EnumOpcionGrabar.Actualizar);
                    }

                    oCanje.idComprobante = Libro;
                    oCanje.numFile = numFile;
                    oCanje.numVoucher = oVoucher.numVoucher;
                    oCanje.AnioPeriodo = AnioPeriodo;
                    oCanje.MesPeriodo = MesPeriodo;
                    oCanje.UsuarioModificacion = Usuario;

                    new CanjeAD().ActualizarCanjeConta(oCanje);
                    new CanjeAD().CambiarEstadoCanje(oCanje.idCanje, "AC", Usuario);

                    //Generando la Cta.Cte.
                    GenerarCanjeCtaCte(oCanje, Usuario);

                    oTrans.Complete();
                }

                return oVoucher;
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

        public Int32 AbrirCanje(Int32 idCanje, String Usuario)
        {
            try
            {
                Int32 resp = 0;

                using (TransactionScope oTrans = new TransactionScope())
                {
                    CanjeE oCanje = new CanjeAD().ObtenerCanje(idCanje);
                    oCanje.ListaCanjeDctoItem = new CanjeDctoItemAD().ListarCanjeDctoItem(idCanje);
                    oCanje.ListaLetrasItem = new LetrasItemAD().ListarLetrasItem(idCanje);

                    //Eliminando el voucher
                    new VoucherAD().EliminarVoucher(oCanje.idEmpresa, oCanje.idLocal, oCanje.AnioPeriodo, oCanje.MesPeriodo, oCanje.numVoucher, oCanje.idComprobante, oCanje.numFile);

                    //Eliminando la Cta.Cte.
                    #region CtaCte Documentos de Ventas

                    foreach (CanjeDctoItemE documento in oCanje.ListaCanjeDctoItem)
                    {
                        //Eliminando de la Cta.Cte. Detalle
                        new CtaCte_DetAD().EliminarMaeCtaCteDetallePorIdItem(documento.idCtaCteItem);
                        //Obteniendo la cabecera de la Cta.Cte.
                        CtaCteE oCtaCteCabecera = new CtaCteAD().ObtenerMaeCtaCtePorId(documento.idCtaCte);

                        #region Verificando Saldo de la CtaCte.

                        if (oCtaCteCabecera != null)
                        {
                            List<CtaCte_DetE> oListaCtaCteDet = new CtaCte_DetAD().ListarMaeCtaCteDet(oCtaCteCabecera.idEmpresa, oCtaCteCabecera.idCtaCte);

                            Decimal Saldo = 0;

                            foreach (CtaCte_DetE item in oListaCtaCteDet)
                            {
                                if (item.TipAccion == "C")
                                {
                                    Saldo = Saldo + Convert.ToDecimal(item.MontoMov);
                                }
                                else
                                {
                                    Saldo = Saldo - Convert.ToDecimal(item.MontoMov);
                                }
                            }

                            // Si el saldo es 0 Cancela colocar fecha de cancelacion de la cta.cte.
                            if (Saldo != 0)
                            {
                                new CtaCteAD().ActualizarFecCancelacionCtaCte(oCtaCteCabecera.idEmpresa, oCtaCteCabecera.idCtaCte, Convert.ToDateTime("31-12-2100"), Usuario);
                            }
                        }

                        #endregion

                    }

                    #endregion

                    #region CtaCte Letras

                    foreach (LetrasItemE Letra in oCanje.ListaLetrasItem)
                    {
                        //Obteniendo la cabecera de la Cta.Cte.
                        CtaCteE oCtaCteCabecera = new CtaCteAD().ObtenerMaeCtaCtePorId(Letra.idCtaCte);

                        //Para saber si el documento ya tiene abonos
                        if (oCtaCteCabecera != null)
                        {
                            List<CtaCte_DetE> oListaCtaCteAbonos = new CtaCte_DetAD().ListarMaeCtaCteDetAbonos(oCtaCteCabecera.idEmpresa, oCtaCteCabecera.idCtaCte);

                            if (oListaCtaCteAbonos.Count > 0)
                            {
                                throw new Exception(String.Format("la Letra LC {0} en la Cta. Cte. ya tiene movimientos de Abono, no puede abrir el Canje, elimine los movimientos antes de volver abrir el canje.", Letra.numLetra));
                            }
                            else
                            {
                                ////Eliminando de la Cta.Cte. la letra generada...
                                new CtaCteAD().EliminarMaeCtaCteConDetalle(oCtaCteCabecera.idCtaCte);
                            }
                        }
                    }

                    #endregion

                    //oCanje.idComprobante = String.Empty;
                    //oCanje.numFile = String.Empty;
                    //oCanje.numVoucher = oVoucher.numVoucher;
                    //oCanje.AnioPeriodo = AnioPeriodo;
                    //oCanje.MesPeriodo = MesPeriodo;

                    //Cambiando el estado
                    new CanjeAD().CambiarEstadoCanje(oCanje.idCanje, "RE", Usuario);

                    oTrans.Complete();
                    resp = 1;
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

        public Int32 ActualizarCanjeConta(CanjeE canje)
        {
            try
            {
                return new CanjeAD().ActualizarCanjeConta(canje);
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

        #region Procedimientos privados

        private int GenerarCanjeCtaCte(CanjeE oCanje, String Usuario)
        {
            try
            {
                int Resultado = 0;

                using (TransactionScope oTrans = new TransactionScope())
                {

                    #region CtaCte (Matar Documentos Canjeados)

                    foreach (CanjeDctoItemE documento in oCanje.ListaCanjeDctoItem)
                    {

                        #region Verificando la Cabecera

                        CtaCteE oCtaCteCabecera = new CtaCteAD().ObtenerMaeCtaCtePorDocumento(documento.idEmpresa, documento.idDocumento, documento.serDocumento, documento.numDocumento);

                        #endregion

                        if (oCtaCteCabecera != null)
                        {
                            documento.idCtaCte = oCtaCteCabecera.idCtaCte;

                            #region Detalle

                            CtaCte_DetE oCtaCteDet = new CtaCte_DetE
                            {
                                idEmpresa = documento.idEmpresa,
                                idCtaCte = oCtaCteCabecera.idCtaCte,
                                idDocumentoMov = documento.idDocumento,
                                SerieMov = documento.serDocumento,
                                NumeroMov = documento.numDocumento,
                                FechaMovimiento = oCanje.FechaCanje,
                                idMoneda = documento.idMonedaOrigen,
                                MontoMov = documento.MontoOrigen,
                                TipoCambio = Convert.ToDecimal(oCtaCteCabecera.TipoCambio),
                                TipAccion = EnumEstadoDocumentos.A.ToString(),
                                numVerPlanCuentas = oCtaCteCabecera.numVerPlanCuentas,
                                codCuenta = oCtaCteCabecera.codCuenta,
                                UsuarioRegistro = Usuario
                            };

                            oCtaCteDet = new CtaCte_DetAD().InsertarMaeCtaCteDet(oCtaCteDet);

                            #endregion

                            documento.idCtaCteItem = oCtaCteDet.idCtaCteItem;

                            #region Verificando Saldo de la CtaCte.

                            List<CtaCte_DetE> oListaCtaCteDet = new CtaCte_DetAD().ListarMaeCtaCteDet(oCtaCteCabecera.idEmpresa, oCtaCteCabecera.idCtaCte);

                            Decimal Saldo = 0;

                            foreach (CtaCte_DetE item in oListaCtaCteDet)
                            {
                                if (item.TipAccion == "C")
                                {
                                    Saldo = Saldo + Convert.ToDecimal(item.MontoMov);
                                }
                                else
                                {
                                    Saldo = Saldo - Convert.ToDecimal(item.MontoMov);
                                }
                            }

                            // Si el saldo es 0 Cancela colocar fecha de cancelacion de la cta.cte.
                            if (Saldo == 0)
                            {
                                oCtaCteCabecera.FechaCancelacion = oCanje.FechaCanje;
                                new CtaCteAD().ActualizarFecCancelacionCtaCte(oCtaCteCabecera.idEmpresa, oCtaCteCabecera.idCtaCte, oCtaCteCabecera.FechaCancelacion, Usuario);
                            }

                            #endregion

                            #region Actualizando Ids CtaCte

                            documento.UsuarioModificacion = Usuario;
                            new CanjeDctoItemAD().ActualizarCanjeDctoItemCtaCte(documento);

                            #endregion
                        }

                    }

                    #endregion

                    #region CtaCte (Generar Letras)

                    foreach (LetrasItemE Letra in oCanje.ListaLetrasItem)
                    {

                        #region Cabecera

                        CtaCteE oCtaCte = new CtaCteE
                        {
                            idEmpresa = Letra.idEmpresa,
                            idPersona = Convert.ToInt32(Letra.idPersona),
                            idDocumento = "LC",
                            numSerie = "",
                            numDocumento = Letra.numLetra,
                            idMoneda = Letra.idMoneda,
                            MontoOrig = Convert.ToDecimal(Letra.MontoLetra),
                            TipoCambio = Convert.ToDecimal(oCanje.TipoCambio),
                            FechaDocumento = Convert.ToDateTime(Letra.FechaEmision),
                            FechaVencimiento = Convert.ToDateTime(Letra.FechaVencimiento),
                            FechaCancelacion = Convert.ToDateTime("31-12-2100"),
                            numVerPlanCuentas = Letra.numVerPlanCuentas,
                            codCuenta = Letra.codCuenta,
                            AnnoVencimiento = String.Empty,
                            MesVencimiento = String.Empty,
                            SemanaVencimiento = String.Empty,
                            FechaOperacion = Convert.ToDateTime(oCanje.FechaCanje),
                            idSistema = 9, //Ctas por pagar
                            UsuarioRegistro = Usuario
                        };

                        oCtaCte = new CtaCteAD().InsertarMaeCtaCte(oCtaCte);

                        #endregion

                        Letra.idCtaCte = oCtaCte.idCtaCte;

                        #region Detalle

                        CtaCte_DetE oCtaCteDet = new CtaCte_DetE
                        {
                            idEmpresa = Letra.idEmpresa,
                            idCtaCte = oCtaCte.idCtaCte,
                            idDocumentoMov = "LC",
                            SerieMov = "",
                            NumeroMov = Letra.numLetra,
                            FechaMovimiento = Convert.ToDateTime(Letra.FechaEmision),
                            idMoneda = Letra.idMoneda,
                            MontoMov = Convert.ToDecimal(Letra.MontoLetra),
                            TipoCambio = Convert.ToDecimal(oCanje.TipoCambio),
                            TipAccion = EnumEstadoDocumentos.C.ToString(),
                            numVerPlanCuentas = Letra.numVerPlanCuentas,
                            codCuenta = Letra.codCuenta,
                            UsuarioRegistro = Usuario
                        };

                        oCtaCteDet = new CtaCte_DetAD().InsertarMaeCtaCteDet(oCtaCteDet);

                        #endregion

                        Letra.idCtaCteItem = oCtaCteDet.idCtaCteItem;

                        #region Actualizando Ids CtaCte

                        Letra.UsuarioModificacion = Usuario;
                        new LetrasItemAD().ActualizarLetrasItemCtaCte(Letra);

                        #endregion
                    }

                    #endregion

                    oTrans.Complete();
                    Resultado = 1;
                }

                return Resultado;
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
