using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Transactions;

using Entidades.Seguridad;
using AccesoDatos.Seguridad;
using Infraestructura.Enumerados;

namespace Negocio.Seguridad
{
    public class UsuarioAccionLN
    {
        
        public String GrabarUsuarioAccion(List<UsuarioAccionE> ListaUsuariosAcciones, EnumOpcionGrabar Opcion)
        {
            try
            {
                String Mensaje = String.Empty;

                using (TransactionScope tx = new TransactionScope())
                {
                    if (Opcion == EnumOpcionGrabar.Insertar)
                    {
                        foreach (UsuarioAccionE item in ListaUsuariosAcciones)
                        {
                            new UsuarioAccionAD().InsertarUsuarioAccion(item);
                        }

                        Mensaje = "Ingreso Correcto";
                    }
                    else
                    {
                        //Eliminando lo anterior
                        BorrarUsuarioAccion(ListaUsuariosAcciones[0].idPersona, ListaUsuariosAcciones[0].idEmpresa, ListaUsuariosAcciones[0].idOpcion);

                        //Volviendo a insertar si tuviese
                        foreach (UsuarioAccionE item in ListaUsuariosAcciones)
                        {
                            new UsuarioAccionAD().InsertarUsuarioAccion(item);
                        }

                        Mensaje = "Registros Actualizados";
                    }

                    tx.Complete();
                }

                return Mensaje;
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

        public String InsertarUsuarioAccion(Usuario usuario, int idEmpresa)
        {
            try
            {
                using (TransactionScope tx = new TransactionScope())
                {
                    //BorrarUsuarioAccion(usuario.IdPersona, idEmpresa);

                    //foreach (AccionE a in usuario.Acciones)
                    //{
                    //    usuacc = new UsuarioAccionE
                    //    {
                    //        UsuarioRegistro = a.UsuarioRegistro,
                    //        idEmpresa = idEmpresa,
                    //        idPersona = usuario.IdPersona,
                    //        idAccion = a.IdAccion
                    //    };

                    //    new UsuarioAccionAD().InsertarUsuarioAccion(usuacc);
                    //}

                    tx.Complete();
                }

                return "Ingreso Correcto";
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

        public List<UsuarioAccionE> ListarUsuarioAccion(Int32 idPersona, Int32 idEmpresa)
        {
            try
            {
                List<UsuarioAccionE> MiLista = new UsuarioAccionAD().ListarUsuarioAccion(idPersona, idEmpresa);

                foreach (UsuarioAccionE item in MiLista)
                {
                    if (item.TomarOpcion && item.ItemsAccion == 0)
                    {
                        item.ItemFaltante = true;
                    }
                    else
                    {
                        item.ItemFaltante = false;
                    }
                }

                return MiLista;
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

        public int BorrarUsuarioAccion(Int32 idPersona, Int32 idEmpresa, Int32 idOpcion)
        {
            try
            {
                return new UsuarioAccionAD().BorrarUsuarioAccion(idPersona, idEmpresa, idOpcion);
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

        public List<UsuarioAccionE> ObtenerUsuarioAccion(Int32 idPersona, Int32 idEmpresa, Int32 idOpcion)
        {
            try
            {
                return new UsuarioAccionAD().ObtenerUsuarioAccion(idPersona, idEmpresa, idOpcion);
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
