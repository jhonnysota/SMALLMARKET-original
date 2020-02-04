using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;

using Entidades.Seguridad;
using AccesoDatos.Seguridad;

namespace Negocio.Seguridad
{
    public class AsignarTipoCobranzaLN
    {

        public AsignarTipoCobranzaE InsertarAsignarTipoCobranza(AsignarTipoCobranzaE asignartipocobranza)
        {
            try
            {
                return new AsignarTipoCobranzaAD().InsertarAsignarTipoCobranza(asignartipocobranza);
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

        public AsignarTipoCobranzaE ActualizarAsignarTipoCobranza(AsignarTipoCobranzaE asignartipocobranza)
        {
            try
            {
                return new AsignarTipoCobranzaAD().ActualizarAsignarTipoCobranza(asignartipocobranza);
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

        public int EliminarAsignarTipoCobranza(Int32 idEmpresa, Int32 idLocal, Int32 idUsuario, Int32 idTipoPlanilla)
        {
            try
            {
                return new AsignarTipoCobranzaAD().EliminarAsignarTipoCobranza(idEmpresa, idLocal, idUsuario, idTipoPlanilla);
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

        //public List<AsignarTipoCobranzaE> ListarTipCobranzaPorUsuario(Int32 idEmpresa, Int32 idLocal)
        //{
        //    try
        //    {
        //        return new AsignarTipoCobranzaAD().ListarTipCobranzaPorUsuario(idEmpresa, idLocal);
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

        public AsignarTipoCobranzaE ObtenerAsignarTipoCobranza(Int32 idEmpresa, Int32 idLocal, Int32 idUsuario, Int32 idTipoPlanilla)
        {
            try
            {
                return new AsignarTipoCobranzaAD().ObtenerAsignarTipoCobranza(idEmpresa, idLocal, idUsuario, idTipoPlanilla);
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

        public List<Usuario> ListarTipoCobranzaPorUsuario()
        {
            List<Usuario> ListaRetorno = new UsuarioAD().ListarUsuario("", false, false);

            foreach (Usuario item in ListaRetorno)
            {
                item.ListaTipoCobranzas = new AsignarTipoCobranzaAD().ListarTipCobranzaPorUsuario(item.IdPersona);
            }

            return ListaRetorno;
        }

        public List<AsignarTipoCobranzaE> ListarTipoCobranza(Int32 idEmpresa, Int32 idLocal, Int32 idUsuario)
        {
            try
            {
                return new AsignarTipoCobranzaAD().ListarTipoCobranza(idEmpresa, idLocal, idUsuario);
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
