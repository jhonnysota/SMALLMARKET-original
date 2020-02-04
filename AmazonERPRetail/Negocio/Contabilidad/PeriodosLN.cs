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
//using Negocio.Base;

namespace Negocio.Contabilidad
{
    public class PeriodosLN //: BaseLN
    {
        public PeriodosE InsertarPeriodos(PeriodosE periodos)
        {
            try
            {
                return new PeriodosAD().InsertarPeriodos(periodos);
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

        public PeriodosE ActualizarPeriodos(PeriodosE periodos)
        {
            try
            {
                return new PeriodosAD().ActualizarPeriodos(periodos);
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

        public List<PeriodosE> ActualizarPeriodosLista(List<PeriodosE> listaperiodos)
        {
            try
            {
                using (TransactionScope oTrans = new TransactionScope())
                {
                    PeriodosE Operiodo = new PeriodosE();
                  
                   

                    if (listaperiodos != null)
                        {
                            foreach (PeriodosE item in listaperiodos)
                            {
                                //for (int ii = 0; ii < listaperiodos.Count; ii++)
                                // { 
                                //item.indAaFinMes = listaperiodos[ii].indAaFinMes;
                                //item.indAjusteDifCambio = listaperiodos[ii].indAjusteDifCambio;
                                //item.indAjustePorDocFinMes = listaperiodos[ii].indAjustePorDocFinMes;
                                //item.indApertura = listaperiodos[ii].indApertura;
                                //item.indCierre = listaperiodos[ii].indCierre;
                                //item.indEfectivoAjusteFinMes = listaperiodos[ii].indEfectivoAjusteFinMes;
                                //item.indEfectivoAsientos = listaperiodos[ii].indEfectivoAsientos;
                                //item.indReapertura = listaperiodos[ii].indReapertura;

                                Operiodo = new PeriodosAD().ActualizarPeriodos(item);
                                //}
                            }
                        }
                     oTrans.Complete();
                    }

                return listaperiodos;
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

        public List<PeriodosE> ListarPeriodos(int idEmpresa, String AnioPeriodo)
        {
            try
            {
                return new PeriodosAD().ListarPeriodos(idEmpresa, AnioPeriodo);
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

        public int EliminarPeriodos(int idEmpresa, string AnioPeriodo, string MesPeriodo)
        {
            try
            {
                return new PeriodosAD().EliminarPeriodos(idEmpresa, AnioPeriodo, MesPeriodo);
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

        public PeriodosE ObtenerPeriodoPorMes(int idEmpresa, string AnioPeriodo, string MesPeriodo)
        {
            try
            {
                return new PeriodosAD().ObtenerPeriodoPorMes(idEmpresa, AnioPeriodo, MesPeriodo);
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

        public int AperturaAnioContable(int idEmpresa, string AnioPeriodo, string MesPeriodo, string UsuarioRegistro)
        {
            try
            {
                return new PeriodosAD().AperturaAnioContable(idEmpresa, AnioPeriodo, MesPeriodo, UsuarioRegistro);
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
