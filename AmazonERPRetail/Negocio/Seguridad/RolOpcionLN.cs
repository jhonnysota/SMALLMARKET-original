using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Transactions;

using Entidades.Seguridad;
using AccesoDatos.Seguridad;

namespace Negocio.Seguridad
{
    public class RolOpcionLN
    {
        
        RolOpcion rolopcion=null;
        public String InsertarRolOpcion(List<Rol> RolesOpciones,int idempresa)
        {
            try
            {
                using (TransactionScope tx = new TransactionScope())
                {
                    foreach (Rol r in RolesOpciones)
                    {
                        new RolOpcionAD().BorrarRolOpcion(r.IdRol);

                        foreach (Opcion o in r.OpcionesRol) 
                        {
                            rolopcion = new RolOpcion
                            {
                                IdOpcion = o.IdOpcion,
                                IdRol = r.IdRol,
                                Acceso = o.control
                            };
                            new RolOpcionAD().InsertarRolOpcion(rolopcion);                            
                        }                                   
                    }

                    tx.Complete();
                    return "Opciones Guardadas";
                }
            }
            catch (Exception)
            {
                return "Opciones no pudieron ser Guardadas";
                throw;
            }
        }

        public RolOpcion ActualizarRolOpcion(RolOpcion rolopcion)
        {
            try
            {
                return new RolOpcionAD().ActualizarRolOpcion(rolopcion);
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

        public List<RolOpcion> ListarRolOpcion(int inRol)
        {
            try
            {
                return new RolOpcionAD().ListarRolOpcion(inRol);
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

        public int AnularRolOpcionPorCodigo(int IdRol)
        {
            try
            {
                return new RolOpcionAD().BorrarRolOpcion(IdRol);
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

        public RolOpcion RecuperarRolOpcionPorCodigo(int IdRol, int IdOpcion, int IdEmpresa)
        {
            try
            {
                return new RolOpcionAD().RecuperarRolOpcionPorCodigo(IdRol, IdOpcion, IdEmpresa);
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

        ///////////////////////////// NUEVOS ////////////////////////////////
        public string GrabarRolOpcion(Rol oRolOpcion)
        {
            try
            {
                using (TransactionScope tx = new TransactionScope())
                {
                    new RolOpcionAD().BorrarRolOpcion(oRolOpcion.IdRol);

                    foreach (Opcion o in oRolOpcion.OpcionesRol)
                    {
                        rolopcion = new RolOpcion
                        {
                            IdOpcion = o.IdOpcion,
                            IdRol = oRolOpcion.IdRol,
                            Acceso = false
                        };

                        new RolOpcionAD().InsertarRolOpcion(rolopcion);
                    }

                    tx.Complete();

                    return "Opciones Guardadas";
                }
            }
            catch (Exception)
            {
                return "Opciones no pudieron ser Guardadas";
                throw;
            }
        }

    }
}
