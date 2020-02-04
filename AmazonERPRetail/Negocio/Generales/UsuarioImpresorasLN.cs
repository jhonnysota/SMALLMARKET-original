using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Transactions;

using Entidades.Generales;
using AccesoDatos.Generales;
using Infraestructura.Enumerados;

namespace Negocio.Generales
{
    public class UsuarioImpresorasLN
    {

        public UsuarioImpresorasE GrabarUsuarioImpresoras(UsuarioImpresorasE usuarioimpresoras, EnumOpcionGrabar opcionGrabar)
        {
            try
            {
                using (TransactionScope oTrans = new TransactionScope())
                {
                    if (opcionGrabar == EnumOpcionGrabar.Insertar)
                    {
                        usuarioimpresoras = new UsuarioImpresorasAD().InsertarUsuarioImpresoras(usuarioimpresoras);

                        foreach (UsuarioImpresorasDetE item in usuarioimpresoras.ListaCodBarras)
                        {
                            item.idImpresora = usuarioimpresoras.idImpresora;
                            //Insertando el detalle
                            new UsuarioImpresorasDetAD().InsertarUsuarioImpresorasDet(item);
                        }
                    }
                    else
                    {
                        //Actualizando la cabecera
                        usuarioimpresoras = new UsuarioImpresorasAD().ActualizarUsuarioImpresoras(usuarioimpresoras);

                        //Eliminando el detalle si hubiese
                        if (usuarioimpresoras.ListaBarrasEliminados != null && usuarioimpresoras.ListaBarrasEliminados.Count > 0)
                        {
                            foreach (UsuarioImpresorasDetE item in usuarioimpresoras.ListaBarrasEliminados)
                            {
                                new UsuarioImpresorasDetAD().EliminarUsuarioImpresorasDet(item.idImpresora, item.Item);
                            }
                        }

                        //Actualizando o Insertando el detalle
                        if (usuarioimpresoras.ListaCodBarras != null)
                        {
                            foreach (UsuarioImpresorasDetE item in usuarioimpresoras.ListaCodBarras)
                            {
                                item.idImpresora = usuarioimpresoras.idImpresora;

                                switch (item.Opcion)
                                {
                                    case (int)EnumOpcionGrabar.Insertar:
                                        new UsuarioImpresorasDetAD().InsertarUsuarioImpresorasDet(item);
                                        break;
                                    case (int)EnumOpcionGrabar.Actualizar:
                                        new UsuarioImpresorasDetAD().ActualizarUsuarioImpresorasDet(item);
                                        break;
                                    default:
                                        break;
                                }
                            }
                        }
                    }

                    oTrans.Complete();
                }

                return usuarioimpresoras;
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

        public UsuarioImpresorasE InsertarUsuarioImpresoras(UsuarioImpresorasE usuarioimpresoras)
        {
            try
            {
                return new UsuarioImpresorasAD().InsertarUsuarioImpresoras(usuarioimpresoras);
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

        public UsuarioImpresorasE ActualizarUsuarioImpresoras(UsuarioImpresorasE usuarioimpresoras)
        {
            try
            {
                return new UsuarioImpresorasAD().ActualizarUsuarioImpresoras(usuarioimpresoras);
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

        public int EliminarUsuarioImpresoras(Int32 idImpresora, Int32 idPersona)
        {
            try
            {
                return new UsuarioImpresorasAD().EliminarUsuarioImpresoras(idImpresora, idPersona);
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

        public List<UsuarioImpresorasE> ListarUsuarioImpresoras(Int32 idPersona)
        {
            try
            {
                return new UsuarioImpresorasAD().ListarUsuarioImpresoras(idPersona);
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

        public UsuarioImpresorasE ObtenerUsuarioImpresoras(Int32 idImpresora, Int32 idPersona, String ConDetalle = "N")
        {
            try
            {
                UsuarioImpresorasE usuario = new UsuarioImpresorasAD().ObtenerUsuarioImpresoras(idImpresora, idPersona);

                if (ConDetalle == "S")
                {
                    usuario.ListaCodBarras = new UsuarioImpresorasDetAD().ListarUsuarioImpresorasDet(idImpresora);
                }

                return usuario;
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

        public List<UsuarioImpresorasE> ListarUsuarioImpresorasBarras(Int32 idPersona)
        {
            try
            {
                return new UsuarioImpresorasAD().ListarUsuarioImpresorasBarras(idPersona);
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
