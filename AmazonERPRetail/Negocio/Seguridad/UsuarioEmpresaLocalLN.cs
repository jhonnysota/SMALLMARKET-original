using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Transactions;

using Entidades.Seguridad;
using Entidades.Maestros;
using AccesoDatos.Seguridad;

namespace Negocio.Seguridad
{
    public class UsuarioEmpresaLocalLN
    {
        
        public Usuario InsertarUsuarioEmpresaLocal(Usuario usuario)
        {
            UsuarioEmpresaLocal usuarioempresalocal = null;

            try
            {
                Int32 sw = 0;
                using (TransactionScope tx = new TransactionScope())
                {
                    //lista de perfiles
                    usuario.ListaUsuarioEmpresaLocalPerfil = new UsuarioEmpresaLocalPerfilAD().ListaUsuarioEmpresaLocalPerfilPorIdPersona(usuario.IdPersona);
                    new UsuarioEmpresaLocalPerfilAD().BorrarUsuarioEmpresaLocalPerfilPorIdPersona(usuario.IdPersona);
                    BorrarUsuarioEmpresaLocalPorIdPersona(usuario.IdPersona);

                    foreach (Empresa e in usuario.UsuarioEmpresas)
                    {
                        foreach (LocalE l in usuario.UsuarioLocales)
                        {    
                            if (e.IdEmpresa == l.IdEmpresa)
                            {
                                usuarioempresalocal = new UsuarioEmpresaLocal
                                {
                                    IdPersona = usuario.IdPersona,
                                    FechaActualizacion = DateTime.Now,
                                    FechaRegistro = DateTime.Now,
                                    UsuarioActualizacion = usuario.UsuarioModificacion,
                                    UsuarioRegistro = usuario.UsuarioRegistro,
                                    IdEmpresa = e.IdEmpresa,
                                    IdLocal = l.IdLocal,
                                    ListaUsuarioEmpresaLocalPerfil = (from x in usuario.ListaUsuarioEmpresaLocalPerfil where x.IdEmpresa == l.IdEmpresa && x.IdLocal == l.IdLocal select x).ToList()
                                };

                                new UsuarioEmpresaLocalAD().InsertarUsuarioEmpresaLocal(usuarioempresalocal);
                                sw = 1;

                                //insertar perfiles
                                foreach (UsuarioEmpresaLocalPerfil u in usuarioempresalocal.ListaUsuarioEmpresaLocalPerfil)
                                {
                                    new UsuarioEmpresaLocalPerfilAD().InsertarUsuarioEmpresaLocalPerfil(u);
                                }
                            }                            
                        }

                        if (sw == 0)
                        {
                            usuarioempresalocal = new UsuarioEmpresaLocal
                            {
                                IdPersona = usuario.IdPersona,
                                FechaActualizacion = DateTime.Now,
                                FechaRegistro = DateTime.Now,
                                UsuarioActualizacion = usuario.UsuarioModificacion,
                                UsuarioRegistro = usuario.UsuarioRegistro,
                                IdEmpresa = e.IdEmpresa,
                                IdLocal = 0
                            };

                            usuarioempresalocal = new UsuarioEmpresaLocalAD().InsertarUsuarioEmpresaLocal(usuarioempresalocal);
                        }
                        sw = 0;
                    }

                    tx.Complete();
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
        
        public List<UsuarioEmpresaLocal> ListarUsuarioEmpresaLocal()
        {
            try
            {
                return new UsuarioEmpresaLocalAD().ListarUsuarioEmpresaLocal();
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

        public Int32 BorrarUsuarioEmpresaLocalPorIdPersona(Int32 IdPersona)
        {
            try
            {
                return new UsuarioEmpresaLocalAD().BorrarUsuarioEmpresaLocalPorIdPersona(IdPersona);
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

        public List<UsuarioEmpresaLocal> RecuperarUsuarioEmpresaLocalPorEmpresa(Int32 idEmpresa)
        {
            try
            {
                return new UsuarioEmpresaLocalAD().RecuperarUsuarioEmpresaLocalPorEmpresa(idEmpresa);
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

        public List<UsuarioEmpresaLocal> ListarUsuarioEmpresaLocalPorUsuario(Int32 idPersona, Int32 idEmpresa)
        {
            try
            {
                return new UsuarioEmpresaLocalAD().ListarUsuarioEmpresaLocalPorUsuario(idPersona, idEmpresa);
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
        
        public Int32 BorrarUsuarioLocalEmpresa(Int32 idPersona, Int32 idEmpresa) 
        {
            try
            {
                return new UsuarioEmpresaLocalAD().BorrarUsuarioLocalEmpresa(idPersona, idEmpresa);
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

        public List<Usuario> ListarUsuariosLocalEmpresa(List<Empresa> ListaEmpresas)
        {
            try
            {
                List<Usuario> ListaUsuarios = new UsuarioAD().ListarUsuario("", false, false);
                List<UsuarioEmpresaLocal> oListaUsuarioEmpresaLocal = null;

                foreach (Empresa itemEmpresa in ListaEmpresas)
                {
                    foreach (Usuario item in ListaUsuarios)
                    {
                        oListaUsuarioEmpresaLocal = new UsuarioEmpresaLocalAD().ListarUsuarioEmpresaLocalPorUsuario(item.IdPersona, itemEmpresa.IdEmpresa);

                        if (oListaUsuarioEmpresaLocal.Count > 0)
                        {
                            item.ListaUsuarioEmpresaLocal.AddRange(oListaUsuarioEmpresaLocal);
                        }
                    }
                }

                return ListaUsuarios;
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
