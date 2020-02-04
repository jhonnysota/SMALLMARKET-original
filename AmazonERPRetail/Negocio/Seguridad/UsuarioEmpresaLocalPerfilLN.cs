using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Transactions;

using Entidades.Seguridad;
using Entidades.Maestros;
using AccesoDatos.Seguridad;

namespace Negocio.Seguridad
{
    public class UsuarioEmpresaLocalPerfilLN
    {
        public List<UsuarioEmpresaLocalPerfil> ListaUsuarioEmpresaLocalPerfilPorUsuario(Int32 idPersona, Int32 idEmpresa, Int32 idLocal) {

            try
            {
                return new UsuarioEmpresaLocalPerfilAD().ListaUsuarioEmpresaLocalPerfilPorUsuario(idPersona, idEmpresa, idLocal);
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

        public UsuarioEmpresaLocalPerfil InsertarUsuarioEmpresaLocalPerfil(UsuarioEmpresaLocalPerfil vUsuarioEmpresaLocalPerfil) {

            try
            {
                return new UsuarioEmpresaLocalPerfilAD().InsertarUsuarioEmpresaLocalPerfil(vUsuarioEmpresaLocalPerfil);
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

        public Int32 BorrarUsuarioEmpresaLocalPerfil(Int32 idPersona, Int32 idEmpresa)
        {

            try
            {
                return new UsuarioEmpresaLocalPerfilAD().BorrarUsuarioEmpresaLocalPerfil(idPersona, idEmpresa);
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

        public Usuario GrabarUsuarioEmpresaLocalPerfil(Usuario vUsuario) 
        {
            try
            {
                using (TransactionScope tx = new TransactionScope())
                {
                    if (vUsuario.ListaUsuarioEmpresaLocal != null) 
                    {
                        //Elimimando Los locales y Perfiles 
                        //new UsuarioEmpresaLocalPerfilAD().BorrarUsuarioEmpresaLocalPerfil(vUsuario.IdPersona, vUsuario.IdEmpresa);
                        new UsuarioEmpresaLocalAD().BorrarUsuarioEmpresaLocalPorIdPersona(vUsuario.IdPersona);

                        foreach (UsuarioEmpresaLocal item in vUsuario.ListaUsuarioEmpresaLocal) 
                        {
                            //Insertando Locales del Usuario
                            new UsuarioEmpresaLocalAD().InsertarUsuarioEmpresaLocal(item);
                            
                            //if (item.ListaUsuarioEmpresaLocalPerfil != null) 
                            //{
                            //    foreach (UsuarioEmpresaLocalPerfil item2 in item.ListaUsuarioEmpresaLocalPerfil)
                            //    {
                            //        //Insertando Perfiles del Usuario
                            //        new UsuarioEmpresaLocalPerfilAD().InsertarUsuarioEmpresaLocalPerfil(item2);
                            //    }
                            //}
                        }
                    }

                    tx.Complete();
                }

                return vUsuario;
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

        public UsuarioEmpresaLocalPerfil RecuperarUsuarioEmpresaLocalPerfil(Int32 idEmpresa, Int32 idLocal, Int32 idPerfil) 
        {
            return new UsuarioEmpresaLocalPerfilAD().RecuperarUsuarioEmpresaLocalPerfil(idEmpresa, idLocal, idPerfil);
        }

        public Persona GrabarPersonaEmpresaLocalPerfil(Persona vPersona)
        {
            try
            {
                using (TransactionScope tx = new TransactionScope())
                {
                    if (vPersona.ListaPersonaEmpresaLocal != null)
                    {
                        //Elimimando Los locales y Perfiles 
                        //new UsuarioEmpresaLocalPerfilAD().BorrarUsuarioEmpresaLocalPerfil(vPersona.IdPersona, vPersona.IdEmpresa);
                        //new UsuarioEmpresaLocalLN().BorrarUsuarioLocalEmpresa(vPersona.IdPersona, vPersona.IdEmpresa);
                        
                        new UsuarioEmpresaLocalPerfilAD().BorrarUsuarioEmpresaLocalPerfilPorIdPersona(vPersona.IdPersona);
                        new UsuarioEmpresaLocalLN().BorrarUsuarioEmpresaLocalPorIdPersona(vPersona.IdPersona);
                        
                        foreach (UsuarioEmpresaLocal item in vPersona.ListaPersonaEmpresaLocal)
                        {
                            //Insertando Locales del Usuario
                            new UsuarioEmpresaLocalAD().InsertarUsuarioEmpresaLocal(item);
                            if (item.ListaUsuarioEmpresaLocalPerfil != null)
                            {
                                foreach (UsuarioEmpresaLocalPerfil item2 in item.ListaUsuarioEmpresaLocalPerfil)
                                {

                                    //Insertando Perfiles del Usuario
                                    new UsuarioEmpresaLocalPerfilAD().InsertarUsuarioEmpresaLocalPerfil(item2);

                                }
                            }
                        }

                    }
                    tx.Complete();
                }
                return vPersona;

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

        public List<UsuarioEmpresaLocalPerfil> ListarUsuarioEmpresaLocalPerfil(Int32 IdEmpresa, Int32 IdLocal)
        {
            try
            {
                return new UsuarioEmpresaLocalPerfilAD().ListarUsuarioEmpresaLocalPerfil(  IdEmpresa,   IdLocal);
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

        public List<UsuarioEmpresaLocalPerfil> Listar_UsuarioEmpresaLocalPerfil(Int32 IdEmpresa, Int32 IdLocal, Int32 IdPerfil, String Parametro, bool ValidaPerfil, bool Estado)
        {
            try
            {
                return new UsuarioEmpresaLocalPerfilAD().Listar_UsuarioEmpresaLocalPerfil(IdEmpresa, IdLocal, IdPerfil, Parametro, ValidaPerfil, Estado);
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
