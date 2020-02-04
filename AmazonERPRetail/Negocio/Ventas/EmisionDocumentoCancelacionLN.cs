using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Transactions;
using System.Linq;

using Entidades.Ventas;
using Entidades.Generales;
using Entidades.Contabilidad;
using Entidades.CtasPorCobrar;
using AccesoDatos.Ventas;
using AccesoDatos.Generales;
using AccesoDatos.Contabilidad;
using AccesoDatos.CtasPorCobrar;
using Infraestructura;
using Infraestructura.Enumerados;
using Negocio.CtasPorCobrar;

namespace Negocio.Ventas
{
    public class EmisionDocumentoCancelacionLN
    {

        public EmisionDocumentoCancelacionE InsertarEmisionDocumentoCancelacion(EmisionDocumentoCancelacionE emisiondocumentocancelacion)
        {
            try
            {
                return new EmisionDocumentoCancelacionAD().InsertarEmisionDocumentoCancelacion(emisiondocumentocancelacion);
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

        public EmisionDocumentoCancelacionE ActualizarEmisionDocumentoCancelacion(EmisionDocumentoCancelacionE emisiondocumentocancelacion)
        {
            try
            {
                return new EmisionDocumentoCancelacionAD().ActualizarEmisionDocumentoCancelacion(emisiondocumentocancelacion);
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

        public int EliminarEmisionDocumentoCancelacion(Int32 idEmpresa, Int32 idLocal, String idDocumento, String numSerie, String numDocumento)
        {
            try
            {
                return new EmisionDocumentoCancelacionAD().EliminarEmisionDocumentoCancelacion(idEmpresa, idLocal, idDocumento, numSerie, numDocumento);
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

        public List<EmisionDocumentoCancelacionE> ListarEmisionDocumentoCancelacion(Int32 idEmpresa, Int32 idLocal, String idDocumentoReci, String numSerieReci, String numDocumentoReci, string fecIni, string fecFin)
        {
            try
            {
                return new EmisionDocumentoCancelacionAD().ListarEmisionDocumentoCancelacion(idEmpresa, idLocal, idDocumentoReci, numSerieReci, numDocumentoReci, fecIni, fecFin);
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

        public List<EmisionDocumentoCancelacionE> ObtenerEmisionDocumentoCancelacion(Int32 idEmpresa, Int32 idLocal, String idDocumento, String numSerie, String numDocumento)
        {
            try
            {
                return new EmisionDocumentoCancelacionAD().ObtenerEmisionDocumentoCancelacion(idEmpresa, idLocal, idDocumento, numSerie, numDocumento);
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

        public int GenerarCobranzas(List<EmisionDocumentoCancelacionE> oListaCancelaciones, String Usuario)
        {
            try
            {
                Int32 resp = 0;

                using (TransactionScope oTrans = new TransactionScope())
                {
                    //Datos Generales
                    Int32 idEmpresa = oListaCancelaciones[0].idEmpresa;
                    Int32 idLocal = oListaCancelaciones[0].idLocal;
                    String idDocumento = oListaCancelaciones[0].idDocumento;
                    String numSerie = oListaCancelaciones[0].numSerie;
                    String numDocumento = oListaCancelaciones[0].numDocumento;
                    DateTime fecAbono = Convert.ToDateTime(oListaCancelaciones[0].fecAbono);
                    String idMonedaRec = oListaCancelaciones[0].idMonedaRecibida;
                    Decimal MontoRec = oListaCancelaciones.Sum(x => x.MontoRecibido);
                    Decimal TicaRec = oListaCancelaciones[0].tipCambio;
                    String idDocRec = oListaCancelaciones[0].idDocumentoReci;
                    String SerieRec = oListaCancelaciones[0].numSerieReci;
                    String NumeroRec = oListaCancelaciones[0].numDocumentoReci;
                    //Tipo de planilla
                    ParTabla oTipoCobro = new ParTablaAD().ParTablaPorNemo("PLAEFE");
                    //Obteniendo los parámetros contables
                    ParametrosContaE oParametroCuenta = new ParametrosContaAD().ObtenerParametrosConta(idEmpresa);
                    //Obteniendo el diario y el file
                    EmisionDocumentoCancelacionE oFileDiario = new EmisionDocumentoCancelacionAD().ObtenerDiarioFileCancelacion(idEmpresa, idLocal, idDocumento, numSerie, numDocumento);

                    //Validación si en caso sea nulo
                    if (oFileDiario == null)
                    {
                        throw new Exception("No esta configurado las cuentas en el Maestro de Bancos o en el Maestro de los Diarios.");
                    }

                    //CABECERA
                    CobranzasE oCobranza = new CobranzasE()
                    {
                        TipoPlanilla = oTipoCobro.IdParTabla,
                        idEmpresa = idEmpresa,
                        idLocal = idLocal,
                        Fecha = fecAbono,
                        MontoSoles = 0,
                        MontoDolares = 0,
                        Observaciones = String.Empty,
                        idComprobante = oFileDiario.idComprobante,
                        numFile = oFileDiario.numFile,
                        AnioPeriodo = fecAbono.ToString("yyyy"),
                        MesPeriodo = fecAbono.ToString("MM"),
                        numVoucher = String.Empty,
                        UsuarioRegistro = Usuario
                    };

                    //DETALLE
                    CobranzasItemE oCobranzaItem = new CobranzasItemE()
                    {
                        Fecha = fecAbono,
                        idMoneda = idMonedaRec,
                        Monto = MontoRec,
                        TipoCobro = "D",
                        Descripcion = String.Empty,
                        tipCambioReci = TicaRec,
                        fecVencimiento = null,
                        fecCobranza = fecAbono,
                        idDocumento = idDocRec,
                        numSerie = SerieRec,
                        numCheque = NumeroRec,
                        Comision = 0,
                        Interes = 0,
                        numVerPlanCuentas = oFileDiario.numVerPlanCuentas,
                        codCuenta = oFileDiario.codCuenta,
                        codCuentaProvision = String.Empty,
                        idConceptoGasto = null,
                        idConceptoInteres = null,
                        idBanco = null,
                        indPresupuesto = false,
                        tipPartidaPresu = String.Empty,
                        idPartidaPresu = String.Empty,
                        cheDifCancelando = false,
                        UsuarioRegistro = Usuario
                    };

                    //Agregando el detalle a la cabecera
                    oCobranza.oListaCobranzas.Add(oCobranzaItem);

                    #region Actualizando los totales en la cabecera...

                    Decimal Soles = 0;
                    Decimal Dolares = 0;

                    foreach (CobranzasItemE itemImp in oCobranza.oListaCobranzas)
                    {
                        if (itemImp.idMoneda == Variables.Soles)
                        {
                            Soles += itemImp.Monto;
                            Dolares += itemImp.Monto / itemImp.tipCambioReci;
                        }
                        else
                        {
                            Soles += itemImp.Monto * itemImp.tipCambioReci;
                            Dolares += itemImp.Monto;
                        }
                    }

                    oCobranza.MontoSoles = Soles;
                    oCobranza.MontoDolares = Dolares;

                    #endregion

                    //Recorriendo la lista de cancelaciones
                    foreach (EmisionDocumentoCancelacionE item in oListaCancelaciones)
                    {
                        String Cuenta12 = String.Empty;
                        EmisionDocumentoE DocumentoTmp = new EmisionDocumentoAD().ObtenerEmisionDocumento(item.idEmpresa, item.idLocal, item.idDocumento, item.numSerie, item.numDocumento);

                        if (item.idMonedaDocum == Variables.Soles)
                        {
                            Cuenta12 = oParametroCuenta.VentaS;
                        }
                        else
                        {
                            Cuenta12 = oParametroCuenta.VentaD;
                        }

                        //DETALLE ITEM
                        CobranzasItemDetE oCobranzaItemDet = new CobranzasItemDetE()
                        {
                            idPersona = Convert.ToInt32(DocumentoTmp.idPersona),
                            idDocumento = item.idDocumento,
                            numSerie = item.numSerie,
                            numDocumento = item.numDocumento,
                            //fecEmision = item.Fecha, //Revisar
                            idMoneda = item.idMonedaDocum,
                            Monto = item.MontoAplicar,
                            idMonedaReci = item.idMonedaRecibida,
                            MontoReci = item.MontoRecibido,
                            tipCambioReci = DocumentoTmp.tipCambio,
                            numVerPlanCuentas = oFileDiario.numVerPlanCuentas,
                            codCuenta = Cuenta12,
                            //fecVencimiento = item.Fecha, //Revisar
                            idCtaCte = DocumentoTmp.idCtaCte,
                            UsuarioRegistro = Usuario
                        };

                        //Agregando al detalle el item
                        oCobranza.oListaCobranzas[0].oListaCobranzasItemDet.Add(oCobranzaItemDet);
                    }

                    //Grabando la Cobranza
                    oCobranza = new CobranzasLN().GrabarCobranzas(oCobranza, EnumOpcionGrabar.Insertar);
                    //Actualizando el campo que indica que la cobranzas viene del módulo de facturación
                    new CobranzasAD().ActualizarVieneFact(oCobranza.idPlanilla);
                    //Cerrando la cobranza
                    new CobranzasLN().CerrarPlanillas(oCobranza.idPlanilla, idEmpresa, idLocal, oParametroCuenta.numVerPlanCuentas, Usuario, oTipoCobro.NemoTecnico);

                    foreach (EmisionDocumentoCancelacionE item in oListaCancelaciones)
                    {
                        //Actualizar el ID de la planilla en la tabla de ven_EmisionDocumentoCancelaciones
                        item.idPlanilla = oCobranza.idPlanilla;
                        item.UsuarioModificacion = Usuario;
                        new EmisionDocumentoCancelacionAD().ActualizarEmisDocuCancelacionPlanilla(item);
                        resp++;
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

        public List<EmisionDocumentoCancelacionE> ReporteConsolidadoCaja(Int32 idEmpresa, Int32 idLocal, string fecha)
        {
            try
            {
                return new EmisionDocumentoCancelacionAD().ReporteConsolidadoCaja(idEmpresa, idLocal, fecha);
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
