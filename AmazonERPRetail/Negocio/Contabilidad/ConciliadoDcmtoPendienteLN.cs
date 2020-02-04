using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Linq;
using System.Transactions;

using Entidades.Contabilidad;
using AccesoDatos.Contabilidad;

namespace Negocio.Contabilidad
{
    public class ConciliadoDcmtoPendienteLN 
    {

        public List<ConciliadoDcmtoPendienteE> ReporteConciliadoBancos(Int32 idEmpresa, String AnioPeriodo, String MesPeriodo, String codCuenta)
        {
            try
            {
                return new ConciliadoDcmtoPendienteAD().ReporteConciliadoBancos(idEmpresa, AnioPeriodo, MesPeriodo, codCuenta);
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

        public void ProcesoCierreConciliacion(Int32 idEmpresa, Int32 idLocal, String ano_periodo, String cod_periodo)
        {
            try
            {
                new ConciliadoDcmtoPendienteAD().ProcesoCierreConciliacion(idEmpresa, idLocal, ano_periodo, cod_periodo);
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

        public ConciliadoDcmtoPendienteE ActualizarConciliadoDcmtoPendiente(ConciliadoDcmtoPendienteE conciliadodcmtopendiente)
        {
            try
            {
                return new ConciliadoDcmtoPendienteAD().ActualizarConciliadoDcmtoPendiente(conciliadodcmtopendiente);
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

        public ConciliadoDcmtoPendienteE ActualizarConciliado(ConciliadoDcmtoPendienteE conciliadodcmtopendiente)
        {
            try
            {
                return new ConciliadoDcmtoPendienteAD().ActualizarConciliado(conciliadodcmtopendiente);
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

        public int EliminarConciliadoDcmtoPendiente(Int32 idEmpresa, Int32 idLocal, String AnioPeriodo, String MesPeriodo, String numVerPlanCuentas, String codCuenta, Int32 idPersona, String idDocumento, String serDocumento, String numDocumento)
        {
            try
            {
                return new ConciliadoDcmtoPendienteAD().EliminarConciliadoDcmtoPendiente(idEmpresa, idLocal, AnioPeriodo, MesPeriodo, numVerPlanCuentas, codCuenta, idPersona, idDocumento, serDocumento, numDocumento);
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

        public List<ConciliadoDcmtoPendienteE> ListarConciliadoDcmtoPendiente(Int32 idEmpresa, Int32 idLocal, String AnioPeriodo, String MesPeriodo, String numVerPlanCuentas, String codCuenta)
        {
            try
            {
                return new ConciliadoDcmtoPendienteAD().ListarConciliadoDcmtoPendiente(idEmpresa, idLocal, AnioPeriodo, MesPeriodo, numVerPlanCuentas, codCuenta);
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

        public ConciliadoDcmtoPendienteE ObtenerConciliadoDcmtoPendiente(Int32 idEmpresa, Int32 idLocal, String AnioPeriodo, String MesPeriodo, String numVerPlanCuentas, String codCuenta, Int32 idPersona, String idDocumento, String serDocumento, String numDocumento)
        {
            try
            {
                return new ConciliadoDcmtoPendienteAD().ObtenerConciliadoDcmtoPendiente(idEmpresa, idLocal, AnioPeriodo, MesPeriodo, numVerPlanCuentas, codCuenta, idPersona, idDocumento, serDocumento, numDocumento);
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

        public List<ConciliadoDcmtoPendienteE> GrabarConciliado(List<ConciliadoDcmtoPendienteE> ListaConciliado)
        {
            try
            {
                using (TransactionScope oTrans = new TransactionScope())
                {

                    if (ListaConciliado != null && ListaConciliado.Count > 0)
                    {
                        foreach (ConciliadoDcmtoPendienteE oitem in ListaConciliado)
                        {
                            new ConciliadoDcmtoPendienteAD().ActualizarConciliadoDcmtoPendiente(oitem);
                        }
                    }

                    oTrans.Complete();
                }

                return ListaConciliado;
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

        public List<ConciliadoDcmtoPendienteE> ConciliacionPreliminar(Int32 idEmpresa, String AnioPeriodo, String MesPeriodo, String numVerPlanCuentas, String codCuenta, String idMoneda)
        {
            try
            {
                Int32 numRev = 1;
                String Glosita = String.Empty;
                List<ConciliadoDcmtoPendienteE> ListaDevuelta = new ConciliadoDcmtoPendienteAD().ConciliacionPreliminar(idEmpresa, AnioPeriodo, MesPeriodo, numVerPlanCuentas, codCuenta, idMoneda);

                List<ConciliadoDcmtoPendienteE> agrupado =
                (
                    from row in ListaDevuelta
                    group row by new { row.desGlosa, row.Orden } into g
                    select new ConciliadoDcmtoPendienteE()
                    {
                        Orden = g.Key.Orden,
                        desGlosa = g.Key.desGlosa,
                        impMonto = g.Sum(x => x.impMonto)
                    }
                ).ToList();

                foreach (ConciliadoDcmtoPendienteE item in agrupado)
                {
                    if (numRev == Convert.ToInt32(item.Orden))
                    {
                        item.Ignorar = false;
                        numRev++;
                    }
                    else
                    {
                        for (int i = numRev; i <= Convert.ToInt32(item.Orden); i++)
                        {
                            if (i == 1)
                            {
                                Glosita = "Saldo según EECC ";
                            }
                            else if (i == 2)
                            {
                                Glosita = "(-) Cheques girados y no cobrados";
                            }
                            else if (i == 3)
                            {
                                Glosita = "(-) Abonos en bancos no registrados en libros";
                            }
                            else if (i == 4)
                            {
                                Glosita = "(+) Abonos en libros no registrados en bancos";
                            }
                            else if (i == 5)
                            {
                                Glosita = "(+) Cargos en bancos no registrado en libros";
                            }
                            else
                            {
                                Glosita = "(-) Cargos en libros no registrado en bancos";
                            }

                            ConciliadoDcmtoPendienteE conciliado = new ConciliadoDcmtoPendienteE()
                            {
                                idEmpresa = item.idEmpresa,
                                fecDocumento = null,
                                desGlosa = Glosita,
                                impMonto = 0,
                                Orden = i.ToString(),
                                Ignorar = true
                            };
                            
                            ListaDevuelta.Add(conciliado);
                        }

                        numRev = Convert.ToInt32(item.Orden);
                        numRev++;
                    }
                }

                ListaDevuelta = (from x in ListaDevuelta orderby x.Orden, (DateTime?)x.fecDocumento select x).ToList();

                return ListaDevuelta;
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
