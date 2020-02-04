using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Transactions;

using Entidades.Contabilidad;
using AccesoDatos.Contabilidad;

namespace Negocio.Contabilidad
{
    public class Con_SaldosLN
    {

        public List<Con_SaldosE> MayorizarMayor(Int32 idEmpresa, Int32 idLocal, String vi_mes_inicio, String vi_ano_inicio, String vi_mes_proceso, String vi_ano_proceso, String vi_ver_placta)
        {
            try
            {
                // Proceso Antiguo
                //return new Con_SaldosAD().MayorizarMayor(idEmpresa, idLocal, vi_mes_inicio, vi_ano_inicio, vi_mes_proceso, vi_ano_proceso, vi_ver_placta);

                List<Con_SaldosE> ListaSaldos = null;
                Int32 Inicio = Convert.ToInt32(vi_mes_inicio); 
                
                for (int i = Inicio; i <= 13; i++)
                { TransactionOptions Opciones = new TransactionOptions();
                  Opciones.Timeout = TimeSpan.FromMinutes(750);

                   using (TransactionScope oTrans = new TransactionScope(TransactionScopeOption.Required, Opciones))
                   {

                   String Mes = i.ToString("00");
                   ListaSaldos = new Con_SaldosAD().MayorizarCuentaMes(idEmpresa, vi_ano_inicio, Mes, vi_ver_placta);

                   oTrans.Complete();
                   }
                }

                for (int i = 13; i > 0; i--)
                {
                    TransactionOptions Opciones = new TransactionOptions();
                    Opciones.Timeout = TimeSpan.FromMinutes(750);

                    using (TransactionScope oTrans = new TransactionScope(TransactionScopeOption.Required, Opciones))
                    {

                        String Mes = i.ToString("00");
                        ListaSaldos = new Con_SaldosAD().MayorizarCuentaMesCero(idEmpresa, vi_ano_inicio, Mes, vi_ver_placta);

                        oTrans.Complete();
                    }
                }

                return ListaSaldos;

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

        public Con_SaldosE Obtenercon_saldos(Int32 idEmpresa, Int32 idLocal, String AnioPeriodo, String MesPeriodo, String numVerPlanCuentas, String codCuenta)
        {
            try
            {
                return new Con_SaldosAD().Obtenercon_saldos(idEmpresa, idLocal, AnioPeriodo, MesPeriodo, numVerPlanCuentas,codCuenta);
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

        public List<Con_SaldosE> SaldoContableApertura(Int32 idEmpresa, String Anio, String Mes)
        {
            try
            {
                return new Con_SaldosAD().SaldoContableApertura(idEmpresa, Anio, Mes);
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
