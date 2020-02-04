using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;

using Entidades.Contabilidad;
using AccesoDatos.Contabilidad;
using System.Transactions;

namespace Negocio.Contabilidad
{
    public class Con_SaldosCostosLN
    {
        public List<Con_SaldosCostosE> MayorizarCostos(Int32 idEmpresa, String as_anno, String vi_ver_placta)
        {
            try
            {
                // Proceso Antiguo
                // return new Con_SaldosCostosAD().MayorizarCostos(idEmpresa, as_anno);

                List<Con_SaldosCostosE> ListaSaldos = null;
                Int32 Inicio = 0;

                for (int i = Inicio; i <= 13; i++)
                {
                    TransactionOptions Opciones = new TransactionOptions();
                    Opciones.Timeout = TimeSpan.FromMinutes(750);

                    using (TransactionScope oTrans = new TransactionScope(TransactionScopeOption.Required, Opciones))
                    {

                        String Mes = i.ToString("00");
                        ListaSaldos = new Con_SaldosCostosAD().MayorizarCostosMes(idEmpresa, as_anno, Mes, vi_ver_placta);

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

        public List<Con_SaldosCostosE> ObtenerResumenDetallePorCentrodeCosto(Int32 idEmpresa, Int32 idLocal, String anioPeriodo, String periodo, String periodoFin, String numVerPlanCuenta, String codCuentaIni, String codCuentaFin,Int32 numNivel)
        {
            try
            {
                return new Con_SaldosCostosAD().ObtenerResumenDetallePorCentrodeCosto(idEmpresa, idLocal, anioPeriodo, periodo, periodoFin, numVerPlanCuenta, codCuentaIni, codCuentaFin,numNivel);
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
