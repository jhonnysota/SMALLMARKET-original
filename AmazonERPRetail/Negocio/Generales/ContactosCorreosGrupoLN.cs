using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;

using Entidades.Generales;
using AccesoDatos.Generales;
using Infraestructura.Enumerados;
using System.Transactions;

namespace Negocio.Generales
{
    public class ContactosCorreosGrupoLN
    {

        public ContactosCorreosGrupoE GrabarCorreoGrupo(ContactosCorreosGrupoE Grupo, EnumOpcionGrabar OpcionGrabacion)
        {
            try
            {
                using (TransactionScope oTrans = new TransactionScope())
                {
                    switch (OpcionGrabacion)
                    {
                        case EnumOpcionGrabar.Insertar:
                            
                            Grupo = new ContactosCorreosGrupoAD().InsertarContactosCorreosGrupo(Grupo);

                            if (Grupo.ListaCorreos != null)
                            {
                                Int32 id = new ContactosCorreosAD().MaximoGrupo(Grupo.idGrupo);
                                id++;

                                foreach (ContactosCorreosE item in Grupo.ListaCorreos)
                                {
                                    item.idGrupo = Grupo.idGrupo;
                                    item.idCorreo = id;
                                    item.CorreoDefecto = false;
                                    new ContactosCorreosAD().InsertarContactosCorreos(item);
                                    //Incrementando el id
                                    id++;
                                }
                            }

                            break;
                        case EnumOpcionGrabar.Actualizar:

                            Grupo = new ContactosCorreosGrupoAD().ActualizarContactosCorreosGrupo(Grupo);

                            if (Grupo.ListaCorreosEliminados != null)
                            {
                                foreach (ContactosCorreosE item in Grupo.ListaCorreosEliminados)
                                {
                                    new ContactosCorreosAD().EliminarContactosCorreos(item.idGrupo, item.idCorreo);
                                }
                            }

                            if (Grupo.ListaCorreos != null)
                            {
                                Int32 id = new ContactosCorreosAD().MaximoGrupo(Grupo.idGrupo);
                                id++;

                                foreach (ContactosCorreosE item in Grupo.ListaCorreos)
                                {
                                    item.idGrupo = Grupo.idGrupo;

                                    switch (item.Opcion)
                                    {
                                        case (Int32)EnumOpcionGrabar.Insertar:

                                            item.idGrupo = Grupo.idGrupo;
                                            item.idCorreo = id;
                                            item.CorreoDefecto = false;
                                            new ContactosCorreosAD().InsertarContactosCorreos(item);
                                            //Incrementando el id
                                            id++;

                                            break;
                                        case (Int32)EnumOpcionGrabar.Actualizar:

                                            item.CorreoDefecto = false;
                                            new ContactosCorreosAD().ActualizarContactosCorreos(item);

                                            break;
                                        default:
                                            break;
                                    }
                                    
                                }
                            }

                            break;
                        default:
                            break;
                    }

                    oTrans.Complete();
                }

                return Grupo;
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

        public ContactosCorreosGrupoE InsertarContactosCorreosGrupo(ContactosCorreosGrupoE contactoscorreosgrupo)
        {
            try
            {
                return new ContactosCorreosGrupoAD().InsertarContactosCorreosGrupo(contactoscorreosgrupo);
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

        public ContactosCorreosGrupoE ActualizarContactosCorreosGrupo(ContactosCorreosGrupoE contactoscorreosgrupo)
        {
            try
            {
                return new ContactosCorreosGrupoAD().ActualizarContactosCorreosGrupo(contactoscorreosgrupo);
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

        public int EliminarContactosCorreosGrupo(Int32 idGrupo)
        {
            try
            {
                return new ContactosCorreosGrupoAD().EliminarContactosCorreosGrupo(idGrupo);
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

        public List<ContactosCorreosGrupoE> ListarContactosCorreosGrupo(Int32 idUsuario)
        {
            try
            {
                return new ContactosCorreosGrupoAD().ListarContactosCorreosGrupo(idUsuario);
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

        public ContactosCorreosGrupoE ObtenerContactosCorreosGrupo(Int32 idGrupo)
        {
            try
            {
                ContactosCorreosGrupoE correosGrupo = new ContactosCorreosGrupoAD().ObtenerContactosCorreosGrupo(idGrupo);

                if (correosGrupo != null)
                {
                    correosGrupo.ListaCorreos = new ContactosCorreosAD().ListarContactosCorreosPorGrupo(idGrupo);
                }

                return correosGrupo;
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

        public Int32 RevisarCorreosGrupoPorDefecto(Int32 idGrupo, Int32 idUsuario)
        {
            try
            {
                return new ContactosCorreosGrupoAD().RevisarCorreosGrupoPorDefecto(idGrupo, idUsuario);
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
