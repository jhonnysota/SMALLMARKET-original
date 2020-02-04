using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;

using Entidades.Contabilidad;
using AccesoDatos.Contabilidad;
using Infraestructura;
using System.Transactions;

namespace Negocio.Contabilidad
{
    public class conCtaCteLN
    {
        public conCtaCteE InsertarConCtaCte(conCtaCteE ctacte)
        {
            try
            {
                return new conCtaCteAD().InsertarConCtaCte(ctacte);
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

        public conCtaCteE ActualizarConCtaCte(conCtaCteE ctacte)
        {
            try
            {
                return new conCtaCteAD().ActualizarConCtaCte(ctacte);
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

        public Int32 EliminarConCtaCte(Int32 idCtaCte)
        {
            try
            {
                return new conCtaCteAD().EliminarConCtaCte(idCtaCte);
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

        public List<conCtaCteE> ListarConCtaCte()
        {
            try
            {
                return new conCtaCteAD().ListarConCtaCte();
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

        public conCtaCteE ObtenerConCtaCte(Int32 idCtaCte)
        {
            try
            {
                return new conCtaCteAD().ObtenerConCtaCte(idCtaCte);
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

        public List<conCtaCteE> ResumenConCtaCtePorParametros(Int32 idEmpresa, String codCuenta, Int32 idPersona, DateTime Fecha, String Estado)
        {
            try
            {
                //Estado = P (Pendientes) Estado = C (Canceladas) Estado = A (Ambas)
                List<conCtaCteE> oListaCtaCteTemporal = new conCtaCteAD().ResumenConCtaCtePorParametros(idEmpresa, codCuenta, idPersona, Fecha);
                //List<conCtaCteItemE> oListaItems = new conCtaCteItemAD().DetalleConCtaCtePorParametros(idEmpresa, codCuenta, idPersona, Fecha);
                List<conCtaCteE> oListaCtaCte = new List<conCtaCteE>();

                foreach (conCtaCteE itemCab in oListaCtaCteTemporal)
                {
                    itemCab.ListaCtaCteItems = new conCtaCteItemAD().DetalleConCtaCtePorParametros(itemCab.idCtaCte, idEmpresa, codCuenta, idPersona, Fecha);
                }

                foreach (conCtaCteE item in oListaCtaCteTemporal)
                {
                    if (Estado == "P")
                    {
                        if (item.SaldoSoles > Variables.Cero)
                        {
                            oListaCtaCte.Add(item);
                        }
                    }
                    else if (Estado == "C")
                    {
                        if (item.SaldoSoles == Variables.Cero)
                        {
                            oListaCtaCte.Add(item);
                        }
                    }
                    else
                    {
                        oListaCtaCte.Add(item);
                    }
                }

                return oListaCtaCte;
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

        public List<conCtaCteE> ReporteConCtaCtePendientes(Int32 idEmpresa, String numPlanCta, String ano, String cuenta_ini, String cuenta_fin,
                                                           Int32 idPersona, String mes_inicial, String mes_fin, String idmoneda, String historico, String tipo_reporte)
        {
            try
            {
                List<conCtaCteE> Lista = null;

                TransactionOptions Opciones = new TransactionOptions
                {
                    Timeout = TimeSpan.FromMinutes(720)
                };

                using (TransactionScope oTrans = new TransactionScope(TransactionScopeOption.Required, Opciones))
                {


                   Lista = new conCtaCteAD().ReporteConCtaCtePendientes(idEmpresa, numPlanCta, ano, cuenta_ini, cuenta_fin, idPersona, mes_inicial, mes_fin, idmoneda, historico, tipo_reporte);

                   oTrans.Complete();
                }

                return Lista;

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

        public List<conCtaCteE> ReporteInventarioBalanceCtaCte(Int32 idEmpresa, String Anio, String Mes,  Int32 Tipo)
        {
            try
            {
                return new conCtaCteAD().ReporteInventarioBalanceCtaCte(idEmpresa, Anio, Mes, Tipo);
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
