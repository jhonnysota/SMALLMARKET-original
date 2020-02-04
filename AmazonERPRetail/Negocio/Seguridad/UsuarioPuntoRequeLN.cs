using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;

using Entidades.Seguridad;
using AccesoDatos.Seguridad;

namespace Negocio.Seguridad
{
    public class UsuarioPuntoRequeLN
    {

        public UsuarioPuntoRequeE InsertarUsuarioPuntoReque(UsuarioPuntoRequeE usuariopuntoreque)
        {
            try
            {
                return new UsuarioPuntoRequeAD().InsertarUsuarioPuntoReque(usuariopuntoreque);
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

        public UsuarioPuntoRequeE ActualizarUsuarioPuntoReque(UsuarioPuntoRequeE usuariopuntoreque)
        {
            try
            {
                return new UsuarioPuntoRequeAD().ActualizarUsuarioPuntoReque(usuariopuntoreque);
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

        public int EliminarUsuarioPuntoReque(Int32 idUsuario)
        {
            try
            {
                return new UsuarioPuntoRequeAD().EliminarUsuarioPuntoReque(idUsuario);
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

        public List<UsuarioPuntoRequeE> ListarUsuarioPuntoReque(Int32 idUsuario)
        {
            try
            {
                return new UsuarioPuntoRequeAD().ListarUsuarioPuntoReque(idUsuario);
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

        public UsuarioPuntoRequeE ObtenerUsuarioPuntoReque(Int32 idUsuario, Int32 idPuntoReq)
        {
            try
            {
                return new UsuarioPuntoRequeAD().ObtenerUsuarioPuntoReque(idUsuario, idPuntoReq);
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
