using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Transactions;

using Entidades.Tesoreria;
using Entidades.Contabilidad;
using Entidades.Generales;
using Entidades.CtasPorPagar;
using AccesoDatos.Tesoreria;
using AccesoDatos.Contabilidad;
using AccesoDatos.Generales;
using AccesoDatos.CtasPorPagar;
using Negocio.Contabilidad;
using Negocio.CtasPorPagar;
using Infraestructura;
using Infraestructura.Enumerados;
using Infraestructura.Extensores;
using Entidades.Maestros;
using AccesoDatos.Maestros;

namespace Negocio.Tesoreria
{
    public class SolicitudProveedorRendicionLN
    {

        public SolicitudProveedorRendicionE GrabarRendicion(SolicitudProveedorRendicionE oRendicion, EnumOpcionGrabar Opcion)
        {
            try
            {
                using (TransactionScope oTrans = new TransactionScope())
                {
                    Decimal Saldo = new SolicitudProveedorRendicionAD().SaldoPorIdSolicitud(oRendicion.idRendicion, oRendicion.idEmpresa, oRendicion.idLocal, oRendicion.idSolicitud);

                    if (Opcion == EnumOpcionGrabar.Insertar)
                    {
                        //Generando el nuevo código
                        oRendicion.codRendicion = new SolicitudProveedorRendicionAD().GenerarNumRendicionProveedor(oRendicion.idEmpresa, oRendicion.idLocal, oRendicion.fecOperacion.Year);
                        
                        //Insertando el registro nuevo
                        oRendicion = new SolicitudProveedorRendicionAD().InsertarSolicitudProveedorRendicion(oRendicion);

                        //Revisando si hay detalle para insertarlo
                        if (oRendicion.oListaRendiciones != null && oRendicion.oListaRendiciones.Count > 0)
                        {
                            Int32 Corre = 1;

                            foreach (SolicitudProveedorRendicionDetE item in oRendicion.oListaRendiciones)
                            {
                                //Si existen provisiones y no viene de una búsqueda, insertarlas
                                if (item.oProvision != null && !item.indProvBusqueda)
                                {
                                    item.oProvision = new ProvisionesLN().GrabarProvision(item.oProvision, EnumOpcionGrabar.Insertar);
                                    item.idProvision = item.oProvision.idProvision;
                                }

                                item.idRendicion = oRendicion.idRendicion;
                                item.Item = Corre;
                                new SolicitudProveedorRendicionDetAD().InsertarSolicitudProveedorRendicionDet(item);

                                Corre++;
                            }
                        }

                        if (oRendicion.indDeposito)
                        {
                            oRendicion.AnioPeriodo = String.Empty;
                            oRendicion.MesPeriodo = String.Empty;
                            oRendicion.numVoucher = String.Empty;
                            oRendicion.UsuarioModificacion = oRendicion.UsuarioRegistro;
                            ActualizarRendicionConta(oRendicion);
                        }
                    }
                    else
                    {
                        //Actualizando el registro...
                        oRendicion = new SolicitudProveedorRendicionAD().ActualizarSolicitudProveedorRendicion(oRendicion);

                        //Lista de Eliminados
                        if (oRendicion.oListaRendicionesDel != null && oRendicion.oListaRendicionesDel.Count > 0)
                        {
                            foreach (SolicitudProveedorRendicionDetE item in oRendicion.oListaRendicionesDel)
                            {
                                //Eliminando la provisión...
                                if (item.EsAutomatico && item.idProvision > 0 && !item.indProvBusqueda)
                                {
                                    ProvisionesE oProvision = new ProvisionesAD().RecuperarProvisionesPorId(oRendicion.idEmpresa, oRendicion.idLocal, item.idProvision.Value);

                                    if (oProvision != null)
                                    {
                                        if (oProvision.EstadoProvision == "PR")
                                        {
                                            throw new Exception(String.Format("No se puede eliminar la Rendición porque el documento {0} {1}-{2} se encuentra provisionado.", item.idDocumento, item.numSerie, item.numDocumento));
                                        }

                                        new ProvisionesLN().EliminarProvisiones(oRendicion.idEmpresa, oRendicion.idLocal, item.idProvision.Value);
                                    }
                                }

                                //Eliminando la rendición
                                new SolicitudProveedorRendicionDetAD().EliminarSolicitudProveedorRendicionDet(oRendicion.idRendicion, item.Item);
                            }
                        }

                        Int32 Corre = oRendicion.oListaRendiciones.Max(x => x.Item);

                        if (oRendicion.oListaRendiciones != null)
                        {
                            foreach (SolicitudProveedorRendicionDetE item in oRendicion.oListaRendiciones)
                            {
                                //Provisiones
                                if (item.OpcionGrabarProv == (Int32)EnumOpcionGrabar.Insertar)
                                {
                                    //Si existen provisiones insertarlas
                                    if (item.oProvision != null && !item.indProvBusqueda)
                                    {
                                        item.oProvision = new ProvisionesLN().GrabarProvision(item.oProvision, EnumOpcionGrabar.Insertar);
                                        item.idProvision = item.oProvision.idProvision;
                                    }
                                }
                                else if (item.OpcionGrabarProv == (Int32)EnumOpcionGrabar.Actualizar)
                                {
                                    //Si existen provisiones actualizarlas
                                    if (item.oProvision != null && item.idProvision > 0 && !item.indProvBusqueda)
                                    {
                                        item.oProvision = new ProvisionesLN().GrabarProvision(item.oProvision, EnumOpcionGrabar.Actualizar);
                                        item.idProvision = item.oProvision.idProvision;
                                    }
                                }

                                if (item.Opcion == (Int32)EnumOpcionGrabar.Insertar)
                                {
                                    Corre++;
                                    item.idRendicion = oRendicion.idRendicion;
                                    item.Item = Corre;

                                    new SolicitudProveedorRendicionDetAD().InsertarSolicitudProveedorRendicionDet(item);
                                }
                                else if (item.Opcion == (Int32)EnumOpcionGrabar.Actualizar)
                                {
                                    new SolicitudProveedorRendicionDetAD().ActualizarSolicitudProveedorRendicionDet(item);
                                }
                            }
                        }

                        if (oRendicion.indDeposito)
                        {
                            oRendicion.AnioPeriodo = String.Empty;
                            oRendicion.MesPeriodo = String.Empty;
                            oRendicion.numVoucher = String.Empty;
                            ActualizarRendicionConta(oRendicion);
                        }
                    }

                    Saldo += oRendicion.MontoAplicado;

                    if (Saldo > oRendicion.impSolicitud)
                    {
                        throw new Exception("El saldo no puede ser mayor al monto del Anticipo.");
                    }

                    new SolicitudProveedorAD().ActualizarSaldoSolProveedor(oRendicion.idSolicitud, oRendicion.impSolicitud - Saldo);

                    oTrans.Complete();
                }

                return oRendicion;
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

        public SolicitudProveedorRendicionE InsertarSolicitudProveedorRendicion(SolicitudProveedorRendicionE solicitudproveedorrendicion)
        {
            try
            {
                return new SolicitudProveedorRendicionAD().InsertarSolicitudProveedorRendicion(solicitudproveedorrendicion);
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

        public SolicitudProveedorRendicionE ActualizarSolicitudProveedorRendicion(SolicitudProveedorRendicionE solicitudproveedorrendicion)
        {
            try
            {
                return new SolicitudProveedorRendicionAD().ActualizarSolicitudProveedorRendicion(solicitudproveedorrendicion);
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

        public int EliminarSolicitudProveedorRendicion(Int32 idRendicion)
        {
            try
            {
                Int32 resp = 0;

                using (TransactionScope oTrans = new TransactionScope())
                {
                    //Para obtener el monto aplicado en esa rendición...
                    SolicitudProveedorRendicionE oRendicion = RecuperarSolicitudProveedorRendicion(idRendicion);//new SolicitudProveedorRendicionAD().ObtenerSolicitudProveedorRendicion(idRendicion);
                    //Para obtener el saldo a la fecha...
                    SolicitudProveedorE oSolicitud = new SolicitudProveedorAD().ObtenerSolicitudProveedor(oRendicion.idSolicitud);
                    //Actualizando el nuevo saldo en la solicitud...
                    new SolicitudProveedorAD().ActualizarSaldoSolProveedor(oRendicion.idSolicitud, oSolicitud.Saldo + oRendicion.MontoAplicado);

                    //Revisando la provisión
                    foreach (SolicitudProveedorRendicionDetE item in oRendicion.oListaRendiciones)
                    {
                        if (item.EsAutomatico && item.idProvision > 0 && !item.indProvBusqueda)
                        {
                            ProvisionesE oProvision = new ProvisionesAD().RecuperarProvisionesPorId(oRendicion.idEmpresa, oRendicion.idLocal, item.idProvision.Value);

                            if (oProvision != null)
                            {
                                if (oProvision.EsRendicion)
                                {
                                    if (oProvision.EstadoProvision == "PR")
                                    {
                                        throw new Exception(String.Format("No se puede eliminar la Rendición porque el documento {0} {1}-{2} se encuentra provisionado.", item.idDocumento, item.numSerie, item.numDocumento));
                                    }

                                    new ProvisionesLN().EliminarProvisiones(oProvision.idEmpresa, oProvision.idLocal, oProvision.idProvision); 
                                }
                            }
                        }
                    }

                    //Eliminando la rendición...
                    resp = new SolicitudProveedorRendicionAD().EliminarSolicitudProveedorRendicion(idRendicion);

                    //Transacción completa...
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

        public List<SolicitudProveedorRendicionE> ListarSolicitudProveedorRendicion(Int32 idEmpresa, Int32 idAuxiliar, DateTime fecIni, DateTime fecFin)
        {
            try
            {
                List<SolicitudProveedorRendicionE> oListaDevuelta = new SolicitudProveedorRendicionAD().ListarSolicitudProveedorRendicion(idEmpresa, idAuxiliar, fecIni, fecFin);
                Decimal Saldito = 0;

                foreach (SolicitudProveedorRendicionE item in oListaDevuelta)
                {
                    if (item.Fila == 1)
                    {
                        item.SaldoSolicitud = item.impSolicitud - item.MontoAplicado;
                        Saldito = item.MontoAplicado;
                    }
                    else
                    {
                        item.SaldoSolicitud = item.impSolicitud - item.MontoAplicado - Saldito;
                        Saldito += item.MontoAplicado;
                    }
                }

                return (from x in oListaDevuelta orderby x.codRendicion select x).ToList();
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

        public SolicitudProveedorRendicionE ObtenerSolicitudProveedorRendicion(Int32 idRendicion)
        {
            try
            {
                return new SolicitudProveedorRendicionAD().ObtenerSolicitudProveedorRendicion(idRendicion);
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

        public SolicitudProveedorRendicionE RecuperarSolicitudProveedorRendicion(Int32 idRendicion)
        {
            try
            {
                SolicitudProveedorRendicionE oRendicion = new SolicitudProveedorRendicionAD().ObtenerSolicitudProveedorRendicion(idRendicion);
                oRendicion.oListaRendiciones = new SolicitudProveedorRendicionDetAD().ListarSolicitudProveedorRendicionDet(idRendicion);

                return oRendicion;
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

        public String GenerarAsientoRendicion(Int32 idRendicion, String Usuario)
        {
            try
            {
                String Mensaje = String.Empty;

                using (TransactionScope oTrans = new TransactionScope())
                {
                    VoucherE oVoucher = null;
                    VoucherItemE oVoucherDet = null;
                    String DebeHaber = Variables.Haber;
                    String Numerovoucher = "0";
                    Int32 numItemDet = 0;
                    SolicitudProveedorRendicionE oRendicion = RecuperarSolicitudProveedorRendicion(idRendicion);
                    List<SolicitudProveedorDetE> oDetalleSolicitud = new SolicitudProveedorDetAD().ListarSolicitudProveedorDetOp(oRendicion.idSolicitud);
                    ParametrosContaE oParametro = new ParametrosContaAD().ObtenerParametrosConta(oRendicion.idEmpresa);
                    TipoCambioE oTica = null;
                    Decimal TipoCambio = 0;
                    PlanCuentasE oCuenta = null;

                    if (!oRendicion.indDeposito)
                    {
                        if (oRendicion.oListaRendiciones == null || oRendicion.oListaRendiciones.Count == 0)
                        {
                            throw new Exception("Este registro no tiene Rendiciones.");
                        } 
                    }

                    //Revisando si existe Voucher
                    if (!String.IsNullOrWhiteSpace(oRendicion.idComprobante) && !String.IsNullOrWhiteSpace(oRendicion.numFile) && !String.IsNullOrWhiteSpace(oRendicion.numVoucher))
                    {
                        VoucherE VoucherTmp = new VoucherAD().ObtenerVoucherPorCodigo(oRendicion.idEmpresa, oRendicion.idLocal, oRendicion.AnioPeriodo, oRendicion.MesPeriodo, oRendicion.numVoucher, oRendicion.idComprobante, oRendicion.numFile);

                        if (VoucherTmp == null)
                        {
                            Numerovoucher = oRendicion.numVoucher;
                            Mensaje = String.Format("Se actualizó el voucher {0}-{1}-{2}", oRendicion.idComprobante, oRendicion.numFile, oRendicion.numVoucher);
                        }
                        else
                        {
                            Numerovoucher = "0";
                            Mensaje = String.Format("El voucher {0}-{1}-{2} ya existe en el módulo de contabilidad, se creó el voucher siguiente.", oRendicion.idComprobante, oRendicion.numFile, oRendicion.numVoucher);
                        }
                    }

                    #region Voucher Rendición

                    #region Cabecera del Voucher

                    oTica = new TipoCambioAD().ObtenerTipoCambioPorDia("02", oRendicion.fecOperacion.ToString("yyyyMMdd"));

                    if (oTica == null)
                    {
                        throw new Exception(String.Format("No existe Tipo de Cambio para el dia {0}", oRendicion.fecOperacion.ToString("dd/MM/yyyy")));
                    }

                    TipoCambio = oTica.valVenta;

                    oVoucher = new VoucherE
                    {
                        idEmpresa = oRendicion.idEmpresa,
                        idLocal = oRendicion.idLocal,
                        AnioPeriodo = oRendicion.fecOperacion.ToString("yyyy"),
                        MesPeriodo = oRendicion.fecOperacion.ToString("MM"),
                        numVoucher = Numerovoucher,
                        idComprobante = oParametro.DiarioRendicion,
                        numFile = oParametro.FileRendicion,
                        fecTransferencia = null,
                        //oVoucher.numItems = ;
                        idMoneda = oRendicion.idMonedaSol,
                        fecOperacion = oRendicion.fecOperacion,
                        fecDocumento = oRendicion.fecOperacion,
                        //oVoucher.impDebeSoles = 0;
                        //oVoucher.impHaberSoles = 0;
                        //oVoucher.impDebeDolares = 0;
                        //oVoucher.impHaberDolares = 0;
                        //oVoucher.impMonOrigDeb = 0;
                        //oVoucher.impMonOrigHab = 0;
                        GlosaGeneral = oRendicion.Glosa, // "RENDICION DE PROVEEDOR N° " + oRendicion.codRendicion,
                        //oVoucher.indEstado = "";
                        tipCambio = TipoCambio,
                        RazonSocial = oRendicion.RazonSocial,
                        numDocumentoPresu = "VARIOS",
                        indHojaCosto = "N",
                        numHojaCosto = String.Empty,
                        numOrdenCompra = String.Empty,
                        sistema = "6", //Tesoreria
                        EsAutomatico = true,
                        UsuarioRegistro = Usuario
                    };

                    #endregion

                    #region Detalle

                    #region Anticipos

                    foreach (SolicitudProveedorDetE item in oDetalleSolicitud)
                    {
                        numItemDet++;
                        oTica = new TipoCambioAD().ObtenerTipoCambioPorDia("02", item.fecOpeSol.ToString("yyyyMMdd"));

                        if (oTica == null)
                        {
                            throw new Exception(String.Format("No existe Tipo de Cambio para el dia {0} del Anticipo", item.fecOpeSol.ToString("dd/MM/yyyy")));
                        }

                        TipoCambio = oTica.valVenta;

                        oVoucherDet = new VoucherItemE();
                        oCuenta = new PlanCuentasAD().ObtenerPlanCuentasPorCodigo(oRendicion.idEmpresa, item.numVerPlanCuentas, item.codCuenta);

                        if (oCuenta == null)
                        {
                            throw new Exception(String.Format("La cuenta {0} ingresada no existe.", item.codCuenta));
                        }

                        oVoucherDet.numItem = String.Format("{0:00000}", numItemDet);
                        oVoucherDet.idPersona = oCuenta.indSolicitaAnexo == "S" ? oRendicion.idProveedor : (int?)null;
                        oVoucherDet.idMoneda = item.idMonedaSol;
                        oVoucherDet.tipCambio = TipoCambio;
                        oVoucherDet.indCambio = "S";
                        oVoucherDet.idCCostos = String.Empty;
                        oVoucherDet.numVerPlanCuentas = item.numVerPlanCuentas;
                        oVoucherDet.codCuenta = item.codCuenta;
                        oVoucherDet.desGlosa = oRendicion.Glosa; //"ANTICIPO DE PROVEEDOR N° " + oRendicion.codSolicitud;
                        oVoucherDet.fecDocumento = oCuenta.indSolicitaDcto == "S" ? item.fecOpeSol : (DateTime?)null;
                        oVoucherDet.fecVencimiento = null;
                        oVoucherDet.idDocumento = oCuenta.indSolicitaDcto == "S" ? "AN" : String.Empty;
                        oVoucherDet.serDocumento = String.Empty;
                        oVoucherDet.numDocumento = oCuenta.indSolicitaDcto == "S" ? oRendicion.codSolicitud : String.Empty;
                        oVoucherDet.fecDetraccion = null;
                        oVoucherDet.idDocumentoRef = String.Empty;
                        oVoucherDet.serDocumentoRef = String.Empty;
                        oVoucherDet.numDocumentoRef = String.Empty;
                        oVoucherDet.indDebeHaber = DebeHaber;

                        if (oRendicion.idMonedaSol == Variables.Soles)
                        {
                            oVoucherDet.impSoles = oRendicion.MontoAplicado;
                            oVoucherDet.impDolares = Math.Round(oRendicion.MontoAplicado / TipoCambio, 2);
                        }
                        else
                        {
                            oVoucherDet.impSoles = Math.Round(oRendicion.MontoAplicado * TipoCambio, 2);
                            oVoucherDet.impDolares = oRendicion.MontoAplicado;
                        }

                        oVoucherDet.indAutomatica = Variables.NO;
                        oVoucherDet.CorrelativoAjuste = String.Empty;
                        oVoucherDet.codFteFin = String.Empty;
                        oVoucherDet.codProgramaCred = String.Empty;
                        oVoucherDet.indMovimientoAnterior = String.Empty;
                        oVoucherDet.tipPartidaPresu = String.Empty;
                        oVoucherDet.codPartidaPresu = String.Empty;
                        oVoucherDet.numDocumentoPresu = String.Empty;
                        oVoucherDet.codColumnaCoven = null;
                        oVoucherDet.depAduanera = null;
                        oVoucherDet.nroDua = String.Empty;
                        oVoucherDet.AnioDua = String.Empty;
                        oVoucherDet.flagDetraccion = Variables.NO;
                        oVoucherDet.numDetraccion = String.Empty;
                        oVoucherDet.fecDetraccion = null;
                        oVoucherDet.tipDetraccion = String.Empty;
                        oVoucherDet.TasaDetraccion = 0;
                        oVoucherDet.MontoDetraccion = 0;
                        oVoucherDet.indPagoDetra = false;
                        oVoucherDet.indReparable = Variables.NO;
                        oVoucherDet.idConceptoRep = null;
                        oVoucherDet.desReferenciaRep = String.Empty;
                        oVoucherDet.idAlmacen = String.Empty;
                        oVoucherDet.tipMovimientoAlmacen = String.Empty;
                        oVoucherDet.numDocumentoAlmacen = String.Empty;
                        oVoucherDet.numItemAlmacen = String.Empty;
                        oVoucherDet.CajaSucursal = String.Empty;
                        oVoucherDet.indCompra = String.Empty;
                        oVoucherDet.indConciliado = String.Empty;
                        oVoucherDet.fecRecepcion = null;
                        oVoucherDet.codMedioPago = null;
                        oVoucherDet.idCampana = null;
                        oVoucherDet.idConceptoGasto = null;
                        oVoucherDet.UsuarioRegistro = Usuario;

                        oVoucherDet.indCuentaGastos = oCuenta.indCuentaGastos;
                        oVoucherDet.codCuentaDestino = oCuenta.codCuentaDestino;
                        oVoucherDet.codCuentaTransferencia = oCuenta.codCuentaTransferencia;

                        oVoucher.ListaVouchers.Add(oVoucherDet);

                        //Si existe diferencia se crea nuevo item e ingresa a la Cta.Cte.
                        if (oRendicion.Diferencia > 0)
                        {
                            numItemDet++;
                            VoucherItemE VoucherDetDif = Colecciones.CopiarEntidad<VoucherItemE>(oVoucherDet);
                            VoucherDetDif.numItem = String.Format("{0:00000}", numItemDet);
                            VoucherDetDif.fecDocumento = oRendicion.fecOperacion;
                            VoucherDetDif.idDocumento = oRendicion.idDocumento;
                            VoucherDetDif.serDocumento = String.Empty;
                            VoucherDetDif.numDocumento = oRendicion.numDocumento;

                            if (oRendicion.idMonedaSol == Variables.Soles)
                            {
                                VoucherDetDif.impSoles = oRendicion.Diferencia;
                                VoucherDetDif.impDolares = Math.Round(oRendicion.Diferencia / TipoCambio, 2);
                            }
                            else
                            {
                                VoucherDetDif.impSoles = Math.Round(oRendicion.Diferencia * TipoCambio, 2);
                                VoucherDetDif.impDolares = oRendicion.Diferencia;
                            }

                            if (!String.IsNullOrWhiteSpace(item.codCuentaCompras))
                            {
                                VoucherDetDif.codCuenta = item.codCuentaCompras;
                            }

                            oVoucher.ListaVouchers.Add(VoucherDetDif);

                            #region CtaCte por la diferencia

                            oRendicion = InsertaCtaCteRendicion(oRendicion, VoucherDetDif);

                            #endregion
                        }
                    }

                    #endregion

                    DebeHaber = Variables.Debe;
                    oCuenta = null;

                    #region Facturas

                    foreach (SolicitudProveedorRendicionDetE item in oRendicion.oListaRendiciones)
                    {
                        numItemDet++;

                        oCuenta = new PlanCuentasAD().ObtenerPlanCuentasPorCodigo(oRendicion.idEmpresa, item.numVerPlanCuentas, item.codCuenta);

                        if (oCuenta == null)
                        {
                            throw new Exception(String.Format("La cuenta {0} ingresada no existe.", item.codCuenta));
                        }

                        oVoucherDet = new VoucherItemE
                        {
                            numItem = String.Format("{0:00000}", numItemDet),
                            idPersona = oCuenta.indSolicitaAnexo == "S" ? item.idAuxiliar : null,
                            idMoneda = item.idMonedaRec,
                            tipCambio = item.tipCambio,
                            indCambio = item.indTicaAuto ? "S" : "N",
                            idCCostos = String.Empty,
                            numVerPlanCuentas = item.numVerPlanCuentas,
                            codCuenta = item.codCuenta,
                            desGlosa = oRendicion.Glosa,//"RENDICION N° " + oRendicion.codRendicion;
                            fecDocumento = oCuenta.indSolicitaDcto == "S" ? item.fecDocumento : (DateTime?)null,
                            fecVencimiento = null,
                            idDocumento = oCuenta.indSolicitaDcto == "S" ? item.idDocumento : string.Empty,
                            serDocumento = oCuenta.indSolicitaDcto == "S" ? item.numSerie : String.Empty,
                            numDocumento = oCuenta.indSolicitaDcto == "S" ? item.numDocumento : string.Empty,
                            fecDocumentoRef = null,
                            idDocumentoRef = String.Empty,
                            serDocumentoRef = String.Empty,
                            numDocumentoRef = String.Empty,
                            indDebeHaber = DebeHaber,
                            indAutomatica = Variables.NO,
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
                            flagDetraccion = Variables.NO,
                            numDetraccion = String.Empty,
                            fecDetraccion = null,
                            tipDetraccion = String.Empty,
                            TasaDetraccion = 0,
                            MontoDetraccion = 0,
                            indPagoDetra = false,
                            indReparable = item.indReparable,
                            idConceptoRep = item.idConceptoRep,
                            desReferenciaRep = item.desReferenciaRep,
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
                            UsuarioRegistro = Usuario,
                            indCuentaGastos = oCuenta.indCuentaGastos,
                            codCuentaDestino = oCuenta.codCuentaDestino,
                            codCuentaTransferencia = oCuenta.codCuentaTransferencia
                        };

                        if (item.idMoneda == "01")
                        {
                            oVoucherDet.impSoles = item.MontoDoc;
                            oVoucherDet.impDolares = item.DolaresRecibidos;
                        }
                        else
                        {
                            oVoucherDet.impSoles = item.SolesRecibidos;
                            oVoucherDet.impDolares = item.MontoDoc;
                        }

                        oVoucher.ListaVouchers.Add(oVoucherDet);
                    }

                    #endregion

                    Decimal totDebeSoles = Decimal.Round((from x in oVoucher.ListaVouchers where x.indDebeHaber == Variables.Debe select x.impSoles).Sum(), 2);
                    Decimal totDebeDolares = Decimal.Round((from x in oVoucher.ListaVouchers where x.indDebeHaber == Variables.Debe select x.impDolares).Sum(), 2);
                    Decimal totHaberSoles = Decimal.Round((from x in oVoucher.ListaVouchers where x.indDebeHaber == Variables.Haber select x.impSoles).Sum(), 2);
                    Decimal totHaberDolares = Decimal.Round((from x in oVoucher.ListaVouchers where x.indDebeHaber == Variables.Haber select x.impDolares).Sum(), 2);
                    Decimal DiferenciaSoles = Variables.ValorCeroDecimal, DiferenciaDolares = Variables.ValorCeroDecimal;
                    Decimal impSoles = 0, impDolares = 0;
                    String CtaBase = String.Empty, CuentaGanancia = String.Empty, CuentaPerdida = String.Empty;
                    
                    DiferenciaSoles = totDebeSoles - totHaberSoles;
                    DiferenciaDolares = totDebeDolares - totHaberDolares;
                    oCuenta = null;

                    if (Math.Abs(DiferenciaSoles) > 0.3M || Math.Abs(DiferenciaDolares) > 0.3M)
                    {
                        #region Diferencia de Cambio

                        CuentaGanancia = oParametro.Ganancia;
                        CuentaPerdida = oParametro.Perdida;

                        #region Diferencia en Soles

                        if (DiferenciaSoles != 0)
                        {
                            numItemDet++;
                            impSoles = Math.Abs(DiferenciaSoles);
                            impDolares = 0;

                            if (DiferenciaSoles > 0)
                            {
                                CtaBase = CuentaGanancia;
                                DebeHaber = Variables.Haber;
                            }
                            else
                            {
                                CtaBase = CuentaPerdida;
                                DebeHaber = Variables.Debe;
                            }

                            oCuenta = new PlanCuentasAD().ObtenerPlanCuentasPorCodigo(oRendicion.idEmpresa, oVoucher.ListaVouchers[0].numVerPlanCuentas, CtaBase);

                            if (oCuenta == null)
                            {
                                throw new Exception(String.Format("La cuenta {0} ingresada no existe.", CtaBase));
                            }

                            oVoucherDet = new VoucherItemE
                            {
                                numItem = String.Format("{0:00000}", numItemDet),
                                idPersona = null,
                                idMoneda = "01",
                                tipCambio = 0,
                                indCambio = "N",
                                idCCostos = String.Empty,
                                numVerPlanCuentas = oParametro.numVerPlanCuentas,
                                codCuenta = CtaBase,
                                desGlosa = "RENDICION DE PROVEEDOR N° " + oRendicion.codRendicion,
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
                                impSoles = impSoles,
                                impDolares = impDolares,
                                indAutomatica = Variables.NO,
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
                                flagDetraccion = Variables.NO,
                                numDetraccion = String.Empty,
                                fecDetraccion = null,
                                tipDetraccion = String.Empty,
                                TasaDetraccion = 0,
                                MontoDetraccion = 0,
                                indPagoDetra = false,
                                indReparable = Variables.NO,
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
                                UsuarioRegistro = Usuario,

                                indCuentaGastos = oCuenta.indCuentaGastos,
                                codCuentaDestino = oCuenta.codCuentaDestino,
                                codCuentaTransferencia = oCuenta.codCuentaTransferencia
                            };

                            oVoucher.ListaVouchers.Add(oVoucherDet);
                        }

                        #endregion

                        #region Diferencia en Dólares

                        if (DiferenciaDolares != 0)
                        {
                            numItemDet++;
                            impSoles = 0;
                            impDolares = Math.Abs(DiferenciaDolares);

                            if (DiferenciaDolares > 0)
                            {
                                CtaBase = CuentaGanancia;
                                DebeHaber = Variables.Haber;
                            }
                            else
                            {
                                CtaBase = CuentaPerdida;
                                DebeHaber = Variables.Debe;
                            }

                            oCuenta = new PlanCuentasAD().ObtenerPlanCuentasPorCodigo(oRendicion.idEmpresa, oVoucher.ListaVouchers[0].numVerPlanCuentas, CtaBase);

                            if (oCuenta == null)
                            {
                                throw new Exception(String.Format("La cuenta {0} ingresada no existe.", CtaBase));
                            }

                            oVoucherDet = new VoucherItemE
                            {
                                numItem = String.Format("{0:00000}", numItemDet),
                                idPersona = null,
                                idMoneda = "02",
                                tipCambio = 0,
                                indCambio = "N",
                                idCCostos = String.Empty,
                                numVerPlanCuentas = oParametro.numVerPlanCuentas,
                                codCuenta = CtaBase,
                                desGlosa = "RENDICION DE PROVEEDOR N° " + oRendicion.codRendicion,
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
                                impSoles = impSoles,
                                impDolares = impDolares,
                                indAutomatica = Variables.NO,
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
                                flagDetraccion = Variables.NO,
                                numDetraccion = String.Empty,
                                fecDetraccion = null,
                                tipDetraccion = String.Empty,
                                TasaDetraccion = 0,
                                MontoDetraccion = 0,
                                indPagoDetra = false,
                                indReparable = Variables.NO,
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
                                UsuarioRegistro = Usuario,

                                indCuentaGastos = oCuenta.indCuentaGastos,
                                codCuentaDestino = oCuenta.codCuentaDestino,
                                codCuentaTransferencia = oCuenta.codCuentaTransferencia
                            };

                            oVoucher.ListaVouchers.Add(oVoucherDet);
                        }

                        #endregion

                        #endregion
                    }
                    else
                    {
                        #region Ajuste

                        foreach (VoucherItemE item in oVoucher.ListaVouchers)
                        {
                            if (Convert.ToInt32(item.numItem) == numItemDet - 1)
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

                        #endregion
                    }

                    #region Cuentas Automáticas

                    List<VoucherItemE> oListaVoucherItems = new List<VoucherItemE>(oVoucher.ListaVouchers);

                    foreach (VoucherItemE item in oListaVoucherItems)
                    {
                        if (item.indCuentaGastos == Variables.SI)
                        {
                            if (!String.IsNullOrEmpty(item.codCuentaDestino))
                            {
                                numItemDet++;
                                oVoucher.ListaVouchers.Add(CuentaAutomatica(item, numItemDet, item.codCuentaDestino));
                            }

                            if (!String.IsNullOrEmpty(item.codCuentaTransferencia))
                            {
                                numItemDet++;
                                oVoucher.ListaVouchers.Add(CuentaAutomatica(item, numItemDet, item.codCuentaTransferencia));
                            }
                        }
                    }

                    #endregion

                    #region Completando datos de la Cabecera del Voucher

                    totDebeSoles = Decimal.Round((from x in oVoucher.ListaVouchers where x.indDebeHaber == Variables.Debe select x.impSoles).Sum(), 2);
                    totDebeDolares = Decimal.Round((from x in oVoucher.ListaVouchers where x.indDebeHaber == Variables.Debe select x.impDolares).Sum(), 2);
                    totHaberSoles = Decimal.Round((from x in oVoucher.ListaVouchers where x.indDebeHaber == Variables.Haber select x.impSoles).Sum(), 2);
                    totHaberDolares = Decimal.Round((from x in oVoucher.ListaVouchers where x.indDebeHaber == Variables.Haber select x.impDolares).Sum(), 2);

                    oVoucher.impDebeSoles = totDebeSoles;
                    oVoucher.impHaberSoles = totHaberSoles;
                    oVoucher.impDebeDolares = totDebeDolares;
                    oVoucher.impHaberDolares = totHaberDolares;

                    DiferenciaSoles = totDebeSoles - totHaberSoles;
                    DiferenciaDolares = totDebeDolares - totHaberDolares;

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

                    if (DiferenciaSoles != Variables.Cero || DiferenciaDolares != Variables.Cero)
                    {
                        oVoucher.indEstado = Variables.VoucherDescuadrado;
                    }
                    else
                    {
                        oVoucher.indEstado = Variables.VoucherCuadrado;
                    }

                    oVoucher.numItems = oVoucher.ListaVouchers.Count();

                    #endregion

                    oVoucher = new VoucherLN().GrabarVouchers(oVoucher, EnumOpcionGrabar.Insertar);

                    #endregion

                    //Actualizando los datos contables en la rendición...
                    oRendicion.AnioPeriodo = oVoucher.AnioPeriodo;
                    oRendicion.MesPeriodo = oVoucher.MesPeriodo;
                    oRendicion.idComprobante = oVoucher.idComprobante;
                    oRendicion.numFile = oVoucher.numFile;
                    oRendicion.numVoucher = oVoucher.numVoucher;
                    oRendicion.UsuarioModificacion = Usuario;

                    ActualizarRendicionConta(oRendicion);

                    //Actualizando el Estado
                    new SolicitudProveedorRendicionAD().ActualizarRendicionEstado(oRendicion.idRendicion, true, Usuario);

                    #endregion

                    #region Voucher Depósito

                    if (oRendicion.indDeposito)
                    {
                        oCuenta = null;
                        numItemDet = 0;
                        String numVoucherDeposito = "0";
                        VoucherE oVoucherDeposito = null;
                        VoucherItemE oVoucherDetDeposito = null;
                        List<BancosCuentasE> bancos = new BancosCuentasAD().ListarCuentasPorBancos(oRendicion.idEmpresa, oRendicion.idLocal, oRendicion.idBancoDepo.Value, oRendicion.idMonedaDepo);

                        if (bancos == null || bancos.Count == 0)
                        {
                            throw new Exception("Falta configurar la cuenta contable para el banco y moneda elegido.");
                        }

                        if (String.IsNullOrWhiteSpace(oParametro.DiarioIngresos))
                        {
                            throw new Exception("Falta configurar el Diario para los Ingresos en los Parámetros Contables.");
                        }

                        ComprobantesFileE oFile = new ComprobantesFileAD().ObtenerFilePorCuenta(oRendicion.idEmpresa, oParametro.DiarioIngresos, oRendicion.idMonedaDepo, oRendicion.oListaRendiciones[0].numVerPlanCuentas, bancos[0].codCuenta);

                        if (oFile == null)
                        {
                            throw new Exception("No se encuentra ningún File Contable con la cuenta contable del banco elegido.");
                        }

                        //Revisando si existe Voucher
                        if (!String.IsNullOrWhiteSpace(oRendicion.DiarioDepo) && !String.IsNullOrWhiteSpace(oRendicion.FileDepo) && !String.IsNullOrWhiteSpace(oRendicion.numVoucherDepo))
                        {
                            VoucherE VoucherTmp = new VoucherAD().ObtenerVoucherPorCodigo(oRendicion.idEmpresa, oRendicion.idLocal, oRendicion.AnioDepo, oRendicion.MesDepo, oRendicion.numVoucherDepo, oRendicion.DiarioDepo, oRendicion.FileDepo);

                            if (VoucherTmp == null)
                            {
                                numVoucherDeposito = oRendicion.numVoucherDepo;
                            }
                            else
                            {
                                numVoucherDeposito = "0";
                            }
                        }

                        #region Cabecera del Voucher

                        oTica = new TipoCambioAD().ObtenerTipoCambioPorDia("02", oRendicion.fecDepo.Value.ToString("yyyyMMdd"));

                        if (oTica == null)
                        {
                            throw new Exception(String.Format("No existe Tipo de Cambio para el dia {0}", oRendicion.fecDepo.Value.ToString("dd/MM/yyyy")));
                        }

                        TipoCambio = oTica.valVenta;

                        oVoucherDeposito = new VoucherE
                        {
                            idEmpresa = oRendicion.idEmpresa,
                            idLocal = oRendicion.idLocal,
                            AnioPeriodo = oRendicion.fecDepo.Value.ToString("yyyy"),
                            MesPeriodo = oRendicion.fecDepo.Value.ToString("MM"),
                            numVoucher = numVoucherDeposito,
                            idComprobante = oParametro.DiarioIngresos,
                            numFile = oFile.numFile,
                            fecTransferencia = null,
                            //oVoucher.numItems = ;
                            idMoneda = oRendicion.idMonedaDepo,
                            fecOperacion = oRendicion.fecDepo.Value,
                            fecDocumento = oRendicion.fecDepo.Value,
                            //oVoucher.impDebeSoles = 0;
                            //oVoucher.impHaberSoles = 0;
                            //oVoucher.impDebeDolares = 0;
                            //oVoucher.impHaberDolares = 0;
                            //oVoucher.impMonOrigDeb = 0;
                            //oVoucher.impMonOrigHab = 0;
                            GlosaGeneral = oRendicion.GlosaDepo,
                            tipCambio = TipoCambio,
                            RazonSocial = oRendicion.RazonSocial,
                            numDocumentoPresu = "VARIOS",
                            indHojaCosto = "N",
                            numHojaCosto = String.Empty,
                            numOrdenCompra = String.Empty,
                            sistema = "6", //Tesoreria
                            EsAutomatico = true,
                            UsuarioRegistro = Usuario
                        };

                        #endregion

                        #region Detalle
                        
                        #region Banco

                        numItemDet++;
                        oTica = new TipoCambioAD().ObtenerTipoCambioPorDia("02", oDetalleSolicitud[0].fecOpeSol.ToString("yyyyMMdd"));

                        if (oTica == null)
                        {
                            throw new Exception(String.Format("No existe Tipo de Cambio para el dia {0} del Anticipo", oDetalleSolicitud[0].fecOpeSol.ToString("dd/MM/yyyy")));
                        }

                        TipoCambio = oTica.valVenta;

                        //ComprobantesFileE oNumFile = new ComprobantesFileAD().ObtenerComprobantesFile(oRendicion.idEmpresa, oRendicion.idComprobante, oRendicion.numFile);

                        //if (oNumFile == null)
                        //{
                        //    throw new Exception("No existe el File seleccionado.");
                        //}
                        //else
                        //{
                        //    if (String.IsNullOrWhiteSpace(oNumFile.codCuenta))
                        //    {
                        //        throw new Exception("El File seleccionado no tiene cuenta.");
                        //    }
                        //}

                        //ComprobantesFileE oNumFileBanco = new ComprobantesFileAD().ObtenerFilePorCuenta(oRendicion.idEmpresa, oRendicion.idComprobante, oNumFile.idMoneda, oNumFile.numVerPlanCuentas, oNumFile.codCuenta);
                        oCuenta = new PlanCuentasAD().ObtenerPlanCuentasPorCodigo(oRendicion.idEmpresa, oFile.numVerPlanCuentas, oFile.codCuenta);

                        if (oCuenta == null)
                        {
                            throw new Exception(String.Format("La cuenta {0} ingresada no existe.", oFile.codCuenta));
                        }

                        oVoucherDetDeposito = new VoucherItemE
                        {
                            numItem = String.Format("{0:00000}", numItemDet),
                            idPersona = oCuenta.indSolicitaAnexo == "S" ? oFile.idBanco : (int?)null,
                            idMoneda = oDetalleSolicitud[0].idMonedaSol,
                            tipCambio = TipoCambio,
                            indCambio = "S",
                            idCCostos = String.Empty,
                            numVerPlanCuentas = oFile.numVerPlanCuentas,
                            codCuenta = oFile.codCuenta,
                            desGlosa = oRendicion.GlosaDepo,//"ANTICIPO DE PROVEEDOR N° " + oRendicion.codSolicitud,
                            fecDocumento = oCuenta.indSolicitaDcto == "S" ? oRendicion.fecDepo : (DateTime?)null,
                            fecVencimiento = null,
                            idDocumento = oCuenta.indSolicitaDcto == "S" ? oRendicion.idDocumentoDepo : String.Empty,
                            serDocumento = "TR",
                            numDocumento = oCuenta.indSolicitaDcto == "S" ? oRendicion.numDocumentoDepo : String.Empty,
                            fecDetraccion = null,
                            idDocumentoRef = String.Empty,
                            serDocumentoRef = String.Empty,
                            numDocumentoRef = String.Empty,
                            indDebeHaber = "D"
                        };

                        if (oRendicion.idMonedaDepo == Variables.Soles)
                        {
                            oVoucherDetDeposito.impSoles = oRendicion.ImporteDepo;
                            oVoucherDetDeposito.impDolares = Math.Round(oRendicion.ImporteDepo / TipoCambio, 2);
                        }
                        else
                        {
                            oVoucherDetDeposito.impSoles = Math.Round(oRendicion.ImporteDepo * TipoCambio, 2);
                            oVoucherDetDeposito.impDolares = oRendicion.ImporteDepo;
                        }

                        oVoucherDetDeposito.indAutomatica = Variables.NO;
                        oVoucherDetDeposito.CorrelativoAjuste = String.Empty;
                        oVoucherDetDeposito.codFteFin = String.Empty;
                        oVoucherDetDeposito.codProgramaCred = String.Empty;
                        oVoucherDetDeposito.indMovimientoAnterior = String.Empty;
                        oVoucherDetDeposito.tipPartidaPresu = String.Empty;
                        oVoucherDetDeposito.codPartidaPresu = String.Empty;
                        oVoucherDetDeposito.numDocumentoPresu = String.Empty;
                        oVoucherDetDeposito.codColumnaCoven = null;
                        oVoucherDetDeposito.depAduanera = null;
                        oVoucherDetDeposito.nroDua = String.Empty;
                        oVoucherDetDeposito.AnioDua = String.Empty;
                        oVoucherDetDeposito.flagDetraccion = Variables.NO;
                        oVoucherDetDeposito.numDetraccion = String.Empty;
                        oVoucherDetDeposito.fecDetraccion = null;
                        oVoucherDetDeposito.tipDetraccion = String.Empty;
                        oVoucherDetDeposito.TasaDetraccion = 0;
                        oVoucherDetDeposito.MontoDetraccion = 0;
                        oVoucherDetDeposito.indPagoDetra = false;
                        oVoucherDetDeposito.indReparable = Variables.NO;
                        oVoucherDetDeposito.idConceptoRep = null;
                        oVoucherDetDeposito.desReferenciaRep = String.Empty;
                        oVoucherDetDeposito.idAlmacen = String.Empty;
                        oVoucherDetDeposito.tipMovimientoAlmacen = String.Empty;
                        oVoucherDetDeposito.numDocumentoAlmacen = String.Empty;
                        oVoucherDetDeposito.numItemAlmacen = String.Empty;
                        oVoucherDetDeposito.CajaSucursal = String.Empty;
                        oVoucherDetDeposito.indCompra = String.Empty;
                        oVoucherDetDeposito.indConciliado = String.Empty;
                        oVoucherDetDeposito.fecRecepcion = null;
                        oVoucherDetDeposito.codMedioPago = null;
                        oVoucherDetDeposito.idCampana = null;
                        oVoucherDetDeposito.idConceptoGasto = null;
                        oVoucherDetDeposito.UsuarioRegistro = Usuario;

                        oVoucherDetDeposito.indCuentaGastos = oCuenta.indCuentaGastos;
                        oVoucherDetDeposito.codCuentaDestino = oCuenta.codCuentaDestino;
                        oVoucherDetDeposito.codCuentaTransferencia = oCuenta.codCuentaTransferencia;

                        oVoucherDeposito.ListaVouchers.Add(oVoucherDetDeposito);

                        #endregion

                        #region Rendición

                        numItemDet++;
                        TipoCambio = oTica.valVenta;

                        oCuenta = new PlanCuentasAD().ObtenerPlanCuentasPorCodigo(oRendicion.idEmpresa, oDetalleSolicitud[0].numVerPlanCuentas, oDetalleSolicitud[0].codCuenta);

                        if (oCuenta == null)
                        {
                            throw new Exception(String.Format("La cuenta {0} ingresada no existe.", oDetalleSolicitud[0].codCuenta));
                        }

                        oVoucherDetDeposito = new VoucherItemE
                        {
                            numItem = String.Format("{0:00000}", numItemDet),
                            idPersona = oCuenta.indSolicitaAnexo == "S" ? oRendicion.idProveedor : (int?)null,
                            idMoneda = oDetalleSolicitud[0].idMonedaSol,
                            tipCambio = TipoCambio,
                            indCambio = "S",
                            idCCostos = String.Empty,
                            numVerPlanCuentas = oDetalleSolicitud[0].numVerPlanCuentas,
                            codCuenta = oDetalleSolicitud[0].codCuenta,
                            desGlosa = oRendicion.GlosaDepo,//"ANTICIPO DE PROVEEDOR N° " + oRendicion.codSolicitud,
                            fecDocumento = oCuenta.indSolicitaDcto == "S" ? oDetalleSolicitud[0].fecOpeSol : (DateTime?)null,
                            fecVencimiento = null,
                            idDocumento = oCuenta.indSolicitaDcto == "S" ? "AN" : String.Empty,
                            serDocumento = String.Empty,
                            numDocumento = oCuenta.indSolicitaDcto == "S" ? oRendicion.codSolicitud : String.Empty,
                            fecDetraccion = null,
                            idDocumentoRef = String.Empty,
                            serDocumentoRef = String.Empty,
                            numDocumentoRef = String.Empty,
                            indDebeHaber = "H"
                        };

                        if (oRendicion.idMonedaSol == Variables.Soles)
                        {
                            oVoucherDetDeposito.impSoles = oRendicion.ImporteDepo;
                            oVoucherDetDeposito.impDolares = Math.Round(oRendicion.ImporteDepo / TipoCambio, 2);
                        }
                        else
                        {
                            oVoucherDetDeposito.impSoles = Math.Round(oRendicion.ImporteDepo * TipoCambio, 2);
                            oVoucherDetDeposito.impDolares = oRendicion.ImporteDepo;
                        }

                        oVoucherDetDeposito.indAutomatica = Variables.NO;
                        oVoucherDetDeposito.CorrelativoAjuste = String.Empty;
                        oVoucherDetDeposito.codFteFin = String.Empty;
                        oVoucherDetDeposito.codProgramaCred = String.Empty;
                        oVoucherDetDeposito.indMovimientoAnterior = String.Empty;
                        oVoucherDetDeposito.tipPartidaPresu = String.Empty;
                        oVoucherDetDeposito.codPartidaPresu = String.Empty;
                        oVoucherDetDeposito.numDocumentoPresu = String.Empty;
                        oVoucherDetDeposito.codColumnaCoven = null;
                        oVoucherDetDeposito.depAduanera = null;
                        oVoucherDetDeposito.nroDua = String.Empty;
                        oVoucherDetDeposito.AnioDua = String.Empty;
                        oVoucherDetDeposito.flagDetraccion = Variables.NO;
                        oVoucherDetDeposito.numDetraccion = String.Empty;
                        oVoucherDetDeposito.fecDetraccion = null;
                        oVoucherDetDeposito.tipDetraccion = String.Empty;
                        oVoucherDetDeposito.TasaDetraccion = 0;
                        oVoucherDetDeposito.MontoDetraccion = 0;
                        oVoucherDetDeposito.indPagoDetra = false;
                        oVoucherDetDeposito.indReparable = Variables.NO;
                        oVoucherDetDeposito.idConceptoRep = null;
                        oVoucherDetDeposito.desReferenciaRep = String.Empty;
                        oVoucherDetDeposito.idAlmacen = String.Empty;
                        oVoucherDetDeposito.tipMovimientoAlmacen = String.Empty;
                        oVoucherDetDeposito.numDocumentoAlmacen = String.Empty;
                        oVoucherDetDeposito.numItemAlmacen = String.Empty;
                        oVoucherDetDeposito.CajaSucursal = String.Empty;
                        oVoucherDetDeposito.indCompra = String.Empty;
                        oVoucherDetDeposito.indConciliado = String.Empty;
                        oVoucherDetDeposito.fecRecepcion = null;
                        oVoucherDetDeposito.codMedioPago = null;
                        oVoucherDetDeposito.idCampana = null;
                        oVoucherDetDeposito.idConceptoGasto = null;
                        oVoucherDetDeposito.UsuarioRegistro = Usuario;

                        oVoucherDetDeposito.indCuentaGastos = oCuenta.indCuentaGastos;
                        oVoucherDetDeposito.codCuentaDestino = oCuenta.codCuentaDestino;
                        oVoucherDetDeposito.codCuentaTransferencia = oCuenta.codCuentaTransferencia;

                        oVoucherDeposito.ListaVouchers.Add(oVoucherDetDeposito);

                        #endregion 

                        totDebeSoles = Decimal.Round((from x in oVoucherDeposito.ListaVouchers where x.indDebeHaber == Variables.Debe select x.impSoles).Sum(), 2);
                        totDebeDolares = Decimal.Round((from x in oVoucherDeposito.ListaVouchers where x.indDebeHaber == Variables.Debe select x.impDolares).Sum(), 2);
                        totHaberSoles = Decimal.Round((from x in oVoucherDeposito.ListaVouchers where x.indDebeHaber == Variables.Haber select x.impSoles).Sum(), 2);
                        totHaberDolares = Decimal.Round((from x in oVoucherDeposito.ListaVouchers where x.indDebeHaber == Variables.Haber select x.impDolares).Sum(), 2);
                        DiferenciaSoles = Variables.ValorCeroDecimal;
                        DiferenciaDolares = Variables.ValorCeroDecimal;
                        impSoles = 0;
                        impDolares = 0;
                        CtaBase = String.Empty;
                        CuentaGanancia = String.Empty;
                        CuentaPerdida = String.Empty;
                        oCuenta = null;

                        DiferenciaSoles = totDebeSoles - totHaberSoles;
                        DiferenciaDolares = totDebeDolares - totHaberDolares;

                        if (Math.Abs(DiferenciaSoles) > 0.3M || Math.Abs(DiferenciaDolares) > 0.3M)
                        {
                            #region Diferencia de Cambio

                            CuentaGanancia = oParametro.Ganancia;
                            CuentaPerdida = oParametro.Perdida;

                            #region Diferencia en Soles

                            if (DiferenciaSoles != 0)
                            {
                                numItemDet++;
                                impSoles = Math.Abs(DiferenciaSoles);
                                impDolares = 0;

                                if (DiferenciaSoles > 0)
                                {
                                    CtaBase = CuentaGanancia;
                                    DebeHaber = Variables.Haber;
                                }
                                else
                                {
                                    CtaBase = CuentaPerdida;
                                    DebeHaber = Variables.Debe;
                                }

                                oCuenta = new PlanCuentasAD().ObtenerPlanCuentasPorCodigo(oRendicion.idEmpresa, oVoucher.ListaVouchers[0].numVerPlanCuentas, CtaBase);

                                if (oCuenta == null)
                                {
                                    throw new Exception(String.Format("La cuenta {0} ingresada no existe.", CtaBase));
                                }

                                oVoucherDetDeposito = new VoucherItemE
                                {
                                    numItem = String.Format("{0:00000}", numItemDet),
                                    idPersona = null,
                                    idMoneda = "01",
                                    tipCambio = 0,
                                    indCambio = "N",
                                    idCCostos = String.Empty,
                                    numVerPlanCuentas = oParametro.numVerPlanCuentas,
                                    codCuenta = CtaBase,
                                    desGlosa = "RENDICION DE PROVEEDOR N° " + oRendicion.codRendicion,
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
                                    impSoles = impSoles,
                                    impDolares = impDolares,
                                    indAutomatica = Variables.NO,
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
                                    flagDetraccion = Variables.NO,
                                    numDetraccion = String.Empty,
                                    fecDetraccion = null,
                                    tipDetraccion = String.Empty,
                                    TasaDetraccion = 0,
                                    MontoDetraccion = 0,
                                    indPagoDetra = false,
                                    indReparable = Variables.NO,
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
                                    UsuarioRegistro = Usuario,

                                    indCuentaGastos = oCuenta.indCuentaGastos,
                                    codCuentaDestino = oCuenta.codCuentaDestino,
                                    codCuentaTransferencia = oCuenta.codCuentaTransferencia
                                };

                                oVoucherDeposito.ListaVouchers.Add(oVoucherDetDeposito);
                            }

                            #endregion

                            #region Diferencia en Dólares

                            if (DiferenciaDolares != 0)
                            {
                                numItemDet++;
                                impSoles = 0;
                                impDolares = Math.Abs(DiferenciaDolares);

                                if (DiferenciaDolares > 0)
                                {
                                    CtaBase = CuentaGanancia;
                                    DebeHaber = Variables.Haber;
                                }
                                else
                                {
                                    CtaBase = CuentaPerdida;
                                    DebeHaber = Variables.Debe;
                                }

                                oCuenta = new PlanCuentasAD().ObtenerPlanCuentasPorCodigo(oRendicion.idEmpresa, oVoucher.ListaVouchers[0].numVerPlanCuentas, CtaBase);

                                if (oCuenta == null)
                                {
                                    throw new Exception(String.Format("La cuenta {0} ingresada no existe.", CtaBase));
                                }

                                oVoucherDetDeposito = new VoucherItemE
                                {
                                    numItem = String.Format("{0:00000}", numItemDet),
                                    idPersona = null,
                                    idMoneda = "02",
                                    tipCambio = 0,
                                    indCambio = "N",
                                    idCCostos = String.Empty,
                                    numVerPlanCuentas = oParametro.numVerPlanCuentas,
                                    codCuenta = CtaBase,
                                    desGlosa = "RENDICION DE PROVEEDOR N° " + oRendicion.codRendicion,
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
                                    impSoles = impSoles,
                                    impDolares = impDolares,
                                    indAutomatica = Variables.NO,
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
                                    flagDetraccion = Variables.NO,
                                    numDetraccion = String.Empty,
                                    fecDetraccion = null,
                                    tipDetraccion = String.Empty,
                                    TasaDetraccion = 0,
                                    MontoDetraccion = 0,
                                    indPagoDetra = false,
                                    indReparable = Variables.NO,
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
                                    UsuarioRegistro = Usuario,

                                    indCuentaGastos = oCuenta.indCuentaGastos,
                                    codCuentaDestino = oCuenta.codCuentaDestino,
                                    codCuentaTransferencia = oCuenta.codCuentaTransferencia
                                };

                                oVoucherDeposito.ListaVouchers.Add(oVoucherDetDeposito);
                            }

                            #endregion

                            #endregion
                        }
                        else
                        {
                            #region Ajuste

                            foreach (VoucherItemE item in oVoucher.ListaVouchers)
                            {
                                if (Convert.ToInt32(item.numItem) == numItemDet - 1)
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

                            #endregion
                        }

                        #region Cuentas Automáticas

                        oListaVoucherItems = new List<VoucherItemE>(oVoucherDeposito.ListaVouchers);

                        foreach (VoucherItemE item in oListaVoucherItems)
                        {
                            if (item.indCuentaGastos == Variables.SI)
                            {
                                if (!String.IsNullOrEmpty(item.codCuentaDestino))
                                {
                                    numItemDet++;
                                    oVoucherDeposito.ListaVouchers.Add(CuentaAutomatica(item, numItemDet, item.codCuentaDestino));
                                }

                                if (!String.IsNullOrEmpty(item.codCuentaTransferencia))
                                {
                                    numItemDet++;
                                    oVoucherDeposito.ListaVouchers.Add(CuentaAutomatica(item, numItemDet, item.codCuentaTransferencia));
                                }
                            }
                        }

                        #endregion

                        #region Completando datos de la Cabecera del Voucher

                        totDebeSoles = Decimal.Round((from x in oVoucherDeposito.ListaVouchers where x.indDebeHaber == Variables.Debe select x.impSoles).Sum(), 2);
                        totDebeDolares = Decimal.Round((from x in oVoucherDeposito.ListaVouchers where x.indDebeHaber == Variables.Debe select x.impDolares).Sum(), 2);
                        totHaberSoles = Decimal.Round((from x in oVoucherDeposito.ListaVouchers where x.indDebeHaber == Variables.Haber select x.impSoles).Sum(), 2);
                        totHaberDolares = Decimal.Round((from x in oVoucherDeposito.ListaVouchers where x.indDebeHaber == Variables.Haber select x.impDolares).Sum(), 2);

                        oVoucherDeposito.impDebeSoles = totDebeSoles;
                        oVoucherDeposito.impHaberSoles = totHaberSoles;
                        oVoucherDeposito.impDebeDolares = totDebeDolares;
                        oVoucherDeposito.impHaberDolares = totHaberDolares;

                        DiferenciaSoles = totDebeSoles - totHaberSoles;
                        DiferenciaDolares = totDebeDolares - totHaberDolares;

                        if (oVoucher.idMoneda == Variables.Soles)
                        {
                            oVoucherDeposito.impMonOrigDeb = totDebeSoles;
                            oVoucherDeposito.impMonOrigHab = totHaberSoles;
                        }
                        else
                        {
                            oVoucherDeposito.impMonOrigDeb = totDebeDolares;
                            oVoucherDeposito.impMonOrigHab = totHaberDolares;
                        }

                        if (DiferenciaSoles != Variables.Cero || DiferenciaDolares != Variables.Cero)
                        {
                            oVoucherDeposito.indEstado = Variables.VoucherDescuadrado;
                        }
                        else
                        {
                            oVoucherDeposito.indEstado = Variables.VoucherCuadrado;
                        }

                        oVoucherDeposito.numItems = oVoucherDeposito.ListaVouchers.Count();

                        #endregion

                        oVoucherDeposito = new VoucherLN().GrabarVouchers(oVoucherDeposito, EnumOpcionGrabar.Insertar);

                        #endregion

                        //Actualizando los datos contables del deposito de la rendición...
                        oRendicion.AnioDepo = oVoucherDeposito.AnioPeriodo;
                        oRendicion.MesDepo = oVoucherDeposito.MesPeriodo;
                        oRendicion.DiarioDepo = oVoucherDeposito.idComprobante;
                        oRendicion.FileDepo = oVoucherDeposito.numFile;
                        oRendicion.numVoucherDepo = oVoucherDeposito.numVoucher;
                        oRendicion.UsuarioModificacion = Usuario;

                        new SolicitudProveedorRendicionAD().ActualizarRendicionContaDepo(oRendicion);
                    } 

                    #endregion

                    if (String.IsNullOrWhiteSpace(Mensaje))
                    {
                        Mensaje = String.Format("Se generó el voucher {0}-{1}-{2}", oVoucher.idComprobante, oVoucher.numFile, oVoucher.numVoucher);
                    }

                    #region Provisiones

                    ProvisionesE ItemProv = null;
                    List<ProvisionesE> ListaProvisiones = new List<ProvisionesE>();

                    //Recorriendo el detalle para saber si hay provisiones...
                    foreach (SolicitudProveedorRendicionDetE item in oRendicion.oListaRendiciones)
                    {
                        if (item.EsAutomatico && item.idProvision > 0)
                        {
                            ItemProv = new ProvisionesAD().RecuperarProvisionesPorId(oRendicion.idEmpresa, oRendicion.idLocal, Convert.ToInt32(item.idProvision));

                            if (ItemProv != null)
                            {
                                if (!String.IsNullOrWhiteSpace(ItemProv.numVoucher))
                                {
                                    VoucherE oVoucherExiste = new VoucherAD().ObtenerVoucherPorCodigo(oRendicion.idEmpresa, oRendicion.idLocal, ItemProv.AnioPeriodo, ItemProv.MesPeriodo, ItemProv.numVoucher, ItemProv.idComprobante, ItemProv.numFile);

                                    if (oVoucherExiste != null)
                                    {
                                        throw new Exception(String.Format("En la provisión {0} el Nro. de Voucher {1} {2}-{3} ya ha sido asignado a {4}, limpie el número de voucher.", ItemProv.idProvision.ToString(), oVoucherExiste.idComprobante, oVoucherExiste.numFile, oVoucherExiste.numVoucher, oVoucherExiste.numDocumentoPresu));
                                    }
                                }

                                ListaProvisiones.Add(ItemProv);
                            }
                        }
                    }

                    //Mandando a cerrar las provisiones si es que las hay...
                    if (ListaProvisiones.Count > 0)
                    {
                        new ProvisionesLN().GenerarVoucherProvisionMasivo(ListaProvisiones, Usuario);
                    }

                    #endregion

                    //Revisando la cta cte de liquidaciones si hubiese
                    foreach (SolicitudProveedorRendicionDetE item in oRendicion.oListaRendiciones)
                    {
                        if (item.EsAutomatico && !item.indProvBusqueda && item.indLiquiImpor)
                        {
                            LiquidacionImportacionE oLiquidacion = new LiquidacionImportacionAD().ObtenerLiquidacionImportacion(item.idLiquiImpor.Value);

                            if (oLiquidacion != null)
                            {
                                //Verificando la Cabecera
                                CtaCteE oCtaCteCabecera = new CtaCteAD().ObtenerMaeCtaCtePorId(oLiquidacion.idCtaCte.Value);

                                if (oCtaCteCabecera == null)
                                {
                                    throw new Exception(String.Format("Debe volver a jalar el documento {0} {1}-{2} para poder actualizar su Cta.Cte.", item.idDocumento, item.numSerie, item.numDocumento));
                                }

                                #region Detalle

                                CtaCte_DetE oCtaCteDet = new CtaCte_DetE
                                {
                                    idEmpresa = oLiquidacion.idEmpresa,
                                    idCtaCte = oCtaCteCabecera.idCtaCte,
                                    idDocumentoMov = item.idDocumento,
                                    SerieMov = item.numSerie,
                                    NumeroMov = item.numDocumento,
                                    FechaMovimiento = Convert.ToDateTime(oRendicion.fecOperacion), //Se cambió 29-01-2019
                                    idMoneda = item.idMoneda,
                                    MontoMov = Convert.ToDecimal(item.MontoDoc),
                                    TipoCambio = item.tipCambio,
                                    TipAccion = EnumEstadoDocumentos.A.ToString(),
                                    numVerPlanCuentas = item.numVerPlanCuentas,
                                    codCuenta = item.codCuenta,
                                    desGlosa = oRendicion.Glosa,
                                    EsDetraccion = false,
                                    UsuarioRegistro = Usuario
                                };

                                oCtaCteDet = new CtaCte_DetAD().InsertarMaeCtaCteDet(oCtaCteDet);

                                #endregion

                                #region Verificando Saldo de la CtaCte.

                                List<CtaCte_DetE> oListaCtaCteDet = new CtaCte_DetAD().ListarMaeCtaCteDet(oLiquidacion.idEmpresa, oCtaCteCabecera.idCtaCte);
                                Decimal Saldo = 0;

                                foreach (CtaCte_DetE itemCtaCte in oListaCtaCteDet)
                                {
                                    if (itemCtaCte.TipAccion == "C")
                                    {
                                        Saldo = Saldo + Convert.ToDecimal(itemCtaCte.MontoMov);
                                    }
                                    else
                                    {
                                        Saldo = Saldo - Convert.ToDecimal(itemCtaCte.MontoMov);
                                    }
                                }

                                // Si el saldo es 0 Cancela colocar fecha de cancelacion de la cta.cte.
                                if (Saldo == 0 || Saldo == 0M)
                                {
                                    oCtaCteCabecera.FechaCancelacion = item.fecOperacion;
                                    new CtaCteAD().ActualizarFecCancelacionCtaCte(oCtaCteCabecera.idEmpresa, oCtaCteCabecera.idCtaCte, oCtaCteCabecera.FechaCancelacion, Usuario);
                                }

                                #endregion

                                #region Actualización de CtaCte Liquidación

                                item.idCtaCteLiqui = oCtaCteCabecera.idCtaCte;
                                item.idCtaCteItemLiqui = oCtaCteDet.idCtaCteItem;
                                new SolicitudProveedorRendicionDetAD().ActualizarProvRendiDetCtaCteLiqui(item, Usuario);

                                #endregion
                            }
                        }
                    }

                    oTrans.Complete();
                }

                return Mensaje;
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

        public int EliminarAsientoRendicion(SolicitudProveedorRendicionE oRendicion, String Usuario)
        {
            try
            {
                Int32 resp = 0;

                using (TransactionScope oTrans = new TransactionScope())
                {
                    oRendicion = new SolicitudProveedorRendicionAD().ObtenerSolicitudProveedorRendicion(oRendicion.idRendicion);
                    //Eliminando la Cta.Cte.
                    EliminarCtaCteProvision(oRendicion);
                    oRendicion.idCtaCte = null;
                    oRendicion.idCtaCteItem = null;

                    //Volviendo abrir la Rendición...
                    resp = new SolicitudProveedorRendicionAD().ActualizarRendicionEstado(oRendicion.idRendicion, false, Usuario);

                    //Eliminar el voucher...
                    new VoucherAD().EliminarVoucher(oRendicion.idEmpresa, oRendicion.idLocal, oRendicion.AnioPeriodo, oRendicion.MesPeriodo, oRendicion.numVoucher, oRendicion.idComprobante, oRendicion.numFile);

                    //Revisando si es con depósito
                    if (oRendicion.indDeposito)
                    {
                        if (!String.IsNullOrWhiteSpace(oRendicion.AnioDepo) && !String.IsNullOrWhiteSpace(oRendicion.MesDepo) && !String.IsNullOrWhiteSpace(oRendicion.numVoucherDepo))
                        {
                            //Eliminar el voucher...
                            new VoucherAD().EliminarVoucher(oRendicion.idEmpresa, oRendicion.idLocal, oRendicion.AnioDepo, oRendicion.MesDepo, oRendicion.numVoucherDepo, oRendicion.DiarioDepo, oRendicion.FileDepo);
                        }
                    }

                    #region Provisiones
                    
                    //Listando las rendiciones
                    List<SolicitudProveedorRendicionDetE> ListaRendicionesDet = new SolicitudProveedorRendicionDetAD().ListarSolicitudProveedorRendicionDet(oRendicion.idRendicion);
                    //Lista de provisiones...
                    List<ProvisionesE> ListaProvisiones = new List<ProvisionesE>();
                    ProvisionesE ItemProv = null;

                    foreach (SolicitudProveedorRendicionDetE item in ListaRendicionesDet)
                    {
                        if (item.EsAutomatico && item.idProvision > 0)
                        {
                            ItemProv = new ProvisionesAD().RecuperarProvisionesPorId(oRendicion.idEmpresa, oRendicion.idLocal, Convert.ToInt32(item.idProvision));

                            if (ItemProv != null)
                            {
                                ListaProvisiones.Add(ItemProv);
                            }
                        }

                        //Aprovechando la iteración se elimina el abono en la CtaCte de la liquidación de importación
                        if (item.EsAutomatico && !item.indProvBusqueda && item.indLiquiImpor)
                        {
                            //Eliminando de la Cta.Cte. Detalle
                            new CtaCte_DetAD().EliminarMaeCtaCteDetallePorIdItem(item.idCtaCteItemLiqui.Value);
                            //Obteniendo la cabecera de la Cta.Cte.
                            CtaCteE oCtaCteCabecera = new CtaCteAD().ObtenerMaeCtaCtePorId(item.idCtaCteLiqui.Value);

                            #region Verificando Saldo de la CtaCte.

                            if (oCtaCteCabecera != null)
                            {
                                List<CtaCte_DetE> oListaCtaCteDet = new CtaCte_DetAD().ListarMaeCtaCteDet(oCtaCteCabecera.idEmpresa, oCtaCteCabecera.idCtaCte);
                                Decimal Saldo = 0;

                                foreach (CtaCte_DetE itemLiqui in oListaCtaCteDet)
                                {
                                    if (itemLiqui.TipAccion == "C")
                                    {
                                        Saldo = Saldo + Convert.ToDecimal(itemLiqui.MontoMov);
                                    }
                                    else
                                    {
                                        Saldo = Saldo - Convert.ToDecimal(itemLiqui.MontoMov);
                                    }
                                }

                                // Si el saldo es diferente de 0 vuelve a habilitar el documento en la cta.cte.
                                if (Saldo != 0)
                                {
                                    new CtaCteAD().ActualizarFecCancelacionCtaCte(oCtaCteCabecera.idEmpresa, oCtaCteCabecera.idCtaCte, Convert.ToDateTime("31-12-2100"), Usuario);
                                }
                            }

                            #endregion

                            #region Actualizando los campos Cta.Cte.

                            item.idCtaCteLiqui = null;
                            item.idCtaCteItemLiqui = null;
                            new SolicitudProveedorRendicionDetAD().ActualizarProvRendiDetCtaCteLiqui(item, Usuario);

                            #endregion
                        }
                    }

                    //Mandando a cerrar las provisiones si es que las hay...
                    if (ListaProvisiones.Count > 0)
                    {
                        new ProvisionesLN().EliminarVoucherProvisionMasivo(ListaProvisiones, Usuario);
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

        public Int32 ActualizarRendicionConta(SolicitudProveedorRendicionE solicitudproveedorrendicion)
        {
            try
            {
                return new SolicitudProveedorRendicionAD().ActualizarRendicionContaCtaCte(solicitudproveedorrendicion);
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

        public int ActualizarTotales(List<SolicitudProveedorRendicionE> oRendiciones)
        {
            try
            {
                Int32 resp = 0;

                foreach (SolicitudProveedorRendicionE item in oRendiciones)
                {
                    SolicitudProveedorRendicionE oRendi = RecuperarSolicitudProveedorRendicion(item.idRendicion);
                    Decimal Dolares = oRendi.oListaRendiciones.Sum(x => x.DolaresRecibidos);
                    Decimal Soles = oRendi.oListaRendiciones.Sum(x => x.SolesRecibidos);

                    oRendi.totSoles = Soles;
                    oRendi.totDolares = Dolares;

                    if (item.MontoAplicado == 0)
                    {
                        if (item.idMonedaSol == "01")
                        {
                            oRendi.MontoAplicado = Soles;
                        }
                        else
                        {
                            oRendi.MontoAplicado = Dolares;
                        } 
                    }

                    ActualizarSolicitudProveedorRendicion(oRendi);
                    resp++;
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

        public Int32 ActualizarRendicionContaDepo(SolicitudProveedorRendicionE solicitudproveedorrendicion)
        {
            try
            {
                return new SolicitudProveedorRendicionAD().ActualizarRendicionContaDepo(solicitudproveedorrendicion);
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

        private SolicitudProveedorRendicionE InsertaCtaCteRendicion(SolicitudProveedorRendicionE oRendicion, VoucherItemE VoucherDiferencia)
        {
            try
            {
                using (TransactionScope oTrans = new TransactionScope())
                {
                    Int32 idCtaCte = 0;
                    Int32 idCtaCteItem = 0;

                    #region Cabecera

                    CtaCteE oCtaCte = new CtaCteE
                    {
                        idEmpresa = oRendicion.idEmpresa,
                        idPersona = Convert.ToInt32(oRendicion.idProveedor),
                        idDocumento = "AN",
                        numSerie = String.Empty,
                        numDocumento = oRendicion.codSolicitud + "-1",
                        idMoneda = oRendicion.idMonedaSol,
                        MontoOrig = oRendicion.Diferencia,
                        TipoCambio = Convert.ToDecimal(VoucherDiferencia.tipCambio),
                        FechaDocumento = Convert.ToDateTime(oRendicion.fecOperacion),
                        FechaVencimiento = oRendicion.fecOperacion,
                        FechaCancelacion = Convert.ToDateTime("31-12-2100"),
                        numVerPlanCuentas = VoucherDiferencia.numVerPlanCuentas,
                        codCuenta = VoucherDiferencia.codCuenta,
                        AnnoVencimiento = String.Empty,
                        MesVencimiento = String.Empty,
                        SemanaVencimiento = String.Empty,
                        tipPartidaPresu = String.Empty,
                        codPartidaPresu = String.Empty,
                        desGlosa = VoucherDiferencia.desGlosa,
                        FechaOperacion = Convert.ToDateTime(oRendicion.fecOperacion),
                        EsDetraCab = false,
                        idCtaCteOrigen = 0,
                        idSistema = 6, //Tesoreria
                        UsuarioRegistro = VoucherDiferencia.UsuarioRegistro
                    };

                    oCtaCte = new CtaCteAD().InsertarMaeCtaCte(oCtaCte);

                    //Obteniendo el id de la ctacte original...
                    idCtaCte = oCtaCte.idCtaCte;

                    #endregion

                    #region Detalle

                    CtaCte_DetE oCtaCteDet = new CtaCte_DetE
                    {
                        idEmpresa = oRendicion.idEmpresa,
                        idCtaCte = idCtaCte,
                        idDocumentoMov = "AN",
                        SerieMov = String.Empty,
                        NumeroMov = oRendicion.codSolicitud,
                        FechaMovimiento = Convert.ToDateTime(oRendicion.fecOperacion),
                        idMoneda = oRendicion.idMonedaSol,
                        MontoMov = oRendicion.Diferencia,
                        TipoCambio = VoucherDiferencia.tipCambio,
                        TipAccion = EnumEstadoDocumentos.C.ToString(),
                        numVerPlanCuentas = VoucherDiferencia.numVerPlanCuentas,
                        codCuenta = VoucherDiferencia.codCuenta,
                        desGlosa = VoucherDiferencia.desGlosa,
                        EsDetraccion = false,
                        UsuarioRegistro = VoucherDiferencia.UsuarioRegistro
                    };

                    oCtaCteDet = new CtaCte_DetAD().InsertarMaeCtaCteDet(oCtaCteDet);

                    //Recuperando el Id del item
                    idCtaCteItem = oCtaCteDet.idCtaCteItem;

                    #endregion

                    //Actualizando el idCtaCte a la Provisión
                    oRendicion.idCtaCte = idCtaCte;
                    oRendicion.idCtaCteItem = idCtaCteItem;

                    oTrans.Complete();
                }

                return oRendicion;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private void EliminarCtaCteProvision(SolicitudProveedorRendicionE oRendicion)
        {
            try
            {
                using (TransactionScope oTrans = new TransactionScope())
                {
                    CtaCteE oCtaCte = new CtaCteAD().ObtenerMaeCtaCtePorId(oRendicion.idCtaCte.Value);

                    //Para saber si el documento ya tiene abonos
                    if (oCtaCte != null)
                    {
                        List<CtaCte_DetE> oListaCtaCte = new CtaCte_DetAD().ListarMaeCtaCteDetAbonos(oCtaCte.idEmpresa, oCtaCte.idCtaCte);

                        if (oListaCtaCte.Count > 0)
                        {
                            throw new Exception(String.Format("Este documento {0} {1} en la Cta. Cte. ya tiene movimientos, elimine los movimientos antes de anular la factura.", "AN", oRendicion.codSolicitud));
                        }
                        else
                        {
                            // Eliminando toda la cta.cte. del documento
                            new CtaCteAD().EliminarMaeCtaCteConDetalle(oCtaCte.idCtaCte);
                        }
                    }

                    oTrans.Complete();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        #endregion

    }
}
