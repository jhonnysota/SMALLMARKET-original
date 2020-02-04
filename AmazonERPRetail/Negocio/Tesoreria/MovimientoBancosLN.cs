using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Transactions;
using System.Linq;

using Entidades.Tesoreria;
using Entidades.Maestros;
using Entidades.Almacen;
using Entidades.Contabilidad;
using AccesoDatos.Tesoreria;
using AccesoDatos.Contabilidad;
using AccesoDatos.Maestros;
using AccesoDatos.Almacen;
using Infraestructura.Enumerados;
using Infraestructura.Extensores;

namespace Negocio.Tesoreria
{
    public class MovimientoBancosLN
    {

        public MovimientoBancosE GrabarMovimientoBancos(MovimientoBancosE MovimientoBan, EnumOpcionGrabar Opcion)
        {
            try
            {
                using (TransactionScope oTrans = new TransactionScope())
                {
                    if (Opcion == EnumOpcionGrabar.Insertar)
                    {
                        String codMovimiento = new MovimientoBancosAD().GenerarNumMovBancos(MovimientoBan.idEmpresa, MovimientoBan.tipMovimiento);
                        MovimientoBan.codMovBanco = codMovimiento;
                        MovimientoBan = new MovimientoBancosAD().InsertarMovimientoBancos(MovimientoBan);

                        if (MovimientoBan.oListaMovimientos != null)
                        {
                            foreach (MovimientoBancosDetE item in MovimientoBan.oListaMovimientos)
                            {
                                item.idMovBanco = MovimientoBan.idMovBanco;
                                new MovimientoBancosDetAD().InsertarMovimientoBancosDet(item);
                            }
                        }
                    }
                    else
                    {
                        MovimientoBan = new MovimientoBancosAD().ActualizarMovimientoBancos(MovimientoBan);

                        if (MovimientoBan.oListaMovimientos != null)
                        {
                            new MovimientoBancosDetAD().EliminarMovBancosDetPorId(MovimientoBan.idMovBanco);

                            foreach (MovimientoBancosDetE item in MovimientoBan.oListaMovimientos)
                            {
                                item.idMovBanco = MovimientoBan.idMovBanco;

                                if (item.idPersona == 0)
                                {
                                    item.idPersona = null;
                                }

                                new MovimientoBancosDetAD().InsertarMovimientoBancosDet(item);
                            }
                        }
                    }

                    oTrans.Complete();
                }

                return MovimientoBan;
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

        public MovimientoBancosE InsertarMovimientoBancos(MovimientoBancosE movimientobancos)
        {
            try
            {
                return new MovimientoBancosAD().InsertarMovimientoBancos(movimientobancos);
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

        public MovimientoBancosE ActualizarMovimientoBancos(MovimientoBancosE movimientobancos)
        {
            try
            {
                return new MovimientoBancosAD().ActualizarMovimientoBancos(movimientobancos);
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

        public int EliminarMovimientoBancos(Int32 idMovBanco)
        {
            try
            {
                return new MovimientoBancosAD().EliminarMovimientoBancos(idMovBanco);
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

        public List<MovimientoBancosE> ListarMovimientoBancos(Int32 idEmpresa, Int32 idBanco, Int32 tipMovimiento, DateTime fecIni, DateTime fecFin, String indEstado, Boolean indDevolucion)
        {
            try
            {
                return new MovimientoBancosAD().ListarMovimientoBancos(idEmpresa, idBanco, tipMovimiento, fecIni, fecFin, indEstado, indDevolucion);
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

        public MovimientoBancosE ObtenerMovimientoBancos(Int32 idMovBanco, Boolean ConDetalle = true)
        {
            try
            {
                MovimientoBancosE oMovimiento = new MovimientoBancosAD().ObtenerMovimientoBancos(idMovBanco);

                if (oMovimiento != null && ConDetalle)
                {
                    oMovimiento.oListaMovimientos = new MovimientoBancosDetAD().ListarMovimientoBancosDet(idMovBanco, oMovimiento.idEmpresa);
                }

                return oMovimiento;
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

        public MovimientoBancosE ActualizarMovBancosConta(MovimientoBancosE movimientobancos)
        {
            try
            {
                return new MovimientoBancosAD().ActualizarMovBancosConta(movimientobancos);
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

        public String GenerarProvisionMovBancos(MovimientoBancosE movimientobancos, Int32 idLocal, String Usuario, String Masivo = "N")
        {
            try
            {
                String VoucherDevuelto = String.Empty;

                using (TransactionScope oTrans = new TransactionScope())
                {
                    if (Masivo == "N")
                    {
                        movimientobancos.UsuarioModificacion = Usuario;
                        new MovimientoBancosAD().ActualizarMovBancosConta(movimientobancos); 
                    }

                    VoucherDevuelto = new MovimientoBancosAD().GenerarProvisionMovBancos(movimientobancos.idMovBanco, movimientobancos.idEmpresa, idLocal, Usuario);

                    if (movimientobancos.tipMovimiento == 4) //Vinculadas
                    {
                        MovimientoBancosE oMovimiento = new MovimientoBancosAD().ObtenerMovimientoBancos(movimientobancos.idMovBanco);
                        oMovimiento.oListaMovimientos = new MovimientoBancosDetAD().ListarMovimientoBancosDet(oMovimiento.idMovBanco, oMovimiento.idEmpresa);
                        List<MovimientoBancosDetE> ListaTransferencia = new List<MovimientoBancosDetE>();
                        Int32 idMovTransferencia = 0;

                        foreach (MovimientoBancosDetE item in (from x in oMovimiento.oListaMovimientos where x.idEmpresaTrans > 0 select x).ToList())
                        {
                            ListaTransferencia.Add(Colecciones.CopiarEntidad(item));
                        }

                        #region Movimiento de Ingreso - Transferencia
                        
                        if (oMovimiento.oListaMovimientos.Count > 0)
                        {
                            Int32 idEmpresaTrans = Convert.ToInt32(oMovimiento.oListaMovimientos[0].idEmpresaTrans);
                            BancosCuentasE oCuentaBancos = new BancosCuentasAD().ObtenerBancosCuentas(Convert.ToInt32(oMovimiento.oListaMovimientos[0].idBancoTrans), idEmpresaTrans, oMovimiento.oListaMovimientos[0].ctaBancariaTrans);
                            MovimientoBancosE MovimientoTrans = Colecciones.CopiarEntidad(oMovimiento);
                            MovimientoTrans.oListaMovimientos = new List<MovimientoBancosDetE>(ListaTransferencia);

                            MovimientoTrans.tipMovimiento = 1; //Ingresos
                            MovimientoTrans.idEmpresa = idEmpresaTrans;
                            MovimientoTrans.idBanco = Convert.ToInt32(oMovimiento.oListaMovimientos[0].idBancoTrans);
                            MovimientoTrans.ctaBancaria = oMovimiento.oListaMovimientos[0].ctaBancariaTrans;
                            MovimientoTrans.idMoneda = oMovimiento.oListaMovimientos[0].idMonedaTrans;
                            //MovimientoTrans.fecMovimiento = oMovimiento.oListaMovimientos[0].fecDocumento;
                            MovimientoTrans.TicaAuto = oMovimiento.TicaAuto;
                            MovimientoTrans.tipCambio = oMovimiento.tipCambio;
                            MovimientoTrans.Glosa = oMovimiento.Glosa;
                            MovimientoTrans.idDocumento = oMovimiento.idDocumento;
                            MovimientoTrans.serDocumento = oMovimiento.serDocumento;
                            MovimientoTrans.numDocumento = oMovimiento.numDocumento;
                            MovimientoTrans.fecDocumento = oMovimiento.fecDocumento;
                            //MovimientoTrans.idMedioPago = oMovimiento.idMedioPago;
                            MovimientoTrans.TotalImporte = oMovimiento.oListaMovimientos[0].Importe;
                            MovimientoTrans.TotalImporteDol = oMovimiento.oListaMovimientos[0].ImporteDolar;
                            MovimientoTrans.GiradoA = oMovimiento.GiradoA;
                            MovimientoTrans.MontoTransS = oMovimiento.oListaMovimientos[0].Importe;
                            MovimientoTrans.MontoTransD = oMovimiento.oListaMovimientos[0].ImporteDolar;
                            MovimientoTrans.numVerPlanCuentas = oCuentaBancos.numVerPlanCuentas;
                            MovimientoTrans.codCuenta = oCuentaBancos.codCuenta;
                            MovimientoTrans.AnioPeriodo = String.Empty;
                            MovimientoTrans.MesPeriodo = String.Empty;
                            MovimientoTrans.idComprobante = String.Empty;
                            MovimientoTrans.numFile = String.Empty;
                            MovimientoTrans.numVoucher = String.Empty;
                            MovimientoTrans.UsuarioRegistro = Usuario;

                            List<ConceptosVariosE> ListaConceptos = new ConceptosVariosAD().ConceptosVariosTesoreria(0, idEmpresaTrans, "");
                            ConceptosVariosE oConcepto = null;

                            //Buscando todos los que digan préstamo
                            List<ConceptosVariosE> oConceptosPrestamos = ListaConceptos.FindAll
                            (
                                delegate (ConceptosVariosE c) { return c.Descripcion.ToUpper().Contains("PRESTAMO") && c.indTransferencia == true; }
                            );

                            if (oConceptosPrestamos.Count == 1)
                            {
                                oConcepto = oConceptosPrestamos[0];
                            }
                            else if (oConceptosPrestamos.Count > 1)
                            {
                                oConcepto = oConceptosPrestamos.Find
                                (
                                    delegate (ConceptosVariosE c) { return c.Descripcion.ToUpper().Contains("VINCULA") && c.indTransferencia == true; }
                                );
                            }

                            if (oConcepto == null)
                            {
                                throw new Exception("No existe el concepto de préstamo en la empresa a transferir.");
                            }

                            foreach (MovimientoBancosDetE item in MovimientoTrans.oListaMovimientos)
                            {
                                item.idConcepto = oConcepto.idConcepto;
                                item.idPersona = item.idPersona == 0 ? (int?)null : item.idPersona;
                                item.idEmpresaTrans = oMovimiento.idEmpresa;
                                item.idBancoTrans = oMovimiento.idBanco;
                                item.idMonedaTrans = oMovimiento.idMoneda;
                                item.ctaBancariaTrans = oMovimiento.ctaBancaria;
                                item.UsuarioRegistro = Usuario;
                            }

                            //Grabando el movimiento de transferencia...
                            GrabarMovimientoBancos(MovimientoTrans, EnumOpcionGrabar.Insertar);
                            new MovimientoBancosDetAD().ActualizarIdMovBancosTrans(oMovimiento.idMovBanco, MovimientoTrans.idMovBanco);

                            //Obteniendo el id del movimiento transferido...
                            idMovTransferencia = MovimientoTrans.idMovBanco;
                        } 

                        #endregion

                        #region CtaCte

                        if (!oMovimiento.indDevolucion)
                        {
                            ActualizarMovBancosCtaCte(oMovimiento, Usuario);
                        }

                        if (oMovimiento.indDevolucion)
                        {
                            //Recorriendo el detalle del movimiento...
                            foreach (MovimientoBancosDetE item in oMovimiento.oListaMovimientos)
                            {
                                if (item.idDocumento == "PR")
                                {
                                    if (!item.indExceso)
                                    {
                                        CtaCteE oCtaCte = new CtaCteAD().ObtenerMaeCtaCtePorDocumento(movimientobancos.idEmpresa, item.idDocumento.Trim(), item.serDocumento.Trim(), item.numDocumento.Trim());

                                        if (oCtaCte != null)
                                        {
                                            #region Detalle

                                            CtaCte_DetE oCtaCteDet = new CtaCte_DetE
                                            {
                                                idEmpresa = movimientobancos.idEmpresa,
                                                idCtaCte = oCtaCte.idCtaCte,
                                                idDocumentoMov = item.idDocumento.Trim(),
                                                SerieMov = item.serDocumento.Trim(),
                                                NumeroMov = item.numDocumento.Trim(),
                                                FechaMovimiento = Convert.ToDateTime(item.fecDocumento),
                                                idMoneda = item.idMoneda,
                                                MontoMov = item.idMoneda == "01" ? item.Importe : item.ImporteDolar,
                                                TipoCambio = Convert.ToDecimal(item.tipCambio),
                                                TipAccion = EnumEstadoDocumentos.A.ToString(),
                                                numVerPlanCuentas = oMovimiento.numVerPlanCuentas,
                                                codCuenta = oMovimiento.codCuenta,
                                                UsuarioRegistro = Usuario
                                            };

                                            oCtaCteDet = new CtaCte_DetAD().InsertarMaeCtaCteDet(oCtaCteDet);

                                            #endregion

                                            #region Verificando Saldo de la CtaCte.

                                            List<CtaCte_DetE> oListaCtaCteDet = new CtaCte_DetAD().ListarMaeCtaCteDet(oCtaCte.idEmpresa, oCtaCte.idCtaCte);
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
                                            if (Saldo == 0)
                                            {
                                                new CtaCteAD().ActualizarFecCancelacionCtaCte(oCtaCte.idEmpresa, oCtaCte.idCtaCte, movimientobancos.fecDocumento.Value, Usuario);
                                            }

                                            #endregion

                                            //Actualizar datos CtaCte al movimiento
                                            new MovimientoBancosDetAD().ActualizarMovBancosDetCtaCte(movimientobancos.idMovBanco, item.Item, oCtaCte.idCtaCte, oCtaCteDet.idCtaCteItem);
                                        }
                                        else
                                        {
                                            throw new Exception(String.Format("El documento {0} {1}-{2} no tiene ningún INGRESO en la Cta. Cte., realice el INGRESO respectivo.", item.idDocumento, item.serDocumento, item.numDocumento));
                                        }
                                    }
                                    else
                                    {
                                        item.idMoviTrans = idMovTransferencia;
                                        InsertarMovBancosCtaCteExceso(item, Usuario);
                                    }
                                }
                            }
                        }

                        #endregion
                    }

                    //Ingresos y además se trata de vinculadas
                    if (movimientobancos.tipMovimiento == 1 && movimientobancos.indDevolucion)
                    {
                        MovimientoBancosE oMovimiento = new MovimientoBancosAD().ObtenerMovimientoBancos(movimientobancos.idMovBanco);
                        oMovimiento.oListaMovimientos = new MovimientoBancosDetAD().ListarMovimientoBancosDet(movimientobancos.idMovBanco, oMovimiento.idEmpresa);

                        #region CtaCte

                        if (oMovimiento.indDevolucion)
                        {
                            foreach (MovimientoBancosDetE item in oMovimiento.oListaMovimientos)
                            {
                                if (!item.indExceso)
                                {
                                    if (!item.VieneApertura)
                                    {
                                        CtaCteE oCtaCte = new CtaCteAD().ObtenerMaeCtaCtePorDocumento(movimientobancos.idEmpresa, item.idDocumento, item.serDocumento, item.numDocumento);

                                        if (oCtaCte != null)
                                        {
                                            #region Detalle

                                            CtaCte_DetE oCtaCteDet = new CtaCte_DetE
                                            {
                                                idEmpresa = movimientobancos.idEmpresa,
                                                idCtaCte = oCtaCte.idCtaCte,
                                                idDocumentoMov = item.idDocumento.Trim(),
                                                SerieMov = item.serDocumento.Trim(),
                                                NumeroMov = item.numDocumento.Trim(),
                                                FechaMovimiento = Convert.ToDateTime(item.fecDocumento),
                                                idMoneda = item.idMoneda,
                                                MontoMov = item.idMoneda == "01" ? item.Importe : item.ImporteDolar,
                                                TipoCambio = Convert.ToDecimal(item.tipCambio),
                                                TipAccion = EnumEstadoDocumentos.A.ToString(),
                                                numVerPlanCuentas = oMovimiento.numVerPlanCuentas,
                                                codCuenta = oMovimiento.codCuenta,
                                                UsuarioRegistro = Usuario
                                            };

                                            new CtaCte_DetAD().InsertarMaeCtaCteDet(oCtaCteDet);

                                            #endregion

                                            #region Verificando Saldo de la CtaCte.

                                            List<CtaCte_DetE> oListaCtaCteDet = new CtaCte_DetAD().ListarMaeCtaCteDet(oCtaCte.idEmpresa, oCtaCte.idCtaCte);
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
                                            if (Saldo == 0)
                                            {
                                                new CtaCteAD().ActualizarFecCancelacionCtaCte(oCtaCte.idEmpresa, oCtaCte.idCtaCte, movimientobancos.fecDocumento.Value, Usuario);
                                            }

                                            #endregion

                                            //Actualizar datos CtaCte al movimiento
                                            new MovimientoBancosDetAD().ActualizarMovBancosDetCtaCte(oMovimiento.idMovBanco, item.Item, oCtaCte.idCtaCte, oCtaCteDet.idCtaCteItem);
                                        }
                                    }
                                    else
                                    {
                                        CtaCteE oCtaCte = new CtaCteAD().ObtenerMaeCtaCtePorDocumento(movimientobancos.idEmpresa, item.idDocumento, item.serDocumento, item.numDocumento);

                                        if (oCtaCte != null)
                                        {
                                            #region Detalle

                                            CtaCte_DetE oCtaCteDet = new CtaCte_DetE
                                            {
                                                idEmpresa = movimientobancos.idEmpresa,
                                                idCtaCte = oCtaCte.idCtaCte,
                                                idDocumentoMov = item.idDocumento.Trim(),
                                                SerieMov = item.serDocumento.Trim(),
                                                NumeroMov = item.numDocumento.Trim(),
                                                FechaMovimiento = Convert.ToDateTime(item.fecDocumento),
                                                idMoneda = item.idMoneda,
                                                MontoMov = item.idMoneda == "01" ? item.Importe : item.ImporteDolar,
                                                TipoCambio = Convert.ToDecimal(item.tipCambio),
                                                TipAccion = EnumEstadoDocumentos.A.ToString(),
                                                numVerPlanCuentas = oMovimiento.numVerPlanCuentas,
                                                codCuenta = oMovimiento.codCuenta,
                                                UsuarioRegistro = Usuario
                                            };

                                            new CtaCte_DetAD().InsertarMaeCtaCteDet(oCtaCteDet);

                                            #endregion

                                            #region Verificando Saldo de la CtaCte.

                                            List<CtaCte_DetE> oListaCtaCteDet = new CtaCte_DetAD().ListarMaeCtaCteDet(oCtaCte.idEmpresa, oCtaCte.idCtaCte);
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
                                            if (Saldo == 0)
                                            {
                                                new CtaCteAD().ActualizarFecCancelacionCtaCte(oCtaCte.idEmpresa, oCtaCte.idCtaCte, movimientobancos.fecDocumento.Value, Usuario);
                                            }

                                            #endregion

                                            //Actualizar datos CtaCte al movimiento
                                            new MovimientoBancosDetAD().ActualizarMovBancosDetCtaCte(oMovimiento.idMovBanco, item.Item, oCtaCte.idCtaCte, oCtaCteDet.idCtaCteItem);
                                        }
                                        else
                                        {
                                            throw new Exception(String.Format("El documento {0} {1}-{2} no existe en la Cta. Cte.", item.idDocumento, item.serDocumento, item.numDocumento));
                                        }
                                    }
                                }
                            }
                        }

                        #endregion
                    }

                    oTrans.Complete();
                }

                return VoucherDevuelto;
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

        public int CambiarEstadoMovBancos(MovimientoBancosE MovBanco, String Estado, String Usuario)
        {
            try
            {
                Int32 resp = 0;
                using (TransactionScope oTrans = new TransactionScope())
                {
                    //if (MovBanco.indDevolucion)
                    //{
                    //    List<MovimientoBancosDetE> oListaMovDet = new MovimientoBancosDetAD().ListarMovimientoBancosDet(MovBanco.idMovBanco, 1);

                    //    if (oListaMovDet != null && oListaMovDet.Count > 0)
                    //    {
                    //        foreach (MovimientoBancosDetE item in oListaMovDet)
                    //        {
                    //            CtaCteE oCtaCte = new CtaCteAD().ObtenerMaeCtaCte(MovBanco.idEmpresa, Convert.ToInt32(MovBanco.idBanco), item.idDocumento, item.serDocumento, item.numDocumento, false);

                    //            if (oCtaCte != null)
                    //            {
                    //                List<CtaCte_DetE> oListaCtaCte = new CtaCte_DetAD().ListarMaeCtaCteDetAbonos(oCtaCte.idEmpresa, oCtaCte.idCtaCte);

                    //                if (oListaCtaCte.Count > 0)
                    //                {
                    //                    throw new Exception(String.Format("Este documento {0} {1}-{2} en la Cta. Cte. ya tiene Movimientos de Abono, elimine los movimientos antes de eliminar la factura.", item.idDocumento, item.serDocumento, item.numDocumento));
                    //                }
                    //                else
                    //                {
                    //                    // Eliminando el detalle
                    //                    new CtaCte_DetAD().EliminarMaeCtaCteDetalle(oCtaCte.idEmpresa, oCtaCte.idCtaCte);
                    //                    // Eliminando la cabecera
                    //                    new CtaCteAD().EliminarMaeCtaCte(oCtaCte.idEmpresa, oCtaCte.idCtaCte);
                    //                }
                    //            }
                    //        }
                    //    } 
                    //}

                    new MovimientoBancosAD().CambiarEstadoMovBancos(MovBanco.idMovBanco, Estado, Usuario);

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

        public Int32 EliminarVoucherMovBancos(MovimientoBancosE movBanco, Int32 idLocal, String Usuario, String Masivo = "N")
        {
            try
            {
                Int32 resp = 0;

                using (TransactionScope oTrans = new TransactionScope())
                {
                    if (Masivo == "N")
                    {
                        //Eliminando el voucher
                        resp = new VoucherAD().EliminarVoucher(movBanco.idEmpresa, idLocal, movBanco.AnioPeriodo, movBanco.MesPeriodo, movBanco.numVoucher, movBanco.idComprobante, movBanco.numFile);
                        //Cambiando el estado del movimiento del banco
                        new MovimientoBancosAD().CambiarEstadoMovBancos(movBanco.idMovBanco, "CR", Usuario); 
                    }

                    //Si en caso fuese transferencia entre vinculadas
                    if (movBanco.tipMovimiento == 4)
                    {
                        #region Movimiento del Banco
                        
                        //Obteniendo el listado del movimiento actual para poder obtener id del movimiento de ingreso
                        List<MovimientoBancosDetE> ListaMovimientos = new MovimientoBancosDetAD().ListarMovimientoBancosDet(movBanco.idMovBanco, movBanco.idEmpresa);
                        MovimientoBancosE oMovimientoTrans = null;
                        List<MovimientoBancosDetE> ListaMovimientosTrans = null;

                        //Eliminando el Ingreso de la otra empresa
                        if (ListaMovimientos != null && ListaMovimientos.Count > 0)
                        {
                            if (ListaMovimientos[0].idMoviTrans != null)
                            {
                                //Obteniendo el movimiento de ingreso
                                oMovimientoTrans = new MovimientoBancosAD().ObtenerMovimientoBancos(Convert.ToInt32(ListaMovimientos[0].idMoviTrans));
                                ListaMovimientosTrans = new MovimientoBancosDetAD().ListarMovimientoBancosDet(oMovimientoTrans.idMovBanco, oMovimientoTrans.idEmpresa);

                                //Verificando el estado de dicho movimiento de ingreso
                                if (oMovimientoTrans.indEstado == "PR")
                                {
                                    throw new Exception("El Ingreso que se originó con este movimiento se encuentra Provisionado, primero elimine el Asiento del Ingreso y luego puede eliminar este asiento.");
                                }

                                //Eliminar por completo el movimiento de ingreso
                                new MovimientoBancosDetAD().EliminarMovBancosDetPorId(oMovimientoTrans.idMovBanco);
                                new MovimientoBancosAD().EliminarMovimientoBancos(oMovimientoTrans.idMovBanco);

                                //Borrando los Id de los movimientos de transferencia...
                                new MovimientoBancosDetAD().ActualizarIdMovBancosTrans(movBanco.idMovBanco, oMovimientoTrans.idMovBanco, true);
                            }
                        } 

                        #endregion

                        #region CtaCte

                        if (!movBanco.indDevolucion)//Si es falso
                        {
                            #region Empresa que hace el Préstamo

                            foreach (MovimientoBancosDetE item in ListaMovimientos)
                            {
                                if (item.idCtaCteItem != 0)
                                {
                                    List<CtaCte_DetE> oListaCtaCteDet = null;

                                    if (item.TipAccionCtaCte == "A") //Si es Abono
                                    {
                                        //Eliminando de la Cta.Cte. Abonos en el detalle
                                        new CtaCte_DetAD().EliminarMaeCtaCteDetallePorIdItem(Convert.ToInt32(item.idCtaCteItem));

                                        #region Saldo de CtaCte

                                        //Volviendo a listar la lista para revisar el saldo
                                        oListaCtaCteDet = new CtaCte_DetAD().ListarMaeCtaCteDet(movBanco.idEmpresa, Convert.ToInt32(item.idCtaCte));
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

                                        // Si el saldo es diferente de 0 se vuelve a colocar como pendiente
                                        if (Saldo != 0 || Saldo != 0M)
                                        {
                                            new CtaCteAD().ActualizarFecCancelacionCtaCte(movBanco.idEmpresa, Convert.ToInt32(item.idCtaCte), Convert.ToDateTime("31-12-2100"), Usuario);
                                        }

                                        #endregion
                                    }
                                    else //Si es Cargo
                                    {
                                        oListaCtaCteDet = new CtaCte_DetAD().ListarMaeCtaCteDetAbonos(movBanco.idEmpresa, Convert.ToInt32(item.idCtaCte));

                                        //Si hay Abonos no se puede eliminar hasta que se borren esos abonos
                                        if (oListaCtaCteDet.Count > 0)
                                        {
                                            throw new Exception(String.Format("Este documento {0} {1}-{2} en la Cta. Cte. ya tiene Movimientos de Abono, elimine los dichos movimientos antes de eliminar", item.idDocumento, item.serDocumento, item.numDocumento));
                                        }
                                        else
                                        {
                                            // Eliminando la cabecera y el detalle
                                            new CtaCteAD().EliminarMaeCtaCteConDetalle(Convert.ToInt32(item.idCtaCte));
                                        }
                                    }

                                    //Actualizar datos de la CtaCte en el movimiento del banco
                                    resp = new MovimientoBancosDetAD().ActualizarMovBancosDetCtaCte(movBanco.idMovBanco, item.Item, null, null);
                                }
                            }

                            #endregion

                            #region Empresa que recibe el Préstamo

                            foreach (MovimientoBancosDetE item in ListaMovimientosTrans)
                            {
                                if (item.idCtaCteItem != 0)
                                {
                                    List<CtaCte_DetE> oListaCtaCteDet = null;

                                    if (item.TipAccionCtaCte == "A") //Si es Abono
                                    {
                                        //Eliminando de la Cta.Cte. Abonos en el detalle
                                        new CtaCte_DetAD().EliminarMaeCtaCteDetallePorIdItem(Convert.ToInt32(item.idCtaCteItem));

                                        #region Saldo de CtaCte

                                        //Volviendo a listar la lista para revisar el saldo
                                        oListaCtaCteDet = new CtaCte_DetAD().ListarMaeCtaCteDet(oMovimientoTrans.idEmpresa, Convert.ToInt32(item.idCtaCte));
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

                                        // Si el saldo es diferente de 0 se vuelve a colocar como pendiente
                                        if (Saldo != 0 || Saldo != 0M)
                                        {
                                            new CtaCteAD().ActualizarFecCancelacionCtaCte(oMovimientoTrans.idEmpresa, Convert.ToInt32(item.idCtaCte), Convert.ToDateTime("31-12-2100"), Usuario);
                                        }

                                        #endregion
                                    }
                                    else //Si es Cargo
                                    {
                                        oListaCtaCteDet = new CtaCte_DetAD().ListarMaeCtaCteDetAbonos(oMovimientoTrans.idEmpresa, Convert.ToInt32(item.idCtaCte));

                                        //Si hay Abonos no se puede eliminar hasta que se borren esos abonos
                                        if (oListaCtaCteDet.Count > 0)
                                        {
                                            throw new Exception(String.Format("Este documento {0} {1}-{2} en la Cta. Cte. ya tiene Movimientos de Abono, elimine dichos movimientos antes de eliminar.", item.idDocumento, item.serDocumento, item.numDocumento));
                                        }
                                        else
                                        {
                                            // Eliminando la cabecera y el detalle
                                            new CtaCteAD().EliminarMaeCtaCteConDetalle(Convert.ToInt32(item.idCtaCte));
                                        }
                                    }

                                    //Actualizar datos de la CtaCte en el movimiento del banco
                                    resp = new MovimientoBancosDetAD().ActualizarMovBancosDetCtaCte(oMovimientoTrans.idMovBanco, item.Item, null, null);
                                }
                            }

                            #endregion
                        }

                        if (movBanco.indDevolucion)//Si es verdadero
                        {
                            List<CtaCte_DetE> oListaCtaCteDet = null;

                            foreach (MovimientoBancosDetE item in ListaMovimientos)
                            {
                                if (!item.indExceso)
                                {
                                    //Eliminando de la Cta.Cte. Abonos en el detalle
                                    new CtaCte_DetAD().EliminarMaeCtaCteDetallePorIdItem(Convert.ToInt32(item.idCtaCteItem));

                                    #region Saldo de CtaCte

                                    //Volviendo a listar la lista para revisar el saldo
                                    oListaCtaCteDet = new CtaCte_DetAD().ListarMaeCtaCteDet(movBanco.idEmpresa, Convert.ToInt32(item.idCtaCte));
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

                                    // Si el saldo es diferente de 0 se vuelve a colocar como pendiente
                                    if (Saldo != 0)
                                    {
                                        new CtaCteAD().ActualizarFecCancelacionCtaCte(movBanco.idEmpresa, Convert.ToInt32(item.idCtaCte), Convert.ToDateTime("31-12-2100"), Usuario);
                                    }

                                    #endregion

                                    //Actualizar datos de la CtaCte en el movimiento del banco
                                    resp = new MovimientoBancosDetAD().ActualizarMovBancosDetCtaCte(movBanco.idMovBanco, item.Item, null, null); 
                                }
                                else
                                {
                                    #region Empresa que hace el Préstamo

                                    oListaCtaCteDet = new CtaCte_DetAD().ListarMaeCtaCteDetAbonos(movBanco.idEmpresa, Convert.ToInt32(item.idCtaCte));

                                    //Si hay Abonos no se puede eliminar hasta que se borren esos abonos
                                    if (oListaCtaCteDet.Count > 0)
                                    {
                                        throw new Exception(String.Format("Este documento {0} {1}-{2} en la Cta. Cte. ya tiene Movimientos de Abono, elimine los dichos movimientos antes de eliminar", item.idDocumento, item.serDocumento, item.numDocumento));
                                    }
                                    else
                                    {
                                        // Eliminando la cabecera y el detalle
                                        new CtaCteAD().EliminarMaeCtaCteConDetalle(Convert.ToInt32(item.idCtaCte));
                                    } 

                                    //Actualizar datos de la CtaCte en el movimiento del banco
                                    resp = new MovimientoBancosDetAD().ActualizarMovBancosDetCtaCte(movBanco.idMovBanco, item.Item, null, null);

                                    #endregion
                                }
                            }

                            //Limpiando la lista
                            oListaCtaCteDet = null;

                            //Movimientos transferidos
                            foreach (MovimientoBancosDetE item in ListaMovimientosTrans)
                            {
                                if (item.indExceso)
                                {
                                    #region Empresa que recibe el Préstamo

                                    oListaCtaCteDet = new CtaCte_DetAD().ListarMaeCtaCteDetAbonos(oMovimientoTrans.idEmpresa, Convert.ToInt32(item.idCtaCte));

                                    //Si hay Abonos no se puede eliminar hasta que se borren esos abonos
                                    if (oListaCtaCteDet.Count > 0)
                                    {
                                        throw new Exception(String.Format("Este documento {0} {1}-{2} en la Cta. Cte. ya tiene Movimientos de Abono, elimine dichos movimientos antes de eliminar.", item.idDocumento, item.serDocumento, item.numDocumento));
                                    }
                                    else
                                    {
                                        // Eliminando la cabecera y el detalle
                                        new CtaCteAD().EliminarMaeCtaCteConDetalle(Convert.ToInt32(item.idCtaCte));
                                    }

                                    //Actualizar datos de la CtaCte en el movimiento del banco
                                    resp = new MovimientoBancosDetAD().ActualizarMovBancosDetCtaCte(oMovimientoTrans.idMovBanco, item.Item, null, null);

                                    #endregion
                                }
                            }
                        }

                        #endregion
                    }

                    if (movBanco.tipMovimiento == 1) //Ingresos
                    {
                        #region CtaCte

                        if (movBanco.indDevolucion)
                        {
                            //Obteniendo el listado del movimiento actual para poder obtener id del movimiento de ingreso
                            List<MovimientoBancosDetE> ListaMovimientos = new MovimientoBancosDetAD().ListarMovimientoBancosDet(movBanco.idMovBanco, movBanco.idEmpresa);

                            foreach (MovimientoBancosDetE item in ListaMovimientos)
                            {
                                if (!item.indExceso)
                                {
                                    //Eliminando de la Cta.Cte. Abonos en el detalle
                                    new CtaCte_DetAD().EliminarMaeCtaCteDetallePorIdItem(Convert.ToInt32(item.idCtaCteItem));

                                    #region Saldo de CtaCte

                                    //Volviendo a listar la lista para revisar el saldo
                                    List<CtaCte_DetE> oListaCtaCteDet = new CtaCte_DetAD().ListarMaeCtaCteDet(movBanco.idEmpresa, Convert.ToInt32(item.idCtaCte));
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

                                    // Si el saldo es diferente de 0 se vuelve a colocar como pendiente
                                    if (Saldo != 0)
                                    {
                                        new CtaCteAD().ActualizarFecCancelacionCtaCte(movBanco.idEmpresa, Convert.ToInt32(item.idCtaCte), Convert.ToDateTime("31-12-2100"), Usuario);
                                    }

                                    #endregion

                                    //Actualizar datos de la CtaCte en el movimiento del banco
                                    resp = new MovimientoBancosDetAD().ActualizarMovBancosDetCtaCte(movBanco.idMovBanco, item.Item, null, null); 
                                }
                            }
                        }

                        #endregion
                    }

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

        public String ProvisionesMasivasMovBancos(List<MovimientoBancosE> ListaMovimientos, Int32 idLocal, String Usuario)
        {
            try
            {
                String resp = String.Empty;

                using (TransactionScope oTrans = new TransactionScope())
                {
                    #region Datos Contables

                    foreach (MovimientoBancosE item in ListaMovimientos)
                    {
                        ComprobantesFileE numFile = new ComprobantesFileAD().ObtenerFilePorCuenta(item.idEmpresa, item.idComprobante, item.idMoneda, item.numVerPlanCuentas, item.codCuenta);

                        if (numFile != null)
                        {
                            item.AnioPeriodo = item.fecMovimiento.ToString("yyyy");
                            item.MesPeriodo = item.fecMovimiento.ToString("MM");
                            item.numFile = numFile.numFile;

                            new MovimientoBancosAD().ActualizarMovBancosConta(item);
                        }
                        else
                        {
                            throw new Exception(String.Format("En el registro {0} no existe ningún File asociado con la cuenta contable del banco. Revisarlo antes de generar.", item.codMovBanco));
                        }
                    } 

                    #endregion

                    foreach (MovimientoBancosE item in ListaMovimientos)
                    {
                        #region MyRegion

                        //new MovimientoBancosAD().GenerarProvisionMovBancos(item.idMovBanco, item.idEmpresa, idLocal, Usuario);

                        //if (item.tipMovimiento == 4) //Vinculadas
                        //{
                        //    MovimientoBancosE oMovimiento = new MovimientoBancosAD().ObtenerMovimientoBancos(item.idMovBanco);
                        //    oMovimiento.oListaMovimientos = new MovimientoBancosDetAD().ListarMovimientoBancosDet(item.idMovBanco, oMovimiento.idEmpresa);

                        //    if (oMovimiento.oListaMovimientos.Count > 0)
                        //    {
                        //        Int32 idEmpresaTrans = Convert.ToInt32(oMovimiento.oListaMovimientos[0].idEmpresaTrans);
                        //        BancosCuentasE oCuentaBancos = new BancosCuentasAD().ObtenerBancosCuentas(Convert.ToInt32(oMovimiento.oListaMovimientos[0].idBancoTrans), idEmpresaTrans, oMovimiento.oListaMovimientos[0].ctaBancariaTrans);
                        //        MovimientoBancosE MovimientoTrans = Colecciones.CopiarEntidad(oMovimiento);
                        //        MovimientoTrans.oListaMovimientos = new List<MovimientoBancosDetE>((from x in oMovimiento.oListaMovimientos where x.idEmpresaTrans > 0 select x).ToList());

                        //        MovimientoTrans.tipMovimiento = 1; //Ingresos
                        //        MovimientoTrans.idEmpresa = idEmpresaTrans;
                        //        MovimientoTrans.idBanco = Convert.ToInt32(oMovimiento.oListaMovimientos[0].idBancoTrans);
                        //        MovimientoTrans.ctaBancaria = oMovimiento.oListaMovimientos[0].ctaBancariaTrans;
                        //        MovimientoTrans.idMoneda = oMovimiento.oListaMovimientos[0].idMonedaTrans;
                        //        //MovimientoTrans.fecMovimiento = oMovimiento.oListaMovimientos[0].fecDocumento;
                        //        MovimientoTrans.TicaAuto = oMovimiento.oListaMovimientos[0].TicaAuto;
                        //        MovimientoTrans.tipCambio = oMovimiento.oListaMovimientos[0].tipCambio;
                        //        MovimientoTrans.Glosa = oMovimiento.oListaMovimientos[0].Glosa;
                        //        MovimientoTrans.idDocumento = oMovimiento.oListaMovimientos[0].idDocumento;
                        //        MovimientoTrans.serDocumento = oMovimiento.oListaMovimientos[0].serDocumento;
                        //        MovimientoTrans.numDocumento = oMovimiento.oListaMovimientos[0].numDocumento;
                        //        MovimientoTrans.fecDocumento = oMovimiento.oListaMovimientos[0].fecDocumento;
                        //        //MovimientoTrans.idMedioPago = oMovimiento.idMedioPago;
                        //        MovimientoTrans.TotalImporte = oMovimiento.oListaMovimientos[0].Importe;
                        //        MovimientoTrans.TotalImporteDol = oMovimiento.oListaMovimientos[0].ImporteDolar;
                        //        MovimientoTrans.GiradoA = oMovimiento.GiradoA;
                        //        MovimientoTrans.MontoTransS = oMovimiento.oListaMovimientos[0].Importe;
                        //        MovimientoTrans.MontoTransD = oMovimiento.oListaMovimientos[0].ImporteDolar;
                        //        MovimientoTrans.numVerPlanCuentas = oCuentaBancos.numVerPlanCuentas;
                        //        MovimientoTrans.codCuenta = oCuentaBancos.codCuenta;
                        //        MovimientoTrans.AnioPeriodo = String.Empty;
                        //        MovimientoTrans.MesPeriodo = String.Empty;
                        //        MovimientoTrans.idComprobante = String.Empty;
                        //        MovimientoTrans.numFile = String.Empty;
                        //        MovimientoTrans.numVoucher = String.Empty;
                        //        MovimientoTrans.UsuarioRegistro = oMovimiento.UsuarioRegistro;

                        //        List<ConceptosVariosE> ListaConceptos = new ConceptosVariosAD().ConceptosVariosTesoreria(0, idEmpresaTrans, "");

                        //        ConceptosVariosE oConcepto = ListaConceptos.Find
                        //        (
                        //            delegate (ConceptosVariosE c) { return c.Descripcion.ToUpper().Contains("PRESTAMO") && c.indTransferencia == true; }
                        //        );

                        //        if (oConcepto == null)
                        //        {
                        //            throw new Exception("No existe el concepto de préstamo en la empresa a transferir.");
                        //        }

                        //        foreach (MovimientoBancosDetE itemDet in MovimientoTrans.oListaMovimientos)
                        //        {
                        //            itemDet.idConcepto = oConcepto.idConcepto;
                        //            itemDet.idPersona = itemDet.idPersona == 0 ? (int?)null : itemDet.idPersona;
                        //            itemDet.idEmpresaTrans = oMovimiento.idEmpresa;
                        //            itemDet.idBancoTrans = oMovimiento.idBanco;
                        //            itemDet.idMonedaTrans = oMovimiento.idMoneda;
                        //            itemDet.ctaBancariaTrans = oMovimiento.ctaBancaria;
                        //            item.UsuarioRegistro = Usuario;
                        //        }

                        //        GrabarMovimientoBancos(MovimientoTrans, EnumOpcionGrabar.Insertar);
                        //        new MovimientoBancosDetAD().ActualizarIdMovBancosTrans(oMovimiento.idMovBanco, MovimientoTrans.idMovBanco);
                        //    }

                        //    #region CtaCte

                        //    if (oMovimiento.indDevolucion)
                        //    {
                        //        foreach (MovimientoBancosDetE itemDet in oMovimiento.oListaMovimientos)
                        //        {
                        //            CtaCteE oCtaCte = new CtaCteAD().ObtenerMaeCtaCtePorDocumento(item.idEmpresa, itemDet.idDocumento, itemDet.serDocumento, itemDet.numDocumento);

                        //            if (oCtaCte != null)
                        //            {
                        //                #region Detalle

                        //                CtaCte_DetE oCtaCteDet = new CtaCte_DetE
                        //                {
                        //                    idEmpresa = item.idEmpresa,
                        //                    idCtaCte = oCtaCte.idCtaCte,
                        //                    idDocumentoMov = itemDet.idDocumento.Trim(),
                        //                    SerieMov = itemDet.serDocumento.Trim(),
                        //                    NumeroMov = itemDet.numDocumento.Trim(),
                        //                    FechaMovimiento = Convert.ToDateTime(itemDet.fecDocumento),
                        //                    idMoneda = itemDet.idMoneda,
                        //                    MontoMov = itemDet.idMoneda == "01" ? itemDet.Importe : itemDet.ImporteDolar,
                        //                    TipoCambio = Convert.ToDecimal(itemDet.tipCambio),
                        //                    TipAccion = EnumEstadoDocumentos.A.ToString(),
                        //                    numVerPlanCuentas = oMovimiento.numVerPlanCuentas,
                        //                    codCuenta = oMovimiento.codCuenta,
                        //                    UsuarioRegistro = Usuario
                        //                };

                        //                new CtaCte_DetAD().InsertarMaeCtaCteDet(oCtaCteDet);

                        //                #endregion

                        //                #region Verificando Saldo de la CtaCte.

                        //                List<CtaCte_DetE> oListaCtaCteDet = new CtaCte_DetAD().ListarMaeCtaCteDet(oCtaCte.idEmpresa, oCtaCte.idCtaCte);

                        //                Decimal Saldo = 0;

                        //                foreach (CtaCte_DetE itemCtaCte in oListaCtaCteDet)
                        //                {
                        //                    if (itemCtaCte.TipAccion == "C")
                        //                    {
                        //                        Saldo = Saldo + Convert.ToDecimal(itemCtaCte.MontoMov);
                        //                    }
                        //                    else
                        //                    {
                        //                        Saldo = Saldo - Convert.ToDecimal(itemCtaCte.MontoMov);
                        //                    }
                        //                }

                        //                // Si el saldo es 0 Cancela colocar fecha de cancelacion de la cta.cte.
                        //                if (Saldo == 0)
                        //                {
                        //                    new CtaCteAD().ActualizarFecCancelacionCtaCte(oCtaCte.idEmpresa, oCtaCte.idCtaCte, oMovimiento.fecDocumento.Value, Usuario);
                        //                }

                        //                #endregion
                        //            }
                        //        }
                        //    }

                        //    #endregion
                        //}

                        //if (item.tipMovimiento == 1 && item.indDevolucion) //Ingresos y además inde¿ica devolución
                        //{
                        //    MovimientoBancosE oMovimiento = new MovimientoBancosAD().ObtenerMovimientoBancos(item.idMovBanco);
                        //    oMovimiento.oListaMovimientos = new MovimientoBancosDetAD().ListarMovimientoBancosDet(item.idMovBanco, oMovimiento.idEmpresa);

                        //    #region CtaCte

                        //    if (oMovimiento.indDevolucion)
                        //    {
                        //        foreach (MovimientoBancosDetE itemDet in oMovimiento.oListaMovimientos)
                        //        {
                        //            CtaCteE oCtaCte = new CtaCteAD().ObtenerMaeCtaCtePorDocumento(item.idEmpresa, itemDet.idDocumento, itemDet.serDocumento, itemDet.numDocumento);

                        //            if (oCtaCte != null)
                        //            {
                        //                #region Detalle

                        //                CtaCte_DetE oCtaCteDet = new CtaCte_DetE
                        //                {
                        //                    idEmpresa = item.idEmpresa,
                        //                    idCtaCte = oCtaCte.idCtaCte,
                        //                    idDocumentoMov = itemDet.idDocumento.Trim(),
                        //                    SerieMov = itemDet.serDocumento.Trim(),
                        //                    NumeroMov = itemDet.numDocumento.Trim(),
                        //                    FechaMovimiento = Convert.ToDateTime(itemDet.fecDocumento),
                        //                    idMoneda = itemDet.idMoneda,
                        //                    MontoMov = itemDet.idMoneda == "01" ? itemDet.Importe : itemDet.ImporteDolar,
                        //                    TipoCambio = Convert.ToDecimal(itemDet.tipCambio),
                        //                    TipAccion = EnumEstadoDocumentos.A.ToString(),
                        //                    numVerPlanCuentas = oMovimiento.numVerPlanCuentas,
                        //                    codCuenta = oMovimiento.codCuenta,
                        //                    UsuarioRegistro = Usuario
                        //                };

                        //                new CtaCte_DetAD().InsertarMaeCtaCteDet(oCtaCteDet);

                        //                #endregion

                        //                #region Verificando Saldo de la CtaCte.

                        //                List<CtaCte_DetE> oListaCtaCteDet = new CtaCte_DetAD().ListarMaeCtaCteDet(oCtaCte.idEmpresa, oCtaCte.idCtaCte);

                        //                Decimal Saldo = 0;

                        //                foreach (CtaCte_DetE itemCtaCte in oListaCtaCteDet)
                        //                {
                        //                    if (itemCtaCte.TipAccion == "C")
                        //                    {
                        //                        Saldo = Saldo + Convert.ToDecimal(itemCtaCte.MontoMov);
                        //                    }
                        //                    else
                        //                    {
                        //                        Saldo = Saldo - Convert.ToDecimal(itemCtaCte.MontoMov);
                        //                    }
                        //                }

                        //                // Si el saldo es 0 Cancela colocar fecha de cancelacion de la cta.cte.
                        //                if (Saldo == 0)
                        //                {
                        //                    new CtaCteAD().ActualizarFecCancelacionCtaCte(oCtaCte.idEmpresa, oCtaCte.idCtaCte, oMovimiento.fecDocumento.Value, Usuario);
                        //                }

                        //                #endregion
                        //            }
                        //        }
                        //    }

                        //    #endregion
                        //} 

                        #endregion

                        GenerarProvisionMovBancos(item, idLocal, Usuario, "S");
                    }

                    oTrans.Complete();
                    resp = "ok";
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

        public Int32 EliminarVoucherMasivoMovBancos(List<MovimientoBancosE> ListaMovBanco, Int32 idLocal, String Usuario)
        {
            try
            {
                Int32 resp = 0;

                using (TransactionScope oTrans = new TransactionScope())
                {
                    foreach (MovimientoBancosE item in ListaMovBanco)
                    {
                        //Eliminando el voucher
                        new VoucherAD().EliminarVoucher(item.idEmpresa, idLocal, item.AnioPeriodo, item.MesPeriodo, item.numVoucher, item.idComprobante, item.numFile);
                        //Cambiando el estado del movimiento del banco
                        new MovimientoBancosAD().CambiarEstadoMovBancos(item.idMovBanco, "CR", Usuario);

                        //Eliminando los otros datos
                        EliminarVoucherMovBancos(item, idLocal, Usuario, "S");

                        #region MyRegion
                        ////Si en caso fuese transferencia entre vinculadas
                        //if (item.tipMovimiento == 4)
                        //{
                        //    //Obteniendo el listado del movimiento actual para poder obtener id del movimiento de ingreso
                        //    List<MovimientoBancosDetE> ListaMovimientos = new MovimientoBancosDetAD().ListarMovimientoBancosDet(item.idMovBanco, item.idEmpresa);

                        //    if (ListaMovimientos != null && ListaMovimientos.Count > 0)
                        //    {
                        //        //Obteniendo el movimiento de ingreso
                        //        MovimientoBancosE oMovimientoTrans = new MovimientoBancosAD().ObtenerMovimientoBancos(Convert.ToInt32(ListaMovimientos[0].idMoviTrans));

                        //        //Verificando el estado de dicho movimiento de ingreso
                        //        if (oMovimientoTrans.indEstado == "PR")
                        //        {
                        //            throw new Exception("El Ingreso que se originó con este movimiento se encuentra Provisionado, primero elimine el Asiento del Ingreso y luego puede eliminar este asiento.");
                        //        }

                        //        //Eliminar por completo el movimiento de ingreso
                        //        new MovimientoBancosDetAD().EliminarMovBancosDetPorId(oMovimientoTrans.idMovBanco);
                        //        new MovimientoBancosAD().EliminarMovimientoBancos(oMovimientoTrans.idMovBanco);

                        //        //Borrando los Id de los movimientos...
                        //        new MovimientoBancosDetAD().ActualizarIdMovBancosTrans(item.idMovBanco, oMovimientoTrans.idMovBanco, true);
                        //    }

                        //    #region CtaCte

                        //    if (item.indDevolucion)
                        //    {
                        //        foreach (MovimientoBancosDetE itemDet in ListaMovimientos)
                        //        {
                        //            //Eliminando de la Cta.Cte. 
                        //            new CtaCte_DetAD().EliminarCtaCteDetPorDocumento(item.idEmpresa, itemDet.idDocumento, itemDet.serDocumento, itemDet.numDocumento);

                        //            #region Verificando Saldo de la CtaCte.

                        //            //Obteniendo la cabecera...
                        //            CtaCteE oCtaCteCabecera = new CtaCteAD().ObtenerMaeCtaCtePorDocumento(item.idEmpresa, itemDet.idDocumento, itemDet.serDocumento, itemDet.numDocumento);

                        //            if (oCtaCteCabecera != null)
                        //            {
                        //                List<CtaCte_DetE> oListaCtaCteDet = new CtaCte_DetAD().ListarMaeCtaCteDet(oCtaCteCabecera.idEmpresa, Convert.ToInt32(oCtaCteCabecera.idCtaCte));
                        //                Decimal Saldo = 0;

                        //                foreach (CtaCte_DetE itemCtaCte in oListaCtaCteDet)
                        //                {
                        //                    if (itemCtaCte.TipAccion == "C")
                        //                    {
                        //                        Saldo = Saldo + Convert.ToDecimal(itemCtaCte.MontoMov);
                        //                    }
                        //                    else
                        //                    {
                        //                        Saldo = Saldo - Convert.ToDecimal(itemCtaCte.MontoMov);
                        //                    }
                        //                }

                        //                // Si el saldo es 0 Cancela colocar fecha de cancelacion de la cta.cte.
                        //                if (Saldo != 0)
                        //                {
                        //                    new CtaCteAD().ActualizarFecCancelacionCtaCte(item.idEmpresa, Convert.ToInt32(oCtaCteCabecera.idCtaCte), Convert.ToDateTime("31-12-2100"), Usuario);
                        //                }
                        //            }

                        //            #endregion

                        //        }
                        //    }

                        //    #endregion
                        //}

                        //if (item.tipMovimiento == 1) //Ingresos
                        //{
                        //    //Obteniendo el listado del movimiento actual para poder obtener id del movimiento de ingreso
                        //    List<MovimientoBancosDetE> ListaMovimientos = new MovimientoBancosDetAD().ListarMovimientoBancosDet(item.idMovBanco, item.idEmpresa);

                        //    #region CtaCte

                        //    if (item.indDevolucion)
                        //    {
                        //        foreach (MovimientoBancosDetE itemDet in ListaMovimientos)
                        //        {
                        //            //Eliminando de la Cta.Cte. 
                        //            new CtaCte_DetAD().EliminarCtaCteDetPorDocumento(item.idEmpresa, itemDet.idDocumento, itemDet.serDocumento, itemDet.numDocumento);

                        //            #region Verificando Saldo de la CtaCte.

                        //            //Obteniendo la cabecera...
                        //            CtaCteE oCtaCteCabecera = new CtaCteAD().ObtenerMaeCtaCtePorDocumento(item.idEmpresa, itemDet.idDocumento, itemDet.serDocumento, itemDet.numDocumento);

                        //            if (oCtaCteCabecera != null)
                        //            {
                        //                List<CtaCte_DetE> oListaCtaCteDet = new CtaCte_DetAD().ListarMaeCtaCteDet(oCtaCteCabecera.idEmpresa, Convert.ToInt32(oCtaCteCabecera.idCtaCte));
                        //                Decimal Saldo = 0;

                        //                foreach (CtaCte_DetE itemCtaCte in oListaCtaCteDet)
                        //                {
                        //                    if (itemCtaCte.TipAccion == "C")
                        //                    {
                        //                        Saldo = Saldo + Convert.ToDecimal(itemCtaCte.MontoMov);
                        //                    }
                        //                    else
                        //                    {
                        //                        Saldo = Saldo - Convert.ToDecimal(itemCtaCte.MontoMov);
                        //                    }
                        //                }

                        //                // Si el saldo es 0 Cancela colocar fecha de cancelacion de la cta.cte.
                        //                if (Saldo != 0)
                        //                {
                        //                    new CtaCteAD().ActualizarFecCancelacionCtaCte(item.idEmpresa, Convert.ToInt32(oCtaCteCabecera.idCtaCte), Convert.ToDateTime("31-12-2100"), Usuario);
                        //                }
                        //            }

                        //            #endregion

                        //        }
                        //    }

                        //    #endregion
                        //} 
                        #endregion

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

        public Int32 ActualizarMovBancosCtaCte(MovimientoBancosE oMovimientoBanco, String Usuario)
        {
            try
            {
                Int32 resp = 0;
                MovimientoBancosE oMovimiento = new MovimientoBancosAD().ObtenerMovimientoBancos(oMovimientoBanco.idMovBanco);
                oMovimiento.oListaMovimientos = new MovimientoBancosDetAD().ListarMovimientoBancosDet(oMovimiento.idMovBanco, oMovimiento.idEmpresa);

                MovimientoBancosDetE MovimientoPrestamo = oMovimiento.oListaMovimientos.Find
                (
                    delegate (MovimientoBancosDetE mp) { return mp.idDocumento == "PR"; }
                );

                using (TransactionScope oTrans = new TransactionScope())
                {
                    if (MovimientoPrestamo != null)
                    {
                        ConceptosVariosE oConcepto = new ConceptosVariosAD().ObtenerConceptosVarios(MovimientoPrestamo.idConcepto, oMovimiento.idEmpresa);
                        String Cuenta16 = String.Empty;
                        String Cuenta46 = String.Empty;
                        Int32 idCtaCte = 0;
                        Int32 idCtaCteItem = 0;
                        Persona Auxiliar = null;

                        #region Cuentas Contables

                        if (MovimientoPrestamo.idMoneda == "01")
                        {
                            Cuenta16 = oConcepto.CtaSoles;
                            Cuenta46 = oConcepto.CtaContraSoles;
                        }
                        else
                        {
                            Cuenta16 = oConcepto.CtaDolares;
                            Cuenta46 = oConcepto.CtaContraDolares;
                        }

                        if (oConcepto.indCuentasMon)
                        {
                            if (String.IsNullOrWhiteSpace(Cuenta16))
                            {
                                throw new Exception(String.Format("Falta colocar la cuenta contable en el Concepto {0}.", oConcepto.Descripcion));
                            }
                        }

                        if (oConcepto.indContraPartida)
                        {
                            if (String.IsNullOrWhiteSpace(Cuenta46))
                            {
                                throw new Exception(String.Format("Falta colocar la cuenta contable de contrapartida en el Concepto {0}.", oConcepto.Descripcion));
                            }
                        } 

                        #endregion

                        if (MovimientoPrestamo.idCtaCte == 0) //INSERTAR
                        {
                            if (oConcepto != null)
                            {
                                if (oConcepto.indTransferencia)
                                {
                                    #region Empresa que hace el Préstamo
                                    
                                    #region Cabecera

                                    CtaCteE oCtaCte = new CtaCteE
                                    {
                                        idEmpresa = Convert.ToInt32(oMovimiento.idEmpresa),
                                        idPersona = Convert.ToInt32(oMovimiento.idBanco),
                                        idDocumento = MovimientoPrestamo.idDocumento,
                                        numSerie = MovimientoPrestamo.serDocumento,
                                        numDocumento = MovimientoPrestamo.numDocumento,
                                        idMoneda = MovimientoPrestamo.idMonedaTrans,
                                        MontoOrig = MovimientoPrestamo.idMonedaTrans == "01" ? MovimientoPrestamo.Importe : MovimientoPrestamo.ImporteDolar,
                                        TipoCambio = MovimientoPrestamo.tipCambio,
                                        FechaDocumento = Convert.ToDateTime(MovimientoPrestamo.fecDocumento),
                                        FechaVencimiento = Convert.ToDateTime(MovimientoPrestamo.fecDocumento),
                                        FechaCancelacion = Convert.ToDateTime("31-12-2100"),
                                        numVerPlanCuentas = oConcepto.numVerPlanCuentas,
                                        codCuenta = Cuenta16,
                                        AnnoVencimiento = String.Empty,
                                        MesVencimiento = String.Empty,
                                        SemanaVencimiento = String.Empty,
                                        tipPartidaPresu = String.Empty,
                                        codPartidaPresu = String.Empty,
                                        desGlosa = MovimientoPrestamo.Glosa,
                                        FechaOperacion = Convert.ToDateTime(oMovimiento.fecDocumento),
                                        EsDetraCab = false,
                                        idCtaCteOrigen = 0,
                                        idSistema = 6, //Tesoreria
                                        UsuarioRegistro = Usuario
                                    };

                                    oCtaCte = new CtaCteAD().InsertarMaeCtaCte(oCtaCte);

                                    //Obteniendo el id de la ctacte...
                                    idCtaCte = oCtaCte.idCtaCte;

                                    #endregion

                                    #region Detalle

                                    CtaCte_DetE oCtaCteDet = new CtaCte_DetE
                                    {
                                        idEmpresa = Convert.ToInt32(oMovimiento.idEmpresa),
                                        idCtaCte = idCtaCte,
                                        idDocumentoMov = MovimientoPrestamo.idDocumento,
                                        SerieMov = MovimientoPrestamo.serDocumento,
                                        NumeroMov = MovimientoPrestamo.numDocumento,
                                        FechaMovimiento = Convert.ToDateTime(MovimientoPrestamo.fecDocumento),
                                        idMoneda = MovimientoPrestamo.idMonedaTrans,
                                        MontoMov = MovimientoPrestamo.idMonedaTrans == "01" ? MovimientoPrestamo.Importe : MovimientoPrestamo.ImporteDolar,
                                        TipoCambio = MovimientoPrestamo.tipCambio,
                                        TipAccion = EnumEstadoDocumentos.C.ToString(),
                                        numVerPlanCuentas = oConcepto.numVerPlanCuentas,
                                        codCuenta = Cuenta16,
                                        desGlosa = MovimientoPrestamo.Glosa,
                                        EsDetraccion = false,
                                        UsuarioRegistro = Usuario
                                    };

                                    oCtaCteDet = new CtaCte_DetAD().InsertarMaeCtaCteDet(oCtaCteDet);

                                    //Obteniendo el id de la Item de la CtaCte Detalle...
                                    idCtaCteItem = oCtaCteDet.idCtaCteItem;

                                    #endregion

                                    //Actualizar datos CtaCte al movimiento
                                    new MovimientoBancosDetAD().ActualizarMovBancosDetCtaCte(oMovimiento.idMovBanco, MovimientoPrestamo.Item, idCtaCte, idCtaCteItem);

                                    #endregion

                                    idCtaCte = 0;
                                    idCtaCteItem = 0;

                                    #region Empresa que recibe el Préstamo

                                    #region Cabecera

                                    Auxiliar = new PersonaAD().ObtenerPersonaPorNroRuc(oMovimiento.RucEmpresa);

                                    if (Auxiliar == null)
                                    {
                                        throw new Exception("La empresa actual no esta registrado como auxiliar.");
                                    }

                                    oCtaCte = new CtaCteE
                                    {
                                        idEmpresa = Convert.ToInt32(MovimientoPrestamo.idEmpresaTrans),
                                        idPersona = Convert.ToInt32(Auxiliar.IdPersona),
                                        idDocumento = MovimientoPrestamo.idDocumento,
                                        numSerie = MovimientoPrestamo.serDocumento,
                                        numDocumento = MovimientoPrestamo.numDocumento,
                                        idMoneda = MovimientoPrestamo.idMonedaTrans,
                                        MontoOrig = MovimientoPrestamo.idMonedaTrans == "01" ? MovimientoPrestamo.Importe : MovimientoPrestamo.ImporteDolar,
                                        TipoCambio = MovimientoPrestamo.tipCambio,
                                        FechaDocumento = Convert.ToDateTime(MovimientoPrestamo.fecDocumento),
                                        FechaVencimiento = Convert.ToDateTime(MovimientoPrestamo.fecDocumento),
                                        FechaCancelacion = Convert.ToDateTime("31-12-2100"),
                                        numVerPlanCuentas = oConcepto.numVerPlanCuentas,
                                        codCuenta = Cuenta46,
                                        AnnoVencimiento = String.Empty,
                                        MesVencimiento = String.Empty,
                                        SemanaVencimiento = String.Empty,
                                        tipPartidaPresu = String.Empty,
                                        codPartidaPresu = String.Empty,
                                        desGlosa = MovimientoPrestamo.Glosa,
                                        FechaOperacion = Convert.ToDateTime(oMovimiento.fecDocumento),
                                        EsDetraCab = false,
                                        idCtaCteOrigen = 0,
                                        idSistema = 6, //Tesoreria
                                        UsuarioRegistro = Usuario
                                    };

                                    oCtaCte = new CtaCteAD().InsertarMaeCtaCte(oCtaCte);

                                    //Obteniendo el id de la ctacte...
                                    idCtaCte = oCtaCte.idCtaCte;

                                    #endregion

                                    #region Detalle

                                    oCtaCteDet = new CtaCte_DetE
                                    {
                                        idEmpresa = Convert.ToInt32(MovimientoPrestamo.idEmpresaTrans),
                                        idCtaCte = idCtaCte,
                                        idDocumentoMov = MovimientoPrestamo.idDocumento,
                                        SerieMov = MovimientoPrestamo.serDocumento,
                                        NumeroMov = MovimientoPrestamo.numDocumento,
                                        FechaMovimiento = Convert.ToDateTime(MovimientoPrestamo.fecDocumento),
                                        idMoneda = MovimientoPrestamo.idMonedaTrans,
                                        MontoMov = MovimientoPrestamo.idMonedaTrans == "01" ? MovimientoPrestamo.Importe : MovimientoPrestamo.ImporteDolar,
                                        TipoCambio = MovimientoPrestamo.tipCambio,
                                        TipAccion = EnumEstadoDocumentos.C.ToString(),
                                        numVerPlanCuentas = oConcepto.numVerPlanCuentas,
                                        codCuenta = Cuenta46,
                                        desGlosa = MovimientoPrestamo.Glosa,
                                        EsDetraccion = false,
                                        UsuarioRegistro = Usuario
                                    };

                                    oCtaCteDet = new CtaCte_DetAD().InsertarMaeCtaCteDet(oCtaCteDet);

                                    //Obteniendo el id de la Item de la CtaCte Detalle...
                                    idCtaCteItem = oCtaCteDet.idCtaCteItem;

                                    #endregion

                                    //Actualizar datos CtaCte al movimiento transferido
                                    new MovimientoBancosDetAD().ActualizarMovBancosDetCtaCte(Convert.ToInt32(MovimientoPrestamo.idMoviTrans), MovimientoPrestamo.Item, idCtaCte, idCtaCteItem);

                                    #endregion
                                }
                            }
                        }
                        else //ACTUALIZAR
                        {
                            if (oConcepto != null)
                            {
                                if (oConcepto.indTransferencia)
                                {
                                    #region Empresa que hace el Préstamo

                                    #region Cabecera

                                    CtaCteE oCtaCte = new CtaCteE
                                    {
                                        idEmpresa = Convert.ToInt32(oMovimientoBanco.idEmpresa),
                                        idCtaCte = Convert.ToInt32(MovimientoPrestamo.idCtaCte),
                                        idPersona = Convert.ToInt32(oMovimientoBanco.idBanco),
                                        idDocumento = MovimientoPrestamo.idDocumento,
                                        numSerie = MovimientoPrestamo.serDocumento,
                                        numDocumento = MovimientoPrestamo.numDocumento,
                                        idMoneda = MovimientoPrestamo.idMonedaTrans,
                                        MontoOrig = MovimientoPrestamo.idMonedaTrans == "01" ? MovimientoPrestamo.Importe : MovimientoPrestamo.ImporteDolar,
                                        TipoCambio = MovimientoPrestamo.tipCambio,
                                        FechaDocumento = Convert.ToDateTime(MovimientoPrestamo.fecDocumento),
                                        FechaVencimiento = Convert.ToDateTime(MovimientoPrestamo.fecDocumento),
                                        FechaCancelacion = Convert.ToDateTime("31-12-2100"),
                                        numVerPlanCuentas = oConcepto.numVerPlanCuentas,
                                        codCuenta = Cuenta16,
                                        AnnoVencimiento = String.Empty,
                                        MesVencimiento = String.Empty,
                                        SemanaVencimiento = String.Empty,
                                        tipPartidaPresu = String.Empty,
                                        codPartidaPresu = String.Empty,
                                        desGlosa = MovimientoPrestamo.Glosa,
                                        FechaOperacion = Convert.ToDateTime(oMovimientoBanco.fecDocumento),
                                        EsDetraCab = false,
                                        idCtaCteOrigen = 0,
                                        idSistema = 6, //Tesoreria
                                        UsuarioModificacion = Usuario
                                    };

                                    new CtaCteAD().ActualizarMaeCtaCte(oCtaCte);

                                    #endregion

                                    #region Detalle

                                    CtaCte_DetE oCtaCteDet = new CtaCte_DetE
                                    {
                                        idEmpresa = Convert.ToInt32(oMovimientoBanco.idEmpresa),
                                        idCtaCte = Convert.ToInt32(MovimientoPrestamo.idCtaCte),
                                        idCtaCteItem = Convert.ToInt32(MovimientoPrestamo.idCtaCteItem),
                                        idDocumentoMov = MovimientoPrestamo.idDocumento,
                                        SerieMov = MovimientoPrestamo.serDocumento,
                                        NumeroMov = MovimientoPrestamo.numDocumento,
                                        FechaMovimiento = Convert.ToDateTime(MovimientoPrestamo.fecDocumento),
                                        idMoneda = MovimientoPrestamo.idMonedaTrans,
                                        MontoMov = MovimientoPrestamo.idMonedaTrans == "01" ? MovimientoPrestamo.Importe : MovimientoPrestamo.ImporteDolar,
                                        TipoCambio = MovimientoPrestamo.tipCambio,
                                        TipAccion = EnumEstadoDocumentos.C.ToString(),
                                        numVerPlanCuentas = oConcepto.numVerPlanCuentas,
                                        codCuenta = Cuenta16,
                                        desGlosa = MovimientoPrestamo.Glosa,
                                        EsDetraccion = false,
                                        UsuarioModificacion = Usuario
                                    };

                                    new CtaCte_DetAD().ActualizarMaeCtaCteDet(oCtaCteDet);

                                    #endregion

                                    #endregion

                                    #region Empresa que recibe el Préstamo

                                    MovimientoBancosE oMovimientoTransferencia = ObtenerMovimientoBancos(Convert.ToInt32(MovimientoPrestamo.idMoviTrans));
                                    MovimientoBancosDetE movPrestamoTmp = oMovimientoTransferencia.oListaMovimientos.Find
                                    (
                                        delegate (MovimientoBancosDetE mp) { return mp.idDocumento == "PR"; }
                                    );

                                    Auxiliar = new PersonaAD().ObtenerPersonaPorNroRuc(oMovimiento.RucEmpresa);

                                    if (Auxiliar == null)
                                    {
                                        throw new Exception("La empresa actual no esta registrado como auxiliar.");
                                    }

                                    if (movPrestamoTmp.idCtaCte > 0)
                                    {
                                        #region Cabecera

                                        oCtaCte = new CtaCteE
                                        {
                                            idEmpresa = Convert.ToInt32(movPrestamoTmp.idEmpresaTrans),
                                            idCtaCte = Convert.ToInt32(movPrestamoTmp.idCtaCte),
                                            idPersona = Convert.ToInt32(Auxiliar.IdPersona),
                                            idDocumento = movPrestamoTmp.idDocumento,
                                            numSerie = movPrestamoTmp.serDocumento,
                                            numDocumento = movPrestamoTmp.numDocumento,
                                            idMoneda = movPrestamoTmp.idMonedaTrans,
                                            MontoOrig = movPrestamoTmp.idMonedaTrans == "01" ? movPrestamoTmp.Importe : movPrestamoTmp.ImporteDolar,
                                            TipoCambio = movPrestamoTmp.tipCambio,
                                            FechaDocumento = Convert.ToDateTime(movPrestamoTmp.fecDocumento),
                                            FechaVencimiento = Convert.ToDateTime(movPrestamoTmp.fecDocumento),
                                            FechaCancelacion = Convert.ToDateTime("31-12-2100"),
                                            numVerPlanCuentas = oConcepto.numVerPlanCuentas,
                                            codCuenta = movPrestamoTmp.idMonedaTrans == "01" ? oConcepto.CtaContraSoles : oConcepto.CtaContraDolares,
                                            AnnoVencimiento = String.Empty,
                                            MesVencimiento = String.Empty,
                                            SemanaVencimiento = String.Empty,
                                            tipPartidaPresu = String.Empty,
                                            codPartidaPresu = String.Empty,
                                            desGlosa = movPrestamoTmp.Glosa,
                                            FechaOperacion = Convert.ToDateTime(oMovimientoBanco.fecDocumento),
                                            EsDetraCab = false,
                                            idCtaCteOrigen = 0,
                                            idSistema = 6,
                                            UsuarioModificacion = Usuario
                                        };

                                        new CtaCteAD().ActualizarMaeCtaCte(oCtaCte);

                                        #endregion

                                        #region Detalle

                                        oCtaCteDet = new CtaCte_DetE
                                        {
                                            idEmpresa = Convert.ToInt32(movPrestamoTmp.idEmpresaTrans),
                                            idCtaCte = Convert.ToInt32(movPrestamoTmp.idCtaCte),
                                            idCtaCteItem = Convert.ToInt32(movPrestamoTmp.idCtaCteItem),
                                            idDocumentoMov = movPrestamoTmp.idDocumento,
                                            SerieMov = movPrestamoTmp.serDocumento,
                                            NumeroMov = movPrestamoTmp.numDocumento,
                                            FechaMovimiento = Convert.ToDateTime(movPrestamoTmp.fecDocumento),
                                            idMoneda = movPrestamoTmp.idMonedaTrans,
                                            MontoMov = movPrestamoTmp.idMonedaTrans == "01" ? movPrestamoTmp.Importe : movPrestamoTmp.ImporteDolar,
                                            TipoCambio = movPrestamoTmp.tipCambio,
                                            TipAccion = EnumEstadoDocumentos.C.ToString(),
                                            numVerPlanCuentas = oConcepto.numVerPlanCuentas,
                                            codCuenta = movPrestamoTmp.idMonedaTrans == "01" ? oConcepto.CtaContraSoles : oConcepto.CtaContraDolares,
                                            desGlosa = movPrestamoTmp.Glosa,
                                            EsDetraccion = false,
                                            UsuarioModificacion = Usuario
                                        };

                                        new CtaCte_DetAD().ActualizarMaeCtaCteDet(oCtaCteDet);

                                        #endregion
                                    }
                                    else
                                    {
                                        #region Cabecera

                                        oCtaCte = new CtaCteE
                                        {
                                            idEmpresa = Convert.ToInt32(MovimientoPrestamo.idEmpresaTrans),
                                            idPersona = Convert.ToInt32(Auxiliar.IdPersona),
                                            idDocumento = MovimientoPrestamo.idDocumento,
                                            numSerie = MovimientoPrestamo.serDocumento,
                                            numDocumento = MovimientoPrestamo.numDocumento,
                                            idMoneda = MovimientoPrestamo.idMonedaTrans,
                                            MontoOrig = MovimientoPrestamo.idMonedaTrans == "01" ? MovimientoPrestamo.Importe : MovimientoPrestamo.ImporteDolar,
                                            TipoCambio = MovimientoPrestamo.tipCambio,
                                            FechaDocumento = Convert.ToDateTime(MovimientoPrestamo.fecDocumento),
                                            FechaVencimiento = Convert.ToDateTime(MovimientoPrestamo.fecDocumento),
                                            FechaCancelacion = Convert.ToDateTime("31-12-2100"),
                                            numVerPlanCuentas = oConcepto.numVerPlanCuentas,
                                            codCuenta = Cuenta46,
                                            AnnoVencimiento = String.Empty,
                                            MesVencimiento = String.Empty,
                                            SemanaVencimiento = String.Empty,
                                            tipPartidaPresu = String.Empty,
                                            codPartidaPresu = String.Empty,
                                            desGlosa = MovimientoPrestamo.Glosa,
                                            FechaOperacion = Convert.ToDateTime(oMovimiento.fecDocumento),
                                            EsDetraCab = false,
                                            idCtaCteOrigen = 0,
                                            idSistema = 6, //Tesoreria
                                            UsuarioRegistro = Usuario
                                        };

                                        oCtaCte = new CtaCteAD().InsertarMaeCtaCte(oCtaCte);

                                        //Obteniendo el id de la ctacte...
                                        idCtaCte = oCtaCte.idCtaCte;

                                        #endregion

                                        #region Detalle

                                        oCtaCteDet = new CtaCte_DetE
                                        {
                                            idEmpresa = Convert.ToInt32(MovimientoPrestamo.idEmpresaTrans),
                                            idCtaCte = idCtaCte,
                                            idDocumentoMov = MovimientoPrestamo.idDocumento,
                                            SerieMov = MovimientoPrestamo.serDocumento,
                                            NumeroMov = MovimientoPrestamo.numDocumento,
                                            FechaMovimiento = Convert.ToDateTime(MovimientoPrestamo.fecDocumento),
                                            idMoneda = MovimientoPrestamo.idMonedaTrans,
                                            MontoMov = MovimientoPrestamo.idMonedaTrans == "01" ? MovimientoPrestamo.Importe : MovimientoPrestamo.ImporteDolar,
                                            TipoCambio = MovimientoPrestamo.tipCambio,
                                            TipAccion = EnumEstadoDocumentos.C.ToString(),
                                            numVerPlanCuentas = oConcepto.numVerPlanCuentas,
                                            codCuenta = Cuenta46,
                                            desGlosa = MovimientoPrestamo.Glosa,
                                            EsDetraccion = false,
                                            UsuarioRegistro = Usuario
                                        };

                                        oCtaCteDet = new CtaCte_DetAD().InsertarMaeCtaCteDet(oCtaCteDet);

                                        //Obteniendo el id de la Item de la CtaCte Detalle...
                                        idCtaCteItem = oCtaCteDet.idCtaCteItem;

                                        #endregion

                                        //Actualizar datos CtaCte al movimiento
                                        new MovimientoBancosDetAD().ActualizarMovBancosDetCtaCte(Convert.ToInt32(MovimientoPrestamo.idMoviTrans), movPrestamoTmp.Item, idCtaCte, idCtaCteItem);
                                    }

                                    #endregion

                                    resp = 1;
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

        public MovimientoBancosE ActualizarMovimientoBancosDocIngresos(MovimientoBancosE movimientobancos)
        {
            try
            {
                return new MovimientoBancosAD().ActualizarMovimientoBancosDocIngresos(movimientobancos);
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

        private Int32 InsertarMovBancosCtaCteExceso(MovimientoBancosDetE MovimientoPrestamo, String Usuario)
        {
            try
            {
                Int32 resp = 0;
                MovimientoBancosE oMovimientoCab = new MovimientoBancosAD().ObtenerMovimientoBancos(MovimientoPrestamo.idMovBanco);

                using (TransactionScope oTrans = new TransactionScope())
                {
                    if (MovimientoPrestamo != null)
                    {
                        ConceptosVariosE oConcepto = new ConceptosVariosAD().ObtenerConceptosVarios(MovimientoPrestamo.idConcepto, oMovimientoCab.idEmpresa);
                        String Cuenta16 = String.Empty;
                        String Cuenta46 = String.Empty;
                        Int32 idCtaCte = 0;
                        Int32 idCtaCteItem = 0;
                        Persona Auxiliar = null;

                        #region Cuentas Contables

                        if (MovimientoPrestamo.idMoneda == "01")
                        {
                            Cuenta16 = oConcepto.CtaSoles;
                            Cuenta46 = oConcepto.CtaContraSoles;
                        }
                        else
                        {
                            Cuenta16 = oConcepto.CtaDolares;
                            Cuenta46 = oConcepto.CtaContraDolares;
                        }

                        if (oConcepto.indCuentasMon)
                        {
                            if (String.IsNullOrWhiteSpace(Cuenta16))
                            {
                                throw new Exception(String.Format("Falta colocar la cuenta contable en el Concepto {0}.", oConcepto.Descripcion));
                            }
                        }

                        if (oConcepto.indContraPartida)
                        {
                            if (String.IsNullOrWhiteSpace(Cuenta46))
                            {
                                throw new Exception(String.Format("Falta colocar la cuenta contable de contrapartida en el Concepto {0}.", oConcepto.Descripcion));
                            }
                        }

                        #endregion

                        if (MovimientoPrestamo.idCtaCte == 0) //INSERTAR
                        {
                            if (oConcepto != null)
                            {
                                if (oConcepto.indTransferencia)
                                {
                                    #region Empresa que hace el Préstamo

                                    #region Cabecera

                                    CtaCteE oCtaCte = new CtaCteE
                                    {
                                        idEmpresa = Convert.ToInt32(oMovimientoCab.idEmpresa),
                                        idPersona = Convert.ToInt32(oMovimientoCab.idBanco),
                                        idDocumento = MovimientoPrestamo.idDocumento,
                                        numSerie = MovimientoPrestamo.serDocumento,
                                        numDocumento = MovimientoPrestamo.numDocumento,
                                        idMoneda = MovimientoPrestamo.idMonedaTrans,
                                        MontoOrig = MovimientoPrestamo.idMonedaTrans == "01" ? MovimientoPrestamo.Importe : MovimientoPrestamo.ImporteDolar,
                                        TipoCambio = MovimientoPrestamo.tipCambio,
                                        FechaDocumento = Convert.ToDateTime(MovimientoPrestamo.fecDocumento),
                                        FechaVencimiento = Convert.ToDateTime(MovimientoPrestamo.fecDocumento),
                                        FechaCancelacion = Convert.ToDateTime("31-12-2100"),
                                        numVerPlanCuentas = oConcepto.numVerPlanCuentas,
                                        codCuenta = Cuenta16,
                                        AnnoVencimiento = String.Empty,
                                        MesVencimiento = String.Empty,
                                        SemanaVencimiento = String.Empty,
                                        tipPartidaPresu = String.Empty,
                                        codPartidaPresu = String.Empty,
                                        desGlosa = MovimientoPrestamo.Glosa,
                                        FechaOperacion = Convert.ToDateTime(oMovimientoCab.fecDocumento),
                                        EsDetraCab = false,
                                        idCtaCteOrigen = 0,
                                        idSistema = 6, //Tesoreria
                                        UsuarioRegistro = Usuario
                                    };

                                    oCtaCte = new CtaCteAD().InsertarMaeCtaCte(oCtaCte);

                                    //Obteniendo el id de la ctacte...
                                    idCtaCte = oCtaCte.idCtaCte;

                                    #endregion

                                    #region Detalle

                                    CtaCte_DetE oCtaCteDet = new CtaCte_DetE
                                    {
                                        idEmpresa = Convert.ToInt32(oMovimientoCab.idEmpresa),
                                        idCtaCte = idCtaCte,
                                        idDocumentoMov = MovimientoPrestamo.idDocumento,
                                        SerieMov = MovimientoPrestamo.serDocumento,
                                        NumeroMov = MovimientoPrestamo.numDocumento,
                                        FechaMovimiento = Convert.ToDateTime(MovimientoPrestamo.fecDocumento),
                                        idMoneda = MovimientoPrestamo.idMonedaTrans,
                                        MontoMov = MovimientoPrestamo.idMonedaTrans == "01" ? MovimientoPrestamo.Importe : MovimientoPrestamo.ImporteDolar,
                                        TipoCambio = MovimientoPrestamo.tipCambio,
                                        TipAccion = EnumEstadoDocumentos.C.ToString(),
                                        numVerPlanCuentas = oConcepto.numVerPlanCuentas,
                                        codCuenta = Cuenta16,
                                        desGlosa = MovimientoPrestamo.Glosa,
                                        EsDetraccion = false,
                                        UsuarioRegistro = Usuario
                                    };

                                    oCtaCteDet = new CtaCte_DetAD().InsertarMaeCtaCteDet(oCtaCteDet);

                                    //Obteniendo el id de la Item de la CtaCte Detalle...
                                    idCtaCteItem = oCtaCteDet.idCtaCteItem;

                                    #endregion

                                    //Actualizar datos CtaCte al movimiento
                                    new MovimientoBancosDetAD().ActualizarMovBancosDetCtaCte(oMovimientoCab.idMovBanco, MovimientoPrestamo.Item, idCtaCte, idCtaCteItem);

                                    #endregion

                                    idCtaCte = 0;
                                    idCtaCteItem = 0;

                                    #region Empresa que recibe el Préstamo

                                    #region Cabecera

                                    Auxiliar = new PersonaAD().ObtenerPersonaPorNroRuc(oMovimientoCab.RucEmpresa);

                                    if (Auxiliar == null)
                                    {
                                        throw new Exception("La empresa actual no esta registrado como auxiliar.");
                                    }

                                    oCtaCte = new CtaCteE
                                    {
                                        idEmpresa = Convert.ToInt32(MovimientoPrestamo.idEmpresaTrans),
                                        idPersona = Convert.ToInt32(Auxiliar.IdPersona),
                                        idDocumento = MovimientoPrestamo.idDocumento,
                                        numSerie = MovimientoPrestamo.serDocumento,
                                        numDocumento = MovimientoPrestamo.numDocumento,
                                        idMoneda = MovimientoPrestamo.idMonedaTrans,
                                        MontoOrig = MovimientoPrestamo.idMonedaTrans == "01" ? MovimientoPrestamo.Importe : MovimientoPrestamo.ImporteDolar,
                                        TipoCambio = MovimientoPrestamo.tipCambio,
                                        FechaDocumento = Convert.ToDateTime(MovimientoPrestamo.fecDocumento),
                                        FechaVencimiento = Convert.ToDateTime(MovimientoPrestamo.fecDocumento),
                                        FechaCancelacion = Convert.ToDateTime("31-12-2100"),
                                        numVerPlanCuentas = oConcepto.numVerPlanCuentas,
                                        codCuenta = Cuenta46,
                                        AnnoVencimiento = String.Empty,
                                        MesVencimiento = String.Empty,
                                        SemanaVencimiento = String.Empty,
                                        tipPartidaPresu = String.Empty,
                                        codPartidaPresu = String.Empty,
                                        desGlosa = MovimientoPrestamo.Glosa,
                                        FechaOperacion = Convert.ToDateTime(oMovimientoCab.fecDocumento),
                                        EsDetraCab = false,
                                        idCtaCteOrigen = 0,
                                        idSistema = 6, //Tesoreria
                                        UsuarioRegistro = Usuario
                                    };

                                    oCtaCte = new CtaCteAD().InsertarMaeCtaCte(oCtaCte);

                                    //Obteniendo el id de la ctacte...
                                    idCtaCte = oCtaCte.idCtaCte;

                                    #endregion

                                    #region Detalle

                                    oCtaCteDet = new CtaCte_DetE
                                    {
                                        idEmpresa = Convert.ToInt32(MovimientoPrestamo.idEmpresaTrans),
                                        idCtaCte = idCtaCte,
                                        idDocumentoMov = MovimientoPrestamo.idDocumento,
                                        SerieMov = MovimientoPrestamo.serDocumento,
                                        NumeroMov = MovimientoPrestamo.numDocumento,
                                        FechaMovimiento = Convert.ToDateTime(MovimientoPrestamo.fecDocumento),
                                        idMoneda = MovimientoPrestamo.idMonedaTrans,
                                        MontoMov = MovimientoPrestamo.idMonedaTrans == "01" ? MovimientoPrestamo.Importe : MovimientoPrestamo.ImporteDolar,
                                        TipoCambio = MovimientoPrestamo.tipCambio,
                                        TipAccion = EnumEstadoDocumentos.C.ToString(),
                                        numVerPlanCuentas = oConcepto.numVerPlanCuentas,
                                        codCuenta = Cuenta46,
                                        desGlosa = MovimientoPrestamo.Glosa,
                                        EsDetraccion = false,
                                        UsuarioRegistro = Usuario
                                    };

                                    oCtaCteDet = new CtaCte_DetAD().InsertarMaeCtaCteDet(oCtaCteDet);

                                    //Obteniendo el id de la Item de la CtaCte Detalle...
                                    idCtaCteItem = oCtaCteDet.idCtaCteItem;

                                    #endregion

                                    //Actualizar datos CtaCte al movimiento transferido
                                    new MovimientoBancosDetAD().ActualizarMovBancosDetCtaCte(Convert.ToInt32(MovimientoPrestamo.idMoviTrans), MovimientoPrestamo.Item, idCtaCte, idCtaCteItem);

                                    #endregion
                                }
                            }
                        }
                        else //ACTUALIZAR
                        {
                            if (oConcepto != null)
                            {
                                if (oConcepto.indTransferencia)
                                {
                                    #region Empresa que hace el Préstamo

                                    #region Cabecera

                                    CtaCteE oCtaCte = new CtaCteE
                                    {
                                        idEmpresa = Convert.ToInt32(oMovimientoCab.idEmpresa),
                                        idCtaCte = Convert.ToInt32(MovimientoPrestamo.idCtaCte),
                                        idPersona = Convert.ToInt32(oMovimientoCab.idBanco),
                                        idDocumento = MovimientoPrestamo.idDocumento,
                                        numSerie = MovimientoPrestamo.serDocumento,
                                        numDocumento = MovimientoPrestamo.numDocumento,
                                        idMoneda = MovimientoPrestamo.idMonedaTrans,
                                        MontoOrig = MovimientoPrestamo.idMonedaTrans == "01" ? MovimientoPrestamo.Importe : MovimientoPrestamo.ImporteDolar,
                                        TipoCambio = MovimientoPrestamo.tipCambio,
                                        FechaDocumento = Convert.ToDateTime(MovimientoPrestamo.fecDocumento),
                                        FechaVencimiento = Convert.ToDateTime(MovimientoPrestamo.fecDocumento),
                                        FechaCancelacion = Convert.ToDateTime("31-12-2100"),
                                        numVerPlanCuentas = oConcepto.numVerPlanCuentas,
                                        codCuenta = Cuenta16,
                                        AnnoVencimiento = String.Empty,
                                        MesVencimiento = String.Empty,
                                        SemanaVencimiento = String.Empty,
                                        tipPartidaPresu = String.Empty,
                                        codPartidaPresu = String.Empty,
                                        desGlosa = MovimientoPrestamo.Glosa,
                                        FechaOperacion = Convert.ToDateTime(oMovimientoCab.fecDocumento),
                                        EsDetraCab = false,
                                        idCtaCteOrigen = 0,
                                        idSistema = 6, //Tesoreria
                                        UsuarioModificacion = Usuario
                                    };

                                    new CtaCteAD().ActualizarMaeCtaCte(oCtaCte);

                                    #endregion

                                    #region Detalle

                                    CtaCte_DetE oCtaCteDet = new CtaCte_DetE
                                    {
                                        idEmpresa = Convert.ToInt32(oMovimientoCab.idEmpresa),
                                        idCtaCte = Convert.ToInt32(MovimientoPrestamo.idCtaCte),
                                        idCtaCteItem = Convert.ToInt32(MovimientoPrestamo.idCtaCteItem),
                                        idDocumentoMov = MovimientoPrestamo.idDocumento,
                                        SerieMov = MovimientoPrestamo.serDocumento,
                                        NumeroMov = MovimientoPrestamo.numDocumento,
                                        FechaMovimiento = Convert.ToDateTime(MovimientoPrestamo.fecDocumento),
                                        idMoneda = MovimientoPrestamo.idMonedaTrans,
                                        MontoMov = MovimientoPrestamo.idMonedaTrans == "01" ? MovimientoPrestamo.Importe : MovimientoPrestamo.ImporteDolar,
                                        TipoCambio = MovimientoPrestamo.tipCambio,
                                        TipAccion = EnumEstadoDocumentos.C.ToString(),
                                        numVerPlanCuentas = oConcepto.numVerPlanCuentas,
                                        codCuenta = Cuenta16,
                                        desGlosa = MovimientoPrestamo.Glosa,
                                        EsDetraccion = false,
                                        UsuarioModificacion = Usuario
                                    };

                                    new CtaCte_DetAD().ActualizarMaeCtaCteDet(oCtaCteDet);

                                    #endregion

                                    #endregion

                                    #region Empresa que recibe el Préstamo

                                    MovimientoBancosE oMovimientoTransferencia = ObtenerMovimientoBancos(Convert.ToInt32(MovimientoPrestamo.idMoviTrans));
                                    MovimientoBancosDetE movPrestamoTmp = oMovimientoTransferencia.oListaMovimientos.Find
                                    (
                                        delegate (MovimientoBancosDetE mp) { return mp.idDocumento == "PR"; }
                                    );

                                    Auxiliar = new PersonaAD().ObtenerPersonaPorNroRuc(oMovimientoCab.RucEmpresa);

                                    if (Auxiliar == null)
                                    {
                                        throw new Exception("La empresa actual no esta registrado como auxiliar.");
                                    }

                                    if (movPrestamoTmp.idCtaCte > 0)
                                    {
                                        #region Cabecera

                                        oCtaCte = new CtaCteE
                                        {
                                            idEmpresa = Convert.ToInt32(movPrestamoTmp.idEmpresaTrans),
                                            idCtaCte = Convert.ToInt32(movPrestamoTmp.idCtaCte),
                                            idPersona = Convert.ToInt32(Auxiliar.IdPersona),
                                            idDocumento = movPrestamoTmp.idDocumento,
                                            numSerie = movPrestamoTmp.serDocumento,
                                            numDocumento = movPrestamoTmp.numDocumento,
                                            idMoneda = movPrestamoTmp.idMonedaTrans,
                                            MontoOrig = movPrestamoTmp.idMonedaTrans == "01" ? movPrestamoTmp.Importe : movPrestamoTmp.ImporteDolar,
                                            TipoCambio = movPrestamoTmp.tipCambio,
                                            FechaDocumento = Convert.ToDateTime(movPrestamoTmp.fecDocumento),
                                            FechaVencimiento = Convert.ToDateTime(movPrestamoTmp.fecDocumento),
                                            FechaCancelacion = Convert.ToDateTime("31-12-2100"),
                                            numVerPlanCuentas = oConcepto.numVerPlanCuentas,
                                            codCuenta = movPrestamoTmp.idMonedaTrans == "01" ? oConcepto.CtaContraSoles : oConcepto.CtaContraDolares,
                                            AnnoVencimiento = String.Empty,
                                            MesVencimiento = String.Empty,
                                            SemanaVencimiento = String.Empty,
                                            tipPartidaPresu = String.Empty,
                                            codPartidaPresu = String.Empty,
                                            desGlosa = movPrestamoTmp.Glosa,
                                            FechaOperacion = Convert.ToDateTime(oMovimientoCab.fecDocumento),
                                            EsDetraCab = false,
                                            idCtaCteOrigen = 0,
                                            idSistema = 6,
                                            UsuarioModificacion = Usuario
                                        };

                                        new CtaCteAD().ActualizarMaeCtaCte(oCtaCte);

                                        #endregion

                                        #region Detalle

                                        oCtaCteDet = new CtaCte_DetE
                                        {
                                            idEmpresa = Convert.ToInt32(movPrestamoTmp.idEmpresaTrans),
                                            idCtaCte = Convert.ToInt32(movPrestamoTmp.idCtaCte),
                                            idCtaCteItem = Convert.ToInt32(movPrestamoTmp.idCtaCteItem),
                                            idDocumentoMov = movPrestamoTmp.idDocumento,
                                            SerieMov = movPrestamoTmp.serDocumento,
                                            NumeroMov = movPrestamoTmp.numDocumento,
                                            FechaMovimiento = Convert.ToDateTime(movPrestamoTmp.fecDocumento),
                                            idMoneda = movPrestamoTmp.idMonedaTrans,
                                            MontoMov = movPrestamoTmp.idMonedaTrans == "01" ? movPrestamoTmp.Importe : movPrestamoTmp.ImporteDolar,
                                            TipoCambio = movPrestamoTmp.tipCambio,
                                            TipAccion = EnumEstadoDocumentos.C.ToString(),
                                            numVerPlanCuentas = oConcepto.numVerPlanCuentas,
                                            codCuenta = movPrestamoTmp.idMonedaTrans == "01" ? oConcepto.CtaContraSoles : oConcepto.CtaContraDolares,
                                            desGlosa = movPrestamoTmp.Glosa,
                                            EsDetraccion = false,
                                            UsuarioModificacion = Usuario
                                        };

                                        new CtaCte_DetAD().ActualizarMaeCtaCteDet(oCtaCteDet);

                                        #endregion
                                    }
                                    else
                                    {
                                        #region Cabecera

                                        oCtaCte = new CtaCteE
                                        {
                                            idEmpresa = Convert.ToInt32(MovimientoPrestamo.idEmpresaTrans),
                                            idPersona = Convert.ToInt32(Auxiliar.IdPersona),
                                            idDocumento = MovimientoPrestamo.idDocumento,
                                            numSerie = MovimientoPrestamo.serDocumento,
                                            numDocumento = MovimientoPrestamo.numDocumento,
                                            idMoneda = MovimientoPrestamo.idMonedaTrans,
                                            MontoOrig = MovimientoPrestamo.idMonedaTrans == "01" ? MovimientoPrestamo.Importe : MovimientoPrestamo.ImporteDolar,
                                            TipoCambio = MovimientoPrestamo.tipCambio,
                                            FechaDocumento = Convert.ToDateTime(MovimientoPrestamo.fecDocumento),
                                            FechaVencimiento = Convert.ToDateTime(MovimientoPrestamo.fecDocumento),
                                            FechaCancelacion = Convert.ToDateTime("31-12-2100"),
                                            numVerPlanCuentas = oConcepto.numVerPlanCuentas,
                                            codCuenta = Cuenta46,
                                            AnnoVencimiento = String.Empty,
                                            MesVencimiento = String.Empty,
                                            SemanaVencimiento = String.Empty,
                                            tipPartidaPresu = String.Empty,
                                            codPartidaPresu = String.Empty,
                                            desGlosa = MovimientoPrestamo.Glosa,
                                            FechaOperacion = Convert.ToDateTime(oMovimientoCab.fecDocumento),
                                            EsDetraCab = false,
                                            idCtaCteOrigen = 0,
                                            idSistema = 6, //Tesoreria
                                            UsuarioRegistro = Usuario
                                        };

                                        oCtaCte = new CtaCteAD().InsertarMaeCtaCte(oCtaCte);

                                        //Obteniendo el id de la ctacte...
                                        idCtaCte = oCtaCte.idCtaCte;

                                        #endregion

                                        #region Detalle

                                        oCtaCteDet = new CtaCte_DetE
                                        {
                                            idEmpresa = Convert.ToInt32(MovimientoPrestamo.idEmpresaTrans),
                                            idCtaCte = idCtaCte,
                                            idDocumentoMov = MovimientoPrestamo.idDocumento,
                                            SerieMov = MovimientoPrestamo.serDocumento,
                                            NumeroMov = MovimientoPrestamo.numDocumento,
                                            FechaMovimiento = Convert.ToDateTime(MovimientoPrestamo.fecDocumento),
                                            idMoneda = MovimientoPrestamo.idMonedaTrans,
                                            MontoMov = MovimientoPrestamo.idMonedaTrans == "01" ? MovimientoPrestamo.Importe : MovimientoPrestamo.ImporteDolar,
                                            TipoCambio = MovimientoPrestamo.tipCambio,
                                            TipAccion = EnumEstadoDocumentos.C.ToString(),
                                            numVerPlanCuentas = oConcepto.numVerPlanCuentas,
                                            codCuenta = Cuenta46,
                                            desGlosa = MovimientoPrestamo.Glosa,
                                            EsDetraccion = false,
                                            UsuarioRegistro = Usuario
                                        };

                                        oCtaCteDet = new CtaCte_DetAD().InsertarMaeCtaCteDet(oCtaCteDet);

                                        //Obteniendo el id de la Item de la CtaCte Detalle...
                                        idCtaCteItem = oCtaCteDet.idCtaCteItem;

                                        #endregion

                                        //Actualizar datos CtaCte al movimiento
                                        new MovimientoBancosDetAD().ActualizarMovBancosDetCtaCte(Convert.ToInt32(MovimientoPrestamo.idMoviTrans), movPrestamoTmp.Item, idCtaCte, idCtaCteItem);
                                    }

                                    #endregion

                                    resp = 1;
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

    }
}
