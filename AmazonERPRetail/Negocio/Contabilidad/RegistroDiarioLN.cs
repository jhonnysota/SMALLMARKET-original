using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Transactions;

using Entidades.Contabilidad;
using AccesoDatos.Contabilidad;

namespace Negocio.Contabilidad
{
    public class RegistroDiarioLN
    {

        public List<RegistroDiarioE> RegistroDeDiarioPLE(Int32 idEmpresa, Int32 idLocal, String MesIni, String MesFin, String AnioPeriodo, String numVerPlanCuenta, String idComprobanteInicial, String idComprobanteFinal)
        {
            try
            {
                Int32 CantidadReg = new RegistroDiarioAD().CantidadRegistroDiario(idEmpresa, idLocal, MesIni, MesFin, AnioPeriodo, numVerPlanCuenta, idComprobanteInicial, idComprobanteFinal);
                List<RegistroDiarioE> LibroDiario = new List<RegistroDiarioE>();

                if (CantidadReg > 0)
                {
                    Decimal Paginas = CantidadReg / 1000;
                    Int32 totPaginas = Convert.ToInt32(Paginas);
                    List<RegistroDiarioE> LibroDiarioTmp = null;

                    for (int i = 0; i <= totPaginas; i++)
                    {
                        LibroDiarioTmp = ObtenerDiario(idEmpresa, idLocal, MesIni, MesFin, AnioPeriodo, numVerPlanCuenta, idComprobanteInicial, idComprobanteFinal, i, 1000);

                        if (LibroDiarioTmp != null && LibroDiarioTmp.Count > 0)
                        {
                            LibroDiario.AddRange(LibroDiarioTmp);
                        }
                    }
                }

                return LibroDiario;
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

        public List<RegistroDiarioE> RegistroDeDiarioEXCEL(Int32 idEmpresa, Int32 idLocal, DateTime FechaIni, DateTime FechaFin, String NumVerPlanCuenta, String idComprobanteInicial, String idComprobanteFinal, String Automatico)
        {
            try
            {
                return new RegistroDiarioAD().RegistroDeDiarioEXCEL(idEmpresa,idLocal,FechaIni, FechaFin, NumVerPlanCuenta, idComprobanteInicial, idComprobanteFinal, Automatico);
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

        public List<RegistroDiarioE> ObtenerDetallePorCenttroDeCostro(Int32 idEmpresa, Int32 idLocal, Int32 anioPeriodo, DateTime fecIni, DateTime fecFin, String codCuentaIni, String codCuentaFin, Int32 numNivel)
        {
            try
            {
                return new RegistroDiarioAD().ObtenerDetallePorCenttroDeCostro(idEmpresa, idLocal, anioPeriodo, fecIni, fecFin, codCuentaIni, codCuentaFin,numNivel);
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

        //public List<RegistroDiarioE> ObtenerLibroMayor(Int32 idEmpresa, Int32 idLocal, String numVerPlanCuenta, String anioPeriodo, String fecIni, String fecFin, String codCuentaIni, String codCuentaFin, Int32 CantidadReg)
        //{
        //    try
        //    {
        //        List<RegistroDiarioE> LibroMayor = new List<RegistroDiarioE>();

        //        if (CantidadReg > 0)
        //        {
        //            Decimal Paginas = CantidadReg / 1000;
        //            Int32 totPaginas = Convert.ToInt32(Paginas);

        //            for (int i = 0; i <= totPaginas; i++)
        //            {
        //                List<RegistroDiarioE> LibroTmp = ObtenerMayor(idEmpresa, idLocal, numVerPlanCuenta, anioPeriodo, fecIni, fecFin, codCuentaIni, codCuentaFin, i, 1000);

        //                if (LibroTmp != null && LibroTmp.Count > 0)
        //                {
        //                    LibroMayor.AddRange(LibroTmp);
        //                }
        //            }
        //        }

        //        return LibroMayor;
        //    }
        //    catch (SqlException ex)
        //    {
        //        SqlError err = ex.Errors[0];
        //        StringBuilder mensaje = new StringBuilder();

        //        switch (err.Number)
        //        {
        //            default:
        //                mensaje.Append("Mensaje: " + err.Message + "\n");
        //                mensaje.Append("N° Linea: " + err.LineNumber + "\n");
        //                mensaje.Append("Origen: " + err.Source + "\n");
        //                mensaje.Append("Procedimiento: " + err.Procedure + "\n");
        //                mensaje.Append("N° Error: " + err.Number);
        //                break;
        //        }

        //        throw new Exception(mensaje.ToString());
        //    }
        //}

        public List<RegistroDiarioE> RegistroDeDiarioSimplificado(Int32 idEmpresa, Int32 idLocal, String MesIni, String MesFin, String AnioPeriodo, String numVerPlanCuenta, String idComprobanteInicial, String idComprobanteFinal)
        {
            try
            {
                return RegistroDeDiarioPLE(idEmpresa, idLocal, MesIni, MesFin, AnioPeriodo, numVerPlanCuenta, idComprobanteInicial, idComprobanteFinal);
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

        public Int32 CantidadRegistroMayor(Int32 idEmpresa, Int32 idLocal, String numVerPlanCuenta, String anioPeriodo, String fecIni, String fecFin, String codCuentaIni, String codCuentaFin)
        {
            try
            {
                return new RegistroDiarioAD().CantidadRegistroMayor(idEmpresa, idLocal, numVerPlanCuenta, anioPeriodo, fecIni, fecFin, codCuentaIni, codCuentaFin);
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

        #region Privados

        private List<RegistroDiarioE> ObtenerDiario(Int32 idEmpresa, Int32 idLocal, String MesIni, String MesFin, String AnioPeriodo, String numVerPlanCuenta, String idComprobanteInicial, String idComprobanteFinal, Int32 Pag, Int32 CantReg)
        {
            try
            {
                List<RegistroDiarioE> LibroDiario = null;
                TransactionOptions Opciones = new TransactionOptions
                {
                    Timeout = TimeSpan.FromMinutes(720)
                };

                using (TransactionScope oTrans = new TransactionScope(TransactionScopeOption.Required, Opciones))
                {
                    LibroDiario = new RegistroDiarioAD().RegistroDeDiarioPLE(idEmpresa, idLocal, MesIni, MesFin, AnioPeriodo, numVerPlanCuenta, idComprobanteInicial, idComprobanteFinal, Pag, CantReg);

                    oTrans.Complete();
                }

                return LibroDiario;
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

        public List<RegistroDiarioE> ObtenerLibroMayor(Int32 idEmpresa, Int32 idLocal, String numVerPlanCuenta, String anioPeriodo, String fecIni, String fecFin, String codCuentaIni, String codCuentaFin, Int32 Pag, Int32 CantReg)
        {
            try
            {
                List<RegistroDiarioE> LibroMayor = null;

                TransactionOptions Opciones = new TransactionOptions
                {
                    Timeout = TimeSpan.FromMinutes(1440)
                };

                using (TransactionScope oTrans = new TransactionScope(TransactionScopeOption.Required, Opciones))
                {
                    LibroMayor = new RegistroDiarioAD().ObtenerLibroMayor(idEmpresa, idLocal, numVerPlanCuenta, anioPeriodo, fecIni, fecFin, codCuentaIni, codCuentaFin, Pag, CantReg);

                    oTrans.Complete();
                }

                return LibroMayor;
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

        #endregion

    }
}
