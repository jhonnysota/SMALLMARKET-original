using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Transactions;
using System.Linq;

using Entidades.CtasPorCobrar;
using Entidades.Tesoreria;
using Entidades.Maestros;
using Entidades.Contabilidad;
using Entidades.Ventas;
using Entidades.Generales;
using Entidades.Almacen;
using AccesoDatos.CtasPorCobrar;
using AccesoDatos.Tesoreria;
using AccesoDatos.Contabilidad;
using AccesoDatos.Maestros;
using AccesoDatos.Ventas;
using AccesoDatos.Generales;
using AccesoDatos.Almacen;
using Negocio.Contabilidad;
using Infraestructura;
using Infraestructura.Enumerados;
using Infraestructura.Extensores;

namespace Negocio.CtasPorCobrar
{
    public class CobranzasLN
    {

        public CobranzasE GrabarCobranzas(CobranzasE oCobranza, EnumOpcionGrabar Opcion)
        {
            try
            {
                using (TransactionScope oTrans = new TransactionScope())
                {
                    switch (Opcion)
                    {
                        case EnumOpcionGrabar.Insertar:

                            oCobranza.codPlanilla = new CobranzasAD().GenerarCodPlanilla(oCobranza.idEmpresa, oCobranza.idLocal, oCobranza.TipoPlanilla, oCobranza.Fecha.ToString("yyyy"));
                            oCobranza = new CobranzasAD().InsertarCobranzas(oCobranza);

                            if (oCobranza.oListaCobranzas != null)
                            {
                                CobranzasItemE oDetalle = null;

                                foreach (CobranzasItemE item in oCobranza.oListaCobranzas)
                                {
                                    item.idPlanilla = oCobranza.idPlanilla;
                                    oDetalle = new CobranzasItemAD().InsertarCobranzasItem(item);

                                    if (item.oListaCobranzasItemDet != null)
                                    {
                                        foreach (CobranzasItemDetE item2 in item.oListaCobranzasItemDet)
                                        {
                                            item2.idPlanilla = oCobranza.idPlanilla;
                                            item2.Recibo = oDetalle.Recibo;
                                            new CobranzasItemDetAD().InsertarCobranzasItemDet(item2);
                                        }
                                    }
                                }
                            }

                            break;
                        case EnumOpcionGrabar.Actualizar:

                            //Actualizar la cabecera...
                            oCobranza = new CobranzasAD().ActualizarCobranzas(oCobranza);

                            //Actualizando o inserta el detalle según la opción
                            if (oCobranza.oListaCobranzas != null)
                            {
                                //Eliminando los items que se encuentran en la lista
                                if (oCobranza.oListaItemsEliminados != null)
                                {
                                    foreach (CobranzasItemE item in oCobranza.oListaItemsEliminados)
                                    {
                                        //Primero eliminar el detalle del item
                                        if (item.oListaCobranzasItemDet != null)
                                        {
                                            foreach (CobranzasItemDetE itemDet in item.oListaCobranzasItemDet)
                                            {
                                                new CobranzasItemDetAD().EliminarCobranzasItemDet(itemDet.idPlanilla, itemDet.Recibo, itemDet.item);
                                            }
                                        }

                                        new CobranzasItemAD().EliminarCobranzasItem(item.Recibo);
                                    }
                                }

                                foreach (CobranzasItemE item in oCobranza.oListaCobranzas)
                                {
                                    if (item.oListaDetalleEliminado != null)
                                    {
                                        foreach (CobranzasItemDetE itemDet in item.oListaDetalleEliminado)
                                        {
                                            new CobranzasItemDetAD().EliminarCobranzasItemDet(itemDet.idPlanilla, itemDet.Recibo, itemDet.item);
                                        }
                                    }

                                    switch (item.Opcion)
                                    {
                                        case (Int32)EnumOpcionGrabar.Insertar:

                                            item.idPlanilla = oCobranza.idPlanilla;
                                            new CobranzasItemAD().InsertarCobranzasItem(item);

                                            if (item.oListaCobranzasItemDet != null)
                                            {
                                                foreach (CobranzasItemDetE item2 in item.oListaCobranzasItemDet)
                                                {
                                                    switch (item2.Opcion)
                                                    {
                                                        case (Int32)EnumOpcionGrabar.Insertar:
                                                            item2.idPlanilla = item.idPlanilla;
                                                            item2.Recibo = item.Recibo;
                                                            new CobranzasItemDetAD().InsertarCobranzasItemDet(item2);

                                                            break;
                                                        case (Int32)EnumOpcionGrabar.Actualizar:
                                                            new CobranzasItemDetAD().ActualizarCobranzasItemDet(item2);

                                                            break;
                                                        default:
                                                            break;
                                                    }
                                                }
                                            }

                                            break;
                                        case (Int32)EnumOpcionGrabar.Actualizar:

                                            item.Fecha = oCobranza.Fecha;
                                            new CobranzasItemAD().ActualizarCobranzasItem(item);

                                            if (item.oListaCobranzasItemDet != null)
                                            {
                                                foreach (CobranzasItemDetE itemDet in item.oListaCobranzasItemDet)
                                                {
                                                    switch (itemDet.Opcion)
                                                    {
                                                        case (Int32)EnumOpcionGrabar.Insertar:
                                                            itemDet.idPlanilla = item.idPlanilla;
                                                            itemDet.Recibo = item.Recibo;

                                                            new CobranzasItemDetAD().InsertarCobranzasItemDet(itemDet);

                                                            break;

                                                        case (Int32)EnumOpcionGrabar.Actualizar:
                                                            new CobranzasItemDetAD().ActualizarCobranzasItemDet(itemDet);

                                                            break;
                                                    }
                                                }
                                            }

                                            break;
                                        default:
                                            break;
                                    }
                                }
                            }

                            break;
                        default:
                            break;
                    }

                    oTrans.Complete();
                }

                return oCobranza;
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

        public CobranzasE InsertarCobranzas(CobranzasE cobranzas)
        {
            try
            {
                return new CobranzasAD().InsertarCobranzas(cobranzas);
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

        public CobranzasE ActualizarCobranzas(CobranzasE cobranzas)
        {
            try
            {
                return new CobranzasAD().ActualizarCobranzas(cobranzas);
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

        public int EliminarCobranzas(CobranzasE cobranzas)
        {
            try
            {
                Int32 resp = new VoucherAD().EliminarVoucher(cobranzas.idEmpresa, cobranzas.idLocal, cobranzas.AnioPeriodo, cobranzas.MesPeriodo, cobranzas.numVoucher, cobranzas.idComprobante, cobranzas.numFile);

                return new CobranzasAD().EliminarCobranzas(cobranzas.idPlanilla);
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

        public List<CobranzasE> ListarCobranzas(Int32 idEmpresa, Int32 idLocal, Int32 TipoPlanilla, DateTime fecIni, DateTime fecFin)
        {
            try
            {
                List<CobranzasE> oListaDevuelta = new CobranzasAD().ListarCobranzas(idEmpresa, idLocal, TipoPlanilla, fecIni, fecFin);
                return oListaDevuelta;
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

        public CobranzasE ObtenerCobranzas(Int32 idPlanilla, String ConDetalle = "S")
        {
            try
            {
                CobranzasE CobranzaRetorno = new CobranzasAD().ObtenerCobranzas(idPlanilla);

                if (ConDetalle == "S")
                {
                    CobranzaRetorno.oListaCobranzas = new CobranzasItemAD().ListarCobranzasItem(idPlanilla, CobranzaRetorno.idEmpresa);
                }

                return CobranzaRetorno;
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

        public String CerrarPlanillas(Int32 idPlanilla, Int32 idEmpresa, Int32 idLocal, String numVerPlanCuentas, String Usuario, String TipoPlanilla)
        {
            try
            {
                CobranzasE oCobranza = ObtenerCobranzas(idPlanilla);
                String Voucher = String.Empty;

                using (TransactionScope oTrans = new TransactionScope())
                {
                    foreach (CobranzasItemE item in oCobranza.oListaCobranzas)
                    {
                        item.oListaCobranzasItemDet = new CobranzasItemDetAD().ListarCobranzasItemDet(item.idPlanilla, item.Recibo);
                    }

                    if (TipoPlanilla != "PLACOMP")
                    {
                        if (TipoPlanilla == "PLALDES" || TipoPlanilla == "PLACALET")
                        {
                            Voucher = GenerarAsientoCobranzaLetrasDscto(oCobranza, Usuario, TipoPlanilla);
                        }
                        else
                        {
                            Voucher = new CobranzasAD().GenerarVenAsientoPlanillas(idPlanilla, idEmpresa, idLocal, numVerPlanCuentas, Usuario);
                        }
                    }
                    else
                    {
                        Voucher = new CobranzasAD().GenerarAsientoPlanillaCompensacion(idPlanilla, idEmpresa, idLocal, numVerPlanCuentas, Usuario);
                    }

                    #region Cuenta Corriente
                    
                    //Detalle de la cobranza
                    if (oCobranza.oListaCobranzas != null)
                    {
                        Int32 idCtaCteItem = 0;
                        Int32 idCtaCte4546 = 0;
                        Int32 idCtaCteItem4546 = 0;
                        List<LetrasEstadoLibroFileE> ListaEstados = new LetrasEstadoLibroFileAD().ListarLetrasEstadoLibroFile(idEmpresa);

                        if (ListaEstados == null)
                        {
                            throw new Exception("No existe ningún Estado de Letra en el sistema");
                        }

                        //Recorriendo el detalle
                        foreach (CobranzasItemE item in oCobranza.oListaCobranzas)
                        {
                            //Items del Detalle de Cobranza. Obteniendo los documentos
                            //Verificando si hay registros
                            if (item.oListaCobranzasItemDet.Count > 0)
                            {
                                CtaCte_DetE oCtaCteDet = null;
                                CtaCteE oCtaCteCabecera = null;

                                if (TipoPlanilla != "PLAANC")//Diferente de Aplicación de Anticipo
                                {
                                    //Recorriendo los items obtenidos
                                    foreach (CobranzasItemDetE itemDet in item.oListaCobranzasItemDet)
                                    {
                                        List<CtaCte_DetE> ListaCtaCteItem = null;

                                        if (!itemDet.indTercero)
                                        {
                                            if (itemDet.idDocumento == "LT" && TipoPlanilla == "PLALDES")//ABONO LETRAS EN DSCTO O ENDOSADA
                                            {
                                                CtaCteE oCtaCte4546Existe = new CtaCteAD().ObtenerCtaCtePorDocumentoPorCuenta(idEmpresa, itemDet.idPersona, itemDet.idDocumento, itemDet.numSerie, itemDet.numDocumento, itemDet.codCuenta);

                                                if (oCtaCte4546Existe == null)
                                                {
                                                    oCtaCteCabecera = new CtaCteAD().ObtenerMaeCtaCtePorId(itemDet.idCtaCte.Value);
                                                    ListaCtaCteItem = new CtaCte_DetAD().ListarMaeCtaCteDet(oCtaCteCabecera.idEmpresa, oCtaCteCabecera.idCtaCte);

                                                    CtaCte_DetE CtaCteItem = ListaCtaCteItem.Find
                                                    (
                                                        delegate (CtaCte_DetE cc) { return cc.TipAccion == "C"; }
                                                    );

                                                    if (CtaCteItem == null)
                                                    {
                                                        throw new Exception(String.Format("No existe ningún Cargo con el documento {0}-{1}", itemDet.idDocumento, itemDet.numDocumento));
                                                    }

                                                    //idCtaCteItem de la cuenta Origen 12
                                                    idCtaCteItem = CtaCteItem.idCtaCteItem;

                                                    #region Cabecera de la CtaCte

                                                    //Actualizando a la nueva cuenta
                                                    oCtaCteCabecera.codCuenta = itemDet.codCuenta;
                                                    oCtaCteCabecera.FechaOperacion = item.Fecha;
                                                    oCtaCteCabecera.idSistema = 7; //Cobranzas
                                                    //Insertando la cabecera
                                                    oCtaCteCabecera = new CtaCteAD().InsertarMaeCtaCte(oCtaCteCabecera);
                                                    //Obteniendo el id generado
                                                    idCtaCte4546 = oCtaCteCabecera.idCtaCte;

                                                    #endregion

                                                    #region Abono de la CtaCte

                                                    //Actualizando la nueva cuenta en el detalle
                                                    CtaCteItem.codCuenta = itemDet.codCuenta;
                                                    //Actualizando el nuevo id de la cabecera en el detalle
                                                    CtaCteItem.idCtaCte = oCtaCteCabecera.idCtaCte;
                                                    //Insertando el detalle Cargo
                                                    //CtaCteItem = new CtaCte_DetAD().InsertarMaeCtaCteDet(CtaCteItem);
                                                    //Insertando el detalle Abono
                                                    CtaCteItem.MontoMov = itemDet.MontoReci;
                                                    CtaCteItem.TipAccion = "A";
                                                    CtaCteItem = new CtaCte_DetAD().InsertarMaeCtaCteDet(CtaCteItem);

                                                    //Obteniendo el nuevo id del detalle del abono
                                                    idCtaCteItem4546 = CtaCteItem.idCtaCteItem;

                                                    #endregion

                                                    #region Actualizando los campos Cta.Cte.

                                                    itemDet.idCtaCteItem = idCtaCteItem;
                                                    itemDet.idCtaCte45 = idCtaCte4546;
                                                    itemDet.idCtaCteItem45 = idCtaCteItem4546; //idCtaCteItem del Abono
                                                    itemDet.UsuarioModificacion = Usuario;

                                                    new CobranzasItemDetAD().ActualizarCobranzasItemDetCtaCte(itemDet);

                                                    #endregion
                                                }
                                                else
                                                {
                                                    ListaCtaCteItem = new CtaCte_DetAD().ListarMaeCtaCteDet(idEmpresa, itemDet.idCtaCte.Value);

                                                    CtaCte_DetE CtaCteItem = ListaCtaCteItem.Find
                                                    (
                                                        delegate (CtaCte_DetE cc) { return cc.TipAccion == "C"; }
                                                    );

                                                    //idCtaCteItem de la cuenta Origen 12
                                                    idCtaCteItem = CtaCteItem.idCtaCteItem;

                                                    //idCtaCte de la cuenta 45
                                                    idCtaCte4546 = oCtaCte4546Existe.idCtaCte;

                                                    //Insertando el detalle Abono
                                                    CtaCteItem.MontoMov = itemDet.MontoReci;
                                                    CtaCteItem.TipAccion = "A";
                                                    //Actualizando la nueva cuenta en el detalle
                                                    CtaCteItem.codCuenta = itemDet.codCuenta;
                                                    CtaCteItem.idCtaCte = oCtaCte4546Existe.idCtaCte;

                                                    CtaCteItem = new CtaCte_DetAD().InsertarMaeCtaCteDet(CtaCteItem);

                                                    //Obteniendo el nuevo id del detalle del abono
                                                    idCtaCteItem4546 = CtaCteItem.idCtaCteItem;

                                                    #region Actualizando los campos Cta.Cte.

                                                    itemDet.idCtaCteItem = idCtaCteItem;
                                                    itemDet.idCtaCte45 = idCtaCte4546;
                                                    itemDet.idCtaCteItem45 = idCtaCteItem4546; //idCtaCteItem del abono en la 45
                                                    itemDet.UsuarioModificacion = Usuario;

                                                    new CobranzasItemDetAD().ActualizarCobranzasItemDetCtaCte(itemDet);

                                                    #endregion
                                                }
                                            }
                                            else if (itemDet.idDocumento == "LT" && TipoPlanilla == "PLACALET")//CANC. LETRAS EN DSCTO O ENDOSADA
                                            {
                                                if (item.TipoCobro != "LDE")//Diferente al Tipo de Cobro 9.7 CANCE. LETRA EN DSCTO ENDOSO S/PAGO
                                                {
                                                    String Cuenta = String.Empty;
                                                    ListaCtaCteItem = new CtaCte_DetAD().ListarMaeCtaCteDet(idEmpresa, itemDet.idCtaCte.Value);

                                                    CtaCte_DetE CtaCteItem = ListaCtaCteItem.Find
                                                    (
                                                        delegate (CtaCte_DetE cc) { return cc.TipAccion == "C"; }
                                                    );

                                                    if (CtaCteItem == null)
                                                    {
                                                        throw new Exception(String.Format("No existe ningún Cargo con el documento {0}-{1}", itemDet.idDocumento, itemDet.numDocumento));
                                                    }

                                                    CtaCteItem.MontoMov = itemDet.Monto;
                                                    CtaCteItem.TipAccion = "A";
                                                    CtaCteItem.idDocumentoMov = !itemDet.indEndosar ? item.idDocumento : itemDet.idDocumento; //Tomando los datos del item para la cancelación del documento si en caso indEndosar es falso
                                                    CtaCteItem.SerieMov = !itemDet.indEndosar ? item.numSerie : itemDet.numSerie; //Tomando los datos del item para la cancelación del documento si en caso indEndosar es falso
                                                    CtaCteItem.NumeroMov = !itemDet.indEndosar ? item.numCheque : itemDet.numDocumento; //Tomando los datos del item para la cancelación del documento si en caso indEndosar es falso
                                                    CtaCteItem.FechaMovimiento = item.fecCobranza.Value; //Tomando los datos del item para la cancelación del documento si en caso indEndosar es falso
                                                    CtaCteItem = new CtaCte_DetAD().InsertarMaeCtaCteDet(CtaCteItem);
                                                    //idCtaCteItem de la cuenta 12
                                                    idCtaCteItem = CtaCteItem.idCtaCteItem;

                                                    #region Verificando Saldo de la CtaCte. 123

                                                    List<CtaCte_DetE> oListaCtaSaldos = new CtaCte_DetAD().ListarMaeCtaCteDet(idEmpresa, itemDet.idCtaCte.Value);
                                                    Decimal Saldo = 0;

                                                    foreach (CtaCte_DetE itemCtaCte in oListaCtaSaldos)
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

                                                    // Si el saldo es 0 se Cancela y se coloca la fecha de cancelacion en la cta.cte.
                                                    if (Saldo == 0 || Saldo == 0M)
                                                    {
                                                        new CtaCteAD().ActualizarFecCancelacionCtaCte(idEmpresa, itemDet.idCtaCte.Value, item.Fecha, Usuario);
                                                    }

                                                    #endregion

                                                    #region Verificando si hay 45-46

                                                    LetrasEstadoLibroFileE EstadoCuentaEqui = ListaEstados.Find
                                                    (
                                                        delegate (LetrasEstadoLibroFileE l) { return l.CuentaSoles == CtaCteItem.codCuenta; }
                                                    );

                                                    if (EstadoCuentaEqui == null)
                                                    {
                                                        EstadoCuentaEqui = ListaEstados.Find
                                                        (
                                                            delegate (LetrasEstadoLibroFileE l) { return l.CuentaDolares == CtaCteItem.codCuenta; }
                                                        );
                                                    }

                                                    if (EstadoCuentaEqui != null && EstadoCuentaEqui.Estado == "D")
                                                    {
                                                        if (CtaCteItem.idMoneda == "01")
                                                        {
                                                            Cuenta = itemDet.indEndosar ? EstadoCuentaEqui.ctaSolesEndosada : EstadoCuentaEqui.ctaSolesDscto;
                                                        }
                                                        else
                                                        {
                                                            Cuenta = itemDet.indEndosar ? EstadoCuentaEqui.ctaDolaresEndosada : EstadoCuentaEqui.ctaDolaresDscto;
                                                        }

                                                        if (String.IsNullOrWhiteSpace(Cuenta))
                                                        {
                                                            throw new Exception(String.Format("No existe cuenta equivalente para la cuenta {0} en el Maestro de Estado de Letras", CtaCteItem.codCuenta));
                                                        }

                                                        CtaCteE oCtaCte45 = new CtaCteAD().ObtenerCtaCtePorDocumentoPorCuenta(idEmpresa, itemDet.idPersona, itemDet.idDocumento, itemDet.numSerie, itemDet.numDocumento, Cuenta);

                                                        if (oCtaCte45 != null)
                                                        {
                                                            idCtaCte4546 = oCtaCte45.idCtaCte;
                                                            //Cargo de la 45
                                                            CtaCteItem.idCtaCte = idCtaCte4546;
                                                            CtaCteItem.TipAccion = "C";
                                                            CtaCteItem.codCuenta = Cuenta;
                                                            CtaCteItem = new CtaCte_DetAD().InsertarMaeCtaCteDet(CtaCteItem);
                                                            idCtaCteItem4546 = CtaCteItem.idCtaCteItem;

                                                            #region Verificando Saldo de la CtaCte. 45

                                                            oListaCtaSaldos = new CtaCte_DetAD().ListarMaeCtaCteDet(idEmpresa, idCtaCte4546);
                                                            Saldo = 0;

                                                            foreach (CtaCte_DetE itemCtaCte in oListaCtaSaldos)
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

                                                            // Si el saldo es 0 se Cancela y se coloca la fecha de cancelacion en la cta.cte.
                                                            if (Saldo == 0 || Saldo == 0M)
                                                            {
                                                                new CtaCteAD().ActualizarFecCancelacionCtaCte(idEmpresa, idCtaCte4546, item.Fecha, Usuario);
                                                            }

                                                            #endregion

                                                            #region Actualizando los campos Cta.Cte.

                                                            itemDet.idCtaCteItem = idCtaCteItem;
                                                            itemDet.idCtaCte45 = idCtaCte4546;
                                                            itemDet.idCtaCteItem45 = idCtaCteItem4546; //idCtaCteItem del abono en la 45
                                                            itemDet.UsuarioModificacion = Usuario;

                                                            new CobranzasItemDetAD().ActualizarCobranzasItemDetCtaCte(itemDet);

                                                            #endregion
                                                        }
                                                    }

                                                    #endregion
                                                }
                                                else
                                                {
                                                    Int32 idCtaCte16 = 0;
                                                    Int32 idCtaCteItem16 = 0;
                                                    oCtaCteCabecera = new CtaCteAD().ObtenerMaeCtaCtePorId(itemDet.idCtaCte.Value);

                                                    if (oCtaCteCabecera != null)
                                                    {
                                                        #region Cuenta 123

                                                        #region Detalle

                                                        oCtaCteDet = new CtaCte_DetE
                                                        {
                                                            idEmpresa = idEmpresa,
                                                            idCtaCte = oCtaCteCabecera.idCtaCte,
                                                            idDocumentoMov = item.idDocumento.Trim(),
                                                            SerieMov = item.numSerie.Trim(),
                                                            NumeroMov = item.numCheque.Trim(),
                                                            FechaMovimiento = Convert.ToDateTime(item.Fecha),
                                                            idMoneda = itemDet.idMoneda,
                                                            MontoMov = Convert.ToDecimal(itemDet.Monto),
                                                            TipoCambio = Convert.ToDecimal(oCtaCteCabecera.TipoCambio),
                                                            TipAccion = EnumEstadoDocumentos.A.ToString(),
                                                            numVerPlanCuentas = oCtaCteCabecera.numVerPlanCuentas,
                                                            codCuenta = oCtaCteCabecera.codCuenta,
                                                            EsDetraccion = (TipoPlanilla == "PLADETR" ? true : false),
                                                            UsuarioRegistro = Usuario
                                                        };

                                                        oCtaCteDet = new CtaCte_DetAD().InsertarMaeCtaCteDet(oCtaCteDet);
                                                        idCtaCteItem = oCtaCteDet.idCtaCteItem;

                                                        #endregion

                                                        #region Verificando Saldo de la CtaCte.

                                                        List<CtaCte_DetE> oListaCtaCteDet = new CtaCte_DetAD().ListarMaeCtaCteDet(oCtaCteCabecera.idEmpresa, oCtaCteCabecera.idCtaCte);
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

                                                        // Si el saldo es 0 se Cancela y se coloca la fecha de cancelacion en la cta.cte.
                                                        if (Saldo == 0 || Saldo == 0M)
                                                        {
                                                            new CtaCteAD().ActualizarFecCancelacionCtaCte(oCtaCteCabecera.idEmpresa, oCtaCteCabecera.idCtaCte, item.Fecha, Usuario);
                                                        }

                                                        #endregion

                                                        #endregion

                                                        #region Nueva Cuenta 16

                                                        #region Cabecera de la CtaCte

                                                        //Actualizando a la nueva cuenta
                                                        oCtaCteCabecera.codCuenta = item.codCuenta;
                                                        oCtaCteCabecera.FechaOperacion = item.Fecha;
                                                        oCtaCteCabecera.idSistema = 7; //Cobranzas
                                                        //Insertando la cabecera
                                                        oCtaCteCabecera = new CtaCteAD().InsertarMaeCtaCte(oCtaCteCabecera);
                                                        //Obteniendo el id generado
                                                        idCtaCte16 = oCtaCteCabecera.idCtaCte;

                                                        #endregion

                                                        #region Detalle de la CtaCte

                                                        //Actualizando a la nueva cuenta y el idCtaCte de la 16
                                                        oCtaCteDet.idCtaCte = idCtaCte16;
                                                        oCtaCteDet.codCuenta = item.codCuenta;
                                                        oCtaCteDet.TipAccion = "C"; //Cargo
                                                                                    //Insertando el detalle
                                                        oCtaCteDet = new CtaCte_DetAD().InsertarMaeCtaCteDet(oCtaCteDet);
                                                        //Obteniendo el idItem generado
                                                        idCtaCteItem16 = oCtaCteDet.idCtaCteItem;

                                                        #endregion

                                                        #endregion

                                                        #region Actualizando los campos Cta.Cte.

                                                        itemDet.idCtaCteItem = idCtaCteItem;
                                                        itemDet.idCtaCte45 = idCtaCte16;
                                                        itemDet.idCtaCteItem45 = idCtaCteItem16;
                                                        itemDet.UsuarioModificacion = Usuario;

                                                        new CobranzasItemDetAD().ActualizarCobranzasItemDetCtaCte(itemDet);

                                                        #endregion
                                                    }
                                                }
                                            }
                                            else
                                            {
                                                oCtaCteCabecera = new CtaCteAD().ObtenerMaeCtaCtePorId(itemDet.idCtaCte.Value);

                                                if (oCtaCteCabecera != null)
                                                {
                                                    #region Detalle

                                                    oCtaCteDet = new CtaCte_DetE
                                                    {
                                                        idEmpresa = idEmpresa,
                                                        idCtaCte = oCtaCteCabecera.idCtaCte,
                                                        idDocumentoMov = item.idDocumento.Trim(),
                                                        SerieMov = item.numSerie.Trim(),
                                                        NumeroMov = item.numCheque.Trim(),
                                                        FechaMovimiento = Convert.ToDateTime(item.Fecha),
                                                        idMoneda = itemDet.idMoneda,
                                                        MontoMov = Convert.ToDecimal(itemDet.Monto),
                                                        TipoCambio = Convert.ToDecimal(oCtaCteCabecera.TipoCambio),
                                                        TipAccion = EnumEstadoDocumentos.A.ToString(),
                                                        numVerPlanCuentas = oCtaCteCabecera.numVerPlanCuentas,
                                                        codCuenta = oCtaCteCabecera.codCuenta,
                                                        EsDetraccion = (TipoPlanilla == "PLADETR" ? true : false),
                                                        UsuarioRegistro = Usuario
                                                    };

                                                    oCtaCteDet = new CtaCte_DetAD().InsertarMaeCtaCteDet(oCtaCteDet);
                                                    idCtaCteItem = oCtaCteDet.idCtaCteItem;

                                                    #endregion

                                                    #region Verificando Saldo de la CtaCte.

                                                    List<CtaCte_DetE> oListaCtaCteDet = new CtaCte_DetAD().ListarMaeCtaCteDet(oCtaCteCabecera.idEmpresa, oCtaCteCabecera.idCtaCte);
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

                                                    // Si el saldo es 0 se Cancela y se coloca la fecha de cancelacion en la cta.cte.
                                                    if (Saldo == 0 || Saldo == 0M)
                                                    {
                                                        new CtaCteAD().ActualizarFecCancelacionCtaCte(oCtaCteCabecera.idEmpresa, oCtaCteCabecera.idCtaCte, item.Fecha, Usuario);
                                                    }

                                                    #endregion

                                                    #region Actualizando los campos Cta.Cte.

                                                    itemDet.idCtaCteItem = idCtaCteItem;
                                                    itemDet.idCtaCte45 = null;
                                                    itemDet.idCtaCteItem45 = null;
                                                    itemDet.UsuarioModificacion = Usuario;

                                                    new CobranzasItemDetAD().ActualizarCobranzasItemDetCtaCte(itemDet);

                                                    #endregion
                                                }
                                            } 
                                        }
                                        else
                                        {
                                            if (itemDet.idDocumento == "LT" && TipoPlanilla == "PLALDES")//ABONO LETRAS EN DSCTO O ENDOSADA
                                            {
                                                #region Nueva Cta.Cte.

                                                #region Cabecera

                                                oCtaCteCabecera = new CtaCteE
                                                {
                                                    idEmpresa = idEmpresa,
                                                    idPersona = itemDet.idPersona,
                                                    idDocumento = itemDet.idDocumento,
                                                    numSerie = itemDet.numSerie.Trim(),
                                                    numDocumento = itemDet.numDocumento.Trim(),
                                                    idMoneda = itemDet.idMoneda,
                                                    MontoOrig = itemDet.Monto.Value,
                                                    TipoCambio = itemDet.tipCambioReci.Value,
                                                    FechaDocumento = Convert.ToDateTime(itemDet.fecEmision),
                                                    FechaVencimiento = Convert.ToDateTime(itemDet.fecVencimiento),
                                                    FechaCancelacion = Convert.ToDateTime("31-12-2100"),
                                                    numVerPlanCuentas = itemDet.numVerPlanCuentas,
                                                    codCuenta = itemDet.codCuenta,
                                                    AnnoVencimiento = String.Empty,
                                                    MesVencimiento = String.Empty,
                                                    SemanaVencimiento = String.Empty,
                                                    tipPartidaPresu = String.Empty,
                                                    codPartidaPresu = String.Empty,
                                                    desGlosa = oCobranza.Observaciones.Trim(),
                                                    FechaOperacion = oCobranza.Fecha,
                                                    EsDetraCab = false,
                                                    idCtaCteOrigen = 0,
                                                    idSistema = 7, //Cobranzas
                                                    UsuarioRegistro = Usuario
                                                };

                                                new CtaCteAD().InsertarMaeCtaCte(oCtaCteCabecera);

                                                //Obteniendo el id de la ctacte...
                                                idCtaCte4546 = oCtaCteCabecera.idCtaCte;

                                                #endregion

                                                #region Detalle

                                                oCtaCteDet = new CtaCte_DetE
                                                {
                                                    idEmpresa = idEmpresa,
                                                    idCtaCte = idCtaCte4546,
                                                    idDocumentoMov = itemDet.idDocumento,
                                                    SerieMov = itemDet.numSerie.Trim(),
                                                    NumeroMov = itemDet.numDocumento.Trim(),
                                                    FechaMovimiento = item.Fecha,
                                                    idMoneda = itemDet.idMoneda,
                                                    MontoMov = itemDet.Monto.Value,
                                                    TipoCambio = itemDet.tipCambioReci.Value,
                                                    TipAccion = EnumEstadoDocumentos.C.ToString(),
                                                    numVerPlanCuentas = itemDet.numVerPlanCuentas,
                                                    codCuenta = itemDet.codCuenta,
                                                    desGlosa = oCobranza.Observaciones,
                                                    EsDetraccion = false,
                                                    UsuarioRegistro = Usuario
                                                };

                                                new CtaCte_DetAD().InsertarMaeCtaCteDet(oCtaCteDet);

                                                //Obteniendo el id de la Item de la CtaCte Detalle...
                                                idCtaCteItem4546 = oCtaCteDet.idCtaCteItem;

                                                #endregion

                                                #region Actualizando los campos Cta.Cte.

                                                itemDet.idCtaCteItem = null;
                                                itemDet.idCtaCte45 = idCtaCte4546;
                                                itemDet.idCtaCteItem45 = idCtaCteItem4546;
                                                itemDet.UsuarioModificacion = Usuario;

                                                new CobranzasItemDetAD().ActualizarCobranzasItemDetCtaCte(itemDet);

                                                #endregion

                                                #endregion
                                            }
                                            else if (itemDet.idDocumento == "LT" && TipoPlanilla == "PLACALET")//CANC. LETRAS EN DSCTO O ENDOSADA
                                            {
                                                Int32 idCtaCte16 = 0;
                                                Int32 idCtaCteItem16 = 0;
                                                oCtaCteCabecera = new CtaCteAD().ObtenerMaeCtaCtePorId(itemDet.idCtaCte.Value);

                                                if (oCtaCteCabecera != null)
                                                {
                                                    #region Cuenta 45

                                                    #region Detalle

                                                    oCtaCteDet = new CtaCte_DetE
                                                    {
                                                        idEmpresa = idEmpresa,
                                                        idCtaCte = oCtaCteCabecera.idCtaCte,
                                                        idDocumentoMov = item.idDocumento.Trim(),
                                                        SerieMov = item.numSerie.Trim(),
                                                        NumeroMov = item.numCheque.Trim(),
                                                        FechaMovimiento = Convert.ToDateTime(item.Fecha),
                                                        idMoneda = itemDet.idMoneda,
                                                        MontoMov = Convert.ToDecimal(itemDet.Monto),
                                                        TipoCambio = Convert.ToDecimal(oCtaCteCabecera.TipoCambio),
                                                        TipAccion = EnumEstadoDocumentos.A.ToString(),
                                                        numVerPlanCuentas = oCtaCteCabecera.numVerPlanCuentas,
                                                        codCuenta = oCtaCteCabecera.codCuenta,
                                                        EsDetraccion = false,
                                                        UsuarioRegistro = Usuario
                                                    };

                                                    oCtaCteDet = new CtaCte_DetAD().InsertarMaeCtaCteDet(oCtaCteDet);
                                                    idCtaCteItem = oCtaCteDet.idCtaCteItem;

                                                    #endregion

                                                    #region Verificando Saldo de la CtaCte.

                                                    List<CtaCte_DetE> oListaCtaCteDet = new CtaCte_DetAD().ListarMaeCtaCteDet(oCtaCteCabecera.idEmpresa, oCtaCteCabecera.idCtaCte);
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

                                                    // Si el saldo es 0 se Cancela y se coloca la fecha de cancelacion en la cta.cte.
                                                    if (Saldo == 0 || Saldo == 0M)
                                                    {
                                                        new CtaCteAD().ActualizarFecCancelacionCtaCte(oCtaCteCabecera.idEmpresa, oCtaCteCabecera.idCtaCte, item.Fecha, Usuario);
                                                    }

                                                    #endregion

                                                    #endregion

                                                    #region Nueva Cuenta 16

                                                    #region Cabecera de la CtaCte

                                                    //Actualizando a la nueva cuenta
                                                    oCtaCteCabecera.codCuenta = item.codCuenta;
                                                    oCtaCteCabecera.FechaOperacion = item.Fecha;
                                                    oCtaCteCabecera.idSistema = 7; //Cobranzas
                                                    //Insertando la cabecera
                                                    oCtaCteCabecera = new CtaCteAD().InsertarMaeCtaCte(oCtaCteCabecera);
                                                    //Obteniendo el id generado
                                                    idCtaCte16 = oCtaCteCabecera.idCtaCte;

                                                    #endregion

                                                    #region Detalle de la CtaCte

                                                    //Actualizando a la nueva cuenta y el idCtaCte de la 16
                                                    oCtaCteDet.idCtaCte = idCtaCte16;
                                                    oCtaCteDet.codCuenta = item.codCuenta;
                                                    oCtaCteDet.TipAccion = "C"; //Cargo
                                                                                //Insertando el detalle
                                                    oCtaCteDet = new CtaCte_DetAD().InsertarMaeCtaCteDet(oCtaCteDet);
                                                    //Obteniendo el idItem generado
                                                    idCtaCteItem16 = oCtaCteDet.idCtaCteItem;

                                                    #endregion

                                                    #endregion

                                                    #region Actualizando los campos Cta.Cte.

                                                    itemDet.idCtaCteItem = idCtaCteItem;
                                                    itemDet.idCtaCte45 = idCtaCte16;
                                                    itemDet.idCtaCteItem45 = idCtaCteItem16;
                                                    itemDet.UsuarioModificacion = Usuario;

                                                    new CobranzasItemDetAD().ActualizarCobranzasItemDetCtaCte(itemDet);

                                                    #endregion
                                                }
                                            }
                                        }
                                    }
                                }
                                else
                                {
                                    CobranzasItemDetE DocumentosVentas = (from x in item.oListaCobranzasItemDet where x.idDocumento != "NC" select x).SingleOrDefault();
                                    List<CobranzasItemDetE> NotasCredito = new List<CobranzasItemDetE>((from x in item.oListaCobranzasItemDet where x.idDocumento == "NC" select x).ToList());
                                    List<CtaCte_DetE> oListaCtaCteDet = null;
                                    Decimal Saldo = 0;

                                    //Recorriendo las notas de crédito para cancelar
                                    foreach (CobranzasItemDetE itemDet in NotasCredito)
                                    {
                                        #region Detalle

                                        oCtaCteDet = new CtaCte_DetE
                                        {
                                            idEmpresa = idEmpresa,
                                            idCtaCte = itemDet.idCtaCte.Value,
                                            idDocumentoMov = itemDet.idDocumento,
                                            SerieMov = itemDet.numSerie,
                                            NumeroMov = itemDet.numDocumento,
                                            FechaMovimiento = Convert.ToDateTime(item.Fecha),
                                            idMoneda = itemDet.idMoneda,
                                            MontoMov = Convert.ToDecimal(itemDet.Monto),
                                            TipoCambio = Convert.ToDecimal(itemDet.tipCambioReci),
                                            TipAccion = EnumEstadoDocumentos.A.ToString(),
                                            numVerPlanCuentas = itemDet.numVerPlanCuentas,
                                            codCuenta = itemDet.codCuenta,
                                            EsDetraccion = (TipoPlanilla == "PLADETR" ? true : false),
                                            UsuarioRegistro = Usuario
                                        };

                                        oCtaCteDet = new CtaCte_DetAD().InsertarMaeCtaCteDet(oCtaCteDet);
                                        idCtaCteItem = oCtaCteDet.idCtaCteItem;

                                        #endregion

                                        #region Verificando Saldo de la CtaCte.

                                        oListaCtaCteDet = new CtaCte_DetAD().ListarMaeCtaCteDet(idEmpresa, itemDet.idCtaCte.Value);

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

                                        // Si el saldo es 0 se Cancela y se coloca la fecha de cancelacion en la cta.cte.
                                        if (Saldo == 0 || Saldo == 0M)
                                        {
                                            new CtaCteAD().ActualizarFecCancelacionCtaCte(idEmpresa, itemDet.idCtaCte.Value, item.Fecha, Usuario);
                                        }

                                        #endregion

                                        #region Actualizando los campos Cta.Cte.

                                        itemDet.idCtaCteItem = idCtaCteItem;
                                        itemDet.idCtaCte45 = null;
                                        itemDet.idCtaCteItem45 = null;
                                        itemDet.UsuarioModificacion = Usuario;

                                        new CobranzasItemDetAD().ActualizarCobranzasItemDetCtaCte(itemDet);

                                        #endregion
                                    }

                                    //Recorriendo las notas de crédito para cancelar los documentos de ventas(Factura, boletas, letras)
                                    foreach (CobranzasItemDetE itemDet in NotasCredito)
                                    {
                                        #region Detalle

                                        oCtaCteDet = new CtaCte_DetE
                                        {
                                            idEmpresa = idEmpresa,
                                            idCtaCte = DocumentosVentas.idCtaCte.Value,
                                            idDocumentoMov = itemDet.idDocumento,
                                            SerieMov = itemDet.numSerie,
                                            NumeroMov = itemDet.numDocumento,
                                            FechaMovimiento = Convert.ToDateTime(item.Fecha),
                                            idMoneda = itemDet.idMoneda,
                                            MontoMov = Convert.ToDecimal(itemDet.Monto),
                                            TipoCambio = Convert.ToDecimal(itemDet.tipCambioReci),
                                            TipAccion = EnumEstadoDocumentos.A.ToString(),
                                            numVerPlanCuentas = itemDet.numVerPlanCuentas,
                                            codCuenta = itemDet.codCuenta,
                                            EsDetraccion = (TipoPlanilla == "PLADETR" ? true : false),
                                            UsuarioRegistro = Usuario
                                        };

                                        oCtaCteDet = new CtaCte_DetAD().InsertarMaeCtaCteDet(oCtaCteDet);

                                        #endregion
                                    }

                                    #region Verificando Saldo de la CtaCte.

                                    oListaCtaCteDet = new CtaCte_DetAD().ListarMaeCtaCteDet(idEmpresa, DocumentosVentas.idCtaCte.Value);
                                    Saldo = 0;

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

                                    // Si el saldo es 0 se Cancela y se coloca la fecha de cancelacion en la cta.cte.
                                    if (Saldo == 0 || Saldo == 0M)
                                    {
                                        new CtaCteAD().ActualizarFecCancelacionCtaCte(idEmpresa, DocumentosVentas.idCtaCte.Value, item.Fecha, Usuario);
                                    }

                                    #endregion
                                }
                            }
                        }
                    } 

                    #endregion

                    oTrans.Complete();
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

        public int ActualizarEstadoCobranzas(Int32 idPlanilla, String numVoucher, Boolean EstadoDoc, String UsuarioModificacion)
        {
            try
            {
                return new CobranzasAD().ActualizarEstadoCobranzas(idPlanilla, numVoucher, EstadoDoc, UsuarioModificacion);
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

        public Int32 AbrirPlanilla(CobranzasE oCobranza, Boolean Estado, String Usuario, String TipoPlanilla)
        {
            try
            {
                Int32 resp = 0;

                using (TransactionScope oTrans = new TransactionScope())
                {
                    //Volviendo abrir la planilla
                    resp = new CobranzasAD().ActualizarEstadoCobranzas(oCobranza.idPlanilla, String.Empty, Estado, Usuario);
                    //Eliminando el voucher
                    new VoucherAD().EliminarVoucher(oCobranza.idEmpresa, oCobranza.idLocal, oCobranza.AnioPeriodo, oCobranza.MesPeriodo, oCobranza.numVoucher, oCobranza.idComprobante, oCobranza.numFile);
                    //Listando el detalle de la cobranza
                    List<CobranzasItemE> oListaItems = new CobranzasItemAD().ListarCobranzasItem(oCobranza.idPlanilla, oCobranza.idEmpresa);

                    if (oListaItems != null)
                    {
                        //Recorriendo el detalle
                        foreach (CobranzasItemE item in oListaItems)
                        {
                            //Obteniendo los items del detalle
                            List<CobranzasItemDetE> oListaDetalle = new CobranzasItemDetAD().ListarCobranzasItemDet(oCobranza.idPlanilla, item.Recibo);

                            if (oListaDetalle.Count > 0)
                            {
                                if (TipoPlanilla != "PLAANC")//Diferente de Aplicación de Anticipo
                                {
                                    foreach (CobranzasItemDetE itemDet in oListaDetalle)
                                    {
                                        if (!itemDet.indTercero)
                                        {
                                            if (itemDet.idDocumento == "LT" && TipoPlanilla == "PLALDES")//ABONO LETRAS EN DSCTO O ENDOSADA
                                            {
                                                //Eliminando el item del abono
                                                new CtaCte_DetAD().EliminarMaeCtaCteDetallePorIdItem(itemDet.idCtaCteItem45.Value);

                                                //Revisando la CtaCte. si existen abonos en las letras
                                                List<CtaCte_DetE> oListaAbonos = new CtaCte_DetAD().ListarMaeCtaCteDetAbonos(oCobranza.idEmpresa, itemDet.idCtaCte45.Value);

                                                if (oListaAbonos == null || oListaAbonos.Count == 0)
                                                {
                                                    //Eliminando de la Cta.Cte. de la Letra con cuenta 45... cabecera - detalle
                                                    new CtaCteAD().EliminarMaeCtaCteConDetalle(itemDet.idCtaCte45.Value);
                                                }

                                                #region Actualizando los campos Cta.Cte.

                                                itemDet.idCtaCteItem = null;
                                                itemDet.idCtaCte45 = null;
                                                itemDet.idCtaCteItem45 = null;
                                                itemDet.UsuarioModificacion = Usuario;

                                                new CobranzasItemDetAD().ActualizarCobranzasItemDetCtaCte(itemDet);

                                                #endregion
                                            }
                                            else if (itemDet.idDocumento == "LT" && TipoPlanilla == "PLACALET")//CANC. LETRAS EN DSCTO O ENDOSADA
                                            {
                                                //Eliminando el item del abono 12
                                                new CtaCte_DetAD().EliminarMaeCtaCteDetallePorIdItem(itemDet.idCtaCteItem.Value);

                                                #region Verificando Saldo de la CtaCte. de la 12

                                                List<CtaCte_DetE> oListaCtaCteDet = new CtaCte_DetAD().ListarMaeCtaCteDet(oCobranza.idEmpresa, itemDet.idCtaCte.Value);
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

                                                // Si el saldo es diferente de 0 vuelve a habilitar el documento en la cta.cte.
                                                if (Saldo != 0)
                                                {
                                                    new CtaCteAD().ActualizarFecCancelacionCtaCte(oCobranza.idEmpresa, itemDet.idCtaCte.Value, Convert.ToDateTime("31-12-2100"), Usuario);
                                                }

                                                #endregion

                                                #region Verificando por el tipo de cobro antes de elimnar

                                                if (item.TipoCobro != "LDE")//Diferente al Tipo de Cobro 9.7 CANCE. LETRA EN DSCTO ENDOSO S/PAGO
                                                {
                                                    //Eliminando el item del cargo de la 45-46
                                                    new CtaCte_DetAD().EliminarMaeCtaCteDetallePorIdItem(itemDet.idCtaCteItem45.Value);

                                                    ////Revisando la CtaCte. si existen abonos en las letras
                                                    //List<CtaCte_DetE> oListaAbonos = new CtaCte_DetAD().ListarMaeCtaCteDetAbonos(oCobranza.idEmpresa, itemDet.idCtaCte45.Value);

                                                    //if (oListaAbonos == null || oListaAbonos.Count == 0)
                                                    //{
                                                    //    //Eliminando de la Cta.Cte. de la Letra con cuenta 45... cabecera - detalle
                                                    //    new CtaCteAD().EliminarMaeCtaCteConDetalle(itemDet.idCtaCte45.Value);
                                                    //}

                                                    #region Verificando Saldo de la CtaCte. de la 45-46

                                                    oListaCtaCteDet = new CtaCte_DetAD().ListarMaeCtaCteDet(oCobranza.idEmpresa, itemDet.idCtaCte45.Value);
                                                    Saldo = 0;

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

                                                    // Si el saldo es diferente de 0 vuelve a habilitar el documento en la cta.cte.
                                                    if (Saldo != 0)
                                                    {
                                                        new CtaCteAD().ActualizarFecCancelacionCtaCte(oCobranza.idEmpresa, itemDet.idCtaCte45.Value, Convert.ToDateTime("31-12-2100"), Usuario);
                                                    }

                                                    #endregion
                                                }
                                                else
                                                {
                                                    //Revisando si hay abonos en la CtaCte de la 16
                                                    List<CtaCte_DetE> oListaCtaCteAbonos16 = new CtaCte_DetAD().ListarMaeCtaCteDetAbonos(oCobranza.idEmpresa, itemDet.idCtaCte45.Value);

                                                    if (oListaCtaCteAbonos16.Count > 0)
                                                    {
                                                        throw new Exception(String.Format("La Letra LT {0} en la Cta. Cte. ya tiene Movimientos de Abono, primero elimine esos movimientos de abono.", itemDet.numDocumento));
                                                    }
                                                    else
                                                    {
                                                        // Eliminando el detalle
                                                        new CtaCte_DetAD().EliminarMaeCtaCteDetalle(oCobranza.idEmpresa, itemDet.idCtaCte45.Value);
                                                        // Eliminando la cabecera
                                                        new CtaCteAD().EliminarMaeCtaCte(oCobranza.idEmpresa, itemDet.idCtaCte45.Value);
                                                    }
                                                }

                                                #endregion

                                                #region Actualizando los campos Cta.Cte.

                                                itemDet.idCtaCteItem = null;
                                                itemDet.idCtaCte45 = null;
                                                itemDet.idCtaCteItem45 = null;
                                                itemDet.UsuarioModificacion = Usuario;

                                                new CobranzasItemDetAD().ActualizarCobranzasItemDetCtaCte(itemDet);

                                                #endregion
                                            }
                                            else //EL RESTO
                                            {
                                                //Eliminando el item Cta.Cte. 
                                                new CtaCte_DetAD().EliminarMaeCtaCteDetallePorIdItem(itemDet.idCtaCteItem.Value);

                                                #region Verificando Saldo de la CtaCte.

                                                List<CtaCte_DetE> oListaCtaCteDet = new CtaCte_DetAD().ListarMaeCtaCteDet(oCobranza.idEmpresa, itemDet.idCtaCte.Value);
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

                                                // Si el saldo es diferente de 0 vuelve a habilitar el documento en la cta.cte.
                                                if (Saldo != 0)
                                                {
                                                    new CtaCteAD().ActualizarFecCancelacionCtaCte(oCobranza.idEmpresa, itemDet.idCtaCte.Value, Convert.ToDateTime("31-12-2100"), Usuario);
                                                }

                                                #endregion

                                                #region Actualizando los campos Cta.Cte.

                                                itemDet.idCtaCteItem = null;
                                                itemDet.idCtaCte45 = null;
                                                itemDet.idCtaCteItem45 = null;
                                                itemDet.UsuarioModificacion = Usuario;

                                                new CobranzasItemDetAD().ActualizarCobranzasItemDetCtaCte(itemDet);

                                                #endregion
                                            }
                                        }
                                        else
                                        {
                                            if (itemDet.idDocumento == "LT" && TipoPlanilla == "PLALDES")
                                            {
                                                //Revisando la CtaCte. si existen abonos en las letras
                                                List<CtaCte_DetE> oListaAbonos = new CtaCte_DetAD().ListarMaeCtaCteDetAbonos(oCobranza.idEmpresa, itemDet.idCtaCte45.Value);

                                                if (oListaAbonos != null && oListaAbonos.Count > 0)
                                                {
                                                    throw new Exception(String.Format("No se puede abrir la planilla {0} porque ya tiene Cancelaciones", oCobranza.codPlanilla));
                                                }

                                                // Eliminando el detalle
                                                new CtaCte_DetAD().EliminarMaeCtaCteDetalle(oCobranza.idEmpresa, itemDet.idCtaCte45.Value);
                                                // Eliminando la cabecera
                                                new CtaCteAD().EliminarMaeCtaCte(oCobranza.idEmpresa, itemDet.idCtaCte45.Value);

                                                #region Actualizando los campos Cta.Cte.

                                                itemDet.idCtaCteItem = null;
                                                itemDet.idCtaCte45 = null;
                                                itemDet.idCtaCteItem45 = null;
                                                itemDet.UsuarioModificacion = Usuario;

                                                new CobranzasItemDetAD().ActualizarCobranzasItemDetCtaCte(itemDet);

                                                #endregion
                                            }
                                            else if (itemDet.idDocumento == "LT" && TipoPlanilla == "PLACALET") //CANC. LETRAS EN DSCTO O ENDOSADA
                                            {
                                                //Eliminando el item del abono 45
                                                new CtaCte_DetAD().EliminarMaeCtaCteDetallePorIdItem(itemDet.idCtaCteItem.Value);

                                                #region Verificando Saldo de la CtaCte. de la 45

                                                List<CtaCte_DetE> oListaCtaCteDet = new CtaCte_DetAD().ListarMaeCtaCteDet(oCobranza.idEmpresa, itemDet.idCtaCte.Value);
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

                                                // Si el saldo es diferente de 0 vuelve a habilitar el documento en la cta.cte.
                                                if (Saldo != 0)
                                                {
                                                    new CtaCteAD().ActualizarFecCancelacionCtaCte(oCobranza.idEmpresa, itemDet.idCtaCte.Value, Convert.ToDateTime("31-12-2100"), Usuario);
                                                }

                                                #endregion

                                                #region Revisando la Cuenta 46 - 16

                                                //Revisando si hay abonos en la CtaCte de la 16
                                                List<CtaCte_DetE> oListaCtaCteAbonos16 = new CtaCte_DetAD().ListarMaeCtaCteDetAbonos(oCobranza.idEmpresa, itemDet.idCtaCte45.Value);

                                                if (oListaCtaCteAbonos16.Count > 0)
                                                {
                                                    throw new Exception(String.Format("La Letra LT {0} en la Cta. Cte. ya tiene Movimientos de Abono, primero elimine esos movimientos de abono.", itemDet.numDocumento));
                                                }
                                                else
                                                {
                                                    // Eliminando el detalle
                                                    new CtaCte_DetAD().EliminarMaeCtaCteDetalle(oCobranza.idEmpresa, itemDet.idCtaCte45.Value);
                                                    // Eliminando la cabecera
                                                    new CtaCteAD().EliminarMaeCtaCte(oCobranza.idEmpresa, itemDet.idCtaCte45.Value);
                                                }

                                                #endregion

                                                #region Actualizando los campos Cta.Cte.

                                                itemDet.idCtaCteItem = null;
                                                itemDet.idCtaCte45 = null;
                                                itemDet.idCtaCteItem45 = null;
                                                itemDet.UsuarioModificacion = Usuario;

                                                new CobranzasItemDetAD().ActualizarCobranzasItemDetCtaCte(itemDet);

                                                #endregion
                                            }
                                        }
                                    } 
                                }
                                else
                                {
                                    CobranzasItemDetE DocumentosVentas = (from x in oListaDetalle where x.idDocumento != "NC" select x).SingleOrDefault();
                                    List<CobranzasItemDetE> NotasCredito = new List<CobranzasItemDetE>((from x in oListaDetalle where x.idDocumento == "NC" select x).ToList());
                                    List<CtaCte_DetE> oListaCtaCteDet = null;
                                    Decimal Saldo = 0;

                                    foreach (CobranzasItemDetE itemDet in NotasCredito)
                                    {
                                        //Eliminando el item Cta.Cte. 
                                        new CtaCte_DetAD().EliminarMaeCtaCteDetallePorIdItem(itemDet.idCtaCteItem.Value);

                                        #region Verificando Saldo de la CtaCte.

                                        oListaCtaCteDet = new CtaCte_DetAD().ListarMaeCtaCteDet(oCobranza.idEmpresa, itemDet.idCtaCte.Value);

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

                                        // Si el saldo es diferente de 0 vuelve a habilitar el documento en la cta.cte.
                                        if (Saldo != 0)
                                        {
                                            new CtaCteAD().ActualizarFecCancelacionCtaCte(oCobranza.idEmpresa, itemDet.idCtaCte.Value, Convert.ToDateTime("31-12-2100"), Usuario);
                                        }

                                        #endregion

                                        #region Actualizando los campos Cta.Cte.

                                        itemDet.idCtaCteItem = null;
                                        itemDet.idCtaCte45 = null;
                                        itemDet.idCtaCteItem45 = null;
                                        itemDet.UsuarioModificacion = Usuario;

                                        new CobranzasItemDetAD().ActualizarCobranzasItemDetCtaCte(itemDet);

                                        #endregion
                                    }

                                    //Eliminando los abonos por notas de credito en el documento de venta
                                    foreach (CobranzasItemDetE itemDet in NotasCredito)
                                    {
                                        //Eliminando el item Cta.Cte. 
                                        new CtaCte_DetAD().EliminarCtaCteDetPorIdPorDocumento(oCobranza.idEmpresa, DocumentosVentas.idCtaCte.Value, itemDet.idDocumento, itemDet.numSerie, itemDet.numDocumento);
                                    }

                                    #region Verificando Saldo de la CtaCte.

                                    oListaCtaCteDet = new CtaCte_DetAD().ListarMaeCtaCteDet(oCobranza.idEmpresa, DocumentosVentas.idCtaCte.Value);
                                    Saldo = 0;

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

                                    // Si el saldo es diferente de 0 vuelve a habilitar el documento en la cta.cte.
                                    if (Saldo != 0)
                                    {
                                        new CtaCteAD().ActualizarFecCancelacionCtaCte(oCobranza.idEmpresa, DocumentosVentas.idCtaCte.Value, Convert.ToDateTime("31-12-2100"), Usuario);
                                    }

                                    #endregion
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

        public int LimpiarCobranzasVoucher(Int32 idPlanilla, String UsuarioModificacion)
        {
            try
            {
                return new CobranzasAD().LimpiarCobranzasVoucher(idPlanilla, UsuarioModificacion);
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

        public Boolean RevisarPlanillaCancelacion(List<CobranzasItemDetE> ListaLetrasCobranzas, Int32 idEmpresa, Int32 idLocal, Int32 TipoPlanilla)
        {
            try
            {
                Boolean Cerrado = false;

                foreach (CobranzasItemDetE item in ListaLetrasCobranzas)
                {
                    List<CobranzasE> cobranzas = new CobranzasAD().ListarCobranzasPorLetraTipPla(idEmpresa, idLocal, TipoPlanilla, item.numDocumento);

                    if (cobranzas != null && cobranzas.Count > 0)
                    {
                        foreach (CobranzasE itemCob in cobranzas)
                        {
                            if (itemCob.EstadoDoc)
                            {
                                Cerrado = true;
                                throw new Exception(String.Format("La Planilla de Cancelación {0} asociada a la letra {1} se encuentra CERRADA, tiene que abrir la Cancelación y después al Abono.", itemCob.codPlanilla, item.numDocumento));
                            }
                            else
                            {
                                if (item.indTercero)
                                {
                                    Cerrado = true;
                                    throw new Exception(String.Format("Tiene que eliminar el item de la Planilla de Cancelación {0} asociada a la letra {1}.", itemCob.codPlanilla, item.numDocumento));
                                }
                            }
                        }
                    }
                }

                return Cerrado;
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

        public Boolean CombinarPlanillas(List<CobranzasE> ListaCobranzas, String Usuario)
        {
            try
            {
                Boolean Valor = false;

                using (TransactionScope oTran = new TransactionScope())
                {
                    List<CobranzasE> ListaNueva = new List<CobranzasE>();
                    List<CobranzasItemE> ListaItemsPorRevisar = new List<CobranzasItemE>();

                    foreach (CobranzasE item in ListaCobranzas)
                    {
                        //Obteniendo cabecera
                        CobranzasE cobranzas = new CobranzasAD().ObtenerCobranzas(item.idPlanilla);
                        //Obteniendo detalle
                        cobranzas.oListaCobranzas = new CobranzasItemAD().ListarCobranzasItem(item.idPlanilla, item.idEmpresa);
                        //Llenando la lista de items para poder hacer una agrupación
                        ListaItemsPorRevisar.AddRange(cobranzas.oListaCobranzas);

                        //Obteniendo items del detalle
                        foreach (CobranzasItemE det in cobranzas.oListaCobranzas)
                        {
                            det.oListaCobranzasItemDet = new CobranzasItemDetAD().ListarCobranzasItemDet(det.idPlanilla, det.Recibo);
                        }

                        ListaNueva.Add(cobranzas);
                    }

                    //Agrupando por id, número y fecha de abono para saber si se trata del mismo documento...
                    var ListaAgrupada = ListaItemsPorRevisar.GroupBy(x => new { x.idDocumento, x.numCheque, x.fecCobranza.Value.Date }).Select(g => g.First()).ToList();

                    //Validando si hay documentos diferentes...
                    if (ListaAgrupada.Count > 1)
                    {
                        Valor = false;
                        throw new Exception("Los documentos o las fechas deben ser iguales para poder hacer la combinación.");
                    }

                    //Ordenando por código de planilla para obtener el menor
                    ListaNueva = ListaNueva.OrderBy(x => x.codPlanilla).ToList();
                    CobranzasE CobranzaCab = ListaNueva[0]; //Obteniendo la cabecera

                    foreach (CobranzasE cab in ListaNueva)
                    {
                        //Si es diferente al idCab ingresa
                        if (CobranzaCab.idPlanilla != cab.idPlanilla)
                        {
                            foreach (CobranzasItemE item in cab.oListaCobranzas)
                            {
                                foreach (CobranzasItemDetE det in item.oListaCobranzasItemDet)
                                {
                                    det.Opcion = (Int32)EnumOpcionGrabar.Insertar;
                                    det.UsuarioRegistro = Usuario;
                                    CobranzaCab.oListaCobranzas[0].oListaCobranzasItemDet.Add(det);
                                }
                            }

                            //eliminando el diferente
                            new CobranzasAD().EliminarCobranzas(cab.idPlanilla);
                        }
                    }

                    CobranzaCab.UsuarioModificacion = Usuario;
                    CobranzaCab.oListaCobranzas[0].UsuarioModificacion = Usuario;
                    CobranzaCab = GrabarCobranzas(CobranzaCab, EnumOpcionGrabar.Actualizar);

                    Valor = true;
                    oTran.Complete();
                }

                return Valor;
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

        String GenerarAsientoCobranzaLetrasDscto(CobranzasE oCobranza, String Usuario, String TipoPlanilla)
        {
            try
            {
                VoucherE oVoucher = null;
                StringBuilder CadAuxiliar = new StringBuilder();
                String MensajeResp = String.Empty;

                using (TransactionScope oTrans = new TransactionScope())
                {
                    #region Variables

                    String Libro = oCobranza.idComprobante;
                    String numFile = oCobranza.numFile;
                    String Glosa = String.Empty;
                    String NumeroVoucher = "0";
                    String MesPeriodo = oCobranza.MesPeriodo;
                    String AnioPeriodo = oCobranza.AnioPeriodo;
                    Decimal TipoCambio = 0M;

                    Int32 numItem = 0;
                    Int32? idPersona = 0;
                    Int32? idPersonaBanco = 0;
                    String idDocumento = String.Empty;
                    String Serie = String.Empty;
                    String numDocumento = String.Empty;
                    String idCCostos = String.Empty;
                    String indCuentaGastos_ = "N";
                    String Cuenta4546 = String.Empty;
                    String Cuenta16 = String.Empty;
                    String Cuenta42 = String.Empty;
                    String Cuenta10 = String.Empty;
                    String Cuenta12 = String.Empty;
                    String VersionPC = String.Empty;
                    String DebeHaber = String.Empty;

                    VoucherItemE oLinea = null;
                    PlanCuentasE oCuentaContable = null;
                    TipoCambioE tipoCambio = new TipoCambioAD().ObtenerTipoCambioPorDia("02", oCobranza.Fecha.ToString("yyyyMMdd"));
                    venParametrosE venParametros = new venParametrosAD().ObtenerVenParametros(oCobranza.idEmpresa);

                    #endregion

                    #region Construyendo la Glosa

                    CadAuxiliar.Append("Referencia de letras a: ");

                    foreach (CobranzasItemE item in oCobranza.oListaCobranzas)
                    {
                        var ListaTmp = item.oListaCobranzasItemDet.GroupBy(x => x.RazonSocial).Select(p => p.First()).ToList();

                        foreach (var itemTmp in ListaTmp)
                        {
                            if (itemTmp.idDocumento == "LT")
                            {
                                CadAuxiliar.Append(itemTmp.RazonSocial).Append(", ");
                            }
                        }
                    }

                    Glosa = Global.Izquierda(CadAuxiliar.ToString(), CadAuxiliar.ToString().Length - 2); 

                    #endregion

                    #region Cabecera

                    if (!String.IsNullOrWhiteSpace(oCobranza.idComprobante.Trim()) && !String.IsNullOrWhiteSpace(oCobranza.numFile.Trim()) && !String.IsNullOrWhiteSpace(oCobranza.numVoucher.Trim()))
                    {
                        VoucherE oVoucherTmp = new VoucherAD().ObtenerVoucherPorCodigo(oCobranza.idEmpresa, oCobranza.idLocal, AnioPeriodo, MesPeriodo, oCobranza.numVoucher, Libro, numFile);

                        //Si es diferente de nulo, significa que el número de voucher ya se encuentra registrado y debe crear el siguiente
                        if (oVoucherTmp != null)
                        {
                            MensajeResp = String.Format("El voucher {0} {1} {2} ya se encontraba en Contabilidad, se generó un nuevo N° ", Libro, numFile, oCobranza.numVoucher);
                            NumeroVoucher = "0";
                        }
                        else //Caso contrario le coloca el mismo número de voucher
                        {
                            NumeroVoucher = oCobranza.numVoucher;
                            MensajeResp = "Se actualizó el asiento ";
                        }
                    }
                    else
                    {
                        MensajeResp = "Se generó el asiento ";
                    }

                    if (tipoCambio != null)
                    {
                        TipoCambio = tipoCambio.valVenta;
                    }

                    oVoucher = new VoucherE()
                    {
                        idEmpresa = oCobranza.idEmpresa,
                        idLocal = oCobranza.idLocal,
                        AnioPeriodo = AnioPeriodo,
                        MesPeriodo = MesPeriodo,
                        numVoucher = NumeroVoucher,
                        idComprobante = Libro,
                        numFile = numFile,
                        fecTransferencia = null,
                        numItems = 0,
                        idMoneda = "01",
                        fecOperacion = oCobranza.Fecha,
                        fecDocumento = oCobranza.Fecha,
                        impDebeSoles = 0,
                        impHaberSoles = 0,
                        impDebeDolares = 0,
                        impHaberDolares = 0,
                        impMonOrigDeb = 0,
                        impMonOrigHab = 0,
                        GlosaGeneral = Glosa,
                        tipCambio = TipoCambio,
                        RazonSocial = "VARIOS",
                        numDocumentoPresu = "SD " + oCobranza.codPlanilla,
                        indHojaCosto = "N",
                        numHojaCosto = String.Empty,
                        numOrdenCompra = String.Empty,
                        sistema = "7", //Cobranzas
                        EsAutomatico = true
                    };

                    #endregion

                    #region Detalle

                    //Recorriendo para obtener el detalle
                    if (TipoPlanilla == "PLALDES") //ABONO LETRAS EN DSCTO O ENDOSADA
                    {
                        foreach (CobranzasItemE item in oCobranza.oListaCobranzas)
                        {
                            VersionPC = item.numVerPlanCuentas;
                            Cuenta10 = item.codCuenta;

                            if (String.IsNullOrWhiteSpace(Cuenta10))
                            {
                                throw new Exception(String.Format("No esta configurada la cuenta contable esta vacia {0}...", Cuenta10));
                            }

                            #region Cuenta 10

                            //Revisando si existe la cuenta en el plan contable
                            oCuentaContable = new PlanCuentasAD().ObtenerPlanCuentasPorCodigo(oCobranza.idEmpresa, VersionPC, Cuenta10);

                            if (oCuentaContable != null)
                            {
                                DebeHaber = oCuentaContable.indNaturalezaCta;

                                if (oCuentaContable.indSolicitaAnexo == "S")
                                {
                                    BancosCuentasE bancosCuentas = new BancosCuentasAD().ObtenerBancosPorCodCuenta(oCobranza.idEmpresa, Cuenta10);

                                    if (bancosCuentas != null)
                                    {
                                        idPersonaBanco = bancosCuentas.idPersona;
                                    }
                                    else
                                    {
                                        throw new Exception(String.Format("No existe ningún banco de la empresa con la Cuenta contable {0}", Cuenta10));
                                    }
                                }
                                else
                                {
                                    idPersonaBanco = null;
                                }

                                if (oCuentaContable.indSolicitaDcto == "S")
                                {
                                    idDocumento = item.idDocumento;
                                    Serie = item.numSerie;
                                    numDocumento = item.numCheque;
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
                            else
                            {
                                throw new Exception(String.Format("La cuenta {0} no esta existe en el Plan Contable...", Cuenta10));
                            }

                            #endregion

                            #region Linea Voucher

                            numItem++;

                            oLinea = new VoucherItemE
                            {
                                numItem = String.Format("{0:00000}", numItem),
                                idPersona = idPersonaBanco,
                                idMoneda = item.idMoneda,
                                tipCambio = item.tipCambioReci,
                                indCambio = "S",
                                idCCostos = idCCostos,
                                numVerPlanCuentas = VersionPC,
                                codCuenta = Cuenta10,
                                desGlosa = Glosa,
                                fecDocumento = item.fecCobranza,
                                fecVencimiento = item.fecCobranza,
                                idDocumento = idDocumento,
                                serDocumento = Serie,
                                numDocumento = numDocumento,
                                fecDocumentoRef = null,
                                idDocumentoRef = String.Empty,
                                serDocumentoRef = String.Empty,
                                numDocumentoRef = String.Empty,
                                indDebeHaber = DebeHaber,
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
                                UsuarioRegistro = Usuario,

                                indCuentaGastos = indCuentaGastos_,
                                PlanCuenta = oCuentaContable
                            };

                            if (oLinea.idMoneda == "01")
                            {
                                oLinea.impSoles = item.Monto;
                                oLinea.impDolares = Decimal.Round(item.Monto / oLinea.tipCambio);
                            }
                            else
                            {
                                oLinea.impSoles = Decimal.Round(item.Monto * oLinea.tipCambio);
                                oLinea.impDolares = item.Monto;
                            }

                            oVoucher.ListaVouchers.Add(oLinea);

                            #endregion

                            #region Comisión

                            if (Math.Abs(item.Comision) > 0)
                            {
                                String DH = String.Empty;
                                Decimal impComision = Math.Abs(item.Comision);
                                Decimal ComisionSoles = 0;
                                Decimal ComisionDolares = 0;

                                if (item.Comision < 0)
                                {
                                    DH = "H";
                                }
                                else
                                {
                                    DH = "D";
                                }

                                ConceptosVariosE variosE = new ConceptosVariosAD().ObtenerConceptosVarios(item.idConceptoGasto.Value, oCobranza.idEmpresa);

                                if (variosE != null)
                                {
                                    //Revisando si existe la cuenta en el plan contable
                                    oCuentaContable = new PlanCuentasAD().ObtenerPlanCuentasPorCodigo(oCobranza.idEmpresa, VersionPC, variosE.codCuentaAdm);

                                    if (oCuentaContable != null)
                                    {
                                        if (oCuentaContable.indSolicitaAnexo == "S")
                                        {
                                            BancosCuentasE bancosCuentas = new BancosCuentasAD().ObtenerBancosPorCodCuenta(oCobranza.idEmpresa, Cuenta10);

                                            if (bancosCuentas != null)
                                            {
                                                idPersona = bancosCuentas.idPersona;
                                            }
                                            else
                                            {
                                                throw new Exception(String.Format("No existe ningún banco de la empresa con la Cuenta contable {0}", Cuenta10));
                                            }
                                        }
                                        else
                                        {
                                            idPersona = null;
                                        }

                                        if (oCuentaContable.indSolicitaDcto == "S")
                                        {
                                            idDocumento = item.idDocumento;
                                            Serie = item.numSerie;
                                            numDocumento = item.numCheque;
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
                                    else
                                    {
                                        throw new Exception(String.Format("La cuenta {0} no esta existe en el Plan Contable...", variosE.codCuentaAdm));
                                    }

                                    if (item.idMoneda == "01")
                                    {
                                        ComisionSoles = impComision;
                                        ComisionDolares = Decimal.Round(impComision / TipoCambio);
                                    }
                                    else
                                    {
                                        ComisionDolares = impComision;
                                        ComisionSoles = Decimal.Round(impComision * TipoCambio);
                                    }

                                    #region Linea Voucher

                                    numItem++;

                                    oLinea = new VoucherItemE
                                    {
                                        numItem = String.Format("{0:00000}", numItem),
                                        idPersona = idPersona,
                                        idMoneda = item.idMoneda,
                                        tipCambio = TipoCambio,
                                        indCambio = "S",
                                        idCCostos = idCCostos,
                                        numVerPlanCuentas = VersionPC,
                                        codCuenta = variosE.codCuentaAdm,
                                        desGlosa = Glosa,
                                        fecDocumento = item.fecCobranza,
                                        fecVencimiento = item.fecCobranza,
                                        idDocumento = idDocumento,
                                        serDocumento = Serie,
                                        numDocumento = numDocumento,
                                        fecDocumentoRef = null,
                                        idDocumentoRef = String.Empty,
                                        serDocumentoRef = String.Empty,
                                        numDocumentoRef = String.Empty,
                                        indDebeHaber = DH,
                                        impSoles = ComisionSoles,
                                        impDolares = ComisionDolares,
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
                                        UsuarioRegistro = Usuario,

                                        indCuentaGastos = indCuentaGastos_,
                                        PlanCuenta = oCuentaContable
                                    };

                                    oVoucher.ListaVouchers.Add(oLinea);

                                    #endregion
                                }
                            }

                            #endregion

                            foreach (CobranzasItemDetE itemDet in item.oListaCobranzasItemDet)
                            {
                                numItem++;

                                if (itemDet.idDocumento == "LT") //Letras
                                {
                                    #region Cuenta 46

                                    Cuenta4546 = itemDet.codCuenta;
                                    Cuenta42 = String.Empty;
                                    oCuentaContable = new PlanCuentasAD().ObtenerPlanCuentasPorCodigo(oCobranza.idEmpresa, VersionPC, Cuenta4546);

                                    if (oCuentaContable != null)
                                    {
                                        if (oCuentaContable.indSolicitaAnexo == "S")
                                        {
                                            if (!itemDet.indTercero)
                                            {
                                                if (itemDet.indEndosar)
                                                {
                                                    idPersona = itemDet.LetraEndosadaA;
                                                }
                                                else
                                                {
                                                    idPersona = itemDet.idPersona;
                                                } 
                                            }
                                            else
                                            {
                                                idPersona = idPersonaBanco;
                                            }
                                        }
                                        else
                                        {
                                            idPersona = null;
                                        }

                                        if (oCuentaContable.indSolicitaDcto == "S")
                                        {
                                            idDocumento = itemDet.idDocumento;
                                            Serie = itemDet.numSerie;
                                            numDocumento = itemDet.numDocumento;
                                        }
                                        else
                                        {
                                            idDocumento = String.Empty;
                                            Serie = String.Empty;
                                            numDocumento = String.Empty;
                                        }

                                        idCCostos = String.Empty;
                                        indCuentaGastos_ = oCuentaContable.indCuentaGastos;

                                        DebeHaber = oCuentaContable.indNaturalezaCta;
                                    }
                                    else
                                    {
                                        throw new Exception(String.Format("La cuenta {0} no esta existe en el Plan Contable...", Cuenta4546));
                                    }

                                    #endregion
                                }
                                else
                                {
                                    #region Cuenta 42

                                    Cuenta42 = itemDet.codCuenta;
                                    Cuenta4546 = String.Empty;
                                    oCuentaContable = new PlanCuentasAD().ObtenerPlanCuentasPorCodigo(oCobranza.idEmpresa, VersionPC, Cuenta42);

                                    if (oCuentaContable != null)
                                    {
                                        if (oCuentaContable.indSolicitaAnexo == "S")
                                        {
                                            idPersona = itemDet.idPersona;
                                        }
                                        else
                                        {
                                            idPersona = null;
                                        }

                                        if (oCuentaContable.indSolicitaDcto == "S")
                                        {
                                            idDocumento = itemDet.idDocumento;
                                            Serie = itemDet.numSerie;
                                            numDocumento = itemDet.numDocumento;
                                        }
                                        else
                                        {
                                            idDocumento = String.Empty;
                                            Serie = String.Empty;
                                            numDocumento = String.Empty;
                                        }

                                        idCCostos = String.Empty;
                                        indCuentaGastos_ = oCuentaContable.indCuentaGastos;

                                        if (oCuentaContable.indNaturalezaCta == "H")
                                        {
                                            DebeHaber = "D";
                                        }
                                        else
                                        {
                                            DebeHaber = "H";
                                        }
                                    }
                                    else
                                    {
                                        throw new Exception(String.Format("La cuenta {0} no esta existe en el Plan Contable...", Cuenta4546));
                                    }

                                    #endregion
                                }

                                #region Linea Voucher

                                oLinea = new VoucherItemE
                                {
                                    numItem = String.Format("{0:00000}", numItem),
                                    idPersona = idPersona,
                                    idMoneda = itemDet.idMoneda,
                                    tipCambio = itemDet.tipCambioReci.Value,
                                    indCambio = "S",
                                    idCCostos = idCCostos,
                                    numVerPlanCuentas = VersionPC,
                                    codCuenta = itemDet.idDocumento == "LT" ? Cuenta4546 : Cuenta42,
                                    desGlosa = Glosa,
                                    fecDocumento = itemDet.fecEmision,
                                    fecVencimiento = itemDet.fecEmision,
                                    idDocumento = idDocumento,
                                    serDocumento = Serie,
                                    numDocumento = numDocumento,
                                    fecDocumentoRef = null,
                                    idDocumentoRef = String.Empty,
                                    serDocumentoRef = String.Empty,
                                    numDocumentoRef = String.Empty,
                                    indDebeHaber = DebeHaber,
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
                                    UsuarioRegistro = Usuario,

                                    indCuentaGastos = indCuentaGastos_,
                                    PlanCuenta = oCuentaContable
                                };

                                if (oLinea.idMoneda == "01")
                                {
                                    oLinea.impSoles = itemDet.Monto.Value;
                                    oLinea.impDolares = Decimal.Round(itemDet.Monto.Value / oLinea.tipCambio);
                                }
                                else
                                {
                                    oLinea.impSoles = Decimal.Round(itemDet.Monto.Value * oLinea.tipCambio);
                                    oLinea.impDolares = itemDet.Monto.Value;
                                }

                                oVoucher.ListaVouchers.Add(oLinea);

                                #endregion
                            }
                        } 
                    }
                    else
                    {
                        foreach (CobranzasItemE item in oCobranza.oListaCobranzas)
                        {
                            VersionPC = item.numVerPlanCuentas;

                            if (item.TipoCobro != "LDE")//Diferente al Tipo de Cobro 9.7 CANCE. LETRA EN DSCTO ENDOSO S/PAGO
                            {
                                Cuenta4546 = item.codCuenta;

                                foreach (CobranzasItemDetE itemDet in item.oListaCobranzasItemDet)
                                {
                                    numItem++;

                                    if (!itemDet.indTercero)
                                    {
                                        #region Cuenta 12

                                        Cuenta12 = itemDet.codCuenta;
                                        oCuentaContable = new PlanCuentasAD().ObtenerPlanCuentasPorCodigo(oCobranza.idEmpresa, VersionPC, Cuenta12);

                                        if (oCuentaContable != null)
                                        {
                                            if (oCuentaContable.indSolicitaAnexo == "S")/////
                                            {
                                                idPersona = itemDet.idPersona;
                                            }
                                            else
                                            {
                                                idPersona = null;
                                            }

                                            if (oCuentaContable.indSolicitaDcto == "S")
                                            {
                                                idDocumento = itemDet.idDocumento;
                                                Serie = itemDet.numSerie;
                                                numDocumento = itemDet.numDocumento;
                                            }
                                            else
                                            {
                                                idDocumento = String.Empty;
                                                Serie = String.Empty;
                                                numDocumento = String.Empty;
                                            }

                                            idCCostos = String.Empty;
                                            indCuentaGastos_ = oCuentaContable.indCuentaGastos;

                                            if (oCuentaContable.indNaturalezaCta == "D")
                                            {
                                                DebeHaber = "H";
                                            }
                                            else
                                            {
                                                DebeHaber = "D";
                                            }
                                        }
                                        else
                                        {
                                            throw new Exception(String.Format("La cuenta {0} no esta existe en el Plan Contable...", Cuenta12));
                                        }

                                        #endregion 
                                    }
                                    else
                                    {
                                        #region Cuenta 45

                                        oCuentaContable = new PlanCuentasAD().ObtenerPlanCuentasPorCodigo(oCobranza.idEmpresa, VersionPC, itemDet.codCuenta);

                                        if (oCuentaContable != null)
                                        {
                                            if (oCuentaContable.indSolicitaAnexo == "S")
                                            {
                                                idPersona = oCobranza.idBanco;
                                            }
                                            else
                                            {
                                                idPersona = null;
                                            }

                                            if (oCuentaContable.indSolicitaDcto == "S")
                                            {
                                                idDocumento = itemDet.idDocumento;
                                                Serie = itemDet.numSerie;
                                                numDocumento = itemDet.numDocumento;
                                            }
                                            else
                                            {
                                                idDocumento = String.Empty;
                                                Serie = String.Empty;
                                                numDocumento = String.Empty;
                                            }

                                            idCCostos = String.Empty;
                                            indCuentaGastos_ = oCuentaContable.indCuentaGastos;

                                            DebeHaber = "D";
                                        }
                                        else
                                        {
                                            throw new Exception(String.Format("La cuenta {0} no esta existe en el Plan Contable...", itemDet.codCuenta));
                                        }

                                        #endregion
                                    }

                                    #region Linea Voucher

                                    oLinea = new VoucherItemE
                                    {
                                        numItem = String.Format("{0:00000}", numItem),
                                        idPersona = idPersona,
                                        idMoneda = itemDet.idMoneda,
                                        tipCambio = itemDet.tipCambioReci.Value,
                                        indCambio = "S",
                                        idCCostos = idCCostos,
                                        numVerPlanCuentas = VersionPC,
                                        codCuenta = !itemDet.indTercero ? Cuenta12 : itemDet.codCuenta,
                                        desGlosa = Glosa,
                                        fecDocumento = itemDet.fecEmision,
                                        fecVencimiento = itemDet.fecEmision,
                                        idDocumento = idDocumento,
                                        serDocumento = Serie,
                                        numDocumento = numDocumento,
                                        fecDocumentoRef = null,
                                        idDocumentoRef = String.Empty,
                                        serDocumentoRef = String.Empty,
                                        numDocumentoRef = String.Empty,
                                        indDebeHaber = DebeHaber,
                                        indAutomatica = "N",
                                        CorrelativoAjuste = String.Empty,
                                        codFteFin = String.Empty,
                                        codProgramaCred = String.Empty,
                                        indMovimientoAnterior = String.Empty,
                                        tipPartidaPresu = String.Empty,
                                        codPartidaPresu = String.Empty,
                                        numDocumentoPresu = item.idDocumento + "-" + NumeroVoucher,
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
                                        UsuarioRegistro = Usuario,

                                        indCuentaGastos = indCuentaGastos_,
                                        PlanCuenta = oCuentaContable
                                    };

                                    if (oLinea.idMoneda == "01")
                                    {
                                        oLinea.impSoles = itemDet.Monto.Value;
                                        oLinea.impDolares = Decimal.Round(itemDet.Monto.Value / oLinea.tipCambio);
                                    }
                                    else
                                    {
                                        oLinea.impSoles = Decimal.Round(itemDet.Monto.Value * oLinea.tipCambio);
                                        oLinea.impDolares = itemDet.Monto.Value;
                                    }

                                    oVoucher.ListaVouchers.Add(oLinea);

                                    #endregion
                                }

                                foreach (CobranzasItemDetE itemDet in item.oListaCobranzasItemDet)
                                {
                                    numItem++;

                                    if (!itemDet.indTercero)
                                    {
                                        #region Cuenta 45 o 46

                                        oCuentaContable = new PlanCuentasAD().ObtenerPlanCuentasPorCodigo(oCobranza.idEmpresa, VersionPC, Cuenta4546);

                                        if (oCuentaContable != null)
                                        {
                                            if (oCuentaContable.indSolicitaAnexo == "S")
                                            {
                                                if (oCobranza.idComprobante != "08")//Diferente a Libro Diario
                                                {
                                                    if (itemDet.indEndosar)
                                                    {
                                                        idPersona = itemDet.LetraEndosadaA;
                                                    }
                                                    else
                                                    {
                                                        idPersona = itemDet.idPersona;
                                                    } 
                                                }
                                                else
                                                {
                                                    if (venParametros != null)
                                                    {
                                                        if (venParametros.indBanco)
                                                        {
                                                            idPersona = oCobranza.idBanco;
                                                        }
                                                        else
                                                        {
                                                            idPersona = itemDet.idPersona;
                                                        }
                                                    }
                                                    else
                                                    {
                                                        idPersona = oCobranza.idBanco;
                                                    }
                                                }
                                            }
                                            else
                                            {
                                                idPersona = null;
                                            }

                                            if (oCuentaContable.indSolicitaDcto == "S")
                                            {
                                                idDocumento = itemDet.idDocumento;
                                                Serie = itemDet.numSerie;
                                                numDocumento = itemDet.numDocumento;
                                            }
                                            else
                                            {
                                                idDocumento = String.Empty;
                                                Serie = String.Empty;
                                                numDocumento = String.Empty;
                                            }

                                            idCCostos = String.Empty;
                                            indCuentaGastos_ = oCuentaContable.indCuentaGastos;

                                            if (oCuentaContable.indNaturalezaCta == "D")
                                            {
                                                DebeHaber = "H";
                                            }
                                            else
                                            {
                                                DebeHaber = "D";
                                            }
                                        }
                                        else
                                        {
                                            throw new Exception(String.Format("La cuenta {0} no esta existe en el Plan Contable...", Cuenta4546));
                                        }

                                        #endregion 
                                    }
                                    else
                                    {
                                        #region Cuenta 46 o 16

                                        oCuentaContable = new PlanCuentasAD().ObtenerPlanCuentasPorCodigo(oCobranza.idEmpresa, VersionPC, item.codCuenta);

                                        if (oCuentaContable != null)
                                        {
                                            if (oCuentaContable.indSolicitaAnexo == "S")
                                            {
                                                if (itemDet.indEndosar)
                                                {
                                                    idPersona = itemDet.LetraEndosadaA;
                                                }
                                                else
                                                {
                                                    idPersona = itemDet.idPersona;
                                                }
                                            }
                                            else
                                            {
                                                idPersona = null;
                                            }

                                            if (oCuentaContable.indSolicitaDcto == "S")
                                            {
                                                idDocumento = itemDet.idDocumento;
                                                Serie = itemDet.numSerie;
                                                numDocumento = itemDet.numDocumento;
                                            }
                                            else
                                            {
                                                idDocumento = String.Empty;
                                                Serie = String.Empty;
                                                numDocumento = String.Empty;
                                            }

                                            idCCostos = String.Empty;
                                            indCuentaGastos_ = oCuentaContable.indCuentaGastos;

                                            DebeHaber = "H";
                                        }
                                        else
                                        {
                                            throw new Exception(String.Format("La cuenta {0} no esta existe en el Plan Contable...", item.codCuenta));
                                        }

                                        #endregion
                                    }

                                    #region Linea Voucher

                                    oLinea = new VoucherItemE
                                    {
                                        numItem = String.Format("{0:00000}", numItem),
                                        idPersona = idPersona,
                                        idMoneda = itemDet.idMoneda,
                                        tipCambio = itemDet.tipCambioReci.Value,
                                        indCambio = "S",
                                        idCCostos = idCCostos,
                                        numVerPlanCuentas = VersionPC,
                                        codCuenta = !itemDet.indTercero ? Cuenta4546 : item.codCuenta,
                                        desGlosa = Glosa,
                                        fecDocumento = itemDet.fecEmision,
                                        fecVencimiento = itemDet.fecEmision,
                                        idDocumento = idDocumento,
                                        serDocumento = Serie,
                                        numDocumento = numDocumento,
                                        fecDocumentoRef = null,
                                        idDocumentoRef = String.Empty,
                                        serDocumentoRef = String.Empty,
                                        numDocumentoRef = String.Empty,
                                        indDebeHaber = DebeHaber,
                                        indAutomatica = "N",
                                        CorrelativoAjuste = String.Empty,
                                        codFteFin = String.Empty,
                                        codProgramaCred = String.Empty,
                                        indMovimientoAnterior = String.Empty,
                                        tipPartidaPresu = String.Empty,
                                        codPartidaPresu = String.Empty,
                                        numDocumentoPresu = item.idDocumento + "-" + NumeroVoucher,
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
                                        UsuarioRegistro = Usuario,

                                        indCuentaGastos = indCuentaGastos_,
                                        PlanCuenta = oCuentaContable
                                    };

                                    if (oLinea.idMoneda == "01")
                                    {
                                        oLinea.impSoles = itemDet.Monto.Value;
                                        oLinea.impDolares = Decimal.Round(itemDet.Monto.Value / oLinea.tipCambio);
                                    }
                                    else
                                    {
                                        oLinea.impSoles = Decimal.Round(itemDet.Monto.Value * oLinea.tipCambio);
                                        oLinea.impDolares = itemDet.Monto.Value;
                                    }

                                    oVoucher.ListaVouchers.Add(oLinea);

                                    #endregion
                                }
                            }
                            else
                            {
                                Cuenta16 = item.codCuenta;
                                DebeHaber = "H";

                                foreach (CobranzasItemDetE itemDet in item.oListaCobranzasItemDet)
                                {
                                    numItem++;

                                    #region Cuenta 12

                                    Cuenta12 = itemDet.codCuenta;
                                    oCuentaContable = new PlanCuentasAD().ObtenerPlanCuentasPorCodigo(oCobranza.idEmpresa, VersionPC, Cuenta12);

                                    if (oCuentaContable != null)
                                    {
                                        if (oCuentaContable.indSolicitaAnexo == "S")
                                        {
                                            idPersona = itemDet.idPersona;
                                        }
                                        else
                                        {
                                            idPersona = null;
                                        }

                                        if (oCuentaContable.indSolicitaDcto == "S")
                                        {
                                            idDocumento = itemDet.idDocumento;
                                            Serie = itemDet.numSerie;
                                            numDocumento = itemDet.numDocumento;
                                        }
                                        else
                                        {
                                            idDocumento = String.Empty;
                                            Serie = String.Empty;
                                            numDocumento = String.Empty;
                                        }

                                        idCCostos = String.Empty;
                                        indCuentaGastos_ = oCuentaContable.indCuentaGastos;

                                        //if (oCuentaContable.indNaturalezaCta == "D")
                                        //{
                                        //    DebeHaber = "H";
                                        //}
                                        //else
                                        //{
                                        //    DebeHaber = "D";
                                        //}
                                    }
                                    else
                                    {
                                        throw new Exception(String.Format("La cuenta {0} no esta existe en el Plan Contable...", Cuenta12));
                                    }

                                    #endregion

                                    #region Linea Voucher

                                    oLinea = new VoucherItemE
                                    {
                                        numItem = String.Format("{0:00000}", numItem),
                                        idPersona = idPersona,
                                        idMoneda = itemDet.idMoneda,
                                        tipCambio = itemDet.tipCambioReci.Value,
                                        indCambio = "S",
                                        idCCostos = idCCostos,
                                        numVerPlanCuentas = VersionPC,
                                        codCuenta = Cuenta12,
                                        desGlosa = Glosa,
                                        fecDocumento = itemDet.fecEmision,
                                        fecVencimiento = itemDet.fecEmision,
                                        idDocumento = idDocumento,
                                        serDocumento = Serie,
                                        numDocumento = numDocumento,
                                        fecDocumentoRef = null,
                                        idDocumentoRef = String.Empty,
                                        serDocumentoRef = String.Empty,
                                        numDocumentoRef = String.Empty,
                                        indDebeHaber = DebeHaber,
                                        indAutomatica = "N",
                                        CorrelativoAjuste = String.Empty,
                                        codFteFin = String.Empty,
                                        codProgramaCred = String.Empty,
                                        indMovimientoAnterior = String.Empty,
                                        tipPartidaPresu = String.Empty,
                                        codPartidaPresu = String.Empty,
                                        numDocumentoPresu = item.idDocumento + "-" + NumeroVoucher,
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
                                        UsuarioRegistro = Usuario,

                                        indCuentaGastos = indCuentaGastos_,
                                        PlanCuenta = oCuentaContable
                                    };

                                    if (oLinea.idMoneda == "01")
                                    {
                                        oLinea.impSoles = itemDet.Monto.Value;
                                        oLinea.impDolares = Decimal.Round(itemDet.Monto.Value / oLinea.tipCambio);
                                    }
                                    else
                                    {
                                        oLinea.impSoles = Decimal.Round(itemDet.Monto.Value * oLinea.tipCambio);
                                        oLinea.impDolares = itemDet.Monto.Value;
                                    }

                                    oVoucher.ListaVouchers.Add(oLinea);

                                    #endregion
                                }

                                DebeHaber = "D";

                                foreach (CobranzasItemDetE itemDet in item.oListaCobranzasItemDet)
                                {
                                    numItem++;

                                    #region Cuenta 16

                                    oCuentaContable = new PlanCuentasAD().ObtenerPlanCuentasPorCodigo(oCobranza.idEmpresa, VersionPC, Cuenta16);

                                    if (oCuentaContable != null)
                                    {
                                        if (oCuentaContable.indSolicitaAnexo == "S")
                                        {
                                            if (itemDet.indEndosar)
                                            {
                                                idPersona = itemDet.LetraEndosadaA;
                                            }
                                            else
                                            {
                                                idPersona = itemDet.idPersona;
                                            }
                                        }
                                        else
                                        {
                                            idPersona = null;
                                        }

                                        if (oCuentaContable.indSolicitaDcto == "S")
                                        {
                                            idDocumento = itemDet.idDocumento;
                                            Serie = itemDet.numSerie;
                                            numDocumento = itemDet.numDocumento;
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
                                    else
                                    {
                                        throw new Exception(String.Format("La cuenta {0} no esta existe en el Plan Contable...", Cuenta4546));
                                    }

                                    #endregion

                                    #region Linea Voucher

                                    oLinea = new VoucherItemE
                                    {
                                        numItem = String.Format("{0:00000}", numItem),
                                        idPersona = idPersona,
                                        idMoneda = itemDet.idMoneda,
                                        tipCambio = itemDet.tipCambioReci.Value,
                                        indCambio = "S",
                                        idCCostos = idCCostos,
                                        numVerPlanCuentas = VersionPC,
                                        codCuenta = Cuenta16,
                                        desGlosa = Glosa,
                                        fecDocumento = itemDet.fecEmision,
                                        fecVencimiento = itemDet.fecEmision,
                                        idDocumento = idDocumento,
                                        serDocumento = Serie,
                                        numDocumento = numDocumento,
                                        fecDocumentoRef = null,
                                        idDocumentoRef = String.Empty,
                                        serDocumentoRef = String.Empty,
                                        numDocumentoRef = String.Empty,
                                        indDebeHaber = DebeHaber,
                                        indAutomatica = "N",
                                        CorrelativoAjuste = String.Empty,
                                        codFteFin = String.Empty,
                                        codProgramaCred = String.Empty,
                                        indMovimientoAnterior = String.Empty,
                                        tipPartidaPresu = String.Empty,
                                        codPartidaPresu = String.Empty,
                                        numDocumentoPresu = item.idDocumento + "-" + NumeroVoucher,
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
                                        UsuarioRegistro = Usuario,

                                        indCuentaGastos = indCuentaGastos_,
                                        PlanCuenta = oCuentaContable
                                    };

                                    if (oLinea.idMoneda == "01")
                                    {
                                        oLinea.impSoles = itemDet.Monto.Value;
                                        oLinea.impDolares = Decimal.Round(itemDet.Monto.Value / oLinea.tipCambio);
                                    }
                                    else
                                    {
                                        oLinea.impSoles = Decimal.Round(itemDet.Monto.Value * oLinea.tipCambio);
                                        oLinea.impDolares = itemDet.Monto.Value;
                                    }

                                    oVoucher.ListaVouchers.Add(oLinea);

                                    #endregion
                                }
                            }
                        }
                    }

                    //Revisando si hay diferencias
                    Decimal totDebeSoles = Decimal.Round((from x in oVoucher.ListaVouchers where x.indDebeHaber == "D" select x.impSoles).Sum(), 2);
                    Decimal totHaberSoles = Decimal.Round((from x in oVoucher.ListaVouchers where x.indDebeHaber == "H" select x.impSoles).Sum(), 2);
                    Decimal totDebeDolares = Decimal.Round((from x in oVoucher.ListaVouchers where x.indDebeHaber == "D" select x.impDolares).Sum(), 2);
                    Decimal totHaberDolares = Decimal.Round((from x in oVoucher.ListaVouchers where x.indDebeHaber == "H" select x.impDolares).Sum(), 2);
                    Decimal DiferenciaSoles = 0, DiferenciaDolares = 0;

                    DiferenciaSoles = totDebeSoles - totHaberSoles;
                    DiferenciaDolares = totDebeDolares - totHaberDolares;

                    if (Math.Abs(DiferenciaSoles) > 0.3M || Math.Abs(DiferenciaDolares) > 0.3M)
                    {
                        #region Diferencia de Cambio

                        ParametrosContaE oParametros = new ParametrosContaAD().ObtenerParametrosConta(oCobranza.idEmpresa);

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
                                else
                                {
                                    CuentaDif = CuentaGanancia;
                                    NaturalezaDH = "H";
                                    Ajustar = true;
                                }

                                if (Ajustar)
                                {
                                    numItem++;
                                    MontoDiferencia = Math.Abs(DiferenciaSoles);
                                    oCuentaContable = new PlanCuentasAD().ObtenerPlanCuentasPorCodigo(oCobranza.idEmpresa, VersionPC, CuentaDif);

                                    oLinea = new VoucherItemE
                                    {
                                        numItem = String.Format("{0:00000}", numItem),
                                        idPersona = null,
                                        idMoneda = "01",
                                        tipCambio = 0,
                                        indCambio = "S",
                                        idCCostos = String.Empty,
                                        numVerPlanCuentas = VersionPC,
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
                                else
                                {
                                    CuentaDif = CuentaGanancia;
                                    NaturalezaDH = "H";
                                    Ajustar = true;
                                }

                                if (Ajustar)
                                {
                                    numItem++;
                                    MontoDiferencia = Math.Abs(DiferenciaDolares);
                                    oCuentaContable = new PlanCuentasAD().ObtenerPlanCuentasPorCodigo(oCobranza.idEmpresa, VersionPC, CuentaDif);

                                    oLinea = new VoucherItemE
                                    {
                                        numItem = String.Format("{0:00000}", numItem),
                                        idPersona = null,
                                        idMoneda = "02",
                                        tipCambio = 0,
                                        indCambio = "S",
                                        idCCostos = String.Empty,
                                        numVerPlanCuentas = VersionPC,
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

                        #endregion
                    }
                    else
                    {
                        #region Ajuste

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

                        #endregion
                    }

                    //Revisando si hay diferencias
                    totDebeSoles = Decimal.Round((from x in oVoucher.ListaVouchers where x.indDebeHaber == "D" select x.impSoles).Sum(), 2);
                    totHaberSoles = Decimal.Round((from x in oVoucher.ListaVouchers where x.indDebeHaber == "H" select x.impSoles).Sum(), 2);
                    totDebeDolares = Decimal.Round((from x in oVoucher.ListaVouchers where x.indDebeHaber == "D" select x.impDolares).Sum(), 2);
                    totHaberDolares = Decimal.Round((from x in oVoucher.ListaVouchers where x.indDebeHaber == "H" select x.impDolares).Sum(), 2);

                    DiferenciaSoles = totDebeSoles - totHaberSoles;
                    DiferenciaDolares = totDebeDolares - totHaberDolares;

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
                                oCuentaContable = new PlanCuentasAD().ObtenerPlanCuentasPorCodigo(oCobranza.idEmpresa, item.PlanCuenta.numVerPlanCuentas, item.PlanCuenta.codCuentaDestino);
                            }

                            if (oCuentaContable != null)
                            {
                                if (oCuentaContable.indSolicitaAnexo == "S")
                                {
                                    idPersona = item.idPersona;
                                }
                                else
                                {
                                    idPersona = null;
                                }

                                //idDocumento = String.Empty;
                                //numDocumento = String.Empty;

                                if (oCuentaContable.indSolicitaDcto == "S")
                                {
                                    idDocumento = item.idDocumento;
                                    Serie = item.serDocumento.Trim();
                                    numDocumento = item.numDocumento.Trim();
                                }
                                else
                                {
                                    idDocumento = String.Empty;
                                    Serie = String.Empty;
                                    numDocumento = String.Empty;
                                }

                                //idCCostos = String.Empty;

                                if (oCuentaContable.indSolicitaCentroCosto == "S")
                                {
                                    idCCostos = item.idCCostos.Trim();
                                }
                                else
                                {
                                    idCCostos = String.Empty;
                                }
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
                                oCuentaContable = new PlanCuentasAD().ObtenerPlanCuentasPorCodigo(oCobranza.idEmpresa, item.PlanCuenta.numVerPlanCuentas, item.PlanCuenta.codCuentaTransferencia);
                            }

                            if (oCuentaContable != null)
                            {
                                if (oCuentaContable.indSolicitaAnexo == "S")
                                {
                                    idPersona = item.idPersona;
                                }
                                else
                                {
                                    idPersona = null;
                                }

                                //idDocumento = String.Empty;
                                //numDocumento = String.Empty;
                                if (oCuentaContable.indSolicitaDcto == "S")
                                {
                                    idDocumento = item.idDocumento;
                                    Serie = item.serDocumento.Trim();
                                    numDocumento = item.numDocumento.Trim();
                                }
                                else
                                {
                                    idDocumento = String.Empty;
                                    Serie = String.Empty;
                                    numDocumento = String.Empty;
                                }

                                //idCCostos = String.Empty;

                                if (oCuentaContable.indSolicitaCentroCosto == "S")
                                {
                                    idCCostos = item.idCCostos.Trim();
                                }
                                else
                                {
                                    idCCostos = String.Empty;
                                }
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

                    //Llenando últimos campos
                    oVoucher.impDebeSoles = (from x in oVoucher.ListaVouchers where x.indDebeHaber == "D" select x.impSoles).Sum();
                    oVoucher.impHaberSoles = (from x in oVoucher.ListaVouchers where x.indDebeHaber == "H" select x.impSoles).Sum();
                    oVoucher.impDebeDolares = (from x in oVoucher.ListaVouchers where x.indDebeHaber == "D" select x.impDolares).Sum();
                    oVoucher.impHaberDolares = (from x in oVoucher.ListaVouchers where x.indDebeHaber == "H" select x.impDolares).Sum();
                    oVoucher.numItems = oVoucher.ListaVouchers.Count;

                    if (DiferenciaSoles == 0 && DiferenciaDolares == 0)
                    {
                        oVoucher.indEstado = "C";
                    }
                    else
                    {
                        oVoucher.indEstado = "D";
                    }

                    //Ingresando el voucher
                    oVoucher.UsuarioRegistro = Usuario;
                    oVoucher = new VoucherLN().GrabarVouchers(oVoucher, EnumOpcionGrabar.Insertar);

                    //Actualizando el N° de voucher en cobranzas...
                    oCobranza.idComprobante = Libro;
                    oCobranza.numFile = numFile;
                    oCobranza.numVoucher = oVoucher.numVoucher;
                    oCobranza.AnioPeriodo = AnioPeriodo;
                    oCobranza.MesPeriodo = MesPeriodo;
                    oCobranza.UsuarioModificacion = Usuario;

                    ActualizarEstadoCobranzas(oCobranza.idPlanilla, oCobranza.numVoucher, true, Usuario);

                    //Transacción completa...
                    oTrans.Complete();
                }

                return MensajeResp + oVoucher.idComprobante + " " + oVoucher.numFile + " " + oVoucher.numVoucher;
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
