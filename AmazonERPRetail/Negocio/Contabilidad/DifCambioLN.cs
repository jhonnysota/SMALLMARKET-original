using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;

using Entidades.Contabilidad;
using AccesoDatos.Contabilidad;
using System.Transactions;

namespace Negocio.Contabilidad
{
    public class DifCambioLN
    {

        public List<DifCambioE> ListarConsistenciaDif(Int32 idEmpresa, Int32 idLocal, String AnioPeriodo, String MesPeriodo, String idMoneda, String numVerPlanCuentas, DateTime Fecha)
        {
            try
            {
                return new DifCambioAD().ListarConsistenciaDif(idEmpresa, idLocal, AnioPeriodo, MesPeriodo, idMoneda, numVerPlanCuentas, Fecha);
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

        public void ProcesoDiferenciaCambio(int idEmpresa, string ano, string mes, string INcodCuenta, string numPlanCuenta, string UsuarioAsignado)
        {
            try
            {
                TransactionOptions Opciones = new TransactionOptions
                {
                    Timeout = TimeSpan.FromMinutes(720)
                };

                using (TransactionScope oTrans = new TransactionScope(TransactionScopeOption.Required, Opciones))
                {
                    new VoucherAD().TriggerVouchers(true); //Desabilita Trigger

                    new DifCambioAD().ProcesoDiferenciaCambio(idEmpresa, ano, mes, INcodCuenta, numPlanCuenta, UsuarioAsignado);

                    new VoucherAD().TriggerVouchers(false); //Habilita Trigger

                    oTrans.Complete();
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

        public void EliminarDiferenciaCambio(int idEmpresa, string ano, string mes, string INcodCuenta, string numPlanCuenta, string UsuarioAsignado)
        {
            try
            {
                TransactionOptions Opciones = new TransactionOptions
                {
                    Timeout = TimeSpan.FromMinutes(720)
                };

                using (TransactionScope oTrans = new TransactionScope(TransactionScopeOption.Required, Opciones))
                {
                    new VoucherAD().TriggerVouchers(true); //Desabilita Trigger

                    new DifCambioAD().EliminarDiferenciaCambio(idEmpresa, ano, mes, INcodCuenta, numPlanCuenta, UsuarioAsignado);

                    new VoucherAD().TriggerVouchers(false); //Habilita Trigger


                    oTrans.Complete();
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

        public void ProcesoDiferenciaCambioSoles(int idEmpresa, string ano, string mes, string INcodCuenta, string numPlanCuenta, string SoloCancelados, string UsuarioAsignado)
        {
            try
            {
                TransactionOptions Opciones = new TransactionOptions
                {
                    Timeout = TimeSpan.FromMinutes(720)
                };

                using (TransactionScope oTrans = new TransactionScope(TransactionScopeOption.Required, Opciones))
                {
                    new VoucherAD().TriggerVouchers(true); //Desabilita Trigger

                    new DifCambioAD().ProcesoDiferenciaCambioSoles(idEmpresa, ano, mes, INcodCuenta, numPlanCuenta, SoloCancelados, UsuarioAsignado);

                    new VoucherAD().TriggerVouchers(false); //Habilita Trigger

                    oTrans.Complete();
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

        public void EliminarDiferenciaCambioSoles(int idEmpresa, string ano, string mes, string INcodCuenta, string numPlanCuenta, string SoloCancelados, string UsuarioAsignado)
        {
            try
            {
                TransactionOptions Opciones = new TransactionOptions
                {
                    Timeout = TimeSpan.FromMinutes(720)
                };

                
                using (TransactionScope oTrans = new TransactionScope(TransactionScopeOption.Required, Opciones))
                {

                    new VoucherAD().TriggerVouchers(true); //Desabilita Trigger

                    new DifCambioAD().EliminarDiferenciaCambioSoles(idEmpresa, ano, mes, INcodCuenta, numPlanCuenta, SoloCancelados, UsuarioAsignado);

                    new VoucherAD().TriggerVouchers(false); //Habilita Trigger

                    oTrans.Complete();
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

    }
}
