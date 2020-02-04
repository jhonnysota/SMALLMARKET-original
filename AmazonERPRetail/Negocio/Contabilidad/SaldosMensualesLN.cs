using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Transactions;

using Entidades.Contabilidad;
using AccesoDatos.Contabilidad;
using Infraestructura.Enumerados;

namespace Negocio.Contabilidad
{
    public class SaldosMensualesLN
    {
        public List<SaldosMensualesE> SaldosMensualesReporte(Int32 idEmpresa, String numVerPlanCuenta, Int32 idLocal, String AnioPeriodo, String codCuentaIni, String codCuentaFin, String MesIni, String MesFin, Int32 NivelCuenta)
        {
            try
            {
                return new SaldosMensualesAD().SaldosMensualesReporte(idEmpresa, numVerPlanCuenta, idLocal, AnioPeriodo, codCuentaIni, codCuentaFin, MesIni, MesFin, NivelCuenta);
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

        public List<SaldosMensualesE> SaldosCuentaAuxiliar(Int32 idEmpresa, String numVerPlanCuenta, Int32 idLocal, String AnioPeriodo, String codCuentaIni, String codCuentaFin, String MesIni, String MesFin, String idComprobante, Int32 NivelCuenta, String idMoneda)
        {
            try
            {
                return new SaldosMensualesAD().SaldosCuentaAuxiliar(idEmpresa, numVerPlanCuenta, idLocal, AnioPeriodo, codCuentaIni, codCuentaFin, MesIni, MesFin, idComprobante, NivelCuenta, idMoneda);
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

        public List<SaldosMensualesE> ReporteResumenMesesSaldos(Int32 idEmpresa, String numVerPlanCuenta, Int32 idLocal, String AnioPeriodo, String codCuentaIni, String codCuentaFin, String MesIni, String MesFin, Int32 NivelCuenta)
        {
            try
            {
                return new SaldosMensualesAD().ReporteResumenMesesSaldos(idEmpresa, numVerPlanCuenta, idLocal, AnioPeriodo, codCuentaIni, codCuentaFin, MesIni, MesFin, NivelCuenta);
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
