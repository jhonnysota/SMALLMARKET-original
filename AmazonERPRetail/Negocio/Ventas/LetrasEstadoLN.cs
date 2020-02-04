using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;

using Entidades.Ventas;
using AccesoDatos.Ventas;

namespace Negocio.Ventas
{
    public class LetrasEstadoLN
    {

        public LetrasEstadoE InsertarLetrasEstado(LetrasEstadoE letrasestado)
        {
            try
            {
                return new LetrasEstadoAD().InsertarLetrasEstado(letrasestado);
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

        public LetrasEstadoE ActualizarLetrasEstado(LetrasEstadoE letrasestado)
        {
            try
            {
                return new LetrasEstadoAD().ActualizarLetrasEstado(letrasestado);
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

        //public int EliminarLetrasEstado(Int32 idEmpresa, Int32 idLocal, String tipCanje, String codCanje, String Numero, String Corre, Int32 item)
        //{
        //    try
        //    {
        //        return new LetrasEstadoAD().EliminarLetrasEstado(idEmpresa, idLocal, tipCanje, codCanje, Numero, Corre, item);
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

        public List<LetrasEstadoE> ListarLetrasEstado()
        {
            try
            {
                return new LetrasEstadoAD().ListarLetrasEstado();
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

        public LetrasEstadoE ObtenerLetrasEstado(Int32 idEmpresa, Int32 idLocal, String tipCanje, String codCanje, String Numero, String Corre, Int32 item)
        {
            try
            {
                return new LetrasEstadoAD().ObtenerLetrasEstado(idEmpresa, idLocal, tipCanje, codCanje, Numero, Corre, item);
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

        public List<LetrasEstadoE> ListarEstadosLetras(Int32 idEmpresa, Int32 idLocal, String tipCanje, String codCanje, String Numero, String Corre)
        {
            try
            {
                return new LetrasEstadoAD().ListarEstadosLetras(idEmpresa, idLocal, tipCanje, codCanje, Numero, Corre);
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
