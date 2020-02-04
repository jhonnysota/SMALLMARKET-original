using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

using Entidades.Contabilidad;
using AccesoDatos.Contabilidad;
using Infraestructura;
using System.Transactions;

namespace Negocio.Contabilidad
{
    public class CierreCuentaLN
    {
        public void ProcesoCierreCuentaPreLiminar(int idEmpresa, int idLocal, DateTime fecCierre)
        {
            try
            {
                new CierreCuentaAD().ProcesoCierreCuentaPreLiminar( idEmpresa,  idLocal, fecCierre);

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

        public void ProcesoCierreResultado(int idEmpresa, int idLocal, string Version, string AnioCierre, DateTime fecCierre, int Nivel, Decimal tcCie, string idMoneda, string idDiario, string idFile)
        {
            try
            {
                using (TransactionScope oTrans = new TransactionScope())
                {

                    new CierreCuentaAD().ProcesoCierreCuentaResultado(idEmpresa, idLocal, Version, AnioCierre, fecCierre, Nivel, tcCie, idMoneda, idDiario, idFile);

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

        public void EliminaCierreBalance(int idEmpresa, int idLocal, string AnioCierre, string idDiario, string idFile)
        {
            try
            {
                using (TransactionScope oTrans = new TransactionScope())
                {

                    new VoucherAD().TriggerVouchers(true); //Desabilita Trigger

                    new CierreCuentaAD().EliminaCierreBalance(idEmpresa, idLocal, AnioCierre, idDiario, idFile);

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

        public void ProcesoCierreCuentaBalance(int idEmpresa, int idLocal, string Version, string AnioCierre, string MesApertura, string AnioApertura, DateTime fecCierre, DateTime fecApertura, int Nivel, Decimal tcCie, Decimal tcApe, string idMoneda, string CtaCie, string CtaApe, string idDiario, string idFile)
        {
            try
            {
                using (TransactionScope oTrans = new TransactionScope())
                {

                    new CierreCuentaAD().ProcesoCierreCuentaBalance(idEmpresa, idLocal, Version, AnioCierre, MesApertura, AnioApertura, fecCierre,fecApertura,Nivel,tcCie,tcApe,idMoneda,CtaCie,CtaApe, idDiario, idFile );

                    string MesCierre = "13";
                    string CtaResultado = "";
                    string CtaAcumulada = "";
                    decimal MontoResultadoSoles = 0;
                    decimal MontoResultadoDolar = 0;

                    new VoucherAD().TriggerVouchers(true); //Desabilita Trigger

                    new CierreCuentaAD().GeneraAperturaContable(idEmpresa, idLocal, Version, MesApertura, AnioApertura, MesCierre, AnioCierre, fecApertura, tcApe, idMoneda, idDiario, idFile, "01", "01" , CtaResultado, CtaAcumulada, MontoResultadoSoles, MontoResultadoDolar);

                    new VoucherAD().TriggerVouchers(false); //Habilita Trigger

                    new Con_SaldosLN().MayorizarMayor(idEmpresa, idLocal, "00", AnioApertura, "13", AnioApertura, Version);

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
