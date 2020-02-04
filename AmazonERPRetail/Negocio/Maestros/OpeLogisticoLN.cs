using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Transactions;

using Entidades.Maestros;
using AccesoDatos.Maestros;
using Infraestructura.Enumerados;

namespace Negocio.Maestros
{
    public class OpeLogisticoLN
    {

        public OpeLogisticoE GrabarOpeLogistico(OpeLogisticoE OpeLogistico, EnumOpcionGrabar OpcionGrabar)
        {
            try
            {
                using (TransactionScope oTrans = new TransactionScope())
                {
                    switch (OpcionGrabar)
                    {
                        case EnumOpcionGrabar.Actualizar:

                            //Actualizando las personas
                            new PersonaAD().ActualizarPersona(OpeLogistico.Persona);
                            //Actualizando el Cliente
                            new OpeLogisticoAD().ActualizarOpeLogistico(OpeLogistico);
                            //Contactos... por hacer

                            break;
                        case EnumOpcionGrabar.InsertarSimple:

                            //Actualizando las personas
                            new PersonaAD().ActualizarPersona(OpeLogistico.Persona);
                            OpeLogistico.idPersona = OpeLogistico.Persona.IdPersona;
                            //Insertando el proveedor
                            OpeLogistico = new OpeLogisticoAD().InsertarOpeLogistico(OpeLogistico);

                            //Sucursales... por hacer

                            break;
                        case EnumOpcionGrabar.Insertar:

                            //Insertando personas
                            OpeLogistico.Persona = new PersonaAD().InsertarPersona(OpeLogistico.Persona);
                            OpeLogistico.idPersona = OpeLogistico.Persona.IdPersona;
                            //Insertando el Cliente
                            OpeLogistico = new OpeLogisticoAD().InsertarOpeLogistico(OpeLogistico);

                            //Sucursales... por hacer

                            break;
                        default:
                            break;
                    }

                    oTrans.Complete();
                }

                return OpeLogistico;
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

        public OpeLogisticoE InsertarOpeLogistico(OpeLogisticoE opelogistico)
        {
            try
            {
                return new OpeLogisticoAD().InsertarOpeLogistico(opelogistico);
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

        public OpeLogisticoE ActualizarOpeLogistico(OpeLogisticoE opelogistico)
        {
            try
            {
                return new OpeLogisticoAD().ActualizarOpeLogistico(opelogistico);
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

        //public int EliminarOpeLogistico(Int32 idPersona, Int32 idEmpresa)
        //{
        //    try
        //    {
        //        return new OpeLogisticoAD().EliminarOpeLogistico(idPersona, idEmpresa);
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

        public List<OpeLogisticoE> ListarOpeLogistico()
        {
            try
            {
                return new OpeLogisticoAD().ListarOpeLogistico();
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

        public OpeLogisticoE ObtenerOpeLogistico(Int32 idPersona, Int32 idEmpresa)
        {
            try
            {
                return new OpeLogisticoAD().ObtenerOpeLogistico(idPersona, idEmpresa);
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

        public List<OpeLogisticoE> ListarOpeLogPorParametro(Int32 idEmpresa, String RazonSocial, String NroDocumento, Boolean activo, Boolean inactivo)
        {
            try
            {
                return new OpeLogisticoAD().ListarOpeLogPorParametro(idEmpresa, RazonSocial, NroDocumento, activo, inactivo);
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

        public OpeLogisticoE RecuperarOpeLogPorId(Int32 idPersona, Int32 idEmpresa)
        {
            try
            {
                return new OpeLogisticoAD().RecuperarOpeLogPorId(idPersona, idEmpresa);
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
