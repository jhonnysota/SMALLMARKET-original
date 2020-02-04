using System;
using System.Text;
using System.Data.SqlClient;

using Entidades.Tesoreria;
using AccesoDatos.Tesoreria;

namespace Negocio.Tesoreria
{
    public class AnticipoCtaCteDetLN
    {

        public AnticipoCtaCteDetE InsertarAnticipoCtaCteDet(AnticipoCtaCteDetE ctacte_det)
        {
            try
            {
                return new AnticipoCtaCteDetAD().InsertarAnticipoCtaCteDet(ctacte_det);
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

        public AnticipoCtaCteDetE ActualizarAnticipoCtaCteDet(AnticipoCtaCteDetE ctacte_det)
        {
            try
            {
                return new AnticipoCtaCteDetAD().ActualizarAnticipoCtaCteDet(ctacte_det);
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

        public AnticipoCtaCteDetE ObtenerAnticipoCtaCteDet(Int32 idEmpresa, String numAnio, String numMes, Int32 IdPersona, String idDocumento, String NumSerie, String NumDocumento, String idDocumentoOrig, String NumSerieOrig, String NumDocOrig)
        {
            try
            {
                return new AnticipoCtaCteDetAD().ObtenerAnticipoCtaCteDet(idEmpresa, numAnio, numMes, IdPersona, idDocumento, NumSerie, NumDocumento, idDocumentoOrig, NumSerieOrig, NumDocOrig);
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
