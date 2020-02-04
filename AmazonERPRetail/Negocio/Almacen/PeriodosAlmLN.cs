using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Transactions;

using Entidades.Almacen;
using AccesoDatos.Almacen;
using Infraestructura.Enumerados;

namespace Negocio.Almacen
{
    public class PeriodosAlmLN
    {

        public List<PeriodosAlmE> GrabarPeriodosAlm(List<PeriodosAlmE> listaperiodo)
        {
            try
            {
                using (TransactionScope oTrans = new TransactionScope())
                {

                    //Detalle de la lista de precios
                    if (listaperiodo != null && listaperiodo.Count > 0)
                    {
                        foreach (PeriodosAlmE oitem in listaperiodo)
                        {
                            switch (oitem.Opcion)
                            {
                                case (Int32)EnumOpcionGrabar.Insertar:
                                    new PeriodosAlmAD().InsertarPeriodosAlm(oitem);
                                    break;
                                case (Int32)EnumOpcionGrabar.Actualizar:
                                    new PeriodosAlmAD().ActualizarPeriodosAlm(oitem);
                                    break;
                                case (Int32)EnumOpcionGrabar.Eliminar:
                                    new PeriodosAlmAD().EliminarPeriodosAlm(oitem.idEmpresa, oitem.AnioPeriodo, oitem.MesPeriodo);
                                    break;
                                default:
                                    break;
                            }
                        }
                    }

                    oTrans.Complete();
                }

                return listaperiodo;
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

        public List<PeriodosAlmE> ListarPeriodosAlm(int idEmpresa, String AnioPeriodo)
        {
            try
            {
                return new PeriodosAlmAD().ListarPeriodosAlm(idEmpresa, AnioPeriodo);
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

        public int EliminarPeriodosAlm(int idEmpresa, string AnioPeriodo, string MesPeriodo)
        {
            try
            {
                return new PeriodosAlmAD().EliminarPeriodosAlm(idEmpresa, AnioPeriodo, MesPeriodo);
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

        public PeriodosAlmE ObtenerPeriodoPorMesAlm(int idEmpresa, string AnioPeriodo, string MesPeriodo)
        {
            try
            {
                return new PeriodosAlmAD().ObtenerPeriodoPorMesAlm(idEmpresa, AnioPeriodo, MesPeriodo);
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
