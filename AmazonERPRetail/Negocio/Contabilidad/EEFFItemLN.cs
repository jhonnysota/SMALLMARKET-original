using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

using Entidades.Contabilidad;
using AccesoDatos.Contabilidad;
using Infraestructura;
//using Negocio.Base;

namespace Negocio.Contabilidad
{
    public class EEFFItemLN //: BaseLN
    {
        // ===========================================================================================================================
        // INSERT
        // ===========================================================================================================================
        public EEFFItemE InsertarEEFFItem(EEFFItemE entidad)
        {
            try
            {
                return new EEFFItemAD().InsertarEEFFItem(entidad);
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

        // ===========================================================================================================================
        // ACTUALIZAR
        // ===========================================================================================================================
        public EEFFItemE ActualizarEEFFItem(EEFFItemE periodos)
        {
            try
            {
                return new EEFFItemAD().ActualizarEEFFItem(periodos);
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

       
        // ===========================================================================================================================
        // ELIMINAR
        // ===========================================================================================================================
        public int EliminarEEFFItem(int idEmpresa, int idEEFF, int idEEFFItem)
        {
            try
            {
                return new EEFFItemAD().EliminarEEFFItem(idEmpresa, idEEFF, idEEFFItem);
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

        // ===========================================================================================================================
        // OBTENER 
        // ===========================================================================================================================
        public EEFFItemE ObtenerEEFFItem(int idEmpresa, int idEEFF, int idEEFFItem)
        {
            try
            {
                //Cabecera
                EEFFItemE Entidad = new EEFFItemAD().ObtenerEEFFItem(idEmpresa, idEEFF, idEEFFItem);

                return Entidad;
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


        public List<EEFFItemE> ListarEEFFItem(int idEmpresa, int idEEFF)
        {
            try
            {
                return new EEFFItemAD().ListarEEFFItem(idEmpresa, idEEFF);
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


        public List<EEFFItemE> ListarConEEFFItemParPres(int idEmpresa, int idEEFF)
        {
            try
            {
                return new EEFFItemAD().ListarConEEFFItemParPres(idEmpresa, idEEFF);
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

        // ===========================================================================================================================
        // END
        // ===========================================================================================================================
    }
}
