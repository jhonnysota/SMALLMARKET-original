using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;

using Entidades.CtasPorCobrar;
using AccesoDatos.CtasPorCobrar;

namespace Negocio.CtasPorCobrar
{
    public class CobranzasItemDetLN 
    {

        public CobranzasItemDetE InsertarCobranzasItemDet(CobranzasItemDetE cobranzasitemdet)
        {
            try
            {
                return new CobranzasItemDetAD().InsertarCobranzasItemDet(cobranzasitemdet);
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

        public CobranzasItemDetE ActualizarCobranzasItemDet(CobranzasItemDetE cobranzasitemdet)
        {
            try
            {
                return new CobranzasItemDetAD().ActualizarCobranzasItemDet(cobranzasitemdet);
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

        public int EliminarCobranzasItemDet(Int32 idPlanilla, Int32 Recibo, Int32 item)
        {
            try
            {
                return new CobranzasItemDetAD().EliminarCobranzasItemDet(idPlanilla, Recibo, item);
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

        public List<CobranzasItemDetE> ListarCobranzasItemDet(Int32 idPlanilla, Int32 Recibo)
        {
            try
            {
                return new CobranzasItemDetAD().ListarCobranzasItemDet(idPlanilla, Recibo);
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

        public CobranzasItemDetE ObtenerCobranzasItemDet(Int32 idPlanilla, Int32 Recibo, Int32 item)
        {
            try
            {
                return new CobranzasItemDetAD().ObtenerCobranzasItemDet(idPlanilla, Recibo, item);
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

        public List<CobranzasItemDetE> ListarCobranzasItemDetPorLetra(Int32 idEmpresa, Int32 idLocal, Int32 idPersona, String numLetra)
        {
            try
            {
                return new CobranzasItemDetAD().ListarCobranzasItemDetPorLetra(idEmpresa, idLocal, idPersona, numLetra);
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

        public List<CobranzasItemDetE> ListarCobranzasLetrasPorPlanilla(Int32 idPlanilla)
        {
            try
            {
                return new CobranzasItemDetAD().ListarCobranzasLetrasPorPlanilla(idPlanilla);
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
