using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Transactions;

using Entidades.Contabilidad;
using Entidades.Generales;
using Entidades.Maestros;
using AccesoDatos.Contabilidad;
using AccesoDatos.Generales;
using AccesoDatos.Maestros;
using Infraestructura;

namespace Negocio.Contabilidad
{
    public class PlantillaAsientoLN
    {

        #region Publicas

        public PlantillaAsientoE InsertarPlantillaAsiento(PlantillaAsientoE plantillaasiento)
        {
            try
            {
                return new PlantillaAsientoAD().InsertarPlantillaAsiento(plantillaasiento);
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

        public PlantillaAsientoE ActualizarPlantillaAsiento(PlantillaAsientoE plantillaasiento)
        {
            try
            {
                return new PlantillaAsientoAD().ActualizarPlantillaAsiento(plantillaasiento);
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

        public Int32 EliminarPlantillaAsiento(Int32 idPlantilla)
        {
            try
            {
                return new PlantillaAsientoAD().EliminarPlantillaAsiento(idPlantilla);
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

        public List<PlantillaAsientoE> ListarPlantillaAsiento(Int32 idEmpresa)
        {
            try
            {
                return new PlantillaAsientoAD().ListarPlantillaAsiento(idEmpresa);
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

        public PlantillaAsientoE ObtenerPlantillaAsiento(Int32 idPlantilla, Int32 idEmpresa)
        {
            try
            {
                return new PlantillaAsientoAD().ObtenerPlantillaAsiento(idPlantilla, idEmpresa);
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

        public PlantillaAsientoE RecuperarPlantillaAsiento(Int32 idPlantilla, Int32 idEmpresa)
        {
            try
            {
                // Cabecera
                PlantillaAsientoE Plantilla = new PlantillaAsientoAD().ObtenerPlantillaAsiento(idPlantilla, idEmpresa);

                // Detalle
                Plantilla.ListaPlantillas = new PlantillaAsientoDetAD().ListarPlantillaAsientoDet(idPlantilla, idEmpresa);

                return Plantilla;
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

        public String GenerarAsientoContable(PlantillaAsientoE oPlantilla)
        {
            try
            {
                Int32 Voucher = Variables.Cero;
                Int32 numItem = Variables.ValorUno;
                Decimal MontoSoles = Variables.ValorCeroDecimal;
                Decimal MontoDolares = Variables.ValorCeroDecimal;
                String Comprobante = String.Empty;
                Int32? idPersona = Variables.Cero;

                using (TransactionScope oTrans = new TransactionScope())
                {
                    Voucher = new VoucherAD().GenerarNumVoucher(oPlantilla.idEmpresa.Value, oPlantilla.idLocal.Value, oPlantilla.Anio, oPlantilla.Mes, oPlantilla.idComprobante, oPlantilla.numFile);
                    Voucher++;
                    String numVoucher = String.Format("{0:000000000}", Voucher);

                    TipoCambioE oTica = null;

                    if (oPlantilla.idMoneda == Variables.Soles)
                    {
                        oTica = new TipoCambioAD().ObtenerTipoCambioPorDia(Variables.Dolares, oPlantilla.Fecha.ToString("yyyyMMdd"));
                    }
                    else
                    {
                        oTica = new TipoCambioAD().ObtenerTipoCambioPorDia(oPlantilla.idMoneda, oPlantilla.Fecha.ToString("yyyyMMdd"));
                    }

                    if (oTica == null)
                    {
                        throw new Exception(String.Format("No se ha ingresado el tipo de cambio para el dia {0}", oPlantilla.Fecha.Date));
                    }

                    #region Cabecera del Voucher

                    VoucherE oVoucher = new VoucherE
                    {
                        idEmpresa = oPlantilla.idEmpresa.Value,
                        idLocal = oPlantilla.idLocal.Value,
                        AnioPeriodo = oPlantilla.Anio,
                        MesPeriodo = oPlantilla.Mes,
                        numVoucher = numVoucher,
                        idComprobante = oPlantilla.idComprobante,
                        numFile = oPlantilla.numFile,
                        idMoneda = oPlantilla.idMoneda,
                        fecOperacion = oPlantilla.Fecha,
                        fecDocumento = oPlantilla.Fecha,
                        GlosaGeneral = oPlantilla.GlosaGeneral,
                        tipCambio = oTica.valVenta,
                        RazonSocial = "VARIOS",
                        numDocumentoPresu = String.Empty,
                        indHojaCosto = Variables.NO,
                        numHojaCosto = String.Empty,
                        numOrdenCompra = String.Empty,
                        sistema = String.Empty,
                        UsuarioRegistro = oPlantilla.UsuarioRegistro
                    };

                    #endregion Cabecera del Voucher

                    #region Detalle del Voucher

                    foreach (PlantillaAsientoDetE item in oPlantilla.ListaPlantillas)
                    {
                        if (oPlantilla.idMoneda == Variables.Soles)
                        {
                            MontoSoles = item.Monto;
                            MontoDolares = Math.Round(item.Monto / oTica.valVenta, 2);
                        }
                        else
                        {
                            MontoDolares = item.Monto;
                            MontoSoles = Decimal.Round(item.Monto * oTica.valVenta, 2);
                        }

                        if (item.oPlanCuentas.indSolicitaAnexo == Variables.SI)
                        {
                            Persona oPersona = new PersonaAD().ObtenerPersonaPorNroRuc(item.nroDocumento);

                            if (oPersona != null)
                            {
                                idPersona = oPersona.IdPersona;
                            }
                            else
                            {
                                idPersona = (Nullable<Int32>)null;
                            }
                        }

                        VoucherItemE oItemVoucher = new VoucherItemE
                        {
                            idEmpresa = item.idEmpresa,
                            idLocal = item.idLocal,
                            AnioPeriodo = oPlantilla.Anio,
                            MesPeriodo = oPlantilla.Mes,
                            numVoucher = numVoucher,
                            idComprobante = oPlantilla.idComprobante,
                            numFile = oPlantilla.numFile,
                            numItem = String.Format("{0:00000}", numItem),
                            idPersona = idPersona,//item.oPlanCuentas.indSolicitaAnexo == Variables.valorSI ? item.idPersona : (Nullable<Int32>)null,
                            idMoneda = oPlantilla.idMoneda,
                            tipCambio = oTica.valVenta,
                            indCambio = Variables.SI,
                            idCCostos = item.oPlanCuentas.indSolicitaCentroCosto == Variables.SI ? item.idCCostos : String.Empty,
                            numVerPlanCuentas = item.numVerPlanCuentas,
                            codCuenta = item.codCuenta,
                            desGlosa = oPlantilla.GlosaGeneral,
                            fecDocumento = (Nullable<DateTime>)null,//item.oPlanCuentas.indSolicitaDcto == Variables.valorSI ? oPlantilla.Fecha : (Nullable<DateTime>)null,
                            fecVencimiento = (Nullable<DateTime>)null,
                            idDocumento = String.Empty,//item.oPlanCuentas.indSolicitaDcto == Variables.SI ? item.idDocumento : String.Empty,
                            serDocumento = String.Empty,//item.oPlanCuentas.indSolicitaDcto == Variables.SI ? item.Serie : String.Empty,
                            numDocumento = String.Empty,//item.oPlanCuentas.indSolicitaDcto == Variables.SI ? item.Numero : String.Empty,
                            fecDocumentoRef = (Nullable<DateTime>)null,
                            idDocumentoRef = String.Empty,
                            serDocumentoRef = String.Empty,
                            numDocumentoRef = String.Empty,
                            indDebeHaber = item.indDebeHaber,
                            impSoles = MontoSoles,
                            impDolares = MontoDolares,
                            indAutomatica = Variables.NO,
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
                            UsuarioRegistro = item.UsuarioRegistro,

                            indCuentaGastos = item.oPlanCuentas.indCuentaGastos,
                            codCuentaDestino = item.oPlanCuentas.codCuentaDestino,
                            codCuentaTransferencia = item.oPlanCuentas.codCuentaTransferencia
                        };

                        oVoucher.ListaVouchers.Add(oItemVoucher);
                        numItem++;
                        oItemVoucher = null;
                    }

                    #endregion Detalle del Voucher

                    #region Cuentas Automáticas

                    List<VoucherItemE> oListaVoucherItems = new List<VoucherItemE>(oVoucher.ListaVouchers);

                    foreach (VoucherItemE item in oListaVoucherItems)
                    {
                        if (item.indCuentaGastos == Variables.SI)
                        {
                            if (!String.IsNullOrEmpty(item.codCuentaDestino))
                            {
                                oVoucher.ListaVouchers.Add(CuentaAutomatica(item, numItem, item.codCuentaDestino));
                                numItem++;
                            }

                            if (!String.IsNullOrEmpty(item.codCuentaTransferencia))
                            {
                                oVoucher.ListaVouchers.Add(CuentaAutomatica(item, numItem, item.codCuentaTransferencia));
                                numItem++;
                            }
                        }
                    }

                    #endregion

                    #region Completando datos de la Cabecera del Voucher

                    Decimal totDebeSoles = Decimal.Round((from x in oVoucher.ListaVouchers where x.indDebeHaber == Variables.Debe select x.impSoles).Sum(), 2);
                    Decimal totDebeDolares = Decimal.Round((from x in oVoucher.ListaVouchers where x.indDebeHaber == Variables.Debe select x.impDolares).Sum(), 2);
                    Decimal totHaberSoles = Decimal.Round((from x in oVoucher.ListaVouchers where x.indDebeHaber == Variables.Haber select x.impSoles).Sum(), 2);
                    Decimal totHaberDolares = Decimal.Round((from x in oVoucher.ListaVouchers where x.indDebeHaber == Variables.Haber select x.impDolares).Sum(), 2);
                    Decimal impDifSoles = Variables.ValorCeroDecimal, impDifDolares = Variables.ValorCeroDecimal;

                    impDifSoles = totDebeSoles - totHaberSoles;
                    impDifDolares = totDebeDolares - totHaberDolares;

                    oVoucher.impDebeSoles = totDebeSoles;
                    oVoucher.impHaberSoles = totHaberSoles;
                    oVoucher.impDebeDolares = totDebeDolares;
                    oVoucher.impHaberDolares = totHaberDolares;

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

                    if (impDifSoles != Variables.Cero || impDifDolares != Variables.Cero)
                    {
                        oVoucher.indEstado = Variables.VoucherDescuadrado;
                    }
                    else
                    {
                        oVoucher.indEstado = Variables.VoucherCuadrado;
                    }

                    #endregion

                    oVoucher.numItems = oVoucher.ListaVouchers.Count();

                    //Insertando el Voucher
                    new VoucherAD().InsertarVoucher(oVoucher);

                    foreach (VoucherItemE item in oVoucher.ListaVouchers)
                    {
                        new VoucherItemAD().InsertarVoucherItem(item);
                    }

                    Comprobante = oVoucher.idComprobante + "-" + oVoucher.numFile + "-" + oVoucher.numVoucher;
                    oTica = null;
                    oVoucher = null;
                    oPlantilla = null;
                    oListaVoucherItems = null;

                    oTrans.Complete();
                }

                return Comprobante;
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

        #endregion Publicas

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

        #endregion

    }
}
