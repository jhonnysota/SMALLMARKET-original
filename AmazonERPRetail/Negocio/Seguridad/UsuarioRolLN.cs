using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

using Entidades.Seguridad;
using AccesoDatos.Seguridad;
using Infraestructura;
using System.Transactions;

namespace Negocio.Seguridad
{
    public class UsuarioRolLN
    {
        
        UsuarioRol usurol = null;
        public String InsertarUsuarioRol(List<Usuario> usuariosRol,int idEmpresa)
        {
            try
            {
                using (TransactionScope tx = new TransactionScope())
                {
                    foreach (Usuario u in usuariosRol) {
                        AnularUsuarioRolPorCodigo(idEmpresa, u.IdPersona);
                        foreach (Rol r in u.Roles)
                        {
                            usurol = new UsuarioRol();
                            usurol.FechaActualizacion = DateTime.Now;
                            usurol.FechaRegistro = DateTime.Now;
                            usurol.UsuarioActualizacion = r.UsuarioRegistro;
                            usurol.UsuarioRegistro = r.UsuarioRegistro;
                            usurol.Estado = r.Estado;
                            usurol.IdEmpresa = idEmpresa;
                            usurol.IdPersona = u.IdPersona;
                            usurol.IdRol = r.IdRol;
                            new UsuarioRolAD().InsertarUsuarioRol(usurol);
                        }
                    }
                    tx.Complete();
                    return "Ingreso Correcto";
                }
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

        public UsuarioRol ActualizarUsuarioRol(UsuarioRol usuariorol)
        {
            try
            {
                return new UsuarioRolAD().ActualizarUsuarioRol(usuariorol);
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

        public List<UsuarioRol> ListarUsuarioRol()
        {
            try
            {
                return new UsuarioRolAD().ListarUsuarioRol();
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

        public int AnularUsuarioRolPorCodigo(int IdEmpresa, int IdPersona)
        {
            try
            {
                return new UsuarioRolAD().BorrarUsuarioRol(IdEmpresa, IdPersona);
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

        public UsuarioRol RecuperarUsuarioRolPorCodigo(int IdPersona, int IdRol, int IdEmpresa)
        {
            try
            {
                return new UsuarioRolAD().RecuperarUsuarioRolPorCodigo(IdPersona, IdRol, IdEmpresa);
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
