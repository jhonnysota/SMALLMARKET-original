using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Transactions;

using Entidades.Seguridad;
using AccesoDatos.Seguridad;
using AccesoDatos.Maestros;
using Negocio.Maestros;
using Infraestructura.Enumerados;
using Infraestructura;

namespace Negocio.Seguridad
{
    public class UsuarioLN
    {

        public Usuario GrabarUsuario(Usuario oUsuario, EnumOpcionGrabar OpcionGrabar)
        {
            try
            {
                using (TransactionScope oTrans = new TransactionScope())
                {
                    switch (OpcionGrabar)
                    {
                        case EnumOpcionGrabar.Actualizar:

                            //Actualizando las personas
                            new PersonaAD().ActualizarPersona(oUsuario.Persona);
                            //Actualizando el Usuario
                            new UsuarioAD().ActualizarUsuario(oUsuario);

                            //Centro de Costos
                            new UsuarioCCostosAD().EliminarUsuarioCCostos(oUsuario.IdPersona);

                            if (oUsuario.listaUsuarioCCostos != null && oUsuario.listaUsuarioCCostos.Count > 0)
                            {
                                foreach (UsuarioCCostosE oitem in oUsuario.listaUsuarioCCostos)
                                {
                                    oitem.idPersona = oUsuario.IdPersona;
                                    new UsuarioCCostosAD().InsertarUsuarioCCostos(oitem);
                                }
                            }

                            //Planillas
                            new UsuarioPlanillaAD().EliminarUsuarioPlanilla(oUsuario.Persona.IdPersona, oUsuario.Empresa.IdEmpresa);

                            if (oUsuario.ListaUsuarioPlanilla != null)
                            {
                                foreach (UsuarioPlanillaE oitem in oUsuario.ListaUsuarioPlanilla)
                                {
                                    if (oitem.Opcion == 0)
                                    {
                                        oitem.Opcion = (Int32)EnumOpcionGrabar.Insertar;
                                    }

                                    if (oitem.Opcion == (Int32)EnumOpcionGrabar.Insertar)
                                    {
                                        new UsuarioPlanillaAD().InsertarUsuarioPlanilla(oitem);
                                    }

                                    if (oitem.Opcion == (Int32)EnumOpcionGrabar.Actualizar)
                                    {
                                        new UsuarioPlanillaAD().ActualizarUsuarioPlanilla(oitem);
                                    }
                                }
                            }

                            //Series
                            new UsuarioSeriesAD().EliminarUsuarioSeries(oUsuario.Empresa.IdEmpresa, oUsuario.Persona.IdPersona);

                            if (oUsuario.ListaSeries != null && oUsuario.ListaSeries.Count > 0)
                            {
                                foreach (UsuarioSeriesE item in oUsuario.ListaSeries)
                                {
                                    item.idUsuario = oUsuario.Persona.IdPersona;
                                    new UsuarioSeriesAD().InsertarUsuarioSeries(item);
                                }
                            }

                            if (oUsuario.ListaUsuarioAlmacen != null)
                            {
                                foreach (UsuarioAlmacenE oitem in oUsuario.ListaUsuarioAlmacen)
                                {
                                    if (oitem.Opcion == (Int32)EnumOpcionGrabar.Insertar)
                                    {
                                        new UsuarioAlmacenAD().InsertarUsuarioAlmacen(oitem);
                                    }
                                }
                            }

                            break;
                        case EnumOpcionGrabar.InsertarSimple:

                            //Actualizando las personas
                            new PersonaAD().ActualizarPersona(oUsuario.Persona);
                            oUsuario.IdPersona = oUsuario.Persona.IdPersona;
                            //Insertando el Usuario
                            oUsuario = new UsuarioAD().InsertarUsuario(oUsuario);

                            //Centros de Costo
                            new UsuarioCCostosAD().EliminarUsuarioCCostos(oUsuario.IdPersona);

                            if (oUsuario.listaUsuarioCCostos != null && oUsuario.listaUsuarioCCostos.Count > 0)
                            {
                                foreach (UsuarioCCostosE oitem in oUsuario.listaUsuarioCCostos)
                                {
                                    oitem.idPersona = oUsuario.IdPersona;
                                    new UsuarioCCostosAD().InsertarUsuarioCCostos(oitem);
                                }
                            }

                            //Series
                            new UsuarioSeriesAD().EliminarUsuarioSeries(oUsuario.Empresa.IdEmpresa, oUsuario.Persona.IdPersona);

                            if (oUsuario.ListaSeries != null && oUsuario.ListaSeries.Count > 0)
                            {
                                foreach (UsuarioSeriesE item in oUsuario.ListaSeries)
                                {
                                    item.idUsuario = oUsuario.Persona.IdPersona;
                                    new UsuarioSeriesAD().InsertarUsuarioSeries(item);
                                }
                            }

                            break;
                        case EnumOpcionGrabar.Insertar:

                            //Insertando personas
                            oUsuario.Persona = new PersonaAD().InsertarPersona(oUsuario.Persona);
                            oUsuario.IdPersona = oUsuario.Persona.IdPersona;
                            //Insertando al Usuario
                            oUsuario = new UsuarioAD().InsertarUsuario(oUsuario);

                            //Centros de Costo
                            if (oUsuario.listaUsuarioCCostos != null)
                            {
                                foreach (UsuarioCCostosE oitem in oUsuario.listaUsuarioCCostos)
                                {
                                    oitem.idPersona = oUsuario.IdPersona;
                                    new UsuarioCCostosAD().InsertarUsuarioCCostos(oitem);
                                }
                            }

                            //Planillas
                            if (oUsuario.ListaUsuarioPlanilla != null)
                            {
                                foreach (UsuarioPlanillaE oitem in oUsuario.ListaUsuarioPlanilla)
                                {
                                    oitem.idPersona = oUsuario.Persona.IdPersona;
                                    new UsuarioPlanillaAD().InsertarUsuarioPlanilla(oitem);
                                }
                            }

                            //Series
                            if (oUsuario.ListaSeries != null)
                            {
                                foreach (UsuarioSeriesE oitem in oUsuario.ListaSeries)
                                {
                                    oitem.idUsuario = oUsuario.Persona.IdPersona;
                                    new UsuarioSeriesAD().InsertarUsuarioSeries(oitem);
                                }
                            }

                            //Usuario Almacen
                            if (oUsuario.ListaUsuarioAlmacen != null)
                            {
                                foreach (UsuarioAlmacenE oitem in oUsuario.ListaUsuarioAlmacen)
                                {
                                    new UsuarioAlmacenAD().InsertarUsuarioAlmacen(oitem);
                                }
                            }

                            break;
                        default:
                            break;
                    }

                    oTrans.Complete();
                }

                return oUsuario;
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

        public Usuario InsertarUsuario(Usuario usuario)
        {
            try
            {
                using (TransactionScope tx = new TransactionScope())
                {
                    if (usuario.Persona.IdPersona == 0)
                    {
                        usuario.Persona = new PersonaAD().InsertarPersona(usuario.Persona);
                        usuario.IdPersona = usuario.Persona.IdPersona;
                    }
                    else
                    {
                        usuario.Persona = new PersonaAD().ActualizarPersona(usuario.Persona);
                        usuario.IdPersona = usuario.Persona.IdPersona;
                    }

                    usuario = new UsuarioAD().InsertarUsuario(usuario);

                    tx.Complete();
                    return usuario;
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

        public Usuario ActualizarUsuario(Usuario usuario)
        {
            try
            {
                using (TransactionScope tx = new TransactionScope())
                {
                    usuario.Persona = new PersonaLN().ActualizarPersona(usuario.Persona);
                    usuario = new UsuarioAD().ActualizarUsuario(usuario);

                    tx.Complete();
                    return usuario;
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

        public List<Usuario> ListarUsuario(String filtro, Boolean activo, Boolean inactivo)
        {
            try
            {
                return new UsuarioAD().ListarUsuario(filtro, activo, inactivo);
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

        public List<Usuario> ListarUsuarioTodos(String filtro, Int32? tipoPersona, Boolean activo, Boolean inactivo)
        {
            try
            {
                return new UsuarioAD().ListarUsuarioTodos(filtro, tipoPersona, activo, inactivo);
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

        public Int32 AnularUsuarioPorCodigo(Int32 IdPersona)
        {
            try
            {
                return new UsuarioAD().BorrarUsuario(IdPersona);
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

        public Usuario RecuperarUsuarioPorCodigo(Int32 IdPersona, Int32 idEmpresa, String BuscarOtros = "N")
        {
            try
            {
                Usuario oUsuario = new UsuarioAD().RecuperarUsuarioPorCodigo(IdPersona, idEmpresa);

                if (BuscarOtros == "S")
                {
                    if (oUsuario != null)
                    {
                        //Persona
                        oUsuario.Persona = new PersonaAD().RecuperarPersonaPorID(IdPersona);
                        //Centro de Costos
                        oUsuario.listaUsuarioCCostos = new UsuarioCCostosAD().ListarUsuarioCCostos(IdPersona, idEmpresa);
                        //Serie
                        oUsuario.ListaSeries = new UsuarioSeriesAD().ListarUsuarioSeries(idEmpresa, IdPersona);

                        //PLANILLAS
                        oUsuario.ListaUsuarioPlanilla = new UsuarioPlanillaAD().ListarUsuarioPlanilla(idEmpresa,IdPersona );
                        //Puntos de Requerimientos
                        oUsuario.ListaPuntosReq = new UsuarioPuntoRequeAD().ListarUsuarioPuntoReque(IdPersona);

                        //Puntos de Requerimientos
                        oUsuario.ListaUsuarioAlmacen = new UsuarioAlmacenAD().ListarUsuarioAlmacen(IdPersona,idEmpresa);
                    }
                }

                return oUsuario;
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

        public Usuario CambiarEstadoUsuario(Int32 IdPersona, Boolean estado)
        {
            try
            {
                return new UsuarioAD().CambiarEstadoUsuario(IdPersona, estado);
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

        public Usuario ValidarUsuario(String Credencial, Byte[] Clave)
        {
            Usuario u = null;
            try
            {
                u = new UsuarioAD().ValidarUsuario(Credencial, Clave);

                if (u != null)
                {
                    u.UsuarioEmpresas = new EmpresaAD().ListarEmpresaPorUsuario(u.IdPersona);
                    u.UsuarioLocales = new LocalAD().ListarLocalPorUsuario(u.IdPersona);
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
            return u;
        }

        public Usuario ValidarUsuarioEmpresa(Usuario u, Int32 IdEmpresa, Int32 IdLocal)
        {
            try
            {
                u.Roles = new RolAD().ListarRolPorUsuario(u.IdPersona, IdEmpresa);

                //u.Acciones = new AccionLN().ListarAccionUsuario(u.IdPersona, IdEmpresa);
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
            return u;
        }

        public List<Opcion> RecuperaOpcionesUsuarioEmpresa(Int32 IdPersona, Int32 idEmpresa)
        {
            try
            {
                return new OpcionAD().RecuperarOpcionPorUsuarioEmpresa(IdPersona, idEmpresa);
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

        public Boolean ModificarClave(String Credencial, Byte[] Clave, Boolean reset)
        {
            try
            {
                new UsuarioAD().ModificarClave(Credencial, Clave, reset);
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
            return true;
        }

        public Usuario RecuperarUsuarioAcccion(String Credencial, Byte[] Clave, Int32 IdEmpresa, Int32 IdAccion)
        {
            try
            {
                return new UsuarioAD().RecuperarUsuarioAcccion(Credencial, Clave, IdEmpresa, IdAccion);
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

        public List<Usuario> ListarUsuarioPorEmpresa(Int32 IdEmpresa, Int32 IdLocal, String filtro, String activo)
        {
            try
            {
                return new UsuarioAD().ListarUsuarioPorEmpresa(IdEmpresa, IdLocal, filtro, activo);
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

        public List<Usuario> ListarUsuarioPorEmpresayArea(Int32 IdEmpresa, Int32 IdLocal, String filtro, String activo)
        {
            try
            {
                List<Usuario> listaUsuario = new UsuarioAD().ListarUsuarioPorEmpresa(IdEmpresa, IdLocal, filtro, activo);

                foreach (Usuario u in listaUsuario)
                {
                    u.ListaUsuarioAreas = new UsuarioAreasAD().ListarUsuarioAreasPorEmpresa(IdEmpresa,IdLocal,u.IdPersona);
                }

                return listaUsuario;
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

        public List<Usuario> ListarUsuarioEmpresa(Int32 IdEmpresa, String filtro, String activo)
        {
            try
            {
                return new UsuarioAD().ListarUsuarioEmpresa(IdEmpresa, filtro, activo);
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

        public Byte[] ObtenerClaveUsuario(Int32 idPersona)
        {
            try
            {
                return new UsuarioAD().ObtenerClaveUsuario(idPersona);
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

        public List<Usuario> ListarUsuariosActivos()
        {
            try
            {
                List<Usuario> ListaDevuelta = new List<Usuario>();
                List<Usuario> ListaTmp = new UsuarioAD().ListarUsuariosActivos();
                ListaDevuelta.Add(new Usuario { IdPersona = 0, NombreCompuesto = Variables.Escoger });

                ListaDevuelta.AddRange(ListaTmp);

                return ListaDevuelta;
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
