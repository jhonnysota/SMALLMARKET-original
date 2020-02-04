using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Transactions;

using Entidades.CtasPorPagar;
using Entidades.Tesoreria;
using AccesoDatos.CtasPorPagar;
using AccesoDatos.Contabilidad;
using AccesoDatos.Tesoreria;
using Infraestructura.Enumerados;

namespace Negocio.CtasPorPagar
{
    public class LiquidacionImportacionLN
    {

        public LiquidacionImportacionE GrabarLiquidacionImportacion(LiquidacionImportacionE liquidacionimportacion, EnumOpcionGrabar opcionGrabar)
        {
            try
            {
                using (TransactionScope oTrans = new TransactionScope())
                {
                    if (opcionGrabar == EnumOpcionGrabar.Insertar)
                    {
                        //Generacion del código de la liquidación de importación
                        liquidacionimportacion.codLiquidacion = new LiquidacionImportacionAD().GenerarCodLiquidacionImportacion(liquidacionimportacion.idEmpresa, liquidacionimportacion.Fecha);
                        //Insertando la cabecera
                        liquidacionimportacion = new LiquidacionImportacionAD().InsertarLiquidacionImportacion(liquidacionimportacion);

                        //Insertando el detalle
                        foreach (LiquidacionImportacionDetE item in liquidacionimportacion.oListaImportacionesDet)
                        {
                            item.idLiquidacion = liquidacionimportacion.idLiquidacion;
                            new LiquidacionImportacionDetAD().InsertarLiquidacionImportacionDet(item);
                        }
                    }
                    else
                    {
                        if (liquidacionimportacion.Fecha != liquidacionimportacion.FechaTmp)
                        {
                            //Generacion del código de la liquidación de importación
                            liquidacionimportacion.codLiquidacion = new LiquidacionImportacionAD().GenerarCodLiquidacionImportacion(liquidacionimportacion.idEmpresa, liquidacionimportacion.Fecha);
                        }

                        //Actualizando la cabecera
                        liquidacionimportacion = new LiquidacionImportacionAD().ActualizarLiquidacionImportacion(liquidacionimportacion);

                        //Revisando si hay eliminados
                        if (liquidacionimportacion.oListaImportacionesDetDel != null)
                        {
                            foreach (LiquidacionImportacionDetE item in liquidacionimportacion.oListaImportacionesDetDel)
                            {
                                new LiquidacionImportacionDetAD().EliminarLiquidacionImportacionDet(item.idItem);
                            }
                        }

                        //Insertando o Actualizando el detalle
                        if (liquidacionimportacion.oListaImportacionesDet != null)
                        {
                            foreach (LiquidacionImportacionDetE item in liquidacionimportacion.oListaImportacionesDet)
                            {
                                item.idLiquidacion = liquidacionimportacion.idLiquidacion;

                                if (item.Opcion == (Int32)EnumOpcionGrabar.Insertar)
                                {
                                    new LiquidacionImportacionDetAD().InsertarLiquidacionImportacionDet(item);
                                }
                                else
                                {
                                    new LiquidacionImportacionDetAD().ActualizarLiquidacionImportacionDet(item);
                                }
                            }
                        }
                    }

                    oTrans.Complete();
                }

                return liquidacionimportacion;
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

        public LiquidacionImportacionE InsertarLiquidacionImportacion(LiquidacionImportacionE liquidacionimportacion)
        {
            try
            {
                return new LiquidacionImportacionAD().InsertarLiquidacionImportacion(liquidacionimportacion);
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

        public LiquidacionImportacionE ActualizarLiquidacionImportacion(LiquidacionImportacionE liquidacionimportacion)
        {
            try
            {
                return new LiquidacionImportacionAD().ActualizarLiquidacionImportacion(liquidacionimportacion);
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

        public int EliminarLiquidacionImportacion(Int32 idLiquidacion)
        {
            try
            {
                Int32 resp = 0;

                List<SolicitudProveedorRendicionDetE> Rendiciones = new SolicitudProveedorRendicionDetAD().ProvRendicionDetPorLiquidacion(idLiquidacion);

                if (Rendiciones != null && Rendiciones.Count > 0)
                {
                    throw new Exception("El documento de Liquidación no se puede eliminar porque se encuentra ingresada en una Rendición.");
                }

                resp = new LiquidacionImportacionAD().EliminarLiquidacionImportacion(idLiquidacion);

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

        public List<LiquidacionImportacionE> ListarLiquidacionImportacion(Int32 idEmpresa, Int32 idLocal, DateTime fecIni, DateTime fecFin, Boolean Estado1, Boolean Estado2, Boolean Detallado)
        {
            try
            {
                return new LiquidacionImportacionAD().ListarLiquidacionImportacion(idEmpresa, idLocal, fecIni, fecFin, Estado1, Estado2, Detallado);
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

        public LiquidacionImportacionE ObtenerLiquidacionImportacion(Int32 idLiquidacion, String ConDetalle = "S")
        {
            try
            {
                LiquidacionImportacionE Importacion = new LiquidacionImportacionAD().ObtenerLiquidacionImportacion(idLiquidacion);

                if (ConDetalle == "S")
                {
                    if (Importacion != null)
                    {
                        Importacion.oListaImportacionesDet = new LiquidacionImportacionDetAD().ListarLiquidacionImportacionDet(idLiquidacion);
                    } 
                }

                return Importacion;
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

        public Int32 CerrarLiquidacionImportacion(LiquidacionImportacionE oLiquidacion, String Usuario)
        {
            try
            {
                Int32 Resp = 0;

                using (TransactionScope oTrans = new TransactionScope())
                {
                    Resp = new LiquidacionImportacionAD().GenerarVoucherLiquidacionImportacion(oLiquidacion.idEmpresa, oLiquidacion.idLocal, oLiquidacion.idLiquidacion, Usuario);

                    if (Resp > 0)
                    {
                        //Actualizando el estado en la liquidación.
                        new LiquidacionImportacionAD().ActualizarEstadoLiquiImportacion(oLiquidacion.idLiquidacion, true, Usuario);
                        //Obteniendo los datos de la liquidación
                        LiquidacionImportacionE importacion = ObtenerLiquidacionImportacion(oLiquidacion.idLiquidacion, "N");

                        #region CtaCte
                        
                        #region Cabecera

                        CtaCteE oCtaCte = new CtaCteE
                        {
                            idEmpresa = importacion.idEmpresa,
                            idPersona = importacion.idPersona,
                            idDocumento = importacion.idDocumento,
                            numSerie = importacion.numSerie,
                            numDocumento = importacion.numDocumento,
                            idMoneda = importacion.idMoneda,
                            MontoOrig = importacion.Importe,
                            TipoCambio = importacion.TiCa,
                            FechaDocumento = importacion.Fecha,
                            FechaVencimiento = importacion.Fecha,
                            FechaCancelacion = Convert.ToDateTime("31-12-2100"),
                            numVerPlanCuentas = importacion.numVerPlanCuentas,
                            codCuenta = importacion.codCuenta,
                            AnnoVencimiento = String.Empty,
                            MesVencimiento = String.Empty,
                            SemanaVencimiento = String.Empty,
                            tipPartidaPresu = String.Empty,
                            codPartidaPresu = String.Empty,
                            desGlosa = importacion.Glosa,
                            FechaOperacion = importacion.Fecha,
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
                            idEmpresa = importacion.idEmpresa,
                            idCtaCte = oCtaCte.idCtaCte,
                            idDocumentoMov = importacion.idDocumento,
                            SerieMov = importacion.numSerie,
                            NumeroMov = importacion.numDocumento,
                            FechaMovimiento = importacion.Fecha,
                            idMoneda = importacion.idMoneda,
                            MontoMov = importacion.Importe,
                            TipoCambio = importacion.TiCa,
                            TipAccion = EnumEstadoDocumentos.C.ToString(),
                            numVerPlanCuentas = importacion.numVerPlanCuentas,
                            codCuenta = importacion.codCuenta,
                            desGlosa = importacion.Glosa,
                            EsDetraccion = false,
                            UsuarioRegistro = Usuario
                        };

                        oCtaCteDet = new CtaCte_DetAD().InsertarMaeCtaCteDet(oCtaCteDet);

                        #endregion 

                        importacion.idCtaCte = oCtaCte.idCtaCte;
                        importacion.idCtaCteItem = oCtaCteDet.idCtaCteItem;
                        //Actualizando
                        new LiquidacionImportacionAD().ActualizarCtaCteLiquiImport(importacion);

                        #endregion
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

        public Boolean AbrirLiquidacionImportacion(LiquidacionImportacionE oLiquidacion, String Usuario)
        {
            try
            {
                Boolean Resp = false;

                using (TransactionScope oTrans = new TransactionScope())
                {
                    //Eliminando el voucher
                    new VoucherAD().EliminarVoucher(oLiquidacion.idEmpresa, oLiquidacion.idLocal, oLiquidacion.AnioPeriodo, oLiquidacion.MesPeriodo, oLiquidacion.numVoucher, oLiquidacion.idComprobante, oLiquidacion.numFile);
                    //Actualizando el estado en la liquidación.
                    new LiquidacionImportacionAD().ActualizarEstadoLiquiImportacion(oLiquidacion.idLiquidacion, false, Usuario);
                    //Obteniendo los datos de la liquidación
                    LiquidacionImportacionE importacion = ObtenerLiquidacionImportacion(oLiquidacion.idLiquidacion, "N");

                    #region CtaCte

                    CtaCteE oCtaCteRevision = new CtaCteAD().ObtenerMaeCtaCtePorId(importacion.idCtaCte.Value);

                    if (oCtaCteRevision != null)
                    {
                        //Para saber si el documento ya tiene abonos
                        List<CtaCte_DetE> oListaCtaCte = new CtaCte_DetAD().ListarMaeCtaCteDetAbonos(oCtaCteRevision.idEmpresa, oCtaCteRevision.idCtaCte);

                        if (oListaCtaCte.Count > 0)
                        {
                            throw new Exception(String.Format("La Liquidación {0} con documento {1} {2} {3} en la Cta. Cte. ya tiene Abonos, elimine los Abonos..", importacion.codLiquidacion, importacion.idDocumento, importacion.numSerie, importacion.numDocumento));
                        }
                        else
                        {
                            //Eliminando toda la CtaCte del documento
                            new CtaCteAD().EliminarMaeCtaCteConDetalle(oCtaCteRevision.idCtaCte);
                        }

                        importacion.idCtaCte = null;
                        importacion.idCtaCteItem = null;
                        //Actualizando
                        new LiquidacionImportacionAD().ActualizarCtaCteLiquiImport(importacion);
                    } 

                    #endregion

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

        public Int32 LimpiarVoucherLiquiImportacion(Int32 idLiquidacion, String UsuarioModificacion)
        {
            try
            {
                return new LiquidacionImportacionAD().LimpiarVoucherLiquiImportacion(idLiquidacion, UsuarioModificacion);
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
