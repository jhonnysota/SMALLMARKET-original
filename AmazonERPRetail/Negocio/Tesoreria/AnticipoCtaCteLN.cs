using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Transactions;

using Entidades.Tesoreria;
using Entidades.CtasPorPagar;
using Entidades.Ventas;
using Entidades.Contabilidad;
using AccesoDatos.Tesoreria;
using AccesoDatos.Contabilidad;
using AccesoDatos.CtasPorPagar;
using Infraestructura;
using Infraestructura.Enumerados;

namespace Negocio.Tesoreria
{
    public class AnticipoCtaCteLN
    {

        public AnticipoCtaCteE InsertarAnticipoCtaCte(AnticipoCtaCteE ctacte)
        {
            try
            {
                return new AnticipoCtaCteAD().InsertarAnticipoCtaCte(ctacte);
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

        public AnticipoCtaCteE ActualizarAnticipoCtaCte(AnticipoCtaCteE ctacte)
        {
            try
            {
                return new AnticipoCtaCteAD().ActualizarAnticipoCtaCte(ctacte);
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

        public List<AnticipoCtaCteE> ListarAnticipoCtaCte()
        {
            try
            {
                return new AnticipoCtaCteAD().ListarAnticipoCtaCte();
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

        public List<AnticipoCtaCteE> ObtenerAnticipoCtaCtePorParametros(Int32 idEmpresa, Int32 idPersona, DateTime fecFiltro, Int32 idSistema)
        {
            try
            {
                return new AnticipoCtaCteAD().ObtenerAnticipoCtaCtePorParametros(idEmpresa, idPersona, fecFiltro, idSistema);
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

        public List<AnticipoCtaCteE> ObtenerAnticipoCtaCteLetras(Int32 idEmpresa, Int32 idPersona, DateTime fecFiltro, Int32 idSistema)
        {
            try
            {

                return new AnticipoCtaCteAD().ObtenerAnticipoCtaCteLetras(idEmpresa, idPersona, fecFiltro, idSistema);

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

        public List<AnticipoCtaCteE> ObtenerAnticipoCtaCteDetallado(Int32 idEmpresa, Int32 idPersona, DateTime fecFiltro, Int32 idSistema)
        {
            try
            {
                return new AnticipoCtaCteAD().ObtenerAnticipoCtaCteDetallado(idEmpresa, idPersona, fecFiltro, idSistema);
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

        public List<AnticipoCtaCteE> AnticipoCtaCteDetalladoVentas(Int32 idEmpresa, Int32 idPersona, DateTime fecFiltro, Int32 idSistema)
        {
            try
            {
                return new AnticipoCtaCteAD().AnticipoCtaCteDetalladoVentas(idEmpresa, idPersona, fecFiltro, idSistema);
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

        public List<AnticipoCtaCteE> ConsultaAnticipoCtaCteDet(Int32 idEmpresa, Int32 IdPersona, DateTime fecFiltro, String Opcion, Boolean EsDetraccion)
        {
            try
            {
                List<AnticipoCtaCteE> oListaFinal = new List<AnticipoCtaCteE>();
                List<AnticipoCtaCteE> oListaCtaCte = new AnticipoCtaCteAD().ConsultaAnticipoCtaCteDet(idEmpresa, IdPersona, fecFiltro, Opcion, EsDetraccion);

                foreach (AnticipoCtaCteE item in oListaCtaCte)
                {
                    if (item.Saldo < Variables.Cero)
                    {
                        item.indDebeHaber = Variables.Haber;
                    }
                    else
                    {
                        item.indDebeHaber = Variables.Debe;
                    }

                    item.oProvisionDet = new Provisiones_PorCCostoAD().RecuperarProvisionDetAnticipo(item.idProvisionOrigen);
                    oListaFinal.Add(item);
                }

                return oListaFinal;
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

        public List<AnticipoCtaCteE> ConsultaAnticipoCtaCteDetVentas(Int32 idEmpresa, Int32 idPersona, DateTime fecFiltro, String Tipo)
        {
            try
            {
                return new AnticipoCtaCteAD().ConsultaAnticipoCtaCteDetVentas(idEmpresa, idPersona, fecFiltro, Tipo);
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

        public List<AnticipoCtaCteE> ObtenerAnticipoCtaCtePorCuenta(Int32 idEmpresa, Int32 idPersona, DateTime fecFiltro)
        {
            try
            {
                return new AnticipoCtaCteAD().ObtenerAnticipoCtaCtePorCuenta(idEmpresa, idPersona, fecFiltro);
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

        public List<AnticipoCtaCteE> ObtenerAnticipoCtaCteGeneral(Int32 idEmpresa, String filtro, DateTime fecFiltro)
        {
            try
            {
                return new AnticipoCtaCteAD().ObtenerAnticipoCtaCteGeneral(idEmpresa, filtro, fecFiltro);
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

        public List<AnticipoCtaCteE> ObtenerAnticipoCtaCtePartida(Int32 idEmpresa, String filtro, DateTime fecFiltro)
        {
            try
            {
                return new AnticipoCtaCteAD().ObtenerAnticipoCtaCtePartida(idEmpresa, filtro, fecFiltro);
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

        public Int32 EliminarAnticipoCtaCteMasivo(Int32 idEmpresa, Int32 idSistema, DateTime fecIni, DateTime fecFin)
        {
            try
            {
                return new AnticipoCtaCteAD().EliminarAnticipoCtaCteMasivo(idEmpresa, idSistema, fecIni, fecFin);
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

        public Int32 TransferirAnticipoCtaCte(List<ProvisionesE> oListaCompras, List<EmisionDocumentoE> oListaVentas, Int32 idSistema, String Usuario)
        {
            try
            {
                Int32 resp = 0;
                Int32 idCtaCte = 0;
                Int32 idCtaCteItem = 0;
                String CuentaDetra = String.Empty;
                ParametrosContaE oParametroConta = null;
                TransactionOptions Opciones = new TransactionOptions()
                {
                    Timeout = TimeSpan.FromMinutes(10)
                };

                using (TransactionScope oTrans = new TransactionScope(TransactionScopeOption.Required, Opciones))
                {
                    if (oListaCompras != null && oListaCompras.Count > 0)
                    {
                        foreach (ProvisionesE item in oListaCompras)
                        {
                            resp++;

                            #region Cabecera

                            AnticipoCtaCteE oCtaCte = new AnticipoCtaCteE
                            {
                                idEmpresa = item.idEmpresa,
                                idPersona = Convert.ToInt32(item.idPersona),
                                idDocumento = item.idDocumento,
                                numSerie = item.NumSerie,
                                numDocumento = item.NumDocumento,
                                idMoneda = item.CodMonedaProvision,
                                MontoOrig = Convert.ToDecimal(item.ImpMonedaOrigen),
                                TipoCambio = Convert.ToDecimal(item.TipCambio),
                                FechaDocumento = Convert.ToDateTime(item.FechaDocumento),
                                FechaVencimiento = Convert.ToDateTime(item.FechaVencimiento),
                                FechaCancelacion = Convert.ToDateTime("31-12-2100"),
                                numVerPlanCuentas = item.NumVerPlanCuentas,
                                codCuenta = item.codCuenta,
                                AnnoVencimiento = String.Empty,
                                MesVencimiento = String.Empty,
                                SemanaVencimiento = String.Empty,
                                tipPartidaPresu = String.Empty,
                                codPartidaPresu = String.Empty,
                                desGlosa = item.DesProvision,
                                FechaOperacion = Convert.ToDateTime(item.FechaDocumento),
                                EsDetraCab = false,
                                idCtaCteOrigen = 0,
                                idSistema = idSistema,
                                UsuarioRegistro = Usuario
                            };

                            new AnticipoCtaCteAD().InsertarAnticipoCtaCte(oCtaCte);

                            //Obteniendo el id de la ctacte...
                            idCtaCte = oCtaCte.idCtaCte;

                            #endregion

                            #region Detalle

                            AnticipoCtaCteDetE oCtaCteDet = new AnticipoCtaCteDetE
                            {
                                idEmpresa = item.idEmpresa,
                                idCtaCte = idCtaCte,
                                idDocumentoMov = item.idDocumento,
                                SerieMov = item.NumSerie,
                                NumeroMov = item.NumDocumento,
                                FechaMovimiento = Convert.ToDateTime(item.FechaDocumento),
                                idMoneda = item.CodMonedaProvision,
                                MontoMov = Convert.ToDecimal(item.ImpMonedaOrigen),
                                TipoCambio = Convert.ToDecimal(item.TipCambio),
                                TipAccion = EnumEstadoDocumentos.C.ToString(),
                                numVerPlanCuentas = item.NumVerPlanCuentas,
                                codCuenta = item.codCuenta,
                                desGlosa = item.DesProvision,
                                EsDetraccion = false,
                                UsuarioRegistro = Usuario
                            };

                            new AnticipoCtaCteDetAD().InsertarAnticipoCtaCteDet(oCtaCteDet);

                            //Recuperando el item
                            idCtaCteItem = oCtaCteDet.idCtaCteItem;

                            #endregion

                            //Actualizando la los Id de la CtaCte en la provisión
                            new ProvisionesAD().ActualizarIdCtaCteProvision(item.idProvision, idCtaCte, idCtaCteItem, Usuario);

                            //Si la empresa paga la detracción
                            if (item.flagDetraccion)
                            {
                                #region Abono de CtaCte padre donde se origina la detracción

                                oCtaCteDet = new AnticipoCtaCteDetE
                                {
                                    idEmpresa = item.idEmpresa,
                                    idCtaCte = idCtaCte,
                                    idDocumentoMov = item.idDocumento,
                                    SerieMov = item.NumSerie,
                                    NumeroMov = item.NumDocumento,
                                    FechaMovimiento = Convert.ToDateTime(item.FechaDocumento),
                                    idMoneda = item.CodMonedaProvision,
                                    MontoMov = Convert.ToDecimal(item.MontoDetraccion),
                                    TipoCambio = Convert.ToDecimal(item.TipCambio),
                                    TipAccion = EnumEstadoDocumentos.A.ToString(),
                                    numVerPlanCuentas = item.NumVerPlanCuentas,
                                    codCuenta = item.codCuenta,
                                    desGlosa = item.DesProvision,
                                    EsDetraccion = true,
                                    UsuarioRegistro = Usuario
                                };

                                new AnticipoCtaCteDetAD().InsertarAnticipoCtaCteDet(oCtaCteDet);

                                #endregion

                                if (item.indPagoDetra)
                                {
                                    #region Cabecera Detraccion

                                    oParametroConta = new ParametrosContaAD().ObtenerParametrosConta(item.idEmpresa);

                                    if (item.CodMonedaProvision == Variables.Soles)
                                    {
                                        CuentaDetra = oParametroConta.ctaDetraccion;
                                    }
                                    else
                                    {
                                        CuentaDetra = oParametroConta.ctaDetraccionDol;
                                    }

                                    oCtaCte = new AnticipoCtaCteE
                                    {
                                        idEmpresa = item.idEmpresa,
                                        idPersona = Convert.ToInt32(item.idPersona),
                                        idDocumento = item.idDocumento,
                                        numSerie = item.NumSerie,
                                        numDocumento = item.NumDocumento,
                                        idMoneda = item.CodMonedaProvision,
                                        MontoOrig = Convert.ToDecimal(item.MontoDetraccion),
                                        TipoCambio = Convert.ToDecimal(item.TipCambio),
                                        FechaDocumento = Convert.ToDateTime(item.FechaDocumento),
                                        FechaVencimiento = Convert.ToDateTime(item.FechaVencimiento),
                                        FechaCancelacion = Convert.ToDateTime("31-12-2100"),
                                        numVerPlanCuentas = item.NumVerPlanCuentas,
                                        codCuenta = CuentaDetra,
                                        AnnoVencimiento = String.Empty,
                                        MesVencimiento = String.Empty,
                                        SemanaVencimiento = String.Empty,
                                        tipPartidaPresu = String.Empty,
                                        codPartidaPresu = String.Empty,
                                        desGlosa = item.DesProvision,
                                        FechaOperacion = Convert.ToDateTime(item.FechaDocumento),
                                        EsDetraCab = true,
                                        idCtaCteOrigen = idCtaCte,
                                        idSistema = idSistema,
                                        UsuarioRegistro = Usuario
                                    };

                                    new AnticipoCtaCteAD().InsertarAnticipoCtaCte(oCtaCte);

                                    //Obteniendo el id de la ctacte...
                                    idCtaCte = oCtaCte.idCtaCte;

                                    #endregion

                                    #region Detalle de la detracción

                                    oCtaCteDet = new AnticipoCtaCteDetE //Cargo
                                    {
                                        idEmpresa = item.idEmpresa,
                                        idCtaCte = idCtaCte,
                                        idDocumentoMov = item.idDocumento,
                                        SerieMov = item.NumSerie,
                                        NumeroMov = item.NumDocumento,
                                        FechaMovimiento = Convert.ToDateTime(item.FechaDocumento),
                                        idMoneda = item.CodMonedaProvision,
                                        MontoMov = Convert.ToDecimal(item.MontoDetraccion),
                                        TipoCambio = Convert.ToDecimal(item.TipCambio),
                                        TipAccion = EnumEstadoDocumentos.C.ToString(),
                                        numVerPlanCuentas = item.NumVerPlanCuentas,
                                        codCuenta = CuentaDetra,
                                        desGlosa = item.DesProvision,
                                        EsDetraccion = true,
                                        UsuarioRegistro = Usuario
                                    };

                                    new AnticipoCtaCteDetAD().InsertarAnticipoCtaCteDet(oCtaCteDet);

                                    #endregion
                                } 
                            }
                        }
                    }

                    if (oListaVentas != null && oListaVentas.Count > 0)
                    {
                        //#region CtaCte

                        //if ((DocumentoTmp.idDocumento == EnumTipoDocumentoVenta.FV.ToString() ||
                        //    DocumentoTmp.idDocumento == EnumTipoDocumentoVenta.BV.ToString() ||
                        //    DocumentoTmp.idDocumento == EnumTipoDocumentoVenta.NC.ToString() ||
                        //    DocumentoTmp.idDocumento == EnumTipoDocumentoVenta.ND.ToString()) && indEstado == EnumEstadoDocumentos.E.ToString())
                        //{
                        //    ParametrosContaE oParametroConta = new ParametrosContaAD().ObtenerParametrosConta(idEmpresa);
                        //    String Cuenta = String.Empty;

                        //    if (DocumentoTmp.idMoneda == Variables.Soles)
                        //    {
                        //        Cuenta = oParametroConta.VentaS;
                        //    }
                        //    else
                        //    {
                        //        Cuenta = oParametroConta.VentaD;
                        //    }

                        //    if (String.IsNullOrWhiteSpace(Cuenta))
                        //    {
                        //        throw new Exception("Falta configurar las cuentas para ventas en Parámetros Contables.");
                        //    }

                        //    #region Cabecera

                        //    CtaCteE oCtaCte = new CtaCteE
                        //    {
                        //        idEmpresa = DocumentoTmp.idEmpresa,
                        //        idPersona = Convert.ToInt32(DocumentoTmp.idPersona),
                        //        idDocumento = DocumentoTmp.idDocumento,
                        //        numSerie = DocumentoTmp.numSerie,
                        //        numDocumento = DocumentoTmp.numDocumento,
                        //        idMoneda = DocumentoTmp.idMoneda,
                        //        MontoOrig = Convert.ToDecimal(DocumentoTmp.totTotal),
                        //        TipoCambio = Convert.ToDecimal(DocumentoTmp.tipCambio),
                        //        FechaDocumento = Convert.ToDateTime(DocumentoTmp.fecEmision),
                        //        FechaVencimiento = Convert.ToDateTime(DocumentoTmp.fecVencimiento),
                        //        FechaCancelacion = Convert.ToDateTime("31-12-2100"),
                        //        numVerPlanCuentas = oParametroConta.numVerPlanCuentas,
                        //        codCuenta = Cuenta,
                        //        AnnoVencimiento = String.Empty,
                        //        MesVencimiento = String.Empty,
                        //        SemanaVencimiento = String.Empty,
                        //        tipPartidaPresu = String.Empty,
                        //        codPartidaPresu = String.Empty,
                        //        desGlosa = DocumentoTmp.Glosa,
                        //        FechaOperacion = Convert.ToDateTime(DocumentoTmp.fecEmision),
                        //        EsDetraCab = false,
                        //        idCtaCteOrigen = 0,
                        //        idSistema = 2,
                        //        UsuarioRegistro = DocumentoTmp.UsuarioRegistro
                        //    };

                        //    oCtaCte = new CtaCteAD().InsertarMaeCtaCte(oCtaCte);

                        //    #endregion

                        //    #region Detalle

                        //    CtaCte_DetE oCtaCteDet = new CtaCte_DetE
                        //    {
                        //        idEmpresa = DocumentoTmp.idEmpresa,
                        //        idCtaCte = oCtaCte.idCtaCte,
                        //        idDocumentoMov = DocumentoTmp.idDocumento,
                        //        SerieMov = DocumentoTmp.numSerie,
                        //        NumeroMov = DocumentoTmp.numDocumento,
                        //        FechaMovimiento = Convert.ToDateTime(DocumentoTmp.fecEmision),
                        //        idMoneda = DocumentoTmp.idMoneda,
                        //        MontoMov = Convert.ToDecimal(DocumentoTmp.totTotal),
                        //        TipoCambio = Convert.ToDecimal(DocumentoTmp.tipCambio),
                        //        TipAccion = EnumEstadoDocumentos.C.ToString(),
                        //        numVerPlanCuentas = oParametroConta.numVerPlanCuentas,
                        //        codCuenta = Cuenta,
                        //        desGlosa = DocumentoTmp.Glosa,
                        //        EsDetraccion = false,
                        //        UsuarioRegistro = DocumentoTmp.UsuarioRegistro
                        //    };

                        //    new CtaCte_DetAD().InsertarMaeCtaCteDet(oCtaCteDet);

                        //    #endregion
                        //}

                        //#endregion CtaCte
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

        public AnticipoCtaCteE ObtenerAnticipoCtaCtePorDocumento(Int32 idEmpresa, String idDocumento, String NumSerie, String NumDocumento)
        {
            try
            {
                return new AnticipoCtaCteAD().ObtenerAnticipoCtaCtePorDocumento(idEmpresa, idDocumento, NumSerie, NumDocumento);
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

        public List<AnticipoCtaCteE> ReporteAnticipoCtaCteComparado(Int32 idEmpresa, Int32 idPersona, DateTime fecFiltro)
        {
            try
            {
                return new AnticipoCtaCteAD().ReporteAnticipoCtaCteComparado(idEmpresa, idPersona, fecFiltro);
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
