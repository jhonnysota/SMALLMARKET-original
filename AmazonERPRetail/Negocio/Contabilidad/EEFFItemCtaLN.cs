using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;

using Entidades.Contabilidad;
using AccesoDatos.Contabilidad;

namespace Negocio.Contabilidad
{
    public class EEFFItemCtaLN
    {

        public Int32 MaxIdConEEFFItemCta(Int32 idEmpresa, int idEEFF, int idEEFFItem)
        {
            try
            {
                return new EEFFItemCtaAD().MaxIdConEEFFItemCta(idEmpresa,idEEFF,idEEFFItem);
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
        

        public EEFFItemCtaE InsertarEEFFItemCta(EEFFItemCtaE eeffitemcta)
        {
            try
            {
                return new EEFFItemCtaAD().InsertarEEFFItemCta(eeffitemcta);
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

        public EEFFItemCtaE ActualizarEEFFItemCta(EEFFItemCtaE eeffitemcta)
        {
            try
            {
                return new EEFFItemCtaAD().ActualizarEEFFItemCta(eeffitemcta);
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

        public int EliminarEEFFItemCta(Int32 idEMPRESA, Int32 idEEFF, Int32 idEEFFItem, Int32 idEEFFItemCta)
        {
            try
            {
                return new EEFFItemCtaAD().EliminarEEFFItemCta(idEMPRESA, idEEFF, idEEFFItem, idEEFFItemCta);
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

        public List<EEFFItemCtaE> ListarEEFFItemCta(Int32 idEmpresa, Int32 idEEFF, Int32 idEEFFItem, Int32 idLocal, String AnioPeriodo, String MesPeriodo)
        {
            try
            {
                return new EEFFItemCtaAD().ListarEEFFItemCta(idEmpresa, idEEFF, idEEFFItem, idLocal, AnioPeriodo, MesPeriodo);
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

        public EEFFItemCtaE ObtenerEEFFItemCta(Int32 idEMPRESA, Int32 idEEFF, Int32 idEEFFItem, Int32 idEEFFItemCta)
        {
            try
            {
                return new EEFFItemCtaAD().ObtenerEEFFItemCta(idEMPRESA, idEEFF, idEEFFItem, idEEFFItemCta);
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

        public List<EEFFItemCtaE> EEFFCtasNoAsignadas(Int32 idEmpresa, Int32 idEEFF, String AnioPeriodo, String MesPeriodo)
        {
            try
            {
                return new EEFFItemCtaAD().EEFFCtasNoAsignadas(idEmpresa, idEEFF, AnioPeriodo, MesPeriodo);
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
