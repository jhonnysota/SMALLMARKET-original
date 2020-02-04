using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;

using Entidades.Seguridad;
using AccesoDatos.Seguridad;

namespace Negocio.Seguridad
{
    public class UsuarioFondoFijoLN 
    {

        public UsuarioFondoFijoE InsertarUsuarioFondoFijo(UsuarioFondoFijoE UsuarioFondoFijo)
        {
            try
            {
                return new UsuarioFondoFijoAD().InsertarUsuarioFondoFijo(UsuarioFondoFijo);
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

        public UsuarioFondoFijoE ActualizarUsuarioFondoFijo(UsuarioFondoFijoE UsuarioFondoFijo)
        {
            try
            {
                return new UsuarioFondoFijoAD().ActualizarUsuarioFondoFijo(UsuarioFondoFijo);
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

        public int EliminarUsuarioFondoFijo(Int32 idEmpresa, Int32 idPersona, Int32 TipoFondo)
        {
            try
            {
                return new UsuarioFondoFijoAD().EliminarUsuarioFondoFijo(idEmpresa, idPersona, TipoFondo);
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

        public List<UsuarioFondoFijoE> ListarUsuarioFondoFijo(Int32 idEmpresa, Int32 idPersona)
        {
            try
            {
                return new UsuarioFondoFijoAD().ListarUsuarioFondoFijo(idEmpresa, idPersona);
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

        public List<Usuario> ListarFondosFijosPorUsuario()
        {
            List<Usuario> ListaRetorno = new UsuarioAD().ListarUsuario("", false, false);

            foreach (Usuario item in ListaRetorno)
            {
                item.ListaUsuarioFondoFijo = new UsuarioFondoFijoAD().UsuarioFondoFijoPorIdPersona(item.IdPersona);
            }

            return ListaRetorno;
        }

    }
}
