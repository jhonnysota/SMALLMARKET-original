using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Transactions;

using Entidades.Contabilidad;
using AccesoDatos.Contabilidad;

namespace Negocio.Contabilidad
{
    public class VoucherItemLN
    {

        public VoucherItemE InsertarVoucherItem(VoucherItemE voucheritem)
        {
            try
            {
                return new VoucherItemAD().InsertarVoucherItem(voucheritem);
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

        public VoucherItemE ActualizarVoucherItem(VoucherItemE voucheritem)
        {
            try
            {
                return new VoucherItemAD().ActualizarVoucherItem(voucheritem);
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

        public VoucherItemE ActualizarVoucherConciliado(VoucherItemE voucheritem)
        {
            try
            {
                return new VoucherItemAD().ActualizarVoucherConciliado(voucheritem);
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

        public List<VoucherItemE> ObtenerVoucherItemPorCodigo(Int32 idEmpresa, Int32 idLocal, String AnioPeriodo, String MesPeriodo, String numVoucher, String idComprobante, String numFile)
        {
            try
            {
                return new VoucherItemAD().ObtenerVoucherItemPorCodigo(idEmpresa, idLocal, AnioPeriodo, MesPeriodo, numVoucher, idComprobante, numFile);
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

        public List<VoucherItemE> ListaVoucherItemPorDcmtoCtaCte(Int32 idEmpresa, String AnioPeriodo, String MesPeriodo, String codCuenta, Int32 idPersona, String idDocumento, String Serie, String Numero)
        {
            try
            {
                return new VoucherItemAD().ListaVoucherItemPorDcmtoCtaCte(idEmpresa, AnioPeriodo, MesPeriodo, codCuenta, idPersona, idDocumento, Serie, Numero);
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

        public List<VoucherItemE> ReporteMovimientoBanco(Int32 idEmpresa, Int32 idLocal, String numVerPlanCuentas, String AnioPeriodo, String MesIni, String MesFin, String CuentaIni, String CuentaFin)
        {
            try
            {
                return new VoucherItemAD().ReporteMovimientoBanco(idEmpresa, idLocal, numVerPlanCuentas, AnioPeriodo, MesIni, MesFin, CuentaIni, CuentaFin);
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

        public VoucherItemE RecuperarVoucherItemPorLinea(Int32 idEmpresa, Int32 idLocal, String AnioPeriodo, String MesPeriodo, String numVoucher, String idComprobante, String numFile, String numItem)
        {
            try
            {
                return new VoucherItemAD().RecuperarVoucherItemPorLinea(idEmpresa, idLocal, AnioPeriodo, MesPeriodo, numVoucher, idComprobante, numFile, numItem);
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

        public List<VoucherItemE> VoucherDetalle(Int32 idEmpresa, Int32 idLocal, String AnioPeriodo, String MesPeriodo, String numVoucher, String idComprobante, String numFile)
        {
            try
            {
                return new VoucherItemAD().VoucherDetalle(idEmpresa, idLocal, AnioPeriodo, MesPeriodo, numVoucher, idComprobante, numFile);
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

        public List<VoucherItemE> VoucherDetalleEgreso(Int32 idEmpresa, Int32 idLocal, String AnioPeriodo, String MesPeriodo, String numVoucher, String idComprobante, String numFile)
        {
            try
            {
                return new VoucherItemAD().VoucherDetalleEgreso(idEmpresa, idLocal, AnioPeriodo, MesPeriodo, numVoucher, idComprobante, numFile);
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

        public List<VoucherItemE> ReporteVoucherItemConceptoGasto(Int32 idEmpresa, String idMoneda, String AnioPeriodo, String MesPeriodoIni, String MesPeriodoFin)
        {
            try
            {
                return new VoucherItemAD().ReporteVoucherItemConceptoGasto(idEmpresa, idMoneda, AnioPeriodo, MesPeriodoIni, MesPeriodoFin);
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

        public List<VoucherItemE> ListarVoucherItemConceptoGasto(Int32 idEmpresa, String idMoneda, String AnioPeriodo, String MesPeriodo, String idConceptoGasto, String idCampana)
        {
            try
            {
                return new VoucherItemAD().ListarVoucherItemConceptoGasto(idEmpresa, idMoneda, AnioPeriodo, MesPeriodo, idConceptoGasto, idCampana);
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

        public List<VoucherItemE> ReporteVoucherItemMovimientoEFectivo(Int32 idEmpresa, Int32 idLocal, String numVerPlanCuentas, String AnioPeriodo, String MesIni, String MesFin, String CuentaIni, String CuentaFin)
        {
            try
            {
                return new VoucherItemAD().ReporteVoucherItemMovimientoEFectivo(idEmpresa, idLocal, numVerPlanCuentas, AnioPeriodo, MesIni, MesFin, CuentaIni, CuentaFin);
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

        public List<VoucherItemE> ReporteVoucherItemMovimientoCtaCte(Int32 idEmpresa, Int32 idLocal, String numVerPlanCuentas, String AnioPeriodo, String MesIni, String MesFin, String CuentaIni, String CuentaFin)
        {
            try
            {
                return new VoucherItemAD().ReporteVoucherItemMovimientoCtaCte(idEmpresa, idLocal, numVerPlanCuentas, AnioPeriodo, MesIni, MesFin, CuentaIni, CuentaFin);
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

        public List<VoucherItemE> ListaVoucherItemActivacion(Int32 idEmpresa, String AnioPeriodo, String MesPeriodo, String MesPeriodoFin)
        {
            try
            {
                return new VoucherItemAD().ListaVoucherItemActivacion(idEmpresa,AnioPeriodo,MesPeriodo,MesPeriodoFin);
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

        public List<VoucherItemE> ListarVoucherItemPorCuenta(Int32 idEmpresa, Int32 idLocal, String AnioPeriodo, String MesPeriodo, String numVerPlanCuentas, String codCuenta)
        {
            try
            {
                return new VoucherItemAD().ListarVoucherItemPorCuenta(idEmpresa, idLocal, AnioPeriodo, MesPeriodo, numVerPlanCuentas, codCuenta);
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

        public List<VoucherItemE> GrabarVoucherItem(List<VoucherItemE> ListaVoucherItem)
        {
            try
            {
                using (TransactionScope oTrans = new TransactionScope())
                {
                    if (ListaVoucherItem != null && ListaVoucherItem.Count > 0)
                    {
                        foreach (VoucherItemE oitem in ListaVoucherItem)
                        {
                            new VoucherItemAD().ActualizarVoucherConciliado(oitem);
                        }
                    }

                    oTrans.Complete();
                }

                return ListaVoucherItem;
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

        public List<VoucherItemE> RegistroDeDiarioTxt(Int32 idEmpresa, Int32 idLocal, DateTime FechaIni, DateTime FechaFin, String NumVerPlanCuenta, String idComprobanteInicial, String idComprobanteFinal)
        {
            try
            {
                TransactionOptions Opciones = new TransactionOptions();
                Opciones.Timeout = TimeSpan.FromMinutes(120);

                using (TransactionScope oTrans = new TransactionScope())
                {

                   return new VoucherItemAD().RegistroDeDiarioTxt(idEmpresa, idLocal, FechaIni, FechaFin, NumVerPlanCuenta, idComprobanteInicial, idComprobanteFinal);

                }

                
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

        public List<VoucherItemE> RepVoucherItemMovimientoCtaCteOpe(Int32 idEmpresa, Int32 idLocal, String numVerPlanCuentas, String AnioPeriodo, String MesIni, String MesFin, String CuentaIni, String CuentaFin)
        {
            try
            {
                return new VoucherItemAD().RepVoucherItemMovimientoCtaCteOpe(idEmpresa, idLocal, numVerPlanCuentas, AnioPeriodo, MesIni, MesFin, CuentaIni, CuentaFin);
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

        public List<VoucherItemE> RepVoucherItemMovimientoEFectivoOpe(Int32 idEmpresa, Int32 idLocal, String numVerPlanCuentas, String AnioPeriodo, String MesIni, String MesFin, String CuentaIni, String CuentaFin)
        {
            try
            {
                return new VoucherItemAD().RepVoucherItemMovimientoEFectivoOpe(idEmpresa, idLocal, numVerPlanCuentas, AnioPeriodo, MesIni, MesFin, CuentaIni, CuentaFin);
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

        public List<VoucherItemE> BuscarVoucherPorCtaContableTipo(Int32 idEmpresa, Int32 idLocal, String numVerPlanCuentas, String codCuenta, String Tipo)
        {
            try
            {
                return new VoucherItemAD().BuscarVoucherPorCtaContableTipo(idEmpresa, idLocal, numVerPlanCuentas, codCuenta, Tipo);
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

        public Int32 ActualizarVoucherItemAuxiCcDoc(List<VoucherItemE> ListaVoucherItem, String Tipo)
        {
            try
            {
                Int32 resp = 0;

                using (TransactionScope oTrans = new TransactionScope())
                {
                    if (ListaVoucherItem != null && ListaVoucherItem.Count > 0)
                    {
                        new VoucherAD().TriggerVouchers(true); //Desabilita Trigger

                        foreach (VoucherItemE item in ListaVoucherItem)
                        {
                            resp += new VoucherItemAD().ActualizarVoucherItemAuxiCcDoc(item, Tipo);
                        }

                        new VoucherAD().TriggerVouchers(false); //Habilita Trigger
                    }

                    oTrans.Complete();
                }

                return resp;
            }
            catch (SqlException ex)
            {
                SqlError err = ex.Errors[0];
                StringBuilder mensaje = new StringBuilder();

                new VoucherAD().TriggerVouchers(false); //Habilita Trigger

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
