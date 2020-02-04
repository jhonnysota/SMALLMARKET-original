using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Transactions;
using System.Linq;

using Entidades.Tesoreria;
using Entidades.Maestros;
using AccesoDatos.Tesoreria;
using AccesoDatos.Maestros;
using Infraestructura.Enumerados;

namespace Negocio.Tesoreria
{
    public class SolicitudProveedorLN
    {

        public SolicitudProveedorE GrabarSolicitudProveedor(SolicitudProveedorE solicitudproveedor, EnumOpcionGrabar Opcion)
        {
            try
            {
                using (TransactionScope oTrans = new TransactionScope())
                {
                    if (Opcion == EnumOpcionGrabar.Insertar)
                    {
                        //Generando el nuevo código
                        solicitudproveedor.codSolicitud = new SolicitudProveedorAD().GenerarNumSolicitudProveedor(solicitudproveedor.idEmpresa, solicitudproveedor.idLocal);
                        //Insertando el registro nuevo
                        solicitudproveedor = new SolicitudProveedorAD().InsertarSolicitudProveedor(solicitudproveedor);

                        //Revisando si hay detalle para insertarlo
                        if (solicitudproveedor.oListaSolicitudes != null && solicitudproveedor.oListaSolicitudes.Count > 0)
                        {
                            Int32 Corre = 1;

                            foreach (SolicitudProveedorDetE item in solicitudproveedor.oListaSolicitudes)
                            {
                                item.idSolicitud = solicitudproveedor.idSolicitud;
                                item.Item = Corre;
                                new SolicitudProveedorDetAD().InsertarSolicitudProveedorDet(item);

                                Corre++;
                            }
                        }
                    }
                    else
                    {
                        //Actualizando el registro...
                        solicitudproveedor = new SolicitudProveedorAD().ActualizarSolicitudProveedor(solicitudproveedor);

                        if (solicitudproveedor.oSolicitudesDel != null && solicitudproveedor.oSolicitudesDel.Count > 0)
                        {
                            foreach (SolicitudProveedorDetE item in solicitudproveedor.oSolicitudesDel)
                            {
                                new SolicitudProveedorDetAD().EliminarSolicitudProveedorDet(solicitudproveedor.idSolicitud, item.Item);
                            }
                        }

                        Int32 Corre = solicitudproveedor.oListaSolicitudes.Count;

                        if (solicitudproveedor.oListaSolicitudes != null)
                        {
                            foreach (SolicitudProveedorDetE item in solicitudproveedor.oListaSolicitudes)
                            {
                                if (item.Opcion == (Int32)EnumOpcionGrabar.Insertar)
                                {
                                    Corre++;
                                    item.idSolicitud = solicitudproveedor.idSolicitud;
                                    item.Item = Corre;

                                    new SolicitudProveedorDetAD().InsertarSolicitudProveedorDet(item);
                                }
                                else if (item.Opcion == (Int32)EnumOpcionGrabar.Actualizar)
                                {
                                    new SolicitudProveedorDetAD().ActualizarSolicitudProveedorDet(item);
                                }
                            }
                        }
                    }

                    oTrans.Complete();
                }

                return solicitudproveedor;
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

        public SolicitudProveedorE InsertarSolicitudProveedor(SolicitudProveedorE solicitudproveedor)
        {
            try
            {
                return new SolicitudProveedorAD().InsertarSolicitudProveedor(solicitudproveedor);
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

        public SolicitudProveedorE ActualizarSolicitudProveedor(SolicitudProveedorE solicitudproveedor)
        {
            try
            {
                return new SolicitudProveedorAD().ActualizarSolicitudProveedor(solicitudproveedor);
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

        public int EliminarSolicitudProveedor(SolicitudProveedorE solicitudproveedor)
        {
            try
            {
                Int32 resp = 0;

                using (TransactionScope oTrans = new TransactionScope())
                {
                    //Eliminando la rendición si tuviese
                    //new SolicitudProveedorRendicionTmpAD().EliminarSolicitudProveedorRendicion(solicitudproveedor.idSolicitud);
                    //Eliminando la solicitud
                    resp = new SolicitudProveedorAD().EliminarSolicitudProveedor(solicitudproveedor.idSolicitud);
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

        public List<SolicitudProveedorE> ListarSolicitudProveedor(Int32 idEmpresa, Int32 idLocal, Int32 idProveedor, DateTime fecIni, DateTime fecFin, String indEstado)
        {
            try
            {
                return new SolicitudProveedorAD().ListarSolicitudProveedor(idEmpresa, idLocal, idProveedor, fecIni, fecFin, indEstado);
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

        public SolicitudProveedorE ObtenerSolicitudProveedor(Int32 idSolicitud)
        {
            try
            {
                return new SolicitudProveedorAD().ObtenerSolicitudProveedor(idSolicitud);
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

        public SolicitudProveedorE RecuperarSolicitudProveedor(Int32 idSolicitud)
        {
            try
            {
                SolicitudProveedorE oSolicitudCobranza = new SolicitudProveedorAD().ObtenerSolicitudProveedor(idSolicitud);
                oSolicitudCobranza.oListaSolicitudes = new SolicitudProveedorDetAD().ListarSolicitudProveedorDet(idSolicitud);

                return oSolicitudCobranza;
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

        public SolicitudProveedorE SolicitudProvImpresion(Int32 idSolicitud)
        {
            try
            {
                SolicitudProveedorE oSolicitudCobranza = new SolicitudProveedorAD().SolicitudProvImpresion(idSolicitud);
                oSolicitudCobranza.oListaSolicitudes = new SolicitudProveedorDetAD().ListarSolicitudProveedorDet(idSolicitud);

                return oSolicitudCobranza;
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

        public String GenerarOrdenPago(Int32 idSolicitud, String Usuario)
        {
            try
            {
                String resp = String.Empty;

                using (TransactionScope oTrans = new TransactionScope())
                {
                    //Obteniendo la solicitud
                    SolicitudProveedorE oSolicitudProveedor = RecuperarSolicitudProveedor(idSolicitud);
                    TipoPagoDetE DetallePago = new TipoPagoDetAD().TipoPagoDetPorConcepto(oSolicitudProveedor.idEmpresa, Convert.ToInt32(oSolicitudProveedor.idConcepto));

                    if (DetallePago == null)
                    {
                        throw new Exception("No se ha configurado ningún concepto para el Adelanto a Proveedores.");
                    }

                    OrdenPagoE OrdenPago = new OrdenPagoE()
                    {
                        idEmpresa = oSolicitudProveedor.idEmpresa,
                        idLocal = oSolicitudProveedor.idLocal,
                        codOrdenPago = String.Empty,
                        codTipoPago = DetallePago.codTipoPago,
                        idConcepto = Convert.ToInt32(oSolicitudProveedor.idConcepto),
                        codFormaPago = "003",
                        Fecha = oSolicitudProveedor.Fecha,
                        idPersona = null,
                        idPersonaBeneficiario = null,
                        idMoneda = "0",
                        Monto = oSolicitudProveedor.oListaSolicitudes.Sum(x => x.Importe),
                        Glosa = String.Empty,
                        VieneDe = "S", //Solicitud de Proveedor/Adelantos/Anticipos
                        UsuarioRegistro = Usuario
                    };

                    OrdenPagoDetE PagoDetalle = null;

                    foreach (SolicitudProveedorDetE item in oSolicitudProveedor.oListaSolicitudes)
                    {
                        if (String.IsNullOrWhiteSpace(item.numVerPlanCuentas) || String.IsNullOrWhiteSpace(item.codCuenta))
                        {
                            throw new Exception("El concepto no tiene cuenta contable. Debe ingresarlo en el Maestro de Conceptos Varios.");
                        }

                        ProveedorCuentaE oProveedorCuenta = new ProveedorCuentaAD().ObtenerProvCtaDefecto(oSolicitudProveedor.idProveedor, oSolicitudProveedor.idEmpresa, oSolicitudProveedor.idMoneda);

                        if (oProveedorCuenta == null)
                        {
                            throw new Exception(String.Format("El proveedor no tiene cuentas bancarias para la moneda {0}. No podrá generar la O.P.", (oSolicitudProveedor.idMoneda == "01" ? "Soles" : "Dólares")));
                        }

                        PagoDetalle = new OrdenPagoDetE()
                        {
                            codTipoPago = DetallePago.codTipoPago,
                            idConcepto = Convert.ToInt32(oSolicitudProveedor.idConcepto),
                            codFormaPago = "003",
                            Fecha = oSolicitudProveedor.Fecha,
                            idProveedor = oSolicitudProveedor.idProveedor,
                            idDocumento = "AN",
                            serDocumento = String.Empty,
                            numDocumento = oSolicitudProveedor.codSolicitud,
                            idMoneda = oSolicitudProveedor.idMoneda,
                            Monto = item.Importe,
                            idMonedaPago = oSolicitudProveedor.idMoneda,
                            MontoPago = item.Importe,
                            TipPartidaPresu = String.Empty,
                            CodPartidaPresu = String.Empty,
                            Concepto = item.desConcepto,
                            Descripcion = oSolicitudProveedor.Descripcion,
                            numVerPlanCuentas = item.numVerPlanCuentas,
                            codCuenta = item.codCuenta,
                            idBanco = oProveedorCuenta.idPersonaBanco,
                            tipCuenta = oProveedorCuenta.tipCuenta,
                            idMonedaBanco = oProveedorCuenta.idMoneda,
                            numCtaBancaria = !String.IsNullOrWhiteSpace(oProveedorCuenta.numCuenta.Trim()) ? oProveedorCuenta.numCuenta.Trim() : oProveedorCuenta.numInterbancaria.Trim(),
                            indPago = false,
                            indAuto = true,
                            UsuarioRegistro = Usuario
                        };

                        OrdenPago.ListaOrdenPago.Add(PagoDetalle);
                    }

                    //Grabando la nueva Orden de Pago
                    OrdenPago = new OrdenPagoLN().GrabarOrdenPago(OrdenPago, EnumOpcionGrabar.Insertar);
                    oSolicitudProveedor.idOrdenPago = OrdenPago.idOrdenPago;

                    //Actualizando el Orden de pago en la solicitud
                    new SolicitudProveedorAD().ActualizarSolicitudProveedor(oSolicitudProveedor);
                    //Actualizando el estado de la solicitud
                    new SolicitudProveedorAD().ActualizarEstadoSolProveedor(idSolicitud, "C", Usuario);
                    //Dando el ok para saber si todo esta bien grabado.
                    resp = "Ok";

                    //Completando la transacción...
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

        public String AbrirSolicitudProveedor(SolicitudProveedorE solicitudproveedor, String UsuarioModificacion)
        {
            try
            {
                String Resp = String.Empty;

                using (TransactionScope oTrans = new TransactionScope())
                {
                    //Eliminando la Orden de Pago...
                    if (solicitudproveedor.idOrdenPago > 0)
                    {
                        OrdenPagoE OrdenPago = new OrdenPagoAD().ObtenerOrdenPago(solicitudproveedor.idOrdenPago.Value);

                        if (OrdenPago.indEstado == "C")
                        {
                            throw new Exception(String.Format("No se puede abrir la Solicitud/Anticipo porque la O.P. {0} se encuentra Cerrada", OrdenPago.codOrdenPago));
                        }

                        new OrdenPagoAD().EliminarOrdenPago(Convert.ToInt32(solicitudproveedor.idOrdenPago));
                    }

                    //Actualizando el estado...
                    new SolicitudProveedorAD().ActualizarEstadoSolProveedor(solicitudproveedor.idSolicitud, "P", UsuarioModificacion);

                    //Completando la transacción
                    oTrans.Complete();
                    //Si todo esta bien ok...
                    Resp = "ok";
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

        public List<SolicitudProveedorE> SolicitudProveedorPendientes(Int32 idEmpresa, Int32 idLocal, String RazonSocial)
        {
            try
            {
                return new SolicitudProveedorAD().SolicitudProveedorPendientes(idEmpresa, idLocal, RazonSocial);
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