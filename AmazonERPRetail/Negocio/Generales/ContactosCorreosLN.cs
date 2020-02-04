using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Linq;

using Entidades.Generales;
using Entidades.Maestros;
using Entidades.Seguridad;
using AccesoDatos.Generales;
using AccesoDatos.Maestros;
using AccesoDatos.Seguridad;

namespace Negocio.Generales
{
    public class ContactosCorreosLN
    {

        public ContactosCorreosE InsertarContactosCorreos(ContactosCorreosE contactoscorreos)
        {
            try
            {
                return new ContactosCorreosAD().InsertarContactosCorreos(contactoscorreos);
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

        public ContactosCorreosE ActualizarContactosCorreos(ContactosCorreosE contactoscorreos)
        {
            try
            {
                return new ContactosCorreosAD().ActualizarContactosCorreos(contactoscorreos);
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

        public int EliminarContactosCorreos(Int32 idGrupo, Int32 idCorreo)
        {
            try
            {
                return new ContactosCorreosAD().EliminarContactosCorreos(idGrupo, idCorreo);
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

        public List<ContactosCorreosE> ListarContactosCorreos()
        {
            try
            {
                return new ContactosCorreosAD().ListarContactosCorreos();
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

        public ContactosCorreosE ObtenerContactosCorreos(Int32 idCorreo)
        {
            try
            {
                return new ContactosCorreosAD().ObtenerContactosCorreos(idCorreo);
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

        public List<ContactosCorreosE> ListarCorreosBusqueda()
        {
            try
            {
                ContactosCorreosE oCorreo = null;
                List<ContactosCorreosE> oListaCorreos = new List<ContactosCorreosE>();
                List<Persona> oListaPersonaCorreo = new PersonaAD().ListarCorreosTrabajador();
                List<Usuario> oListaUsuarioCorreo = new UsuarioAD().ListarUsuariosCorreos();

                foreach (Persona item in oListaPersonaCorreo)
                {
                    oCorreo = new ContactosCorreosE()
                    {
                        Nombres = item.Nombres.Trim(),
                        Correo = item.Correo.Trim()
                    };

                    oListaCorreos.Add(oCorreo);
                }

                foreach (Usuario item in oListaUsuarioCorreo)
                {
                    oCorreo = new ContactosCorreosE()
                    {
                        Nombres = item.NombreCompleto.Trim(),
                        Correo = item.Correo.Trim()
                    };

                    oListaCorreos.Add(oCorreo);
                }
                
                var oListaTemporal = oListaCorreos.GroupBy(x => new { x.Correo, x.Nombres }).Select(p => p.First()).ToList();
                oListaCorreos = new List<ContactosCorreosE>(oListaTemporal.ToList());

                return oListaCorreos;
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

        public List<ContactosCorreosE> ListarCorreosPorDefecto(Int32 idUsuario)
        {
            try
            {
                return new ContactosCorreosAD().ListarCorreosPorDefecto(idUsuario);
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

        public List<ContactosCorreosE> ListarContactosCorreosPorGrupo(Int32 idGrupo)
        {
            try
            {
                return new ContactosCorreosAD().ListarContactosCorreosPorGrupo(idGrupo);
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