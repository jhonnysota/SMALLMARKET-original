using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;

using Entidades.Generales;
using AccesoDatos.Generales;

namespace Negocio.Generales
{
    public class UsuarioImpresorasDetLN
    {

        public UsuarioImpresorasDetE InsertarUsuarioImpresorasDet(UsuarioImpresorasDetE usuarioimpresorasdet)
        {
            try
            {
                return new UsuarioImpresorasDetAD().InsertarUsuarioImpresorasDet(usuarioimpresorasdet);
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

        public UsuarioImpresorasDetE ActualizarUsuarioImpresorasDet(UsuarioImpresorasDetE usuarioimpresorasdet)
        {
            try
            {
                return new UsuarioImpresorasDetAD().ActualizarUsuarioImpresorasDet(usuarioimpresorasdet);
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

        public int EliminarUsuarioImpresorasDet(Int32 idImpresora, Int32 Item)
        {
            try
            {
                return new UsuarioImpresorasDetAD().EliminarUsuarioImpresorasDet(idImpresora, Item);
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

        public List<UsuarioImpresorasDetE> ListarUsuarioImpresorasDet(Int32 idImpresora)
        {
            try
            {
                return new UsuarioImpresorasDetAD().ListarUsuarioImpresorasDet(idImpresora);
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

        public UsuarioImpresorasDetE ObtenerUsuarioImpresorasDet(Int32 idImpresora, Int32 Item)
        {
            try
            {
                return new UsuarioImpresorasDetAD().ObtenerUsuarioImpresorasDet(idImpresora, Item);
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