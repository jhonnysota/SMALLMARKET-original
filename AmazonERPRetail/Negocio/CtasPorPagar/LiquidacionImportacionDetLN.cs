using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;

using Entidades.CtasPorPagar;
using AccesoDatos.CtasPorPagar;

namespace Negocio.CtasPorPagar
{
    public class LiquidacionImportacionDetLN
    {

        public LiquidacionImportacionDetE InsertarLiquidacionImportacionDet(LiquidacionImportacionDetE liquidacionimportaciondet)
        {
            try
            {
                return new LiquidacionImportacionDetAD().InsertarLiquidacionImportacionDet(liquidacionimportaciondet);
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

        public LiquidacionImportacionDetE ActualizarLiquidacionImportacionDet(LiquidacionImportacionDetE liquidacionimportaciondet)
        {
            try
            {
                return new LiquidacionImportacionDetAD().ActualizarLiquidacionImportacionDet(liquidacionimportaciondet);
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

        public int EliminarLiquidacionImportacionDet(Int32 idItem)
        {
            try
            {
                return new LiquidacionImportacionDetAD().EliminarLiquidacionImportacionDet(idItem);
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

        public List<LiquidacionImportacionDetE> ListarLiquidacionImportacionDet(Int32 idLiquidacion)
        {
            try
            {
                return new LiquidacionImportacionDetAD().ListarLiquidacionImportacionDet(idLiquidacion);
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

        public LiquidacionImportacionDetE ObtenerLiquidacionImportacionDet(Int32 idItem)
        {
            try
            {
                return new LiquidacionImportacionDetAD().ObtenerLiquidacionImportacionDet(idItem);
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
