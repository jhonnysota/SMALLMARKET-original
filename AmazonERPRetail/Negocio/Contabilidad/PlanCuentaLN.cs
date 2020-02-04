using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;

using Entidades.Contabilidad;
using AccesoDatos.Contabilidad;

namespace Negocio.Contabilidad
{
    public class PlanCuentasLN
    {
        public PlanCuentasE InsertarPlanCuentas(PlanCuentasE plancuenta)
        {
            try
            {
                PlanCuentasE oPlanCuentas = new PlanCuentasAD().InsertarPlanCuentas(plancuenta);

                if (oPlanCuentas.codCuenta.Length > 1)
                {
                    new PlanCuentasAD().ActualizarCodigosBalancePC(oPlanCuentas.idEmpresa, Convert.ToInt32(oPlanCuentas.indBalance), oPlanCuentas.numVerPlanCuentas, oPlanCuentas.codCuenta.Substring(0, 2)); 
                }

                if (plancuenta.oListaTasaRenta != null)
                {
                    foreach (CuentaTasaRentaE item in plancuenta.oListaTasaRenta)
                    {
                        new CuentaTasaRentaAD().InsertarCuentaTasaRenta(item);
                    }
                }

                return oPlanCuentas;
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

        public PlanCuentasE ActualizarPlanCuentas(PlanCuentasE plancuenta)
        {
            try
            {
                PlanCuentasE oPlanCuentas = new PlanCuentasAD().ActualizarPlanCuentas(plancuenta);

                if (oPlanCuentas.codCuenta.Length > 1)
                {
                    new PlanCuentasAD().ActualizarCodigosBalancePC(oPlanCuentas.idEmpresa, Convert.ToInt32(oPlanCuentas.indBalance), oPlanCuentas.numVerPlanCuentas, oPlanCuentas.codCuenta.Substring(0, 2)); 
                }

                if (plancuenta.oListaTasaRenta != null)
                {
                    new CuentaTasaRentaAD().EliminarCuentaTasaRenta(plancuenta.idEmpresa, plancuenta.codCuenta, plancuenta.numVerPlanCuentas);

                    foreach (CuentaTasaRentaE item in plancuenta.oListaTasaRenta)
                    {
                        new CuentaTasaRentaAD().InsertarCuentaTasaRenta(item);
                    }
                }

                return oPlanCuentas;
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

        public List<PlanCuentasE> ObtenerPlanCuentasPadre(Int32 idEmpresa, String VersionPlanCuentas)
        {
            try
            {
                return new PlanCuentasAD().ObtenerPlanCuentasPadre(idEmpresa, VersionPlanCuentas);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<PlanCuentasE> ObtenerPlanCuentasSubCuentas(Int32 idEmpresa, String VersionPlanCuentas, Int32 Nivel, String Cuenta)
        {
            try
            {
                return new PlanCuentasAD().ObtenerPlanCuentasSubCuentas(idEmpresa, VersionPlanCuentas, Nivel, Cuenta);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public PlanCuentasE ObtenerPlanCuentasPorCodigo(Int32 idEmpresa, String VersionPlanCuentas, String Cuenta, String ConTasa)
        {
            try
            {
                PlanCuentasE oCuenta = new PlanCuentasAD().ObtenerPlanCuentasPorCodigo(idEmpresa, VersionPlanCuentas, Cuenta);

                if (oCuenta != null)
                {
                    if (ConTasa == "S")
                    {
                        oCuenta.oListaTasaRenta = new CuentaTasaRentaAD().ListarCuentaTasaRenta(idEmpresa, Cuenta, VersionPlanCuentas);
                    }
                }

                return oCuenta;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<PlanCuentasE> ObtenerPlanCuentasPorCtaSuperior(Int32 idEmpresa, String VersionPlanCuentas, String CuentaSuperior)
        {
            try
            {
                return new PlanCuentasAD().ObtenerPlanCuentasPorCtaSuperior(idEmpresa, VersionPlanCuentas, CuentaSuperior);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public String ObtenerDescripcionCuenta(Int32 idEmpresa, String VersionPlanCuentas, String Cuenta)
        {
            try
            {
                return new PlanCuentasAD().ObtenerDescripcionCuenta(idEmpresa, VersionPlanCuentas, Cuenta);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Int32 EliminarCuenta(Int32 idEmpresa, String numVerPlanCuentas, String codCuenta)
        {
            try
            {
                return new PlanCuentasAD().EliminarCuenta(idEmpresa, numVerPlanCuentas, codCuenta);
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

        public Int32 VerificaSubCuentas(Int32 idEmpresa, String numVerPlanCuentas, String codCuentaSup)
        {
            try
            {
                return new PlanCuentasAD().VerificaSubCuentas(idEmpresa, numVerPlanCuentas, codCuentaSup);
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

        public Int32 EliminarSubCuentas(Int32 idEmpresa, String numVerPlanCuentas, String codCuentaSup)
        {
            try
            {
                return new PlanCuentasAD().EliminarSubCuentas(idEmpresa, numVerPlanCuentas, codCuentaSup);
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

        public List<PlanCuentasE> ListarPlanCuentasPorParametro(Int32 idEmpresa, String numVerPlanCuentas, String Parametro, Int32 numNivel, Int32 Opcion)
        {
            try
            {
                return new PlanCuentasAD().ListarPlanCuentasPorParametro(idEmpresa, numVerPlanCuentas, Parametro, numNivel, Opcion);
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

        public List<PlanCuentasE> PlanContableExportacion(Int32 idEmpresa, String numVerPlanCuentas)
        {
            try
            {
                return new PlanCuentasAD().PlanContableExportacion(idEmpresa, numVerPlanCuentas);
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

        public List<PlanCuentasE> ObtenerReportePlanDeCuenta(Int32 idEmpresa, Int32 idLocal,String Anio, String MesIni, String MesFin, String idMoneda, String idCompIni, String idCompFin)
        {
            try
            {
                return new PlanCuentasAD().ObtenerReportePlanDeCuenta(idEmpresa, idLocal, Anio, MesIni, MesFin, idMoneda, idCompIni, idCompFin);
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

        public List<PlanCuentasE> CuentasRenta(Int32 idEmpresa, String numVerPlanCuentas)
        {
            try
            {
                return new PlanCuentasAD().CuentasRenta(idEmpresa, numVerPlanCuentas);
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

        public List<PlanCuentasE> ListarCtaCuentaSunat(Int32 idEmpresa, String anioPeriodo, String MesPeriodo)
        {
            try
            {
                return new PlanCuentasAD().ListarCtaCuentaSunat(idEmpresa, anioPeriodo, MesPeriodo);
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

        public PlanCuentasE ActualizarPlandeCuentasSunat(PlanCuentasE plancuentas_sunat)
        {
            try
            {
                PlanCuentasE oPlanCuentas = new PlanCuentasAD().ActualizarPlandeCuentasSunat(plancuentas_sunat);

                return oPlanCuentas;
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

        public List<PlanCuentasE> GenerarBalanceComprobacionSunat(Int32 idEmpresa, String anioPeriodo, String MesPeriodo)
        {
            try
            {
                return new PlanCuentasAD().GenerarBalanceComprobacionSunat(idEmpresa, anioPeriodo, MesPeriodo);
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

        public List<PlanCuentasE> PlanCuentasRepSimplificado(Int32 idEmpresa, String numVerPlanCuentas)
        {
            try
            {
                return new PlanCuentasAD().PlanCuentasRepSimplificado(idEmpresa, numVerPlanCuentas);
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
