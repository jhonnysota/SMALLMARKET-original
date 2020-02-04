using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Transactions;
using System.Linq;

using Entidades.Ventas;
using Entidades.Tesoreria;
using Entidades.Contabilidad;
using Entidades.Generales;
using AccesoDatos.Generales;
using AccesoDatos.Ventas;
using AccesoDatos.Tesoreria;
using AccesoDatos.Contabilidad;
using Infraestructura;
using Infraestructura.Enumerados;

namespace Negocio.Ventas
{
    public class LetrasCanjeUnionLN
    {

        public bool GrabarLetrasCanje(LetrasCanjeUnionE oLetraCanjeUnion, EnumOpcionGrabar OpcionGrabar)
        {
            try
            {
                bool Grabo = false;

                using (TransactionScope oTrans = new TransactionScope())
                {
                    String tipCanje = String.Empty;
                    Int32 Codigo = 0;
                    String codCanje = String.Empty;

                    switch (OpcionGrabar)
                    {
                        case EnumOpcionGrabar.Insertar:

                            tipCanje = oLetraCanjeUnion.oListaLetras[0].tipCanje;
                            Codigo = new LetrasCanjeAD().GenerarCodCanje(oLetraCanjeUnion.oListaLetras[0].idEmpresa, oLetraCanjeUnion.oListaLetras[0].idLocal, tipCanje);
                            codCanje = String.Format("{0:0000000000}", Codigo);
                            String numLetra = String.Empty;
                            //LetrasCanjeE oCanje = null;

                            //Verificando si se ha generado letras para el documento
                            //foreach (LetrasCanjeE item in oLetraCanjeUnion.oListaCanjes)
                            //{
                            //    oCanje = new LetrasCanjeAD().LetrasCanjePorDocumento(item.idEmpresa, item.idLocal, item.idDocumento, item.numSerie, item.numDocumento);

                            //    if (oCanje != null)
                            //    {
                            //        throw new Exception(string.Format("El documento {0} {1}-{2} ya posee letras generadas.", item.idDocumento, item.numSerie, item.numDocumento));
                            //    }
                            //}

                            LetrasCanjeUnionE oCanjeUnion = new LetrasCanjeUnionE()
                            {
                                idEmpresa = oLetraCanjeUnion.oListaCanjes[0].idEmpresa,
                                idLocal = oLetraCanjeUnion.oListaCanjes[0].idLocal,
                                tipCanje = tipCanje,
                                codCanje = codCanje,
                                Estado = false
                            };

                            //Insertando en la Union
                            new LetrasCanjeUnionAD().InsertarLetrasCanjeUnion(oCanjeUnion);

                            //Insertando la cabecera - Canjes
                            foreach (LetrasCanjeE item in oLetraCanjeUnion.oListaCanjes)
                            {
                                item.tipCanje = tipCanje;
                                item.codCanje = codCanje;

                                if (item.idCtaCte == 0 && String.IsNullOrWhiteSpace(item.codCuenta))
                                {
                                    CtaCteE oCtaCteDocumento = new CtaCteAD().ObtenerMaeCtaCtePorDocumento(item.idEmpresa, item.idDocumento, item.numSerie, item.numDocumento);

                                    if (oCtaCteDocumento != null)
                                    {
                                        item.tipCambioDoc = oCtaCteDocumento.TipoCambio;
                                        item.numVerPlanCuentas = oCtaCteDocumento.numVerPlanCuentas;
                                        item.codCuenta = oCtaCteDocumento.codCuenta;
                                        item.idCtaCte = oCtaCteDocumento.idCtaCte;
                                    }
                                }

                                new LetrasCanjeAD().InsertarLetrasCanje(item);
                            }

                            //Insertando el detalle - Letras
                            foreach (LetrasE item2 in oLetraCanjeUnion.oListaLetras)
                            {
                                if (item2.tipCanje == "RV")
                                {
                                    numLetra = item2.Numero; //Convert.ToInt32(item2.Numero);
                                }
                                else
                                {
                                    numLetra = new LetrasAD().GenerarNumeroLetra(item2.idEmpresa, item2.idLocal);

                                    if (numLetra == "error")
                                    {
                                        throw new Exception("No se ha configurado correlativo para Letras en Ventas/Maestros/Control de Documento");
                                    }

                                    //Actualizando Correlativo del documento en numControlDet
                                    new NumControlDetAD().ActualizarCorrelativoNumControlDet(item2.idEmpresa, item2.idLocal, "LT", "", numLetra);
                                }

                                item2.codCanje = codCanje;
                                item2.Numero = numLetra; //String.Format("{0:00000000}", numLetra);
                                new LetrasAD().InsertarLetras(item2);
                            }

                            break;
                        case EnumOpcionGrabar.Actualizar:

                            tipCanje = oLetraCanjeUnion.oListaLetras[0].tipCanje;
                            codCanje = oLetraCanjeUnion.oListaLetras[0].codCanje;

                            //Eliminando si hay canjes por eliminar
                            if (oLetraCanjeUnion.CanjesEliminados != null && oLetraCanjeUnion.CanjesEliminados.Count > 0)
                            {
                                foreach (LetrasCanjeE item in oLetraCanjeUnion.CanjesEliminados)
                                {
                                    new LetrasCanjeAD().EliminarLetrasCanje(item.idEmpresa, item.idLocal, item.tipCanje, item.codCanje);
                                }
                            }

                            //Insertando o actualizando canjes
                            foreach (LetrasCanjeE item in oLetraCanjeUnion.oListaCanjes)
                            {
                                if (item.idCtaCte == 0 && String.IsNullOrWhiteSpace(item.codCuenta))
                                {
                                    CtaCteE oCtaCteDocumento = new CtaCteAD().ObtenerMaeCtaCtePorDocumento(item.idEmpresa, item.idDocumento, item.numSerie, item.numDocumento);

                                    if (oCtaCteDocumento != null)
                                    {
                                        item.tipCambioDoc = oCtaCteDocumento.TipoCambio;
                                        item.numVerPlanCuentas = oCtaCteDocumento.numVerPlanCuentas;
                                        item.codCuenta = oCtaCteDocumento.codCuenta;
                                        item.idCtaCte = oCtaCteDocumento.idCtaCte;
                                    }
                                }

                                switch (item.Opcion)
                                {
                                    case (int)EnumOpcionGrabar.Insertar:

                                        item.tipCanje = tipCanje;
                                        item.codCanje = codCanje;

                                        new LetrasCanjeAD().InsertarLetrasCanje(item);

                                        break;
                                    case (int)EnumOpcionGrabar.Actualizar:

                                        new LetrasCanjeAD().ActualizarLetrasCanje(item);

                                        break;
                                    default:
                                        break;
                                }
                            }

                            //Eliminando si hay letras por eliminar
                            if (oLetraCanjeUnion.LetrasEliminadas != null)
                            {
                                foreach (LetrasE item in oLetraCanjeUnion.LetrasEliminadas)
                                {
                                    new LetrasAD().EliminarLetras(item.idEmpresa, item.idLocal, item.tipCanje, item.codCanje, item.Numero, item.Corre);
                                }
                            }

                            //Insertando o actualizando Letras
                            foreach (LetrasE item in oLetraCanjeUnion.oListaLetras)
                            {
                                switch (item.Opcion)
                                {
                                    case (int)EnumOpcionGrabar.Insertar:

                                        if (item.tipCanje == "RV")
                                        {
                                            numLetra = item.Numero; //Convert.ToInt32(item2.Numero);
                                        }
                                        else
                                        {
                                            numLetra = new LetrasAD().GenerarNumeroLetra(item.idEmpresa, item.idLocal);

                                            if (numLetra == "error")
                                            {
                                                throw new Exception("No se ha configurado correlativo para Letras en Ventas/Maestros/Control de Documento");
                                            }

                                            //Actualizando Correlativo del documento en numControlDet
                                            new NumControlDetAD().ActualizarCorrelativoNumControlDet(item.idEmpresa, item.idLocal, "LT", "", numLetra);
                                        }

                                        item.codCanje = codCanje;
                                        item.Numero = numLetra;
                                        new LetrasAD().InsertarLetras(item);

                                        break;
                                    case (int)EnumOpcionGrabar.Actualizar:

                                        new LetrasAD().ActualizarLetras(item);

                                        break;
                                    default:
                                        break;
                                }
                            }

                            break;
                        default:
                            break;
                    }

                    oTrans.Complete();
                    Grabo = true;
                }

                return Grabo;
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

        public LetrasCanjeUnionE InsertarLetrasCanjeUnion(LetrasCanjeUnionE letrascanjeunion)
        {
            try
            {
                return new LetrasCanjeUnionAD().InsertarLetrasCanjeUnion(letrascanjeunion);
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

        public LetrasCanjeUnionE ActualizarLetrasCanjeUnion(LetrasCanjeUnionE letrascanjeunion)
        {
            try
            {
                return new LetrasCanjeUnionAD().ActualizarLetrasCanjeUnion(letrascanjeunion);
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

        public int EliminarLetrasCanjeUnion(Int32 idEmpresa, Int32 idLocal, String tipCanje, String codCanje)
        {
            try
            {
                return new LetrasCanjeUnionAD().EliminarLetrasCanjeUnion(idEmpresa, idLocal, tipCanje, codCanje);
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

        public List<LetrasCanjeUnionE> ListarLetrasCanjeUnion()
        {
            try
            {
                return new LetrasCanjeUnionAD().ListarLetrasCanjeUnion();
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

        public LetrasCanjeUnionE ObtenerLetrasCanjeUnion(Int32 idEmpresa, Int32 idLocal, String tipCanje, String codCanje)
        {
            try
            {
                LetrasCanjeUnionE oLetrasCanjeUnion = new LetrasCanjeUnionE
                {
                    oListaCanjes = new LetrasCanjeAD().ListarLetrasCanje(idEmpresa, idLocal, tipCanje, codCanje),
                    oListaLetras = new LetrasAD().ListarLetrasPorCanje(idEmpresa, idLocal, tipCanje, codCanje)
                };

                return oLetrasCanjeUnion;
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
        
        public int AprobarLetrasCanjeUnion(Int32 idEmpresa, Int32 idLocal, String tipCanje, String codCanje, DateTime fecAprobacion, String Usuario)
        {
            try
            {
                Int32 Resultado = 0;

                using (TransactionScope oTrans = new TransactionScope())
                {
                    LetrasCanjeUnionE oLetrasCanjeUnion = new LetrasCanjeUnionE
                    {
                        oListaCanjes = new LetrasCanjeAD().ListarLetrasCanje(idEmpresa, idLocal, tipCanje, codCanje),
                        oListaLetras = new LetrasAD().ListarLetrasPorCanje(idEmpresa, idLocal, tipCanje, codCanje)
                    };

                    #region Actualizar fecha de aprobación

                    var ListaTempCanje = oLetrasCanjeUnion.oListaCanjes.GroupBy(x => x.codCanje).Select(p => p.First()).ToList();

                    foreach (var item in ListaTempCanje)
                    {
                        new LetrasCanjeAD().ActualizarFecAprobacionLetrasCanje(item.idEmpresa, item.idLocal, item.tipCanje, item.codCanje, fecAprobacion, Usuario);
                    }

                    #endregion

                    #region CtaCte (Matar Documentos Canjeados)

                    //Letra para poder conseguir los datos del estado anterior en caso se trate de una renovación
                    LetrasE LetraCanje = null;

                    foreach (LetrasCanjeE itemDoc in oLetrasCanjeUnion.oListaCanjes)
                    {
                        itemDoc.fecAprobacion = fecAprobacion;//Ultima fecha actualizada...

                        //Verificando la Cabecera
                        CtaCteE oCtaCteCabecera = new CtaCteAD().ObtenerMaeCtaCtePorId(itemDoc.idCtaCte.Value);

                        if (oCtaCteCabecera == null)
                        {
                            throw new Exception(String.Format("Debe volver a jalar el documento {0} {1}-{2} para poder actualizar su Cta.Cte.", itemDoc.idDocumento, itemDoc.numSerie, itemDoc.numDocumento));
                        }

                        #region Detalle

                        CtaCte_DetE oCtaCteDet = new CtaCte_DetE
                        {
                            idEmpresa = itemDoc.idEmpresa,
                            idCtaCte = oCtaCteCabecera.idCtaCte,
                            idDocumentoMov = itemDoc.idDocumento,
                            SerieMov = itemDoc.numSerie,
                            NumeroMov = itemDoc.numDocumento,
                            FechaMovimiento = Convert.ToDateTime(itemDoc.fecAprobacion), //Se cambió 29-01-2019
                            idMoneda = itemDoc.idMoneda,
                            MontoMov = Convert.ToDecimal(itemDoc.SaldoDoc),
                            TipoCambio = itemDoc.tipCambioDoc,
                            TipAccion = EnumEstadoDocumentos.A.ToString(),
                            numVerPlanCuentas = itemDoc.numVerPlanCuentas,
                            codCuenta = itemDoc.codCuenta,
                            desGlosa = "CANJE DE LETRA " + tipCanje + "-" + codCanje,
                            EsDetraccion = false,
                            UsuarioRegistro = Usuario
                        };

                        oCtaCteDet = new CtaCte_DetAD().InsertarMaeCtaCteDet(oCtaCteDet);

                        #endregion

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
                        if (Saldo == 0 || Saldo == 0M)
                        {
                            oCtaCteCabecera.FechaCancelacion = itemDoc.fecAprobacion.Value; //Se cambió 29-01-2019
                            new CtaCteAD().ActualizarFecCancelacionCtaCte(oCtaCteCabecera.idEmpresa, oCtaCteCabecera.idCtaCte, oCtaCteCabecera.FechaCancelacion, Usuario);
                        }

                        #endregion

                        #region Actualizando los campos Cta.Cte.

                        Int32 idCtaCte = oCtaCteCabecera.idCtaCte;
                        Int32 idCtaCteItem = oCtaCteDet.idCtaCteItem;

                        itemDoc.idCtaCte = idCtaCte;
                        itemDoc.idCtaCteItem = idCtaCteItem;
                        itemDoc.UsuarioModificacion = Usuario;

                        new LetrasCanjeAD().ActualizarLetrasCanjeIdCtaCteItem(itemDoc);

                        #endregion

                        if (itemDoc.idDocumento == "LT" && itemDoc.tipCanje == "RV" && LetraCanje == null)
                        {
                            String Numero = itemDoc.numDocumento.Substring(0, itemDoc.numDocumento.Length - 2);
                            String Correlativo = itemDoc.numDocumento.Replace(Numero, "");

                            LetraCanje = new LetrasAD().ObtenerLetrasPorAuxiliar(idEmpresa, idLocal, "CJ", Numero, Correlativo.Trim(), itemDoc.idPersona);
                        }
                    }

                    #endregion

                    #region CtaCte (Generar Letras)

                    /* E = EN CARTERA
                     * D = DESCUENTO
                     * G = EN GARANTIA
                     * L = COBRANZA LIBRE
                     * P = PROTESTADA*/

                    LetrasEstadoLibroFileE oLibroFileEstadoLetra = new LetrasEstadoLibroFileAD().ObtenerLetrasEstadoLibroFile("E", idEmpresa);
                    String CuentaLetra = String.Empty;
                    String VersionPlan = String.Empty;

                    if (oLibroFileEstadoLetra == null)
                    {
                        throw new Exception("Falta configurar las cuentas Contables para las letras.");
                    }

                    VersionPlan = oLibroFileEstadoLetra.numVerPlanCuentas;

                    foreach (LetrasE itemLetra in oLetrasCanjeUnion.oListaLetras)
                    {
                        if (itemLetra.idMoneda == Variables.Soles)
                        {
                            CuentaLetra = oLibroFileEstadoLetra.CuentaSoles;
                        }
                        else
                        {
                            CuentaLetra = oLibroFileEstadoLetra.CuentaDolares;
                        }

                        if (String.IsNullOrWhiteSpace(CuentaLetra))
                        {
                            throw new Exception("Falta colocar la Cuenta para Letras en Cobranzas/Maestros/");
                        }

                        #region Cabecera

                        CtaCteE oCtaCte = new CtaCteE
                        {
                            idEmpresa = itemLetra.idEmpresa,
                            idPersona = Convert.ToInt32(itemLetra.idPersona),
                            idDocumento = "LT",
                            numSerie = String.Empty,
                            numDocumento = itemLetra.Numero + itemLetra.Corre,
                            idMoneda = itemLetra.idMoneda,
                            MontoOrig = Convert.ToDecimal(itemLetra.MontoOrigen),
                            TipoCambio = Convert.ToDecimal(itemLetra.tipCambio),
                            FechaDocumento = Convert.ToDateTime(itemLetra.Fecha),
                            FechaVencimiento = Convert.ToDateTime(itemLetra.FechaVenc),
                            FechaCancelacion = Convert.ToDateTime("31-12-2100"),
                            numVerPlanCuentas = VersionPlan,
                            codCuenta = CuentaLetra,
                            AnnoVencimiento = String.Empty,
                            MesVencimiento = String.Empty,
                            SemanaVencimiento = String.Empty,
                            desGlosa = "CANJE DE LETRA " + tipCanje + "-" + codCanje,
                            FechaOperacion = Convert.ToDateTime(fecAprobacion), //Se cambió 29-01-2019
                            EsDetraCab = false,
                            idSistema = 2, //Ventas
                            UsuarioRegistro = Usuario
                        };

                        oCtaCte = new CtaCteAD().InsertarMaeCtaCte(oCtaCte);

                        #endregion

                        #region Detalle

                        CtaCte_DetE oCtaCteDet = new CtaCte_DetE
                        {
                            idEmpresa = itemLetra.idEmpresa,
                            idCtaCte = oCtaCte.idCtaCte,
                            idDocumentoMov = "LT",
                            SerieMov = "",
                            NumeroMov = itemLetra.Numero + itemLetra.Corre,
                            FechaMovimiento = Convert.ToDateTime(fecAprobacion), //Se cambió 29-01-2019
                            idMoneda = itemLetra.idMoneda,
                            MontoMov = Convert.ToDecimal(itemLetra.MontoOrigen),
                            TipoCambio = Convert.ToDecimal(itemLetra.tipCambio),
                            TipAccion = EnumEstadoDocumentos.C.ToString(),
                            numVerPlanCuentas = VersionPlan,
                            codCuenta = CuentaLetra,
                            desGlosa = "CANJE DE LETRA " + tipCanje + "-" + codCanje,
                            EsDetraccion = false,
                            UsuarioRegistro = Usuario
                        };

                        oCtaCteDet = new CtaCte_DetAD().InsertarMaeCtaCteDet(oCtaCteDet);

                        #endregion

                        //-- Actualizar el Estado de la Letra a Aceptado y los datos de la Cta. Cte.
                        //-- Estado P=PorAceptar A=Aceptado B=Anulado, Borrado
                        new LetrasAD().ActualizarEstadoDeLetra(itemLetra.idEmpresa, itemLetra.idLocal, itemLetra.tipCanje, itemLetra.codCanje, itemLetra.Numero, itemLetra.Corre, oCtaCte.idCtaCte, oCtaCteDet.idCtaCteItem, "A", Usuario);

                        //Insertando en la tabla estados de la letra
                        //Aceptada en Cartera=E, Cobranza Libre=L, Descuentos=D, Protestada=P
                        LetrasEstadoE oLetraEstado = new LetrasEstadoE()
                        {
                            idEmpresa = itemLetra.idEmpresa,
                            idLocal = itemLetra.idLocal,
                            tipCanje = itemLetra.tipCanje,
                            codCanje = itemLetra.codCanje,
                            Numero = itemLetra.Numero,
                            Corre = itemLetra.Corre,
                            Fecha = fecAprobacion, //Se cambió 29-01-2019
                            Estado = "E",
                            idBanco = null,
                            numVerPlanCuentas = VersionPlan,
                            codCuenta = CuentaLetra,
                            numUnico = String.Empty,
                            UsuarioRegistro = Usuario
                        };

                        new LetrasEstadoAD().InsertarLetrasEstado(oLetraEstado);
                    }

                    #endregion

                    if (tipCanje == "RV" && LetraCanje != null)
                    {
                        List<LetrasEstadoE> Lista = new LetrasEstadoAD().ListarEstadosLetras(LetraCanje.idEmpresa, LetraCanje.idLocal, LetraCanje.tipCanje, LetraCanje.codCanje, LetraCanje.Numero, LetraCanje.Corre);

                        if (Lista.Count > 0)
                        {
                            LetrasEstadoE Letrita = (from x in Lista
                                                     where x.Estado != "E"
                                                     orderby x.item descending
                                                     select x).FirstOrDefault();

                            if (Letrita != null)
                            {
                                //Insertando en la tabla estados de la letra
                                //Aceptada en Cartera=E, Cobranza Libre=L, Descuentos=D, Protestada=P
                                Letrita.tipCanje = oLetrasCanjeUnion.oListaLetras[0].tipCanje;
                                Letrita.codCanje = oLetrasCanjeUnion.oListaLetras[0].codCanje;
                                Letrita.Numero = oLetrasCanjeUnion.oListaLetras[0].Numero;
                                Letrita.Corre = oLetrasCanjeUnion.oListaLetras[0].Corre;
                                Letrita.UsuarioRegistro = Usuario;

                                new LetrasEstadoAD().InsertarLetrasEstado(Letrita);
                            }
                        }
                    }

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

        public String GenerarProvisionLetra(Int32 idEmpresa, Int32 idLocal, String tipCanje, String codCanje, Int32 idPersona, String RazonSocial, String Usuario, String Corregir = "N")
        {
            String Mensaje = String.Empty;

            try
            {
                using (TransactionScope oTrans = new TransactionScope())
                {
                    #region Variables

                    VoucherE oVoucher = new VoucherE();
                    List<LetrasCanjeE> oListaCanjes = new LetrasCanjeAD().ListarLetrasCanjeCtaCte(idEmpresa, idLocal, tipCanje, codCanje);
                    List<LetrasE> oListaLetras = new LetrasAD().ListarLetrasPorCanje(idEmpresa, idLocal, tipCanje, codCanje);
                    ParametrosContaE oParametrosCuentas = new ParametrosContaAD().ObtenerParametrosConta(idEmpresa);
                    LetrasEstadoLibroFileE oLibroFileEstadoLetra = new LetrasEstadoLibroFileAD().ObtenerLetrasEstadoLibroFile("E", idEmpresa);
                    Decimal MontoS = 0; Decimal MontoD = 0; Decimal MontoCanjeS = 0; Decimal MontoCanjeD = 0; Decimal MontoLetraS = 0; Decimal MontoLetraD = 0;
                    DateTime FechaAprobacion = oListaCanjes[0].fecAprobacion.Value; //Se cambió 29-01-2019
                    DateTime FechaMinima = oListaLetras.Min(x => x.Fecha); //Se agregó 29-01-2019
                    Decimal Tica = 0;//Convert.ToDecimal((from x in oListaLetras where x.Fecha.ToString("dd/MM/yy") == FechaProc.ToString("dd/MM/yy") select x.tipCambio).SingleOrDefault());
                    String Moneda = oListaLetras.Min(x => x.idMoneda);
                    String Anio = FechaAprobacion.ToString("yyyy");
                    String Mes = FechaAprobacion.ToString("MM");
                    String Diario = oListaCanjes[0].idComprobante.Trim();
                    String File = oListaCanjes[0].numFile.Trim();
                    String Voucher = oListaCanjes[0].numVoucher;
                    String Glosa = "POR CANJE DE LETRA AUTOMATICO: " + codCanje;
                    String DebeHaber = String.Empty;
                    String codCuentaLetra = String.Empty;
                    String VersionPC = String.Empty;
                    Int32 VoucherTmp = 0;
                    Int32 numItem = 1;

                    #endregion

                    #region Tipo de Cambio

                    if (Corregir == "N")
                    {
                        LetrasE letras = oListaLetras.Find
                        (
                            delegate (LetrasE x) { return x.Fecha.ToString("dd/MM/yy") == FechaMinima.ToString("dd/MM/yy"); }
                        );

                        if (letras != null)
                        {
                            Tica = letras.tipCambio.Value;
                        }
                    }
                    else
                    {
                        TipoCambioE tipoCambio = new TipoCambioAD().ObtenerTipoCambioPorDia(Variables.Dolares, FechaMinima.ToString("yyyyMMdd"));
                        Tica = tipoCambio.valVenta;
                    }

                    #endregion

                    if (oParametrosCuentas == null)
                    {
                        throw new Exception("Falta configurar los Parámetros Contables.");
                    }

                    if (oLibroFileEstadoLetra == null)
                    {
                        throw new Exception("Falta configurar las cuentas para letras en cartera.");
                    }

                    if (Tica.ToString("N3") == "0.000")
                    {
                        throw new Exception(String.Format("La fecha {0} no tiene Tipo de Cambio.", FechaAprobacion.ToString("dd/MM/yyyy")));
                    }

                    #region Cabecera del Voucher

                    //Revisando si existe Voucher
                    if (String.IsNullOrWhiteSpace(Diario) && String.IsNullOrWhiteSpace(File) && String.IsNullOrWhiteSpace(Voucher))
                    {
                        Diario = oLibroFileEstadoLetra.idComprobante;
                        File = oLibroFileEstadoLetra.numFile;

                        VoucherTmp = new VoucherAD().GenerarNumVoucher(idEmpresa, idLocal, Anio, Mes, Diario, File);
                        VoucherTmp++;
                        Voucher = String.Format("{0:000000000}", VoucherTmp);
                        Mensaje = String.Format("Se generó el voucher {0} {1} {2}", Diario, File, Voucher);
                    }
                    else
                    {
                        new VoucherAD().EliminarVoucher(idEmpresa, idLocal, Anio, Mes, Voucher, Diario, File);
                        Mensaje = String.Format("Se actualizó el voucher {0} {1} {2}", Diario, File, Voucher);
                    }

                    //Datos Cabecera
                    oVoucher.idEmpresa = idEmpresa;
                    oVoucher.idLocal = idLocal;
                    oVoucher.AnioPeriodo = Anio;
                    oVoucher.MesPeriodo = Mes;
                    oVoucher.numVoucher = Voucher;
                    oVoucher.idComprobante = Diario;
                    oVoucher.numFile = File;
                    oVoucher.fecTransferencia = null;
                    oVoucher.idMoneda = Moneda;
                    oVoucher.fecOperacion = FechaAprobacion.Date; //Cambia fecha de aprobacion de la letra
                    oVoucher.fecDocumento = FechaMinima.Date; //Fecha minima de lista de las letras
                    oVoucher.GlosaGeneral = Glosa;
                    oVoucher.indEstado = "C";
                    oVoucher.tipCambio = Tica;
                    oVoucher.RazonSocial = RazonSocial;
                    oVoucher.numDocumentoPresu = "VARIOS";
                    oVoucher.indHojaCosto = "N";
                    oVoucher.numHojaCosto = String.Empty;
                    oVoucher.numOrdenCompra = String.Empty;
                    oVoucher.sistema = "2";
                    oVoucher.UsuarioRegistro = Usuario;
                    oVoucher.EsAutomatico = true;

                    #endregion

                    #region Detalle del Voucher

                    //Preparando el detalle del voucher
                    VoucherItemE vItem = null;

                    #region Canjes

                    foreach (LetrasCanjeE itemCanje in oListaCanjes)
                    {
                        DebeHaber = Variables.Haber;

                        if (itemCanje.idMoneda == Variables.Soles)
                        {
                            MontoS = Convert.ToDecimal(itemCanje.SaldoDoc);
                            MontoD = Decimal.Round(Convert.ToDecimal(itemCanje.SaldoDoc) / itemCanje.tipCambioDoc,2); //Tica;
                        }
                        else
                        {
                            MontoS = Decimal.Round(Convert.ToDecimal(itemCanje.SaldoDoc) * itemCanje.tipCambioDoc,2);//Tica;
                            MontoD = Convert.ToDecimal(itemCanje.SaldoDoc);
                        }

                        if (itemCanje.idDocumento == "NC")
                        {
                            MontoCanjeS -= MontoS;
                            MontoCanjeD -= MontoD;
                        }
                        else
                        {
                            MontoCanjeS += MontoS;
                            MontoCanjeD += MontoD;
                        }

                        if (itemCanje.idDocumento == "NC")//Si esta Nota de Crédito
                        {
                            DebeHaber = Variables.Debe;
                            MontoS = Math.Abs(MontoS);
                            MontoD = Math.Abs(MontoD);
                        }

                        //Nuevo Item
                        vItem = new VoucherItemE
                        {
                            idEmpresa = idEmpresa,
                            idLocal = idLocal,
                            AnioPeriodo = Anio,
                            MesPeriodo = Mes,
                            numVoucher = Voucher,
                            idComprobante = Diario,
                            numFile = File,
                            numItem = String.Format("{0:00000}", numItem),
                            idPersona = itemCanje.idPersona,
                            idMoneda = itemCanje.idMoneda,
                            tipCambio = itemCanje.tipCambioDoc,
                            indCambio = Variables.SI,
                            idCCostos = String.Empty,
                            numVerPlanCuentas = itemCanje.numVerPlanCuentas,
                            codCuenta = itemCanje.codCuenta,
                            desGlosa = Glosa,
                            fecDocumento = itemCanje.fecDocumento,
                            fecVencimiento = itemCanje.fecDocumento,
                            idDocumento = itemCanje.idDocumento,
                            serDocumento = itemCanje.numSerie,
                            numDocumento = itemCanje.numDocumento,
                            fecDocumentoRef = null,
                            idDocumentoRef = String.Empty,
                            serDocumentoRef = String.Empty,
                            numDocumentoRef = String.Empty,
                            indDebeHaber = DebeHaber,
                            impSoles = MontoS,
                            impDolares = MontoD,
                            indAutomatica = Variables.NO,
                            CorrelativoAjuste = String.Empty,
                            codFteFin = String.Empty,
                            codProgramaCred = String.Empty,
                            indMovimientoAnterior = Variables.NO,
                            tipPartidaPresu = String.Empty,
                            codPartidaPresu = String.Empty,
                            numDocumentoPresu = itemCanje.idDocumento + " " + itemCanje.numSerie + " " + itemCanje.numDocumento,
                            codColumnaCoven = 0,
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
                            codMedioPago = 0,
                            idCampana = null,
                            idConceptoGasto = null,
                            UsuarioRegistro = Usuario
                        };

                        oVoucher.ListaVouchers.Add(vItem);
                        numItem++;
                    }

                    #endregion

                    #region Letras

                    VersionPC = oLibroFileEstadoLetra.numVerPlanCuentas; // oParametrosCuentas.numVerPlanCuentas;

                    foreach (LetrasE itemLetra in oListaLetras)
                    {
                        DebeHaber = Variables.Haber;

                        if (itemLetra.idMoneda == Variables.Soles)
                        {
                            MontoS = Convert.ToDecimal(itemLetra.MontoOrigen);
                            MontoD = Decimal.Round(Convert.ToDecimal(itemLetra.MontoOrigen) / (Corregir == "N" ? itemLetra.tipCambio.Value : Tica),2);
                            codCuentaLetra = oLibroFileEstadoLetra.CuentaSoles; //oParametrosCuentas.codCtaLetraS;
                        }
                        else
                        {
                            MontoS = Decimal.Round(Convert.ToDecimal(itemLetra.MontoOrigen) * (Corregir == "N" ? itemLetra.tipCambio.Value : Tica),2);
                            MontoD = Convert.ToDecimal(itemLetra.MontoOrigen);
                            codCuentaLetra = oLibroFileEstadoLetra.CuentaDolares; // oParametrosCuentas.codCtaLetraD;
                        }

                        if (String.IsNullOrWhiteSpace(codCuentaLetra))
                        {
                            throw new Exception("Falta colocar la Cuenta para Letras en COBRANZAS/MAESTROS/ESTADOS DE LETRAS");
                        }

                        MontoLetraS += MontoS;
                        MontoLetraD += MontoD;

                        vItem = new VoucherItemE
                        {
                            idEmpresa = idEmpresa,
                            idLocal = idLocal,
                            AnioPeriodo = Anio,
                            MesPeriodo = Mes,
                            numVoucher = Voucher,
                            idComprobante = Diario,
                            numFile = File,
                            numItem = String.Format("{0:00000}", numItem),
                            idPersona = idPersona,
                            idMoneda = itemLetra.idMoneda,
                            tipCambio = (Corregir == "N" ? itemLetra.tipCambio.Value : Tica),//itemLetra.tipCambio.Value,
                            indCambio = Variables.SI,
                            idCCostos = String.Empty,
                            numVerPlanCuentas = VersionPC,
                            codCuenta = codCuentaLetra,
                            desGlosa = Glosa,
                            fecDocumento = itemLetra.Fecha,
                            fecVencimiento = itemLetra.FechaVenc,
                            idDocumento = "LT",
                            serDocumento = String.Empty,
                            numDocumento = itemLetra.Numero + itemLetra.Corre,
                            fecDocumentoRef = null,
                            idDocumentoRef = String.Empty,
                            serDocumentoRef = String.Empty,
                            numDocumentoRef = String.Empty,
                            indDebeHaber = Variables.Debe,
                            impSoles = MontoS,
                            impDolares = MontoD,
                            indAutomatica = Variables.NO,
                            CorrelativoAjuste = String.Empty,
                            codFteFin = String.Empty,
                            codProgramaCred = String.Empty,
                            indMovimientoAnterior = Variables.NO,
                            tipPartidaPresu = String.Empty,
                            codPartidaPresu = String.Empty,
                            numDocumentoPresu = "LT " + " " + itemLetra.Numero + itemLetra.Corre,
                            codColumnaCoven = 0,
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
                            codMedioPago = 0,
                            idCampana = null,
                            idConceptoGasto = null,
                            UsuarioRegistro = Usuario
                        };

                        oVoucher.ListaVouchers.Add(vItem);

                        numItem++;
                    }

                    #endregion

                    //Actualizando datos contables en las letras
                    new LetrasCanjeAD().ActualizarLetrasCanjeConta(idEmpresa, idLocal, tipCanje, codCanje, Diario, File, Anio, Mes, Voucher, Usuario);

                    #region Diferencia 

                    //Si hay diferencia
                    if ((Decimal.Round(MontoCanjeS, 2) != Decimal.Round(MontoLetraS, 2)) || (Decimal.Round(MontoCanjeD, 2) != Decimal.Round(MontoLetraD, 2)))
                    {
                        #region  Ganancia o Pérdida

                        String idCostos = String.Empty; String codCuentaGanPer = String.Empty;
                        Decimal difSoles = 0; Decimal difDolares = 0; Decimal impSoles = 0; Decimal impDolares = 0;

                        idCostos = oParametrosCuentas.Costo;
                        difSoles = Decimal.Round(MontoLetraS,2) - Decimal.Round(MontoCanjeS,2);
                        difDolares = Decimal.Round(MontoLetraD,2) - Decimal.Round(MontoCanjeD,2);

                        if (difSoles != 0)
                        {
                            impSoles = Math.Abs(difSoles);

                            if (difSoles > 0)
                            {
                                DebeHaber = Variables.Haber;
                                codCuentaGanPer = oParametrosCuentas.Ganancia;
                            }
                            else
                            {
                                DebeHaber = Variables.Debe;
                                codCuentaGanPer = oParametrosCuentas.Perdida;
                            }
                        }
                        else
                        {
                            impDolares = Math.Abs(difDolares);

                            if (difDolares > 0)
                            {
                                DebeHaber = Variables.Haber;
                                codCuentaGanPer = oParametrosCuentas.Ganancia;
                            }
                            else
                            {
                                DebeHaber = Variables.Debe;
                                codCuentaGanPer = oParametrosCuentas.Perdida;
                            }
                        }

                        if (String.IsNullOrWhiteSpace(codCuentaGanPer))
                        {
                            throw new Exception("Falta configurar la Cuenta de Ganancia o Pérdida en Parámetros Contables.");
                        }

                        PlanCuentasE oCuentaContable = new PlanCuentasAD().ObtenerPlanCuentasPorCodigo(idEmpresa, VersionPC, codCuentaGanPer);

                        //Agregando las lineas al detalle
                        vItem = new VoucherItemE
                        {
                            idEmpresa = idEmpresa,
                            idLocal = idLocal,
                            AnioPeriodo = Anio,
                            MesPeriodo = Mes,
                            numVoucher = Voucher,
                            idComprobante = Diario,
                            numFile = File,
                            numItem = String.Format("{0:00000}", numItem),
                            idPersona = idPersona,
                            idMoneda = Moneda,
                            tipCambio = 0,
                            indCambio = Variables.NO,
                            idCCostos = idCostos,
                            numVerPlanCuentas = VersionPC,
                            codCuenta = codCuentaGanPer,
                            desGlosa = oCuentaContable.Descripcion,
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
                            indMovimientoAnterior = Variables.NO,
                            tipPartidaPresu = String.Empty,
                            codPartidaPresu = String.Empty,
                            numDocumentoPresu = String.Empty,
                            codColumnaCoven = 0,
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
                            codMedioPago = 0,
                            idCampana = null,
                            idConceptoGasto = null,
                            UsuarioRegistro = Usuario
                        };

                        oVoucher.ListaVouchers.Add(vItem);
                        numItem++;

                        #endregion

                        //Si Indica Gastos
                        if (oCuentaContable.indCuentaGastos == "S")
                        {
                            String ctaDestino = oCuentaContable.codCuentaDestino;
                            String ctaTransferencia = oCuentaContable.codCuentaTransferencia;

                            if (String.IsNullOrWhiteSpace(ctaDestino) || String.IsNullOrWhiteSpace(ctaTransferencia))
                            {
                                throw new Exception("Falta configurar la cuenta de destino o la cuenta de transferencia en el Plan de Cuentas.");
                            }

                            #region Destino

                            oCuentaContable = new PlanCuentasAD().ObtenerPlanCuentasPorCodigo(idEmpresa, VersionPC, ctaDestino);

                            //Agregando las lineas al detalle
                            vItem = new VoucherItemE
                            {
                                idEmpresa = idEmpresa,
                                idLocal = idLocal,
                                AnioPeriodo = Anio,
                                MesPeriodo = Mes,
                                numVoucher = Voucher,
                                idComprobante = Diario,
                                numFile = File,
                                numItem = String.Format("{0:00000}", numItem),
                                idPersona = idPersona,
                                idMoneda = Moneda,
                                tipCambio = 0,
                                indCambio = Variables.SI,
                                idCCostos = String.Empty,
                                numVerPlanCuentas = VersionPC,
                                codCuenta = ctaDestino,
                                desGlosa = oCuentaContable.Descripcion,
                                fecDocumento = null,
                                fecVencimiento = null,
                                idDocumento = String.Empty,
                                serDocumento = String.Empty,
                                numDocumento = String.Empty,
                                fecDocumentoRef = null,
                                idDocumentoRef = String.Empty,
                                serDocumentoRef = String.Empty,
                                numDocumentoRef = String.Empty,
                                indDebeHaber = oCuentaContable.indNaturalezaCta,
                                impSoles = impSoles,
                                impDolares = impDolares,
                                indAutomatica = Variables.SI,
                                CorrelativoAjuste = String.Empty,
                                codFteFin = String.Empty,
                                codProgramaCred = String.Empty,
                                indMovimientoAnterior = Variables.NO,
                                tipPartidaPresu = String.Empty,
                                codPartidaPresu = String.Empty,
                                numDocumentoPresu = String.Empty,
                                codColumnaCoven = 0,
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
                                codMedioPago = 0,
                                idCampana = null,
                                idConceptoGasto = null,
                                UsuarioRegistro = Usuario
                            };

                            oVoucher.ListaVouchers.Add(vItem);
                            numItem++;

                            #endregion

                            #region Transferencia

                            oCuentaContable = new PlanCuentasAD().ObtenerPlanCuentasPorCodigo(idEmpresa, VersionPC, ctaTransferencia);

                            //Agregando las lineas al detalle
                            vItem = new VoucherItemE
                            {
                                idEmpresa = idEmpresa,
                                idLocal = idLocal,
                                AnioPeriodo = Anio,
                                MesPeriodo = Mes,
                                numVoucher = Voucher,
                                idComprobante = Diario,
                                numFile = File,
                                numItem = String.Format("{0:00000}", numItem),
                                idPersona = idPersona,
                                idMoneda = Moneda,
                                tipCambio = 0,
                                indCambio = Variables.NO,
                                idCCostos = String.Empty,
                                numVerPlanCuentas = VersionPC,
                                codCuenta = ctaTransferencia,
                                desGlosa = oCuentaContable.Descripcion,
                                fecDocumento = null,
                                fecVencimiento = null,
                                idDocumento = String.Empty,
                                serDocumento = String.Empty,
                                numDocumento = String.Empty,
                                fecDocumentoRef = null,
                                idDocumentoRef = String.Empty,
                                serDocumentoRef = String.Empty,
                                numDocumentoRef = String.Empty,
                                indDebeHaber = oCuentaContable.indNaturalezaCta,
                                impSoles = impSoles,
                                impDolares = impDolares,
                                indAutomatica = Variables.SI,
                                CorrelativoAjuste = String.Empty,
                                codFteFin = String.Empty,
                                codProgramaCred = String.Empty,
                                indMovimientoAnterior = Variables.NO,
                                tipPartidaPresu = String.Empty,
                                codPartidaPresu = String.Empty,
                                numDocumentoPresu = String.Empty,
                                codColumnaCoven = 0,
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
                                codMedioPago = 0,
                                idCampana = null,
                                idConceptoGasto = null,
                                UsuarioRegistro = Usuario
                            };

                            oVoucher.ListaVouchers.Add(vItem);

                            #endregion

                        }
                    }

                    #endregion

                    #endregion

                    //Insertando los Vouchers
                    Decimal totDebeSoles = Decimal.Round((from x in oVoucher.ListaVouchers where x.indDebeHaber == Variables.Debe select x.impSoles).Sum(), 2);
                    Decimal totDebeDolares = Decimal.Round((from x in oVoucher.ListaVouchers where x.indDebeHaber == Variables.Debe select x.impDolares).Sum(), 2);
                    Decimal totHaberSoles = Decimal.Round((from x in oVoucher.ListaVouchers where x.indDebeHaber == Variables.Haber select x.impSoles).Sum(), 2);
                    Decimal totHaberDolares = Decimal.Round((from x in oVoucher.ListaVouchers where x.indDebeHaber == Variables.Haber select x.impDolares).Sum(), 2);

                    //Datos faltantes de la cabecera
                    oVoucher.numItems = oVoucher.ListaVouchers.Count();
                    oVoucher.impDebeSoles = totDebeSoles;
                    oVoucher.impHaberSoles = totHaberSoles;
                    oVoucher.impDebeDolares = totDebeDolares;
                    oVoucher.impHaberDolares = totHaberDolares;

                    new VoucherAD().InsertarVoucher(oVoucher);

                    foreach (VoucherItemE item in oVoucher.ListaVouchers)
                    {
                        new VoucherItemAD().InsertarVoucherItem(item);
                    }

                    oTrans.Complete();
                }

                return Mensaje;
            }
            catch (SqlException ex)
            {
                SqlError err = ex.Errors[0];
                StringBuilder mensaje = new StringBuilder();
                Mensaje = String.Empty;

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

        public int DesaprobarLetras(LetrasE oLetra, String Usuario)
        {
            try
            {
                Int32 Resultado = 0;

                using (TransactionScope oTrans = new TransactionScope())
                {
                    //Eliminando el voucher
                    new VoucherAD().EliminarVoucher(oLetra.idEmpresa, oLetra.idLocal, oLetra.AnioPeriodo, oLetra.MesPeriodo, oLetra.numVoucher, oLetra.idComprobante, oLetra.numFile);

                    //Eliminando las Letras
                    LetrasCanjeUnionE oLetrasCanjeUnion = new LetrasCanjeUnionE
                    {
                        oListaCanjes = new LetrasCanjeAD().ListarLetrasCanje(oLetra.idEmpresa, oLetra.idLocal, oLetra.tipCanje, oLetra.codCanje),
                        oListaLetras = new LetrasAD().ListarLetrasPorCanje(oLetra.idEmpresa, oLetra.idLocal, oLetra.tipCanje, oLetra.codCanje)
                    };

                    #region Actualizar fecha de aprobación

                    var ListaTempCanje = oLetrasCanjeUnion.oListaCanjes.GroupBy(x => x.codCanje).Select(p => p.First()).ToList();

                    foreach (var item in ListaTempCanje)
                    {
                        new LetrasCanjeAD().ActualizarFecAprobacionLetrasCanje(item.idEmpresa, item.idLocal, item.tipCanje, item.codCanje, (DateTime?)null, Usuario);
                    }

                    #endregion

                    #region CtaCte Documentos de Ventas

                    foreach (LetrasCanjeE docItem in oLetrasCanjeUnion.oListaCanjes)
                    {
                        //Eliminando de la Cta.Cte. Detalle
                        new CtaCte_DetAD().EliminarMaeCtaCteDetallePorIdItem(docItem.idCtaCteItem.Value);
                        //Obteniendo la cabecera de la Cta.Cte.
                        CtaCteE oCtaCteCabecera = new CtaCteAD().ObtenerMaeCtaCtePorId(docItem.idCtaCte.Value);

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

                            // Si el saldo es diferente de 0 vuelve a habilitar el documento en la cta.cte.
                            if (Saldo != 0)
                            {
                                new CtaCteAD().ActualizarFecCancelacionCtaCte(oCtaCteCabecera.idEmpresa, oCtaCteCabecera.idCtaCte, Convert.ToDateTime("31-12-2100"), Usuario);
                            }
                        }

                        #endregion

                        #region Actualizando los campos Cta.Cte.

                        //docItem.idCtaCte = idCtaCte;
                        docItem.idCtaCteItem = null;
                        docItem.UsuarioModificacion = Usuario;

                        new LetrasCanjeAD().ActualizarLetrasCanjeIdCtaCteItem(docItem);

                        #endregion
                    }

                    #endregion

                    #region CtaCte Letras

                    foreach (LetrasE itemLetra in oLetrasCanjeUnion.oListaLetras)
                    {
                        //Revisando si existen abonos
                        List<CtaCte_DetE> oListaAbonos = new CtaCte_DetAD().ListarMaeCtaCteDetAbonos(itemLetra.idEmpresa, itemLetra.idCtaCte.Value);

                        if (oListaAbonos != null && oListaAbonos.Count > 0)
                        {
                            throw new Exception(String.Format("No se puede desaprobar el {0} {1} porque la Letra {2}-{3} ya tiene Abonos.", itemLetra.tipCanje, itemLetra.codCanje, itemLetra.Numero, itemLetra.Corre));
                        }
                        else
                        {
                            //Eliminando de la Cta.Cte. de la Letra... cabecera - detalle
                            new CtaCteAD().EliminarMaeCtaCteConDetalle(itemLetra.idCtaCte.Value);

                            //Eliminando el estado de la letra en cartera
                            new LetrasEstadoAD().EliminarLetrasEstado(itemLetra.idEmpresa, itemLetra.idLocal, itemLetra.tipCanje, itemLetra.codCanje, itemLetra.Numero, itemLetra.Corre);

                            //Actualizar Estado Aceptado a la Letra
                            //-- Estado P=PorAceptar A=Aceptado B=Anular, Borrar
                            new LetrasAD().ActualizarEstadoDeLetra(itemLetra.idEmpresa, itemLetra.idLocal, itemLetra.tipCanje, itemLetra.codCanje, itemLetra.Numero, itemLetra.Corre, null, null, "P", Usuario);
                        }
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

        public List<LetrasCanjeUnionE> ReporteCanjeLetra(Int32 idEmpresa, Int32 idLocal, String tipCanje, String codCanje)
        {
            try
            {
                return new LetrasCanjeUnionAD().ReporteCanjeLetra(idEmpresa, idLocal, tipCanje, codCanje);
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

        public List<LetrasCanjeUnionE> ReporteCanjeLetraPorEstado(Int32 idEmpresa, Int32 idLocal, Int32 idPersona, String Estado)
        {
            try
            {
                return new LetrasCanjeUnionAD().ReporteCanjeLetraPorEstado(idEmpresa,idLocal,idPersona,Estado);
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

        public int ActualizarLetraDocCtaCte(Int32 idEmpresa, Int32 idLocal, String tipCanje, String codCanje)
        {
            try
            {
                Int32 resp = 0;
                List<LetrasCanjeE> oListaCanjes = new LetrasCanjeAD().ListarLetrasCanje(idEmpresa, idLocal, tipCanje, codCanje);

                foreach (LetrasCanjeE item in oListaCanjes)
                {
                    CtaCteE oCtaCteDocumento = new CtaCteAD().ObtenerMaeCtaCtePorDocumento(item.idEmpresa, item.idDocumento, item.numSerie, item.numDocumento);

                    if (oCtaCteDocumento != null)
                    {
                        new LetrasCanjeAD().ActualizarLetrasCanjeIdCtaCte(item.idEmpresa, item.idLocal, item.tipCanje, item.codCanje, item.idDocumento, item.numSerie, item.numDocumento, oCtaCteDocumento.TipoCambio, oCtaCteDocumento.numVerPlanCuentas, oCtaCteDocumento.codCuenta, oCtaCteDocumento.idCtaCte);
                        resp++;
                    }
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

        public String CorregirLetraTicaCteCte(Int32 idEmpresa, Int32 idLocal, String tipCanje, String codCanje, String Usuario)
        {
            try
            {
                String resp = String.Empty;

                using (TransactionScope oTrans = new TransactionScope())
                {
                    List<LetrasE> oListaCanjes = new LetrasAD().ListarLetrasPorCanje(idEmpresa, idLocal, tipCanje, codCanje);

                    foreach (LetrasE item in oListaCanjes)
                    {
                        TipoCambioE tipoCambio = new TipoCambioAD().ObtenerTipoCambioPorDia(Variables.Dolares, item.Fecha.ToString("yyyyMMdd"));
                        item.tipCambio = tipoCambio.valVenta;
                        item.UsuarioModificacion = Usuario;

                        if (item.idMoneda == "01")
                        {
                            item.MontoRefe = Decimal.Round(item.MontoOrigen / tipoCambio.valVenta, 2);
                        }
                        else
                        {
                            item.MontoRefe = Decimal.Round(item.MontoOrigen * tipoCambio.valVenta, 2);
                        }

                        //Actualizando las Letras
                        new LetrasAD().ActualizarLetrasTica(item);
                        //Actualizando la CtaCte
                        new CtaCteAD().ActualizarTicaCtaCteLetras(item.idCtaCte.Value, tipoCambio.valVenta);
                    }

                    //Volviendo a generar el asiento...
                    resp = GenerarProvisionLetra(idEmpresa, idLocal, tipCanje, codCanje, oListaCanjes[0].idPersona, oListaCanjes[0].RazonSocial, Usuario);
                    //Completando la Transacción...
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
