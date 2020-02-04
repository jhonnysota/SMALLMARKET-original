using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

using Entidades;
using AccesoDatos;
using Infraestructura;
using Entidades.Contabilidad;
using AccesoDatos.Contabilidad;
//using Negocio.Base;

namespace Negocio.Contabilidad
{
    public class EEFFItemXlsLN //: BaseLN
    {
        public EEFFItemXlsE InsertarEEFFItemXls(EEFFItemXlsE eeffitemxls)
        {
            try
            {
                return new EEFFItemXlsAD().InsertarEEFFItemXls(eeffitemxls);
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

        public EEFFItemXlsE ActualizarEEFFItemXls(EEFFItemXlsE eeffitemxls)
        {
            try
            {
                return new EEFFItemXlsAD().ActualizarEEFFItemXls(eeffitemxls);
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

        public int EliminarEEFFItemXls(Int32 idEMPRESA, Int32 idEEFF, Int32 idEEFFItem, Int32 idEEFFItemXls)
        {
            try
            {
                return new EEFFItemXlsAD().EliminarEEFFItemXls(idEMPRESA, idEEFF, idEEFFItem, idEEFFItemXls);
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

        public List<EEFFItemXlsE> ListarEEFFItemXls(Int32 idEMPRESA, Int32 idEEFF, Int32 idEEFFItem)
        {
            try
            {
                return new EEFFItemXlsAD().ListarEEFFItemXls( idEMPRESA, idEEFF, idEEFFItem);
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

        public EEFFItemXlsE ObtenerEEFFItemXls(Int32 idEMPRESA, Int32 idEEFF, Int32 idEEFFItem, Int32 idEEFFItemXls)
        {
            try
            {
                return new EEFFItemXlsAD().ObtenerEEFFItemXls(idEMPRESA, idEEFF, idEEFFItem, idEEFFItemXls);
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
