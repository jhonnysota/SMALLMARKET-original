using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;

using Entidades.CtasPorPagar;
using AccesoDatos.CtasPorPagar;

namespace Negocio.CtasPorPagar
{
    public class LiquidacionSaldosLN
    {

        public LiquidacionSaldosE InsertarLiquidacionSaldos(LiquidacionSaldosE liquidacionsaldos)
        {
            try
            {
                return new LiquidacionSaldosAD().InsertarLiquidacionSaldos(liquidacionsaldos);
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

        public LiquidacionSaldosE ActualizarLiquidacionSaldos(LiquidacionSaldosE liquidacionsaldos)
        {
            try
            {
                return new LiquidacionSaldosAD().ActualizarLiquidacionSaldos(liquidacionsaldos);
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

        public int EliminarLiquidacionSaldos(Int32 idEmpresa, Int32 idLocal, Int32 idPersona, String codOrdenPago)
        {
            try
            {
                return new LiquidacionSaldosAD().EliminarLiquidacionSaldos(idEmpresa, idLocal, idPersona, codOrdenPago);
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

        public List<LiquidacionSaldosE> ListarLiquidacionSaldos(Int32 idEmpresa, Int32 idLocal)
        {
            try
            {
                return new LiquidacionSaldosAD().ListarLiquidacionSaldos(idEmpresa, idLocal);
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

        public LiquidacionSaldosE ObtenerLiquidacionSaldos(Int32 idEmpresa, Int32 idLocal, Int32 idPersona)
        {
            try
            {
                return new LiquidacionSaldosAD().ObtenerLiquidacionSaldos(idEmpresa, idLocal, idPersona);
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

        public LiquidacionSaldosE ObtenerSaldosPorIdLiquidacion(Int32 idEmpresa, Int32 idLocal, Int32 idPersona, Int32 idLiquidacion)
        {
            try
            {
                return new LiquidacionSaldosAD().ObtenerSaldosPorIdLiquidacion(idEmpresa, idLocal, idPersona, idLiquidacion);
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
