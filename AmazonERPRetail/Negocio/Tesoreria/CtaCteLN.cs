using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Transactions;
using System.Linq;

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
    public class CtaCteLN
    {

        public CtaCteE InsertarMaeCtaCte(CtaCteE ctacte)
        {
            try
            {
                return new CtaCteAD().InsertarMaeCtaCte(ctacte);
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

        public CtaCteE ActualizarMaeCtaCte(CtaCteE ctacte)
        {
            try
            {
                return new CtaCteAD().ActualizarMaeCtaCte(ctacte);
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

        public List<CtaCteE> ListarMaeCtaCte()
        {
            try
            {
                return new CtaCteAD().ListarMaeCtaCte();
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

        public List<CtaCteE> ObtenerMaeCtaCtePorParametros(Int32 idEmpresa, Int32 idPersona, DateTime fecFiltro, Int32 idSistema)
        {
            try
            {
                //List<CtaCteE> oListaTmp = new CtaCteAD().ObtenerCtaCtePorParametros(idEmpresa, idPersona, fecFiltro);
                //List<CtaCteE> oListaFinal = new List<CtaCteE>();

                //foreach (CtaCteE item in oListaTmp)
                //{
                //    item.SaldoSoles = item.CargoSoles - item.AbonoSoles;
                //    item.SaldoDolares = item.CargoDolares - item.AbonoDolares;
                //    item.DiasMora = Variables.ValorCero;

                //    oListaFinal.Add(item);
                //}

                //return oListaFinal;
                return new CtaCteAD().ObtenerMaeCtaCtePorParametros(idEmpresa, idPersona, fecFiltro, idSistema);

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

        public List<CtaCteE> ObtenerMaeCtaCteResumen(Int32 idEmpresa, Int32 idPersona, DateTime fecFiltro, Int32 idSistema)
        {
            try
            {
                return new CtaCteAD().ObtenerMaeCtaCteResumen(idEmpresa, idPersona, fecFiltro, idSistema);

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

        public List<CtaCteE> ObtenerMaeCtaCteLetras(Int32 idEmpresa, Int32 idPersona, DateTime fecFiltro, Int32 idSistema)
        {
            try
            {
   
                return new CtaCteAD().ObtenerMaeCtaCteLetras(idEmpresa, idPersona, fecFiltro, idSistema);

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

        public List<CtaCteE> ObtenerMaeCtaCteDetallado(Int32 idEmpresa, Int32 idPersona, DateTime fecFiltro, Int32 idSistema)
        {
            try
            {
                return new CtaCteAD().ObtenerMaeCtaCteDetallado(idEmpresa, idPersona, fecFiltro, idSistema);
                //List<CtaCte_DetE> CtaCteListado = new CtaCte_DetAD().ListarCtaCteDetallado(idEmpresa, numAnio, numMes, idPersona);

                //foreach (CtaCteE item in CtaCteDetallado)
                //{
                //    item.ListaCtaCte = new List<CtaCte_DetE>(from x in CtaCteListado
                //                                            where x.idDocumento == item.idDocumento
                //                                            && x.NumSerie == item.numSerie
                //                                            && x.NumDocumento == item.numDocumento select x).ToList();
                //}

                //return CtaCteDetallado;
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

        public List<CtaCteE> MaeCtaCteDetalladoVentas(Int32 idEmpresa, Int32 idPersona, DateTime fecFiltro, Int32 idSistema, Boolean Historico)
        {
            try
            {
                List<CtaCteE> oListaCtaCteDevuelta = new List<CtaCteE>();
                List<CtaCteE> oListaCtaCteReal = new CtaCteAD().MaeCtaCteDetalladoVentas(idEmpresa, idPersona, fecFiltro, idSistema, Historico);
                List<CtaCteE> oListaCtaCteTmp = oListaCtaCteReal.GroupBy(x => new { x.idCtaCte, x.idPersona }).Select(p => p.First()).ToList();
                Int16 Primero = 1;

                foreach (CtaCteE item in oListaCtaCteTmp)
                {
                    List<CtaCteE> oLista = new List<CtaCteE>(oListaCtaCteReal.Where(x => x.idCtaCte == item.idCtaCte && x.idPersona == item.idPersona));

                    if (oLista.Count > 0)
                    {
                        foreach (CtaCteE itemDet in oLista)
                        {
                            if (Primero == 1)
                            {
                                if (itemDet.idDocumentoMov != "NC")
                                {
                                    if (itemDet.idMoneda == "01")
                                    {
                                        itemDet.Saldo = itemDet.Cargo;
                                        Primero = 2;
                                    }
                                    else
                                    {
                                        itemDet.SaldoD = itemDet.CargoD;
                                        Primero = 2;
                                    }  
                                }
                                else
                                {
                                    CtaCteE oCtaCteAnte = oListaCtaCteDevuelta.TakeWhile(x => !x.Equals(itemDet)).LastOrDefault();

                                    if (itemDet.idMoneda == "01")
                                    {
                                        itemDet.Saldo = oCtaCteAnte.Saldo - itemDet.Abono;
                                        Primero = 2;
                                    }
                                    else
                                    {
                                        itemDet.SaldoD = oCtaCteAnte.SaldoD - itemDet.AbonoD;
                                        Primero = 2;
                                    }
                                }
                            }
                            else
                            {
                                CtaCteE oCtaCteAnte = oLista.TakeWhile(x => !x.Equals(itemDet)).LastOrDefault();

                                if (itemDet.idMoneda == "01")
                                {
                                    itemDet.Saldo = oCtaCteAnte.Saldo - itemDet.Abono;
                                    Primero = 2;
                                }
                                else
                                {
                                    itemDet.SaldoD = oCtaCteAnte.SaldoD - itemDet.AbonoD;
                                    Primero = 2;
                                }
                            }

                            oListaCtaCteDevuelta.Add(itemDet);
                        }

                        Primero = 1;
                    }
                }

                return oListaCtaCteDevuelta;
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

        public List<CtaCteE> ConsultaMaeCtaCteDet(Int32 idEmpresa, Int32 IdPersona, DateTime fecFiltro, String Opcion, Boolean EsDetraccion)
        {
            try
            {
                List<CtaCteE> oListaFinal = new List<CtaCteE>();
                List<CtaCteE> oListaCtaCte = new CtaCteAD().ConsultaMaeCtaCteDet(idEmpresa, IdPersona, fecFiltro, Opcion, EsDetraccion);

                foreach (CtaCteE item in oListaCtaCte)
                {
                    //if (item.idMoneda == Variables.ValorMonedaSoles)
                    //{
                    if (item.Saldo < Variables.Cero)
                    {
                        item.indDebeHaber = Variables.Haber;
                    }
                    else
                    {
                        item.indDebeHaber = Variables.Debe;
                    }
                    //}
                    //else
                    //{
                    //    if (item.Saldo < Variables.ValorCero)
                    //    {
                    //        item.indDebeHaber = Variables.ValorHaber;
                    //    }
                    //    else
                    //    {
                    //        item.indDebeHaber = Variables.ValorDebe;
                    //    }
                    //}

                    //item.Saldo = item.Saldo - item.Detraccion;

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

        public List<CtaCteE> ConsultaMaeCtaCteDetVentas(Int32 idEmpresa, Int32 idPersona, DateTime fecFiltro, String Tipo)
        {
            try
            {
                List<CtaCteE> ListaRetorno = new CtaCteAD().ConsultaMaeCtaCteDetVentas(idEmpresa, idPersona, fecFiltro, Tipo);

                foreach (CtaCteE item in ListaRetorno)
                {
                    item.SaldoOperativo = item.Saldo - item.SaldoEquivalente;
                }

                return ListaRetorno;
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

        public List<CtaCteE> ObtenerMaeCtaCtePorCuenta(Int32 idEmpresa, Int32 idPersona, DateTime fecFiltro)
        {
            try
            {
                return new CtaCteAD().ObtenerMaeCtaCtePorCuenta(idEmpresa, idPersona, fecFiltro);
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

        public List<CtaCteE> ObtenerMaeCtaCteGeneral(Int32 idEmpresa, string filtro, DateTime fecFiltro)
        {
            try
            {
                return new CtaCteAD().ObtenerMaeCtaCteGeneral(idEmpresa, filtro, fecFiltro);
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

        public List<CtaCteE> ObtenerMaeCtaCteDetalladoPorId(Int32 idEmpresa, Int32 idCtaCte, DateTime fecFiltro)
        {
            try
            {
                return new CtaCteAD().ObtenerMaeCtaCteDetalladoPorId(idEmpresa, idCtaCte, fecFiltro);
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

        public List<CtaCteE> ObtenerMaeCtaCtePartida(Int32 idEmpresa, string filtro, DateTime fecFiltro)
        {
            try
            {
                return new CtaCteAD().ObtenerMaeCtaCtePartida(idEmpresa, filtro, fecFiltro);
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

        public Int32 EliminarCtaCteMasivo(Int32 idEmpresa, Int32 idSistema, DateTime fecIni, DateTime fecFin)
        {
            try
            {
                return new CtaCteAD().EliminarCtaCteMasivo(idEmpresa, idSistema, fecIni, fecFin);
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

        public Int32 TransferirCtaCte(List<ProvisionesE> oListaCompras, List<EmisionDocumentoE> oListaVentas, Int32 idSistema, String Usuario)
        {
            try
            {
                Int32 resp = 0;
                Int32 idCtaCte = 0;
                Int32 idCtaCteItem = 0;
                String CuentaDetra = String.Empty;
                ParametrosContaE oParametroConta = null;
                TransactionOptions Opciones = new TransactionOptions();
                Opciones.Timeout = TimeSpan.FromMinutes(10);

                using (TransactionScope oTrans = new TransactionScope(TransactionScopeOption.Required, Opciones))
                {
                    if (oListaCompras != null && oListaCompras.Count > 0)
                    {
                        foreach (ProvisionesE item in oListaCompras)
                        {
                            resp++;

                            #region Cabecera

                            CtaCteE oCtaCte = new CtaCteE
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

                            new CtaCteAD().InsertarMaeCtaCte(oCtaCte);

                            //Obteniendo el id de la ctacte...
                            idCtaCte = oCtaCte.idCtaCte;

                            #endregion

                            #region Detalle

                            CtaCte_DetE oCtaCteDet = new CtaCte_DetE
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

                            new CtaCte_DetAD().InsertarMaeCtaCteDet(oCtaCteDet);

                            //Recuperando el item
                            idCtaCteItem = oCtaCteDet.idCtaCteItem;

                            #endregion

                            //Actualizando la los Id de la CtaCte en la provisión
                            new ProvisionesAD().ActualizarIdCtaCteProvision(item.idProvision, idCtaCte, idCtaCteItem, Usuario);

                            //Si la empresa paga la detracción
                            if (item.flagDetraccion)
                            {
                                #region Abono de CtaCte padre donde se origina la detracción

                                oCtaCteDet = new CtaCte_DetE
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

                                new CtaCte_DetAD().InsertarMaeCtaCteDet(oCtaCteDet);

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

                                    oCtaCte = new CtaCteE
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

                                    new CtaCteAD().InsertarMaeCtaCte(oCtaCte);

                                    //Obteniendo el id de la ctacte...
                                    idCtaCte = oCtaCte.idCtaCte;

                                    #endregion

                                    #region Detalle de la detracción

                                    oCtaCteDet = new CtaCte_DetE //Cargo
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

                                    new CtaCte_DetAD().InsertarMaeCtaCteDet(oCtaCteDet);

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

        public CtaCteE ObtenerMaeCtaCtePorDocumento(Int32 idEmpresa, String idDocumento, String NumSerie, String NumDocumento)
        {
            try
            {
                return new CtaCteAD().ObtenerMaeCtaCtePorDocumento(idEmpresa, idDocumento, NumSerie, NumDocumento);
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

        public List<CtaCteE> ListarReporteCtaCteComparado(Int32 idEmpresa, Int32 idPersona, DateTime fecFiltro, String TipoBuscar)
        {
            try
            {
                return new CtaCteAD().ListarReporteCtaCteComparado(idEmpresa, idPersona, fecFiltro, TipoBuscar);
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

        public List<CtaCteE> CtaCteDetalladoVentas2(Int32 idEmpresa, Int32 idPersona, DateTime fecFiltro, Int32 idSistema)
        {
            try
            {
                return new CtaCteAD().CtaCteDetalladoVentas2(idEmpresa, idPersona, fecFiltro, idSistema);
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

        public List<CtaCteE> ObtenerCtaCtePorEstadosLetras(Int32 idEmpresa, String idDocumento, String NumSerie, String NumDocumento)
        {
            try
            {
                return new CtaCteAD().ObtenerCtaCtePorEstadosLetras(idEmpresa, idDocumento, NumSerie, NumDocumento);
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

        public List<CtaCteE> ConsultaCtaCteRRHH(Int32 idEmpresa, Int32 idPersona, DateTime fecFiltro)
        {
            try
            {
                return new CtaCteAD().ConsultaCtaCteRRHH(idEmpresa, idPersona, fecFiltro);
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

        public List<CtaCteE> ConsultaMaeCtaCteLiquidacion(Int32 idEmpresa, Int32 idPersona, DateTime fecFiltro)
        {
            try
            {
                return new CtaCteAD().ConsultaMaeCtaCteLiquidacion(idEmpresa, idPersona, fecFiltro);
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
