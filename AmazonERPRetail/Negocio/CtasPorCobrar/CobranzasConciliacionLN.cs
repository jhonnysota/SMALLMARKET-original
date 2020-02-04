using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;

using Entidades.CtasPorCobrar;
using AccesoDatos.CtasPorCobrar;

namespace Negocio.CtasPorCobrar
{
    public class CobranzasConciliacionLN
    {

        public CobranzasConciliacionE InsertarCobranzasConciliacion(CobranzasConciliacionE cobranzasconciliacion)
        {
            try
            {
                return new CobranzasConciliacionAD().InsertarCobranzasConciliacion(cobranzasconciliacion);
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

        public CobranzasConciliacionE ActualizarCobranzasConciliacion(CobranzasConciliacionE cobranzasconciliacion)
        {
            try
            {
                return new CobranzasConciliacionAD().ActualizarCobranzasConciliacion(cobranzasconciliacion);
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

        public Int32 EliminarCobranzasConciliacion(Int32 idPersona, Int32 idEmpresa, DateTime fecIni, DateTime fecFin, String codCuenta)
        {
            try
            {
                return new CobranzasConciliacionAD().EliminarCobranzasConciliacion(idPersona, idEmpresa, fecIni, fecFin, codCuenta);
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

        public List<CobranzasConciliacionE> ListarCobranzasConciliacion(Int32 idEmpresa, DateTime fecIni, DateTime fecFin, String codCuenta)
        {
            try
            {
                return new CobranzasConciliacionAD().ListarCobranzasConciliacion(idEmpresa, fecIni, fecFin, codCuenta);
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

        public CobranzasConciliacionE ObtenerCobranzasConciliacion(Int32 numitem)
        {
            try
            {
                return new CobranzasConciliacionAD().ObtenerCobranzasConciliacion(numitem);
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
